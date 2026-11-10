(self.webpackChunkapp_studio_enterprise_web_service=self.webpackChunkapp_studio_enterprise_web_service||[]).push([[2161],{52161(vt,V,s){s.r(V),s.d(V,{MAT_TAB:()=>S,MAT_TABS_CONFIG:()=>W,MAT_TAB_CONTENT:()=>F,MAT_TAB_GROUP:()=>O,MAT_TAB_LABEL:()=>N,MatInkBar:()=>z,MatPaginatedTabHeader:()=>C,MatTab:()=>m,MatTabBody:()=>h,MatTabBodyPortal:()=>g,MatTabChangeEvent:()=>tt,MatTabContent:()=>b,MatTabGroup:()=>f,MatTabHeader:()=>y,MatTabLabel:()=>c,MatTabLabelWrapper:()=>p,MatTabLink:()=>v,MatTabNav:()=>k,MatTabNavPanel:()=>T,MatTabsModule:()=>R,_MAT_INK_BAR_POSITIONER:()=>_t});var t=s(39638),E=s(34883),d=s(88632),$=s(4295),Q=s(30184),x=s(60447),L=s(90459),w=s(88783),at=s(69005),G=s(52455),j=s(33807),l=s(24884),B=s(34630),A=s(48867),_=s(84350),yt=s(15047),kt=s(73971);const D=["*"];function nt(r,e){r&1&&t.\u0275\u0275projection(0)}const K=["tabListContainer"],U=["tabList"],Z=["tabListInner"],Y=["nextPaginator"],q=["previousPaginator"],it=["content"];function ot(r,e){}const rt=["tabBodyWrapper"],st=["tabHeader"];function dt(r,e){}function lt(r,e){if(r&1&&t.\u0275\u0275template(0,dt,0,0,"ng-template",12),r&2){const a=t.\u0275\u0275nextContext().$implicit;t.\u0275\u0275property("cdkPortalOutlet",a.templateLabel)}}function ct(r,e){if(r&1&&t.\u0275\u0275text(0),r&2){const a=t.\u0275\u0275nextContext().$implicit;t.\u0275\u0275textInterpolate(a.textLabel)}}function bt(r,e){if(r&1){const a=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"div",7,2),t.\u0275\u0275listener("click",function(){const i=t.\u0275\u0275restoreView(a),o=i.$implicit,u=i.$index,I=t.\u0275\u0275nextContext(),M=t.\u0275\u0275reference(1);return t.\u0275\u0275resetView(I._handleClick(o,M,u))})("cdkFocusChange",function(i){const o=t.\u0275\u0275restoreView(a).$index,u=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(u._tabFocusChanged(i,o))}),t.\u0275\u0275element(2,"span",8)(3,"div",9),t.\u0275\u0275elementStart(4,"span",10)(5,"span",11),t.\u0275\u0275conditionalCreate(6,lt,1,1,null,12)(7,ct,1,1),t.\u0275\u0275elementEnd()()()}if(r&2){const a=e.$implicit,n=e.$index,i=t.\u0275\u0275reference(1),o=t.\u0275\u0275nextContext();t.\u0275\u0275classMap(a.labelClass),t.\u0275\u0275classProp("mdc-tab--active",o.selectedIndex===n),t.\u0275\u0275property("id",o._getTabLabelId(a,n))("disabled",a.disabled)("fitInkBarToContent",o.fitInkBarToContent),t.\u0275\u0275attribute("tabIndex",o._getTabIndex(n))("aria-posinset",n+1)("aria-setsize",o._tabs.length)("aria-controls",o._getTabContentId(n))("aria-selected",o.selectedIndex===n)("aria-label",a.ariaLabel||null)("aria-labelledby",!a.ariaLabel&&a.ariaLabelledby?a.ariaLabelledby:null),t.\u0275\u0275advance(3),t.\u0275\u0275property("matRippleTrigger",i)("matRippleDisabled",a.disabled||o.disableRipple),t.\u0275\u0275advance(3),t.\u0275\u0275conditional(a.templateLabel?6:7)}}function mt(r,e){r&1&&t.\u0275\u0275projection(0)}function pt(r,e){if(r&1){const a=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"mat-tab-body",13),t.\u0275\u0275listener("_onCentered",function(){t.\u0275\u0275restoreView(a);const i=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(i._removeTabBodyWrapperHeight())})("_onCentering",function(i){t.\u0275\u0275restoreView(a);const o=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(o._setTabBodyWrapperHeight(i))})("_beforeCentering",function(i){t.\u0275\u0275restoreView(a);const o=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(o._bodyCentered(i))}),t.\u0275\u0275elementEnd()}if(r&2){const a=e.$implicit,n=e.$index,i=t.\u0275\u0275nextContext();t.\u0275\u0275classMap(a.bodyClass),t.\u0275\u0275property("id",i._getTabContentId(n))("content",a.content)("position",a.position)("animationDuration",i.animationDuration)("preserveContent",i.preserveContent),t.\u0275\u0275attribute("tabindex",i.contentTabIndex!=null&&i.selectedIndex===n?i.contentTabIndex:null)("aria-labelledby",i._getTabLabelId(a,n))("aria-hidden",i.selectedIndex!==n)}}const ht=["mat-tab-nav-bar",""],ut=["mat-tab-link",""],F=new t.InjectionToken("MatTabContent");class b{template=(0,t.inject)(t.TemplateRef);constructor(){}static \u0275fac=function(a){return new(a||b)};static \u0275dir=t.\u0275\u0275defineDirective({type:b,selectors:[["","matTabContent",""]],features:[t.\u0275\u0275ProvidersFeature([{provide:F,useExisting:b}])]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(b,[{type:t.Directive,args:[{selector:"[matTabContent]",providers:[{provide:F,useExisting:b}]}]}],()=>[],null);const N=new t.InjectionToken("MatTabLabel"),S=new t.InjectionToken("MAT_TAB");class c extends E.CdkPortal{_closestTab=(0,t.inject)(S,{optional:!0});static \u0275fac=(()=>{let e;return function(n){return(e||(e=t.\u0275\u0275getInheritedFactory(c)))(n||c)}})();static \u0275dir=t.\u0275\u0275defineDirective({type:c,selectors:[["","mat-tab-label",""],["","matTabLabel",""]],features:[t.\u0275\u0275ProvidersFeature([{provide:N,useExisting:c}]),t.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(c,[{type:t.Directive,args:[{selector:"[mat-tab-label], [matTabLabel]",providers:[{provide:N,useExisting:c}]}]}],null,null);const O=new t.InjectionToken("MAT_TAB_GROUP");class m{_viewContainerRef=(0,t.inject)(t.ViewContainerRef);_closestTabGroup=(0,t.inject)(O,{optional:!0});disabled=!1;get templateLabel(){return this._templateLabel}set templateLabel(e){this._setTemplateLabelInput(e)}_templateLabel;_explicitContent=void 0;_implicitContent;textLabel="";ariaLabel;ariaLabelledby;labelClass;bodyClass;id=null;_contentPortal=null;get content(){return this._contentPortal}_stateChanges=new d.Subject;position=null;origin=null;isActive=!1;constructor(){(0,t.inject)($._CdkPrivateStyleLoader).load(Q.A)}ngOnChanges(e){(e.hasOwnProperty("textLabel")||e.hasOwnProperty("disabled"))&&this._stateChanges.next()}ngOnDestroy(){this._stateChanges.complete()}ngOnInit(){this._contentPortal=new E.TemplatePortal(this._explicitContent||this._implicitContent,this._viewContainerRef)}_setTemplateLabelInput(e){e&&e._closestTab===this&&(this._templateLabel=e)}static \u0275fac=function(a){return new(a||m)};static \u0275cmp=t.\u0275\u0275defineComponent({type:m,selectors:[["mat-tab"]],contentQueries:function(a,n,i){if(a&1&&t.\u0275\u0275contentQuery(i,c,5)(i,b,7,t.TemplateRef),a&2){let o;t.\u0275\u0275queryRefresh(o=t.\u0275\u0275loadQuery())&&(n.templateLabel=o.first),t.\u0275\u0275queryRefresh(o=t.\u0275\u0275loadQuery())&&(n._explicitContent=o.first)}},viewQuery:function(a,n){if(a&1&&t.\u0275\u0275viewQuery(t.TemplateRef,7),a&2){let i;t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._implicitContent=i.first)}},hostAttrs:["hidden",""],hostVars:1,hostBindings:function(a,n){a&2&&t.\u0275\u0275attribute("id",null)},inputs:{disabled:[2,"disabled","disabled",t.booleanAttribute],textLabel:[0,"label","textLabel"],ariaLabel:[0,"aria-label","ariaLabel"],ariaLabelledby:[0,"aria-labelledby","ariaLabelledby"],labelClass:"labelClass",bodyClass:"bodyClass",id:"id"},exportAs:["matTab"],features:[t.\u0275\u0275ProvidersFeature([{provide:S,useExisting:m}]),t.\u0275\u0275NgOnChangesFeature],ngContentSelectors:D,decls:1,vars:0,template:function(a,n){a&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275domTemplate(0,nt,1,0,"ng-template"))},encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(m,[{type:t.Component,args:[{selector:"mat-tab",changeDetection:t.ChangeDetectionStrategy.Default,encapsulation:t.ViewEncapsulation.None,exportAs:"matTab",providers:[{provide:S,useExisting:m}],host:{hidden:"","[attr.id]":"null"},template:`<!-- Create a template for the content of the <mat-tab> so that we can grab a reference to this
    TemplateRef and use it in a Portal to render the tab content in the appropriate place in the
    tab-group. -->
<ng-template><ng-content></ng-content></ng-template>
`}]}],()=>[],{disabled:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],templateLabel:[{type:t.ContentChild,args:[c]}],_explicitContent:[{type:t.ContentChild,args:[b,{read:t.TemplateRef,static:!0}]}],_implicitContent:[{type:t.ViewChild,args:[t.TemplateRef,{static:!0}]}],textLabel:[{type:t.Input,args:["label"]}],ariaLabel:[{type:t.Input,args:["aria-label"]}],ariaLabelledby:[{type:t.Input,args:["aria-labelledby"]}],labelClass:[{type:t.Input}],bodyClass:[{type:t.Input}],id:[{type:t.Input}]});const H="mdc-tab-indicator--active",X="mdc-tab-indicator--no-transition";class z{_items;_currentItem;constructor(e){this._items=e}hide(){this._items.forEach(e=>e.deactivateInkBar()),this._currentItem=void 0}alignToElement(e){const a=this._items.find(i=>i.elementRef.nativeElement===e),n=this._currentItem;if(a!==n&&(n?.deactivateInkBar(),a)){const i=n?.elementRef.nativeElement.getBoundingClientRect?.();a.activateInkBar(i),this._currentItem=a}}}class P{_elementRef=(0,t.inject)(t.ElementRef);_inkBarElement=null;_inkBarContentElement=null;_fitToContent=!1;get fitInkBarToContent(){return this._fitToContent}set fitInkBarToContent(e){this._fitToContent!==e&&(this._fitToContent=e,this._inkBarElement&&this._appendInkBarElement())}activateInkBar(e){const a=this._elementRef.nativeElement;if(!e||!a.getBoundingClientRect||!this._inkBarContentElement){a.classList.add(H);return}const n=a.getBoundingClientRect(),i=e.width/n.width,o=e.left-n.left;a.classList.add(X),this._inkBarContentElement.style.setProperty("transform",`translateX(${o}px) scaleX(${i})`),a.getBoundingClientRect(),a.classList.remove(X),a.classList.add(H),this._inkBarContentElement.style.setProperty("transform","")}deactivateInkBar(){this._elementRef.nativeElement.classList.remove(H)}ngOnInit(){this._createInkBarElement()}ngOnDestroy(){this._inkBarElement?.remove(),this._inkBarElement=this._inkBarContentElement=null}_createInkBarElement(){const e=this._elementRef.nativeElement.ownerDocument||document,a=this._inkBarElement=e.createElement("span"),n=this._inkBarContentElement=e.createElement("span");a.className="mdc-tab-indicator",n.className="mdc-tab-indicator__content mdc-tab-indicator__content--underline",a.appendChild(this._inkBarContentElement),this._appendInkBarElement()}_appendInkBarElement(){if(!this._inkBarElement&&(typeof ngDevMode>"u"||ngDevMode))throw Error("Ink bar element has not been created and cannot be appended");const e=this._fitToContent?this._elementRef.nativeElement.querySelector(".mdc-tab__content"):this._elementRef.nativeElement;if(!e&&(typeof ngDevMode>"u"||ngDevMode))throw Error("Missing element to host the ink bar");e.appendChild(this._inkBarElement)}static \u0275fac=function(a){return new(a||P)};static \u0275dir=t.\u0275\u0275defineDirective({type:P,inputs:{fitInkBarToContent:[2,"fitInkBarToContent","fitInkBarToContent",t.booleanAttribute]}})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(P,[{type:t.Directive}],null,{fitInkBarToContent:[{type:t.Input,args:[{transform:t.booleanAttribute}]}]});const _t=new t.InjectionToken("MatInkBarPositioner",{providedIn:"root",factory:()=>e=>({left:e?(e.offsetLeft||0)+"px":"0",width:e?(e.offsetWidth||0)+"px":"0"})});class p extends P{elementRef=(0,t.inject)(t.ElementRef);disabled=!1;focus(){this.elementRef.nativeElement.focus()}getOffsetLeft(){return this.elementRef.nativeElement.offsetLeft}getOffsetWidth(){return this.elementRef.nativeElement.offsetWidth}static \u0275fac=(()=>{let e;return function(n){return(e||(e=t.\u0275\u0275getInheritedFactory(p)))(n||p)}})();static \u0275dir=t.\u0275\u0275defineDirective({type:p,selectors:[["","matTabLabelWrapper",""]],hostVars:3,hostBindings:function(a,n){a&2&&(t.\u0275\u0275attribute("aria-disabled",!!n.disabled),t.\u0275\u0275classProp("mat-mdc-tab-disabled",n.disabled))},inputs:{disabled:[2,"disabled","disabled",t.booleanAttribute]},features:[t.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(p,[{type:t.Directive,args:[{selector:"[matTabLabelWrapper]",host:{"[class.mat-mdc-tab-disabled]":"disabled","[attr.aria-disabled]":"!!disabled"}}]}],null,{disabled:[{type:t.Input,args:[{transform:t.booleanAttribute}]}]});const J={passive:!0},gt=650,ft=100;class C{_elementRef=(0,t.inject)(t.ElementRef);_changeDetectorRef=(0,t.inject)(t.ChangeDetectorRef);_viewportRuler=(0,t.inject)(j.ViewportRuler);_dir=(0,t.inject)(L.Directionality,{optional:!0});_ngZone=(0,t.inject)(t.NgZone);_platform=(0,t.inject)(G.Platform);_sharedResizeObserver=(0,t.inject)(at.SharedResizeObserver);_injector=(0,t.inject)(t.Injector);_renderer=(0,t.inject)(t.Renderer2);_animationsDisabled=(0,B.Rc)();_eventCleanups;_scrollDistance=0;_selectedIndexChanged=!1;_destroyed=new d.Subject;_showPaginationControls=!1;_disableScrollAfter=!0;_disableScrollBefore=!0;_tabLabelCount;_scrollDistanceChanged=!1;_keyManager;_currentTextContent;_stopScrolling=new d.Subject;disablePagination=!1;get selectedIndex(){return this._selectedIndex}set selectedIndex(e){const a=isNaN(e)?0:e;this._selectedIndex!=a&&(this._selectedIndexChanged=!0,this._selectedIndex=a,this._keyManager&&this._keyManager.updateActiveItem(a))}_selectedIndex=0;selectFocusedIndex=new t.EventEmitter;indexFocused=new t.EventEmitter;constructor(){this._eventCleanups=this._ngZone.runOutsideAngular(()=>[this._renderer.listen(this._elementRef.nativeElement,"mouseleave",()=>this._stopInterval())])}ngAfterViewInit(){this._eventCleanups.push(this._renderer.listen(this._previousPaginator.nativeElement,"touchstart",()=>this._handlePaginatorPress("before"),J),this._renderer.listen(this._nextPaginator.nativeElement,"touchstart",()=>this._handlePaginatorPress("after"),J))}ngAfterContentInit(){const e=this._dir?this._dir.change:(0,d.of)("ltr"),a=this._sharedResizeObserver.observe(this._elementRef.nativeElement).pipe((0,l.debounceTime)(32),(0,l.takeUntil)(this._destroyed)),n=this._viewportRuler.change(150).pipe((0,l.takeUntil)(this._destroyed)),i=()=>{this.updatePagination(),this._alignInkBarToSelectedTab()};this._keyManager=new x.FocusKeyManager(this._items).withHorizontalOrientation(this._getLayoutDirection()).withHomeAndEnd().withWrap().skipPredicate(()=>!1),this._keyManager.updateActiveItem(Math.max(this._selectedIndex,0)),(0,t.afterNextRender)(i,{injector:this._injector}),(0,d.merge)(e,n,a,this._items.changes,this._itemsResized()).pipe((0,l.takeUntil)(this._destroyed)).subscribe(()=>{this._ngZone.run(()=>{Promise.resolve().then(()=>{this._scrollDistance=Math.max(0,Math.min(this._getMaxScrollDistance(),this._scrollDistance)),i()})}),this._keyManager?.withHorizontalOrientation(this._getLayoutDirection())}),this._keyManager.change.subscribe(o=>{this.indexFocused.emit(o),this._setTabFocus(o)})}_itemsResized(){return typeof ResizeObserver!="function"?d.EMPTY:this._items.changes.pipe((0,l.startWith)(this._items),(0,l.switchMap)(e=>new d.Observable(a=>this._ngZone.runOutsideAngular(()=>{const n=new ResizeObserver(i=>a.next(i));return e.forEach(i=>n.observe(i.elementRef.nativeElement)),()=>{n.disconnect()}}))),(0,l.skip)(1),(0,l.filter)(e=>e.some(a=>a.contentRect.width>0&&a.contentRect.height>0)))}ngAfterContentChecked(){this._tabLabelCount!=this._items.length&&(this.updatePagination(),this._tabLabelCount=this._items.length,this._changeDetectorRef.markForCheck()),this._selectedIndexChanged&&(this._scrollToLabel(this._selectedIndex),this._checkScrollingControls(),this._alignInkBarToSelectedTab(),this._selectedIndexChanged=!1,this._changeDetectorRef.markForCheck()),this._scrollDistanceChanged&&(this._updateTabScrollPosition(),this._scrollDistanceChanged=!1,this._changeDetectorRef.markForCheck())}ngOnDestroy(){this._eventCleanups.forEach(e=>e()),this._keyManager?.destroy(),this._destroyed.next(),this._destroyed.complete(),this._stopScrolling.complete()}_handleKeydown(e){if(!(0,w.hasModifierKey)(e))switch(e.keyCode){case w.ENTER:case w.SPACE:if(this.focusIndex!==this.selectedIndex){const a=this._items.get(this.focusIndex);a&&!a.disabled&&(this.selectFocusedIndex.emit(this.focusIndex),this._itemSelected(e))}break;default:this._keyManager?.onKeydown(e)}}_onContentChanges(){const e=this._elementRef.nativeElement.textContent;e!==this._currentTextContent&&(this._currentTextContent=e||"",this._ngZone.run(()=>{this.updatePagination(),this._alignInkBarToSelectedTab(),this._changeDetectorRef.markForCheck()}))}updatePagination(){this._checkPaginationEnabled(),this._checkScrollingControls(),this._updateTabScrollPosition()}get focusIndex(){return this._keyManager?this._keyManager.activeItemIndex:0}set focusIndex(e){!this._isValidIndex(e)||this.focusIndex===e||!this._keyManager||this._keyManager.setActiveItem(e)}_isValidIndex(e){return this._items?!!this._items.toArray()[e]:!0}_setTabFocus(e){if(this._showPaginationControls&&this._scrollToLabel(e),this._items&&this._items.length){this._items.toArray()[e].focus();const a=this._tabListContainer.nativeElement;this._getLayoutDirection()=="ltr"?a.scrollLeft=0:a.scrollLeft=a.scrollWidth-a.offsetWidth}}_getLayoutDirection(){return this._dir&&this._dir.value==="rtl"?"rtl":"ltr"}_updateTabScrollPosition(){if(this.disablePagination)return;const e=this.scrollDistance,a=this._getLayoutDirection()==="ltr"?-e:e;this._tabList.nativeElement.style.transform=`translateX(${Math.round(a)}px)`,(this._platform.TRIDENT||this._platform.EDGE)&&(this._tabListContainer.nativeElement.scrollLeft=0)}get scrollDistance(){return this._scrollDistance}set scrollDistance(e){this._scrollTo(e)}_scrollHeader(e){const a=this._tabListContainer.nativeElement.offsetWidth,n=(e=="before"?-1:1)*a/3;return this._scrollTo(this._scrollDistance+n)}_handlePaginatorClick(e){this._stopInterval(),this._scrollHeader(e)}_scrollToLabel(e){if(this.disablePagination)return;const a=this._items?this._items.toArray()[e]:null;if(!a)return;const n=this._tabListContainer.nativeElement.offsetWidth,{offsetLeft:i,offsetWidth:o}=a.elementRef.nativeElement;let u,I;this._getLayoutDirection()=="ltr"?(u=i,I=u+o):(I=this._tabListInner.nativeElement.offsetWidth-i,u=I-o);const M=this.scrollDistance,et=this.scrollDistance+n;u<M?this.scrollDistance-=M-u:I>et&&(this.scrollDistance+=Math.min(I-et,u-M))}_checkPaginationEnabled(){if(this.disablePagination)this._showPaginationControls=!1;else{const e=this._tabListInner.nativeElement.scrollWidth,a=this._elementRef.nativeElement.offsetWidth,n=e-a>=5;n||(this.scrollDistance=0),n!==this._showPaginationControls&&(this._showPaginationControls=n,this._changeDetectorRef.markForCheck())}}_checkScrollingControls(){this.disablePagination?this._disableScrollAfter=this._disableScrollBefore=!0:(this._disableScrollBefore=this.scrollDistance==0,this._disableScrollAfter=this.scrollDistance==this._getMaxScrollDistance(),this._changeDetectorRef.markForCheck())}_getMaxScrollDistance(){const e=this._tabListInner.nativeElement.scrollWidth,a=this._tabListContainer.nativeElement.offsetWidth;return e-a||0}_alignInkBarToSelectedTab(){const e=this._items&&this._items.length?this._items.toArray()[this.selectedIndex]:null,a=e?e.elementRef.nativeElement:null;a?this._inkBar.alignToElement(a):this._inkBar.hide()}_stopInterval(){this._stopScrolling.next()}_handlePaginatorPress(e,a){a&&a.button!=null&&a.button!==0||(this._stopInterval(),(0,d.timer)(gt,ft).pipe((0,l.takeUntil)((0,d.merge)(this._stopScrolling,this._destroyed))).subscribe(()=>{const{maxScrollDistance:n,distance:i}=this._scrollHeader(e);(i===0||i>=n)&&this._stopInterval()}))}_scrollTo(e){if(this.disablePagination)return{maxScrollDistance:0,distance:0};const a=this._getMaxScrollDistance();return this._scrollDistance=Math.max(0,Math.min(a,e)),this._scrollDistanceChanged=!0,this._checkScrollingControls(),{maxScrollDistance:a,distance:this._scrollDistance}}static \u0275fac=function(a){return new(a||C)};static \u0275dir=t.\u0275\u0275defineDirective({type:C,inputs:{disablePagination:[2,"disablePagination","disablePagination",t.booleanAttribute],selectedIndex:[2,"selectedIndex","selectedIndex",t.numberAttribute]},outputs:{selectFocusedIndex:"selectFocusedIndex",indexFocused:"indexFocused"}})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(C,[{type:t.Directive}],()=>[],{disablePagination:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],selectedIndex:[{type:t.Input,args:[{transform:t.numberAttribute}]}],selectFocusedIndex:[{type:t.Output}],indexFocused:[{type:t.Output}]});class y extends C{_items;_tabListContainer;_tabList;_tabListInner;_nextPaginator;_previousPaginator;_inkBar;ariaLabel;ariaLabelledby;disableRipple=!1;ngAfterContentInit(){this._inkBar=new z(this._items),super.ngAfterContentInit()}_itemSelected(e){e.preventDefault()}static \u0275fac=(()=>{let e;return function(n){return(e||(e=t.\u0275\u0275getInheritedFactory(y)))(n||y)}})();static \u0275cmp=t.\u0275\u0275defineComponent({type:y,selectors:[["mat-tab-header"]],contentQueries:function(a,n,i){if(a&1&&t.\u0275\u0275contentQuery(i,p,4),a&2){let o;t.\u0275\u0275queryRefresh(o=t.\u0275\u0275loadQuery())&&(n._items=o)}},viewQuery:function(a,n){if(a&1&&t.\u0275\u0275viewQuery(K,7)(U,7)(Z,7)(Y,5)(q,5),a&2){let i;t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabListContainer=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabList=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabListInner=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._nextPaginator=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._previousPaginator=i.first)}},hostAttrs:[1,"mat-mdc-tab-header"],hostVars:4,hostBindings:function(a,n){a&2&&t.\u0275\u0275classProp("mat-mdc-tab-header-pagination-controls-enabled",n._showPaginationControls)("mat-mdc-tab-header-rtl",n._getLayoutDirection()=="rtl")},inputs:{ariaLabel:[0,"aria-label","ariaLabel"],ariaLabelledby:[0,"aria-labelledby","ariaLabelledby"],disableRipple:[2,"disableRipple","disableRipple",t.booleanAttribute]},features:[t.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:D,decls:13,vars:10,consts:[["previousPaginator",""],["tabListContainer",""],["tabList",""],["tabListInner",""],["nextPaginator",""],["mat-ripple","",1,"mat-mdc-tab-header-pagination","mat-mdc-tab-header-pagination-before",3,"click","mousedown","touchend","matRippleDisabled"],[1,"mat-mdc-tab-header-pagination-chevron"],[1,"mat-mdc-tab-label-container",3,"keydown"],["role","tablist",1,"mat-mdc-tab-list",3,"cdkObserveContent"],[1,"mat-mdc-tab-labels"],["mat-ripple","",1,"mat-mdc-tab-header-pagination","mat-mdc-tab-header-pagination-after",3,"mousedown","click","touchend","matRippleDisabled"]],template:function(a,n){a&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275elementStart(0,"div",5,0),t.\u0275\u0275listener("click",function(){return n._handlePaginatorClick("before")})("mousedown",function(o){return n._handlePaginatorPress("before",o)})("touchend",function(){return n._stopInterval()}),t.\u0275\u0275element(2,"div",6),t.\u0275\u0275elementEnd(),t.\u0275\u0275elementStart(3,"div",7,1),t.\u0275\u0275listener("keydown",function(o){return n._handleKeydown(o)}),t.\u0275\u0275elementStart(5,"div",8,2),t.\u0275\u0275listener("cdkObserveContent",function(){return n._onContentChanges()}),t.\u0275\u0275elementStart(7,"div",9,3),t.\u0275\u0275projection(9),t.\u0275\u0275elementEnd()()(),t.\u0275\u0275elementStart(10,"div",10,4),t.\u0275\u0275listener("mousedown",function(o){return n._handlePaginatorPress("after",o)})("click",function(){return n._handlePaginatorClick("after")})("touchend",function(){return n._stopInterval()}),t.\u0275\u0275element(12,"div",6),t.\u0275\u0275elementEnd()),a&2&&(t.\u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled",n._disableScrollBefore),t.\u0275\u0275property("matRippleDisabled",n._disableScrollBefore||n.disableRipple),t.\u0275\u0275advance(3),t.\u0275\u0275classProp("_mat-animation-noopable",n._animationsDisabled),t.\u0275\u0275advance(2),t.\u0275\u0275attribute("aria-label",n.ariaLabel||null)("aria-labelledby",n.ariaLabelledby||null),t.\u0275\u0275advance(5),t.\u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled",n._disableScrollAfter),t.\u0275\u0275property("matRippleDisabled",n._disableScrollAfter||n.disableRipple))},dependencies:[_.r6,A.CdkObserveContent],styles:[`.mat-mdc-tab-header {
  display: flex;
  overflow: hidden;
  position: relative;
  flex-shrink: 0;
}

.mdc-tab-indicator .mdc-tab-indicator__content {
  transition-duration: var(--mat-tab-animation-duration, 250ms);
}

.mat-mdc-tab-header-pagination {
  -webkit-user-select: none;
  user-select: none;
  position: relative;
  display: none;
  justify-content: center;
  align-items: center;
  min-width: 32px;
  cursor: pointer;
  z-index: 2;
  -webkit-tap-highlight-color: transparent;
  touch-action: none;
  box-sizing: content-box;
  outline: 0;
}
.mat-mdc-tab-header-pagination::-moz-focus-inner {
  border: 0;
}
.mat-mdc-tab-header-pagination .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination {
  display: flex;
}

.mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after {
  padding-left: 4px;
}
.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(-135deg);
}

.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-pagination-after {
  padding-right: 4px;
}
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(45deg);
}

.mat-mdc-tab-header-pagination-chevron {
  border-style: solid;
  border-width: 2px 2px 0 0;
  height: 8px;
  width: 8px;
  border-color: var(--mat-tab-pagination-icon-color, var(--mat-sys-on-surface));
}

.mat-mdc-tab-header-pagination-disabled {
  box-shadow: none;
  cursor: default;
  pointer-events: none;
}
.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron {
  opacity: 0.4;
}

.mat-mdc-tab-list {
  flex-grow: 1;
  position: relative;
  transition: transform 500ms cubic-bezier(0.35, 0, 0.25, 1);
}
._mat-animation-noopable .mat-mdc-tab-list {
  transition: none;
}

.mat-mdc-tab-label-container {
  display: flex;
  flex-grow: 1;
  overflow: hidden;
  z-index: 1;
  border-bottom-style: solid;
  border-bottom-width: var(--mat-tab-divider-height, 1px);
  border-bottom-color: var(--mat-tab-divider-color, var(--mat-sys-surface-variant));
}
.mat-mdc-tab-group-inverted-header .mat-mdc-tab-label-container {
  border-bottom: none;
  border-top-style: solid;
  border-top-width: var(--mat-tab-divider-height, 1px);
  border-top-color: var(--mat-tab-divider-color, var(--mat-sys-surface-variant));
}

.mat-mdc-tab-labels {
  display: flex;
  flex: 1 0 auto;
}
[mat-align-tabs=center] > .mat-mdc-tab-header .mat-mdc-tab-labels {
  justify-content: center;
}
[mat-align-tabs=end] > .mat-mdc-tab-header .mat-mdc-tab-labels {
  justify-content: flex-end;
}
.cdk-drop-list .mat-mdc-tab-labels, .mat-mdc-tab-labels.cdk-drop-list {
  min-height: var(--mat-tab-container-height, 48px);
}

.mat-mdc-tab::before {
  margin: 5px;
}
@media (forced-colors: active) {
  .mat-mdc-tab[aria-disabled=true] {
    color: GrayText;
  }
}
`],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(y,[{type:t.Component,args:[{selector:"mat-tab-header",encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.Default,host:{class:"mat-mdc-tab-header","[class.mat-mdc-tab-header-pagination-controls-enabled]":"_showPaginationControls","[class.mat-mdc-tab-header-rtl]":"_getLayoutDirection() == 'rtl'"},imports:[_.r6,A.CdkObserveContent],template:`<!--
 Note that this intentionally uses a \`div\` instead of a \`button\`, because it's not part of
 the regular tabs flow and is only here to support mouse users. It should also not be focusable.
-->
<div class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-before"
     #previousPaginator
     mat-ripple
     [matRippleDisabled]="_disableScrollBefore || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollBefore"
     (click)="_handlePaginatorClick('before')"
     (mousedown)="_handlePaginatorPress('before', $event)"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</div>

<div
  class="mat-mdc-tab-label-container"
  #tabListContainer
  (keydown)="_handleKeydown($event)"
  [class._mat-animation-noopable]="_animationsDisabled">
  <div
    #tabList
    class="mat-mdc-tab-list"
    role="tablist"
    [attr.aria-label]="ariaLabel || null"
    [attr.aria-labelledby]="ariaLabelledby || null"
    (cdkObserveContent)="_onContentChanges()">
    <div class="mat-mdc-tab-labels" #tabListInner>
      <ng-content></ng-content>
    </div>
  </div>
</div>

<div class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-after"
     #nextPaginator
     mat-ripple
     [matRippleDisabled]="_disableScrollAfter || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollAfter"
     (mousedown)="_handlePaginatorPress('after', $event)"
     (click)="_handlePaginatorClick('after')"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</div>
`,styles:[`.mat-mdc-tab-header {
  display: flex;
  overflow: hidden;
  position: relative;
  flex-shrink: 0;
}

.mdc-tab-indicator .mdc-tab-indicator__content {
  transition-duration: var(--mat-tab-animation-duration, 250ms);
}

.mat-mdc-tab-header-pagination {
  -webkit-user-select: none;
  user-select: none;
  position: relative;
  display: none;
  justify-content: center;
  align-items: center;
  min-width: 32px;
  cursor: pointer;
  z-index: 2;
  -webkit-tap-highlight-color: transparent;
  touch-action: none;
  box-sizing: content-box;
  outline: 0;
}
.mat-mdc-tab-header-pagination::-moz-focus-inner {
  border: 0;
}
.mat-mdc-tab-header-pagination .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination {
  display: flex;
}

.mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after {
  padding-left: 4px;
}
.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(-135deg);
}

.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-pagination-after {
  padding-right: 4px;
}
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(45deg);
}

.mat-mdc-tab-header-pagination-chevron {
  border-style: solid;
  border-width: 2px 2px 0 0;
  height: 8px;
  width: 8px;
  border-color: var(--mat-tab-pagination-icon-color, var(--mat-sys-on-surface));
}

.mat-mdc-tab-header-pagination-disabled {
  box-shadow: none;
  cursor: default;
  pointer-events: none;
}
.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron {
  opacity: 0.4;
}

.mat-mdc-tab-list {
  flex-grow: 1;
  position: relative;
  transition: transform 500ms cubic-bezier(0.35, 0, 0.25, 1);
}
._mat-animation-noopable .mat-mdc-tab-list {
  transition: none;
}

.mat-mdc-tab-label-container {
  display: flex;
  flex-grow: 1;
  overflow: hidden;
  z-index: 1;
  border-bottom-style: solid;
  border-bottom-width: var(--mat-tab-divider-height, 1px);
  border-bottom-color: var(--mat-tab-divider-color, var(--mat-sys-surface-variant));
}
.mat-mdc-tab-group-inverted-header .mat-mdc-tab-label-container {
  border-bottom: none;
  border-top-style: solid;
  border-top-width: var(--mat-tab-divider-height, 1px);
  border-top-color: var(--mat-tab-divider-color, var(--mat-sys-surface-variant));
}

.mat-mdc-tab-labels {
  display: flex;
  flex: 1 0 auto;
}
[mat-align-tabs=center] > .mat-mdc-tab-header .mat-mdc-tab-labels {
  justify-content: center;
}
[mat-align-tabs=end] > .mat-mdc-tab-header .mat-mdc-tab-labels {
  justify-content: flex-end;
}
.cdk-drop-list .mat-mdc-tab-labels, .mat-mdc-tab-labels.cdk-drop-list {
  min-height: var(--mat-tab-container-height, 48px);
}

.mat-mdc-tab::before {
  margin: 5px;
}
@media (forced-colors: active) {
  .mat-mdc-tab[aria-disabled=true] {
    color: GrayText;
  }
}
`]}]}],null,{_items:[{type:t.ContentChildren,args:[p,{descendants:!1}]}],_tabListContainer:[{type:t.ViewChild,args:["tabListContainer",{static:!0}]}],_tabList:[{type:t.ViewChild,args:["tabList",{static:!0}]}],_tabListInner:[{type:t.ViewChild,args:["tabListInner",{static:!0}]}],_nextPaginator:[{type:t.ViewChild,args:["nextPaginator"]}],_previousPaginator:[{type:t.ViewChild,args:["previousPaginator"]}],ariaLabel:[{type:t.Input,args:["aria-label"]}],ariaLabelledby:[{type:t.Input,args:["aria-labelledby"]}],disableRipple:[{type:t.Input,args:[{transform:t.booleanAttribute}]}]});const W=new t.InjectionToken("MAT_TABS_CONFIG");class g extends E.CdkPortalOutlet{_host=(0,t.inject)(h);_ngZone=(0,t.inject)(t.NgZone);_centeringSub=d.Subscription.EMPTY;_leavingSub=d.Subscription.EMPTY;constructor(){super()}ngOnInit(){super.ngOnInit(),this._centeringSub=this._host._beforeCentering.pipe((0,l.startWith)(this._host._isCenterPosition())).subscribe(e=>{this._host._content&&e&&!this.hasAttached()&&this._ngZone.run(()=>{Promise.resolve().then(),this.attach(this._host._content)})}),this._leavingSub=this._host._afterLeavingCenter.subscribe(()=>{this._host.preserveContent||this._ngZone.run(()=>this.detach())})}ngOnDestroy(){super.ngOnDestroy(),this._centeringSub.unsubscribe(),this._leavingSub.unsubscribe()}static \u0275fac=function(a){return new(a||g)};static \u0275dir=t.\u0275\u0275defineDirective({type:g,selectors:[["","matTabBodyHost",""]],features:[t.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(g,[{type:t.Directive,args:[{selector:"[matTabBodyHost]"}]}],()=>[],null);class h{_elementRef=(0,t.inject)(t.ElementRef);_dir=(0,t.inject)(L.Directionality,{optional:!0});_ngZone=(0,t.inject)(t.NgZone);_injector=(0,t.inject)(t.Injector);_renderer=(0,t.inject)(t.Renderer2);_diAnimationsDisabled=(0,B.Rc)();_eventCleanups;_initialized=!1;_fallbackTimer;_positionIndex;_dirChangeSubscription=d.Subscription.EMPTY;_position;_previousPosition;_onCentering=new t.EventEmitter;_beforeCentering=new t.EventEmitter;_afterLeavingCenter=new t.EventEmitter;_onCentered=new t.EventEmitter(!0);_portalHost;_contentElement;_content;animationDuration="500ms";preserveContent=!1;set position(e){this._positionIndex=e,this._computePositionAnimationState()}constructor(){if(this._dir){const e=(0,t.inject)(t.ChangeDetectorRef);this._dirChangeSubscription=this._dir.change.subscribe(a=>{this._computePositionAnimationState(a),e.markForCheck()})}}ngOnInit(){this._bindTransitionEvents(),this._position==="center"&&(this._setActiveClass(!0),(0,t.afterNextRender)(()=>this._onCentering.emit(this._elementRef.nativeElement.clientHeight),{injector:this._injector})),this._initialized=!0}ngOnDestroy(){clearTimeout(this._fallbackTimer),this._eventCleanups?.forEach(e=>e()),this._dirChangeSubscription.unsubscribe()}_bindTransitionEvents(){this._ngZone.runOutsideAngular(()=>{const e=this._elementRef.nativeElement,a=n=>{n.target===this._contentElement?.nativeElement&&(this._elementRef.nativeElement.classList.remove("mat-tab-body-animating"),n.type==="transitionend"&&this._transitionDone())};this._eventCleanups=[this._renderer.listen(e,"transitionstart",n=>{n.target===this._contentElement?.nativeElement&&(this._elementRef.nativeElement.classList.add("mat-tab-body-animating"),this._transitionStarted())}),this._renderer.listen(e,"transitionend",a),this._renderer.listen(e,"transitioncancel",a)]})}_transitionStarted(){clearTimeout(this._fallbackTimer);const e=this._position==="center";this._beforeCentering.emit(e),e&&this._onCentering.emit(this._elementRef.nativeElement.clientHeight)}_transitionDone(){this._position==="center"?this._onCentered.emit():this._previousPosition==="center"&&this._afterLeavingCenter.emit()}_setActiveClass(e){this._elementRef.nativeElement.classList.toggle("mat-mdc-tab-body-active",e)}_getLayoutDirection(){return this._dir&&this._dir.value==="rtl"?"rtl":"ltr"}_isCenterPosition(){return this._positionIndex===0}_computePositionAnimationState(e=this._getLayoutDirection()){this._previousPosition=this._position,this._positionIndex<0?this._position=e=="ltr"?"left":"right":this._positionIndex>0?this._position=e=="ltr"?"right":"left":this._position="center",this._animationsDisabled()?this._simulateTransitionEvents():this._initialized&&(this._position==="center"||this._previousPosition==="center")&&(clearTimeout(this._fallbackTimer),this._fallbackTimer=this._ngZone.runOutsideAngular(()=>setTimeout(()=>this._simulateTransitionEvents(),100)))}_simulateTransitionEvents(){this._transitionStarted(),(0,t.afterNextRender)(()=>this._transitionDone(),{injector:this._injector})}_animationsDisabled(){return this._diAnimationsDisabled||this.animationDuration==="0ms"||this.animationDuration==="0s"}static \u0275fac=function(a){return new(a||h)};static \u0275cmp=t.\u0275\u0275defineComponent({type:h,selectors:[["mat-tab-body"]],viewQuery:function(a,n){if(a&1&&t.\u0275\u0275viewQuery(g,5)(it,5),a&2){let i;t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._portalHost=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._contentElement=i.first)}},hostAttrs:[1,"mat-mdc-tab-body"],hostVars:1,hostBindings:function(a,n){a&2&&t.\u0275\u0275attribute("inert",n._position==="center"?null:"")},inputs:{_content:[0,"content","_content"],animationDuration:"animationDuration",preserveContent:"preserveContent",position:"position"},outputs:{_onCentering:"_onCentering",_beforeCentering:"_beforeCentering",_onCentered:"_onCentered"},decls:3,vars:6,consts:[["content",""],["cdkScrollable","",1,"mat-mdc-tab-body-content"],["matTabBodyHost",""]],template:function(a,n){a&1&&(t.\u0275\u0275elementStart(0,"div",1,0),t.\u0275\u0275template(2,ot,0,0,"ng-template",2),t.\u0275\u0275elementEnd()),a&2&&t.\u0275\u0275classProp("mat-tab-body-content-left",n._position==="left")("mat-tab-body-content-right",n._position==="right")("mat-tab-body-content-can-animate",n._position==="center"||n._previousPosition==="center")},dependencies:[g,j.CdkScrollable],styles:[`.mat-mdc-tab-body {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: block;
  overflow: hidden;
  outline: 0;
  flex-basis: 100%;
}
.mat-mdc-tab-body.mat-mdc-tab-body-active {
  position: relative;
  overflow-x: hidden;
  overflow-y: auto;
  z-index: 1;
  flex-grow: 1;
}
.mat-mdc-tab-group.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body.mat-mdc-tab-body-active {
  overflow-y: hidden;
}

.mat-mdc-tab-body-content {
  height: 100%;
  overflow: auto;
  transform: none;
  visibility: hidden;
}
.mat-tab-body-animating > .mat-mdc-tab-body-content, .mat-mdc-tab-body-active > .mat-mdc-tab-body-content {
  visibility: visible;
}
.mat-tab-body-animating > .mat-mdc-tab-body-content {
  min-height: 1px;
}
.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body-content {
  overflow: hidden;
}

.mat-tab-body-content-can-animate {
  transition: transform var(--mat-tab-animation-duration) 1ms cubic-bezier(0.35, 0, 0.25, 1);
}
.mat-mdc-tab-body-wrapper._mat-animation-noopable .mat-tab-body-content-can-animate {
  transition: none;
}

.mat-tab-body-content-left {
  transform: translate3d(-100%, 0, 0);
}

.mat-tab-body-content-right {
  transform: translate3d(100%, 0, 0);
}
`],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(h,[{type:t.Component,args:[{selector:"mat-tab-body",encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.Default,host:{class:"mat-mdc-tab-body","[attr.inert]":'_position === "center" ? null : ""'},imports:[g,j.CdkScrollable],template:`<div
   class="mat-mdc-tab-body-content"
   #content
   cdkScrollable
   [class.mat-tab-body-content-left]="_position === 'left'"
   [class.mat-tab-body-content-right]="_position === 'right'"
   [class.mat-tab-body-content-can-animate]="_position === 'center' || _previousPosition === 'center'">
  <ng-template matTabBodyHost></ng-template>
</div>
`,styles:[`.mat-mdc-tab-body {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  display: block;
  overflow: hidden;
  outline: 0;
  flex-basis: 100%;
}
.mat-mdc-tab-body.mat-mdc-tab-body-active {
  position: relative;
  overflow-x: hidden;
  overflow-y: auto;
  z-index: 1;
  flex-grow: 1;
}
.mat-mdc-tab-group.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body.mat-mdc-tab-body-active {
  overflow-y: hidden;
}

.mat-mdc-tab-body-content {
  height: 100%;
  overflow: auto;
  transform: none;
  visibility: hidden;
}
.mat-tab-body-animating > .mat-mdc-tab-body-content, .mat-mdc-tab-body-active > .mat-mdc-tab-body-content {
  visibility: visible;
}
.mat-tab-body-animating > .mat-mdc-tab-body-content {
  min-height: 1px;
}
.mat-mdc-tab-group-dynamic-height .mat-mdc-tab-body-content {
  overflow: hidden;
}

.mat-tab-body-content-can-animate {
  transition: transform var(--mat-tab-animation-duration) 1ms cubic-bezier(0.35, 0, 0.25, 1);
}
.mat-mdc-tab-body-wrapper._mat-animation-noopable .mat-tab-body-content-can-animate {
  transition: none;
}

.mat-tab-body-content-left {
  transform: translate3d(-100%, 0, 0);
}

.mat-tab-body-content-right {
  transform: translate3d(100%, 0, 0);
}
`]}]}],()=>[],{_onCentering:[{type:t.Output}],_beforeCentering:[{type:t.Output}],_onCentered:[{type:t.Output}],_portalHost:[{type:t.ViewChild,args:[g]}],_contentElement:[{type:t.ViewChild,args:["content"]}],_content:[{type:t.Input,args:["content"]}],animationDuration:[{type:t.Input}],preserveContent:[{type:t.Input}],position:[{type:t.Input}]});class f{_elementRef=(0,t.inject)(t.ElementRef);_changeDetectorRef=(0,t.inject)(t.ChangeDetectorRef);_ngZone=(0,t.inject)(t.NgZone);_tabsSubscription=d.Subscription.EMPTY;_tabLabelSubscription=d.Subscription.EMPTY;_tabBodySubscription=d.Subscription.EMPTY;_diAnimationsDisabled=(0,B.Rc)();_allTabs;_tabBodies;_tabBodyWrapper;_tabHeader;_tabs=new t.QueryList;_indexToSelect=0;_lastFocusedTabIndex=null;_tabBodyWrapperHeight=0;color;get fitInkBarToContent(){return this._fitInkBarToContent}set fitInkBarToContent(e){this._fitInkBarToContent=e,this._changeDetectorRef.markForCheck()}_fitInkBarToContent=!1;stretchTabs=!0;alignTabs=null;dynamicHeight=!1;get selectedIndex(){return this._selectedIndex}set selectedIndex(e){this._indexToSelect=isNaN(e)?null:e}_selectedIndex=null;headerPosition="above";get animationDuration(){return this._animationDuration}set animationDuration(e){const a=e+"";this._animationDuration=/^\d+$/.test(a)?e+"ms":a}_animationDuration;get contentTabIndex(){return this._contentTabIndex}set contentTabIndex(e){this._contentTabIndex=isNaN(e)?null:e}_contentTabIndex=null;disablePagination=!1;disableRipple=!1;preserveContent=!1;get backgroundColor(){return this._backgroundColor}set backgroundColor(e){const a=this._elementRef.nativeElement.classList;a.remove("mat-tabs-with-background",`mat-background-${this.backgroundColor}`),e&&a.add("mat-tabs-with-background",`mat-background-${e}`),this._backgroundColor=e}_backgroundColor;ariaLabel;ariaLabelledby;selectedIndexChange=new t.EventEmitter;focusChange=new t.EventEmitter;animationDone=new t.EventEmitter;selectedTabChange=new t.EventEmitter(!0);_groupId;_isServer=!(0,t.inject)(G.Platform).isBrowser;constructor(){const e=(0,t.inject)(W,{optional:!0});this._groupId=(0,t.inject)(x._IdGenerator).getId("mat-tab-group-"),this.animationDuration=e&&e.animationDuration?e.animationDuration:"500ms",this.disablePagination=e&&e.disablePagination!=null?e.disablePagination:!1,this.dynamicHeight=e&&e.dynamicHeight!=null?e.dynamicHeight:!1,e?.contentTabIndex!=null&&(this.contentTabIndex=e.contentTabIndex),this.preserveContent=!!e?.preserveContent,this.fitInkBarToContent=e&&e.fitInkBarToContent!=null?e.fitInkBarToContent:!1,this.stretchTabs=e&&e.stretchTabs!=null?e.stretchTabs:!0,this.alignTabs=e&&e.alignTabs!=null?e.alignTabs:null}ngAfterContentChecked(){const e=this._indexToSelect=this._clampTabIndex(this._indexToSelect);if(this._selectedIndex!=e){const a=this._selectedIndex==null;if(!a){this.selectedTabChange.emit(this._createChangeEvent(e));const n=this._tabBodyWrapper.nativeElement;n.style.minHeight=n.clientHeight+"px"}Promise.resolve().then(()=>{this._tabs.forEach((n,i)=>n.isActive=i===e),a||(this.selectedIndexChange.emit(e),this._tabBodyWrapper.nativeElement.style.minHeight="")})}this._tabs.forEach((a,n)=>{a.position=n-e,this._selectedIndex!=null&&a.position==0&&!a.origin&&(a.origin=e-this._selectedIndex)}),this._selectedIndex!==e&&(this._selectedIndex=e,this._lastFocusedTabIndex=null,this._changeDetectorRef.markForCheck())}ngAfterContentInit(){this._subscribeToAllTabChanges(),this._subscribeToTabLabels(),this._tabsSubscription=this._tabs.changes.subscribe(()=>{const e=this._clampTabIndex(this._indexToSelect);if(e===this._selectedIndex){const a=this._tabs.toArray();let n;for(let i=0;i<a.length;i++)if(a[i].isActive){this._indexToSelect=this._selectedIndex=i,this._lastFocusedTabIndex=null,n=a[i];break}!n&&a[e]&&Promise.resolve().then(()=>{a[e].isActive=!0,this.selectedTabChange.emit(this._createChangeEvent(e))})}this._changeDetectorRef.markForCheck()})}ngAfterViewInit(){this._tabBodySubscription=this._tabBodies.changes.subscribe(()=>this._bodyCentered(!0))}_subscribeToAllTabChanges(){this._allTabs.changes.pipe((0,l.startWith)(this._allTabs)).subscribe(e=>{this._tabs.reset(e.filter(a=>a._closestTabGroup===this||!a._closestTabGroup)),this._tabs.notifyOnChanges()})}ngOnDestroy(){this._tabs.destroy(),this._tabsSubscription.unsubscribe(),this._tabLabelSubscription.unsubscribe(),this._tabBodySubscription.unsubscribe()}realignInkBar(){this._tabHeader&&this._tabHeader._alignInkBarToSelectedTab()}updatePagination(){this._tabHeader&&this._tabHeader.updatePagination()}focusTab(e){const a=this._tabHeader;a&&(a.focusIndex=e)}_focusChanged(e){this._lastFocusedTabIndex=e,this.focusChange.emit(this._createChangeEvent(e))}_createChangeEvent(e){const a=new tt;return a.index=e,this._tabs&&this._tabs.length&&(a.tab=this._tabs.toArray()[e]),a}_subscribeToTabLabels(){this._tabLabelSubscription&&this._tabLabelSubscription.unsubscribe(),this._tabLabelSubscription=(0,d.merge)(...this._tabs.map(e=>e._stateChanges)).subscribe(()=>this._changeDetectorRef.markForCheck())}_clampTabIndex(e){return Math.min(this._tabs.length-1,Math.max(e||0,0))}_getTabLabelId(e,a){return e.id||`${this._groupId}-label-${a}`}_getTabContentId(e){return`${this._groupId}-content-${e}`}_setTabBodyWrapperHeight(e){if(!this.dynamicHeight||!this._tabBodyWrapperHeight){this._tabBodyWrapperHeight=e;return}const a=this._tabBodyWrapper.nativeElement;a.style.height=this._tabBodyWrapperHeight+"px",this._tabBodyWrapper.nativeElement.offsetHeight&&(a.style.height=e+"px")}_removeTabBodyWrapperHeight(){const e=this._tabBodyWrapper.nativeElement;this._tabBodyWrapperHeight=e.clientHeight,e.style.height="",this._ngZone.run(()=>this.animationDone.emit())}_handleClick(e,a,n){a.focusIndex=n,e.disabled||(this.selectedIndex=n)}_getTabIndex(e){const a=this._lastFocusedTabIndex??this.selectedIndex;return e===a?0:-1}_tabFocusChanged(e,a){e&&e!=="mouse"&&e!=="touch"&&(this._tabHeader.focusIndex=a)}_bodyCentered(e){e&&this._tabBodies?.forEach((a,n)=>a._setActiveClass(n===this._selectedIndex))}_animationsDisabled(){return this._diAnimationsDisabled||this.animationDuration==="0"||this.animationDuration==="0ms"}static \u0275fac=function(a){return new(a||f)};static \u0275cmp=t.\u0275\u0275defineComponent({type:f,selectors:[["mat-tab-group"]],contentQueries:function(a,n,i){if(a&1&&t.\u0275\u0275contentQuery(i,m,5),a&2){let o;t.\u0275\u0275queryRefresh(o=t.\u0275\u0275loadQuery())&&(n._allTabs=o)}},viewQuery:function(a,n){if(a&1&&t.\u0275\u0275viewQuery(rt,5)(st,5)(h,5),a&2){let i;t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabBodyWrapper=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabHeader=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabBodies=i)}},hostAttrs:[1,"mat-mdc-tab-group"],hostVars:11,hostBindings:function(a,n){a&2&&(t.\u0275\u0275attribute("mat-align-tabs",n.alignTabs),t.\u0275\u0275classMap("mat-"+(n.color||"primary")),t.\u0275\u0275styleProp("--mat-tab-animation-duration",n.animationDuration),t.\u0275\u0275classProp("mat-mdc-tab-group-dynamic-height",n.dynamicHeight)("mat-mdc-tab-group-inverted-header",n.headerPosition==="below")("mat-mdc-tab-group-stretch-tabs",n.stretchTabs))},inputs:{color:"color",fitInkBarToContent:[2,"fitInkBarToContent","fitInkBarToContent",t.booleanAttribute],stretchTabs:[2,"mat-stretch-tabs","stretchTabs",t.booleanAttribute],alignTabs:[0,"mat-align-tabs","alignTabs"],dynamicHeight:[2,"dynamicHeight","dynamicHeight",t.booleanAttribute],selectedIndex:[2,"selectedIndex","selectedIndex",t.numberAttribute],headerPosition:"headerPosition",animationDuration:"animationDuration",contentTabIndex:[2,"contentTabIndex","contentTabIndex",t.numberAttribute],disablePagination:[2,"disablePagination","disablePagination",t.booleanAttribute],disableRipple:[2,"disableRipple","disableRipple",t.booleanAttribute],preserveContent:[2,"preserveContent","preserveContent",t.booleanAttribute],backgroundColor:"backgroundColor",ariaLabel:[0,"aria-label","ariaLabel"],ariaLabelledby:[0,"aria-labelledby","ariaLabelledby"]},outputs:{selectedIndexChange:"selectedIndexChange",focusChange:"focusChange",animationDone:"animationDone",selectedTabChange:"selectedTabChange"},exportAs:["matTabGroup"],features:[t.\u0275\u0275ProvidersFeature([{provide:O,useExisting:f}])],ngContentSelectors:D,decls:9,vars:8,consts:[["tabHeader",""],["tabBodyWrapper",""],["tabNode",""],[3,"indexFocused","selectFocusedIndex","selectedIndex","disableRipple","disablePagination","aria-label","aria-labelledby"],["role","tab","matTabLabelWrapper","","cdkMonitorElementFocus","",1,"mdc-tab","mat-mdc-tab","mat-focus-indicator",3,"id","mdc-tab--active","class","disabled","fitInkBarToContent"],[1,"mat-mdc-tab-body-wrapper"],["role","tabpanel",3,"id","class","content","position","animationDuration","preserveContent"],["role","tab","matTabLabelWrapper","","cdkMonitorElementFocus","",1,"mdc-tab","mat-mdc-tab","mat-focus-indicator",3,"click","cdkFocusChange","id","disabled","fitInkBarToContent"],[1,"mdc-tab__ripple"],["mat-ripple","",1,"mat-mdc-tab-ripple",3,"matRippleTrigger","matRippleDisabled"],[1,"mdc-tab__content"],[1,"mdc-tab__text-label"],[3,"cdkPortalOutlet"],["role","tabpanel",3,"_onCentered","_onCentering","_beforeCentering","id","content","position","animationDuration","preserveContent"]],template:function(a,n){a&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275elementStart(0,"mat-tab-header",3,0),t.\u0275\u0275listener("indexFocused",function(o){return n._focusChanged(o)})("selectFocusedIndex",function(o){return n.selectedIndex=o}),t.\u0275\u0275repeaterCreate(2,bt,8,17,"div",4,t.\u0275\u0275repeaterTrackByIdentity),t.\u0275\u0275elementEnd(),t.\u0275\u0275conditionalCreate(4,mt,1,0),t.\u0275\u0275elementStart(5,"div",5,1),t.\u0275\u0275repeaterCreate(7,pt,1,10,"mat-tab-body",6,t.\u0275\u0275repeaterTrackByIdentity),t.\u0275\u0275elementEnd()),a&2&&(t.\u0275\u0275property("selectedIndex",n.selectedIndex||0)("disableRipple",n.disableRipple)("disablePagination",n.disablePagination),t.\u0275\u0275ariaProperty("aria-label",n.ariaLabel)("aria-labelledby",n.ariaLabelledby),t.\u0275\u0275advance(2),t.\u0275\u0275repeater(n._tabs),t.\u0275\u0275advance(2),t.\u0275\u0275conditional(n._isServer?4:-1),t.\u0275\u0275advance(),t.\u0275\u0275classProp("_mat-animation-noopable",n._animationsDisabled()),t.\u0275\u0275advance(2),t.\u0275\u0275repeater(n._tabs))},dependencies:[y,p,x.CdkMonitorFocus,_.r6,E.CdkPortalOutlet,h],styles:[`.mdc-tab {
  min-width: 90px;
  padding: 0 24px;
  display: flex;
  flex: 1 0 auto;
  justify-content: center;
  box-sizing: border-box;
  border: none;
  outline: none;
  text-align: center;
  white-space: nowrap;
  cursor: pointer;
  z-index: 1;
  touch-action: manipulation;
}

.mdc-tab__content {
  display: flex;
  align-items: center;
  justify-content: center;
  height: inherit;
  pointer-events: none;
}

.mdc-tab__text-label {
  transition: 150ms color linear;
  display: inline-block;
  line-height: 1;
  z-index: 2;
}

.mdc-tab--active .mdc-tab__text-label {
  transition-delay: 100ms;
}

._mat-animation-noopable .mdc-tab__text-label {
  transition: none;
}

.mdc-tab-indicator {
  display: flex;
  position: absolute;
  top: 0;
  left: 0;
  justify-content: center;
  width: 100%;
  height: 100%;
  pointer-events: none;
  z-index: 1;
}

.mdc-tab-indicator__content {
  transition: var(--mat-tab-animation-duration, 250ms) transform cubic-bezier(0.4, 0, 0.2, 1);
  transform-origin: left;
  opacity: 0;
}

.mdc-tab-indicator__content--underline {
  align-self: flex-end;
  box-sizing: border-box;
  width: 100%;
  border-top-style: solid;
}

.mdc-tab-indicator--active .mdc-tab-indicator__content {
  opacity: 1;
}

._mat-animation-noopable .mdc-tab-indicator__content, .mdc-tab-indicator--no-transition .mdc-tab-indicator__content {
  transition: none;
}

.mat-mdc-tab-ripple.mat-mdc-tab-ripple {
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  pointer-events: none;
}

.mat-mdc-tab {
  -webkit-tap-highlight-color: transparent;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-decoration: none;
  background: none;
  height: var(--mat-tab-container-height, 48px);
  font-family: var(--mat-tab-label-text-font, var(--mat-sys-title-small-font));
  font-size: var(--mat-tab-label-text-size, var(--mat-sys-title-small-size));
  letter-spacing: var(--mat-tab-label-text-tracking, var(--mat-sys-title-small-tracking));
  line-height: var(--mat-tab-label-text-line-height, var(--mat-sys-title-small-line-height));
  font-weight: var(--mat-tab-label-text-weight, var(--mat-sys-title-small-weight));
}
.mat-mdc-tab.mdc-tab {
  flex-grow: 0;
}
.mat-mdc-tab .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-indicator-color, var(--mat-sys-primary));
  border-top-width: var(--mat-tab-active-indicator-height, 2px);
  border-radius: var(--mat-tab-active-indicator-shape, 0);
}
.mat-mdc-tab:hover .mdc-tab__text-label {
  color: var(--mat-tab-inactive-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab:focus .mdc-tab__text-label {
  color: var(--mat-tab-inactive-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active .mdc-tab__text-label {
  color: var(--mat-tab-active-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active .mdc-tab__ripple::before,
.mat-mdc-tab.mdc-tab--active .mat-ripple-element {
  background-color: var(--mat-tab-active-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active:hover .mdc-tab__text-label {
  color: var(--mat-tab-active-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active:hover .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-hover-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab.mdc-tab--active:focus .mdc-tab__text-label {
  color: var(--mat-tab-active-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active:focus .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-focus-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab.mat-mdc-tab-disabled {
  opacity: 0.4;
  pointer-events: none;
}
.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__content {
  pointer-events: none;
}
.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__ripple::before,
.mat-mdc-tab.mat-mdc-tab-disabled .mat-ripple-element {
  background-color: var(--mat-tab-disabled-ripple-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-tab .mdc-tab__ripple::before {
  content: "";
  display: block;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  opacity: 0;
  pointer-events: none;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab .mdc-tab__text-label {
  color: var(--mat-tab-inactive-label-text-color, var(--mat-sys-on-surface));
  display: inline-flex;
  align-items: center;
}
.mat-mdc-tab .mdc-tab__content {
  position: relative;
  pointer-events: auto;
}
.mat-mdc-tab:hover .mdc-tab__ripple::before {
  opacity: 0.04;
}
.mat-mdc-tab.cdk-program-focused .mdc-tab__ripple::before, .mat-mdc-tab.cdk-keyboard-focused .mdc-tab__ripple::before {
  opacity: 0.12;
}
.mat-mdc-tab .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-group.mat-mdc-tab-group-stretch-tabs > .mat-mdc-tab-header .mat-mdc-tab {
  flex-grow: 1;
}

.mat-mdc-tab-group {
  display: flex;
  flex-direction: column;
  max-width: 100%;
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination {
  background-color: var(--mat-tab-background-color);
}
.mat-mdc-tab-group.mat-tabs-with-background.mat-primary > .mat-mdc-tab-header .mat-mdc-tab .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background.mat-primary > .mat-mdc-tab-header .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-focus-indicator::before, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-focus-indicator::before {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-ripple-element, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mdc-tab__ripple::before, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-ripple-element, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mdc-tab__ripple::before {
  background-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header {
  flex-direction: column-reverse;
}
.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header .mdc-tab-indicator__content--underline {
  align-self: flex-start;
}

.mat-mdc-tab-body-wrapper {
  position: relative;
  overflow: hidden;
  display: flex;
  transition: height 500ms cubic-bezier(0.35, 0, 0.25, 1);
}
.mat-mdc-tab-body-wrapper._mat-animation-noopable {
  transition: none !important;
  animation: none !important;
}
`],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(f,[{type:t.Component,args:[{selector:"mat-tab-group",exportAs:"matTabGroup",encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.Default,providers:[{provide:O,useExisting:f}],host:{class:"mat-mdc-tab-group","[class]":'"mat-" + (color || "primary")',"[class.mat-mdc-tab-group-dynamic-height]":"dynamicHeight","[class.mat-mdc-tab-group-inverted-header]":'headerPosition === "below"',"[class.mat-mdc-tab-group-stretch-tabs]":"stretchTabs","[attr.mat-align-tabs]":"alignTabs","[style.--mat-tab-animation-duration]":"animationDuration"},imports:[y,p,x.CdkMonitorFocus,_.r6,E.CdkPortalOutlet,h],template:`<mat-tab-header #tabHeader
                [selectedIndex]="selectedIndex || 0"
                [disableRipple]="disableRipple"
                [disablePagination]="disablePagination"
                [aria-label]="ariaLabel"
                [aria-labelledby]="ariaLabelledby"
                (indexFocused)="_focusChanged($event)"
                (selectFocusedIndex)="selectedIndex = $event">

  @for (tab of _tabs; track tab) {
    <div class="mdc-tab mat-mdc-tab mat-focus-indicator"
        #tabNode
        role="tab"
        matTabLabelWrapper
        cdkMonitorElementFocus
        [id]="_getTabLabelId(tab, $index)"
        [attr.tabIndex]="_getTabIndex($index)"
        [attr.aria-posinset]="$index + 1"
        [attr.aria-setsize]="_tabs.length"
        [attr.aria-controls]="_getTabContentId($index)"
        [attr.aria-selected]="selectedIndex === $index"
        [attr.aria-label]="tab.ariaLabel || null"
        [attr.aria-labelledby]="(!tab.ariaLabel && tab.ariaLabelledby) ? tab.ariaLabelledby : null"
        [class.mdc-tab--active]="selectedIndex === $index"
        [class]="tab.labelClass"
        [disabled]="tab.disabled"
        [fitInkBarToContent]="fitInkBarToContent"
        (click)="_handleClick(tab, tabHeader, $index)"
        (cdkFocusChange)="_tabFocusChanged($event, $index)">
      <span class="mdc-tab__ripple"></span>

      <!-- Needs to be a separate element, because we can't put
          \`overflow: hidden\` on tab due to the ink bar. -->
      <div
        class="mat-mdc-tab-ripple"
        mat-ripple
        [matRippleTrigger]="tabNode"
        [matRippleDisabled]="tab.disabled || disableRipple"></div>

      <span class="mdc-tab__content">
        <span class="mdc-tab__text-label">
          <!--
            If there is a label template, use it, otherwise fall back to the text label.
            Note that we don't have indentation around the text label, because it adds
            whitespace around the text which breaks some internal tests.
          -->
          @if (tab.templateLabel) {
            <ng-template [cdkPortalOutlet]="tab.templateLabel"></ng-template>
          } @else {{{tab.textLabel}}}
        </span>
      </span>
    </div>
  }
</mat-tab-header>

<!--
  We need to project the content somewhere to avoid hydration errors. Some observations:
  1. This is only necessary on the server.
  2. We get a hydration error if there aren't any nodes after the \`ng-content\`.
  3. We get a hydration error if \`ng-content\` is wrapped in another element.
-->
@if (_isServer) {
  <ng-content/>
}

<div
  class="mat-mdc-tab-body-wrapper"
  [class._mat-animation-noopable]="_animationsDisabled()"
  #tabBodyWrapper>
  @for (tab of _tabs; track tab;) {
    <mat-tab-body role="tabpanel"
                 [id]="_getTabContentId($index)"
                 [attr.tabindex]="(contentTabIndex != null && selectedIndex === $index) ? contentTabIndex : null"
                 [attr.aria-labelledby]="_getTabLabelId(tab, $index)"
                 [attr.aria-hidden]="selectedIndex !== $index"
                 [class]="tab.bodyClass"
                 [content]="tab.content!"
                 [position]="tab.position!"
                 [animationDuration]="animationDuration"
                 [preserveContent]="preserveContent"
                 (_onCentered)="_removeTabBodyWrapperHeight()"
                 (_onCentering)="_setTabBodyWrapperHeight($event)"
                 (_beforeCentering)="_bodyCentered($event)"/>
  }
</div>
`,styles:[`.mdc-tab {
  min-width: 90px;
  padding: 0 24px;
  display: flex;
  flex: 1 0 auto;
  justify-content: center;
  box-sizing: border-box;
  border: none;
  outline: none;
  text-align: center;
  white-space: nowrap;
  cursor: pointer;
  z-index: 1;
  touch-action: manipulation;
}

.mdc-tab__content {
  display: flex;
  align-items: center;
  justify-content: center;
  height: inherit;
  pointer-events: none;
}

.mdc-tab__text-label {
  transition: 150ms color linear;
  display: inline-block;
  line-height: 1;
  z-index: 2;
}

.mdc-tab--active .mdc-tab__text-label {
  transition-delay: 100ms;
}

._mat-animation-noopable .mdc-tab__text-label {
  transition: none;
}

.mdc-tab-indicator {
  display: flex;
  position: absolute;
  top: 0;
  left: 0;
  justify-content: center;
  width: 100%;
  height: 100%;
  pointer-events: none;
  z-index: 1;
}

.mdc-tab-indicator__content {
  transition: var(--mat-tab-animation-duration, 250ms) transform cubic-bezier(0.4, 0, 0.2, 1);
  transform-origin: left;
  opacity: 0;
}

.mdc-tab-indicator__content--underline {
  align-self: flex-end;
  box-sizing: border-box;
  width: 100%;
  border-top-style: solid;
}

.mdc-tab-indicator--active .mdc-tab-indicator__content {
  opacity: 1;
}

._mat-animation-noopable .mdc-tab-indicator__content, .mdc-tab-indicator--no-transition .mdc-tab-indicator__content {
  transition: none;
}

.mat-mdc-tab-ripple.mat-mdc-tab-ripple {
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  pointer-events: none;
}

.mat-mdc-tab {
  -webkit-tap-highlight-color: transparent;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-decoration: none;
  background: none;
  height: var(--mat-tab-container-height, 48px);
  font-family: var(--mat-tab-label-text-font, var(--mat-sys-title-small-font));
  font-size: var(--mat-tab-label-text-size, var(--mat-sys-title-small-size));
  letter-spacing: var(--mat-tab-label-text-tracking, var(--mat-sys-title-small-tracking));
  line-height: var(--mat-tab-label-text-line-height, var(--mat-sys-title-small-line-height));
  font-weight: var(--mat-tab-label-text-weight, var(--mat-sys-title-small-weight));
}
.mat-mdc-tab.mdc-tab {
  flex-grow: 0;
}
.mat-mdc-tab .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-indicator-color, var(--mat-sys-primary));
  border-top-width: var(--mat-tab-active-indicator-height, 2px);
  border-radius: var(--mat-tab-active-indicator-shape, 0);
}
.mat-mdc-tab:hover .mdc-tab__text-label {
  color: var(--mat-tab-inactive-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab:focus .mdc-tab__text-label {
  color: var(--mat-tab-inactive-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active .mdc-tab__text-label {
  color: var(--mat-tab-active-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active .mdc-tab__ripple::before,
.mat-mdc-tab.mdc-tab--active .mat-ripple-element {
  background-color: var(--mat-tab-active-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active:hover .mdc-tab__text-label {
  color: var(--mat-tab-active-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active:hover .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-hover-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab.mdc-tab--active:focus .mdc-tab__text-label {
  color: var(--mat-tab-active-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab.mdc-tab--active:focus .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-focus-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab.mat-mdc-tab-disabled {
  opacity: 0.4;
  pointer-events: none;
}
.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__content {
  pointer-events: none;
}
.mat-mdc-tab.mat-mdc-tab-disabled .mdc-tab__ripple::before,
.mat-mdc-tab.mat-mdc-tab-disabled .mat-ripple-element {
  background-color: var(--mat-tab-disabled-ripple-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-tab .mdc-tab__ripple::before {
  content: "";
  display: block;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  opacity: 0;
  pointer-events: none;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab .mdc-tab__text-label {
  color: var(--mat-tab-inactive-label-text-color, var(--mat-sys-on-surface));
  display: inline-flex;
  align-items: center;
}
.mat-mdc-tab .mdc-tab__content {
  position: relative;
  pointer-events: auto;
}
.mat-mdc-tab:hover .mdc-tab__ripple::before {
  opacity: 0.04;
}
.mat-mdc-tab.cdk-program-focused .mdc-tab__ripple::before, .mat-mdc-tab.cdk-keyboard-focused .mdc-tab__ripple::before {
  opacity: 0.12;
}
.mat-mdc-tab .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-group.mat-mdc-tab-group-stretch-tabs > .mat-mdc-tab-header .mat-mdc-tab {
  flex-grow: 1;
}

.mat-mdc-tab-group {
  display: flex;
  flex-direction: column;
  max-width: 100%;
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination {
  background-color: var(--mat-tab-background-color);
}
.mat-mdc-tab-group.mat-tabs-with-background.mat-primary > .mat-mdc-tab-header .mat-mdc-tab .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background.mat-primary > .mat-mdc-tab-header .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-header .mat-mdc-tab:not(.mdc-tab--active) .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-focus-indicator::before, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-focus-indicator::before {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-ripple-element, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mdc-tab__ripple::before, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-ripple-element, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mdc-tab__ripple::before {
  background-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header .mat-mdc-tab-header-pagination-chevron, .mat-mdc-tab-group.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header {
  flex-direction: column-reverse;
}
.mat-mdc-tab-group.mat-mdc-tab-group-inverted-header .mdc-tab-indicator__content--underline {
  align-self: flex-start;
}

.mat-mdc-tab-body-wrapper {
  position: relative;
  overflow: hidden;
  display: flex;
  transition: height 500ms cubic-bezier(0.35, 0, 0.25, 1);
}
.mat-mdc-tab-body-wrapper._mat-animation-noopable {
  transition: none !important;
  animation: none !important;
}
`]}]}],()=>[],{_allTabs:[{type:t.ContentChildren,args:[m,{descendants:!0}]}],_tabBodies:[{type:t.ViewChildren,args:[h]}],_tabBodyWrapper:[{type:t.ViewChild,args:["tabBodyWrapper"]}],_tabHeader:[{type:t.ViewChild,args:["tabHeader"]}],color:[{type:t.Input}],fitInkBarToContent:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],stretchTabs:[{type:t.Input,args:[{alias:"mat-stretch-tabs",transform:t.booleanAttribute}]}],alignTabs:[{type:t.Input,args:[{alias:"mat-align-tabs"}]}],dynamicHeight:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],selectedIndex:[{type:t.Input,args:[{transform:t.numberAttribute}]}],headerPosition:[{type:t.Input}],animationDuration:[{type:t.Input}],contentTabIndex:[{type:t.Input,args:[{transform:t.numberAttribute}]}],disablePagination:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],disableRipple:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],preserveContent:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],backgroundColor:[{type:t.Input}],ariaLabel:[{type:t.Input,args:["aria-label"]}],ariaLabelledby:[{type:t.Input,args:["aria-labelledby"]}],selectedIndexChange:[{type:t.Output}],focusChange:[{type:t.Output}],animationDone:[{type:t.Output}],selectedTabChange:[{type:t.Output}]});class tt{index;tab}class k extends C{_focusedItem=(0,t.signal)(null,...ngDevMode?[{debugName:"_focusedItem"}]:[]);get fitInkBarToContent(){return this._fitInkBarToContent.value}set fitInkBarToContent(e){this._fitInkBarToContent.next(e),this._changeDetectorRef.markForCheck()}_fitInkBarToContent=new d.BehaviorSubject(!1);stretchTabs=!0;get animationDuration(){return this._animationDuration}set animationDuration(e){const a=e+"";this._animationDuration=/^\d+$/.test(a)?e+"ms":a}_animationDuration;_items;get backgroundColor(){return this._backgroundColor}set backgroundColor(e){const a=this._elementRef.nativeElement.classList;a.remove("mat-tabs-with-background",`mat-background-${this.backgroundColor}`),e&&a.add("mat-tabs-with-background",`mat-background-${e}`),this._backgroundColor=e}_backgroundColor;get disableRipple(){return this._disableRipple()}set disableRipple(e){this._disableRipple.set(e)}_disableRipple=(0,t.signal)(!1,...ngDevMode?[{debugName:"_disableRipple"}]:[]);color="primary";tabPanel;_tabListContainer;_tabList;_tabListInner;_nextPaginator;_previousPaginator;_inkBar;constructor(){const e=(0,t.inject)(W,{optional:!0});super(),this.disablePagination=e&&e.disablePagination!=null?e.disablePagination:!1,this.fitInkBarToContent=e&&e.fitInkBarToContent!=null?e.fitInkBarToContent:!1,this.stretchTabs=e&&e.stretchTabs!=null?e.stretchTabs:!0}_itemSelected(){}ngAfterContentInit(){this._inkBar=new z(this._items),this._items.changes.pipe((0,l.startWith)(null),(0,l.takeUntil)(this._destroyed)).subscribe(()=>this.updateActiveLink()),super.ngAfterContentInit(),this._keyManager.change.pipe((0,l.startWith)(null),(0,l.takeUntil)(this._destroyed)).subscribe(()=>this._focusedItem.set(this._keyManager?.activeItem||null))}ngAfterViewInit(){if(!this.tabPanel&&(typeof ngDevMode>"u"||ngDevMode))throw new Error("A mat-tab-nav-panel must be specified via [tabPanel].");super.ngAfterViewInit()}updateActiveLink(){if(!this._items)return;const e=this._items.toArray();for(let a=0;a<e.length;a++)if(e[a].active){this.selectedIndex=a,this.tabPanel&&(this.tabPanel._activeTabId=e[a].id),this._focusedItem.set(e[a]),this._changeDetectorRef.markForCheck();return}this.selectedIndex=-1}_getRole(){return this.tabPanel?"tablist":this._elementRef.nativeElement.getAttribute("role")}_hasFocus(e){return this._keyManager?.activeItem===e}static \u0275fac=function(a){return new(a||k)};static \u0275cmp=t.\u0275\u0275defineComponent({type:k,selectors:[["","mat-tab-nav-bar",""]],contentQueries:function(a,n,i){if(a&1&&t.\u0275\u0275contentQuery(i,v,5),a&2){let o;t.\u0275\u0275queryRefresh(o=t.\u0275\u0275loadQuery())&&(n._items=o)}},viewQuery:function(a,n){if(a&1&&t.\u0275\u0275viewQuery(K,7)(U,7)(Z,7)(Y,5)(q,5),a&2){let i;t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabListContainer=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabList=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._tabListInner=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._nextPaginator=i.first),t.\u0275\u0275queryRefresh(i=t.\u0275\u0275loadQuery())&&(n._previousPaginator=i.first)}},hostAttrs:[1,"mat-mdc-tab-nav-bar","mat-mdc-tab-header"],hostVars:17,hostBindings:function(a,n){a&2&&(t.\u0275\u0275attribute("role",n._getRole()),t.\u0275\u0275styleProp("--mat-tab-animation-duration",n.animationDuration),t.\u0275\u0275classProp("mat-mdc-tab-header-pagination-controls-enabled",n._showPaginationControls)("mat-mdc-tab-header-rtl",n._getLayoutDirection()=="rtl")("mat-mdc-tab-nav-bar-stretch-tabs",n.stretchTabs)("mat-primary",n.color!=="warn"&&n.color!=="accent")("mat-accent",n.color==="accent")("mat-warn",n.color==="warn")("_mat-animation-noopable",n._animationsDisabled))},inputs:{fitInkBarToContent:[2,"fitInkBarToContent","fitInkBarToContent",t.booleanAttribute],stretchTabs:[2,"mat-stretch-tabs","stretchTabs",t.booleanAttribute],animationDuration:"animationDuration",backgroundColor:"backgroundColor",disableRipple:[2,"disableRipple","disableRipple",t.booleanAttribute],color:"color",tabPanel:"tabPanel"},exportAs:["matTabNavBar","matTabNav"],features:[t.\u0275\u0275InheritDefinitionFeature],attrs:ht,ngContentSelectors:D,decls:13,vars:6,consts:[["previousPaginator",""],["tabListContainer",""],["tabList",""],["tabListInner",""],["nextPaginator",""],["mat-ripple","",1,"mat-mdc-tab-header-pagination","mat-mdc-tab-header-pagination-before",3,"click","mousedown","touchend","matRippleDisabled"],[1,"mat-mdc-tab-header-pagination-chevron"],[1,"mat-mdc-tab-link-container",3,"keydown"],[1,"mat-mdc-tab-list",3,"cdkObserveContent"],[1,"mat-mdc-tab-links"],["mat-ripple","",1,"mat-mdc-tab-header-pagination","mat-mdc-tab-header-pagination-after",3,"mousedown","click","touchend","matRippleDisabled"]],template:function(a,n){a&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275elementStart(0,"div",5,0),t.\u0275\u0275listener("click",function(){return n._handlePaginatorClick("before")})("mousedown",function(o){return n._handlePaginatorPress("before",o)})("touchend",function(){return n._stopInterval()}),t.\u0275\u0275element(2,"div",6),t.\u0275\u0275elementEnd(),t.\u0275\u0275elementStart(3,"div",7,1),t.\u0275\u0275listener("keydown",function(o){return n._handleKeydown(o)}),t.\u0275\u0275elementStart(5,"div",8,2),t.\u0275\u0275listener("cdkObserveContent",function(){return n._onContentChanges()}),t.\u0275\u0275elementStart(7,"div",9,3),t.\u0275\u0275projection(9),t.\u0275\u0275elementEnd()()(),t.\u0275\u0275elementStart(10,"div",10,4),t.\u0275\u0275listener("mousedown",function(o){return n._handlePaginatorPress("after",o)})("click",function(){return n._handlePaginatorClick("after")})("touchend",function(){return n._stopInterval()}),t.\u0275\u0275element(12,"div",6),t.\u0275\u0275elementEnd()),a&2&&(t.\u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled",n._disableScrollBefore),t.\u0275\u0275property("matRippleDisabled",n._disableScrollBefore||n.disableRipple),t.\u0275\u0275advance(10),t.\u0275\u0275classProp("mat-mdc-tab-header-pagination-disabled",n._disableScrollAfter),t.\u0275\u0275property("matRippleDisabled",n._disableScrollAfter||n.disableRipple))},dependencies:[_.r6,A.CdkObserveContent],styles:[`.mdc-tab {
  min-width: 90px;
  padding: 0 24px;
  display: flex;
  flex: 1 0 auto;
  justify-content: center;
  box-sizing: border-box;
  border: none;
  outline: none;
  text-align: center;
  white-space: nowrap;
  cursor: pointer;
  z-index: 1;
  touch-action: manipulation;
}

.mdc-tab__content {
  display: flex;
  align-items: center;
  justify-content: center;
  height: inherit;
  pointer-events: none;
}

.mdc-tab__text-label {
  transition: 150ms color linear;
  display: inline-block;
  line-height: 1;
  z-index: 2;
}

.mdc-tab--active .mdc-tab__text-label {
  transition-delay: 100ms;
}

._mat-animation-noopable .mdc-tab__text-label {
  transition: none;
}

.mdc-tab-indicator {
  display: flex;
  position: absolute;
  top: 0;
  left: 0;
  justify-content: center;
  width: 100%;
  height: 100%;
  pointer-events: none;
  z-index: 1;
}

.mdc-tab-indicator__content {
  transition: var(--mat-tab-animation-duration, 250ms) transform cubic-bezier(0.4, 0, 0.2, 1);
  transform-origin: left;
  opacity: 0;
}

.mdc-tab-indicator__content--underline {
  align-self: flex-end;
  box-sizing: border-box;
  width: 100%;
  border-top-style: solid;
}

.mdc-tab-indicator--active .mdc-tab-indicator__content {
  opacity: 1;
}

._mat-animation-noopable .mdc-tab-indicator__content, .mdc-tab-indicator--no-transition .mdc-tab-indicator__content {
  transition: none;
}

.mat-mdc-tab-ripple.mat-mdc-tab-ripple {
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  pointer-events: none;
}

.mat-mdc-tab-header {
  display: flex;
  overflow: hidden;
  position: relative;
  flex-shrink: 0;
}

.mdc-tab-indicator .mdc-tab-indicator__content {
  transition-duration: var(--mat-tab-animation-duration, 250ms);
}

.mat-mdc-tab-header-pagination {
  -webkit-user-select: none;
  user-select: none;
  position: relative;
  display: none;
  justify-content: center;
  align-items: center;
  min-width: 32px;
  cursor: pointer;
  z-index: 2;
  -webkit-tap-highlight-color: transparent;
  touch-action: none;
  box-sizing: content-box;
  outline: 0;
}
.mat-mdc-tab-header-pagination::-moz-focus-inner {
  border: 0;
}
.mat-mdc-tab-header-pagination .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination {
  display: flex;
}

.mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after {
  padding-left: 4px;
}
.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(-135deg);
}

.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-pagination-after {
  padding-right: 4px;
}
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(45deg);
}

.mat-mdc-tab-header-pagination-chevron {
  border-style: solid;
  border-width: 2px 2px 0 0;
  height: 8px;
  width: 8px;
  border-color: var(--mat-tab-pagination-icon-color, var(--mat-sys-on-surface));
}

.mat-mdc-tab-header-pagination-disabled {
  box-shadow: none;
  cursor: default;
  pointer-events: none;
}
.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron {
  opacity: 0.4;
}

.mat-mdc-tab-list {
  flex-grow: 1;
  position: relative;
  transition: transform 500ms cubic-bezier(0.35, 0, 0.25, 1);
}
._mat-animation-noopable .mat-mdc-tab-list {
  transition: none;
}

.mat-mdc-tab-links {
  display: flex;
  flex: 1 0 auto;
}
[mat-align-tabs=center] > .mat-mdc-tab-link-container .mat-mdc-tab-links {
  justify-content: center;
}
[mat-align-tabs=end] > .mat-mdc-tab-link-container .mat-mdc-tab-links {
  justify-content: flex-end;
}
.cdk-drop-list .mat-mdc-tab-links, .mat-mdc-tab-links.cdk-drop-list {
  min-height: var(--mat-tab-container-height, 48px);
}

.mat-mdc-tab-link-container {
  display: flex;
  flex-grow: 1;
  overflow: hidden;
  z-index: 1;
  border-bottom-style: solid;
  border-bottom-width: var(--mat-tab-divider-height, 1px);
  border-bottom-color: var(--mat-tab-divider-color, var(--mat-sys-surface-variant));
}

.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination {
  background-color: var(--mat-tab-background-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary > .mat-mdc-tab-link-container .mat-mdc-tab-link .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary > .mat-mdc-tab-link-container .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-focus-indicator::before, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-focus-indicator::before {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-ripple-element, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mdc-tab__ripple::before, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-ripple-element, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mdc-tab__ripple::before {
  background-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron {
  color: var(--mat-tab-foreground-color);
}
`],encapsulation:2})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(k,[{type:t.Component,args:[{selector:"[mat-tab-nav-bar]",exportAs:"matTabNavBar, matTabNav",host:{"[attr.role]":"_getRole()",class:"mat-mdc-tab-nav-bar mat-mdc-tab-header","[class.mat-mdc-tab-header-pagination-controls-enabled]":"_showPaginationControls","[class.mat-mdc-tab-header-rtl]":"_getLayoutDirection() == 'rtl'","[class.mat-mdc-tab-nav-bar-stretch-tabs]":"stretchTabs","[class.mat-primary]":'color !== "warn" && color !== "accent"',"[class.mat-accent]":'color === "accent"',"[class.mat-warn]":'color === "warn"',"[class._mat-animation-noopable]":"_animationsDisabled","[style.--mat-tab-animation-duration]":"animationDuration"},encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.Default,imports:[_.r6,A.CdkObserveContent],template:`<!--
 Note that this intentionally uses a \`div\` instead of a \`button\`, because it's not part of
 the regular tabs flow and is only here to support mouse users. It should also not be focusable.
-->
<div class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-before"
     #previousPaginator
     mat-ripple
     [matRippleDisabled]="_disableScrollBefore || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollBefore"
     (click)="_handlePaginatorClick('before')"
     (mousedown)="_handlePaginatorPress('before', $event)"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</div>

<div class="mat-mdc-tab-link-container" #tabListContainer (keydown)="_handleKeydown($event)">
  <div class="mat-mdc-tab-list" #tabList (cdkObserveContent)="_onContentChanges()">
    <div class="mat-mdc-tab-links" #tabListInner>
      <ng-content></ng-content>
    </div>
  </div>
</div>

<div class="mat-mdc-tab-header-pagination mat-mdc-tab-header-pagination-after"
     #nextPaginator
     mat-ripple
     [matRippleDisabled]="_disableScrollAfter || disableRipple"
     [class.mat-mdc-tab-header-pagination-disabled]="_disableScrollAfter"
     (mousedown)="_handlePaginatorPress('after', $event)"
     (click)="_handlePaginatorClick('after')"
     (touchend)="_stopInterval()">
  <div class="mat-mdc-tab-header-pagination-chevron"></div>
</div>
`,styles:[`.mdc-tab {
  min-width: 90px;
  padding: 0 24px;
  display: flex;
  flex: 1 0 auto;
  justify-content: center;
  box-sizing: border-box;
  border: none;
  outline: none;
  text-align: center;
  white-space: nowrap;
  cursor: pointer;
  z-index: 1;
  touch-action: manipulation;
}

.mdc-tab__content {
  display: flex;
  align-items: center;
  justify-content: center;
  height: inherit;
  pointer-events: none;
}

.mdc-tab__text-label {
  transition: 150ms color linear;
  display: inline-block;
  line-height: 1;
  z-index: 2;
}

.mdc-tab--active .mdc-tab__text-label {
  transition-delay: 100ms;
}

._mat-animation-noopable .mdc-tab__text-label {
  transition: none;
}

.mdc-tab-indicator {
  display: flex;
  position: absolute;
  top: 0;
  left: 0;
  justify-content: center;
  width: 100%;
  height: 100%;
  pointer-events: none;
  z-index: 1;
}

.mdc-tab-indicator__content {
  transition: var(--mat-tab-animation-duration, 250ms) transform cubic-bezier(0.4, 0, 0.2, 1);
  transform-origin: left;
  opacity: 0;
}

.mdc-tab-indicator__content--underline {
  align-self: flex-end;
  box-sizing: border-box;
  width: 100%;
  border-top-style: solid;
}

.mdc-tab-indicator--active .mdc-tab-indicator__content {
  opacity: 1;
}

._mat-animation-noopable .mdc-tab-indicator__content, .mdc-tab-indicator--no-transition .mdc-tab-indicator__content {
  transition: none;
}

.mat-mdc-tab-ripple.mat-mdc-tab-ripple {
  position: absolute;
  top: 0;
  left: 0;
  bottom: 0;
  right: 0;
  pointer-events: none;
}

.mat-mdc-tab-header {
  display: flex;
  overflow: hidden;
  position: relative;
  flex-shrink: 0;
}

.mdc-tab-indicator .mdc-tab-indicator__content {
  transition-duration: var(--mat-tab-animation-duration, 250ms);
}

.mat-mdc-tab-header-pagination {
  -webkit-user-select: none;
  user-select: none;
  position: relative;
  display: none;
  justify-content: center;
  align-items: center;
  min-width: 32px;
  cursor: pointer;
  z-index: 2;
  -webkit-tap-highlight-color: transparent;
  touch-action: none;
  box-sizing: content-box;
  outline: 0;
}
.mat-mdc-tab-header-pagination::-moz-focus-inner {
  border: 0;
}
.mat-mdc-tab-header-pagination .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-header-pagination-controls-enabled .mat-mdc-tab-header-pagination {
  display: flex;
}

.mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after {
  padding-left: 4px;
}
.mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(-135deg);
}

.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before,
.mat-mdc-tab-header-pagination-after {
  padding-right: 4px;
}
.mat-mdc-tab-header-rtl .mat-mdc-tab-header-pagination-before .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-header-pagination-after .mat-mdc-tab-header-pagination-chevron {
  transform: rotate(45deg);
}

.mat-mdc-tab-header-pagination-chevron {
  border-style: solid;
  border-width: 2px 2px 0 0;
  height: 8px;
  width: 8px;
  border-color: var(--mat-tab-pagination-icon-color, var(--mat-sys-on-surface));
}

.mat-mdc-tab-header-pagination-disabled {
  box-shadow: none;
  cursor: default;
  pointer-events: none;
}
.mat-mdc-tab-header-pagination-disabled .mat-mdc-tab-header-pagination-chevron {
  opacity: 0.4;
}

.mat-mdc-tab-list {
  flex-grow: 1;
  position: relative;
  transition: transform 500ms cubic-bezier(0.35, 0, 0.25, 1);
}
._mat-animation-noopable .mat-mdc-tab-list {
  transition: none;
}

.mat-mdc-tab-links {
  display: flex;
  flex: 1 0 auto;
}
[mat-align-tabs=center] > .mat-mdc-tab-link-container .mat-mdc-tab-links {
  justify-content: center;
}
[mat-align-tabs=end] > .mat-mdc-tab-link-container .mat-mdc-tab-links {
  justify-content: flex-end;
}
.cdk-drop-list .mat-mdc-tab-links, .mat-mdc-tab-links.cdk-drop-list {
  min-height: var(--mat-tab-container-height, 48px);
}

.mat-mdc-tab-link-container {
  display: flex;
  flex-grow: 1;
  overflow: hidden;
  z-index: 1;
  border-bottom-style: solid;
  border-bottom-width: var(--mat-tab-divider-height, 1px);
  border-bottom-color: var(--mat-tab-divider-color, var(--mat-sys-surface-variant));
}

.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination {
  background-color: var(--mat-tab-background-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary > .mat-mdc-tab-link-container .mat-mdc-tab-link .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background.mat-primary > .mat-mdc-tab-link-container .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab__text-label {
  color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background:not(.mat-primary) > .mat-mdc-tab-link-container .mat-mdc-tab-link:not(.mdc-tab--active) .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-focus-indicator::before, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron,
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-focus-indicator::before {
  border-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-ripple-element, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mdc-tab__ripple::before, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-ripple-element, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mdc-tab__ripple::before {
  background-color: var(--mat-tab-foreground-color);
}
.mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-link-container .mat-mdc-tab-header-pagination-chevron, .mat-mdc-tab-nav-bar.mat-tabs-with-background > .mat-mdc-tab-header-pagination .mat-mdc-tab-header-pagination-chevron {
  color: var(--mat-tab-foreground-color);
}
`]}]}],()=>[],{fitInkBarToContent:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],stretchTabs:[{type:t.Input,args:[{alias:"mat-stretch-tabs",transform:t.booleanAttribute}]}],animationDuration:[{type:t.Input}],_items:[{type:t.ContentChildren,args:[(0,t.forwardRef)(()=>v),{descendants:!0}]}],backgroundColor:[{type:t.Input}],disableRipple:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],color:[{type:t.Input}],tabPanel:[{type:t.Input}],_tabListContainer:[{type:t.ViewChild,args:["tabListContainer",{static:!0}]}],_tabList:[{type:t.ViewChild,args:["tabList",{static:!0}]}],_tabListInner:[{type:t.ViewChild,args:["tabListInner",{static:!0}]}],_nextPaginator:[{type:t.ViewChild,args:["nextPaginator"]}],_previousPaginator:[{type:t.ViewChild,args:["previousPaginator"]}]});class v extends P{_tabNavBar=(0,t.inject)(k);elementRef=(0,t.inject)(t.ElementRef);_focusMonitor=(0,t.inject)(x.FocusMonitor);_destroyed=new d.Subject;_isActive=!1;_tabIndex=(0,t.computed)(()=>this._tabNavBar._focusedItem()===this?this.tabIndex:-1,...ngDevMode?[{debugName:"_tabIndex"}]:[]);get active(){return this._isActive}set active(e){e!==this._isActive&&(this._isActive=e,this._tabNavBar.updateActiveLink())}disabled=!1;get disableRipple(){return this._disableRipple()}set disableRipple(e){this._disableRipple.set(e)}_disableRipple=(0,t.signal)(!1,...ngDevMode?[{debugName:"_disableRipple"}]:[]);tabIndex=0;rippleConfig;get rippleDisabled(){return this.disabled||this.disableRipple||this._tabNavBar.disableRipple||!!this.rippleConfig.disabled}id=(0,t.inject)(x._IdGenerator).getId("mat-tab-link-");constructor(){super(),(0,t.inject)($._CdkPrivateStyleLoader).load(Q.A);const e=(0,t.inject)(_.$E,{optional:!0}),a=(0,t.inject)(new t.HostAttributeToken("tabindex"),{optional:!0});this.rippleConfig=e||{},this.tabIndex=a==null?0:parseInt(a)||0,(0,B.Rc)()&&(this.rippleConfig.animation={enterDuration:0,exitDuration:0}),this._tabNavBar._fitInkBarToContent.pipe((0,l.takeUntil)(this._destroyed)).subscribe(n=>{this.fitInkBarToContent=n})}focus(){this.elementRef.nativeElement.focus()}ngAfterViewInit(){this._focusMonitor.monitor(this.elementRef)}ngOnDestroy(){this._destroyed.next(),this._destroyed.complete(),super.ngOnDestroy(),this._focusMonitor.stopMonitoring(this.elementRef)}_handleFocus(){this._tabNavBar.focusIndex=this._tabNavBar._items.toArray().indexOf(this)}_handleKeydown(e){(e.keyCode===w.SPACE||e.keyCode===w.ENTER)&&(this.disabled?e.preventDefault():this._tabNavBar.tabPanel&&(e.keyCode===w.SPACE&&e.preventDefault(),this.elementRef.nativeElement.click()))}_getAriaControls(){return this._tabNavBar.tabPanel?this._tabNavBar.tabPanel?.id:this.elementRef.nativeElement.getAttribute("aria-controls")}_getAriaSelected(){return this._tabNavBar.tabPanel?this.active?"true":"false":this.elementRef.nativeElement.getAttribute("aria-selected")}_getAriaCurrent(){return this.active&&!this._tabNavBar.tabPanel?"page":null}_getRole(){return this._tabNavBar.tabPanel?"tab":this.elementRef.nativeElement.getAttribute("role")}static \u0275fac=function(a){return new(a||v)};static \u0275cmp=t.\u0275\u0275defineComponent({type:v,selectors:[["","mat-tab-link",""],["","matTabLink",""]],hostAttrs:[1,"mdc-tab","mat-mdc-tab-link","mat-focus-indicator"],hostVars:11,hostBindings:function(a,n){a&1&&t.\u0275\u0275listener("focus",function(){return n._handleFocus()})("keydown",function(o){return n._handleKeydown(o)}),a&2&&(t.\u0275\u0275attribute("aria-controls",n._getAriaControls())("aria-current",n._getAriaCurrent())("aria-disabled",n.disabled)("aria-selected",n._getAriaSelected())("id",n.id)("tabIndex",n._tabIndex())("role",n._getRole()),t.\u0275\u0275classProp("mat-mdc-tab-disabled",n.disabled)("mdc-tab--active",n.active))},inputs:{active:[2,"active","active",t.booleanAttribute],disabled:[2,"disabled","disabled",t.booleanAttribute],disableRipple:[2,"disableRipple","disableRipple",t.booleanAttribute],tabIndex:[2,"tabIndex","tabIndex",e=>e==null?0:(0,t.numberAttribute)(e)],id:"id"},exportAs:["matTabLink"],features:[t.\u0275\u0275InheritDefinitionFeature],attrs:ut,ngContentSelectors:D,decls:5,vars:2,consts:[[1,"mdc-tab__ripple"],["mat-ripple","",1,"mat-mdc-tab-ripple",3,"matRippleTrigger","matRippleDisabled"],[1,"mdc-tab__content"],[1,"mdc-tab__text-label"]],template:function(a,n){a&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275element(0,"span",0)(1,"div",1),t.\u0275\u0275elementStart(2,"span",2)(3,"span",3),t.\u0275\u0275projection(4),t.\u0275\u0275elementEnd()()),a&2&&(t.\u0275\u0275advance(),t.\u0275\u0275property("matRippleTrigger",n.elementRef.nativeElement)("matRippleDisabled",n.rippleDisabled))},dependencies:[_.r6],styles:[`.mat-mdc-tab-link {
  -webkit-tap-highlight-color: transparent;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-decoration: none;
  background: none;
  height: var(--mat-tab-container-height, 48px);
  font-family: var(--mat-tab-label-text-font, var(--mat-sys-title-small-font));
  font-size: var(--mat-tab-label-text-size, var(--mat-sys-title-small-size));
  letter-spacing: var(--mat-tab-label-text-tracking, var(--mat-sys-title-small-tracking));
  line-height: var(--mat-tab-label-text-line-height, var(--mat-sys-title-small-line-height));
  font-weight: var(--mat-tab-label-text-weight, var(--mat-sys-title-small-weight));
}
.mat-mdc-tab-link.mdc-tab {
  flex-grow: 0;
}
.mat-mdc-tab-link .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-indicator-color, var(--mat-sys-primary));
  border-top-width: var(--mat-tab-active-indicator-height, 2px);
  border-radius: var(--mat-tab-active-indicator-shape, 0);
}
.mat-mdc-tab-link:hover .mdc-tab__text-label {
  color: var(--mat-tab-inactive-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link:focus .mdc-tab__text-label {
  color: var(--mat-tab-inactive-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active .mdc-tab__text-label {
  color: var(--mat-tab-active-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active .mdc-tab__ripple::before,
.mat-mdc-tab-link.mdc-tab--active .mat-ripple-element {
  background-color: var(--mat-tab-active-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab__text-label {
  color: var(--mat-tab-active-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-hover-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab__text-label {
  color: var(--mat-tab-active-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-focus-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab-link.mat-mdc-tab-disabled {
  opacity: 0.4;
  pointer-events: none;
}
.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__content {
  pointer-events: none;
}
.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__ripple::before,
.mat-mdc-tab-link.mat-mdc-tab-disabled .mat-ripple-element {
  background-color: var(--mat-tab-disabled-ripple-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-tab-link .mdc-tab__ripple::before {
  content: "";
  display: block;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  opacity: 0;
  pointer-events: none;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link .mdc-tab__text-label {
  color: var(--mat-tab-inactive-label-text-color, var(--mat-sys-on-surface));
  display: inline-flex;
  align-items: center;
}
.mat-mdc-tab-link .mdc-tab__content {
  position: relative;
  pointer-events: auto;
}
.mat-mdc-tab-link:hover .mdc-tab__ripple::before {
  opacity: 0.04;
}
.mat-mdc-tab-link.cdk-program-focused .mdc-tab__ripple::before, .mat-mdc-tab-link.cdk-keyboard-focused .mdc-tab__ripple::before {
  opacity: 0.12;
}
.mat-mdc-tab-link .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-header.mat-mdc-tab-nav-bar-stretch-tabs .mat-mdc-tab-link {
  flex-grow: 1;
}
.mat-mdc-tab-link::before {
  margin: 5px;
}

@media (max-width: 599px) {
  .mat-mdc-tab-link {
    min-width: 72px;
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(v,[{type:t.Component,args:[{selector:"[mat-tab-link], [matTabLink]",exportAs:"matTabLink",changeDetection:t.ChangeDetectionStrategy.OnPush,encapsulation:t.ViewEncapsulation.None,host:{class:"mdc-tab mat-mdc-tab-link mat-focus-indicator","[attr.aria-controls]":"_getAriaControls()","[attr.aria-current]":"_getAriaCurrent()","[attr.aria-disabled]":"disabled","[attr.aria-selected]":"_getAriaSelected()","[attr.id]":"id","[attr.tabIndex]":"_tabIndex()","[attr.role]":"_getRole()","[class.mat-mdc-tab-disabled]":"disabled","[class.mdc-tab--active]":"active","(focus)":"_handleFocus()","(keydown)":"_handleKeydown($event)"},imports:[_.r6],template:`<span class="mdc-tab__ripple"></span>

<div
  class="mat-mdc-tab-ripple"
  mat-ripple
  [matRippleTrigger]="elementRef.nativeElement"
  [matRippleDisabled]="rippleDisabled"></div>

<span class="mdc-tab__content">
  <span class="mdc-tab__text-label">
    <ng-content></ng-content>
  </span>
</span>

`,styles:[`.mat-mdc-tab-link {
  -webkit-tap-highlight-color: transparent;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-decoration: none;
  background: none;
  height: var(--mat-tab-container-height, 48px);
  font-family: var(--mat-tab-label-text-font, var(--mat-sys-title-small-font));
  font-size: var(--mat-tab-label-text-size, var(--mat-sys-title-small-size));
  letter-spacing: var(--mat-tab-label-text-tracking, var(--mat-sys-title-small-tracking));
  line-height: var(--mat-tab-label-text-line-height, var(--mat-sys-title-small-line-height));
  font-weight: var(--mat-tab-label-text-weight, var(--mat-sys-title-small-weight));
}
.mat-mdc-tab-link.mdc-tab {
  flex-grow: 0;
}
.mat-mdc-tab-link .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-indicator-color, var(--mat-sys-primary));
  border-top-width: var(--mat-tab-active-indicator-height, 2px);
  border-radius: var(--mat-tab-active-indicator-shape, 0);
}
.mat-mdc-tab-link:hover .mdc-tab__text-label {
  color: var(--mat-tab-inactive-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link:focus .mdc-tab__text-label {
  color: var(--mat-tab-inactive-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active .mdc-tab__text-label {
  color: var(--mat-tab-active-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active .mdc-tab__ripple::before,
.mat-mdc-tab-link.mdc-tab--active .mat-ripple-element {
  background-color: var(--mat-tab-active-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab__text-label {
  color: var(--mat-tab-active-hover-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active:hover .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-hover-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab__text-label {
  color: var(--mat-tab-active-focus-label-text-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link.mdc-tab--active:focus .mdc-tab-indicator__content--underline {
  border-color: var(--mat-tab-active-focus-indicator-color, var(--mat-sys-primary));
}
.mat-mdc-tab-link.mat-mdc-tab-disabled {
  opacity: 0.4;
  pointer-events: none;
}
.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__content {
  pointer-events: none;
}
.mat-mdc-tab-link.mat-mdc-tab-disabled .mdc-tab__ripple::before,
.mat-mdc-tab-link.mat-mdc-tab-disabled .mat-ripple-element {
  background-color: var(--mat-tab-disabled-ripple-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-tab-link .mdc-tab__ripple::before {
  content: "";
  display: block;
  position: absolute;
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  opacity: 0;
  pointer-events: none;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-link .mdc-tab__text-label {
  color: var(--mat-tab-inactive-label-text-color, var(--mat-sys-on-surface));
  display: inline-flex;
  align-items: center;
}
.mat-mdc-tab-link .mdc-tab__content {
  position: relative;
  pointer-events: auto;
}
.mat-mdc-tab-link:hover .mdc-tab__ripple::before {
  opacity: 0.04;
}
.mat-mdc-tab-link.cdk-program-focused .mdc-tab__ripple::before, .mat-mdc-tab-link.cdk-keyboard-focused .mdc-tab__ripple::before {
  opacity: 0.12;
}
.mat-mdc-tab-link .mat-ripple-element {
  opacity: 0.12;
  background-color: var(--mat-tab-inactive-ripple-color, var(--mat-sys-on-surface));
}
.mat-mdc-tab-header.mat-mdc-tab-nav-bar-stretch-tabs .mat-mdc-tab-link {
  flex-grow: 1;
}
.mat-mdc-tab-link::before {
  margin: 5px;
}

@media (max-width: 599px) {
  .mat-mdc-tab-link {
    min-width: 72px;
  }
}
`]}]}],()=>[],{active:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],disabled:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],disableRipple:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],tabIndex:[{type:t.Input,args:[{transform:r=>r==null?0:(0,t.numberAttribute)(r)}]}],id:[{type:t.Input}]});class T{id=(0,t.inject)(x._IdGenerator).getId("mat-tab-nav-panel-");_activeTabId;static \u0275fac=function(a){return new(a||T)};static \u0275cmp=t.\u0275\u0275defineComponent({type:T,selectors:[["mat-tab-nav-panel"]],hostAttrs:["role","tabpanel",1,"mat-mdc-tab-nav-panel"],hostVars:2,hostBindings:function(a,n){a&2&&t.\u0275\u0275attribute("aria-labelledby",n._activeTabId)("id",n.id)},inputs:{id:"id"},exportAs:["matTabNavPanel"],ngContentSelectors:D,decls:1,vars:0,template:function(a,n){a&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275projection(0))},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(T,[{type:t.Component,args:[{selector:"mat-tab-nav-panel",exportAs:"matTabNavPanel",template:"<ng-content></ng-content>",host:{"[attr.aria-labelledby]":"_activeTabId","[attr.id]":"id",class:"mat-mdc-tab-nav-panel",role:"tabpanel"},encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.OnPush}]}],null,{id:[{type:t.Input}]});class R{static \u0275fac=function(a){return new(a||R)};static \u0275mod=t.\u0275\u0275defineNgModule({type:R});static \u0275inj=t.\u0275\u0275defineInjector({imports:[L.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(R,[{type:t.NgModule,args:[{imports:[b,c,m,f,k,T,v],exports:[L.BidiModule,b,c,m,f,k,T,v]}]}],null,null)}}]);
