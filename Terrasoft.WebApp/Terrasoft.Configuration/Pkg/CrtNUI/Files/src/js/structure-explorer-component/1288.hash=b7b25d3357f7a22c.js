(self.webpackChunkapp_studio_enterprise_structure_explorer=self.webpackChunkapp_studio_enterprise_structure_explorer||[]).push([[1288],{34630(D,_,i){i.d(_,{Rc:()=>x,Sx:()=>w,_J:()=>c});var n=i(15047),o=i(39638);const w=new o.InjectionToken("MATERIAL_ANIMATIONS");let d=null;function c(){return(0,o.inject)(w,{optional:!0})?.animationsDisabled||(0,o.inject)(o.ANIMATION_MODULE_TYPE,{optional:!0})==="NoopAnimations"?"di-disabled":(d??=(0,o.inject)(n.MediaMatcher).matchMedia("(prefers-reduced-motion)").matches,d?"reduced-motion":"enabled")}function x(){return c()!=="enabled"}},30184(D,_,i){i.d(_,{A:()=>o});var n=i(39638);class o{static \u0275fac=function(c){return new(c||o)};static \u0275cmp=n.\u0275\u0275defineComponent({type:o,selectors:[["structural-styles"]],decls:0,vars:0,template:function(c,x){},styles:[`.mat-focus-indicator {
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
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(o,[{type:n.Component,args:[{selector:"structural-styles",encapsulation:n.ViewEncapsulation.None,template:"",changeDetection:n.ChangeDetectionStrategy.OnPush,styles:[`.mat-focus-indicator {
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
`]}]}],null,null)},71288(D,_,i){i.r(_),i.d(_,{MAT_ACCORDION:()=>v,MAT_EXPANSION_PANEL:()=>M,MAT_EXPANSION_PANEL_DEFAULT_OPTIONS:()=>C,MatAccordion:()=>l,MatExpansionModule:()=>y,MatExpansionPanel:()=>p,MatExpansionPanelActionRow:()=>u,MatExpansionPanelContent:()=>m,MatExpansionPanelDescription:()=>f,MatExpansionPanelHeader:()=>g,MatExpansionPanelTitle:()=>b});var n=i(39638),o=i(76217),w=i(41407),d=i(34883),c=i(60447),x=i(88632),h=i(24884),T=i(34630),P=i(88783),I=i(4295),O=i(30184),A=i(90459),B=i(15047);const k=["body"],H=["bodyWrapper"],j=[[["mat-expansion-panel-header"]],"*",[["mat-action-row"]]],R=["mat-expansion-panel-header","*","mat-action-row"];function N(E,e){}const S=[[["mat-panel-title"]],[["mat-panel-description"]],"*"],z=["mat-panel-title","mat-panel-description","*"];function L(E,e){E&1&&(n.\u0275\u0275domElementStart(0,"span",1),n.\u0275\u0275namespaceSVG(),n.\u0275\u0275domElementStart(1,"svg",2),n.\u0275\u0275domElement(2,"path",3),n.\u0275\u0275domElementEnd()())}const v=new n.InjectionToken("MAT_ACCORDION"),M=new n.InjectionToken("MAT_EXPANSION_PANEL");class m{_template=(0,n.inject)(n.TemplateRef);_expansionPanel=(0,n.inject)(M,{optional:!0});constructor(){}static \u0275fac=function(a){return new(a||m)};static \u0275dir=n.\u0275\u0275defineDirective({type:m,selectors:[["ng-template","matExpansionPanelContent",""]]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(m,[{type:n.Directive,args:[{selector:"ng-template[matExpansionPanelContent]"}]}],()=>[],null);const C=new n.InjectionToken("MAT_EXPANSION_PANEL_DEFAULT_OPTIONS");class p extends o.CdkAccordionItem{_viewContainerRef=(0,n.inject)(n.ViewContainerRef);_animationsDisabled=(0,T.Rc)();_document=(0,n.inject)(n.DOCUMENT);_ngZone=(0,n.inject)(n.NgZone);_elementRef=(0,n.inject)(n.ElementRef);_renderer=(0,n.inject)(n.Renderer2);_cleanupTransitionEnd;get hideToggle(){return this._hideToggle||this.accordion&&this.accordion.hideToggle}set hideToggle(e){this._hideToggle=e}_hideToggle=!1;get togglePosition(){return this._togglePosition||this.accordion&&this.accordion.togglePosition}set togglePosition(e){this._togglePosition=e}_togglePosition;afterExpand=new n.EventEmitter;afterCollapse=new n.EventEmitter;_inputChanges=new x.Subject;accordion=(0,n.inject)(v,{optional:!0,skipSelf:!0});_lazyContent;_body;_bodyWrapper;_portal;_headerId=(0,n.inject)(c._IdGenerator).getId("mat-expansion-panel-header-");constructor(){super();const e=(0,n.inject)(C,{optional:!0});this._expansionDispatcher=(0,n.inject)(w.UniqueSelectionDispatcher),e&&(this.hideToggle=e.hideToggle)}_hasSpacing(){return this.accordion?this.expanded&&this.accordion.displayMode==="default":!1}_getExpandedState(){return this.expanded?"expanded":"collapsed"}toggle(){this.expanded=!this.expanded}close(){this.expanded=!1}open(){this.expanded=!0}ngAfterContentInit(){this._lazyContent&&this._lazyContent._expansionPanel===this&&this.opened.pipe((0,h.startWith)(null),(0,h.filter)(()=>this.expanded&&!this._portal),(0,h.take)(1)).subscribe(()=>{this._portal=new d.TemplatePortal(this._lazyContent._template,this._viewContainerRef)}),this._setupAnimationEvents()}ngOnChanges(e){this._inputChanges.next(e)}ngOnDestroy(){super.ngOnDestroy(),this._cleanupTransitionEnd?.(),this._inputChanges.complete()}_containsFocus(){if(this._body){const e=this._document.activeElement,a=this._body.nativeElement;return e===a||a.contains(e)}return!1}_transitionEndListener=({target:e,propertyName:a})=>{e===this._bodyWrapper?.nativeElement&&a==="grid-template-rows"&&this._ngZone.run(()=>{this.expanded?this.afterExpand.emit():this.afterCollapse.emit()})};_setupAnimationEvents(){this._ngZone.runOutsideAngular(()=>{this._animationsDisabled?(this.opened.subscribe(()=>this._ngZone.run(()=>this.afterExpand.emit())),this.closed.subscribe(()=>this._ngZone.run(()=>this.afterCollapse.emit()))):setTimeout(()=>{const e=this._elementRef.nativeElement;this._cleanupTransitionEnd=this._renderer.listen(e,"transitionend",this._transitionEndListener),e.classList.add("mat-expansion-panel-animations-enabled")},200)})}static \u0275fac=function(a){return new(a||p)};static \u0275cmp=n.\u0275\u0275defineComponent({type:p,selectors:[["mat-expansion-panel"]],contentQueries:function(a,t,s){if(a&1&&n.\u0275\u0275contentQuery(s,m,5),a&2){let r;n.\u0275\u0275queryRefresh(r=n.\u0275\u0275loadQuery())&&(t._lazyContent=r.first)}},viewQuery:function(a,t){if(a&1&&n.\u0275\u0275viewQuery(k,5)(H,5),a&2){let s;n.\u0275\u0275queryRefresh(s=n.\u0275\u0275loadQuery())&&(t._body=s.first),n.\u0275\u0275queryRefresh(s=n.\u0275\u0275loadQuery())&&(t._bodyWrapper=s.first)}},hostAttrs:[1,"mat-expansion-panel"],hostVars:4,hostBindings:function(a,t){a&2&&n.\u0275\u0275classProp("mat-expanded",t.expanded)("mat-expansion-panel-spacing",t._hasSpacing())},inputs:{hideToggle:[2,"hideToggle","hideToggle",n.booleanAttribute],togglePosition:"togglePosition"},outputs:{afterExpand:"afterExpand",afterCollapse:"afterCollapse"},exportAs:["matExpansionPanel"],features:[n.\u0275\u0275ProvidersFeature([{provide:v,useValue:void 0},{provide:M,useExisting:p}]),n.\u0275\u0275InheritDefinitionFeature,n.\u0275\u0275NgOnChangesFeature],ngContentSelectors:R,decls:9,vars:4,consts:[["bodyWrapper",""],["body",""],[1,"mat-expansion-panel-content-wrapper"],["role","region",1,"mat-expansion-panel-content",3,"id"],[1,"mat-expansion-panel-body"],[3,"cdkPortalOutlet"]],template:function(a,t){a&1&&(n.\u0275\u0275projectionDef(j),n.\u0275\u0275projection(0),n.\u0275\u0275elementStart(1,"div",2,0)(3,"div",3,1)(5,"div",4),n.\u0275\u0275projection(6,1),n.\u0275\u0275template(7,N,0,0,"ng-template",5),n.\u0275\u0275elementEnd(),n.\u0275\u0275projection(8,2),n.\u0275\u0275elementEnd()()),a&2&&(n.\u0275\u0275advance(),n.\u0275\u0275attribute("inert",t.expanded?null:""),n.\u0275\u0275advance(2),n.\u0275\u0275property("id",t.id),n.\u0275\u0275attribute("aria-labelledby",t._headerId),n.\u0275\u0275advance(4),n.\u0275\u0275property("cdkPortalOutlet",t._portal))},dependencies:[d.CdkPortalOutlet],styles:[`.mat-expansion-panel {
  box-sizing: content-box;
  display: block;
  margin: 0;
  overflow: hidden;
}
.mat-expansion-panel.mat-expansion-panel-animations-enabled {
  transition: margin 225ms cubic-bezier(0.4, 0, 0.2, 1), box-shadow 280ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel {
  position: relative;
  background: var(--mat-expansion-container-background-color, var(--mat-sys-surface));
  color: var(--mat-expansion-container-text-color, var(--mat-sys-on-surface));
  border-radius: var(--mat-expansion-container-shape, 12px);
}
.mat-expansion-panel:not([class*=mat-elevation-z]) {
  box-shadow: var(--mat-expansion-container-elevation-shadow, 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12));
}
.mat-accordion .mat-expansion-panel:not(.mat-expanded), .mat-accordion .mat-expansion-panel:not(.mat-expansion-panel-spacing) {
  border-radius: 0;
}
.mat-accordion .mat-expansion-panel:first-of-type {
  border-top-right-radius: var(--mat-expansion-container-shape, 12px);
  border-top-left-radius: var(--mat-expansion-container-shape, 12px);
}
.mat-accordion .mat-expansion-panel:last-of-type {
  border-bottom-right-radius: var(--mat-expansion-container-shape, 12px);
  border-bottom-left-radius: var(--mat-expansion-container-shape, 12px);
}
@media (forced-colors: active) {
  .mat-expansion-panel {
    outline: solid 1px;
  }
}

.mat-expansion-panel-content-wrapper {
  display: grid;
  grid-template-rows: 0fr;
  grid-template-columns: 100%;
}
.mat-expansion-panel-animations-enabled .mat-expansion-panel-content-wrapper {
  transition: grid-template-rows 225ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper {
  grid-template-rows: 1fr;
}
@supports not (grid-template-rows: 0fr) {
  .mat-expansion-panel-content-wrapper {
    height: 0;
  }
  .mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper {
    height: auto;
  }
}
@media print {
  .mat-expansion-panel-content-wrapper {
    height: 0;
  }
  .mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper {
    height: auto;
  }
}

.mat-expansion-panel-content {
  display: flex;
  flex-direction: column;
  overflow: visible;
  min-height: 0;
  visibility: hidden;
}
.mat-expansion-panel-animations-enabled .mat-expansion-panel-content {
  transition: visibility 190ms linear;
}
.mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper > .mat-expansion-panel-content {
  visibility: visible;
}
.mat-expansion-panel-content {
  font-family: var(--mat-expansion-container-text-font, var(--mat-sys-body-large-font));
  font-size: var(--mat-expansion-container-text-size, var(--mat-sys-body-large-size));
  font-weight: var(--mat-expansion-container-text-weight, var(--mat-sys-body-large-weight));
  line-height: var(--mat-expansion-container-text-line-height, var(--mat-sys-body-large-line-height));
  letter-spacing: var(--mat-expansion-container-text-tracking, var(--mat-sys-body-large-tracking));
}

.mat-expansion-panel-body {
  padding: 0 24px 16px;
}

.mat-expansion-panel-spacing {
  margin: 16px 0;
}
.mat-accordion > .mat-expansion-panel-spacing:first-child, .mat-accordion > *:first-child:not(.mat-expansion-panel) .mat-expansion-panel-spacing {
  margin-top: 0;
}
.mat-accordion > .mat-expansion-panel-spacing:last-child, .mat-accordion > *:last-child:not(.mat-expansion-panel) .mat-expansion-panel-spacing {
  margin-bottom: 0;
}

.mat-action-row {
  border-top-style: solid;
  border-top-width: 1px;
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  padding: 16px 8px 16px 24px;
  border-top-color: var(--mat-expansion-actions-divider-color, var(--mat-sys-outline));
}
.mat-action-row .mat-button-base,
.mat-action-row .mat-mdc-button-base {
  margin-left: 8px;
}
[dir=rtl] .mat-action-row .mat-button-base,
[dir=rtl] .mat-action-row .mat-mdc-button-base {
  margin-left: 0;
  margin-right: 8px;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(p,[{type:n.Component,args:[{selector:"mat-expansion-panel",exportAs:"matExpansionPanel",encapsulation:n.ViewEncapsulation.None,changeDetection:n.ChangeDetectionStrategy.OnPush,providers:[{provide:v,useValue:void 0},{provide:M,useExisting:p}],host:{class:"mat-expansion-panel","[class.mat-expanded]":"expanded","[class.mat-expansion-panel-spacing]":"_hasSpacing()"},imports:[d.CdkPortalOutlet],template:`<ng-content select="mat-expansion-panel-header"></ng-content>
<div class="mat-expansion-panel-content-wrapper" [attr.inert]="expanded ? null : ''" #bodyWrapper>
  <div class="mat-expansion-panel-content"
       role="region"
       [attr.aria-labelledby]="_headerId"
       [id]="id"
       #body>
    <div class="mat-expansion-panel-body">
      <ng-content></ng-content>
      <ng-template [cdkPortalOutlet]="_portal"></ng-template>
    </div>
    <ng-content select="mat-action-row"></ng-content>
  </div>
</div>
`,styles:[`.mat-expansion-panel {
  box-sizing: content-box;
  display: block;
  margin: 0;
  overflow: hidden;
}
.mat-expansion-panel.mat-expansion-panel-animations-enabled {
  transition: margin 225ms cubic-bezier(0.4, 0, 0.2, 1), box-shadow 280ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel {
  position: relative;
  background: var(--mat-expansion-container-background-color, var(--mat-sys-surface));
  color: var(--mat-expansion-container-text-color, var(--mat-sys-on-surface));
  border-radius: var(--mat-expansion-container-shape, 12px);
}
.mat-expansion-panel:not([class*=mat-elevation-z]) {
  box-shadow: var(--mat-expansion-container-elevation-shadow, 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12));
}
.mat-accordion .mat-expansion-panel:not(.mat-expanded), .mat-accordion .mat-expansion-panel:not(.mat-expansion-panel-spacing) {
  border-radius: 0;
}
.mat-accordion .mat-expansion-panel:first-of-type {
  border-top-right-radius: var(--mat-expansion-container-shape, 12px);
  border-top-left-radius: var(--mat-expansion-container-shape, 12px);
}
.mat-accordion .mat-expansion-panel:last-of-type {
  border-bottom-right-radius: var(--mat-expansion-container-shape, 12px);
  border-bottom-left-radius: var(--mat-expansion-container-shape, 12px);
}
@media (forced-colors: active) {
  .mat-expansion-panel {
    outline: solid 1px;
  }
}

.mat-expansion-panel-content-wrapper {
  display: grid;
  grid-template-rows: 0fr;
  grid-template-columns: 100%;
}
.mat-expansion-panel-animations-enabled .mat-expansion-panel-content-wrapper {
  transition: grid-template-rows 225ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper {
  grid-template-rows: 1fr;
}
@supports not (grid-template-rows: 0fr) {
  .mat-expansion-panel-content-wrapper {
    height: 0;
  }
  .mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper {
    height: auto;
  }
}
@media print {
  .mat-expansion-panel-content-wrapper {
    height: 0;
  }
  .mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper {
    height: auto;
  }
}

.mat-expansion-panel-content {
  display: flex;
  flex-direction: column;
  overflow: visible;
  min-height: 0;
  visibility: hidden;
}
.mat-expansion-panel-animations-enabled .mat-expansion-panel-content {
  transition: visibility 190ms linear;
}
.mat-expansion-panel.mat-expanded > .mat-expansion-panel-content-wrapper > .mat-expansion-panel-content {
  visibility: visible;
}
.mat-expansion-panel-content {
  font-family: var(--mat-expansion-container-text-font, var(--mat-sys-body-large-font));
  font-size: var(--mat-expansion-container-text-size, var(--mat-sys-body-large-size));
  font-weight: var(--mat-expansion-container-text-weight, var(--mat-sys-body-large-weight));
  line-height: var(--mat-expansion-container-text-line-height, var(--mat-sys-body-large-line-height));
  letter-spacing: var(--mat-expansion-container-text-tracking, var(--mat-sys-body-large-tracking));
}

.mat-expansion-panel-body {
  padding: 0 24px 16px;
}

.mat-expansion-panel-spacing {
  margin: 16px 0;
}
.mat-accordion > .mat-expansion-panel-spacing:first-child, .mat-accordion > *:first-child:not(.mat-expansion-panel) .mat-expansion-panel-spacing {
  margin-top: 0;
}
.mat-accordion > .mat-expansion-panel-spacing:last-child, .mat-accordion > *:last-child:not(.mat-expansion-panel) .mat-expansion-panel-spacing {
  margin-bottom: 0;
}

.mat-action-row {
  border-top-style: solid;
  border-top-width: 1px;
  display: flex;
  flex-direction: row;
  justify-content: flex-end;
  padding: 16px 8px 16px 24px;
  border-top-color: var(--mat-expansion-actions-divider-color, var(--mat-sys-outline));
}
.mat-action-row .mat-button-base,
.mat-action-row .mat-mdc-button-base {
  margin-left: 8px;
}
[dir=rtl] .mat-action-row .mat-button-base,
[dir=rtl] .mat-action-row .mat-mdc-button-base {
  margin-left: 0;
  margin-right: 8px;
}
`]}]}],()=>[],{hideToggle:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],togglePosition:[{type:n.Input}],afterExpand:[{type:n.Output}],afterCollapse:[{type:n.Output}],_lazyContent:[{type:n.ContentChild,args:[m]}],_body:[{type:n.ViewChild,args:["body"]}],_bodyWrapper:[{type:n.ViewChild,args:["bodyWrapper"]}]});class u{static \u0275fac=function(a){return new(a||u)};static \u0275dir=n.\u0275\u0275defineDirective({type:u,selectors:[["mat-action-row"]],hostAttrs:[1,"mat-action-row"]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(u,[{type:n.Directive,args:[{selector:"mat-action-row",host:{class:"mat-action-row"}}]}],null,null);class g{panel=(0,n.inject)(p,{host:!0});_element=(0,n.inject)(n.ElementRef);_focusMonitor=(0,n.inject)(c.FocusMonitor);_changeDetectorRef=(0,n.inject)(n.ChangeDetectorRef);_parentChangeSubscription=x.Subscription.EMPTY;constructor(){(0,n.inject)(I._CdkPrivateStyleLoader).load(O.A);const e=this.panel,a=(0,n.inject)(C,{optional:!0}),t=(0,n.inject)(new n.HostAttributeToken("tabindex"),{optional:!0}),s=e.accordion?e.accordion._stateChanges.pipe((0,h.filter)(r=>!!(r.hideToggle||r.togglePosition))):x.EMPTY;this.tabIndex=parseInt(t||"")||0,this._parentChangeSubscription=(0,x.merge)(e.opened,e.closed,s,e._inputChanges.pipe((0,h.filter)(r=>!!(r.hideToggle||r.disabled||r.togglePosition)))).subscribe(()=>this._changeDetectorRef.markForCheck()),e.closed.pipe((0,h.filter)(()=>e._containsFocus())).subscribe(()=>this._focusMonitor.focusVia(this._element,"program")),a&&(this.expandedHeight=a.expandedHeight,this.collapsedHeight=a.collapsedHeight)}expandedHeight;collapsedHeight;tabIndex=0;get disabled(){return this.panel.disabled}_toggle(){this.disabled||this.panel.toggle()}_isExpanded(){return this.panel.expanded}_getExpandedState(){return this.panel._getExpandedState()}_getPanelId(){return this.panel.id}_getTogglePosition(){return this.panel.togglePosition}_showToggle(){return!this.panel.hideToggle&&!this.panel.disabled}_getHeaderHeight(){const e=this._isExpanded();return e&&this.expandedHeight?this.expandedHeight:!e&&this.collapsedHeight?this.collapsedHeight:null}_keydown(e){switch(e.keyCode){case P.SPACE:case P.ENTER:(0,P.hasModifierKey)(e)||(e.preventDefault(),this._toggle());break;default:this.panel.accordion&&this.panel.accordion._handleHeaderKeydown(e);return}}focus(e,a){e?this._focusMonitor.focusVia(this._element,e,a):this._element.nativeElement.focus(a)}ngAfterViewInit(){this._focusMonitor.monitor(this._element).subscribe(e=>{e&&this.panel.accordion&&this.panel.accordion._handleHeaderFocus(this)})}ngOnDestroy(){this._parentChangeSubscription.unsubscribe(),this._focusMonitor.stopMonitoring(this._element)}static \u0275fac=function(a){return new(a||g)};static \u0275cmp=n.\u0275\u0275defineComponent({type:g,selectors:[["mat-expansion-panel-header"]],hostAttrs:["role","button",1,"mat-expansion-panel-header","mat-focus-indicator"],hostVars:13,hostBindings:function(a,t){a&1&&n.\u0275\u0275listener("click",function(){return t._toggle()})("keydown",function(r){return t._keydown(r)}),a&2&&(n.\u0275\u0275attribute("id",t.panel._headerId)("tabindex",t.disabled?-1:t.tabIndex)("aria-controls",t._getPanelId())("aria-expanded",t._isExpanded())("aria-disabled",t.panel.disabled),n.\u0275\u0275styleProp("height",t._getHeaderHeight()),n.\u0275\u0275classProp("mat-expanded",t._isExpanded())("mat-expansion-toggle-indicator-after",t._getTogglePosition()==="after")("mat-expansion-toggle-indicator-before",t._getTogglePosition()==="before"))},inputs:{expandedHeight:"expandedHeight",collapsedHeight:"collapsedHeight",tabIndex:[2,"tabIndex","tabIndex",e=>e==null?0:(0,n.numberAttribute)(e)]},ngContentSelectors:z,decls:5,vars:3,consts:[[1,"mat-content"],[1,"mat-expansion-indicator"],["xmlns","http://www.w3.org/2000/svg","viewBox","0 -960 960 960","aria-hidden","true","focusable","false"],["d","M480-345 240-585l56-56 184 184 184-184 56 56-240 240Z"]],template:function(a,t){a&1&&(n.\u0275\u0275projectionDef(S),n.\u0275\u0275domElementStart(0,"span",0),n.\u0275\u0275projection(1),n.\u0275\u0275projection(2,1),n.\u0275\u0275projection(3,2),n.\u0275\u0275domElementEnd(),n.\u0275\u0275conditionalCreate(4,L,3,0,"span",1)),a&2&&(n.\u0275\u0275classProp("mat-content-hide-toggle",!t._showToggle()),n.\u0275\u0275advance(4),n.\u0275\u0275conditional(t._showToggle()?4:-1))},styles:[`.mat-expansion-panel-header {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 0 24px;
  border-radius: inherit;
}
.mat-expansion-panel-animations-enabled .mat-expansion-panel-header {
  transition: height 225ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel-header::before {
  border-radius: inherit;
}
.mat-expansion-panel-header {
  height: var(--mat-expansion-header-collapsed-state-height, 48px);
  font-family: var(--mat-expansion-header-text-font, var(--mat-sys-title-medium-font));
  font-size: var(--mat-expansion-header-text-size, var(--mat-sys-title-medium-size));
  font-weight: var(--mat-expansion-header-text-weight, var(--mat-sys-title-medium-weight));
  line-height: var(--mat-expansion-header-text-line-height, var(--mat-sys-title-medium-line-height));
  letter-spacing: var(--mat-expansion-header-text-tracking, var(--mat-sys-title-medium-tracking));
}
.mat-expansion-panel-header.mat-expanded {
  height: var(--mat-expansion-header-expanded-state-height, 64px);
}
.mat-expansion-panel-header[aria-disabled=true] {
  color: var(--mat-expansion-header-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-expansion-panel-header:not([aria-disabled=true]) {
  cursor: pointer;
}
.mat-expansion-panel:not(.mat-expanded) .mat-expansion-panel-header:not([aria-disabled=true]):hover {
  background: var(--mat-expansion-header-hover-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-hover-state-layer-opacity) * 100%), transparent));
}
@media (hover: none) {
  .mat-expansion-panel:not(.mat-expanded) .mat-expansion-panel-header:not([aria-disabled=true]):hover {
    background: var(--mat-expansion-container-background-color, var(--mat-sys-surface));
  }
}
.mat-expansion-panel .mat-expansion-panel-header:not([aria-disabled=true]).cdk-keyboard-focused, .mat-expansion-panel .mat-expansion-panel-header:not([aria-disabled=true]).cdk-program-focused {
  background: var(--mat-expansion-header-focus-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-focus-state-layer-opacity) * 100%), transparent));
}
.mat-expansion-panel-header._mat-animation-noopable {
  transition: none;
}
.mat-expansion-panel-header:focus, .mat-expansion-panel-header:hover {
  outline: none;
}
.mat-expansion-panel-header.mat-expanded:focus, .mat-expansion-panel-header.mat-expanded:hover {
  background: inherit;
}
.mat-expansion-panel-header.mat-expansion-toggle-indicator-before {
  flex-direction: row-reverse;
}
.mat-expansion-panel-header.mat-expansion-toggle-indicator-before .mat-expansion-indicator {
  margin: 0 16px 0 0;
}
[dir=rtl] .mat-expansion-panel-header.mat-expansion-toggle-indicator-before .mat-expansion-indicator {
  margin: 0 0 0 16px;
}

.mat-content {
  display: flex;
  flex: 1;
  flex-direction: row;
  overflow: hidden;
}
.mat-content.mat-content-hide-toggle {
  margin-right: 8px;
}
[dir=rtl] .mat-content.mat-content-hide-toggle {
  margin-right: 0;
  margin-left: 8px;
}
.mat-expansion-toggle-indicator-before .mat-content.mat-content-hide-toggle {
  margin-left: 24px;
  margin-right: 0;
}
[dir=rtl] .mat-expansion-toggle-indicator-before .mat-content.mat-content-hide-toggle {
  margin-right: 24px;
  margin-left: 0;
}

.mat-expansion-panel-header-title {
  color: var(--mat-expansion-header-text-color, var(--mat-sys-on-surface));
}

.mat-expansion-panel-header-title,
.mat-expansion-panel-header-description {
  display: flex;
  flex-grow: 1;
  flex-basis: 0;
  margin-right: 16px;
  align-items: center;
}
[dir=rtl] .mat-expansion-panel-header-title,
[dir=rtl] .mat-expansion-panel-header-description {
  margin-right: 0;
  margin-left: 16px;
}
.mat-expansion-panel-header[aria-disabled=true] .mat-expansion-panel-header-title,
.mat-expansion-panel-header[aria-disabled=true] .mat-expansion-panel-header-description {
  color: inherit;
}

.mat-expansion-panel-header-description {
  flex-grow: 2;
  color: var(--mat-expansion-header-description-color, var(--mat-sys-on-surface-variant));
}

.mat-expansion-panel-animations-enabled .mat-expansion-indicator {
  transition: transform 225ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel-header.mat-expanded .mat-expansion-indicator {
  transform: rotate(180deg);
}
.mat-expansion-indicator::after {
  border-style: solid;
  border-width: 0 2px 2px 0;
  content: "";
  padding: 3px;
  transform: rotate(45deg);
  vertical-align: middle;
  color: var(--mat-expansion-header-indicator-color, var(--mat-sys-on-surface-variant));
  display: var(--mat-expansion-legacy-header-indicator-display, none);
}
.mat-expansion-indicator svg {
  width: 24px;
  height: 24px;
  margin: 0 -8px;
  vertical-align: middle;
  fill: var(--mat-expansion-header-indicator-color, var(--mat-sys-on-surface-variant));
  display: var(--mat-expansion-header-indicator-display, inline-block);
}

@media (forced-colors: active) {
  .mat-expansion-panel-content {
    border-top: 1px solid;
    border-top-left-radius: 0;
    border-top-right-radius: 0;
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(g,[{type:n.Component,args:[{selector:"mat-expansion-panel-header",encapsulation:n.ViewEncapsulation.None,changeDetection:n.ChangeDetectionStrategy.OnPush,host:{class:"mat-expansion-panel-header mat-focus-indicator",role:"button","[attr.id]":"panel._headerId","[attr.tabindex]":"disabled ? -1 : tabIndex","[attr.aria-controls]":"_getPanelId()","[attr.aria-expanded]":"_isExpanded()","[attr.aria-disabled]":"panel.disabled","[class.mat-expanded]":"_isExpanded()","[class.mat-expansion-toggle-indicator-after]":"_getTogglePosition() === 'after'","[class.mat-expansion-toggle-indicator-before]":"_getTogglePosition() === 'before'","[style.height]":"_getHeaderHeight()","(click)":"_toggle()","(keydown)":"_keydown($event)"},template:`<span class="mat-content" [class.mat-content-hide-toggle]="!_showToggle()">
  <ng-content select="mat-panel-title"></ng-content>
  <ng-content select="mat-panel-description"></ng-content>
  <ng-content></ng-content>
</span>

@if (_showToggle()) {
  <span class="mat-expansion-indicator">
    <svg
      xmlns="http://www.w3.org/2000/svg"
      viewBox="0 -960 960 960"
      aria-hidden="true"
      focusable="false">
      <path d="M480-345 240-585l56-56 184 184 184-184 56 56-240 240Z"/>
    </svg>
  </span>
}
`,styles:[`.mat-expansion-panel-header {
  display: flex;
  flex-direction: row;
  align-items: center;
  padding: 0 24px;
  border-radius: inherit;
}
.mat-expansion-panel-animations-enabled .mat-expansion-panel-header {
  transition: height 225ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel-header::before {
  border-radius: inherit;
}
.mat-expansion-panel-header {
  height: var(--mat-expansion-header-collapsed-state-height, 48px);
  font-family: var(--mat-expansion-header-text-font, var(--mat-sys-title-medium-font));
  font-size: var(--mat-expansion-header-text-size, var(--mat-sys-title-medium-size));
  font-weight: var(--mat-expansion-header-text-weight, var(--mat-sys-title-medium-weight));
  line-height: var(--mat-expansion-header-text-line-height, var(--mat-sys-title-medium-line-height));
  letter-spacing: var(--mat-expansion-header-text-tracking, var(--mat-sys-title-medium-tracking));
}
.mat-expansion-panel-header.mat-expanded {
  height: var(--mat-expansion-header-expanded-state-height, 64px);
}
.mat-expansion-panel-header[aria-disabled=true] {
  color: var(--mat-expansion-header-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-expansion-panel-header:not([aria-disabled=true]) {
  cursor: pointer;
}
.mat-expansion-panel:not(.mat-expanded) .mat-expansion-panel-header:not([aria-disabled=true]):hover {
  background: var(--mat-expansion-header-hover-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-hover-state-layer-opacity) * 100%), transparent));
}
@media (hover: none) {
  .mat-expansion-panel:not(.mat-expanded) .mat-expansion-panel-header:not([aria-disabled=true]):hover {
    background: var(--mat-expansion-container-background-color, var(--mat-sys-surface));
  }
}
.mat-expansion-panel .mat-expansion-panel-header:not([aria-disabled=true]).cdk-keyboard-focused, .mat-expansion-panel .mat-expansion-panel-header:not([aria-disabled=true]).cdk-program-focused {
  background: var(--mat-expansion-header-focus-state-layer-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-focus-state-layer-opacity) * 100%), transparent));
}
.mat-expansion-panel-header._mat-animation-noopable {
  transition: none;
}
.mat-expansion-panel-header:focus, .mat-expansion-panel-header:hover {
  outline: none;
}
.mat-expansion-panel-header.mat-expanded:focus, .mat-expansion-panel-header.mat-expanded:hover {
  background: inherit;
}
.mat-expansion-panel-header.mat-expansion-toggle-indicator-before {
  flex-direction: row-reverse;
}
.mat-expansion-panel-header.mat-expansion-toggle-indicator-before .mat-expansion-indicator {
  margin: 0 16px 0 0;
}
[dir=rtl] .mat-expansion-panel-header.mat-expansion-toggle-indicator-before .mat-expansion-indicator {
  margin: 0 0 0 16px;
}

.mat-content {
  display: flex;
  flex: 1;
  flex-direction: row;
  overflow: hidden;
}
.mat-content.mat-content-hide-toggle {
  margin-right: 8px;
}
[dir=rtl] .mat-content.mat-content-hide-toggle {
  margin-right: 0;
  margin-left: 8px;
}
.mat-expansion-toggle-indicator-before .mat-content.mat-content-hide-toggle {
  margin-left: 24px;
  margin-right: 0;
}
[dir=rtl] .mat-expansion-toggle-indicator-before .mat-content.mat-content-hide-toggle {
  margin-right: 24px;
  margin-left: 0;
}

.mat-expansion-panel-header-title {
  color: var(--mat-expansion-header-text-color, var(--mat-sys-on-surface));
}

.mat-expansion-panel-header-title,
.mat-expansion-panel-header-description {
  display: flex;
  flex-grow: 1;
  flex-basis: 0;
  margin-right: 16px;
  align-items: center;
}
[dir=rtl] .mat-expansion-panel-header-title,
[dir=rtl] .mat-expansion-panel-header-description {
  margin-right: 0;
  margin-left: 16px;
}
.mat-expansion-panel-header[aria-disabled=true] .mat-expansion-panel-header-title,
.mat-expansion-panel-header[aria-disabled=true] .mat-expansion-panel-header-description {
  color: inherit;
}

.mat-expansion-panel-header-description {
  flex-grow: 2;
  color: var(--mat-expansion-header-description-color, var(--mat-sys-on-surface-variant));
}

.mat-expansion-panel-animations-enabled .mat-expansion-indicator {
  transition: transform 225ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-expansion-panel-header.mat-expanded .mat-expansion-indicator {
  transform: rotate(180deg);
}
.mat-expansion-indicator::after {
  border-style: solid;
  border-width: 0 2px 2px 0;
  content: "";
  padding: 3px;
  transform: rotate(45deg);
  vertical-align: middle;
  color: var(--mat-expansion-header-indicator-color, var(--mat-sys-on-surface-variant));
  display: var(--mat-expansion-legacy-header-indicator-display, none);
}
.mat-expansion-indicator svg {
  width: 24px;
  height: 24px;
  margin: 0 -8px;
  vertical-align: middle;
  fill: var(--mat-expansion-header-indicator-color, var(--mat-sys-on-surface-variant));
  display: var(--mat-expansion-header-indicator-display, inline-block);
}

@media (forced-colors: active) {
  .mat-expansion-panel-content {
    border-top: 1px solid;
    border-top-left-radius: 0;
    border-top-right-radius: 0;
  }
}
`]}]}],()=>[],{expandedHeight:[{type:n.Input}],collapsedHeight:[{type:n.Input}],tabIndex:[{type:n.Input,args:[{transform:E=>E==null?0:(0,n.numberAttribute)(E)}]}]});class f{static \u0275fac=function(a){return new(a||f)};static \u0275dir=n.\u0275\u0275defineDirective({type:f,selectors:[["mat-panel-description"]],hostAttrs:[1,"mat-expansion-panel-header-description"]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(f,[{type:n.Directive,args:[{selector:"mat-panel-description",host:{class:"mat-expansion-panel-header-description"}}]}],null,null);class b{static \u0275fac=function(a){return new(a||b)};static \u0275dir=n.\u0275\u0275defineDirective({type:b,selectors:[["mat-panel-title"]],hostAttrs:[1,"mat-expansion-panel-header-title"]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(b,[{type:n.Directive,args:[{selector:"mat-panel-title",host:{class:"mat-expansion-panel-header-title"}}]}],null,null);class l extends o.CdkAccordion{_keyManager;_ownHeaders=new n.QueryList;_headers;hideToggle=!1;displayMode="default";togglePosition="after";ngAfterContentInit(){this._headers.changes.pipe((0,h.startWith)(this._headers)).subscribe(e=>{this._ownHeaders.reset(e.filter(a=>a.panel.accordion===this)),this._ownHeaders.notifyOnChanges()}),this._keyManager=new c.FocusKeyManager(this._ownHeaders).withWrap().withHomeAndEnd()}_handleHeaderKeydown(e){this._keyManager.onKeydown(e)}_handleHeaderFocus(e){this._keyManager.updateActiveItem(e)}ngOnDestroy(){super.ngOnDestroy(),this._keyManager?.destroy(),this._ownHeaders.destroy()}static \u0275fac=(()=>{let e;return function(t){return(e||(e=n.\u0275\u0275getInheritedFactory(l)))(t||l)}})();static \u0275dir=n.\u0275\u0275defineDirective({type:l,selectors:[["mat-accordion"]],contentQueries:function(a,t,s){if(a&1&&n.\u0275\u0275contentQuery(s,g,5),a&2){let r;n.\u0275\u0275queryRefresh(r=n.\u0275\u0275loadQuery())&&(t._headers=r)}},hostAttrs:[1,"mat-accordion"],hostVars:2,hostBindings:function(a,t){a&2&&n.\u0275\u0275classProp("mat-accordion-multi",t.multi)},inputs:{hideToggle:[2,"hideToggle","hideToggle",n.booleanAttribute],displayMode:"displayMode",togglePosition:"togglePosition"},exportAs:["matAccordion"],features:[n.\u0275\u0275ProvidersFeature([{provide:v,useExisting:l}]),n.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(l,[{type:n.Directive,args:[{selector:"mat-accordion",exportAs:"matAccordion",providers:[{provide:v,useExisting:l}],host:{class:"mat-accordion","[class.mat-accordion-multi]":"this.multi"}}]}],null,{_headers:[{type:n.ContentChildren,args:[g,{descendants:!0}]}],hideToggle:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],displayMode:[{type:n.Input}],togglePosition:[{type:n.Input}]});class y{static \u0275fac=function(a){return new(a||y)};static \u0275mod=n.\u0275\u0275defineNgModule({type:y});static \u0275inj=n.\u0275\u0275defineInjector({imports:[o.CdkAccordionModule,d.PortalModule,A.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(y,[{type:n.NgModule,args:[{imports:[o.CdkAccordionModule,d.PortalModule,l,p,u,g,b,f,m],exports:[A.BidiModule,l,p,u,g,b,f,m]}]}],null,null)}}]);
