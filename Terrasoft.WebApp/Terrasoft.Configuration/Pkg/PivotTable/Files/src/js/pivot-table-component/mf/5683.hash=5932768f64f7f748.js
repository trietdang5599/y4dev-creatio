(self.webpackChunkapp_studio_enterprise_pivot_table=self.webpackChunkapp_studio_enterprise_pivot_table||[]).push([[5683],{34630(S,x,i){i.d(x,{Rc:()=>s,Sx:()=>w,_J:()=>b});var v=i(15047),_=i(39638);const w=new _.InjectionToken("MATERIAL_ANIMATIONS");let y=null;function b(){return(0,_.inject)(w,{optional:!0})?.animationsDisabled||(0,_.inject)(_.ANIMATION_MODULE_TYPE,{optional:!0})==="NoopAnimations"?"di-disabled":(y??=(0,_.inject)(v.MediaMatcher).matchMedia("(prefers-reduced-motion)").matches,y?"reduced-motion":"enabled")}function s(){return b()!=="enabled"}},45683(S,x,i){i.r(x),i.d(x,{MAT_DRAWER_DEFAULT_AUTOSIZE:()=>E,MatDrawer:()=>p,MatDrawerContainer:()=>l,MatDrawerContent:()=>d,MatSidenav:()=>h,MatSidenavContainer:()=>u,MatSidenavContent:()=>c,MatSidenavModule:()=>C,throwMatDuplicatedDrawerError:()=>M});var v=i(60447),_=i(90459),w=i(73971),y=i(88783),b=i(52455),s=i(33807),e=i(39638),f=i(88632),a=i(24884),B=i(34630),W=i(15047);const D=["*"],T=["content"],I=[[["mat-drawer"]],[["mat-drawer-content"]],"*"],P=["mat-drawer","mat-drawer-content","*"];function A(g,t){if(g&1){const n=e.\u0275\u0275getCurrentView();e.\u0275\u0275elementStart(0,"div",1),e.\u0275\u0275listener("click",function(){e.\u0275\u0275restoreView(n);const o=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(o._onBackdropClicked())}),e.\u0275\u0275elementEnd()}if(g&2){const n=e.\u0275\u0275nextContext();e.\u0275\u0275classProp("mat-drawer-shown",n._isShowingBackdrop())}}function O(g,t){g&1&&(e.\u0275\u0275elementStart(0,"mat-drawer-content"),e.\u0275\u0275projection(1,2),e.\u0275\u0275elementEnd())}const j=[[["mat-sidenav"]],[["mat-sidenav-content"]],"*"],F=["mat-sidenav","mat-sidenav-content","*"];function R(g,t){if(g&1){const n=e.\u0275\u0275getCurrentView();e.\u0275\u0275elementStart(0,"div",1),e.\u0275\u0275listener("click",function(){e.\u0275\u0275restoreView(n);const o=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(o._onBackdropClicked())}),e.\u0275\u0275elementEnd()}if(g&2){const n=e.\u0275\u0275nextContext();e.\u0275\u0275classProp("mat-drawer-shown",n._isShowingBackdrop())}}function z(g,t){g&1&&(e.\u0275\u0275elementStart(0,"mat-sidenav-content"),e.\u0275\u0275projection(1,2),e.\u0275\u0275elementEnd())}const V=`.mat-drawer-container {
  position: relative;
  z-index: 1;
  color: var(--mat-sidenav-content-text-color, var(--mat-sys-on-background));
  background-color: var(--mat-sidenav-content-background-color, var(--mat-sys-background));
  box-sizing: border-box;
  display: block;
  overflow: hidden;
}
.mat-drawer-container[fullscreen] {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
}
.mat-drawer-container[fullscreen].mat-drawer-container-has-open {
  overflow: hidden;
}
.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side {
  z-index: 3;
}
.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,
.mat-drawer-container.ng-animate-disabled .mat-drawer-content, .ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,
.ng-animate-disabled .mat-drawer-container .mat-drawer-content {
  transition: none;
}

.mat-drawer-backdrop {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: block;
  z-index: 3;
  visibility: hidden;
}
.mat-drawer-backdrop.mat-drawer-shown {
  visibility: visible;
  background-color: var(--mat-sidenav-scrim-color, color-mix(in srgb, var(--mat-sys-neutral-variant20) 40%, transparent));
}
.mat-drawer-transition .mat-drawer-backdrop {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: background-color, visibility;
}
@media (forced-colors: active) {
  .mat-drawer-backdrop {
    opacity: 0.5;
  }
}

.mat-drawer-content {
  position: relative;
  z-index: 1;
  display: block;
  height: 100%;
  overflow: auto;
}
.mat-drawer-content.mat-drawer-content-hidden {
  opacity: 0;
}
.mat-drawer-transition .mat-drawer-content {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: transform, margin-left, margin-right;
}

.mat-drawer {
  position: relative;
  z-index: 4;
  color: var(--mat-sidenav-container-text-color, var(--mat-sys-on-surface-variant));
  box-shadow: var(--mat-sidenav-container-elevation-shadow, none);
  background-color: var(--mat-sidenav-container-background-color, var(--mat-sys-surface));
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  width: var(--mat-sidenav-container-width, 360px);
  display: block;
  position: absolute;
  top: 0;
  bottom: 0;
  z-index: 3;
  outline: 0;
  box-sizing: border-box;
  overflow-y: auto;
  transform: translate3d(-100%, 0, 0);
}
@media (forced-colors: active) {
  .mat-drawer, [dir=rtl] .mat-drawer.mat-drawer-end {
    border-right: solid 1px currentColor;
  }
}
@media (forced-colors: active) {
  [dir=rtl] .mat-drawer, .mat-drawer.mat-drawer-end {
    border-left: solid 1px currentColor;
    border-right: none;
  }
}
.mat-drawer.mat-drawer-side {
  z-index: 2;
}
.mat-drawer.mat-drawer-end {
  right: 0;
  transform: translate3d(100%, 0, 0);
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
}
[dir=rtl] .mat-drawer {
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
  transform: translate3d(100%, 0, 0);
}
[dir=rtl] .mat-drawer.mat-drawer-end {
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-left-radius: 0;
  border-bottom-left-radius: 0;
  left: 0;
  right: auto;
  transform: translate3d(-100%, 0, 0);
}
.mat-drawer-transition .mat-drawer {
  transition: transform 400ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) {
  visibility: hidden;
  box-shadow: none;
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) .mat-drawer-inner-container {
  display: none;
}
.mat-drawer.mat-drawer-opened.mat-drawer-opened {
  transform: none;
}

.mat-drawer-side {
  box-shadow: none;
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
}
.mat-drawer-side.mat-drawer-end {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side.mat-drawer-end {
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
  border-left: none;
}

.mat-drawer-inner-container {
  width: 100%;
  height: 100%;
  overflow: auto;
}

.mat-sidenav-fixed {
  position: fixed;
}
`;function M(g){throw Error(`A drawer was already declared for 'position="${g}"'`)}const E=new e.InjectionToken("MAT_DRAWER_DEFAULT_AUTOSIZE",{providedIn:"root",factory:()=>!1}),k=new e.InjectionToken("MAT_DRAWER_CONTAINER");class d extends s.CdkScrollable{_platform=(0,e.inject)(b.Platform);_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_container=(0,e.inject)(l);constructor(){const t=(0,e.inject)(e.ElementRef),n=(0,e.inject)(s.ScrollDispatcher),r=(0,e.inject)(e.NgZone);super(t,n,r)}ngAfterContentInit(){this._container._contentMarginChanges.subscribe(()=>{this._changeDetectorRef.markForCheck()})}_shouldBeHidden(){if(this._platform.isBrowser)return!1;const{start:t,end:n}=this._container;return t!=null&&t.mode!=="over"&&t.opened||n!=null&&n.mode!=="over"&&n.opened}static \u0275fac=function(n){return new(n||d)};static \u0275cmp=e.\u0275\u0275defineComponent({type:d,selectors:[["mat-drawer-content"]],hostAttrs:[1,"mat-drawer-content"],hostVars:6,hostBindings:function(n,r){n&2&&(e.\u0275\u0275styleProp("margin-left",r._container._contentMargins.left,"px")("margin-right",r._container._contentMargins.right,"px"),e.\u0275\u0275classProp("mat-drawer-content-hidden",r._shouldBeHidden()))},features:[e.\u0275\u0275ProvidersFeature([{provide:s.CdkScrollable,useExisting:d}]),e.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:D,decls:1,vars:0,template:function(n,r){n&1&&(e.\u0275\u0275projectionDef(),e.\u0275\u0275projection(0))},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(d,[{type:e.Component,args:[{selector:"mat-drawer-content",template:"<ng-content></ng-content>",host:{class:"mat-drawer-content","[style.margin-left.px]":"_container._contentMargins.left","[style.margin-right.px]":"_container._contentMargins.right","[class.mat-drawer-content-hidden]":"_shouldBeHidden()"},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,providers:[{provide:s.CdkScrollable,useExisting:d}]}]}],()=>[],null);class p{_elementRef=(0,e.inject)(e.ElementRef);_focusTrapFactory=(0,e.inject)(v.FocusTrapFactory);_focusMonitor=(0,e.inject)(v.FocusMonitor);_platform=(0,e.inject)(b.Platform);_ngZone=(0,e.inject)(e.NgZone);_renderer=(0,e.inject)(e.Renderer2);_interactivityChecker=(0,e.inject)(v.InteractivityChecker);_doc=(0,e.inject)(e.DOCUMENT);_container=(0,e.inject)(k,{optional:!0});_focusTrap=null;_elementFocusedBeforeDrawerWasOpened=null;_eventCleanups;_isAttached=!1;_anchor=null;get position(){return this._position}set position(t){t=t==="end"?"end":"start",t!==this._position&&(this._isAttached&&this._updatePositionInParent(t),this._position=t,this.onPositionChanged.emit())}_position="start";get mode(){return this._mode}set mode(t){this._mode=t,this._updateFocusTrapState(),this._modeChanged.next()}_mode="over";get disableClose(){return this._disableClose}set disableClose(t){this._disableClose=(0,w.coerceBooleanProperty)(t)}_disableClose=!1;get autoFocus(){const t=this._autoFocus;return t??(this.mode==="side"?"dialog":"first-tabbable")}set autoFocus(t){(t==="true"||t==="false"||t==null)&&(t=(0,w.coerceBooleanProperty)(t)),this._autoFocus=t}_autoFocus;get opened(){return this._opened()}set opened(t){this.toggle((0,w.coerceBooleanProperty)(t))}_opened=(0,e.signal)(!1,...ngDevMode?[{debugName:"_opened"}]:[]);_openedVia=null;_animationStarted=new f.Subject;_animationEnd=new f.Subject;openedChange=new e.EventEmitter(!0);_openedStream=this.openedChange.pipe((0,a.filter)(t=>t),(0,a.map)(()=>{}));openedStart=this._animationStarted.pipe((0,a.filter)(()=>this.opened),(0,a.mapTo)(void 0));_closedStream=this.openedChange.pipe((0,a.filter)(t=>!t),(0,a.map)(()=>{}));closedStart=this._animationStarted.pipe((0,a.filter)(()=>!this.opened),(0,a.mapTo)(void 0));_destroyed=new f.Subject;onPositionChanged=new e.EventEmitter;_content;_modeChanged=new f.Subject;_injector=(0,e.inject)(e.Injector);_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);constructor(){this.openedChange.pipe((0,a.takeUntil)(this._destroyed)).subscribe(t=>{t?(this._elementFocusedBeforeDrawerWasOpened=this._doc.activeElement,this._takeFocus()):this._isFocusWithinDrawer()&&this._restoreFocus(this._openedVia||"program")}),this._eventCleanups=this._ngZone.runOutsideAngular(()=>{const t=this._renderer,n=this._elementRef.nativeElement;return[t.listen(n,"keydown",r=>{r.keyCode===y.ESCAPE&&!this.disableClose&&!(0,y.hasModifierKey)(r)&&this._ngZone.run(()=>{this.close(),r.stopPropagation(),r.preventDefault()})}),t.listen(n,"transitionend",this._handleTransitionEvent),t.listen(n,"transitioncancel",this._handleTransitionEvent)]}),this._animationEnd.subscribe(()=>{this.openedChange.emit(this.opened)})}_forceFocus(t,n){this._interactivityChecker.isFocusable(t)||(t.tabIndex=-1,this._ngZone.runOutsideAngular(()=>{const r=()=>{o(),m(),t.removeAttribute("tabindex")},o=this._renderer.listen(t,"blur",r),m=this._renderer.listen(t,"mousedown",r)})),t.focus(n)}_focusByCssSelector(t,n){let r=this._elementRef.nativeElement.querySelector(t);r&&this._forceFocus(r,n)}_takeFocus(){if(!this._focusTrap)return;const t=this._elementRef.nativeElement;switch(this.autoFocus){case!1:case"dialog":return;case!0:case"first-tabbable":(0,e.afterNextRender)(()=>{!this._focusTrap.focusInitialElement()&&typeof t.focus=="function"&&t.focus()},{injector:this._injector});break;case"first-heading":this._focusByCssSelector('h1, h2, h3, h4, h5, h6, [role="heading"]');break;default:this._focusByCssSelector(this.autoFocus);break}}_restoreFocus(t){this.autoFocus!=="dialog"&&(this._elementFocusedBeforeDrawerWasOpened?this._focusMonitor.focusVia(this._elementFocusedBeforeDrawerWasOpened,t):this._elementRef.nativeElement.blur(),this._elementFocusedBeforeDrawerWasOpened=null)}_isFocusWithinDrawer(){const t=this._doc.activeElement;return!!t&&this._elementRef.nativeElement.contains(t)}ngAfterViewInit(){this._isAttached=!0,this._position==="end"&&this._updatePositionInParent("end"),this._platform.isBrowser&&(this._focusTrap=this._focusTrapFactory.create(this._elementRef.nativeElement),this._updateFocusTrapState())}ngOnDestroy(){this._eventCleanups.forEach(t=>t()),this._focusTrap?.destroy(),this._anchor?.remove(),this._anchor=null,this._animationStarted.complete(),this._animationEnd.complete(),this._modeChanged.complete(),this._destroyed.next(),this._destroyed.complete()}open(t){return this.toggle(!0,t)}close(){return this.toggle(!1)}_closeViaBackdropClick(){return this._setOpen(!1,!0,"mouse")}toggle(t=!this.opened,n){t&&n&&(this._openedVia=n);const r=this._setOpen(t,!t&&this._isFocusWithinDrawer(),this._openedVia||"program");return t||(this._openedVia=null),r}_setOpen(t,n,r){return t===this.opened?Promise.resolve(t?"open":"close"):(this._opened.set(t),this._container?._transitionsEnabled?(this._setIsAnimating(!0),setTimeout(()=>this._animationStarted.next())):setTimeout(()=>{this._animationStarted.next(),this._animationEnd.next()}),this._elementRef.nativeElement.classList.toggle("mat-drawer-opened",t),!t&&n&&this._restoreFocus(r),this._changeDetectorRef.markForCheck(),this._updateFocusTrapState(),new Promise(o=>{this.openedChange.pipe((0,a.take)(1)).subscribe(m=>o(m?"open":"close"))}))}_setIsAnimating(t){this._elementRef.nativeElement.classList.toggle("mat-drawer-animating",t)}_getWidth(){return this._elementRef.nativeElement.offsetWidth||0}_updateFocusTrapState(){this._focusTrap&&(this._focusTrap.enabled=this.opened&&!!this._container?._isShowingBackdrop())}_updatePositionInParent(t){if(!this._platform.isBrowser)return;const n=this._elementRef.nativeElement,r=n.parentNode;t==="end"?(this._anchor||(this._anchor=this._doc.createComment("mat-drawer-anchor"),r.insertBefore(this._anchor,n)),r.appendChild(n)):this._anchor&&this._anchor.parentNode.insertBefore(n,this._anchor)}_handleTransitionEvent=t=>{const n=this._elementRef.nativeElement;t.target===n&&this._ngZone.run(()=>{t.type==="transitionend"&&this._setIsAnimating(!1),this._animationEnd.next(t)})};static \u0275fac=function(n){return new(n||p)};static \u0275cmp=e.\u0275\u0275defineComponent({type:p,selectors:[["mat-drawer"]],viewQuery:function(n,r){if(n&1&&e.\u0275\u0275viewQuery(T,5),n&2){let o;e.\u0275\u0275queryRefresh(o=e.\u0275\u0275loadQuery())&&(r._content=o.first)}},hostAttrs:[1,"mat-drawer"],hostVars:12,hostBindings:function(n,r){n&2&&(e.\u0275\u0275attribute("align",null)("tabIndex",r.mode!=="side"?"-1":null),e.\u0275\u0275styleProp("visibility",!r._container&&!r.opened?"hidden":null),e.\u0275\u0275classProp("mat-drawer-end",r.position==="end")("mat-drawer-over",r.mode==="over")("mat-drawer-push",r.mode==="push")("mat-drawer-side",r.mode==="side"))},inputs:{position:"position",mode:"mode",disableClose:"disableClose",autoFocus:"autoFocus",opened:"opened"},outputs:{openedChange:"openedChange",_openedStream:"opened",openedStart:"openedStart",_closedStream:"closed",closedStart:"closedStart",onPositionChanged:"positionChanged"},exportAs:["matDrawer"],ngContentSelectors:D,decls:3,vars:0,consts:[["content",""],["cdkScrollable","",1,"mat-drawer-inner-container"]],template:function(n,r){n&1&&(e.\u0275\u0275projectionDef(),e.\u0275\u0275elementStart(0,"div",1,0),e.\u0275\u0275projection(2),e.\u0275\u0275elementEnd())},dependencies:[s.CdkScrollable],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(p,[{type:e.Component,args:[{selector:"mat-drawer",exportAs:"matDrawer",host:{class:"mat-drawer","[attr.align]":"null","[class.mat-drawer-end]":'position === "end"',"[class.mat-drawer-over]":'mode === "over"',"[class.mat-drawer-push]":'mode === "push"',"[class.mat-drawer-side]":'mode === "side"',"[style.visibility]":'(!_container && !opened) ? "hidden" : null',"[attr.tabIndex]":'(mode !== "side") ? "-1" : null'},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,imports:[s.CdkScrollable],template:`<div class="mat-drawer-inner-container" cdkScrollable #content>\r
  <ng-content></ng-content>\r
</div>\r
`}]}],()=>[],{position:[{type:e.Input}],mode:[{type:e.Input}],disableClose:[{type:e.Input}],autoFocus:[{type:e.Input}],opened:[{type:e.Input}],openedChange:[{type:e.Output}],_openedStream:[{type:e.Output,args:["opened"]}],openedStart:[{type:e.Output}],_closedStream:[{type:e.Output,args:["closed"]}],closedStart:[{type:e.Output}],onPositionChanged:[{type:e.Output,args:["positionChanged"]}],_content:[{type:e.ViewChild,args:["content"]}]});class l{_dir=(0,e.inject)(_.Directionality,{optional:!0});_element=(0,e.inject)(e.ElementRef);_ngZone=(0,e.inject)(e.NgZone);_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_animationDisabled=(0,B.Rc)();_transitionsEnabled=!1;_allDrawers;_drawers=new e.QueryList;_content;_userContent;get start(){return this._start}get end(){return this._end}get autosize(){return this._autosize}set autosize(t){this._autosize=(0,w.coerceBooleanProperty)(t)}_autosize=(0,e.inject)(E);get hasBackdrop(){return this._drawerHasBackdrop(this._start)||this._drawerHasBackdrop(this._end)}set hasBackdrop(t){this._backdropOverride=t==null?null:(0,w.coerceBooleanProperty)(t)}_backdropOverride=null;backdropClick=new e.EventEmitter;_start=null;_end=null;_left=null;_right=null;_destroyed=new f.Subject;_doCheckSubject=new f.Subject;_contentMargins={left:null,right:null};_contentMarginChanges=new f.Subject;get scrollable(){return this._userContent||this._content}_injector=(0,e.inject)(e.Injector);constructor(){const t=(0,e.inject)(b.Platform),n=(0,e.inject)(s.ViewportRuler);this._dir?.change.pipe((0,a.takeUntil)(this._destroyed)).subscribe(()=>{this._validateDrawers(),this.updateContentMargins()}),n.change().pipe((0,a.takeUntil)(this._destroyed)).subscribe(()=>this.updateContentMargins()),!this._animationDisabled&&t.isBrowser&&this._ngZone.runOutsideAngular(()=>{setTimeout(()=>{this._element.nativeElement.classList.add("mat-drawer-transition"),this._transitionsEnabled=!0},200)})}ngAfterContentInit(){this._allDrawers.changes.pipe((0,a.startWith)(this._allDrawers),(0,a.takeUntil)(this._destroyed)).subscribe(t=>{this._drawers.reset(t.filter(n=>!n._container||n._container===this)),this._drawers.notifyOnChanges()}),this._drawers.changes.pipe((0,a.startWith)(null)).subscribe(()=>{this._validateDrawers(),this._drawers.forEach(t=>{this._watchDrawerToggle(t),this._watchDrawerPosition(t),this._watchDrawerMode(t)}),(!this._drawers.length||this._isDrawerOpen(this._start)||this._isDrawerOpen(this._end))&&this.updateContentMargins(),this._changeDetectorRef.markForCheck()}),this._ngZone.runOutsideAngular(()=>{this._doCheckSubject.pipe((0,a.debounceTime)(10),(0,a.takeUntil)(this._destroyed)).subscribe(()=>this.updateContentMargins())})}ngOnDestroy(){this._contentMarginChanges.complete(),this._doCheckSubject.complete(),this._drawers.destroy(),this._destroyed.next(),this._destroyed.complete()}open(){this._drawers.forEach(t=>t.open())}close(){this._drawers.forEach(t=>t.close())}updateContentMargins(){let t=0,n=0;if(this._left&&this._left.opened){if(this._left.mode=="side")t+=this._left._getWidth();else if(this._left.mode=="push"){const r=this._left._getWidth();t+=r,n-=r}}if(this._right&&this._right.opened){if(this._right.mode=="side")n+=this._right._getWidth();else if(this._right.mode=="push"){const r=this._right._getWidth();n+=r,t-=r}}t=t||null,n=n||null,(t!==this._contentMargins.left||n!==this._contentMargins.right)&&(this._contentMargins={left:t,right:n},this._ngZone.run(()=>this._contentMarginChanges.next(this._contentMargins)))}ngDoCheck(){this._autosize&&this._isPushed()&&this._ngZone.runOutsideAngular(()=>this._doCheckSubject.next())}_watchDrawerToggle(t){t._animationStarted.pipe((0,a.takeUntil)(this._drawers.changes)).subscribe(()=>{this.updateContentMargins(),this._changeDetectorRef.markForCheck()}),t.mode!=="side"&&t.openedChange.pipe((0,a.takeUntil)(this._drawers.changes)).subscribe(()=>this._setContainerClass(t.opened))}_watchDrawerPosition(t){t.onPositionChanged.pipe((0,a.takeUntil)(this._drawers.changes)).subscribe(()=>{(0,e.afterNextRender)({read:()=>this._validateDrawers()},{injector:this._injector})})}_watchDrawerMode(t){t._modeChanged.pipe((0,a.takeUntil)((0,f.merge)(this._drawers.changes,this._destroyed))).subscribe(()=>{this.updateContentMargins(),this._changeDetectorRef.markForCheck()})}_setContainerClass(t){const n=this._element.nativeElement.classList,r="mat-drawer-container-has-open";t?n.add(r):n.remove(r)}_validateDrawers(){this._start=this._end=null,this._drawers.forEach(t=>{t.position=="end"?(this._end!=null&&(typeof ngDevMode>"u"||ngDevMode)&&M("end"),this._end=t):(this._start!=null&&(typeof ngDevMode>"u"||ngDevMode)&&M("start"),this._start=t)}),this._right=this._left=null,this._dir&&this._dir.value==="rtl"?(this._left=this._end,this._right=this._start):(this._left=this._start,this._right=this._end)}_isPushed(){return this._isDrawerOpen(this._start)&&this._start.mode!="over"||this._isDrawerOpen(this._end)&&this._end.mode!="over"}_onBackdropClicked(){this.backdropClick.emit(),this._closeModalDrawersViaBackdrop()}_closeModalDrawersViaBackdrop(){[this._start,this._end].filter(t=>t&&!t.disableClose&&this._drawerHasBackdrop(t)).forEach(t=>t._closeViaBackdropClick())}_isShowingBackdrop(){return this._isDrawerOpen(this._start)&&this._drawerHasBackdrop(this._start)||this._isDrawerOpen(this._end)&&this._drawerHasBackdrop(this._end)}_isDrawerOpen(t){return t!=null&&t.opened}_drawerHasBackdrop(t){return this._backdropOverride==null?!!t&&t.mode!=="side":this._backdropOverride}static \u0275fac=function(n){return new(n||l)};static \u0275cmp=e.\u0275\u0275defineComponent({type:l,selectors:[["mat-drawer-container"]],contentQueries:function(n,r,o){if(n&1&&e.\u0275\u0275contentQuery(o,d,5)(o,p,5),n&2){let m;e.\u0275\u0275queryRefresh(m=e.\u0275\u0275loadQuery())&&(r._content=m.first),e.\u0275\u0275queryRefresh(m=e.\u0275\u0275loadQuery())&&(r._allDrawers=m)}},viewQuery:function(n,r){if(n&1&&e.\u0275\u0275viewQuery(d,5),n&2){let o;e.\u0275\u0275queryRefresh(o=e.\u0275\u0275loadQuery())&&(r._userContent=o.first)}},hostAttrs:[1,"mat-drawer-container"],hostVars:2,hostBindings:function(n,r){n&2&&e.\u0275\u0275classProp("mat-drawer-container-explicit-backdrop",r._backdropOverride)},inputs:{autosize:"autosize",hasBackdrop:"hasBackdrop"},outputs:{backdropClick:"backdropClick"},exportAs:["matDrawerContainer"],features:[e.\u0275\u0275ProvidersFeature([{provide:k,useExisting:l}])],ngContentSelectors:P,decls:4,vars:2,consts:[[1,"mat-drawer-backdrop",3,"mat-drawer-shown"],[1,"mat-drawer-backdrop",3,"click"]],template:function(n,r){n&1&&(e.\u0275\u0275projectionDef(I),e.\u0275\u0275conditionalCreate(0,A,1,2,"div",0),e.\u0275\u0275projection(1),e.\u0275\u0275projection(2,1),e.\u0275\u0275conditionalCreate(3,O,2,0,"mat-drawer-content")),n&2&&(e.\u0275\u0275conditional(r.hasBackdrop?0:-1),e.\u0275\u0275advance(3),e.\u0275\u0275conditional(r._content?-1:3))},dependencies:[d],styles:[`.mat-drawer-container {
  position: relative;
  z-index: 1;
  color: var(--mat-sidenav-content-text-color, var(--mat-sys-on-background));
  background-color: var(--mat-sidenav-content-background-color, var(--mat-sys-background));
  box-sizing: border-box;
  display: block;
  overflow: hidden;
}
.mat-drawer-container[fullscreen] {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
}
.mat-drawer-container[fullscreen].mat-drawer-container-has-open {
  overflow: hidden;
}
.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side {
  z-index: 3;
}
.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,
.mat-drawer-container.ng-animate-disabled .mat-drawer-content, .ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,
.ng-animate-disabled .mat-drawer-container .mat-drawer-content {
  transition: none;
}

.mat-drawer-backdrop {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: block;
  z-index: 3;
  visibility: hidden;
}
.mat-drawer-backdrop.mat-drawer-shown {
  visibility: visible;
  background-color: var(--mat-sidenav-scrim-color, color-mix(in srgb, var(--mat-sys-neutral-variant20) 40%, transparent));
}
.mat-drawer-transition .mat-drawer-backdrop {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: background-color, visibility;
}
@media (forced-colors: active) {
  .mat-drawer-backdrop {
    opacity: 0.5;
  }
}

.mat-drawer-content {
  position: relative;
  z-index: 1;
  display: block;
  height: 100%;
  overflow: auto;
}
.mat-drawer-content.mat-drawer-content-hidden {
  opacity: 0;
}
.mat-drawer-transition .mat-drawer-content {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: transform, margin-left, margin-right;
}

.mat-drawer {
  position: relative;
  z-index: 4;
  color: var(--mat-sidenav-container-text-color, var(--mat-sys-on-surface-variant));
  box-shadow: var(--mat-sidenav-container-elevation-shadow, none);
  background-color: var(--mat-sidenav-container-background-color, var(--mat-sys-surface));
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  width: var(--mat-sidenav-container-width, 360px);
  display: block;
  position: absolute;
  top: 0;
  bottom: 0;
  z-index: 3;
  outline: 0;
  box-sizing: border-box;
  overflow-y: auto;
  transform: translate3d(-100%, 0, 0);
}
@media (forced-colors: active) {
  .mat-drawer, [dir=rtl] .mat-drawer.mat-drawer-end {
    border-right: solid 1px currentColor;
  }
}
@media (forced-colors: active) {
  [dir=rtl] .mat-drawer, .mat-drawer.mat-drawer-end {
    border-left: solid 1px currentColor;
    border-right: none;
  }
}
.mat-drawer.mat-drawer-side {
  z-index: 2;
}
.mat-drawer.mat-drawer-end {
  right: 0;
  transform: translate3d(100%, 0, 0);
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
}
[dir=rtl] .mat-drawer {
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
  transform: translate3d(100%, 0, 0);
}
[dir=rtl] .mat-drawer.mat-drawer-end {
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-left-radius: 0;
  border-bottom-left-radius: 0;
  left: 0;
  right: auto;
  transform: translate3d(-100%, 0, 0);
}
.mat-drawer-transition .mat-drawer {
  transition: transform 400ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) {
  visibility: hidden;
  box-shadow: none;
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) .mat-drawer-inner-container {
  display: none;
}
.mat-drawer.mat-drawer-opened.mat-drawer-opened {
  transform: none;
}

.mat-drawer-side {
  box-shadow: none;
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
}
.mat-drawer-side.mat-drawer-end {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side.mat-drawer-end {
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
  border-left: none;
}

.mat-drawer-inner-container {
  width: 100%;
  height: 100%;
  overflow: auto;
}

.mat-sidenav-fixed {
  position: fixed;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(l,[{type:e.Component,args:[{selector:"mat-drawer-container",exportAs:"matDrawerContainer",host:{class:"mat-drawer-container","[class.mat-drawer-container-explicit-backdrop]":"_backdropOverride"},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,providers:[{provide:k,useExisting:l}],imports:[d],template:`@if (hasBackdrop) {
  <div class="mat-drawer-backdrop" (click)="_onBackdropClicked()"
       [class.mat-drawer-shown]="_isShowingBackdrop()"></div>
}

<ng-content select="mat-drawer"></ng-content>

<ng-content select="mat-drawer-content">
</ng-content>

@if (!_content) {
  <mat-drawer-content>
    <ng-content></ng-content>
  </mat-drawer-content>
}
`,styles:[`.mat-drawer-container {
  position: relative;
  z-index: 1;
  color: var(--mat-sidenav-content-text-color, var(--mat-sys-on-background));
  background-color: var(--mat-sidenav-content-background-color, var(--mat-sys-background));
  box-sizing: border-box;
  display: block;
  overflow: hidden;
}
.mat-drawer-container[fullscreen] {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
}
.mat-drawer-container[fullscreen].mat-drawer-container-has-open {
  overflow: hidden;
}
.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side {
  z-index: 3;
}
.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,
.mat-drawer-container.ng-animate-disabled .mat-drawer-content, .ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,
.ng-animate-disabled .mat-drawer-container .mat-drawer-content {
  transition: none;
}

.mat-drawer-backdrop {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: block;
  z-index: 3;
  visibility: hidden;
}
.mat-drawer-backdrop.mat-drawer-shown {
  visibility: visible;
  background-color: var(--mat-sidenav-scrim-color, color-mix(in srgb, var(--mat-sys-neutral-variant20) 40%, transparent));
}
.mat-drawer-transition .mat-drawer-backdrop {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: background-color, visibility;
}
@media (forced-colors: active) {
  .mat-drawer-backdrop {
    opacity: 0.5;
  }
}

.mat-drawer-content {
  position: relative;
  z-index: 1;
  display: block;
  height: 100%;
  overflow: auto;
}
.mat-drawer-content.mat-drawer-content-hidden {
  opacity: 0;
}
.mat-drawer-transition .mat-drawer-content {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: transform, margin-left, margin-right;
}

.mat-drawer {
  position: relative;
  z-index: 4;
  color: var(--mat-sidenav-container-text-color, var(--mat-sys-on-surface-variant));
  box-shadow: var(--mat-sidenav-container-elevation-shadow, none);
  background-color: var(--mat-sidenav-container-background-color, var(--mat-sys-surface));
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  width: var(--mat-sidenav-container-width, 360px);
  display: block;
  position: absolute;
  top: 0;
  bottom: 0;
  z-index: 3;
  outline: 0;
  box-sizing: border-box;
  overflow-y: auto;
  transform: translate3d(-100%, 0, 0);
}
@media (forced-colors: active) {
  .mat-drawer, [dir=rtl] .mat-drawer.mat-drawer-end {
    border-right: solid 1px currentColor;
  }
}
@media (forced-colors: active) {
  [dir=rtl] .mat-drawer, .mat-drawer.mat-drawer-end {
    border-left: solid 1px currentColor;
    border-right: none;
  }
}
.mat-drawer.mat-drawer-side {
  z-index: 2;
}
.mat-drawer.mat-drawer-end {
  right: 0;
  transform: translate3d(100%, 0, 0);
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
}
[dir=rtl] .mat-drawer {
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
  transform: translate3d(100%, 0, 0);
}
[dir=rtl] .mat-drawer.mat-drawer-end {
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-left-radius: 0;
  border-bottom-left-radius: 0;
  left: 0;
  right: auto;
  transform: translate3d(-100%, 0, 0);
}
.mat-drawer-transition .mat-drawer {
  transition: transform 400ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) {
  visibility: hidden;
  box-shadow: none;
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) .mat-drawer-inner-container {
  display: none;
}
.mat-drawer.mat-drawer-opened.mat-drawer-opened {
  transform: none;
}

.mat-drawer-side {
  box-shadow: none;
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
}
.mat-drawer-side.mat-drawer-end {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side.mat-drawer-end {
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
  border-left: none;
}

.mat-drawer-inner-container {
  width: 100%;
  height: 100%;
  overflow: auto;
}

.mat-sidenav-fixed {
  position: fixed;
}
`]}]}],()=>[],{_allDrawers:[{type:e.ContentChildren,args:[p,{descendants:!0}]}],_content:[{type:e.ContentChild,args:[d]}],_userContent:[{type:e.ViewChild,args:[d]}],autosize:[{type:e.Input}],hasBackdrop:[{type:e.Input}],backdropClick:[{type:e.Output}]});class c extends d{static \u0275fac=(()=>{let t;return function(r){return(t||(t=e.\u0275\u0275getInheritedFactory(c)))(r||c)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:c,selectors:[["mat-sidenav-content"]],hostAttrs:[1,"mat-drawer-content","mat-sidenav-content"],features:[e.\u0275\u0275ProvidersFeature([{provide:s.CdkScrollable,useExisting:c}]),e.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:D,decls:1,vars:0,template:function(n,r){n&1&&(e.\u0275\u0275projectionDef(),e.\u0275\u0275projection(0))},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(c,[{type:e.Component,args:[{selector:"mat-sidenav-content",template:"<ng-content></ng-content>",host:{class:"mat-drawer-content mat-sidenav-content"},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,providers:[{provide:s.CdkScrollable,useExisting:c}]}]}],null,null);class h extends p{get fixedInViewport(){return this._fixedInViewport}set fixedInViewport(t){this._fixedInViewport=(0,w.coerceBooleanProperty)(t)}_fixedInViewport=!1;get fixedTopGap(){return this._fixedTopGap}set fixedTopGap(t){this._fixedTopGap=(0,w.coerceNumberProperty)(t)}_fixedTopGap=0;get fixedBottomGap(){return this._fixedBottomGap}set fixedBottomGap(t){this._fixedBottomGap=(0,w.coerceNumberProperty)(t)}_fixedBottomGap=0;static \u0275fac=(()=>{let t;return function(r){return(t||(t=e.\u0275\u0275getInheritedFactory(h)))(r||h)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:h,selectors:[["mat-sidenav"]],hostAttrs:[1,"mat-drawer","mat-sidenav"],hostVars:16,hostBindings:function(n,r){n&2&&(e.\u0275\u0275attribute("tabIndex",r.mode!=="side"?"-1":null)("align",null),e.\u0275\u0275styleProp("top",r.fixedInViewport?r.fixedTopGap:null,"px")("bottom",r.fixedInViewport?r.fixedBottomGap:null,"px"),e.\u0275\u0275classProp("mat-drawer-end",r.position==="end")("mat-drawer-over",r.mode==="over")("mat-drawer-push",r.mode==="push")("mat-drawer-side",r.mode==="side")("mat-sidenav-fixed",r.fixedInViewport))},inputs:{fixedInViewport:"fixedInViewport",fixedTopGap:"fixedTopGap",fixedBottomGap:"fixedBottomGap"},exportAs:["matSidenav"],features:[e.\u0275\u0275ProvidersFeature([{provide:p,useExisting:h}]),e.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:D,decls:3,vars:0,consts:[["content",""],["cdkScrollable","",1,"mat-drawer-inner-container"]],template:function(n,r){n&1&&(e.\u0275\u0275projectionDef(),e.\u0275\u0275elementStart(0,"div",1,0),e.\u0275\u0275projection(2),e.\u0275\u0275elementEnd())},dependencies:[s.CdkScrollable],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(h,[{type:e.Component,args:[{selector:"mat-sidenav",exportAs:"matSidenav",host:{class:"mat-drawer mat-sidenav","[attr.tabIndex]":'(mode !== "side") ? "-1" : null',"[attr.align]":"null","[class.mat-drawer-end]":'position === "end"',"[class.mat-drawer-over]":'mode === "over"',"[class.mat-drawer-push]":'mode === "push"',"[class.mat-drawer-side]":'mode === "side"',"[class.mat-sidenav-fixed]":"fixedInViewport","[style.top.px]":"fixedInViewport ? fixedTopGap : null","[style.bottom.px]":"fixedInViewport ? fixedBottomGap : null"},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,imports:[s.CdkScrollable],providers:[{provide:p,useExisting:h}],template:`<div class="mat-drawer-inner-container" cdkScrollable #content>\r
  <ng-content></ng-content>\r
</div>\r
`}]}],null,{fixedInViewport:[{type:e.Input}],fixedTopGap:[{type:e.Input}],fixedBottomGap:[{type:e.Input}]});class u extends l{_allDrawers=void 0;_content=void 0;static \u0275fac=(()=>{let t;return function(r){return(t||(t=e.\u0275\u0275getInheritedFactory(u)))(r||u)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:u,selectors:[["mat-sidenav-container"]],contentQueries:function(n,r,o){if(n&1&&e.\u0275\u0275contentQuery(o,c,5)(o,h,5),n&2){let m;e.\u0275\u0275queryRefresh(m=e.\u0275\u0275loadQuery())&&(r._content=m.first),e.\u0275\u0275queryRefresh(m=e.\u0275\u0275loadQuery())&&(r._allDrawers=m)}},hostAttrs:[1,"mat-drawer-container","mat-sidenav-container"],hostVars:2,hostBindings:function(n,r){n&2&&e.\u0275\u0275classProp("mat-drawer-container-explicit-backdrop",r._backdropOverride)},exportAs:["matSidenavContainer"],features:[e.\u0275\u0275ProvidersFeature([{provide:k,useExisting:u},{provide:l,useExisting:u}]),e.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:F,decls:4,vars:2,consts:[[1,"mat-drawer-backdrop",3,"mat-drawer-shown"],[1,"mat-drawer-backdrop",3,"click"]],template:function(n,r){n&1&&(e.\u0275\u0275projectionDef(j),e.\u0275\u0275conditionalCreate(0,R,1,2,"div",0),e.\u0275\u0275projection(1),e.\u0275\u0275projection(2,1),e.\u0275\u0275conditionalCreate(3,z,2,0,"mat-sidenav-content")),n&2&&(e.\u0275\u0275conditional(r.hasBackdrop?0:-1),e.\u0275\u0275advance(3),e.\u0275\u0275conditional(r._content?-1:3))},dependencies:[c],styles:[V],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(u,[{type:e.Component,args:[{selector:"mat-sidenav-container",exportAs:"matSidenavContainer",host:{class:"mat-drawer-container mat-sidenav-container","[class.mat-drawer-container-explicit-backdrop]":"_backdropOverride"},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,providers:[{provide:k,useExisting:u},{provide:l,useExisting:u}],imports:[c],template:`@if (hasBackdrop) {
  <div class="mat-drawer-backdrop" (click)="_onBackdropClicked()"
       [class.mat-drawer-shown]="_isShowingBackdrop()"></div>
}

<ng-content select="mat-sidenav"></ng-content>

<ng-content select="mat-sidenav-content">
</ng-content>

@if (!_content) {
  <mat-sidenav-content>
    <ng-content></ng-content>
  </mat-sidenav-content>
}
`,styles:[`.mat-drawer-container {
  position: relative;
  z-index: 1;
  color: var(--mat-sidenav-content-text-color, var(--mat-sys-on-background));
  background-color: var(--mat-sidenav-content-background-color, var(--mat-sys-background));
  box-sizing: border-box;
  display: block;
  overflow: hidden;
}
.mat-drawer-container[fullscreen] {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
}
.mat-drawer-container[fullscreen].mat-drawer-container-has-open {
  overflow: hidden;
}
.mat-drawer-container.mat-drawer-container-explicit-backdrop .mat-drawer-side {
  z-index: 3;
}
.mat-drawer-container.ng-animate-disabled .mat-drawer-backdrop,
.mat-drawer-container.ng-animate-disabled .mat-drawer-content, .ng-animate-disabled .mat-drawer-container .mat-drawer-backdrop,
.ng-animate-disabled .mat-drawer-container .mat-drawer-content {
  transition: none;
}

.mat-drawer-backdrop {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: block;
  z-index: 3;
  visibility: hidden;
}
.mat-drawer-backdrop.mat-drawer-shown {
  visibility: visible;
  background-color: var(--mat-sidenav-scrim-color, color-mix(in srgb, var(--mat-sys-neutral-variant20) 40%, transparent));
}
.mat-drawer-transition .mat-drawer-backdrop {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: background-color, visibility;
}
@media (forced-colors: active) {
  .mat-drawer-backdrop {
    opacity: 0.5;
  }
}

.mat-drawer-content {
  position: relative;
  z-index: 1;
  display: block;
  height: 100%;
  overflow: auto;
}
.mat-drawer-content.mat-drawer-content-hidden {
  opacity: 0;
}
.mat-drawer-transition .mat-drawer-content {
  transition-duration: 400ms;
  transition-timing-function: cubic-bezier(0.25, 0.8, 0.25, 1);
  transition-property: transform, margin-left, margin-right;
}

.mat-drawer {
  position: relative;
  z-index: 4;
  color: var(--mat-sidenav-container-text-color, var(--mat-sys-on-surface-variant));
  box-shadow: var(--mat-sidenav-container-elevation-shadow, none);
  background-color: var(--mat-sidenav-container-background-color, var(--mat-sys-surface));
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  width: var(--mat-sidenav-container-width, 360px);
  display: block;
  position: absolute;
  top: 0;
  bottom: 0;
  z-index: 3;
  outline: 0;
  box-sizing: border-box;
  overflow-y: auto;
  transform: translate3d(-100%, 0, 0);
}
@media (forced-colors: active) {
  .mat-drawer, [dir=rtl] .mat-drawer.mat-drawer-end {
    border-right: solid 1px currentColor;
  }
}
@media (forced-colors: active) {
  [dir=rtl] .mat-drawer, .mat-drawer.mat-drawer-end {
    border-left: solid 1px currentColor;
    border-right: none;
  }
}
.mat-drawer.mat-drawer-side {
  z-index: 2;
}
.mat-drawer.mat-drawer-end {
  right: 0;
  transform: translate3d(100%, 0, 0);
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
}
[dir=rtl] .mat-drawer {
  border-top-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-left-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-right-radius: 0;
  border-bottom-right-radius: 0;
  transform: translate3d(100%, 0, 0);
}
[dir=rtl] .mat-drawer.mat-drawer-end {
  border-top-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-bottom-right-radius: var(--mat-sidenav-container-shape, var(--mat-sys-corner-large));
  border-top-left-radius: 0;
  border-bottom-left-radius: 0;
  left: 0;
  right: auto;
  transform: translate3d(-100%, 0, 0);
}
.mat-drawer-transition .mat-drawer {
  transition: transform 400ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) {
  visibility: hidden;
  box-shadow: none;
}
.mat-drawer:not(.mat-drawer-opened):not(.mat-drawer-animating) .mat-drawer-inner-container {
  display: none;
}
.mat-drawer.mat-drawer-opened.mat-drawer-opened {
  transform: none;
}

.mat-drawer-side {
  box-shadow: none;
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
}
.mat-drawer-side.mat-drawer-end {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side {
  border-left-color: var(--mat-sidenav-container-divider-color, transparent);
  border-left-width: 1px;
  border-left-style: solid;
  border-right: none;
}
[dir=rtl] .mat-drawer-side.mat-drawer-end {
  border-right-color: var(--mat-sidenav-container-divider-color, transparent);
  border-right-width: 1px;
  border-right-style: solid;
  border-left: none;
}

.mat-drawer-inner-container {
  width: 100%;
  height: 100%;
  overflow: auto;
}

.mat-sidenav-fixed {
  position: fixed;
}
`]}]}],null,{_allDrawers:[{type:e.ContentChildren,args:[h,{descendants:!0}]}],_content:[{type:e.ContentChild,args:[c]}]});class C{static \u0275fac=function(n){return new(n||C)};static \u0275mod=e.\u0275\u0275defineNgModule({type:C});static \u0275inj=e.\u0275\u0275defineInjector({imports:[s.CdkScrollableModule,_.BidiModule,s.CdkScrollableModule]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(C,[{type:e.NgModule,args:[{imports:[s.CdkScrollableModule,p,l,d,h,u,c],exports:[_.BidiModule,s.CdkScrollableModule,p,l,d,h,u,c]}]}],null,null)}}]);
