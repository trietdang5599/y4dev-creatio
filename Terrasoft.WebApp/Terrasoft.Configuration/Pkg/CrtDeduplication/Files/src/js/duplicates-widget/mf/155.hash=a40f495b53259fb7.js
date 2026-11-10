(self.webpackChunkapp_studio_enterprise_duplicates_widget=self.webpackChunkapp_studio_enterprise_duplicates_widget||[]).push([[155],{34630(O,h,a){a.d(h,{Rc:()=>b,Sx:()=>g,_J:()=>u});var c=a(15047),i=a(39638);const g=new i.InjectionToken("MATERIAL_ANIMATIONS");let p=null;function u(){return(0,i.inject)(g,{optional:!0})?.animationsDisabled||(0,i.inject)(i.ANIMATION_MODULE_TYPE,{optional:!0})==="NoopAnimations"?"di-disabled":(p??=(0,i.inject)(c.MediaMatcher).matchMedia("(prefers-reduced-motion)").matches,p?"reduced-motion":"enabled")}function b(){return u()!=="enabled"}},84350(O,h,a){a.d(h,{$E:()=>L,EX:()=>T,Ex:()=>o,Ge:()=>M,r6:()=>E,ug:()=>v});var c=a(52455),i=a(39638),g=a(60447),p=a(73971),u=a(4295),b=a(34630),o;(function(l){l[l.FADING_IN=0]="FADING_IN",l[l.VISIBLE=1]="VISIBLE",l[l.FADING_OUT=2]="FADING_OUT",l[l.HIDDEN=3]="HIDDEN"})(o||(o={}));class M{_renderer;element;config;_animationForciblyDisabledThroughCss;state=o.HIDDEN;constructor(e,t,n,s=!1){this._renderer=e,this.element=t,this.config=n,this._animationForciblyDisabledThroughCss=s}fadeOut(){this._renderer.fadeOutRipple(this)}}const A=(0,c.normalizePassiveListenerOptions)({passive:!0,capture:!0});class x{_events=new Map;addHandler(e,t,n,s){const r=this._events.get(t);if(r){const _=r.get(n);_?_.add(s):r.set(n,new Set([s]))}else this._events.set(t,new Map([[n,new Set([s])]])),e.runOutsideAngular(()=>{document.addEventListener(t,this._delegateEventHandler,A)})}removeHandler(e,t,n){const s=this._events.get(e);if(!s)return;const r=s.get(t);r&&(r.delete(n),r.size===0&&s.delete(t),s.size===0&&(this._events.delete(e),document.removeEventListener(e,this._delegateEventHandler,A)))}_delegateEventHandler=e=>{const t=(0,c._getEventTarget)(e);t&&this._events.get(e.type)?.forEach((n,s)=>{(s===t||s.contains(t))&&n.forEach(r=>r.handleEvent(e))})}}const T={enterDuration:225,exitDuration:150},S=800,w=(0,c.normalizePassiveListenerOptions)({passive:!0,capture:!0}),C=["mousedown","touchstart"],P=["mouseup","mouseleave","touchend","touchcancel"];class f{static \u0275fac=function(t){return new(t||f)};static \u0275cmp=i.\u0275\u0275defineComponent({type:f,selectors:[["ng-component"]],hostAttrs:["mat-ripple-style-loader",""],decls:0,vars:0,template:function(t,n){},styles:[`.mat-ripple {
  overflow: hidden;
  position: relative;
}
.mat-ripple:not(:empty) {
  transform: translateZ(0);
}

.mat-ripple.mat-ripple-unbounded {
  overflow: visible;
}

.mat-ripple-element {
  position: absolute;
  border-radius: 50%;
  pointer-events: none;
  transition: opacity, transform 0ms cubic-bezier(0, 0, 0.2, 1);
  transform: scale3d(0, 0, 0);
  background-color: var(--mat-ripple-color, color-mix(in srgb, var(--mat-sys-on-surface) 10%, transparent));
}
@media (forced-colors: active) {
  .mat-ripple-element {
    display: none;
  }
}
.cdk-drag-preview .mat-ripple-element, .cdk-drag-placeholder .mat-ripple-element {
  display: none;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&i.\u0275setClassMetadata(f,[{type:i.Component,args:[{template:"",changeDetection:i.ChangeDetectionStrategy.OnPush,encapsulation:i.ViewEncapsulation.None,host:{"mat-ripple-style-loader":""},styles:[`.mat-ripple {
  overflow: hidden;
  position: relative;
}
.mat-ripple:not(:empty) {
  transform: translateZ(0);
}

.mat-ripple.mat-ripple-unbounded {
  overflow: visible;
}

.mat-ripple-element {
  position: absolute;
  border-radius: 50%;
  pointer-events: none;
  transition: opacity, transform 0ms cubic-bezier(0, 0, 0.2, 1);
  transform: scale3d(0, 0, 0);
  background-color: var(--mat-ripple-color, color-mix(in srgb, var(--mat-sys-on-surface) 10%, transparent));
}
@media (forced-colors: active) {
  .mat-ripple-element {
    display: none;
  }
}
.cdk-drag-preview .mat-ripple-element, .cdk-drag-placeholder .mat-ripple-element {
  display: none;
}
`]}]}],null,null);class v{_target;_ngZone;_platform;_containerElement;_triggerElement=null;_isPointerDown=!1;_activeRipples=new Map;_mostRecentTransientRipple=null;_lastTouchStartEvent;_pointerUpEventsRegistered=!1;_containerRect=null;static _eventManager=new x;constructor(e,t,n,s,r){this._target=e,this._ngZone=t,this._platform=s,s.isBrowser&&(this._containerElement=(0,p.coerceElement)(n)),r&&r.get(u._CdkPrivateStyleLoader).load(f)}fadeInRipple(e,t,n={}){const s=this._containerRect=this._containerRect||this._containerElement.getBoundingClientRect(),r={...T,...n.animation};n.centered&&(e=s.left+s.width/2,t=s.top+s.height/2);const _=n.radius||B(e,t,s),H=e-s.left,j=t-s.top,D=r.enterDuration,d=document.createElement("div");d.classList.add("mat-ripple-element"),d.style.left=`${H-_}px`,d.style.top=`${j-_}px`,d.style.height=`${_*2}px`,d.style.width=`${_*2}px`,n.color!=null&&(d.style.backgroundColor=n.color),d.style.transitionDuration=`${D}ms`,this._containerElement.appendChild(d);const N=window.getComputedStyle(d),z=N.transitionProperty,F=N.transitionDuration,R=z==="none"||F==="0s"||F==="0s, 0s"||s.width===0&&s.height===0,m=new M(this,d,n,R);d.style.transform="scale3d(1, 1, 1)",m.state=o.FADING_IN,n.persistent||(this._mostRecentTransientRipple=m);let y=null;return!R&&(D||r.exitDuration)&&this._ngZone.runOutsideAngular(()=>{const U=()=>{y&&(y.fallbackTimer=null),clearTimeout(k),this._finishRippleTransition(m)},I=()=>this._destroyRipple(m),k=setTimeout(I,D+100);d.addEventListener("transitionend",U),d.addEventListener("transitioncancel",I),y={onTransitionEnd:U,onTransitionCancel:I,fallbackTimer:k}}),this._activeRipples.set(m,y),(R||!D)&&this._finishRippleTransition(m),m}fadeOutRipple(e){if(e.state===o.FADING_OUT||e.state===o.HIDDEN)return;const t=e.element,n={...T,...e.config.animation};t.style.transitionDuration=`${n.exitDuration}ms`,t.style.opacity="0",e.state=o.FADING_OUT,(e._animationForciblyDisabledThroughCss||!n.exitDuration)&&this._finishRippleTransition(e)}fadeOutAll(){this._getActiveRipples().forEach(e=>e.fadeOut())}fadeOutAllNonPersistent(){this._getActiveRipples().forEach(e=>{e.config.persistent||e.fadeOut()})}setupTriggerEvents(e){const t=(0,p.coerceElement)(e);!this._platform.isBrowser||!t||t===this._triggerElement||(this._removeTriggerEvents(),this._triggerElement=t,C.forEach(n=>{v._eventManager.addHandler(this._ngZone,n,t,this)}))}handleEvent(e){e.type==="mousedown"?this._onMousedown(e):e.type==="touchstart"?this._onTouchStart(e):this._onPointerUp(),this._pointerUpEventsRegistered||(this._ngZone.runOutsideAngular(()=>{P.forEach(t=>{this._triggerElement.addEventListener(t,this,w)})}),this._pointerUpEventsRegistered=!0)}_finishRippleTransition(e){e.state===o.FADING_IN?this._startFadeOutTransition(e):e.state===o.FADING_OUT&&this._destroyRipple(e)}_startFadeOutTransition(e){const t=e===this._mostRecentTransientRipple,{persistent:n}=e.config;e.state=o.VISIBLE,!n&&(!t||!this._isPointerDown)&&e.fadeOut()}_destroyRipple(e){const t=this._activeRipples.get(e)??null;this._activeRipples.delete(e),this._activeRipples.size||(this._containerRect=null),e===this._mostRecentTransientRipple&&(this._mostRecentTransientRipple=null),e.state=o.HIDDEN,t!==null&&(e.element.removeEventListener("transitionend",t.onTransitionEnd),e.element.removeEventListener("transitioncancel",t.onTransitionCancel),t.fallbackTimer!==null&&clearTimeout(t.fallbackTimer)),e.element.remove()}_onMousedown(e){const t=(0,g.isFakeMousedownFromScreenReader)(e),n=this._lastTouchStartEvent&&Date.now()<this._lastTouchStartEvent+S;!this._target.rippleDisabled&&!t&&!n&&(this._isPointerDown=!0,this.fadeInRipple(e.clientX,e.clientY,this._target.rippleConfig))}_onTouchStart(e){if(!this._target.rippleDisabled&&!(0,g.isFakeTouchstartFromScreenReader)(e)){this._lastTouchStartEvent=Date.now(),this._isPointerDown=!0;const t=e.changedTouches;if(t)for(let n=0;n<t.length;n++)this.fadeInRipple(t[n].clientX,t[n].clientY,this._target.rippleConfig)}}_onPointerUp(){this._isPointerDown&&(this._isPointerDown=!1,this._getActiveRipples().forEach(e=>{const t=e.state===o.VISIBLE||e.config.terminateOnPointerUp&&e.state===o.FADING_IN;!e.config.persistent&&t&&e.fadeOut()}))}_getActiveRipples(){return Array.from(this._activeRipples.keys())}_removeTriggerEvents(){const e=this._triggerElement;e&&(C.forEach(t=>v._eventManager.removeHandler(t,e,this)),this._pointerUpEventsRegistered&&(P.forEach(t=>e.removeEventListener(t,this,w)),this._pointerUpEventsRegistered=!1))}}function B(l,e,t){const n=Math.max(Math.abs(l-t.left),Math.abs(l-t.right)),s=Math.max(Math.abs(e-t.top),Math.abs(e-t.bottom));return Math.sqrt(n*n+s*s)}const L=new i.InjectionToken("mat-ripple-global-options");class E{_elementRef=(0,i.inject)(i.ElementRef);_animationsDisabled=(0,b.Rc)();color;unbounded=!1;centered=!1;radius=0;animation;get disabled(){return this._disabled}set disabled(e){e&&this.fadeOutAllNonPersistent(),this._disabled=e,this._setupTriggerEventsIfEnabled()}_disabled=!1;get trigger(){return this._trigger||this._elementRef.nativeElement}set trigger(e){this._trigger=e,this._setupTriggerEventsIfEnabled()}_trigger;_rippleRenderer;_globalOptions;_isInitialized=!1;constructor(){const e=(0,i.inject)(i.NgZone),t=(0,i.inject)(c.Platform),n=(0,i.inject)(L,{optional:!0}),s=(0,i.inject)(i.Injector);this._globalOptions=n||{},this._rippleRenderer=new v(this,e,this._elementRef,t,s)}ngOnInit(){this._isInitialized=!0,this._setupTriggerEventsIfEnabled()}ngOnDestroy(){this._rippleRenderer._removeTriggerEvents()}fadeOutAll(){this._rippleRenderer.fadeOutAll()}fadeOutAllNonPersistent(){this._rippleRenderer.fadeOutAllNonPersistent()}get rippleConfig(){return{centered:this.centered,radius:this.radius,color:this.color,animation:{...this._globalOptions.animation,...this._animationsDisabled?{enterDuration:0,exitDuration:0}:{},...this.animation},terminateOnPointerUp:this._globalOptions.terminateOnPointerUp}}get rippleDisabled(){return this.disabled||!!this._globalOptions.disabled}_setupTriggerEventsIfEnabled(){!this.disabled&&this._isInitialized&&this._rippleRenderer.setupTriggerEvents(this.trigger)}launch(e,t=0,n){return typeof e=="number"?this._rippleRenderer.fadeInRipple(e,t,{...this.rippleConfig,...n}):this._rippleRenderer.fadeInRipple(0,0,{...this.rippleConfig,...e})}static \u0275fac=function(t){return new(t||E)};static \u0275dir=i.\u0275\u0275defineDirective({type:E,selectors:[["","mat-ripple",""],["","matRipple",""]],hostAttrs:[1,"mat-ripple"],hostVars:2,hostBindings:function(t,n){t&2&&i.\u0275\u0275classProp("mat-ripple-unbounded",n.unbounded)},inputs:{color:[0,"matRippleColor","color"],unbounded:[0,"matRippleUnbounded","unbounded"],centered:[0,"matRippleCentered","centered"],radius:[0,"matRippleRadius","radius"],animation:[0,"matRippleAnimation","animation"],disabled:[0,"matRippleDisabled","disabled"],trigger:[0,"matRippleTrigger","trigger"]},exportAs:["matRipple"]})}(typeof ngDevMode>"u"||ngDevMode)&&i.\u0275setClassMetadata(E,[{type:i.Directive,args:[{selector:"[mat-ripple], [matRipple]",exportAs:"matRipple",host:{class:"mat-ripple","[class.mat-ripple-unbounded]":"unbounded"}}]}],()=>[],{color:[{type:i.Input,args:["matRippleColor"]}],unbounded:[{type:i.Input,args:["matRippleUnbounded"]}],centered:[{type:i.Input,args:["matRippleCentered"]}],radius:[{type:i.Input,args:["matRippleRadius"]}],animation:[{type:i.Input,args:["matRippleAnimation"]}],disabled:[{type:i.Input,args:["matRippleDisabled"]}],trigger:[{type:i.Input,args:["matRippleTrigger"]}]})},30184(O,h,a){a.d(h,{A:()=>i});var c=a(39638);class i{static \u0275fac=function(u){return new(u||i)};static \u0275cmp=c.\u0275\u0275defineComponent({type:i,selectors:[["structural-styles"]],decls:0,vars:0,template:function(u,b){},styles:[`.mat-focus-indicator {
  position: relative;
}
.mat-focus-indicator::before {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  box-sizing: border-box;
  pointer-events: none;
  display: var(--mat-focus-indicator-display, none);
  border-width: var(--mat-focus-indicator-border-width, 3px);
  border-style: var(--mat-focus-indicator-border-style, solid);
  border-color: var(--mat-focus-indicator-border-color, transparent);
  border-radius: var(--mat-focus-indicator-border-radius, 4px);
}
.mat-focus-indicator:focus-visible::before {
  content: "";
}

@media (forced-colors: active) {
  html {
    --mat-focus-indicator-display: block;
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&c.\u0275setClassMetadata(i,[{type:c.Component,args:[{selector:"structural-styles",encapsulation:c.ViewEncapsulation.None,template:"",changeDetection:c.ChangeDetectionStrategy.OnPush,styles:[`.mat-focus-indicator {
  position: relative;
}
.mat-focus-indicator::before {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  box-sizing: border-box;
  pointer-events: none;
  display: var(--mat-focus-indicator-display, none);
  border-width: var(--mat-focus-indicator-border-width, 3px);
  border-style: var(--mat-focus-indicator-border-style, solid);
  border-color: var(--mat-focus-indicator-border-color, transparent);
  border-radius: var(--mat-focus-indicator-border-radius, 4px);
}
.mat-focus-indicator:focus-visible::before {
  content: "";
}

@media (forced-colors: active) {
  html {
    --mat-focus-indicator-display: block;
  }
}
`]}]}],null,null)}}]);
