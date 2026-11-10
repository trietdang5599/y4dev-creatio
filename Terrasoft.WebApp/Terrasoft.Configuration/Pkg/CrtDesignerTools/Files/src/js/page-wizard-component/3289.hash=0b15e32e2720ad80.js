(self.webpackChunkapp_studio_enterprise_page_wizard=self.webpackChunkapp_studio_enterprise_page_wizard||[]).push([[3289],{93289(U,C,r){r.r(C),r.d(C,{MAT_SNACK_BAR_DATA:()=>A,MAT_SNACK_BAR_DEFAULT_OPTIONS:()=>R,MatSnackBar:()=>l,MatSnackBarAction:()=>_,MatSnackBarActions:()=>m,MatSnackBarConfig:()=>f,MatSnackBarContainer:()=>h,MatSnackBarLabel:()=>d,MatSnackBarModule:()=>k,MatSnackBarRef:()=>x,SimpleSnackBar:()=>u});var t=r(39638),E=r(60447),S=r(15047),p=r(15893),b=r(88632),y=r(72221),O=r(52455),c=r(34883),D=r(34630),P=r(24884),w=r(90459),W=r(4295),K=r(73971);function I(v,n){if(v&1){const a=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"div",1)(1,"button",2),t.\u0275\u0275listener("click",function(){t.\u0275\u0275restoreView(a);const i=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(i.action())}),t.\u0275\u0275text(2),t.\u0275\u0275elementEnd()()}if(v&2){const a=t.\u0275\u0275nextContext();t.\u0275\u0275advance(2),t.\u0275\u0275textInterpolate1(" ",a.data.action," ")}}const j=["label"];function L(v,n){}const F=Math.pow(2,31)-1;class x{_overlayRef;instance;containerInstance;_afterDismissed=new b.Subject;_afterOpened=new b.Subject;_onAction=new b.Subject;_durationTimeoutId;_dismissedByAction=!1;constructor(n,a){this._overlayRef=a,this.containerInstance=n,n._onExit.subscribe(()=>this._finishDismiss())}dismiss(){this._afterDismissed.closed||this.containerInstance.exit(),clearTimeout(this._durationTimeoutId)}dismissWithAction(){this._onAction.closed||(this._dismissedByAction=!0,this._onAction.next(),this._onAction.complete(),this.dismiss()),clearTimeout(this._durationTimeoutId)}closeWithAction(){this.dismissWithAction()}_dismissAfter(n){this._durationTimeoutId=setTimeout(()=>this.dismiss(),Math.min(n,F))}_open(){this._afterOpened.closed||(this._afterOpened.next(),this._afterOpened.complete())}_finishDismiss(){this._overlayRef.dispose(),this._onAction.closed||this._onAction.complete(),this._afterDismissed.next({dismissedByAction:this._dismissedByAction}),this._afterDismissed.complete(),this._dismissedByAction=!1}afterDismissed(){return this._afterDismissed}afterOpened(){return this.containerInstance._onEnter}onAction(){return this._onAction}}const A=new t.InjectionToken("MatSnackBarData");class f{politeness="polite";announcementMessage="";viewContainerRef;duration=0;panelClass;direction;data=null;horizontalPosition="center";verticalPosition="bottom"}class d{static \u0275fac=function(a){return new(a||d)};static \u0275dir=t.\u0275\u0275defineDirective({type:d,selectors:[["","matSnackBarLabel",""]],hostAttrs:[1,"mat-mdc-snack-bar-label","mdc-snackbar__label"]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(d,[{type:t.Directive,args:[{selector:"[matSnackBarLabel]",host:{class:"mat-mdc-snack-bar-label mdc-snackbar__label"}}]}],null,null);class m{static \u0275fac=function(a){return new(a||m)};static \u0275dir=t.\u0275\u0275defineDirective({type:m,selectors:[["","matSnackBarActions",""]],hostAttrs:[1,"mat-mdc-snack-bar-actions","mdc-snackbar__actions"]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(m,[{type:t.Directive,args:[{selector:"[matSnackBarActions]",host:{class:"mat-mdc-snack-bar-actions mdc-snackbar__actions"}}]}],null,null);class _{static \u0275fac=function(a){return new(a||_)};static \u0275dir=t.\u0275\u0275defineDirective({type:_,selectors:[["","matSnackBarAction",""]],hostAttrs:[1,"mat-mdc-snack-bar-action","mdc-snackbar__action"]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(_,[{type:t.Directive,args:[{selector:"[matSnackBarAction]",host:{class:"mat-mdc-snack-bar-action mdc-snackbar__action"}}]}],null,null);class u{snackBarRef=(0,t.inject)(x);data=(0,t.inject)(A);constructor(){}action(){this.snackBarRef.dismissWithAction()}get hasAction(){return!!this.data.action}static \u0275fac=function(a){return new(a||u)};static \u0275cmp=t.\u0275\u0275defineComponent({type:u,selectors:[["simple-snack-bar"]],hostAttrs:[1,"mat-mdc-simple-snack-bar"],exportAs:["matSnackBar"],decls:3,vars:2,consts:[["matSnackBarLabel",""],["matSnackBarActions",""],["matButton","","matSnackBarAction","",3,"click"]],template:function(a,e){a&1&&(t.\u0275\u0275elementStart(0,"div",0),t.\u0275\u0275text(1),t.\u0275\u0275elementEnd(),t.\u0275\u0275conditionalCreate(2,I,3,1,"div",1)),a&2&&(t.\u0275\u0275advance(),t.\u0275\u0275textInterpolate1(" ",e.data.message,`
`),t.\u0275\u0275advance(),t.\u0275\u0275conditional(e.hasAction?2:-1))},dependencies:[y.MatButton,d,m,_],styles:[`.mat-mdc-simple-snack-bar {
  display: flex;
}
.mat-mdc-simple-snack-bar .mat-mdc-snack-bar-label {
  max-height: 50vh;
  overflow: auto;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(u,[{type:t.Component,args:[{selector:"simple-snack-bar",exportAs:"matSnackBar",encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.OnPush,imports:[y.MatButton,d,m,_],host:{class:"mat-mdc-simple-snack-bar"},template:`<div matSnackBarLabel>
  {{data.message}}
</div>

@if (hasAction) {
  <div matSnackBarActions>
    <button matButton matSnackBarAction (click)="action()">
      {{data.action}}
    </button>
  </div>
}
`,styles:[`.mat-mdc-simple-snack-bar {
  display: flex;
}
.mat-mdc-simple-snack-bar .mat-mdc-snack-bar-label {
  max-height: 50vh;
  overflow: auto;
}
`]}]}],()=>[],null);const M="_mat-snack-bar-enter",B="_mat-snack-bar-exit";class h extends c.BasePortalOutlet{_ngZone=(0,t.inject)(t.NgZone);_elementRef=(0,t.inject)(t.ElementRef);_changeDetectorRef=(0,t.inject)(t.ChangeDetectorRef);_platform=(0,t.inject)(O.Platform);_animationsDisabled=(0,D.Rc)();snackBarConfig=(0,t.inject)(f);_document=(0,t.inject)(t.DOCUMENT);_trackedModals=new Set;_enterFallback;_exitFallback;_injector=(0,t.inject)(t.Injector);_announceDelay=150;_announceTimeoutId;_destroyed=!1;_portalOutlet;_onAnnounce=new b.Subject;_onExit=new b.Subject;_onEnter=new b.Subject;_animationState="void";_live;_label;_role;_liveElementId=(0,t.inject)(E._IdGenerator).getId("mat-snack-bar-container-live-");constructor(){super();const n=this.snackBarConfig;n.politeness==="assertive"&&!n.announcementMessage?this._live="assertive":n.politeness==="off"?this._live="off":this._live="polite",this._platform.FIREFOX&&(this._live==="polite"&&(this._role="status"),this._live==="assertive"&&(this._role="alert"))}attachComponentPortal(n){this._assertNotAttached();const a=this._portalOutlet.attachComponentPortal(n);return this._afterPortalAttached(),a}attachTemplatePortal(n){this._assertNotAttached();const a=this._portalOutlet.attachTemplatePortal(n);return this._afterPortalAttached(),a}attachDomPortal=n=>{this._assertNotAttached();const a=this._portalOutlet.attachDomPortal(n);return this._afterPortalAttached(),a};onAnimationEnd(n){n===B?this._completeExit():n===M&&(clearTimeout(this._enterFallback),this._ngZone.run(()=>{this._onEnter.next(),this._onEnter.complete()}))}enter(){this._destroyed||(this._animationState="visible",this._changeDetectorRef.markForCheck(),this._changeDetectorRef.detectChanges(),this._screenReaderAnnounce(),this._animationsDisabled?(0,t.afterNextRender)(()=>{this._ngZone.run(()=>queueMicrotask(()=>this.onAnimationEnd(M)))},{injector:this._injector}):(clearTimeout(this._enterFallback),this._enterFallback=setTimeout(()=>{this._elementRef.nativeElement.classList.add("mat-snack-bar-fallback-visible"),this.onAnimationEnd(M)},200)))}exit(){return this._destroyed?(0,b.of)(void 0):(this._ngZone.run(()=>{this._animationState="hidden",this._changeDetectorRef.markForCheck(),this._elementRef.nativeElement.setAttribute("mat-exit",""),clearTimeout(this._announceTimeoutId),this._animationsDisabled?(0,t.afterNextRender)(()=>{this._ngZone.run(()=>queueMicrotask(()=>this.onAnimationEnd(B)))},{injector:this._injector}):(clearTimeout(this._exitFallback),this._exitFallback=setTimeout(()=>this.onAnimationEnd(B),200))}),this._onExit)}ngOnDestroy(){this._destroyed=!0,this._clearFromModals(),this._completeExit()}_completeExit(){clearTimeout(this._exitFallback),queueMicrotask(()=>{this._onExit.next(),this._onExit.complete()})}_afterPortalAttached(){const n=this._elementRef.nativeElement,a=this.snackBarConfig.panelClass;a&&(Array.isArray(a)?a.forEach(s=>n.classList.add(s)):n.classList.add(a)),this._exposeToModals();const e=this._label.nativeElement,i="mdc-snackbar__label";e.classList.toggle(i,!e.querySelector(`.${i}`))}_exposeToModals(){const n=this._liveElementId,a=this._document.querySelectorAll('body > .cdk-overlay-container [aria-modal="true"]');for(let e=0;e<a.length;e++){const i=a[e],s=i.getAttribute("aria-owns");this._trackedModals.add(i),s?s.indexOf(n)===-1&&i.setAttribute("aria-owns",s+" "+n):i.setAttribute("aria-owns",n)}}_clearFromModals(){this._trackedModals.forEach(n=>{const a=n.getAttribute("aria-owns");if(a){const e=a.replace(this._liveElementId,"").trim();e.length>0?n.setAttribute("aria-owns",e):n.removeAttribute("aria-owns")}}),this._trackedModals.clear()}_assertNotAttached(){if(this._portalOutlet.hasAttached()&&(typeof ngDevMode>"u"||ngDevMode))throw Error("Attempting to attach snack bar content after content is already attached")}_screenReaderAnnounce(){this._announceTimeoutId||this._ngZone.runOutsideAngular(()=>{this._announceTimeoutId=setTimeout(()=>{if(this._destroyed)return;const n=this._elementRef.nativeElement,a=n.querySelector("[aria-hidden]"),e=n.querySelector("[aria-live]");if(a&&e){let i=null;this._platform.isBrowser&&document.activeElement instanceof HTMLElement&&a.contains(document.activeElement)&&(i=document.activeElement),a.removeAttribute("aria-hidden"),e.appendChild(a),i?.focus(),this._onAnnounce.next(),this._onAnnounce.complete()}},this._announceDelay)})}static \u0275fac=function(a){return new(a||h)};static \u0275cmp=t.\u0275\u0275defineComponent({type:h,selectors:[["mat-snack-bar-container"]],viewQuery:function(a,e){if(a&1&&t.\u0275\u0275viewQuery(c.CdkPortalOutlet,7)(j,7),a&2){let i;t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(e._portalOutlet=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(e._label=i.first)}},hostAttrs:[1,"mdc-snackbar","mat-mdc-snack-bar-container"],hostVars:6,hostBindings:function(a,e){a&1&&t.\u0275\u0275listener("animationend",function(s){return e.onAnimationEnd(s.animationName)})("animationcancel",function(s){return e.onAnimationEnd(s.animationName)}),a&2&&t.\u0275\u0275classProp("mat-snack-bar-container-enter",e._animationState==="visible")("mat-snack-bar-container-exit",e._animationState==="hidden")("mat-snack-bar-container-animations-enabled",!e._animationsDisabled)},features:[t.\u0275\u0275InheritDefinitionFeature],decls:6,vars:3,consts:[["label",""],[1,"mdc-snackbar__surface","mat-mdc-snackbar-surface"],[1,"mat-mdc-snack-bar-label"],["aria-hidden","true"],["cdkPortalOutlet",""]],template:function(a,e){a&1&&(t.\u0275\u0275elementStart(0,"div",1)(1,"div",2,0)(3,"div",3),t.\u0275\u0275template(4,L,0,0,"ng-template",4),t.\u0275\u0275elementEnd(),t.\u0275\u0275element(5,"div"),t.\u0275\u0275elementEnd()()),a&2&&(t.\u0275\u0275advance(5),t.\u0275\u0275attribute("aria-live",e._live)("role",e._role)("id",e._liveElementId))},dependencies:[c.CdkPortalOutlet],styles:[`@keyframes _mat-snack-bar-enter {
  from {
    transform: scale(0.8);
    opacity: 0;
  }
  to {
    transform: scale(1);
    opacity: 1;
  }
}
@keyframes _mat-snack-bar-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-mdc-snack-bar-container {
  display: flex;
  align-items: center;
  justify-content: center;
  box-sizing: border-box;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
  margin: 8px;
}
.mat-mdc-snack-bar-handset .mat-mdc-snack-bar-container {
  width: 100vw;
}

.mat-snack-bar-container-animations-enabled {
  opacity: 0;
}
.mat-snack-bar-container-animations-enabled.mat-snack-bar-fallback-visible {
  opacity: 1;
}
.mat-snack-bar-container-animations-enabled.mat-snack-bar-container-enter {
  animation: _mat-snack-bar-enter 150ms cubic-bezier(0, 0, 0.2, 1) forwards;
}
.mat-snack-bar-container-animations-enabled.mat-snack-bar-container-exit {
  animation: _mat-snack-bar-exit 75ms cubic-bezier(0.4, 0, 1, 1) forwards;
}

.mat-mdc-snackbar-surface {
  box-shadow: 0px 3px 5px -1px rgba(0, 0, 0, 0.2), 0px 6px 10px 0px rgba(0, 0, 0, 0.14), 0px 1px 18px 0px rgba(0, 0, 0, 0.12);
  display: flex;
  align-items: center;
  justify-content: flex-start;
  box-sizing: border-box;
  padding-left: 0;
  padding-right: 8px;
}
[dir=rtl] .mat-mdc-snackbar-surface {
  padding-right: 0;
  padding-left: 8px;
}
.mat-mdc-snack-bar-container .mat-mdc-snackbar-surface {
  min-width: 344px;
  max-width: 672px;
}
.mat-mdc-snack-bar-handset .mat-mdc-snackbar-surface {
  width: 100%;
  min-width: 0;
}
@media (forced-colors: active) {
  .mat-mdc-snackbar-surface {
    outline: solid 1px;
  }
}
.mat-mdc-snack-bar-container .mat-mdc-snackbar-surface {
  color: var(--mat-snack-bar-supporting-text-color, var(--mat-sys-inverse-on-surface));
  border-radius: var(--mat-snack-bar-container-shape, var(--mat-sys-corner-extra-small));
  background-color: var(--mat-snack-bar-container-color, var(--mat-sys-inverse-surface));
}

.mdc-snackbar__label {
  width: 100%;
  flex-grow: 1;
  box-sizing: border-box;
  margin: 0;
  padding: 14px 8px 14px 16px;
}
[dir=rtl] .mdc-snackbar__label {
  padding-left: 8px;
  padding-right: 16px;
}
.mat-mdc-snack-bar-container .mdc-snackbar__label {
  font-family: var(--mat-snack-bar-supporting-text-font, var(--mat-sys-body-medium-font));
  font-size: var(--mat-snack-bar-supporting-text-size, var(--mat-sys-body-medium-size));
  font-weight: var(--mat-snack-bar-supporting-text-weight, var(--mat-sys-body-medium-weight));
  line-height: var(--mat-snack-bar-supporting-text-line-height, var(--mat-sys-body-medium-line-height));
}

.mat-mdc-snack-bar-actions {
  display: flex;
  flex-shrink: 0;
  align-items: center;
  box-sizing: border-box;
}

.mat-mdc-snack-bar-handset,
.mat-mdc-snack-bar-container,
.mat-mdc-snack-bar-label {
  flex: 1 1 auto;
}

.mat-mdc-snack-bar-container .mat-mdc-button.mat-mdc-snack-bar-action:not(:disabled).mat-unthemed {
  color: var(--mat-snack-bar-button-color, var(--mat-sys-inverse-primary));
}
.mat-mdc-snack-bar-container .mat-mdc-button.mat-mdc-snack-bar-action:not(:disabled) {
  --mat-button-text-state-layer-color: currentColor;
  --mat-button-text-ripple-color: currentColor;
}
.mat-mdc-snack-bar-container .mat-mdc-button.mat-mdc-snack-bar-action:not(:disabled) .mat-ripple-element {
  opacity: 0.1;
}
`],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(h,[{type:t.Component,args:[{selector:"mat-snack-bar-container",changeDetection:t.ChangeDetectionStrategy.Default,encapsulation:t.ViewEncapsulation.None,imports:[c.CdkPortalOutlet],host:{class:"mdc-snackbar mat-mdc-snack-bar-container","[class.mat-snack-bar-container-enter]":'_animationState === "visible"',"[class.mat-snack-bar-container-exit]":'_animationState === "hidden"',"[class.mat-snack-bar-container-animations-enabled]":"!_animationsDisabled","(animationend)":"onAnimationEnd($event.animationName)","(animationcancel)":"onAnimationEnd($event.animationName)"},template:`<div class="mdc-snackbar__surface mat-mdc-snackbar-surface">
  <!--
    This outer label wrapper will have the class \`mdc-snackbar__label\` applied if
    the attached template/component does not contain it.
  -->
  <div class="mat-mdc-snack-bar-label" #label>
    <!-- Initialy holds the snack bar content, will be empty after announcing to screen readers. -->
    <div aria-hidden="true">
      <ng-template cdkPortalOutlet />
    </div>

    <!-- Will receive the snack bar content from the non-live div, move will happen a short delay after opening -->
    <div [attr.aria-live]="_live" [attr.role]="_role" [attr.id]="_liveElementId"></div>
  </div>
</div>
`,styles:[`@keyframes _mat-snack-bar-enter {
  from {
    transform: scale(0.8);
    opacity: 0;
  }
  to {
    transform: scale(1);
    opacity: 1;
  }
}
@keyframes _mat-snack-bar-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-mdc-snack-bar-container {
  display: flex;
  align-items: center;
  justify-content: center;
  box-sizing: border-box;
  -webkit-tap-highlight-color: rgba(0, 0, 0, 0);
  margin: 8px;
}
.mat-mdc-snack-bar-handset .mat-mdc-snack-bar-container {
  width: 100vw;
}

.mat-snack-bar-container-animations-enabled {
  opacity: 0;
}
.mat-snack-bar-container-animations-enabled.mat-snack-bar-fallback-visible {
  opacity: 1;
}
.mat-snack-bar-container-animations-enabled.mat-snack-bar-container-enter {
  animation: _mat-snack-bar-enter 150ms cubic-bezier(0, 0, 0.2, 1) forwards;
}
.mat-snack-bar-container-animations-enabled.mat-snack-bar-container-exit {
  animation: _mat-snack-bar-exit 75ms cubic-bezier(0.4, 0, 1, 1) forwards;
}

.mat-mdc-snackbar-surface {
  box-shadow: 0px 3px 5px -1px rgba(0, 0, 0, 0.2), 0px 6px 10px 0px rgba(0, 0, 0, 0.14), 0px 1px 18px 0px rgba(0, 0, 0, 0.12);
  display: flex;
  align-items: center;
  justify-content: flex-start;
  box-sizing: border-box;
  padding-left: 0;
  padding-right: 8px;
}
[dir=rtl] .mat-mdc-snackbar-surface {
  padding-right: 0;
  padding-left: 8px;
}
.mat-mdc-snack-bar-container .mat-mdc-snackbar-surface {
  min-width: 344px;
  max-width: 672px;
}
.mat-mdc-snack-bar-handset .mat-mdc-snackbar-surface {
  width: 100%;
  min-width: 0;
}
@media (forced-colors: active) {
  .mat-mdc-snackbar-surface {
    outline: solid 1px;
  }
}
.mat-mdc-snack-bar-container .mat-mdc-snackbar-surface {
  color: var(--mat-snack-bar-supporting-text-color, var(--mat-sys-inverse-on-surface));
  border-radius: var(--mat-snack-bar-container-shape, var(--mat-sys-corner-extra-small));
  background-color: var(--mat-snack-bar-container-color, var(--mat-sys-inverse-surface));
}

.mdc-snackbar__label {
  width: 100%;
  flex-grow: 1;
  box-sizing: border-box;
  margin: 0;
  padding: 14px 8px 14px 16px;
}
[dir=rtl] .mdc-snackbar__label {
  padding-left: 8px;
  padding-right: 16px;
}
.mat-mdc-snack-bar-container .mdc-snackbar__label {
  font-family: var(--mat-snack-bar-supporting-text-font, var(--mat-sys-body-medium-font));
  font-size: var(--mat-snack-bar-supporting-text-size, var(--mat-sys-body-medium-size));
  font-weight: var(--mat-snack-bar-supporting-text-weight, var(--mat-sys-body-medium-weight));
  line-height: var(--mat-snack-bar-supporting-text-line-height, var(--mat-sys-body-medium-line-height));
}

.mat-mdc-snack-bar-actions {
  display: flex;
  flex-shrink: 0;
  align-items: center;
  box-sizing: border-box;
}

.mat-mdc-snack-bar-handset,
.mat-mdc-snack-bar-container,
.mat-mdc-snack-bar-label {
  flex: 1 1 auto;
}

.mat-mdc-snack-bar-container .mat-mdc-button.mat-mdc-snack-bar-action:not(:disabled).mat-unthemed {
  color: var(--mat-snack-bar-button-color, var(--mat-sys-inverse-primary));
}
.mat-mdc-snack-bar-container .mat-mdc-button.mat-mdc-snack-bar-action:not(:disabled) {
  --mat-button-text-state-layer-color: currentColor;
  --mat-button-text-ripple-color: currentColor;
}
.mat-mdc-snack-bar-container .mat-mdc-button.mat-mdc-snack-bar-action:not(:disabled) .mat-ripple-element {
  opacity: 0.1;
}
`]}]}],()=>[],{_portalOutlet:[{type:t.ViewChild,args:[c.CdkPortalOutlet,{static:!0}]}],_label:[{type:t.ViewChild,args:["label",{static:!0}]}]});const R=new t.InjectionToken("mat-snack-bar-default-options",{providedIn:"root",factory:()=>new f});class l{_live=(0,t.inject)(E.LiveAnnouncer);_injector=(0,t.inject)(t.Injector);_breakpointObserver=(0,t.inject)(S.BreakpointObserver);_parentSnackBar=(0,t.inject)(l,{optional:!0,skipSelf:!0});_defaultConfig=(0,t.inject)(R);_animationsDisabled=(0,D.Rc)();_snackBarRefAtThisLevel=null;simpleSnackBarComponent=u;snackBarContainerComponent=h;handsetCssClass="mat-mdc-snack-bar-handset";get _openedSnackBarRef(){const n=this._parentSnackBar;return n?n._openedSnackBarRef:this._snackBarRefAtThisLevel}set _openedSnackBarRef(n){this._parentSnackBar?this._parentSnackBar._openedSnackBarRef=n:this._snackBarRefAtThisLevel=n}constructor(){}openFromComponent(n,a){return this._attach(n,a)}openFromTemplate(n,a){return this._attach(n,a)}open(n,a="",e){const i={...this._defaultConfig,...e};return i.data={message:n,action:a},i.announcementMessage===n&&(i.announcementMessage=void 0),this.openFromComponent(this.simpleSnackBarComponent,i)}dismiss(){this._openedSnackBarRef&&this._openedSnackBarRef.dismiss()}ngOnDestroy(){this._snackBarRefAtThisLevel&&this._snackBarRefAtThisLevel.dismiss()}_attachSnackBarContainer(n,a){const e=a&&a.viewContainerRef&&a.viewContainerRef.injector,i=t.Injector.create({parent:e||this._injector,providers:[{provide:f,useValue:a}]}),s=new c.ComponentPortal(this.snackBarContainerComponent,a.viewContainerRef,i),o=n.attach(s);return o.instance.snackBarConfig=a,o.instance}_attach(n,a){const e={...new f,...this._defaultConfig,...a},i=this._createOverlay(e),s=this._attachSnackBarContainer(i,e),o=new x(s,i);if(n instanceof t.TemplateRef){const g=new c.TemplatePortal(n,null,{$implicit:e.data,snackBarRef:o});o.instance=s.attachTemplatePortal(g)}else{const g=this._createInjector(e,o),z=new c.ComponentPortal(n,void 0,g),N=s.attachComponentPortal(z);o.instance=N.instance}return this._breakpointObserver.observe(S.Breakpoints.HandsetPortrait).pipe((0,P.takeUntil)(i.detachments())).subscribe(g=>{i.overlayElement.classList.toggle(this.handsetCssClass,g.matches)}),e.announcementMessage&&s._onAnnounce.subscribe(()=>{this._live.announce(e.announcementMessage,e.politeness)}),this._animateSnackBar(o,e),this._openedSnackBarRef=o,this._openedSnackBarRef}_animateSnackBar(n,a){n.afterDismissed().subscribe(()=>{this._openedSnackBarRef==n&&(this._openedSnackBarRef=null),a.announcementMessage&&this._live.clear()}),a.duration&&a.duration>0&&n.afterOpened().subscribe(()=>n._dismissAfter(a.duration)),this._openedSnackBarRef?(this._openedSnackBarRef.afterDismissed().subscribe(()=>{n.containerInstance.enter()}),this._openedSnackBarRef.dismiss()):n.containerInstance.enter()}_createOverlay(n){const a=new p.OverlayConfig;a.direction=n.direction;const e=(0,p.createGlobalPositionStrategy)(this._injector),i=n.direction==="rtl",s=n.horizontalPosition==="left"||n.horizontalPosition==="start"&&!i||n.horizontalPosition==="end"&&i,o=!s&&n.horizontalPosition!=="center";return s?e.left("0"):o?e.right("0"):e.centerHorizontally(),n.verticalPosition==="top"?e.top("0"):e.bottom("0"),a.positionStrategy=e,a.disableAnimations=this._animationsDisabled,(0,p.createOverlayRef)(this._injector,a)}_createInjector(n,a){const e=n&&n.viewContainerRef&&n.viewContainerRef.injector;return t.Injector.create({parent:e||this._injector,providers:[{provide:x,useValue:a},{provide:A,useValue:n.data}]})}static \u0275fac=function(a){return new(a||l)};static \u0275prov=t.\u0275\u0275defineInjectable({token:l,factory:l.\u0275fac,providedIn:"root"})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(l,[{type:t.Injectable,args:[{providedIn:"root"}]}],()=>[],null);const T=[h,d,m,_];class k{static \u0275fac=function(a){return new(a||k)};static \u0275mod=t.\u0275\u0275defineNgModule({type:k});static \u0275inj=t.\u0275\u0275defineInjector({providers:[l],imports:[p.OverlayModule,c.PortalModule,y.MatButtonModule,u,w.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(k,[{type:t.NgModule,args:[{imports:[p.OverlayModule,c.PortalModule,y.MatButtonModule,u,...T],exports:[w.BidiModule,...T],providers:[l]}]}],null,null)}}]);
