CKEDITOR.plugins.add('creatiofixedtoolbox', {
    init: function (editor) {
        if (getIsStopHandleCKEditorScrollEventFeatureDisabled()) {
            let isHandlingScrollEvent = false;
            const handleScroll = function (editor) {
                if (getIsNeedHandleScroll(editor) && !isHandlingScrollEvent) {
                    isHandlingScrollEvent = true;
                    window.dispatchEvent(new Event('scroll'));
                    isHandlingScrollEvent = false;
                }
            };
            const handleScrollCallback = () => handleScroll(editor);
            editor.on('focus', function () {
                setTimeout(() => window.addEventListener('scroll', handleScrollCallback, true), 0);
                // some touchpads fire 'wheel' event instead of 'scroll'
                setTimeout(() => window.addEventListener('wheel', handleScrollCallback, true), 0);
            });
            editor.on('blur', function () {
                setTimeout(() => window.removeEventListener('scroll', handleScrollCallback, true), 0);
                setTimeout(() => window.removeEventListener('wheel', handleScrollCallback, true), 0);
            });
        }
        stickPositionToContainer(editor);
    }
});

function getIsNeedHandleScroll(editor) {
    return editor
        && document.querySelector("#cke_" + editor.name + ":not([style*=\"display: none\"])");
}

function getIsStopHandleCKEditorScrollEventFeatureDisabled() {
    return Terrasoft?.Features?.getIsDisabled("StopHandleCKEditorScrollEvent");
}

function stickPositionToContainer(editor) {
    let repositionTimeout = null;
    let lastCalculatedTop = null;
    editor.on('floatingSpaceLayout', () => {
        if (repositionTimeout) {
            clearTimeout(repositionTimeout);
        }
        repositionTimeout = setTimeout(() => {
            const newTop = reposition(editor, lastCalculatedTop);
            if (newTop !== null) {
                lastCalculatedTop = newTop;
            }
        }, 100);
    });
}

function reposition(editor, lastCalculatedTop) {
    const headerElement = document.getElementById('MainHeader');
    if (!headerElement) {
        return null;
    }
    const headerRect = headerElement.getBoundingClientRect();
    const editorRect = editor?.container?.$.getBoundingClientRect();
    if (!editorRect) {
        return null;
    }
    const toolbarElement = document.querySelector('#cke_' + editor.name);
    if (!toolbarElement) {
        return null;
    }
    const TOOLBAR_OFFSET = 10;
    const EDITOR_VISIBLE_THRESHOLD = 50;
    if (editorRect.top > headerRect.bottom &&
        editorRect.top < window.innerHeight - EDITOR_VISIBLE_THRESHOLD) {
        return null;
    }
    if (editorRect.bottom < 0 || editorRect.top > window.innerHeight) {
        return null;
    }
    if (editorRect.top < headerRect.bottom) {
        const newTop = headerRect.bottom + TOOLBAR_OFFSET;
        if (lastCalculatedTop === null || Math.abs(newTop - lastCalculatedTop) > 1) {
            toolbarElement.style.top = `${newTop}px`;
        }
        return newTop;
    }
    return null;
}