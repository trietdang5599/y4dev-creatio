(self.webpackChunkapp_studio_enterprise_omnichannel_messaging=self.webpackChunkapp_studio_enterprise_omnichannel_messaging||[]).push([[1184],{71127(z,E,s){s.d(E,{p:()=>l});var v=s(90459),e=s(39638),r=s(84350);class l{static \u0275fac=function(T){return new(T||l)};static \u0275mod=e.\u0275\u0275defineNgModule({type:l});static \u0275inj=e.\u0275\u0275defineInjector({imports:[v.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(l,[{type:e.NgModule,args:[{imports:[r.r6],exports:[r.r6,v.BidiModule]}]}],null,null)},1184(z,E,s){s.r(E),s.d(E,{MAT_MENU_CONTENT:()=>x,MAT_MENU_DEFAULT_OPTIONS:()=>U,MAT_MENU_PANEL:()=>M,MAT_MENU_SCROLL_STRATEGY:()=>W,MENU_PANEL_TOP_PADDING:()=>ee,MatContextMenuTrigger:()=>b,MatMenu:()=>m,MatMenuContent:()=>p,MatMenuItem:()=>c,MatMenuModule:()=>D,MatMenuTrigger:()=>f});var v=s(34883),e=s(39638),r=s(88632),l=s(60447),u=s(88783),d=s(24884),T=s(4295),K=s(30184),F=s(84350),B=s(34630),k=s(90459),_=s(15893),j=s(52455),L=s(33807),N=s(71127),te=s(73971),ne=s(15047);const Y=["mat-menu-item",""],V=[[["mat-icon"],["","matMenuItemIcon",""]],"*"],X=["mat-icon, [matMenuItemIcon]","*"];function G(g,t){g&1&&(e.\u0275\u0275namespaceSVG(),e.\u0275\u0275elementStart(0,"svg",2),e.\u0275\u0275element(1,"polygon",3),e.\u0275\u0275elementEnd())}const Q=["*"];function $(g,t){if(g&1){const n=e.\u0275\u0275getCurrentView();e.\u0275\u0275domElementStart(0,"div",0),e.\u0275\u0275domListener("click",function(){e.\u0275\u0275restoreView(n);const a=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(a.closed.emit("click"))})("animationstart",function(a){e.\u0275\u0275restoreView(n);const o=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(o._onAnimationStart(a.animationName))})("animationend",function(a){e.\u0275\u0275restoreView(n);const o=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(o._onAnimationDone(a.animationName))})("animationcancel",function(a){e.\u0275\u0275restoreView(n);const o=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(o._onAnimationDone(a.animationName))}),e.\u0275\u0275domElementStart(1,"div",1),e.\u0275\u0275projection(2),e.\u0275\u0275domElementEnd()()}if(g&2){const n=e.\u0275\u0275nextContext();e.\u0275\u0275classMap(n._classList),e.\u0275\u0275classProp("mat-menu-panel-animations-disabled",n._animationsDisabled)("mat-menu-panel-exit-animation",n._panelAnimationState==="void")("mat-menu-panel-animating",n._isAnimating()),e.\u0275\u0275domProperty("id",n.panelId),e.\u0275\u0275attribute("aria-label",n.ariaLabel||null)("aria-labelledby",n.ariaLabelledby||null)("aria-describedby",n.ariaDescribedby||null)}}const M=new e.InjectionToken("MAT_MENU_PANEL");class c{_elementRef=(0,e.inject)(e.ElementRef);_document=(0,e.inject)(e.DOCUMENT);_focusMonitor=(0,e.inject)(l.FocusMonitor);_parentMenu=(0,e.inject)(M,{optional:!0});_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);role="menuitem";disabled=!1;disableRipple=!1;_hovered=new r.Subject;_focused=new r.Subject;_highlighted=!1;_triggersSubmenu=!1;constructor(){(0,e.inject)(T._CdkPrivateStyleLoader).load(K.A),this._parentMenu?.addItem?.(this)}focus(t,n){this._focusMonitor&&t?this._focusMonitor.focusVia(this._getHostElement(),t,n):this._getHostElement().focus(n),this._focused.next(this)}ngAfterViewInit(){this._focusMonitor&&this._focusMonitor.monitor(this._elementRef,!1)}ngOnDestroy(){this._focusMonitor&&this._focusMonitor.stopMonitoring(this._elementRef),this._parentMenu&&this._parentMenu.removeItem&&this._parentMenu.removeItem(this),this._hovered.complete(),this._focused.complete()}_getTabIndex(){return this.disabled?"-1":"0"}_getHostElement(){return this._elementRef.nativeElement}_checkDisabled(t){this.disabled&&(t.preventDefault(),t.stopPropagation())}_handleMouseEnter(){this._hovered.next(this)}getLabel(){const t=this._elementRef.nativeElement.cloneNode(!0),n=t.querySelectorAll("mat-icon, .material-icons");for(let i=0;i<n.length;i++)n[i].remove();return t.textContent?.trim()||""}_setHighlighted(t){this._highlighted=t,this._changeDetectorRef.markForCheck()}_setTriggersSubmenu(t){this._triggersSubmenu=t,this._changeDetectorRef.markForCheck()}_hasFocus(){return this._document&&this._document.activeElement===this._getHostElement()}static \u0275fac=function(n){return new(n||c)};static \u0275cmp=e.\u0275\u0275defineComponent({type:c,selectors:[["","mat-menu-item",""]],hostAttrs:[1,"mat-mdc-menu-item","mat-focus-indicator"],hostVars:8,hostBindings:function(n,i){n&1&&e.\u0275\u0275listener("click",function(o){return i._checkDisabled(o)})("mouseenter",function(){return i._handleMouseEnter()}),n&2&&(e.\u0275\u0275attribute("role",i.role)("tabindex",i._getTabIndex())("aria-disabled",i.disabled)("disabled",i.disabled||null),e.\u0275\u0275classProp("mat-mdc-menu-item-highlighted",i._highlighted)("mat-mdc-menu-item-submenu-trigger",i._triggersSubmenu))},inputs:{role:"role",disabled:[2,"disabled","disabled",e.booleanAttribute],disableRipple:[2,"disableRipple","disableRipple",e.booleanAttribute]},exportAs:["matMenuItem"],attrs:Y,ngContentSelectors:X,decls:5,vars:3,consts:[[1,"mat-mdc-menu-item-text"],["matRipple","",1,"mat-mdc-menu-ripple",3,"matRippleDisabled","matRippleTrigger"],["viewBox","0 0 5 10","focusable","false","aria-hidden","true",1,"mat-mdc-menu-submenu-icon"],["points","0,0 5,5 0,10"]],template:function(n,i){n&1&&(e.\u0275\u0275projectionDef(V),e.\u0275\u0275projection(0),e.\u0275\u0275elementStart(1,"span",0),e.\u0275\u0275projection(2,1),e.\u0275\u0275elementEnd(),e.\u0275\u0275element(3,"div",1),e.\u0275\u0275conditionalCreate(4,G,2,0,":svg:svg",2)),n&2&&(e.\u0275\u0275advance(3),e.\u0275\u0275property("matRippleDisabled",i.disableRipple||i.disabled)("matRippleTrigger",i._getHostElement()),e.\u0275\u0275advance(),e.\u0275\u0275conditional(i._triggersSubmenu?4:-1))},dependencies:[F.r6],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(c,[{type:e.Component,args:[{selector:"[mat-menu-item]",exportAs:"matMenuItem",host:{"[attr.role]":"role",class:"mat-mdc-menu-item mat-focus-indicator","[class.mat-mdc-menu-item-highlighted]":"_highlighted","[class.mat-mdc-menu-item-submenu-trigger]":"_triggersSubmenu","[attr.tabindex]":"_getTabIndex()","[attr.aria-disabled]":"disabled","[attr.disabled]":"disabled || null","(click)":"_checkDisabled($event)","(mouseenter)":"_handleMouseEnter()"},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,imports:[F.r6],template:`<ng-content select="mat-icon, [matMenuItemIcon]"></ng-content>
<span class="mat-mdc-menu-item-text"><ng-content></ng-content></span>
<div class="mat-mdc-menu-ripple" matRipple
     [matRippleDisabled]="disableRipple || disabled"
     [matRippleTrigger]="_getHostElement()">
</div>

@if (_triggersSubmenu) {
     <svg
       class="mat-mdc-menu-submenu-icon"
       viewBox="0 0 5 10"
       focusable="false"
       aria-hidden="true"><polygon points="0,0 5,5 0,10"/></svg>
}
`}]}],()=>[],{role:[{type:e.Input}],disabled:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],disableRipple:[{type:e.Input,args:[{transform:e.booleanAttribute}]}]});function Z(){throw Error(`xPosition value must be either 'before' or after'.
      Example: <mat-menu xPosition="before" #menu="matMenu"></mat-menu>`)}function J(){throw Error(`yPosition value must be either 'above' or below'.
      Example: <mat-menu yPosition="above" #menu="matMenu"></mat-menu>`)}function q(){throw Error("matMenuTriggerFor: menu cannot contain its own trigger. Assign a menu that is not a parent of the trigger or move the trigger outside of the menu.")}const x=new e.InjectionToken("MatMenuContent");class p{_template=(0,e.inject)(e.TemplateRef);_appRef=(0,e.inject)(e.ApplicationRef);_injector=(0,e.inject)(e.Injector);_viewContainerRef=(0,e.inject)(e.ViewContainerRef);_document=(0,e.inject)(e.DOCUMENT);_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_portal;_outlet;_attached=new r.Subject;constructor(){}attach(t={}){this._portal||(this._portal=new v.TemplatePortal(this._template,this._viewContainerRef)),this.detach(),this._outlet||(this._outlet=new v.DomPortalOutlet(this._document.createElement("div"),this._appRef,this._injector));const n=this._template.elementRef.nativeElement;n.parentNode.insertBefore(this._outlet.outletElement,n),this._changeDetectorRef.markForCheck(),this._portal.attach(this._outlet,t),this._attached.next()}detach(){this._portal?.isAttached&&this._portal.detach()}ngOnDestroy(){this.detach(),this._outlet?.dispose()}static \u0275fac=function(n){return new(n||p)};static \u0275dir=e.\u0275\u0275defineDirective({type:p,selectors:[["ng-template","matMenuContent",""]],features:[e.\u0275\u0275ProvidersFeature([{provide:x,useExisting:p}])]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(p,[{type:e.Directive,args:[{selector:"ng-template[matMenuContent]",providers:[{provide:x,useExisting:p}]}]}],()=>[],null);const U=new e.InjectionToken("mat-menu-default-options",{providedIn:"root",factory:()=>({overlapTrigger:!1,xPosition:"after",yPosition:"below",backdropClass:"cdk-overlay-transparent-backdrop"})}),R="_mat-menu-enter",P="_mat-menu-exit";class m{_elementRef=(0,e.inject)(e.ElementRef);_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_injector=(0,e.inject)(e.Injector);_keyManager;_xPosition;_yPosition;_firstItemFocusRef;_exitFallbackTimeout;_animationsDisabled=(0,B.Rc)();_allItems;_directDescendantItems=new e.QueryList;_classList={};_panelAnimationState="void";_animationDone=new r.Subject;_isAnimating=(0,e.signal)(!1,...ngDevMode?[{debugName:"_isAnimating"}]:[]);parentMenu;direction;overlayPanelClass;backdropClass;ariaLabel;ariaLabelledby;ariaDescribedby;get xPosition(){return this._xPosition}set xPosition(t){t!=="before"&&t!=="after"&&(typeof ngDevMode>"u"||ngDevMode)&&Z(),this._xPosition=t,this.setPositionClasses()}get yPosition(){return this._yPosition}set yPosition(t){t!=="above"&&t!=="below"&&(typeof ngDevMode>"u"||ngDevMode)&&J(),this._yPosition=t,this.setPositionClasses()}templateRef;items;lazyContent;overlapTrigger=!1;hasBackdrop;set panelClass(t){const n=this._previousPanelClass,i={...this._classList};n&&n.length&&n.split(" ").forEach(a=>{i[a]=!1}),this._previousPanelClass=t,t&&t.length&&(t.split(" ").forEach(a=>{i[a]=!0}),this._elementRef.nativeElement.className=""),this._classList=i}_previousPanelClass;get classList(){return this.panelClass}set classList(t){this.panelClass=t}closed=new e.EventEmitter;close=this.closed;panelId=(0,e.inject)(l._IdGenerator).getId("mat-menu-panel-");constructor(){const t=(0,e.inject)(U);this.overlayPanelClass=t.overlayPanelClass||"",this._xPosition=t.xPosition,this._yPosition=t.yPosition,this.backdropClass=t.backdropClass,this.overlapTrigger=t.overlapTrigger,this.hasBackdrop=t.hasBackdrop}ngOnInit(){this.setPositionClasses()}ngAfterContentInit(){this._updateDirectDescendants(),this._keyManager=new l.FocusKeyManager(this._directDescendantItems).withWrap().withTypeAhead().withHomeAndEnd(),this._keyManager.tabOut.subscribe(()=>this.closed.emit("tab")),this._directDescendantItems.changes.pipe((0,d.startWith)(this._directDescendantItems),(0,d.switchMap)(t=>(0,r.merge)(...t.map(n=>n._focused)))).subscribe(t=>this._keyManager.updateActiveItem(t)),this._directDescendantItems.changes.subscribe(t=>{const n=this._keyManager;if(this._panelAnimationState==="enter"&&n.activeItem?._hasFocus()){const i=t.toArray(),a=Math.max(0,Math.min(i.length-1,n.activeItemIndex||0));i[a]&&!i[a].disabled?n.setActiveItem(a):n.setNextItemActive()}})}ngOnDestroy(){this._keyManager?.destroy(),this._directDescendantItems.destroy(),this.closed.complete(),this._firstItemFocusRef?.destroy(),clearTimeout(this._exitFallbackTimeout)}_hovered(){return this._directDescendantItems.changes.pipe((0,d.startWith)(this._directDescendantItems),(0,d.switchMap)(n=>(0,r.merge)(...n.map(i=>i._hovered))))}addItem(t){}removeItem(t){}_handleKeydown(t){const n=t.keyCode,i=this._keyManager;switch(n){case u.ESCAPE:(0,u.hasModifierKey)(t)||(t.preventDefault(),this.closed.emit("keydown"));break;case u.LEFT_ARROW:this.parentMenu&&this.direction==="ltr"&&this.closed.emit("keydown");break;case u.RIGHT_ARROW:this.parentMenu&&this.direction==="rtl"&&this.closed.emit("keydown");break;default:(n===u.UP_ARROW||n===u.DOWN_ARROW)&&i.setFocusOrigin("keyboard"),i.onKeydown(t);return}}focusFirstItem(t="program"){this._firstItemFocusRef?.destroy(),this._firstItemFocusRef=(0,e.afterNextRender)(()=>{const n=this._resolvePanel();if(!n||!n.contains(document.activeElement)){const i=this._keyManager;i.setFocusOrigin(t).setFirstItemActive(),!i.activeItem&&n&&n.focus()}},{injector:this._injector})}resetActiveItem(){this._keyManager.setActiveItem(-1)}setElevation(t){}setPositionClasses(t=this.xPosition,n=this.yPosition){this._classList={...this._classList,"mat-menu-before":t==="before","mat-menu-after":t==="after","mat-menu-above":n==="above","mat-menu-below":n==="below"},this._changeDetectorRef.markForCheck()}_onAnimationDone(t){const n=t===P;(n||t===R)&&(n&&(clearTimeout(this._exitFallbackTimeout),this._exitFallbackTimeout=void 0),this._animationDone.next(n?"void":"enter"),this._isAnimating.set(!1))}_onAnimationStart(t){(t===R||t===P)&&this._isAnimating.set(!0)}_setIsOpen(t){if(this._panelAnimationState=t?"enter":"void",t){if(this._keyManager.activeItemIndex===0){const n=this._resolvePanel();n&&(n.scrollTop=0)}}else this._animationsDisabled||(this._exitFallbackTimeout=setTimeout(()=>this._onAnimationDone(P),200));this._animationsDisabled&&setTimeout(()=>{this._onAnimationDone(t?R:P)}),this._changeDetectorRef.markForCheck()}_updateDirectDescendants(){this._allItems.changes.pipe((0,d.startWith)(this._allItems)).subscribe(t=>{this._directDescendantItems.reset(t.filter(n=>n._parentMenu===this)),this._directDescendantItems.notifyOnChanges()})}_resolvePanel(){let t=null;return this._directDescendantItems.length&&(t=this._directDescendantItems.first._getHostElement().closest('[role="menu"]')),t}static \u0275fac=function(n){return new(n||m)};static \u0275cmp=e.\u0275\u0275defineComponent({type:m,selectors:[["mat-menu"]],contentQueries:function(n,i,a){if(n&1&&e.\u0275\u0275contentQuery(a,x,5)(a,c,5)(a,c,4),n&2){let o;e.\u0275\u0275queryRefresh(o=e.\u0275\u0275loadQuery())&&(i.lazyContent=o.first),e.\u0275\u0275queryRefresh(o=e.\u0275\u0275loadQuery())&&(i._allItems=o),e.\u0275\u0275queryRefresh(o=e.\u0275\u0275loadQuery())&&(i.items=o)}},viewQuery:function(n,i){if(n&1&&e.\u0275\u0275viewQuery(e.TemplateRef,5),n&2){let a;e.\u0275\u0275queryRefresh(a=e.\u0275\u0275loadQuery())&&(i.templateRef=a.first)}},hostVars:3,hostBindings:function(n,i){n&2&&e.\u0275\u0275attribute("aria-label",null)("aria-labelledby",null)("aria-describedby",null)},inputs:{backdropClass:"backdropClass",ariaLabel:[0,"aria-label","ariaLabel"],ariaLabelledby:[0,"aria-labelledby","ariaLabelledby"],ariaDescribedby:[0,"aria-describedby","ariaDescribedby"],xPosition:"xPosition",yPosition:"yPosition",overlapTrigger:[2,"overlapTrigger","overlapTrigger",e.booleanAttribute],hasBackdrop:[2,"hasBackdrop","hasBackdrop",t=>t==null?null:(0,e.booleanAttribute)(t)],panelClass:[0,"class","panelClass"],classList:"classList"},outputs:{closed:"closed",close:"close"},exportAs:["matMenu"],features:[e.\u0275\u0275ProvidersFeature([{provide:M,useExisting:m}])],ngContentSelectors:Q,decls:1,vars:0,consts:[["tabindex","-1","role","menu",1,"mat-mdc-menu-panel",3,"click","animationstart","animationend","animationcancel","id"],[1,"mat-mdc-menu-content"]],template:function(n,i){n&1&&(e.\u0275\u0275projectionDef(),e.\u0275\u0275domTemplate(0,$,3,12,"ng-template"))},styles:[`mat-menu {
  display: none;
}

.mat-mdc-menu-content {
  margin: 0;
  padding: 8px 0;
  outline: 0;
}
.mat-mdc-menu-content,
.mat-mdc-menu-content .mat-mdc-menu-item .mat-mdc-menu-item-text {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  flex: 1;
  white-space: normal;
  font-family: var(--mat-menu-item-label-text-font, var(--mat-sys-label-large-font));
  line-height: var(--mat-menu-item-label-text-line-height, var(--mat-sys-label-large-line-height));
  font-size: var(--mat-menu-item-label-text-size, var(--mat-sys-label-large-size));
  letter-spacing: var(--mat-menu-item-label-text-tracking, var(--mat-sys-label-large-tracking));
  font-weight: var(--mat-menu-item-label-text-weight, var(--mat-sys-label-large-weight));
}

@keyframes _mat-menu-enter {
  from {
    opacity: 0;
    transform: scale(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-menu-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-mdc-menu-panel {
  min-width: 112px;
  max-width: 280px;
  overflow: auto;
  box-sizing: border-box;
  outline: 0;
  animation: _mat-menu-enter 120ms cubic-bezier(0, 0, 0.2, 1);
  border-radius: var(--mat-menu-container-shape, var(--mat-sys-corner-extra-small));
  background-color: var(--mat-menu-container-color, var(--mat-sys-surface-container));
  box-shadow: var(--mat-menu-container-elevation-shadow, 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12));
  will-change: transform, opacity;
}
.mat-mdc-menu-panel.mat-menu-panel-exit-animation {
  animation: _mat-menu-exit 100ms 25ms linear forwards;
}
.mat-mdc-menu-panel.mat-menu-panel-animations-disabled {
  animation: none;
}
.mat-mdc-menu-panel.mat-menu-panel-animating {
  pointer-events: none;
}
.mat-mdc-menu-panel.mat-menu-panel-animating:has(.mat-mdc-menu-content:empty) {
  display: none;
}
@media (forced-colors: active) {
  .mat-mdc-menu-panel {
    outline: solid 1px;
  }
}
.mat-mdc-menu-panel .mat-divider {
  border-top-color: var(--mat-menu-divider-color, var(--mat-sys-surface-variant));
  margin-bottom: var(--mat-menu-divider-bottom-spacing, 8px);
  margin-top: var(--mat-menu-divider-top-spacing, 8px);
}

.mat-mdc-menu-item {
  display: flex;
  position: relative;
  align-items: center;
  justify-content: flex-start;
  overflow: hidden;
  padding: 0;
  cursor: pointer;
  width: 100%;
  text-align: left;
  box-sizing: border-box;
  color: inherit;
  font-size: inherit;
  background: none;
  text-decoration: none;
  margin: 0;
  min-height: 48px;
  padding-left: var(--mat-menu-item-leading-spacing, 12px);
  padding-right: var(--mat-menu-item-trailing-spacing, 12px);
  -webkit-user-select: none;
  user-select: none;
  cursor: pointer;
  outline: none;
  border: none;
  -webkit-tap-highlight-color: transparent;
}
.mat-mdc-menu-item::-moz-focus-inner {
  border: 0;
}
[dir=rtl] .mat-mdc-menu-item {
  padding-left: var(--mat-menu-item-trailing-spacing, 12px);
  padding-right: var(--mat-menu-item-leading-spacing, 12px);
}
.mat-mdc-menu-item:has(.material-icons, mat-icon, [matButtonIcon]) {
  padding-left: var(--mat-menu-item-with-icon-leading-spacing, 12px);
  padding-right: var(--mat-menu-item-with-icon-trailing-spacing, 12px);
}
[dir=rtl] .mat-mdc-menu-item:has(.material-icons, mat-icon, [matButtonIcon]) {
  padding-left: var(--mat-menu-item-with-icon-trailing-spacing, 12px);
  padding-right: var(--mat-menu-item-with-icon-leading-spacing, 12px);
}
.mat-mdc-menu-item, .mat-mdc-menu-item:visited, .mat-mdc-menu-item:link {
  color: var(--mat-menu-item-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-menu-item .mat-icon-no-color,
.mat-mdc-menu-item .mat-mdc-menu-submenu-icon {
  color: var(--mat-menu-item-icon-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-menu-item[disabled] {
  cursor: default;
  opacity: 0.38;
}
.mat-mdc-menu-item[disabled]::after {
  display: block;
  position: absolute;
  content: "";
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}
.mat-mdc-menu-item:focus {
  outline: 0;
}
.mat-mdc-menu-item .mat-icon {
  flex-shrink: 0;
  margin-right: var(--mat-menu-item-spacing, 12px);
  height: var(--mat-menu-item-icon-size, 24px);
  width: var(--mat-menu-item-icon-size, 24px);
}
[dir=rtl] .mat-mdc-menu-item {
  text-align: right;
}
[dir=rtl] .mat-mdc-menu-item .mat-icon {
  margin-right: 0;
  margin-left: var(--mat-menu-item-spacing, 12px);
}
.mat-mdc-menu-item:not([disabled]):hover {
  background-color: var(--mat-menu-item-hover-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-hover-state-layer-opacity) * 100%), transparent));
}
.mat-mdc-menu-item:not([disabled]).cdk-program-focused, .mat-mdc-menu-item:not([disabled]).cdk-keyboard-focused, .mat-mdc-menu-item:not([disabled]).mat-mdc-menu-item-highlighted {
  background-color: var(--mat-menu-item-focus-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-focus-state-layer-opacity) * 100%), transparent));
}
@media (forced-colors: active) {
  .mat-mdc-menu-item {
    margin-top: 1px;
  }
}

.mat-mdc-menu-submenu-icon {
  width: var(--mat-menu-item-icon-size, 24px);
  height: 10px;
  fill: currentColor;
  padding-left: var(--mat-menu-item-spacing, 12px);
}
[dir=rtl] .mat-mdc-menu-submenu-icon {
  padding-right: var(--mat-menu-item-spacing, 12px);
  padding-left: 0;
}
[dir=rtl] .mat-mdc-menu-submenu-icon polygon {
  transform: scaleX(-1);
  transform-origin: center;
}
@media (forced-colors: active) {
  .mat-mdc-menu-submenu-icon {
    fill: CanvasText;
  }
}

.mat-mdc-menu-item .mat-mdc-menu-ripple {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  pointer-events: none;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(m,[{type:e.Component,args:[{selector:"mat-menu",changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,exportAs:"matMenu",host:{"[attr.aria-label]":"null","[attr.aria-labelledby]":"null","[attr.aria-describedby]":"null"},providers:[{provide:M,useExisting:m}],template:`<ng-template>
  <div
    class="mat-mdc-menu-panel"
    [id]="panelId"
    [class]="_classList"
    [class.mat-menu-panel-animations-disabled]="_animationsDisabled"
    [class.mat-menu-panel-exit-animation]="_panelAnimationState === 'void'"
    [class.mat-menu-panel-animating]="_isAnimating()"
    (click)="closed.emit('click')"
    tabindex="-1"
    role="menu"
    (animationstart)="_onAnimationStart($event.animationName)"
    (animationend)="_onAnimationDone($event.animationName)"
    (animationcancel)="_onAnimationDone($event.animationName)"
    [attr.aria-label]="ariaLabel || null"
    [attr.aria-labelledby]="ariaLabelledby || null"
    [attr.aria-describedby]="ariaDescribedby || null">
    <div class="mat-mdc-menu-content">
      <ng-content></ng-content>
    </div>
  </div>
</ng-template>
`,styles:[`mat-menu {
  display: none;
}

.mat-mdc-menu-content {
  margin: 0;
  padding: 8px 0;
  outline: 0;
}
.mat-mdc-menu-content,
.mat-mdc-menu-content .mat-mdc-menu-item .mat-mdc-menu-item-text {
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  flex: 1;
  white-space: normal;
  font-family: var(--mat-menu-item-label-text-font, var(--mat-sys-label-large-font));
  line-height: var(--mat-menu-item-label-text-line-height, var(--mat-sys-label-large-line-height));
  font-size: var(--mat-menu-item-label-text-size, var(--mat-sys-label-large-size));
  letter-spacing: var(--mat-menu-item-label-text-tracking, var(--mat-sys-label-large-tracking));
  font-weight: var(--mat-menu-item-label-text-weight, var(--mat-sys-label-large-weight));
}

@keyframes _mat-menu-enter {
  from {
    opacity: 0;
    transform: scale(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-menu-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-mdc-menu-panel {
  min-width: 112px;
  max-width: 280px;
  overflow: auto;
  box-sizing: border-box;
  outline: 0;
  animation: _mat-menu-enter 120ms cubic-bezier(0, 0, 0.2, 1);
  border-radius: var(--mat-menu-container-shape, var(--mat-sys-corner-extra-small));
  background-color: var(--mat-menu-container-color, var(--mat-sys-surface-container));
  box-shadow: var(--mat-menu-container-elevation-shadow, 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12));
  will-change: transform, opacity;
}
.mat-mdc-menu-panel.mat-menu-panel-exit-animation {
  animation: _mat-menu-exit 100ms 25ms linear forwards;
}
.mat-mdc-menu-panel.mat-menu-panel-animations-disabled {
  animation: none;
}
.mat-mdc-menu-panel.mat-menu-panel-animating {
  pointer-events: none;
}
.mat-mdc-menu-panel.mat-menu-panel-animating:has(.mat-mdc-menu-content:empty) {
  display: none;
}
@media (forced-colors: active) {
  .mat-mdc-menu-panel {
    outline: solid 1px;
  }
}
.mat-mdc-menu-panel .mat-divider {
  border-top-color: var(--mat-menu-divider-color, var(--mat-sys-surface-variant));
  margin-bottom: var(--mat-menu-divider-bottom-spacing, 8px);
  margin-top: var(--mat-menu-divider-top-spacing, 8px);
}

.mat-mdc-menu-item {
  display: flex;
  position: relative;
  align-items: center;
  justify-content: flex-start;
  overflow: hidden;
  padding: 0;
  cursor: pointer;
  width: 100%;
  text-align: left;
  box-sizing: border-box;
  color: inherit;
  font-size: inherit;
  background: none;
  text-decoration: none;
  margin: 0;
  min-height: 48px;
  padding-left: var(--mat-menu-item-leading-spacing, 12px);
  padding-right: var(--mat-menu-item-trailing-spacing, 12px);
  -webkit-user-select: none;
  user-select: none;
  cursor: pointer;
  outline: none;
  border: none;
  -webkit-tap-highlight-color: transparent;
}
.mat-mdc-menu-item::-moz-focus-inner {
  border: 0;
}
[dir=rtl] .mat-mdc-menu-item {
  padding-left: var(--mat-menu-item-trailing-spacing, 12px);
  padding-right: var(--mat-menu-item-leading-spacing, 12px);
}
.mat-mdc-menu-item:has(.material-icons, mat-icon, [matButtonIcon]) {
  padding-left: var(--mat-menu-item-with-icon-leading-spacing, 12px);
  padding-right: var(--mat-menu-item-with-icon-trailing-spacing, 12px);
}
[dir=rtl] .mat-mdc-menu-item:has(.material-icons, mat-icon, [matButtonIcon]) {
  padding-left: var(--mat-menu-item-with-icon-trailing-spacing, 12px);
  padding-right: var(--mat-menu-item-with-icon-leading-spacing, 12px);
}
.mat-mdc-menu-item, .mat-mdc-menu-item:visited, .mat-mdc-menu-item:link {
  color: var(--mat-menu-item-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-menu-item .mat-icon-no-color,
.mat-mdc-menu-item .mat-mdc-menu-submenu-icon {
  color: var(--mat-menu-item-icon-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-menu-item[disabled] {
  cursor: default;
  opacity: 0.38;
}
.mat-mdc-menu-item[disabled]::after {
  display: block;
  position: absolute;
  content: "";
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
}
.mat-mdc-menu-item:focus {
  outline: 0;
}
.mat-mdc-menu-item .mat-icon {
  flex-shrink: 0;
  margin-right: var(--mat-menu-item-spacing, 12px);
  height: var(--mat-menu-item-icon-size, 24px);
  width: var(--mat-menu-item-icon-size, 24px);
}
[dir=rtl] .mat-mdc-menu-item {
  text-align: right;
}
[dir=rtl] .mat-mdc-menu-item .mat-icon {
  margin-right: 0;
  margin-left: var(--mat-menu-item-spacing, 12px);
}
.mat-mdc-menu-item:not([disabled]):hover {
  background-color: var(--mat-menu-item-hover-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-hover-state-layer-opacity) * 100%), transparent));
}
.mat-mdc-menu-item:not([disabled]).cdk-program-focused, .mat-mdc-menu-item:not([disabled]).cdk-keyboard-focused, .mat-mdc-menu-item:not([disabled]).mat-mdc-menu-item-highlighted {
  background-color: var(--mat-menu-item-focus-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-focus-state-layer-opacity) * 100%), transparent));
}
@media (forced-colors: active) {
  .mat-mdc-menu-item {
    margin-top: 1px;
  }
}

.mat-mdc-menu-submenu-icon {
  width: var(--mat-menu-item-icon-size, 24px);
  height: 10px;
  fill: currentColor;
  padding-left: var(--mat-menu-item-spacing, 12px);
}
[dir=rtl] .mat-mdc-menu-submenu-icon {
  padding-right: var(--mat-menu-item-spacing, 12px);
  padding-left: 0;
}
[dir=rtl] .mat-mdc-menu-submenu-icon polygon {
  transform: scaleX(-1);
  transform-origin: center;
}
@media (forced-colors: active) {
  .mat-mdc-menu-submenu-icon {
    fill: CanvasText;
  }
}

.mat-mdc-menu-item .mat-mdc-menu-ripple {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  pointer-events: none;
}
`]}]}],()=>[],{_allItems:[{type:e.ContentChildren,args:[c,{descendants:!0}]}],backdropClass:[{type:e.Input}],ariaLabel:[{type:e.Input,args:["aria-label"]}],ariaLabelledby:[{type:e.Input,args:["aria-labelledby"]}],ariaDescribedby:[{type:e.Input,args:["aria-describedby"]}],xPosition:[{type:e.Input}],yPosition:[{type:e.Input}],templateRef:[{type:e.ViewChild,args:[e.TemplateRef]}],items:[{type:e.ContentChildren,args:[c,{descendants:!1}]}],lazyContent:[{type:e.ContentChild,args:[x]}],overlapTrigger:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],hasBackdrop:[{type:e.Input,args:[{transform:g=>g==null?null:(0,e.booleanAttribute)(g)}]}],panelClass:[{type:e.Input,args:["class"]}],classList:[{type:e.Input}],closed:[{type:e.Output}],close:[{type:e.Output}]});const W=new e.InjectionToken("mat-menu-scroll-strategy",{providedIn:"root",factory:()=>{const g=(0,e.inject)(e.Injector);return()=>(0,_.createRepositionScrollStrategy)(g)}}),ee=8,y=new WeakMap;class C{_canHaveBackdrop;_element=(0,e.inject)(e.ElementRef);_viewContainerRef=(0,e.inject)(e.ViewContainerRef);_menuItemInstance=(0,e.inject)(c,{optional:!0,self:!0});_dir=(0,e.inject)(k.Directionality,{optional:!0});_focusMonitor=(0,e.inject)(l.FocusMonitor);_ngZone=(0,e.inject)(e.NgZone);_injector=(0,e.inject)(e.Injector);_scrollStrategy=(0,e.inject)(W);_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_animationsDisabled=(0,B.Rc)();_portal;_overlayRef=null;_menuOpen=!1;_closingActionsSubscription=r.Subscription.EMPTY;_menuCloseSubscription=r.Subscription.EMPTY;_pendingRemoval;_parentMaterialMenu;_parentInnerPadding;_openedBy=void 0;get _menu(){return this._menuInternal}set _menu(t){t!==this._menuInternal&&(this._menuInternal=t,this._menuCloseSubscription.unsubscribe(),t&&(t===this._parentMaterialMenu&&(typeof ngDevMode>"u"||ngDevMode)&&q(),this._menuCloseSubscription=t.close.subscribe(n=>{this._destroyMenu(n),(n==="click"||n==="tab")&&this._parentMaterialMenu&&this._parentMaterialMenu.closed.emit(n)})),this._menuItemInstance?._setTriggersSubmenu(this._triggersSubmenu()))}_menuInternal=null;constructor(t){this._canHaveBackdrop=t;const n=(0,e.inject)(M,{optional:!0});this._parentMaterialMenu=n instanceof m?n:void 0}ngOnDestroy(){this._menu&&this._ownsMenu(this._menu)&&y.delete(this._menu),this._pendingRemoval?.unsubscribe(),this._menuCloseSubscription.unsubscribe(),this._closingActionsSubscription.unsubscribe(),this._overlayRef&&(this._overlayRef.dispose(),this._overlayRef=null)}get menuOpen(){return this._menuOpen}get dir(){return this._dir&&this._dir.value==="rtl"?"rtl":"ltr"}_triggersSubmenu(){return!!(this._menuItemInstance&&this._parentMaterialMenu&&this._menu)}_closeMenu(){this._menu?.close.emit()}_openMenu(t){if(this._triggerIsAriaDisabled())return;const n=this._menu;if(this._menuOpen||!n)return;this._pendingRemoval?.unsubscribe();const i=y.get(n);y.set(n,this),i&&i!==this&&i._closeMenu();const a=this._createOverlay(n),o=a.getConfig(),h=o.positionStrategy;this._setPosition(n,h),this._canHaveBackdrop?o.hasBackdrop=n.hasBackdrop==null?!this._triggersSubmenu():n.hasBackdrop:o.hasBackdrop=n.hasBackdrop??!1,a.hasAttached()||(a.attach(this._getPortal(n)),n.lazyContent?.attach(this.menuData)),this._closingActionsSubscription=this._menuClosingActions().subscribe(()=>this._closeMenu()),n.parentMenu=this._triggersSubmenu()?this._parentMaterialMenu:void 0,n.direction=this.dir,t&&n.focusFirstItem(this._openedBy||"program"),this._setIsMenuOpen(!0),n instanceof m&&(n._setIsOpen(!0),n._directDescendantItems.changes.pipe((0,d.takeUntil)(n.close)).subscribe(()=>{h.withLockedPosition(!1).reapplyLastPosition(),h.withLockedPosition(!0)}))}focus(t,n){this._focusMonitor&&t?this._focusMonitor.focusVia(this._element,t,n):this._element.nativeElement.focus(n)}_destroyMenu(t){const n=this._overlayRef,i=this._menu;!n||!this.menuOpen||(this._closingActionsSubscription.unsubscribe(),this._pendingRemoval?.unsubscribe(),i instanceof m&&this._ownsMenu(i)?(this._pendingRemoval=i._animationDone.pipe((0,d.take)(1)).subscribe(()=>{n.detach(),y.has(i)||i.lazyContent?.detach()}),i._setIsOpen(!1)):(n.detach(),i?.lazyContent?.detach()),i&&this._ownsMenu(i)&&y.delete(i),this.restoreFocus&&(t==="keydown"||!this._openedBy||!this._triggersSubmenu())&&this.focus(this._openedBy),this._openedBy=void 0,this._setIsMenuOpen(!1))}_setIsMenuOpen(t){t!==this._menuOpen&&(this._menuOpen=t,this._menuOpen?this.menuOpened.emit():this.menuClosed.emit(),this._triggersSubmenu()&&this._menuItemInstance._setHighlighted(t),this._changeDetectorRef.markForCheck())}_createOverlay(t){if(!this._overlayRef){const n=this._getOverlayConfig(t);this._subscribeToPositions(t,n.positionStrategy),this._overlayRef=(0,_.createOverlayRef)(this._injector,n),this._overlayRef.keydownEvents().subscribe(i=>{this._menu instanceof m&&this._menu._handleKeydown(i)})}return this._overlayRef}_getOverlayConfig(t){return new _.OverlayConfig({positionStrategy:(0,_.createFlexibleConnectedPositionStrategy)(this._injector,this._getOverlayOrigin()).withLockedPosition().withGrowAfterOpen().withTransformOriginOn(".mat-menu-panel, .mat-mdc-menu-panel"),backdropClass:t.backdropClass||"cdk-overlay-transparent-backdrop",panelClass:t.overlayPanelClass,scrollStrategy:this._scrollStrategy(),direction:this._dir||"ltr",disableAnimations:this._animationsDisabled})}_subscribeToPositions(t,n){t.setPositionClasses&&n.positionChanges.subscribe(i=>{this._ngZone.run(()=>{const a=i.connectionPair.overlayX==="start"?"after":"before",o=i.connectionPair.overlayY==="top"?"below":"above";t.setPositionClasses(a,o)})})}_setPosition(t,n){let[i,a]=t.xPosition==="before"?["end","start"]:["start","end"],[o,h]=t.yPosition==="above"?["bottom","top"]:["top","bottom"],[O,w]=[o,h],[A,S]=[i,a],I=0;if(this._triggersSubmenu()){if(S=i=t.xPosition==="before"?"start":"end",a=A=i==="end"?"start":"end",this._parentMaterialMenu){if(this._parentInnerPadding==null){const H=this._parentMaterialMenu.items.first;this._parentInnerPadding=H?H._getHostElement().offsetTop:0}I=o==="bottom"?this._parentInnerPadding:-this._parentInnerPadding}}else t.overlapTrigger||(O=o==="top"?"bottom":"top",w=h==="top"?"bottom":"top");n.withPositions([{originX:i,originY:O,overlayX:A,overlayY:o,offsetY:I},{originX:a,originY:O,overlayX:S,overlayY:o,offsetY:I},{originX:i,originY:w,overlayX:A,overlayY:h,offsetY:-I},{originX:a,originY:w,overlayX:S,overlayY:h,offsetY:-I}])}_menuClosingActions(){const t=this._getOutsideClickStream(this._overlayRef),n=this._overlayRef.detachments(),i=this._parentMaterialMenu?this._parentMaterialMenu.closed:(0,r.of)(),a=this._parentMaterialMenu?this._parentMaterialMenu._hovered().pipe((0,d.filter)(o=>this._menuOpen&&o!==this._menuItemInstance)):(0,r.of)();return(0,r.merge)(t,i,a,n)}_getPortal(t){return(!this._portal||this._portal.templateRef!==t.templateRef)&&(this._portal=new v.TemplatePortal(t.templateRef,this._viewContainerRef)),this._portal}_ownsMenu(t){return y.get(t)===this}_triggerIsAriaDisabled(){return(0,e.booleanAttribute)(this._element.nativeElement.getAttribute("aria-disabled"))}static \u0275fac=function(n){e.\u0275\u0275invalidFactory()};static \u0275dir=e.\u0275\u0275defineDirective({type:C})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(C,[{type:e.Directive}],()=>[{type:void 0}],null);class f extends C{_cleanupTouchstart;_hoverSubscription=r.Subscription.EMPTY;get _deprecatedMatMenuTriggerFor(){return this.menu}set _deprecatedMatMenuTriggerFor(t){this.menu=t}get menu(){return this._menu}set menu(t){this._menu=t}menuData;restoreFocus=!0;menuOpened=new e.EventEmitter;onMenuOpen=this.menuOpened;menuClosed=new e.EventEmitter;onMenuClose=this.menuClosed;constructor(){super(!0);const t=(0,e.inject)(e.Renderer2);this._cleanupTouchstart=t.listen(this._element.nativeElement,"touchstart",n=>{(0,l.isFakeTouchstartFromScreenReader)(n)||(this._openedBy="touch")},{passive:!0})}triggersSubmenu(){return super._triggersSubmenu()}toggleMenu(){return this.menuOpen?this.closeMenu():this.openMenu()}openMenu(){this._openMenu(!0)}closeMenu(){this._closeMenu()}updatePosition(){this._overlayRef?.updatePosition()}ngAfterContentInit(){this._handleHover()}ngOnDestroy(){super.ngOnDestroy(),this._cleanupTouchstart(),this._hoverSubscription.unsubscribe()}_getOverlayOrigin(){return this._element}_getOutsideClickStream(t){return t.backdropClick()}_handleMousedown(t){(0,l.isFakeMousedownFromScreenReader)(t)||(this._openedBy=t.button===0?"mouse":void 0,this.triggersSubmenu()&&t.preventDefault())}_handleKeydown(t){const n=t.keyCode;(n===u.ENTER||n===u.SPACE)&&(this._openedBy="keyboard"),this.triggersSubmenu()&&(n===u.RIGHT_ARROW&&this.dir==="ltr"||n===u.LEFT_ARROW&&this.dir==="rtl")&&(this._openedBy="keyboard",this.openMenu())}_handleClick(t){this.triggersSubmenu()?(t.stopPropagation(),this.openMenu()):this.toggleMenu()}_handleHover(){this.triggersSubmenu()&&this._parentMaterialMenu&&(this._hoverSubscription=this._parentMaterialMenu._hovered().subscribe(t=>{t===this._menuItemInstance&&!t.disabled&&this._parentMaterialMenu?._panelAnimationState!=="void"&&(this._openedBy="mouse",this._openMenu(!1))}))}static \u0275fac=function(n){return new(n||f)};static \u0275dir=e.\u0275\u0275defineDirective({type:f,selectors:[["","mat-menu-trigger-for",""],["","matMenuTriggerFor",""]],hostAttrs:[1,"mat-mdc-menu-trigger"],hostVars:3,hostBindings:function(n,i){n&1&&e.\u0275\u0275listener("click",function(o){return i._handleClick(o)})("mousedown",function(o){return i._handleMousedown(o)})("keydown",function(o){return i._handleKeydown(o)}),n&2&&e.\u0275\u0275attribute("aria-haspopup",i.menu?"menu":null)("aria-expanded",i.menuOpen)("aria-controls",i.menuOpen?i.menu==null?null:i.menu.panelId:null)},inputs:{_deprecatedMatMenuTriggerFor:[0,"mat-menu-trigger-for","_deprecatedMatMenuTriggerFor"],menu:[0,"matMenuTriggerFor","menu"],menuData:[0,"matMenuTriggerData","menuData"],restoreFocus:[0,"matMenuTriggerRestoreFocus","restoreFocus"]},outputs:{menuOpened:"menuOpened",onMenuOpen:"onMenuOpen",menuClosed:"menuClosed",onMenuClose:"onMenuClose"},exportAs:["matMenuTrigger"],features:[e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(f,[{type:e.Directive,args:[{selector:"[mat-menu-trigger-for], [matMenuTriggerFor]",host:{class:"mat-mdc-menu-trigger","[attr.aria-haspopup]":'menu ? "menu" : null',"[attr.aria-expanded]":"menuOpen","[attr.aria-controls]":"menuOpen ? menu?.panelId : null","(click)":"_handleClick($event)","(mousedown)":"_handleMousedown($event)","(keydown)":"_handleKeydown($event)"},exportAs:"matMenuTrigger"}]}],()=>[],{_deprecatedMatMenuTriggerFor:[{type:e.Input,args:["mat-menu-trigger-for"]}],menu:[{type:e.Input,args:["matMenuTriggerFor"]}],menuData:[{type:e.Input,args:["matMenuTriggerData"]}],restoreFocus:[{type:e.Input,args:["matMenuTriggerRestoreFocus"]}],menuOpened:[{type:e.Output}],onMenuOpen:[{type:e.Output}],menuClosed:[{type:e.Output}],onMenuClose:[{type:e.Output}]});class b extends C{_point={x:0,y:0,initialX:0,initialY:0,initialScrollX:0,initialScrollY:0};_triggerPressedControl=!1;_rootNode;_document=(0,e.inject)(e.DOCUMENT);_viewportRuler=(0,e.inject)(_.ViewportRuler);_scrollDispatcher=(0,e.inject)(_.ScrollDispatcher);_scrollSubscription;get menu(){return this._menu}set menu(t){this._menu=t}menuData;restoreFocus=!0;disabled=!1;menuOpened=new e.EventEmitter;menuClosed=new e.EventEmitter;constructor(){super(!1)}ngOnDestroy(){super.ngOnDestroy(),this._scrollSubscription?.unsubscribe()}_handleContextMenuEvent(t){this.disabled||(t.preventDefault(),this.menuOpen?(this._initializePoint(t.clientX,t.clientY),this._updatePosition()):this._openContextMenu(t))}_destroyMenu(t){super._destroyMenu(t),this._scrollSubscription?.unsubscribe()}_getOverlayOrigin(){return this._point}_getOutsideClickStream(t){return t.outsidePointerEvents().pipe((0,d.skipWhile)((n,i)=>n.type==="contextmenu"?this._isWithinMenuOrTrigger((0,j._getEventTarget)(n)):n.type==="auxclick"?i===0?!0:(this._rootNode??=(0,j._getShadowRoot)(this._element.nativeElement)||this._document,this._isWithinMenuOrTrigger(this._rootNode.elementFromPoint(n.clientX,n.clientY))):this._triggerPressedControl&&i===0&&n.ctrlKey))}_isWithinMenuOrTrigger(t){if(!t)return!1;const n=this._element.nativeElement;if(t===n||n.contains(t))return!0;const i=this._overlayRef?.hostElement;return i===t||!!i?.contains(t)}_openContextMenu(t){t.button===2?this._openedBy="mouse":this._openedBy=t.button===0?"keyboard":void 0,this._initializePoint(t.clientX,t.clientY),this._triggerPressedControl=t.ctrlKey,super._openMenu(!0),this._scrollSubscription?.unsubscribe(),this._scrollSubscription=this._scrollDispatcher.scrolled(0).subscribe(()=>{const n=this._viewportRuler.getViewportScrollPosition(),i=this._point;i.y=i.initialY+(i.initialScrollY-n.top),i.x=i.initialX+(i.initialScrollX-n.left),this._updatePosition()})}_initializePoint(t,n){const i=this._viewportRuler.getViewportScrollPosition(),a=this._point;a.x=a.initialX=t,a.y=a.initialY=n,a.initialScrollX=i.left,a.initialScrollY=i.top}_updatePosition(){const t=this._overlayRef;t&&(t.getConfig().positionStrategy.setOrigin(this._point),t.updatePosition())}static \u0275fac=function(n){return new(n||b)};static \u0275dir=e.\u0275\u0275defineDirective({type:b,selectors:[["","matContextMenuTriggerFor",""]],hostAttrs:[1,"mat-context-menu-trigger"],hostVars:3,hostBindings:function(n,i){n&1&&e.\u0275\u0275listener("contextmenu",function(o){return i._handleContextMenuEvent(o)}),n&2&&(e.\u0275\u0275attribute("aria-controls",i.menuOpen?i.menu==null?null:i.menu.panelId:null),e.\u0275\u0275classProp("mat-context-menu-trigger-disabled",i.disabled))},inputs:{menu:[0,"matContextMenuTriggerFor","menu"],menuData:[0,"matContextMenuTriggerData","menuData"],restoreFocus:[0,"matContextMenuTriggerRestoreFocus","restoreFocus"],disabled:[2,"matContextMenuTriggerDisabled","disabled",e.booleanAttribute]},outputs:{menuOpened:"menuOpened",menuClosed:"menuClosed"},exportAs:["matContextMenuTrigger"],features:[e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(b,[{type:e.Directive,args:[{selector:"[matContextMenuTriggerFor]",host:{class:"mat-context-menu-trigger","[class.mat-context-menu-trigger-disabled]":"disabled","[attr.aria-controls]":"menuOpen ? menu?.panelId : null","(contextmenu)":"_handleContextMenuEvent($event)"},exportAs:"matContextMenuTrigger"}]}],()=>[],{menu:[{type:e.Input,args:[{alias:"matContextMenuTriggerFor",required:!0}]}],menuData:[{type:e.Input,args:["matContextMenuTriggerData"]}],restoreFocus:[{type:e.Input,args:["matContextMenuTriggerRestoreFocus"]}],disabled:[{type:e.Input,args:[{alias:"matContextMenuTriggerDisabled",transform:e.booleanAttribute}]}],menuOpened:[{type:e.Output}],menuClosed:[{type:e.Output}]});class D{static \u0275fac=function(n){return new(n||D)};static \u0275mod=e.\u0275\u0275defineNgModule({type:D});static \u0275inj=e.\u0275\u0275defineInjector({imports:[N.p,_.OverlayModule,k.BidiModule,L.CdkScrollableModule]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(D,[{type:e.NgModule,args:[{imports:[N.p,_.OverlayModule,m,c,p,f,b],exports:[k.BidiModule,L.CdkScrollableModule,m,c,p,f,b]}]}],null,null)}}]);
