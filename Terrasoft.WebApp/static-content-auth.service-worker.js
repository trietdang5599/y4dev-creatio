const SET_AUTH_STATE_MESSAGE_TYPE = 'static-content.auth.state.set';
const CLEAR_AUTH_STATE_MESSAGE_TYPE = 'static-content.auth.state.clear';
const REQUEST_AUTH_STATE_MESSAGE_TYPE = 'static-content.auth.state.request';
const AUTH_STATE_REQUEST_TIMEOUT_MS = 400;
const SERVICE_WORKER_FILE_NAME = '/static-content-auth.service-worker.js';

const authStateByClientId = new Map();
const pendingAuthStateRequestsByClientId = new Map();

function getClientIdFromSource(source) {
	return source?.id;
}

function normalizeExpiresAt(value) {
	const expiresAt = Number(value);
	return Number.isFinite(expiresAt) ? expiresAt : null;
}

function getValidAuthState(clientId) {
	if (!clientId) {
		return null;
	}
	const authState = authStateByClientId.get(clientId);
	if (!authState?.accessToken) {
		return null;
	}
	if (typeof authState.expiresAt === 'number' && authState.expiresAt <= Date.now()) {
		authStateByClientId.delete(clientId);
		return null;
	}
	return authState;
}

function resolvePendingAuthStateRequest(clientId, authState) {
	const pendingRequest = pendingAuthStateRequestsByClientId.get(clientId);
	if (!pendingRequest) {
		return;
	}
	pendingAuthStateRequestsByClientId.delete(clientId);
	pendingRequest.resolve(authState);
}

function setAuthState(clientId, payload) {
	const hasAccessToken = payload && typeof payload.accessToken === 'string' && !!payload.accessToken;
	if (!clientId || !hasAccessToken) {
		return;
	}
	const authState = {
		accessToken: payload.accessToken,
		expiresAt: normalizeExpiresAt(payload.expiresAt),
	};
	authStateByClientId.set(clientId, authState);
	resolvePendingAuthStateRequest(clientId, getValidAuthState(clientId));
}

function clearAuthState(clientId) {
	if (!clientId) {
		return;
	}
	authStateByClientId.delete(clientId);
	resolvePendingAuthStateRequest(clientId, null);
}

function createPendingAuthStateRequest(clientId) {
	let resolvePromise = () => undefined;
	const timeoutId = setTimeout(() => {
		pendingAuthStateRequestsByClientId.delete(clientId);
		resolvePromise(getValidAuthState(clientId));
	}, AUTH_STATE_REQUEST_TIMEOUT_MS);
	const promise = new Promise((resolve) => {
		resolvePromise = resolve;
	});
	return {
		promise,
		resolve(authState) {
			clearTimeout(timeoutId);
			resolvePromise(authState);
		},
	};
}

async function requestAuthStateFromClient(clientId) {
	if (!clientId) {
		return null;
	}
	const currentAuthState = getValidAuthState(clientId);
	if (currentAuthState) {
		return currentAuthState;
	}
	const pendingRequest = pendingAuthStateRequestsByClientId.get(clientId);
	if (pendingRequest) {
		return pendingRequest.promise;
	}
	const client = await self.clients.get(clientId);
	if (!client) {
		return null;
	}
	const nextPendingRequest = createPendingAuthStateRequest(clientId);
	pendingAuthStateRequestsByClientId.set(clientId, nextPendingRequest);
	client.postMessage({ type: REQUEST_AUTH_STATE_MESSAGE_TYPE });
	return nextPendingRequest.promise;
}

function isClientScriptRequest(url) {
	return /\/api\/ClientScript(?:\/|$)/i.test(url.pathname) || /GenerateViewModuleScripts/i.test(url.search);
}

function shouldInterceptRequest(request) {
	if (request.method !== 'GET') {
		return false;
	}
	const url = new URL(request.url);
	if (url.origin !== self.location.origin) {
		return false;
	}
	if (!url.href.startsWith(self.registration.scope)) {
		return false;
	}
	if (url.pathname.endsWith(SERVICE_WORKER_FILE_NAME)) {
		return false;
	}
	return url.pathname.includes('/conf/content') || isClientScriptRequest(url);
}

function createAuthenticatedRequest(request, accessToken) {
	const headers = new Headers(request.headers);
	headers.set('Authorization', 'Bearer ' + accessToken);
	return new Request(request.url, {
		cache: request.cache,
		credentials: request.credentials,
		headers,
		integrity: request.integrity,
		keepalive: request.keepalive,
		method: request.method,
		mode: 'same-origin',
		redirect: request.redirect,
		referrer: request.referrer,
		referrerPolicy: request.referrerPolicy,
	});
}

async function handleInterceptedRequest(event) {
	const clientId = event.clientId || event.resultingClientId;
	let authState = getValidAuthState(clientId);
	if (!authState) {
		authState = await requestAuthStateFromClient(clientId);
	}
	if (!authState) {
		return fetch(event.request);
	}
	try {
		const response = await fetch(createAuthenticatedRequest(event.request, authState.accessToken));
		if (response.status === 401 || response.status === 403) {
			clearAuthState(clientId);
		}
		return response;
	} catch (error) {
		console.error('Authenticated request failed', {
			clientId,
			url: event.request.url,
			method: event.request.method,
			error: error instanceof Error ? error.message : String(error),
		});
		return fetch(event.request);
	}
}

self.addEventListener('install', (event) => {
	event.waitUntil(self.skipWaiting());
});

self.addEventListener('activate', (event) => {
	event.waitUntil(self.clients.claim());
});

self.addEventListener('message', (event) => {
	if (event.origin !== self.location.origin) {
		return;
	}
	const clientId = getClientIdFromSource(event.source);
	if (event.data?.type === SET_AUTH_STATE_MESSAGE_TYPE) {
		setAuthState(clientId, event.data.payload);
		return;
	}
	if (event.data?.type === CLEAR_AUTH_STATE_MESSAGE_TYPE) {
		clearAuthState(clientId);
	}
});

self.addEventListener('fetch', (event) => {
	if (!shouldInterceptRequest(event.request)) {
		return;
	}
	event.respondWith(handleInterceptedRequest(event));
});
