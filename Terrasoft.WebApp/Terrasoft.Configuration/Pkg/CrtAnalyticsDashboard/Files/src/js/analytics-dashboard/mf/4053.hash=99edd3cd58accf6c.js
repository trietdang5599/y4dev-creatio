(self.webpackChunkapp_studio_enterprise_analytics_dashboard=self.webpackChunkapp_studio_enterprise_analytics_dashboard||[]).push([[4053],{34630(G,C,o){o.d(C,{Rc:()=>A,Sx:()=>r,_J:()=>m});var u=o(15047),t=o(39638);const r=new t.InjectionToken("MATERIAL_ANIMATIONS");let D=null;function m(){return(0,t.inject)(r,{optional:!0})?.animationsDisabled||(0,t.inject)(t.ANIMATION_MODULE_TYPE,{optional:!0})==="NoopAnimations"?"di-disabled":(D??=(0,t.inject)(u.MediaMatcher).matchMedia("(prefers-reduced-motion)").matches,D?"reduced-motion":"enabled")}function A(){return m()!=="enabled"}},44053(G,C,o){o.r(C),o.d(C,{MAT_DIALOG_DATA:()=>B,MAT_DIALOG_DEFAULT_OPTIONS:()=>F,MAT_DIALOG_SCROLL_STRATEGY:()=>N,MatDialog:()=>s,MatDialogActions:()=>h,MatDialogClose:()=>f,MatDialogConfig:()=>T,MatDialogContainer:()=>c,MatDialogContent:()=>y,MatDialogModule:()=>x,MatDialogRef:()=>O,MatDialogState:()=>_,MatDialogTitle:()=>g,_closeDialogVia:()=>E});var u=o(15893),t=o(39638),r=o(5275),D=o(73971),m=o(34883),A=o(34630),p=o(88632),d=o(24884),I=o(88783),w=o(60447),k=o(33807),R=o(90459),$=o(15047);function K(e,n){}class T{viewContainerRef;injector;id;role="dialog";panelClass="";hasBackdrop=!0;backdropClass="";disableClose=!1;closePredicate;width="";height="";minWidth;minHeight;maxWidth;maxHeight;position;data=null;direction;ariaDescribedBy=null;ariaLabelledBy=null;ariaLabel=null;ariaModal=!1;autoFocus="first-tabbable";restoreFocus=!0;delayFocusTrap=!0;scrollStrategy;closeOnNavigation=!0;enterAnimationDuration;exitAnimationDuration}const M="mdc-dialog--open",P="mdc-dialog--opening",L="mdc-dialog--closing",V=150,H=75;class c extends r.CdkDialogContainer{_animationStateChanged=new t.EventEmitter;_animationsEnabled=!(0,A.Rc)();_actionSectionCount=0;_hostElement=this._elementRef.nativeElement;_enterAnimationDuration=this._animationsEnabled?j(this._config.enterAnimationDuration)??V:0;_exitAnimationDuration=this._animationsEnabled?j(this._config.exitAnimationDuration)??H:0;_animationTimer=null;_contentAttached(){super._contentAttached(),this._startOpenAnimation()}_startOpenAnimation(){this._animationStateChanged.emit({state:"opening",totalTime:this._enterAnimationDuration}),this._animationsEnabled?(this._hostElement.style.setProperty(S,`${this._enterAnimationDuration}ms`),this._requestAnimationFrame(()=>this._hostElement.classList.add(P,M)),this._waitForAnimationToComplete(this._enterAnimationDuration,this._finishDialogOpen)):(this._hostElement.classList.add(M),Promise.resolve().then(()=>this._finishDialogOpen()))}_startExitAnimation(){this._animationStateChanged.emit({state:"closing",totalTime:this._exitAnimationDuration}),this._hostElement.classList.remove(M),this._animationsEnabled?(this._hostElement.style.setProperty(S,`${this._exitAnimationDuration}ms`),this._requestAnimationFrame(()=>this._hostElement.classList.add(L)),this._waitForAnimationToComplete(this._exitAnimationDuration,this._finishDialogClose)):Promise.resolve().then(()=>this._finishDialogClose())}_updateActionSectionCount(n){this._actionSectionCount+=n,this._changeDetectorRef.markForCheck()}_finishDialogOpen=()=>{this._clearAnimationClasses(),this._openAnimationDone(this._enterAnimationDuration)};_finishDialogClose=()=>{this._clearAnimationClasses(),this._animationStateChanged.emit({state:"closed",totalTime:this._exitAnimationDuration})};_clearAnimationClasses(){this._hostElement.classList.remove(P,L)}_waitForAnimationToComplete(n,a){this._animationTimer!==null&&clearTimeout(this._animationTimer),this._animationTimer=setTimeout(a,n)}_requestAnimationFrame(n){this._ngZone.runOutsideAngular(()=>{typeof requestAnimationFrame=="function"?requestAnimationFrame(n):n()})}_captureInitialFocus(){this._config.delayFocusTrap||this._trapFocus()}_openAnimationDone(n){this._config.delayFocusTrap&&this._trapFocus(),this._animationStateChanged.next({state:"opened",totalTime:n})}ngOnDestroy(){super.ngOnDestroy(),this._animationTimer!==null&&clearTimeout(this._animationTimer)}attachComponentPortal(n){const a=super.attachComponentPortal(n);return a.location.nativeElement.classList.add("mat-mdc-dialog-component-host"),a}static \u0275fac=(()=>{let n;return function(i){return(n||(n=t.\u0275\u0275getInheritedFactory(c)))(i||c)}})();static \u0275cmp=t.\u0275\u0275defineComponent({type:c,selectors:[["mat-dialog-container"]],hostAttrs:["tabindex","-1",1,"mat-mdc-dialog-container","mdc-dialog"],hostVars:10,hostBindings:function(a,i){a&2&&(t.\u0275\u0275domProperty("id",i._config.id),t.\u0275\u0275attribute("aria-modal",i._config.ariaModal)("role",i._config.role)("aria-labelledby",i._config.ariaLabel?null:i._ariaLabelledByQueue[0])("aria-label",i._config.ariaLabel)("aria-describedby",i._config.ariaDescribedBy||null),t.\u0275\u0275classProp("_mat-animation-noopable",!i._animationsEnabled)("mat-mdc-dialog-container-with-actions",i._actionSectionCount>0))},features:[t.\u0275\u0275InheritDefinitionFeature],decls:3,vars:0,consts:[[1,"mat-mdc-dialog-inner-container","mdc-dialog__container"],[1,"mat-mdc-dialog-surface","mdc-dialog__surface"],["cdkPortalOutlet",""]],template:function(a,i){a&1&&(t.\u0275\u0275elementStart(0,"div",0)(1,"div",1),t.\u0275\u0275template(2,K,0,0,"ng-template",2),t.\u0275\u0275elementEnd()())},dependencies:[m.CdkPortalOutlet],styles:[`.mat-mdc-dialog-container {
  width: 100%;
  height: 100%;
  display: block;
  box-sizing: border-box;
  max-height: inherit;
  min-height: inherit;
  min-width: inherit;
  max-width: inherit;
  outline: 0;
}

.cdk-overlay-pane.mat-mdc-dialog-panel {
  max-width: var(--mat-dialog-container-max-width, 560px);
  min-width: var(--mat-dialog-container-min-width, 280px);
}
@media (max-width: 599px) {
  .cdk-overlay-pane.mat-mdc-dialog-panel {
    max-width: var(--mat-dialog-container-small-max-width, calc(100vw - 32px));
  }
}

.mat-mdc-dialog-inner-container {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-around;
  box-sizing: border-box;
  height: 100%;
  opacity: 0;
  transition: opacity linear var(--mat-dialog-transition-duration, 0ms);
  max-height: inherit;
  min-height: inherit;
  min-width: inherit;
  max-width: inherit;
}
.mdc-dialog--closing .mat-mdc-dialog-inner-container {
  transition: opacity 75ms linear;
  transform: none;
}
.mdc-dialog--open .mat-mdc-dialog-inner-container {
  opacity: 1;
}
._mat-animation-noopable .mat-mdc-dialog-inner-container {
  transition: none;
}

.mat-mdc-dialog-surface {
  display: flex;
  flex-direction: column;
  flex-grow: 0;
  flex-shrink: 0;
  box-sizing: border-box;
  width: 100%;
  height: 100%;
  position: relative;
  overflow-y: auto;
  outline: 0;
  transform: scale(0.8);
  transition: transform var(--mat-dialog-transition-duration, 0ms) cubic-bezier(0, 0, 0.2, 1);
  max-height: inherit;
  min-height: inherit;
  min-width: inherit;
  max-width: inherit;
  box-shadow: var(--mat-dialog-container-elevation-shadow, none);
  border-radius: var(--mat-dialog-container-shape, var(--mat-sys-corner-extra-large, 4px));
  background-color: var(--mat-dialog-container-color, var(--mat-sys-surface, white));
}
[dir=rtl] .mat-mdc-dialog-surface {
  text-align: right;
}
.mdc-dialog--open .mat-mdc-dialog-surface, .mdc-dialog--closing .mat-mdc-dialog-surface {
  transform: none;
}
._mat-animation-noopable .mat-mdc-dialog-surface {
  transition: none;
}
.mat-mdc-dialog-surface::before {
  position: absolute;
  box-sizing: border-box;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  border: 2px solid transparent;
  border-radius: inherit;
  content: "";
  pointer-events: none;
}

.mat-mdc-dialog-title {
  display: block;
  position: relative;
  flex-shrink: 0;
  box-sizing: border-box;
  margin: 0 0 1px;
  padding: var(--mat-dialog-headline-padding, 6px 24px 13px);
}
.mat-mdc-dialog-title::before {
  display: inline-block;
  width: 0;
  height: 40px;
  content: "";
  vertical-align: 0;
}
[dir=rtl] .mat-mdc-dialog-title {
  text-align: right;
}
.mat-mdc-dialog-container .mat-mdc-dialog-title {
  color: var(--mat-dialog-subhead-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
  font-family: var(--mat-dialog-subhead-font, var(--mat-sys-headline-small-font, inherit));
  line-height: var(--mat-dialog-subhead-line-height, var(--mat-sys-headline-small-line-height, 1.5rem));
  font-size: var(--mat-dialog-subhead-size, var(--mat-sys-headline-small-size, 1rem));
  font-weight: var(--mat-dialog-subhead-weight, var(--mat-sys-headline-small-weight, 400));
  letter-spacing: var(--mat-dialog-subhead-tracking, var(--mat-sys-headline-small-tracking, 0.03125em));
}

.mat-mdc-dialog-content {
  display: block;
  flex-grow: 1;
  box-sizing: border-box;
  margin: 0;
  overflow: auto;
  max-height: 65vh;
}
.mat-mdc-dialog-content > :first-child {
  margin-top: 0;
}
.mat-mdc-dialog-content > :last-child {
  margin-bottom: 0;
}
.mat-mdc-dialog-container .mat-mdc-dialog-content {
  color: var(--mat-dialog-supporting-text-color, var(--mat-sys-on-surface-variant, rgba(0, 0, 0, 0.6)));
  font-family: var(--mat-dialog-supporting-text-font, var(--mat-sys-body-medium-font, inherit));
  line-height: var(--mat-dialog-supporting-text-line-height, var(--mat-sys-body-medium-line-height, 1.5rem));
  font-size: var(--mat-dialog-supporting-text-size, var(--mat-sys-body-medium-size, 1rem));
  font-weight: var(--mat-dialog-supporting-text-weight, var(--mat-sys-body-medium-weight, 400));
  letter-spacing: var(--mat-dialog-supporting-text-tracking, var(--mat-sys-body-medium-tracking, 0.03125em));
}
.mat-mdc-dialog-container .mat-mdc-dialog-content {
  padding: var(--mat-dialog-content-padding, 20px 24px);
}
.mat-mdc-dialog-container-with-actions .mat-mdc-dialog-content {
  padding: var(--mat-dialog-with-actions-content-padding, 20px 24px 0);
}
.mat-mdc-dialog-container .mat-mdc-dialog-title + .mat-mdc-dialog-content {
  padding-top: 0;
}

.mat-mdc-dialog-actions {
  display: flex;
  position: relative;
  flex-shrink: 0;
  flex-wrap: wrap;
  align-items: center;
  box-sizing: border-box;
  min-height: 52px;
  margin: 0;
  border-top: 1px solid transparent;
  padding: var(--mat-dialog-actions-padding, 16px 24px);
  justify-content: var(--mat-dialog-actions-alignment, flex-end);
}
@media (forced-colors: active) {
  .mat-mdc-dialog-actions {
    border-top-color: CanvasText;
  }
}
.mat-mdc-dialog-actions.mat-mdc-dialog-actions-align-start, .mat-mdc-dialog-actions[align=start] {
  justify-content: start;
}
.mat-mdc-dialog-actions.mat-mdc-dialog-actions-align-center, .mat-mdc-dialog-actions[align=center] {
  justify-content: center;
}
.mat-mdc-dialog-actions.mat-mdc-dialog-actions-align-end, .mat-mdc-dialog-actions[align=end] {
  justify-content: flex-end;
}
.mat-mdc-dialog-actions .mat-button-base + .mat-button-base,
.mat-mdc-dialog-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 8px;
}
[dir=rtl] .mat-mdc-dialog-actions .mat-button-base + .mat-button-base,
[dir=rtl] .mat-mdc-dialog-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 0;
  margin-right: 8px;
}

.mat-mdc-dialog-component-host {
  display: contents;
}
`],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(c,[{type:t.Component,args:[{selector:"mat-dialog-container",encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.Default,imports:[m.CdkPortalOutlet],host:{class:"mat-mdc-dialog-container mdc-dialog",tabindex:"-1","[attr.aria-modal]":"_config.ariaModal","[id]":"_config.id","[attr.role]":"_config.role","[attr.aria-labelledby]":"_config.ariaLabel ? null : _ariaLabelledByQueue[0]","[attr.aria-label]":"_config.ariaLabel","[attr.aria-describedby]":"_config.ariaDescribedBy || null","[class._mat-animation-noopable]":"!_animationsEnabled","[class.mat-mdc-dialog-container-with-actions]":"_actionSectionCount > 0"},template:`<div class="mat-mdc-dialog-inner-container mdc-dialog__container">
  <div class="mat-mdc-dialog-surface mdc-dialog__surface">
    <ng-template cdkPortalOutlet />
  </div>
</div>
`,styles:[`.mat-mdc-dialog-container {
  width: 100%;
  height: 100%;
  display: block;
  box-sizing: border-box;
  max-height: inherit;
  min-height: inherit;
  min-width: inherit;
  max-width: inherit;
  outline: 0;
}

.cdk-overlay-pane.mat-mdc-dialog-panel {
  max-width: var(--mat-dialog-container-max-width, 560px);
  min-width: var(--mat-dialog-container-min-width, 280px);
}
@media (max-width: 599px) {
  .cdk-overlay-pane.mat-mdc-dialog-panel {
    max-width: var(--mat-dialog-container-small-max-width, calc(100vw - 32px));
  }
}

.mat-mdc-dialog-inner-container {
  display: flex;
  flex-direction: row;
  align-items: center;
  justify-content: space-around;
  box-sizing: border-box;
  height: 100%;
  opacity: 0;
  transition: opacity linear var(--mat-dialog-transition-duration, 0ms);
  max-height: inherit;
  min-height: inherit;
  min-width: inherit;
  max-width: inherit;
}
.mdc-dialog--closing .mat-mdc-dialog-inner-container {
  transition: opacity 75ms linear;
  transform: none;
}
.mdc-dialog--open .mat-mdc-dialog-inner-container {
  opacity: 1;
}
._mat-animation-noopable .mat-mdc-dialog-inner-container {
  transition: none;
}

.mat-mdc-dialog-surface {
  display: flex;
  flex-direction: column;
  flex-grow: 0;
  flex-shrink: 0;
  box-sizing: border-box;
  width: 100%;
  height: 100%;
  position: relative;
  overflow-y: auto;
  outline: 0;
  transform: scale(0.8);
  transition: transform var(--mat-dialog-transition-duration, 0ms) cubic-bezier(0, 0, 0.2, 1);
  max-height: inherit;
  min-height: inherit;
  min-width: inherit;
  max-width: inherit;
  box-shadow: var(--mat-dialog-container-elevation-shadow, none);
  border-radius: var(--mat-dialog-container-shape, var(--mat-sys-corner-extra-large, 4px));
  background-color: var(--mat-dialog-container-color, var(--mat-sys-surface, white));
}
[dir=rtl] .mat-mdc-dialog-surface {
  text-align: right;
}
.mdc-dialog--open .mat-mdc-dialog-surface, .mdc-dialog--closing .mat-mdc-dialog-surface {
  transform: none;
}
._mat-animation-noopable .mat-mdc-dialog-surface {
  transition: none;
}
.mat-mdc-dialog-surface::before {
  position: absolute;
  box-sizing: border-box;
  width: 100%;
  height: 100%;
  top: 0;
  left: 0;
  border: 2px solid transparent;
  border-radius: inherit;
  content: "";
  pointer-events: none;
}

.mat-mdc-dialog-title {
  display: block;
  position: relative;
  flex-shrink: 0;
  box-sizing: border-box;
  margin: 0 0 1px;
  padding: var(--mat-dialog-headline-padding, 6px 24px 13px);
}
.mat-mdc-dialog-title::before {
  display: inline-block;
  width: 0;
  height: 40px;
  content: "";
  vertical-align: 0;
}
[dir=rtl] .mat-mdc-dialog-title {
  text-align: right;
}
.mat-mdc-dialog-container .mat-mdc-dialog-title {
  color: var(--mat-dialog-subhead-color, var(--mat-sys-on-surface, rgba(0, 0, 0, 0.87)));
  font-family: var(--mat-dialog-subhead-font, var(--mat-sys-headline-small-font, inherit));
  line-height: var(--mat-dialog-subhead-line-height, var(--mat-sys-headline-small-line-height, 1.5rem));
  font-size: var(--mat-dialog-subhead-size, var(--mat-sys-headline-small-size, 1rem));
  font-weight: var(--mat-dialog-subhead-weight, var(--mat-sys-headline-small-weight, 400));
  letter-spacing: var(--mat-dialog-subhead-tracking, var(--mat-sys-headline-small-tracking, 0.03125em));
}

.mat-mdc-dialog-content {
  display: block;
  flex-grow: 1;
  box-sizing: border-box;
  margin: 0;
  overflow: auto;
  max-height: 65vh;
}
.mat-mdc-dialog-content > :first-child {
  margin-top: 0;
}
.mat-mdc-dialog-content > :last-child {
  margin-bottom: 0;
}
.mat-mdc-dialog-container .mat-mdc-dialog-content {
  color: var(--mat-dialog-supporting-text-color, var(--mat-sys-on-surface-variant, rgba(0, 0, 0, 0.6)));
  font-family: var(--mat-dialog-supporting-text-font, var(--mat-sys-body-medium-font, inherit));
  line-height: var(--mat-dialog-supporting-text-line-height, var(--mat-sys-body-medium-line-height, 1.5rem));
  font-size: var(--mat-dialog-supporting-text-size, var(--mat-sys-body-medium-size, 1rem));
  font-weight: var(--mat-dialog-supporting-text-weight, var(--mat-sys-body-medium-weight, 400));
  letter-spacing: var(--mat-dialog-supporting-text-tracking, var(--mat-sys-body-medium-tracking, 0.03125em));
}
.mat-mdc-dialog-container .mat-mdc-dialog-content {
  padding: var(--mat-dialog-content-padding, 20px 24px);
}
.mat-mdc-dialog-container-with-actions .mat-mdc-dialog-content {
  padding: var(--mat-dialog-with-actions-content-padding, 20px 24px 0);
}
.mat-mdc-dialog-container .mat-mdc-dialog-title + .mat-mdc-dialog-content {
  padding-top: 0;
}

.mat-mdc-dialog-actions {
  display: flex;
  position: relative;
  flex-shrink: 0;
  flex-wrap: wrap;
  align-items: center;
  box-sizing: border-box;
  min-height: 52px;
  margin: 0;
  border-top: 1px solid transparent;
  padding: var(--mat-dialog-actions-padding, 16px 24px);
  justify-content: var(--mat-dialog-actions-alignment, flex-end);
}
@media (forced-colors: active) {
  .mat-mdc-dialog-actions {
    border-top-color: CanvasText;
  }
}
.mat-mdc-dialog-actions.mat-mdc-dialog-actions-align-start, .mat-mdc-dialog-actions[align=start] {
  justify-content: start;
}
.mat-mdc-dialog-actions.mat-mdc-dialog-actions-align-center, .mat-mdc-dialog-actions[align=center] {
  justify-content: center;
}
.mat-mdc-dialog-actions.mat-mdc-dialog-actions-align-end, .mat-mdc-dialog-actions[align=end] {
  justify-content: flex-end;
}
.mat-mdc-dialog-actions .mat-button-base + .mat-button-base,
.mat-mdc-dialog-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 8px;
}
[dir=rtl] .mat-mdc-dialog-actions .mat-button-base + .mat-button-base,
[dir=rtl] .mat-mdc-dialog-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 0;
  margin-right: 8px;
}

.mat-mdc-dialog-component-host {
  display: contents;
}
`]}]}],null,null);const S="--mat-dialog-transition-duration";function j(e){return e==null?null:typeof e=="number"?e:e.endsWith("ms")?(0,D.coerceNumberProperty)(e.substring(0,e.length-2)):e.endsWith("s")?(0,D.coerceNumberProperty)(e.substring(0,e.length-1))*1e3:e==="0"?0:null}var _;(function(e){e[e.OPEN=0]="OPEN",e[e.CLOSING=1]="CLOSING",e[e.CLOSED=2]="CLOSED"})(_||(_={}));class O{_ref;_config;_containerInstance;componentInstance;componentRef=null;disableClose;id;_afterOpened=new p.ReplaySubject(1);_beforeClosed=new p.ReplaySubject(1);_result;_closeFallbackTimeout;_state=_.OPEN;_closeInteractionType;constructor(n,a,i){this._ref=n,this._config=a,this._containerInstance=i,this.disableClose=a.disableClose,this.id=n.id,n.addPanelClass("mat-mdc-dialog-panel"),i._animationStateChanged.pipe((0,d.filter)(l=>l.state==="opened"),(0,d.take)(1)).subscribe(()=>{this._afterOpened.next(),this._afterOpened.complete()}),i._animationStateChanged.pipe((0,d.filter)(l=>l.state==="closed"),(0,d.take)(1)).subscribe(()=>{clearTimeout(this._closeFallbackTimeout),this._finishDialogClose()}),n.overlayRef.detachments().subscribe(()=>{this._beforeClosed.next(this._result),this._beforeClosed.complete(),this._finishDialogClose()}),(0,p.merge)(this.backdropClick(),this.keydownEvents().pipe((0,d.filter)(l=>l.keyCode===I.ESCAPE&&!this.disableClose&&!(0,I.hasModifierKey)(l)))).subscribe(l=>{this.disableClose||(l.preventDefault(),E(this,l.type==="keydown"?"keyboard":"mouse"))})}close(n){const a=this._config.closePredicate;a&&!a(n,this._config,this.componentInstance)||(this._result=n,this._containerInstance._animationStateChanged.pipe((0,d.filter)(i=>i.state==="closing"),(0,d.take)(1)).subscribe(i=>{this._beforeClosed.next(n),this._beforeClosed.complete(),this._ref.overlayRef.detachBackdrop(),this._closeFallbackTimeout=setTimeout(()=>this._finishDialogClose(),i.totalTime+100)}),this._state=_.CLOSING,this._containerInstance._startExitAnimation())}afterOpened(){return this._afterOpened}afterClosed(){return this._ref.closed}beforeClosed(){return this._beforeClosed}backdropClick(){return this._ref.backdropClick}keydownEvents(){return this._ref.keydownEvents}updatePosition(n){let a=this._ref.config.positionStrategy;return n&&(n.left||n.right)?n.left?a.left(n.left):a.right(n.right):a.centerHorizontally(),n&&(n.top||n.bottom)?n.top?a.top(n.top):a.bottom(n.bottom):a.centerVertically(),this._ref.updatePosition(),this}updateSize(n="",a=""){return this._ref.updateSize(n,a),this}addPanelClass(n){return this._ref.addPanelClass(n),this}removePanelClass(n){return this._ref.removePanelClass(n),this}getState(){return this._state}_finishDialogClose(){this._state=_.CLOSED,this._ref.close(this._result,{focusOrigin:this._closeInteractionType}),this.componentInstance=null}}function E(e,n,a){return e._closeInteractionType=n,e.close(a)}const B=new t.InjectionToken("MatMdcDialogData"),F=new t.InjectionToken("mat-mdc-dialog-default-options"),N=new t.InjectionToken("mat-mdc-dialog-scroll-strategy",{providedIn:"root",factory:()=>{const e=(0,t.inject)(t.Injector);return()=>(0,u.createBlockScrollStrategy)(e)}});class s{_defaultOptions=(0,t.inject)(F,{optional:!0});_scrollStrategy=(0,t.inject)(N);_parentDialog=(0,t.inject)(s,{optional:!0,skipSelf:!0});_idGenerator=(0,t.inject)(w._IdGenerator);_injector=(0,t.inject)(t.Injector);_dialog=(0,t.inject)(r.Dialog);_animationsDisabled=(0,A.Rc)();_openDialogsAtThisLevel=[];_afterAllClosedAtThisLevel=new p.Subject;_afterOpenedAtThisLevel=new p.Subject;dialogConfigClass=T;_dialogRefConstructor;_dialogContainerType;_dialogDataToken;get openDialogs(){return this._parentDialog?this._parentDialog.openDialogs:this._openDialogsAtThisLevel}get afterOpened(){return this._parentDialog?this._parentDialog.afterOpened:this._afterOpenedAtThisLevel}_getAfterAllClosed(){const n=this._parentDialog;return n?n._getAfterAllClosed():this._afterAllClosedAtThisLevel}afterAllClosed=(0,p.defer)(()=>this.openDialogs.length?this._getAfterAllClosed():this._getAfterAllClosed().pipe((0,d.startWith)(void 0)));constructor(){this._dialogRefConstructor=O,this._dialogContainerType=c,this._dialogDataToken=B}open(n,a){let i;a={...this._defaultOptions||new T,...a},a.id=a.id||this._idGenerator.getId("mat-mdc-dialog-"),a.scrollStrategy=a.scrollStrategy||this._scrollStrategy();const l=this._dialog.open(n,{...a,positionStrategy:(0,u.createGlobalPositionStrategy)(this._injector).centerHorizontally().centerVertically(),disableClose:!0,closePredicate:void 0,closeOnDestroy:!1,closeOnOverlayDetachments:!1,disableAnimations:this._animationsDisabled||a.enterAnimationDuration?.toLocaleString()==="0"||a.exitAnimationDuration?.toString()==="0",container:{type:this._dialogContainerType,providers:()=>[{provide:this.dialogConfigClass,useValue:a},{provide:r.DialogConfig,useValue:a}]},templateContext:()=>({dialogRef:i}),providers:(v,Y,W)=>(i=new this._dialogRefConstructor(v,a,W),i.updatePosition(a?.position),[{provide:this._dialogContainerType,useValue:W},{provide:this._dialogDataToken,useValue:Y.data},{provide:this._dialogRefConstructor,useValue:i}])});return i.componentRef=l.componentRef,i.componentInstance=l.componentInstance,this.openDialogs.push(i),this.afterOpened.next(i),i.afterClosed().subscribe(()=>{const v=this.openDialogs.indexOf(i);v>-1&&(this.openDialogs.splice(v,1),this.openDialogs.length||this._getAfterAllClosed().next())}),i}closeAll(){this._closeDialogs(this.openDialogs)}getDialogById(n){return this.openDialogs.find(a=>a.id===n)}ngOnDestroy(){this._closeDialogs(this._openDialogsAtThisLevel),this._afterAllClosedAtThisLevel.complete(),this._afterOpenedAtThisLevel.complete()}_closeDialogs(n){let a=n.length;for(;a--;)n[a].close()}static \u0275fac=function(a){return new(a||s)};static \u0275prov=t.\u0275\u0275defineInjectable({token:s,factory:s.\u0275fac,providedIn:"root"})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(s,[{type:t.Injectable,args:[{providedIn:"root"}]}],()=>[],null);class f{dialogRef=(0,t.inject)(O,{optional:!0});_elementRef=(0,t.inject)(t.ElementRef);_dialog=(0,t.inject)(s);ariaLabel;type="button";dialogResult;_matDialogClose;constructor(){}ngOnInit(){this.dialogRef||(this.dialogRef=z(this._elementRef,this._dialog.openDialogs))}ngOnChanges(n){const a=n._matDialogClose||n._matDialogCloseResult;a&&(this.dialogResult=a.currentValue)}_onButtonClick(n){E(this.dialogRef,n.screenX===0&&n.screenY===0?"keyboard":"mouse",this.dialogResult)}static \u0275fac=function(a){return new(a||f)};static \u0275dir=t.\u0275\u0275defineDirective({type:f,selectors:[["","mat-dialog-close",""],["","matDialogClose",""]],hostVars:2,hostBindings:function(a,i){a&1&&t.\u0275\u0275listener("click",function(v){return i._onButtonClick(v)}),a&2&&t.\u0275\u0275attribute("aria-label",i.ariaLabel||null)("type",i.type)},inputs:{ariaLabel:[0,"aria-label","ariaLabel"],type:"type",dialogResult:[0,"mat-dialog-close","dialogResult"],_matDialogClose:[0,"matDialogClose","_matDialogClose"]},exportAs:["matDialogClose"],features:[t.\u0275\u0275NgOnChangesFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(f,[{type:t.Directive,args:[{selector:"[mat-dialog-close], [matDialogClose]",exportAs:"matDialogClose",host:{"(click)":"_onButtonClick($event)","[attr.aria-label]":"ariaLabel || null","[attr.type]":"type"}}]}],()=>[],{ariaLabel:[{type:t.Input,args:["aria-label"]}],type:[{type:t.Input}],dialogResult:[{type:t.Input,args:["mat-dialog-close"]}],_matDialogClose:[{type:t.Input,args:["matDialogClose"]}]});class b{_dialogRef=(0,t.inject)(O,{optional:!0});_elementRef=(0,t.inject)(t.ElementRef);_dialog=(0,t.inject)(s);constructor(){}ngOnInit(){this._dialogRef||(this._dialogRef=z(this._elementRef,this._dialog.openDialogs)),this._dialogRef&&Promise.resolve().then(()=>{this._onAdd()})}ngOnDestroy(){this._dialogRef?._containerInstance&&Promise.resolve().then(()=>{this._onRemove()})}static \u0275fac=function(a){return new(a||b)};static \u0275dir=t.\u0275\u0275defineDirective({type:b})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(b,[{type:t.Directive}],()=>[],null);class g extends b{id=(0,t.inject)(w._IdGenerator).getId("mat-mdc-dialog-title-");_onAdd(){this._dialogRef._containerInstance?._addAriaLabelledBy?.(this.id)}_onRemove(){this._dialogRef?._containerInstance?._removeAriaLabelledBy?.(this.id)}static \u0275fac=(()=>{let n;return function(i){return(n||(n=t.\u0275\u0275getInheritedFactory(g)))(i||g)}})();static \u0275dir=t.\u0275\u0275defineDirective({type:g,selectors:[["","mat-dialog-title",""],["","matDialogTitle",""]],hostAttrs:[1,"mat-mdc-dialog-title","mdc-dialog__title"],hostVars:1,hostBindings:function(a,i){a&2&&t.\u0275\u0275domProperty("id",i.id)},inputs:{id:"id"},exportAs:["matDialogTitle"],features:[t.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(g,[{type:t.Directive,args:[{selector:"[mat-dialog-title], [matDialogTitle]",exportAs:"matDialogTitle",host:{class:"mat-mdc-dialog-title mdc-dialog__title","[id]":"id"}}]}],null,{id:[{type:t.Input}]});class y{static \u0275fac=function(a){return new(a||y)};static \u0275dir=t.\u0275\u0275defineDirective({type:y,selectors:[["","mat-dialog-content",""],["mat-dialog-content"],["","matDialogContent",""]],hostAttrs:[1,"mat-mdc-dialog-content","mdc-dialog__content"],features:[t.\u0275\u0275HostDirectivesFeature([k.CdkScrollable])]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(y,[{type:t.Directive,args:[{selector:"[mat-dialog-content], mat-dialog-content, [matDialogContent]",host:{class:"mat-mdc-dialog-content mdc-dialog__content"},hostDirectives:[k.CdkScrollable]}]}],null,null);class h extends b{align;_onAdd(){this._dialogRef._containerInstance?._updateActionSectionCount?.(1)}_onRemove(){this._dialogRef._containerInstance?._updateActionSectionCount?.(-1)}static \u0275fac=(()=>{let n;return function(i){return(n||(n=t.\u0275\u0275getInheritedFactory(h)))(i||h)}})();static \u0275dir=t.\u0275\u0275defineDirective({type:h,selectors:[["","mat-dialog-actions",""],["mat-dialog-actions"],["","matDialogActions",""]],hostAttrs:[1,"mat-mdc-dialog-actions","mdc-dialog__actions"],hostVars:6,hostBindings:function(a,i){a&2&&t.\u0275\u0275classProp("mat-mdc-dialog-actions-align-start",i.align==="start")("mat-mdc-dialog-actions-align-center",i.align==="center")("mat-mdc-dialog-actions-align-end",i.align==="end")},inputs:{align:"align"},features:[t.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(h,[{type:t.Directive,args:[{selector:"[mat-dialog-actions], mat-dialog-actions, [matDialogActions]",host:{class:"mat-mdc-dialog-actions mdc-dialog__actions","[class.mat-mdc-dialog-actions-align-start]":'align === "start"',"[class.mat-mdc-dialog-actions-align-center]":'align === "center"',"[class.mat-mdc-dialog-actions-align-end]":'align === "end"'}}]}],null,{align:[{type:t.Input}]});function z(e,n){let a=e.nativeElement.parentElement;for(;a&&!a.classList.contains("mat-mdc-dialog-container");)a=a.parentElement;return a?n.find(i=>i.id===a.id):null}const U=[c,f,g,h,y];class x{static \u0275fac=function(a){return new(a||x)};static \u0275mod=t.\u0275\u0275defineNgModule({type:x});static \u0275inj=t.\u0275\u0275defineInjector({providers:[s],imports:[r.DialogModule,u.OverlayModule,m.PortalModule,R.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(x,[{type:t.NgModule,args:[{imports:[r.DialogModule,u.OverlayModule,m.PortalModule,...U],exports:[R.BidiModule,...U],providers:[s]}]}],null,null)}}]);
