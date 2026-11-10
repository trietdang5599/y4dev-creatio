(self.webpackChunkapp_studio_enterprise_relationship_diagram=self.webpackChunkapp_studio_enterprise_relationship_diagram||[]).push([[6865],{48827(w,v,i){i.d(v,{_:()=>_,e:()=>p});var r=i(39638);class _{isErrorState(s,m){return!!(s&&s.invalid&&(s.dirty||m&&m.submitted))}static \u0275fac=function(m){return new(m||_)};static \u0275prov=r.\u0275\u0275defineInjectable({token:_,factory:_.\u0275fac})}(typeof ngDevMode>"u"||ngDevMode)&&r.\u0275setClassMetadata(_,[{type:r.Injectable}],null,null);class p{isErrorState(s,m){return!!(s&&s.invalid&&(s.touched||m&&m.submitted))}static \u0275fac=function(m){return new(m||p)};static \u0275prov=r.\u0275\u0275defineInjectable({token:p,factory:p.\u0275fac,providedIn:"root"})}(typeof ngDevMode>"u"||ngDevMode)&&r.\u0275setClassMetadata(p,[{type:r.Injectable,args:[{providedIn:"root"}]}],null,null)},3146(w,v,i){i.d(v,{X:()=>r});class r{_defaultMatcher;ngControl;_parentFormGroup;_parentForm;_stateChanges;errorState=!1;matcher;constructor(p,o,s,m,t){this._defaultMatcher=p,this.ngControl=o,this._parentFormGroup=s,this._parentForm=m,this._stateChanges=t}updateErrorState(){const p=this.errorState,o=this._parentFormGroup||this._parentForm,s=this.matcher||this._defaultMatcher,m=this.ngControl?this.ngControl.control:null,t=s?.isErrorState(m,o)??!1;t!==p&&(this.errorState=t,this._stateChanges.next())}}},29344(w,v,i){i.r(v),i.d(v,{MAT_ERROR:()=>r.EJ,MAT_FORM_FIELD:()=>r.xb,MAT_FORM_FIELD_DEFAULT_OPTIONS:()=>r.U$,MAT_PREFIX:()=>r.KN,MAT_SUFFIX:()=>r.B1,MatError:()=>r.TL,MatFormField:()=>r.rl,MatFormFieldControl:()=>r.qT,MatFormFieldModule:()=>O,MatHint:()=>r.MV,MatLabel:()=>r.nJ,MatPrefix:()=>r.JW,MatSuffix:()=>r.yw,getMatFormFieldDuplicatedHintError:()=>r.fZ,getMatFormFieldMissingControlError:()=>r.kh,getMatFormFieldPlaceholderConflictError:()=>r.UT});var r=i(51029),_=i(90459),p=i(48867),o=i(39638),s=i(60447),m=i(73971),t=i(52455),M=i(90508),I=i(88632),C=i(24884),h=i(69005),g=i(15047);class O{static \u0275fac=function(S){return new(S||O)};static \u0275mod=o.\u0275\u0275defineNgModule({type:O});static \u0275inj=o.\u0275\u0275defineInjector({imports:[p.ObserversModule,r.rl,_.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&o.\u0275setClassMetadata(O,[{type:o.NgModule,args:[{imports:[p.ObserversModule,r.rl,r.nJ,r.TL,r.MV,r.JW,r.yw],exports:[r.rl,r.nJ,r.MV,r.TL,r.JW,r.yw,_.BidiModule]}]}],null,null)},66865(w,v,i){i.r(v),i.d(v,{MAT_SELECT_CONFIG:()=>R,MAT_SELECT_SCROLL_STRATEGY:()=>P,MAT_SELECT_TRIGGER:()=>E,MatError:()=>g.TL,MatFormField:()=>g.rl,MatHint:()=>g.MV,MatLabel:()=>g.nJ,MatOptgroup:()=>f.D7,MatOption:()=>f.wT,MatPrefix:()=>g.JW,MatSelect:()=>u,MatSelectChange:()=>F,MatSelectModule:()=>x,MatSelectTrigger:()=>b,MatSuffix:()=>g.yw});var r=i(60447),_=i(90459),p=i(41407),o=i(88783),s=i(15893),m=i(33807),t=i(39638),M=i(58102),I=i(52455),C=i(88632),h=i(24884),g=i(51029),O=i(34630),f=i(92755),A=i(48827),S=i(3146),T=i(29344),D=i(70084),Q=i(73971),X=i(90508),J=i(69005),$=i(15047),Z=i(4295),q=i(48867);const L=["trigger"],W=["panel"],B=[[["mat-select-trigger"]],"*"],K=["mat-select-trigger","*"];function U(d,e){if(d&1&&(t.\u0275\u0275elementStart(0,"span",4),t.\u0275\u0275text(1),t.\u0275\u0275elementEnd()),d&2){const n=t.\u0275\u0275nextContext();t.\u0275\u0275advance(),t.\u0275\u0275textInterpolate(n.placeholder)}}function j(d,e){d&1&&t.\u0275\u0275projection(0)}function V(d,e){if(d&1&&(t.\u0275\u0275elementStart(0,"span",11),t.\u0275\u0275text(1),t.\u0275\u0275elementEnd()),d&2){const n=t.\u0275\u0275nextContext(2);t.\u0275\u0275advance(),t.\u0275\u0275textInterpolate(n.triggerValue)}}function N(d,e){if(d&1&&(t.\u0275\u0275elementStart(0,"span",5),t.\u0275\u0275conditionalCreate(1,j,1,0)(2,V,2,1,"span",11),t.\u0275\u0275elementEnd()),d&2){const n=t.\u0275\u0275nextContext();t.\u0275\u0275advance(),t.\u0275\u0275conditional(n.customTrigger?1:2)}}function z(d,e){if(d&1){const n=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"div",12,1),t.\u0275\u0275listener("keydown",function(l){t.\u0275\u0275restoreView(n);const c=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(c._handleKeydown(l))}),t.\u0275\u0275projection(2,1),t.\u0275\u0275elementEnd()}if(d&2){const n=t.\u0275\u0275nextContext();t.\u0275\u0275classMap(n.panelClass),t.\u0275\u0275classProp("mat-select-panel-animations-enabled",!n._animationsDisabled)("mat-primary",(n._parentFormField==null?null:n._parentFormField.color)==="primary")("mat-accent",(n._parentFormField==null?null:n._parentFormField.color)==="accent")("mat-warn",(n._parentFormField==null?null:n._parentFormField.color)==="warn")("mat-undefined",!(n._parentFormField!=null&&n._parentFormField.color)),t.\u0275\u0275attribute("id",n.id+"-panel")("aria-multiselectable",n.multiple)("aria-label",n.ariaLabel||null)("aria-labelledby",n._getPanelAriaLabelledby())}}function G(){return Error("Cannot change `multiple` mode of select after initialization.")}function H(){return Error("Value must be an array in multiple-selection mode.")}function Y(){return Error("`compareWith` must be a function.")}const P=new t.InjectionToken("mat-select-scroll-strategy",{providedIn:"root",factory:()=>{const d=(0,t.inject)(t.Injector);return()=>(0,s.createRepositionScrollStrategy)(d)}}),R=new t.InjectionToken("MAT_SELECT_CONFIG"),E=new t.InjectionToken("MatSelectTrigger");class F{source;value;constructor(e,n){this.source=e,this.value=n}}class u{_viewportRuler=(0,t.inject)(m.ViewportRuler);_changeDetectorRef=(0,t.inject)(t.ChangeDetectorRef);_elementRef=(0,t.inject)(t.ElementRef);_dir=(0,t.inject)(_.Directionality,{optional:!0});_idGenerator=(0,t.inject)(r._IdGenerator);_renderer=(0,t.inject)(t.Renderer2);_parentFormField=(0,t.inject)(g.xb,{optional:!0});ngControl=(0,t.inject)(M.NgControl,{self:!0,optional:!0});_liveAnnouncer=(0,t.inject)(r.LiveAnnouncer);_defaultOptions=(0,t.inject)(R,{optional:!0});_animationsDisabled=(0,O.Rc)();_popoverLocation;_initialized=new C.Subject;_cleanupDetach;options;optionGroups;customTrigger;_positions=[{originX:"start",originY:"bottom",overlayX:"start",overlayY:"top"},{originX:"end",originY:"bottom",overlayX:"end",overlayY:"top"},{originX:"start",originY:"top",overlayX:"start",overlayY:"bottom",panelClass:"mat-mdc-select-panel-above"},{originX:"end",originY:"top",overlayX:"end",overlayY:"bottom",panelClass:"mat-mdc-select-panel-above"}];_scrollOptionIntoView(e){const n=this.options.toArray()[e];if(n){const a=this.panel.nativeElement,l=(0,f.jb)(e,this.options,this.optionGroups),c=n._getHostElement();e===0&&l===1?a.scrollTop=0:a.scrollTop=(0,f.TL)(c.offsetTop,c.offsetHeight,a.scrollTop,a.offsetHeight)}}_positioningSettled(){this._scrollOptionIntoView(this._keyManager.activeItemIndex||0)}_getChangeEvent(e){return new F(this,e)}_scrollStrategyFactory=(0,t.inject)(P);_panelOpen=!1;_compareWith=(e,n)=>e===n;_uid=this._idGenerator.getId("mat-select-");_triggerAriaLabelledBy=null;_previousControl;_destroy=new C.Subject;_errorStateTracker;stateChanges=new C.Subject;disableAutomaticLabeling=!0;userAriaDescribedBy;_selectionModel;_keyManager;_preferredOverlayOrigin;_overlayWidth;_onChange=()=>{};_onTouched=()=>{};_valueId=this._idGenerator.getId("mat-select-value-");_scrollStrategy;_overlayPanelClass=this._defaultOptions?.overlayPanelClass||"";get focused(){return this._focused||this._panelOpen}_focused=!1;controlType="mat-select";trigger;panel;_overlayDir;panelClass;disabled=!1;get disableRipple(){return this._disableRipple()}set disableRipple(e){this._disableRipple.set(e)}_disableRipple=(0,t.signal)(!1,...ngDevMode?[{debugName:"_disableRipple"}]:[]);tabIndex=0;get hideSingleSelectionIndicator(){return this._hideSingleSelectionIndicator}set hideSingleSelectionIndicator(e){this._hideSingleSelectionIndicator=e,this._syncParentProperties()}_hideSingleSelectionIndicator=this._defaultOptions?.hideSingleSelectionIndicator??!1;get placeholder(){return this._placeholder}set placeholder(e){this._placeholder=e,this.stateChanges.next()}_placeholder;get required(){return this._required??this.ngControl?.control?.hasValidator(M.Validators.required)??!1}set required(e){this._required=e,this.stateChanges.next()}_required;get multiple(){return this._multiple}set multiple(e){if(this._selectionModel&&(typeof ngDevMode>"u"||ngDevMode))throw G();this._multiple=e}_multiple=!1;disableOptionCentering=this._defaultOptions?.disableOptionCentering??!1;get compareWith(){return this._compareWith}set compareWith(e){if(typeof e!="function"&&(typeof ngDevMode>"u"||ngDevMode))throw Y();this._compareWith=e,this._selectionModel&&this._initializeSelection()}get value(){return this._value}set value(e){this._assignValue(e)&&this._onChange(e)}_value;ariaLabel="";ariaLabelledby;get errorStateMatcher(){return this._errorStateTracker.matcher}set errorStateMatcher(e){this._errorStateTracker.matcher=e}typeaheadDebounceInterval;sortComparator;get id(){return this._id}set id(e){this._id=e||this._uid,this.stateChanges.next()}_id;get errorState(){return this._errorStateTracker.errorState}set errorState(e){this._errorStateTracker.errorState=e}panelWidth=this._defaultOptions&&typeof this._defaultOptions.panelWidth<"u"?this._defaultOptions.panelWidth:"auto";canSelectNullableOptions=this._defaultOptions?.canSelectNullableOptions??!1;optionSelectionChanges=(0,C.defer)(()=>{const e=this.options;return e?e.changes.pipe((0,h.startWith)(e),(0,h.switchMap)(()=>(0,C.merge)(...e.map(n=>n.onSelectionChange)))):this._initialized.pipe((0,h.switchMap)(()=>this.optionSelectionChanges))});openedChange=new t.EventEmitter;_openedStream=this.openedChange.pipe((0,h.filter)(e=>e),(0,h.map)(()=>{}));_closedStream=this.openedChange.pipe((0,h.filter)(e=>!e),(0,h.map)(()=>{}));selectionChange=new t.EventEmitter;valueChange=new t.EventEmitter;constructor(){const e=(0,t.inject)(A.e),n=(0,t.inject)(M.NgForm,{optional:!0}),a=(0,t.inject)(M.FormGroupDirective,{optional:!0}),l=(0,t.inject)(new t.HostAttributeToken("tabindex"),{optional:!0}),c=(0,t.inject)(s.OVERLAY_DEFAULT_CONFIG,{optional:!0});this.ngControl&&(this.ngControl.valueAccessor=this),this._defaultOptions?.typeaheadDebounceInterval!=null&&(this.typeaheadDebounceInterval=this._defaultOptions.typeaheadDebounceInterval),this._errorStateTracker=new S.X(e,this.ngControl,a,n,this.stateChanges),this._scrollStrategy=this._scrollStrategyFactory(),this.tabIndex=l==null?0:parseInt(l)||0,this._popoverLocation=c?.usePopover===!1?null:"inline",this.id=this.id}ngOnInit(){this._selectionModel=new p.SelectionModel(this.multiple),this.stateChanges.next(),this._viewportRuler.change().pipe((0,h.takeUntil)(this._destroy)).subscribe(()=>{this.panelOpen&&(this._overlayWidth=this._getOverlayWidth(this._preferredOverlayOrigin),this._changeDetectorRef.detectChanges())})}ngAfterContentInit(){this._initialized.next(),this._initialized.complete(),this._initKeyManager(),this._selectionModel.changed.pipe((0,h.takeUntil)(this._destroy)).subscribe(e=>{e.added.forEach(n=>n.select()),e.removed.forEach(n=>n.deselect())}),this.options.changes.pipe((0,h.startWith)(null),(0,h.takeUntil)(this._destroy)).subscribe(()=>{this._resetOptions(),this._initializeSelection()})}ngDoCheck(){const e=this._getTriggerAriaLabelledby(),n=this.ngControl;if(e!==this._triggerAriaLabelledBy){const a=this._elementRef.nativeElement;this._triggerAriaLabelledBy=e,e?a.setAttribute("aria-labelledby",e):a.removeAttribute("aria-labelledby")}n&&(this._previousControl!==n.control&&(this._previousControl!==void 0&&n.disabled!==null&&n.disabled!==this.disabled&&(this.disabled=n.disabled),this._previousControl=n.control),this.updateErrorState())}ngOnChanges(e){(e.disabled||e.userAriaDescribedBy)&&this.stateChanges.next(),e.typeaheadDebounceInterval&&this._keyManager&&this._keyManager.withTypeAhead(this.typeaheadDebounceInterval),e.panelClass&&this.panelClass instanceof Set&&(this.panelClass=Array.from(this.panelClass))}ngOnDestroy(){this._cleanupDetach?.(),this._keyManager?.destroy(),this._destroy.next(),this._destroy.complete(),this.stateChanges.complete(),this._clearFromModal()}toggle(){this.panelOpen?this.close():this.open()}open(){this._canOpen()&&(this._parentFormField&&(this._preferredOverlayOrigin=this._parentFormField.getConnectedOverlayOrigin()),this._cleanupDetach?.(),this._overlayWidth=this._getOverlayWidth(this._preferredOverlayOrigin),this._applyModalPanelOwnership(),this._panelOpen=!0,this._overlayDir.positionChange.pipe((0,h.take)(1)).subscribe(()=>{this._changeDetectorRef.detectChanges(),this._positioningSettled()}),this._overlayDir.attachOverlay(),this._keyManager.withHorizontalOrientation(null),this._highlightCorrectOption(),this._changeDetectorRef.markForCheck(),this.stateChanges.next(),Promise.resolve().then(()=>this.openedChange.emit(!0)))}_trackedModal=null;_applyModalPanelOwnership(){const e=this._elementRef.nativeElement.closest('body > .cdk-overlay-container [aria-modal="true"]');if(!e)return;const n=`${this.id}-panel`;this._trackedModal&&(0,r.removeAriaReferencedId)(this._trackedModal,"aria-owns",n),(0,r.addAriaReferencedId)(e,"aria-owns",n),this._trackedModal=e}_clearFromModal(){if(!this._trackedModal)return;const e=`${this.id}-panel`;(0,r.removeAriaReferencedId)(this._trackedModal,"aria-owns",e),this._trackedModal=null}close(){this._panelOpen&&(this._panelOpen=!1,this._exitAndDetach(),this._keyManager.withHorizontalOrientation(this._isRtl()?"rtl":"ltr"),this._changeDetectorRef.markForCheck(),this._onTouched(),this.stateChanges.next(),Promise.resolve().then(()=>this.openedChange.emit(!1)))}_exitAndDetach(){if(this._animationsDisabled||!this.panel){this._detachOverlay();return}this._cleanupDetach?.(),this._cleanupDetach=()=>{n(),clearTimeout(a),this._cleanupDetach=void 0};const e=this.panel.nativeElement,n=this._renderer.listen(e,"animationend",l=>{l.animationName==="_mat-select-exit"&&(this._cleanupDetach?.(),this._detachOverlay())}),a=setTimeout(()=>{this._cleanupDetach?.(),this._detachOverlay()},200);e.classList.add("mat-select-panel-exit")}_detachOverlay(){this._overlayDir.detachOverlay(),this._changeDetectorRef.markForCheck()}writeValue(e){this._assignValue(e)}registerOnChange(e){this._onChange=e}registerOnTouched(e){this._onTouched=e}setDisabledState(e){this.disabled=e,this._changeDetectorRef.markForCheck(),this.stateChanges.next()}get panelOpen(){return this._panelOpen}get selected(){return this.multiple?this._selectionModel?.selected||[]:this._selectionModel?.selected[0]}get triggerValue(){if(this.empty)return"";if(this._multiple){const e=this._selectionModel.selected.map(n=>n.viewValue);return this._isRtl()&&e.reverse(),e.join(", ")}return this._selectionModel.selected[0].viewValue}updateErrorState(){this._errorStateTracker.updateErrorState()}_isRtl(){return this._dir?this._dir.value==="rtl":!1}_handleKeydown(e){this.disabled||(this.panelOpen?this._handleOpenKeydown(e):this._handleClosedKeydown(e))}_handleClosedKeydown(e){const n=e.keyCode,a=n===o.DOWN_ARROW||n===o.UP_ARROW||n===o.LEFT_ARROW||n===o.RIGHT_ARROW,l=n===o.ENTER||n===o.SPACE,c=this._keyManager;if(!c.isTyping()&&l&&!(0,o.hasModifierKey)(e)||(this.multiple||e.altKey)&&a)e.preventDefault(),this.open();else if(!this.multiple){const k=this.selected;c.onKeydown(e);const y=this.selected;y&&k!==y&&this._liveAnnouncer.announce(y.viewValue,1e4)}}_handleOpenKeydown(e){const n=this._keyManager,a=e.keyCode,l=a===o.DOWN_ARROW||a===o.UP_ARROW,c=n.isTyping();if(l&&e.altKey)e.preventDefault(),this.close();else if(!c&&(a===o.ENTER||a===o.SPACE)&&n.activeItem&&!(0,o.hasModifierKey)(e))e.preventDefault(),n.activeItem._selectViaInteraction();else if(!c&&this._multiple&&a===o.A&&e.ctrlKey){e.preventDefault();const k=this.options.some(y=>!y.disabled&&!y.selected);this.options.forEach(y=>{y.disabled||(k?y.select():y.deselect())})}else{const k=n.activeItemIndex;n.onKeydown(e),this._multiple&&l&&e.shiftKey&&n.activeItem&&n.activeItemIndex!==k&&n.activeItem._selectViaInteraction()}}_handleOverlayKeydown(e){e.keyCode===o.ESCAPE&&!(0,o.hasModifierKey)(e)&&(e.preventDefault(),this.close())}_onFocus(){this.disabled||(this._focused=!0,this.stateChanges.next())}_onBlur(){this._focused=!1,this._keyManager?.cancelTypeahead(),!this.disabled&&!this.panelOpen&&(this._onTouched(),this._changeDetectorRef.markForCheck(),this.stateChanges.next())}get empty(){return!this._selectionModel||this._selectionModel.isEmpty()}_initializeSelection(){Promise.resolve().then(()=>{this.ngControl&&(this._value=this.ngControl.value),this._setSelectionByValue(this._value),this.stateChanges.next()})}_setSelectionByValue(e){if(this.options.forEach(n=>n.setInactiveStyles()),this._selectionModel.clear(),this.multiple&&e){if(!Array.isArray(e)&&(typeof ngDevMode>"u"||ngDevMode))throw H();e.forEach(n=>this._selectOptionByValue(n)),this._sortValues()}else{const n=this._selectOptionByValue(e);n?this._keyManager.updateActiveItem(n):this.panelOpen||this._keyManager.updateActiveItem(-1)}this._changeDetectorRef.markForCheck()}_selectOptionByValue(e){const n=this.options.find(a=>{if(this._selectionModel.isSelected(a))return!1;try{return(a.value!=null||this.canSelectNullableOptions)&&this._compareWith(a.value,e)}catch(l){return(typeof ngDevMode>"u"||ngDevMode)&&console.warn(l),!1}});return n&&this._selectionModel.select(n),n}_assignValue(e){return e!==this._value||this._multiple&&Array.isArray(e)?(this.options&&this._setSelectionByValue(e),this._value=e,!0):!1}_skipPredicate=e=>this.panelOpen?!1:e.disabled;_getOverlayWidth(e){return this.panelWidth==="auto"?(e instanceof s.CdkOverlayOrigin?e.elementRef:e||this._elementRef).nativeElement.getBoundingClientRect().width:this.panelWidth===null?"":this.panelWidth}_syncParentProperties(){if(this.options)for(const e of this.options)e._changeDetectorRef.markForCheck()}_initKeyManager(){this._keyManager=new r.ActiveDescendantKeyManager(this.options).withTypeAhead(this.typeaheadDebounceInterval).withVerticalOrientation().withHorizontalOrientation(this._isRtl()?"rtl":"ltr").withHomeAndEnd().withPageUpDown().withAllowedModifierKeys(["shiftKey"]).skipPredicate(this._skipPredicate),this._keyManager.tabOut.subscribe(()=>{this.panelOpen&&(!this.multiple&&this._keyManager.activeItem&&this._keyManager.activeItem._selectViaInteraction(),this.focus(),this.close())}),this._keyManager.change.subscribe(()=>{this._panelOpen&&this.panel?this._scrollOptionIntoView(this._keyManager.activeItemIndex||0):!this._panelOpen&&!this.multiple&&this._keyManager.activeItem&&this._keyManager.activeItem._selectViaInteraction()})}_resetOptions(){const e=(0,C.merge)(this.options.changes,this._destroy);this.optionSelectionChanges.pipe((0,h.takeUntil)(e)).subscribe(n=>{this._onSelect(n.source,n.isUserInput),n.isUserInput&&!this.multiple&&this._panelOpen&&(this.close(),this.focus())}),(0,C.merge)(...this.options.map(n=>n._stateChanges)).pipe((0,h.takeUntil)(e)).subscribe(()=>{this._changeDetectorRef.detectChanges(),this.stateChanges.next()})}_onSelect(e,n){const a=this._selectionModel.isSelected(e);!this.canSelectNullableOptions&&e.value==null&&!this._multiple?(e.deselect(),this._selectionModel.clear(),this.value!=null&&this._propagateChanges(e.value)):(a!==e.selected&&(e.selected?this._selectionModel.select(e):this._selectionModel.deselect(e)),n&&this._keyManager.setActiveItem(e),this.multiple&&(this._sortValues(),n&&this.focus())),a!==this._selectionModel.isSelected(e)&&this._propagateChanges(),this.stateChanges.next()}_sortValues(){if(this.multiple){const e=this.options.toArray();this._selectionModel.sort((n,a)=>this.sortComparator?this.sortComparator(n,a,e):e.indexOf(n)-e.indexOf(a)),this.stateChanges.next()}}_propagateChanges(e){let n;this.multiple?n=this.selected.map(a=>a.value):n=this.selected?this.selected.value:e,this._value=n,this.valueChange.emit(n),this._onChange(n),this.selectionChange.emit(this._getChangeEvent(n)),this._changeDetectorRef.markForCheck()}_highlightCorrectOption(){if(this._keyManager)if(this.empty){let e=-1;for(let n=0;n<this.options.length;n++)if(!this.options.get(n).disabled){e=n;break}this._keyManager.setActiveItem(e)}else this._keyManager.setActiveItem(this._selectionModel.selected[0])}_canOpen(){return!this._panelOpen&&!this.disabled&&this.options?.length>0&&!!this._overlayDir}focus(e){this._elementRef.nativeElement.focus(e)}_getPanelAriaLabelledby(){if(this.ariaLabel)return null;const e=this._parentFormField?.getLabelId()||null,n=e?e+" ":"";return this.ariaLabelledby?n+this.ariaLabelledby:e}_getAriaActiveDescendant(){return this.panelOpen&&this._keyManager&&this._keyManager.activeItem?this._keyManager.activeItem.id:null}_getTriggerAriaLabelledby(){if(this.ariaLabel)return null;let e=this._parentFormField?.getLabelId()||"";return this.ariaLabelledby&&(e+=" "+this.ariaLabelledby),e||(e=this._valueId),e}get describedByIds(){return this._elementRef.nativeElement.getAttribute("aria-describedby")?.split(" ")||[]}setDescribedByIds(e){const n=this._elementRef.nativeElement;e.length?n.setAttribute("aria-describedby",e.join(" ")):n.removeAttribute("aria-describedby")}onContainerClick(e){const n=(0,I._getEventTarget)(e);n&&(n.tagName==="MAT-OPTION"||n.classList.contains("cdk-overlay-backdrop")||n.closest(".mat-mdc-select-panel"))||(this.focus(),this.open())}get shouldLabelFloat(){return this.panelOpen||!this.empty||this.focused&&!!this.placeholder}static \u0275fac=function(n){return new(n||u)};static \u0275cmp=t.\u0275\u0275defineComponent({type:u,selectors:[["mat-select"]],contentQueries:function(n,a,l){if(n&1&&t.\u0275\u0275contentQuery(l,E,5)(l,f.wT,5)(l,f.QC,5),n&2){let c;t.\u0275\u0275queryRefresh(c=t.\u0275\u0275loadQuery())&&(a.customTrigger=c.first),t.\u0275\u0275queryRefresh(c=t.\u0275\u0275loadQuery())&&(a.options=c),t.\u0275\u0275queryRefresh(c=t.\u0275\u0275loadQuery())&&(a.optionGroups=c)}},viewQuery:function(n,a){if(n&1&&t.\u0275\u0275viewQuery(L,5)(W,5)(s.CdkConnectedOverlay,5),n&2){let l;t.\u0275\u0275queryRefresh(l=t.\u0275\u0275loadQuery())&&(a.trigger=l.first),t.\u0275\u0275queryRefresh(l=t.\u0275\u0275loadQuery())&&(a.panel=l.first),t.\u0275\u0275queryRefresh(l=t.\u0275\u0275loadQuery())&&(a._overlayDir=l.first)}},hostAttrs:["role","combobox","aria-haspopup","listbox",1,"mat-mdc-select"],hostVars:21,hostBindings:function(n,a){n&1&&t.\u0275\u0275listener("keydown",function(c){return a._handleKeydown(c)})("focus",function(){return a._onFocus()})("blur",function(){return a._onBlur()}),n&2&&(t.\u0275\u0275attribute("id",a.id)("tabindex",a.disabled?-1:a.tabIndex)("aria-controls",a.panelOpen?a.id+"-panel":null)("aria-expanded",a.panelOpen)("aria-label",a.ariaLabel||null)("aria-required",a.required.toString())("aria-disabled",a.disabled.toString())("aria-invalid",a.errorState)("aria-activedescendant",a._getAriaActiveDescendant()),t.\u0275\u0275classProp("mat-mdc-select-disabled",a.disabled)("mat-mdc-select-invalid",a.errorState)("mat-mdc-select-required",a.required)("mat-mdc-select-empty",a.empty)("mat-mdc-select-multiple",a.multiple)("mat-select-open",a.panelOpen))},inputs:{userAriaDescribedBy:[0,"aria-describedby","userAriaDescribedBy"],panelClass:"panelClass",disabled:[2,"disabled","disabled",t.booleanAttribute],disableRipple:[2,"disableRipple","disableRipple",t.booleanAttribute],tabIndex:[2,"tabIndex","tabIndex",e=>e==null?0:(0,t.numberAttribute)(e)],hideSingleSelectionIndicator:[2,"hideSingleSelectionIndicator","hideSingleSelectionIndicator",t.booleanAttribute],placeholder:"placeholder",required:[2,"required","required",t.booleanAttribute],multiple:[2,"multiple","multiple",t.booleanAttribute],disableOptionCentering:[2,"disableOptionCentering","disableOptionCentering",t.booleanAttribute],compareWith:"compareWith",value:"value",ariaLabel:[0,"aria-label","ariaLabel"],ariaLabelledby:[0,"aria-labelledby","ariaLabelledby"],errorStateMatcher:"errorStateMatcher",typeaheadDebounceInterval:[2,"typeaheadDebounceInterval","typeaheadDebounceInterval",t.numberAttribute],sortComparator:"sortComparator",id:"id",panelWidth:"panelWidth",canSelectNullableOptions:[2,"canSelectNullableOptions","canSelectNullableOptions",t.booleanAttribute]},outputs:{openedChange:"openedChange",_openedStream:"opened",_closedStream:"closed",selectionChange:"selectionChange",valueChange:"valueChange"},exportAs:["matSelect"],features:[t.\u0275\u0275ProvidersFeature([{provide:g.qT,useExisting:u},{provide:f.is,useExisting:u}]),t.\u0275\u0275NgOnChangesFeature],ngContentSelectors:K,decls:11,vars:10,consts:[["fallbackOverlayOrigin","cdkOverlayOrigin","trigger",""],["panel",""],["cdk-overlay-origin","",1,"mat-mdc-select-trigger",3,"click"],[1,"mat-mdc-select-value"],[1,"mat-mdc-select-placeholder","mat-mdc-select-min-line"],[1,"mat-mdc-select-value-text"],[1,"mat-mdc-select-arrow-wrapper"],[1,"mat-mdc-select-arrow"],["viewBox","0 0 24 24","width","24px","height","24px","focusable","false","aria-hidden","true"],["d","M7 10l5 5 5-5z"],["cdk-connected-overlay","","cdkConnectedOverlayHasBackdrop","","cdkConnectedOverlayBackdropClass","cdk-overlay-transparent-backdrop",3,"detach","backdropClick","overlayKeydown","cdkConnectedOverlayDisableClose","cdkConnectedOverlayPanelClass","cdkConnectedOverlayScrollStrategy","cdkConnectedOverlayOrigin","cdkConnectedOverlayPositions","cdkConnectedOverlayWidth","cdkConnectedOverlayFlexibleDimensions","cdkConnectedOverlayUsePopover"],[1,"mat-mdc-select-min-line"],["role","listbox","tabindex","-1",1,"mat-mdc-select-panel","mdc-menu-surface","mdc-menu-surface--open",3,"keydown"]],template:function(n,a){if(n&1&&(t.\u0275\u0275projectionDef(B),t.\u0275\u0275elementStart(0,"div",2,0),t.\u0275\u0275listener("click",function(){return a.open()}),t.\u0275\u0275elementStart(3,"div",3),t.\u0275\u0275conditionalCreate(4,U,2,1,"span",4)(5,N,3,1,"span",5),t.\u0275\u0275elementEnd(),t.\u0275\u0275elementStart(6,"div",6)(7,"div",7),t.\u0275\u0275namespaceSVG(),t.\u0275\u0275elementStart(8,"svg",8),t.\u0275\u0275element(9,"path",9),t.\u0275\u0275elementEnd()()()(),t.\u0275\u0275template(10,z,3,16,"ng-template",10),t.\u0275\u0275listener("detach",function(){return a.close()})("backdropClick",function(){return a.close()})("overlayKeydown",function(c){return a._handleOverlayKeydown(c)})),n&2){const l=t.\u0275\u0275reference(1);t.\u0275\u0275advance(3),t.\u0275\u0275attribute("id",a._valueId),t.\u0275\u0275advance(),t.\u0275\u0275conditional(a.empty?4:5),t.\u0275\u0275advance(6),t.\u0275\u0275property("cdkConnectedOverlayDisableClose",!0)("cdkConnectedOverlayPanelClass",a._overlayPanelClass)("cdkConnectedOverlayScrollStrategy",a._scrollStrategy)("cdkConnectedOverlayOrigin",a._preferredOverlayOrigin||l)("cdkConnectedOverlayPositions",a._positions)("cdkConnectedOverlayWidth",a._overlayWidth)("cdkConnectedOverlayFlexibleDimensions",!0)("cdkConnectedOverlayUsePopover",a._popoverLocation)}},dependencies:[s.CdkOverlayOrigin,s.CdkConnectedOverlay],styles:[`@keyframes _mat-select-enter {
  from {
    opacity: 0;
    transform: scaleY(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-select-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-mdc-select {
  display: inline-block;
  width: 100%;
  outline: none;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  color: var(--mat-select-enabled-trigger-text-color, var(--mat-sys-on-surface));
  font-family: var(--mat-select-trigger-text-font, var(--mat-sys-body-large-font));
  line-height: var(--mat-select-trigger-text-line-height, var(--mat-sys-body-large-line-height));
  font-size: var(--mat-select-trigger-text-size, var(--mat-sys-body-large-size));
  font-weight: var(--mat-select-trigger-text-weight, var(--mat-sys-body-large-weight));
  letter-spacing: var(--mat-select-trigger-text-tracking, var(--mat-sys-body-large-tracking));
}

div.mat-mdc-select-panel {
  box-shadow: var(--mat-select-container-elevation-shadow, 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12));
}

.mat-mdc-select-disabled {
  color: var(--mat-select-disabled-trigger-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-mdc-select-disabled .mat-mdc-select-placeholder {
  color: var(--mat-select-disabled-trigger-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}

.mat-mdc-select-trigger {
  display: inline-flex;
  align-items: center;
  cursor: pointer;
  position: relative;
  box-sizing: border-box;
  width: 100%;
}
.mat-mdc-select-disabled .mat-mdc-select-trigger {
  -webkit-user-select: none;
  user-select: none;
  cursor: default;
}

.mat-mdc-select-value {
  width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.mat-mdc-select-value-text {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.mat-mdc-select-arrow-wrapper {
  height: 24px;
  flex-shrink: 0;
  display: inline-flex;
  align-items: center;
}
.mat-form-field-appearance-fill .mdc-text-field--no-label .mat-mdc-select-arrow-wrapper {
  transform: none;
}

.mat-mdc-form-field .mat-mdc-select.mat-mdc-select-invalid .mat-mdc-select-arrow,
.mat-form-field-invalid:not(.mat-form-field-disabled) .mat-mdc-form-field-infix::after {
  color: var(--mat-select-invalid-arrow-color, var(--mat-sys-error));
}

.mat-mdc-select-arrow {
  width: 10px;
  height: 5px;
  position: relative;
  color: var(--mat-select-enabled-arrow-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-form-field.mat-focused .mat-mdc-select-arrow {
  color: var(--mat-select-focused-arrow-color, var(--mat-sys-primary));
}
.mat-mdc-form-field .mat-mdc-select.mat-mdc-select-disabled .mat-mdc-select-arrow {
  color: var(--mat-select-disabled-arrow-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-select-open .mat-mdc-select-arrow {
  transform: rotate(180deg);
}
.mat-form-field-animations-enabled .mat-mdc-select-arrow {
  transition: transform 80ms linear;
}
.mat-mdc-select-arrow svg {
  fill: currentColor;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
@media (forced-colors: active) {
  .mat-mdc-select-arrow svg {
    fill: CanvasText;
  }
  .mat-mdc-select-disabled .mat-mdc-select-arrow svg {
    fill: GrayText;
  }
}

div.mat-mdc-select-panel {
  width: 100%;
  max-height: 275px;
  outline: 0;
  overflow: auto;
  padding: 8px 0;
  box-sizing: border-box;
  transform-origin: top center;
  border-radius: 0 0 4px 4px;
  position: relative;
  background-color: var(--mat-select-panel-background-color, var(--mat-sys-surface-container));
}
.mat-mdc-select-panel-above div.mat-mdc-select-panel {
  border-radius: 4px 4px 0 0;
  transform-origin: bottom center;
}
@media (forced-colors: active) {
  div.mat-mdc-select-panel {
    outline: solid 1px;
  }
}

.mat-select-panel-animations-enabled {
  animation: _mat-select-enter 120ms cubic-bezier(0, 0, 0.2, 1);
}
.mat-select-panel-animations-enabled.mat-select-panel-exit {
  animation: _mat-select-exit 100ms linear;
}

.mat-mdc-select-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
  color: var(--mat-select-placeholder-text-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-form-field:not(.mat-form-field-animations-enabled) .mat-mdc-select-placeholder, ._mat-animation-noopable .mat-mdc-select-placeholder {
  transition: none;
}
.mat-form-field-hide-placeholder .mat-mdc-select-placeholder {
  color: transparent;
  -webkit-text-fill-color: transparent;
  transition: none;
  display: block;
}

.mat-mdc-form-field-type-mat-select:not(.mat-form-field-disabled) .mat-mdc-text-field-wrapper {
  cursor: pointer;
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-fill .mat-mdc-floating-label {
  max-width: calc(100% - 18px);
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-fill .mdc-floating-label--float-above {
  max-width: calc(100% / 0.75 - 24px);
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-outline .mdc-notched-outline__notch {
  max-width: calc(100% - 60px);
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-outline .mdc-text-field--label-floating .mdc-notched-outline__notch {
  max-width: calc(100% - 24px);
}

.mat-mdc-select-min-line:empty::before {
  content: " ";
  white-space: pre;
  width: 1px;
  display: inline-block;
  visibility: hidden;
}

.mat-form-field-appearance-fill .mat-mdc-select-arrow-wrapper {
  transform: var(--mat-select-arrow-transform, translateY(-8px));
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(u,[{type:t.Component,args:[{selector:"mat-select",exportAs:"matSelect",encapsulation:t.ViewEncapsulation.None,changeDetection:t.ChangeDetectionStrategy.OnPush,host:{role:"combobox","aria-haspopup":"listbox",class:"mat-mdc-select","[attr.id]":"id","[attr.tabindex]":"disabled ? -1 : tabIndex","[attr.aria-controls]":'panelOpen ? id + "-panel" : null',"[attr.aria-expanded]":"panelOpen","[attr.aria-label]":"ariaLabel || null","[attr.aria-required]":"required.toString()","[attr.aria-disabled]":"disabled.toString()","[attr.aria-invalid]":"errorState","[attr.aria-activedescendant]":"_getAriaActiveDescendant()","[class.mat-mdc-select-disabled]":"disabled","[class.mat-mdc-select-invalid]":"errorState","[class.mat-mdc-select-required]":"required","[class.mat-mdc-select-empty]":"empty","[class.mat-mdc-select-multiple]":"multiple","[class.mat-select-open]":"panelOpen","(keydown)":"_handleKeydown($event)","(focus)":"_onFocus()","(blur)":"_onBlur()"},providers:[{provide:g.qT,useExisting:u},{provide:f.is,useExisting:u}],imports:[s.CdkOverlayOrigin,s.CdkConnectedOverlay],template:`<div
  cdk-overlay-origin
  class="mat-mdc-select-trigger"
  (click)="open()"
  #fallbackOverlayOrigin="cdkOverlayOrigin"
  #trigger
>
  <div class="mat-mdc-select-value" [attr.id]="_valueId">
    @if (empty) {
      <span class="mat-mdc-select-placeholder mat-mdc-select-min-line">{{placeholder}}</span>
    } @else {
      <span class="mat-mdc-select-value-text">
        @if (customTrigger) {
          <ng-content select="mat-select-trigger"></ng-content>
        } @else {
          <span class="mat-mdc-select-min-line">{{triggerValue}}</span>
        }
      </span>
    }
  </div>

  <div class="mat-mdc-select-arrow-wrapper">
    <div class="mat-mdc-select-arrow">
      <!-- Use an inline SVG, because it works better than a CSS triangle in high contrast mode. -->
      <svg viewBox="0 0 24 24" width="24px" height="24px" focusable="false" aria-hidden="true">
        <path d="M7 10l5 5 5-5z" />
      </svg>
    </div>
  </div>
</div>

<ng-template
  cdk-connected-overlay
  cdkConnectedOverlayHasBackdrop
  cdkConnectedOverlayBackdropClass="cdk-overlay-transparent-backdrop"
  [cdkConnectedOverlayDisableClose]="true"
  [cdkConnectedOverlayPanelClass]="_overlayPanelClass"
  [cdkConnectedOverlayScrollStrategy]="_scrollStrategy"
  [cdkConnectedOverlayOrigin]="_preferredOverlayOrigin || fallbackOverlayOrigin"
  [cdkConnectedOverlayPositions]="_positions"
  [cdkConnectedOverlayWidth]="_overlayWidth"
  [cdkConnectedOverlayFlexibleDimensions]="true"
  [cdkConnectedOverlayUsePopover]="_popoverLocation"
  (detach)="close()"
  (backdropClick)="close()"
  (overlayKeydown)="_handleOverlayKeydown($event)">
  <!-- \`mat-undefined\` is weird, but we were using it internally -->
  <div
    #panel
    role="listbox"
    tabindex="-1"
    class="mat-mdc-select-panel mdc-menu-surface mdc-menu-surface--open"
    [class]="panelClass"
    [class.mat-select-panel-animations-enabled]="!_animationsDisabled"
    [class.mat-primary]="_parentFormField?.color === 'primary'"
    [class.mat-accent]="_parentFormField?.color === 'accent'"
    [class.mat-warn]="_parentFormField?.color === 'warn'"
    [class.mat-undefined]="!_parentFormField?.color"
    [attr.id]="id + '-panel'"
    [attr.aria-multiselectable]="multiple"
    [attr.aria-label]="ariaLabel || null"
    [attr.aria-labelledby]="_getPanelAriaLabelledby()"
    (keydown)="_handleKeydown($event)">
    <ng-content></ng-content>
  </div>
</ng-template>
`,styles:[`@keyframes _mat-select-enter {
  from {
    opacity: 0;
    transform: scaleY(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-select-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-mdc-select {
  display: inline-block;
  width: 100%;
  outline: none;
  -moz-osx-font-smoothing: grayscale;
  -webkit-font-smoothing: antialiased;
  color: var(--mat-select-enabled-trigger-text-color, var(--mat-sys-on-surface));
  font-family: var(--mat-select-trigger-text-font, var(--mat-sys-body-large-font));
  line-height: var(--mat-select-trigger-text-line-height, var(--mat-sys-body-large-line-height));
  font-size: var(--mat-select-trigger-text-size, var(--mat-sys-body-large-size));
  font-weight: var(--mat-select-trigger-text-weight, var(--mat-sys-body-large-weight));
  letter-spacing: var(--mat-select-trigger-text-tracking, var(--mat-sys-body-large-tracking));
}

div.mat-mdc-select-panel {
  box-shadow: var(--mat-select-container-elevation-shadow, 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12));
}

.mat-mdc-select-disabled {
  color: var(--mat-select-disabled-trigger-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-mdc-select-disabled .mat-mdc-select-placeholder {
  color: var(--mat-select-disabled-trigger-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}

.mat-mdc-select-trigger {
  display: inline-flex;
  align-items: center;
  cursor: pointer;
  position: relative;
  box-sizing: border-box;
  width: 100%;
}
.mat-mdc-select-disabled .mat-mdc-select-trigger {
  -webkit-user-select: none;
  user-select: none;
  cursor: default;
}

.mat-mdc-select-value {
  width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  white-space: nowrap;
}

.mat-mdc-select-value-text {
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.mat-mdc-select-arrow-wrapper {
  height: 24px;
  flex-shrink: 0;
  display: inline-flex;
  align-items: center;
}
.mat-form-field-appearance-fill .mdc-text-field--no-label .mat-mdc-select-arrow-wrapper {
  transform: none;
}

.mat-mdc-form-field .mat-mdc-select.mat-mdc-select-invalid .mat-mdc-select-arrow,
.mat-form-field-invalid:not(.mat-form-field-disabled) .mat-mdc-form-field-infix::after {
  color: var(--mat-select-invalid-arrow-color, var(--mat-sys-error));
}

.mat-mdc-select-arrow {
  width: 10px;
  height: 5px;
  position: relative;
  color: var(--mat-select-enabled-arrow-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-form-field.mat-focused .mat-mdc-select-arrow {
  color: var(--mat-select-focused-arrow-color, var(--mat-sys-primary));
}
.mat-mdc-form-field .mat-mdc-select.mat-mdc-select-disabled .mat-mdc-select-arrow {
  color: var(--mat-select-disabled-arrow-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-select-open .mat-mdc-select-arrow {
  transform: rotate(180deg);
}
.mat-form-field-animations-enabled .mat-mdc-select-arrow {
  transition: transform 80ms linear;
}
.mat-mdc-select-arrow svg {
  fill: currentColor;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
}
@media (forced-colors: active) {
  .mat-mdc-select-arrow svg {
    fill: CanvasText;
  }
  .mat-mdc-select-disabled .mat-mdc-select-arrow svg {
    fill: GrayText;
  }
}

div.mat-mdc-select-panel {
  width: 100%;
  max-height: 275px;
  outline: 0;
  overflow: auto;
  padding: 8px 0;
  box-sizing: border-box;
  transform-origin: top center;
  border-radius: 0 0 4px 4px;
  position: relative;
  background-color: var(--mat-select-panel-background-color, var(--mat-sys-surface-container));
}
.mat-mdc-select-panel-above div.mat-mdc-select-panel {
  border-radius: 4px 4px 0 0;
  transform-origin: bottom center;
}
@media (forced-colors: active) {
  div.mat-mdc-select-panel {
    outline: solid 1px;
  }
}

.mat-select-panel-animations-enabled {
  animation: _mat-select-enter 120ms cubic-bezier(0, 0, 0.2, 1);
}
.mat-select-panel-animations-enabled.mat-select-panel-exit {
  animation: _mat-select-exit 100ms linear;
}

.mat-mdc-select-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
  color: var(--mat-select-placeholder-text-color, var(--mat-sys-on-surface-variant));
}
.mat-mdc-form-field:not(.mat-form-field-animations-enabled) .mat-mdc-select-placeholder, ._mat-animation-noopable .mat-mdc-select-placeholder {
  transition: none;
}
.mat-form-field-hide-placeholder .mat-mdc-select-placeholder {
  color: transparent;
  -webkit-text-fill-color: transparent;
  transition: none;
  display: block;
}

.mat-mdc-form-field-type-mat-select:not(.mat-form-field-disabled) .mat-mdc-text-field-wrapper {
  cursor: pointer;
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-fill .mat-mdc-floating-label {
  max-width: calc(100% - 18px);
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-fill .mdc-floating-label--float-above {
  max-width: calc(100% / 0.75 - 24px);
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-outline .mdc-notched-outline__notch {
  max-width: calc(100% - 60px);
}
.mat-mdc-form-field-type-mat-select.mat-form-field-appearance-outline .mdc-text-field--label-floating .mdc-notched-outline__notch {
  max-width: calc(100% - 24px);
}

.mat-mdc-select-min-line:empty::before {
  content: " ";
  white-space: pre;
  width: 1px;
  display: inline-block;
  visibility: hidden;
}

.mat-form-field-appearance-fill .mat-mdc-select-arrow-wrapper {
  transform: var(--mat-select-arrow-transform, translateY(-8px));
}
`]}]}],()=>[],{options:[{type:t.ContentChildren,args:[f.wT,{descendants:!0}]}],optionGroups:[{type:t.ContentChildren,args:[f.QC,{descendants:!0}]}],customTrigger:[{type:t.ContentChild,args:[E]}],userAriaDescribedBy:[{type:t.Input,args:["aria-describedby"]}],trigger:[{type:t.ViewChild,args:["trigger"]}],panel:[{type:t.ViewChild,args:["panel"]}],_overlayDir:[{type:t.ViewChild,args:[s.CdkConnectedOverlay]}],panelClass:[{type:t.Input}],disabled:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],disableRipple:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],tabIndex:[{type:t.Input,args:[{transform:d=>d==null?0:(0,t.numberAttribute)(d)}]}],hideSingleSelectionIndicator:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],placeholder:[{type:t.Input}],required:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],multiple:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],disableOptionCentering:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],compareWith:[{type:t.Input}],value:[{type:t.Input}],ariaLabel:[{type:t.Input,args:["aria-label"]}],ariaLabelledby:[{type:t.Input,args:["aria-labelledby"]}],errorStateMatcher:[{type:t.Input}],typeaheadDebounceInterval:[{type:t.Input,args:[{transform:t.numberAttribute}]}],sortComparator:[{type:t.Input}],id:[{type:t.Input}],panelWidth:[{type:t.Input}],canSelectNullableOptions:[{type:t.Input,args:[{transform:t.booleanAttribute}]}],openedChange:[{type:t.Output}],_openedStream:[{type:t.Output,args:["opened"]}],_closedStream:[{type:t.Output,args:["closed"]}],selectionChange:[{type:t.Output}],valueChange:[{type:t.Output}]});class b{static \u0275fac=function(n){return new(n||b)};static \u0275dir=t.\u0275\u0275defineDirective({type:b,selectors:[["mat-select-trigger"]],features:[t.\u0275\u0275ProvidersFeature([{provide:E,useExisting:b}])]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(b,[{type:t.Directive,args:[{selector:"mat-select-trigger",providers:[{provide:E,useExisting:b}]}]}],null,null);class x{static \u0275fac=function(n){return new(n||x)};static \u0275mod=t.\u0275\u0275defineNgModule({type:x});static \u0275inj=t.\u0275\u0275defineInjector({imports:[s.OverlayModule,D.S,_.BidiModule,m.CdkScrollableModule,T.MatFormFieldModule,D.S]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(x,[{type:t.NgModule,args:[{imports:[s.OverlayModule,D.S,u,b],exports:[_.BidiModule,m.CdkScrollableModule,T.MatFormFieldModule,u,b,D.S]}]}],null,null)}}]);
