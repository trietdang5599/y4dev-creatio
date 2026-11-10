"use strict";(self.webpackChunkapp_studio_enterprise_shell=self.webpackChunkapp_studio_enterprise_shell||[]).push([[6247],{26470(V,T,l){l.r(T),l.d(T,{MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS:()=>I,MAT_BUTTON_TOGGLE_GROUP:()=>D,MAT_BUTTON_TOGGLE_GROUP_VALUE_ACCESSOR:()=>S,MatButtonToggle:()=>b,MatButtonToggleChange:()=>B,MatButtonToggleGroup:()=>p,MatButtonToggleModule:()=>f});var x=l(17220),C=l(38912),y=l(82724),k=l(9812),E=l(82548),n=l(40231),t=l(17721),v=l(84350),g=l(86192),O=l(34630),F=l(30184),M=l(71127),j=l(9204),z=l(88208),G=l(65868);const A=["button"],R=["*"];function P(u,a){if(u&1&&(n.\u0275\u0275elementStart(0,"div",2),n.\u0275\u0275element(1,"mat-pseudo-checkbox",6),n.\u0275\u0275elementEnd()),u&2){const s=n.\u0275\u0275nextContext();n.\u0275\u0275advance(),n.\u0275\u0275property("disabled",s.disabled)}}const I=new n.InjectionToken("MAT_BUTTON_TOGGLE_DEFAULT_OPTIONS",{providedIn:"root",factory:()=>({hideSingleSelectionIndicator:!1,hideMultipleSelectionIndicator:!1,disabledInteractive:!1})}),D=new n.InjectionToken("MatButtonToggleGroup"),S={provide:t.NG_VALUE_ACCESSOR,useExisting:(0,n.forwardRef)(()=>p),multi:!0};class B{source;value;constructor(a,s){this.source=a,this.value=s}}class p{_changeDetector=(0,n.inject)(n.ChangeDetectorRef);_dir=(0,n.inject)(C.Directionality,{optional:!0});_multiple=!1;_disabled=!1;_disabledInteractive=!1;_selectionModel;_rawValue;_controlValueAccessorChangeFn=()=>{};_onTouched=()=>{};_buttonToggles;appearance;get name(){return this._name}set name(a){this._name=a,this._markButtonsForCheck()}_name=(0,n.inject)(x._IdGenerator).getId("mat-button-toggle-group-");vertical=!1;get value(){const a=this._selectionModel?this._selectionModel.selected:[];return this.multiple?a.map(s=>s.value):a[0]?a[0].value:void 0}set value(a){this._setSelectionByValue(a),this.valueChange.emit(this.value)}valueChange=new n.EventEmitter;get selected(){const a=this._selectionModel?this._selectionModel.selected:[];return this.multiple?a:a[0]||null}get multiple(){return this._multiple}set multiple(a){this._multiple=a,this._markButtonsForCheck()}get disabled(){return this._disabled}set disabled(a){this._disabled=a,this._markButtonsForCheck()}get disabledInteractive(){return this._disabledInteractive}set disabledInteractive(a){this._disabledInteractive=a,this._markButtonsForCheck()}get dir(){return this._dir&&this._dir.value==="rtl"?"rtl":"ltr"}change=new n.EventEmitter;get hideSingleSelectionIndicator(){return this._hideSingleSelectionIndicator}set hideSingleSelectionIndicator(a){this._hideSingleSelectionIndicator=a,this._markButtonsForCheck()}_hideSingleSelectionIndicator;get hideMultipleSelectionIndicator(){return this._hideMultipleSelectionIndicator}set hideMultipleSelectionIndicator(a){this._hideMultipleSelectionIndicator=a,this._markButtonsForCheck()}_hideMultipleSelectionIndicator;constructor(){const a=(0,n.inject)(I,{optional:!0});this.appearance=a&&a.appearance?a.appearance:"standard",this._hideSingleSelectionIndicator=a?.hideSingleSelectionIndicator??!1,this._hideMultipleSelectionIndicator=a?.hideMultipleSelectionIndicator??!1}ngOnInit(){this._selectionModel=new y.SelectionModel(this.multiple,void 0,!1)}ngAfterContentInit(){this._selectionModel.select(...this._buttonToggles.filter(a=>a.checked)),this.multiple||this._initializeTabIndex()}writeValue(a){this.value=a,this._changeDetector.markForCheck()}registerOnChange(a){this._controlValueAccessorChangeFn=a}registerOnTouched(a){this._onTouched=a}setDisabledState(a){this.disabled=a}_keydown(a){if(this.multiple||this.disabled||(0,k.hasModifierKey)(a))return;const r=a.target.id,d=this._buttonToggles.toArray().findIndex(_=>_.buttonId===r);let c=null;switch(a.keyCode){case k.SPACE:case k.ENTER:c=this._buttonToggles.get(d)||null;break;case k.UP_ARROW:c=this._getNextButton(d,-1);break;case k.LEFT_ARROW:c=this._getNextButton(d,this.dir==="ltr"?-1:1);break;case k.DOWN_ARROW:c=this._getNextButton(d,1);break;case k.RIGHT_ARROW:c=this._getNextButton(d,this.dir==="ltr"?1:-1);break;default:return}c&&(a.preventDefault(),c._onButtonClick(),c.focus())}_emitChangeEvent(a){const s=new B(a,this.value);this._rawValue=s.value,this._controlValueAccessorChangeFn(s.value),this.change.emit(s)}_syncButtonToggle(a,s,r=!1,d=!1){!this.multiple&&this.selected&&!a.checked&&(this.selected.checked=!1),this._selectionModel?s?this._selectionModel.select(a):this._selectionModel.deselect(a):d=!0,d?Promise.resolve().then(()=>this._updateModelValue(a,r)):this._updateModelValue(a,r)}_isSelected(a){return this._selectionModel&&this._selectionModel.isSelected(a)}_isPrechecked(a){return typeof this._rawValue>"u"?!1:this.multiple&&Array.isArray(this._rawValue)?this._rawValue.some(s=>a.value!=null&&s===a.value):a.value===this._rawValue}_initializeTabIndex(){if(this._buttonToggles.forEach(a=>{a.tabIndex=-1}),this.selected)this.selected.tabIndex=0;else for(let a=0;a<this._buttonToggles.length;a++){const s=this._buttonToggles.get(a);if(!s.disabled){s.tabIndex=0;break}}}_getNextButton(a,s){const r=this._buttonToggles;for(let d=1;d<=r.length;d++){const c=(a+s*d+r.length)%r.length,_=r.get(c);if(_&&!_.disabled)return _}return null}_setSelectionByValue(a){if(this._rawValue=a,!this._buttonToggles)return;const s=this._buttonToggles.toArray();if(this.multiple&&a){if(!Array.isArray(a)&&(typeof ngDevMode>"u"||ngDevMode))throw Error("Value must be an array in multiple-selection mode.");this._clearSelection(),a.forEach(r=>this._selectValue(r,s))}else this._clearSelection(),this._selectValue(a,s);if(!this.multiple&&s.every(r=>r.tabIndex===-1)){for(const r of s)if(!r.disabled){r.tabIndex=0;break}}}_clearSelection(){this._selectionModel.clear(),this._buttonToggles.forEach(a=>{a.checked=!1,this.multiple||(a.tabIndex=-1)})}_selectValue(a,s){for(const r of s)if(r.value===a){r.checked=!0,this._selectionModel.select(r),this.multiple||(r.tabIndex=0);break}}_updateModelValue(a,s){s&&this._emitChangeEvent(a),this.valueChange.emit(this.value)}_markButtonsForCheck(){this._buttonToggles?.forEach(a=>a._markForCheck())}static \u0275fac=function(s){return new(s||p)};static \u0275dir=n.\u0275\u0275defineDirective({type:p,selectors:[["mat-button-toggle-group"]],contentQueries:function(s,r,d){if(s&1&&n.\u0275\u0275contentQuery(d,b,5),s&2){let c;n.\u0275\u0275queryRefresh(c=n.\u0275\u0275loadQuery())&&(r._buttonToggles=c)}},hostAttrs:[1,"mat-button-toggle-group"],hostVars:6,hostBindings:function(s,r){s&1&&n.\u0275\u0275listener("keydown",function(c){return r._keydown(c)}),s&2&&(n.\u0275\u0275attribute("role",r.multiple?"group":"radiogroup")("aria-disabled",r.disabled),n.\u0275\u0275classProp("mat-button-toggle-vertical",r.vertical)("mat-button-toggle-group-appearance-standard",r.appearance==="standard"))},inputs:{appearance:"appearance",name:"name",vertical:[2,"vertical","vertical",n.booleanAttribute],value:"value",multiple:[2,"multiple","multiple",n.booleanAttribute],disabled:[2,"disabled","disabled",n.booleanAttribute],disabledInteractive:[2,"disabledInteractive","disabledInteractive",n.booleanAttribute],hideSingleSelectionIndicator:[2,"hideSingleSelectionIndicator","hideSingleSelectionIndicator",n.booleanAttribute],hideMultipleSelectionIndicator:[2,"hideMultipleSelectionIndicator","hideMultipleSelectionIndicator",n.booleanAttribute]},outputs:{valueChange:"valueChange",change:"change"},exportAs:["matButtonToggleGroup"],features:[n.\u0275\u0275ProvidersFeature([S,{provide:D,useExisting:p}])]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(p,[{type:n.Directive,args:[{selector:"mat-button-toggle-group",providers:[S,{provide:D,useExisting:p}],host:{class:"mat-button-toggle-group","(keydown)":"_keydown($event)","[attr.role]":"multiple ? 'group' : 'radiogroup'","[attr.aria-disabled]":"disabled","[class.mat-button-toggle-vertical]":"vertical","[class.mat-button-toggle-group-appearance-standard]":'appearance === "standard"'},exportAs:"matButtonToggleGroup"}]}],()=>[],{_buttonToggles:[{type:n.ContentChildren,args:[(0,n.forwardRef)(()=>b),{descendants:!0}]}],appearance:[{type:n.Input}],name:[{type:n.Input}],vertical:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],value:[{type:n.Input}],valueChange:[{type:n.Output}],multiple:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],disabled:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],disabledInteractive:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],change:[{type:n.Output}],hideSingleSelectionIndicator:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],hideMultipleSelectionIndicator:[{type:n.Input,args:[{transform:n.booleanAttribute}]}]});class b{_changeDetectorRef=(0,n.inject)(n.ChangeDetectorRef);_elementRef=(0,n.inject)(n.ElementRef);_focusMonitor=(0,n.inject)(x.FocusMonitor);_idGenerator=(0,n.inject)(x._IdGenerator);_animationDisabled=(0,O.Rc)();_checked=!1;ariaLabel;ariaLabelledby=null;_buttonElement;buttonToggleGroup;get buttonId(){return`${this.id}-button`}id;name;value;get tabIndex(){return this._tabIndex()}set tabIndex(a){this._tabIndex.set(a)}_tabIndex;disableRipple=!1;get appearance(){return this.buttonToggleGroup?this.buttonToggleGroup.appearance:this._appearance}set appearance(a){this._appearance=a}_appearance;get checked(){return this.buttonToggleGroup?this.buttonToggleGroup._isSelected(this):this._checked}set checked(a){a!==this._checked&&(this._checked=a,this.buttonToggleGroup&&this.buttonToggleGroup._syncButtonToggle(this,this._checked),this._changeDetectorRef.markForCheck())}get disabled(){return this._disabled||this.buttonToggleGroup&&this.buttonToggleGroup.disabled}set disabled(a){this._disabled=a}_disabled=!1;get disabledInteractive(){return this._disabledInteractive||this.buttonToggleGroup!==null&&this.buttonToggleGroup.disabledInteractive}set disabledInteractive(a){this._disabledInteractive=a}_disabledInteractive;change=new n.EventEmitter;constructor(){(0,n.inject)(E._CdkPrivateStyleLoader).load(F.A);const a=(0,n.inject)(D,{optional:!0}),s=(0,n.inject)(new n.HostAttributeToken("tabindex"),{optional:!0})||"",r=(0,n.inject)(I,{optional:!0});this._tabIndex=(0,n.signal)(parseInt(s)||0,...ngDevMode?[{debugName:"_tabIndex"}]:[]),this.buttonToggleGroup=a,this._appearance=r&&r.appearance?r.appearance:"standard",this._disabledInteractive=r?.disabledInteractive??!1}ngOnInit(){const a=this.buttonToggleGroup;this.id=this.id||this._idGenerator.getId("mat-button-toggle-"),a&&(a._isPrechecked(this)?this.checked=!0:a._isSelected(this)!==this._checked&&a._syncButtonToggle(this,this._checked))}ngAfterViewInit(){this._animationDisabled||this._elementRef.nativeElement.classList.add("mat-button-toggle-animations-enabled"),this._focusMonitor.monitor(this._elementRef,!0)}ngOnDestroy(){const a=this.buttonToggleGroup;this._focusMonitor.stopMonitoring(this._elementRef),a&&a._isSelected(this)&&a._syncButtonToggle(this,!1,!1,!0)}focus(a){this._buttonElement.nativeElement.focus(a)}_onButtonClick(){if(this.disabled)return;const a=this.isSingleSelector()?!0:!this._checked;if(a!==this._checked&&(this._checked=a,this.buttonToggleGroup&&(this.buttonToggleGroup._syncButtonToggle(this,this._checked,!0),this.buttonToggleGroup._onTouched())),this.isSingleSelector()){const s=this.buttonToggleGroup._buttonToggles.find(r=>r.tabIndex===0);s&&(s.tabIndex=-1),this.tabIndex=0}this.change.emit(new B(this,this.value))}_markForCheck(){this._changeDetectorRef.markForCheck()}_getButtonName(){return this.isSingleSelector()?this.buttonToggleGroup.name:this.name||null}isSingleSelector(){return this.buttonToggleGroup&&!this.buttonToggleGroup.multiple}static \u0275fac=function(s){return new(s||b)};static \u0275cmp=n.\u0275\u0275defineComponent({type:b,selectors:[["mat-button-toggle"]],viewQuery:function(s,r){if(s&1&&n.\u0275\u0275viewQuery(A,5),s&2){let d;n.\u0275\u0275queryRefresh(d=n.\u0275\u0275loadQuery())&&(r._buttonElement=d.first)}},hostAttrs:["role","presentation",1,"mat-button-toggle"],hostVars:14,hostBindings:function(s,r){s&1&&n.\u0275\u0275listener("focus",function(){return r.focus()}),s&2&&(n.\u0275\u0275attribute("aria-label",null)("aria-labelledby",null)("id",r.id)("name",null),n.\u0275\u0275classProp("mat-button-toggle-standalone",!r.buttonToggleGroup)("mat-button-toggle-checked",r.checked)("mat-button-toggle-disabled",r.disabled)("mat-button-toggle-disabled-interactive",r.disabledInteractive)("mat-button-toggle-appearance-standard",r.appearance==="standard"))},inputs:{ariaLabel:[0,"aria-label","ariaLabel"],ariaLabelledby:[0,"aria-labelledby","ariaLabelledby"],id:"id",name:"name",value:"value",tabIndex:"tabIndex",disableRipple:[2,"disableRipple","disableRipple",n.booleanAttribute],appearance:"appearance",checked:[2,"checked","checked",n.booleanAttribute],disabled:[2,"disabled","disabled",n.booleanAttribute],disabledInteractive:[2,"disabledInteractive","disabledInteractive",n.booleanAttribute]},outputs:{change:"change"},exportAs:["matButtonToggle"],ngContentSelectors:R,decls:7,vars:13,consts:[["button",""],["type","button",1,"mat-button-toggle-button","mat-focus-indicator",3,"click","id","disabled"],[1,"mat-button-toggle-checkbox-wrapper"],[1,"mat-button-toggle-label-content"],[1,"mat-button-toggle-focus-overlay"],["matRipple","",1,"mat-button-toggle-ripple",3,"matRippleTrigger","matRippleDisabled"],["state","checked","aria-hidden","true","appearance","minimal",3,"disabled"]],template:function(s,r){if(s&1&&(n.\u0275\u0275projectionDef(),n.\u0275\u0275elementStart(0,"button",1,0),n.\u0275\u0275listener("click",function(){return r._onButtonClick()}),n.\u0275\u0275conditionalCreate(2,P,2,1,"div",2),n.\u0275\u0275elementStart(3,"span",3),n.\u0275\u0275projection(4),n.\u0275\u0275elementEnd()(),n.\u0275\u0275element(5,"span",4)(6,"span",5)),s&2){const d=n.\u0275\u0275reference(1);n.\u0275\u0275property("id",r.buttonId)("disabled",r.disabled&&!r.disabledInteractive||null),n.\u0275\u0275attribute("role",r.isSingleSelector()?"radio":"button")("tabindex",r.disabled&&!r.disabledInteractive?-1:r.tabIndex)("aria-pressed",r.isSingleSelector()?null:r.checked)("aria-checked",r.isSingleSelector()?r.checked:null)("name",r._getButtonName())("aria-label",r.ariaLabel)("aria-labelledby",r.ariaLabelledby)("aria-disabled",r.disabled&&r.disabledInteractive?"true":null),n.\u0275\u0275advance(2),n.\u0275\u0275conditional(r.buttonToggleGroup&&(!r.buttonToggleGroup.multiple&&!r.buttonToggleGroup.hideSingleSelectionIndicator||r.buttonToggleGroup.multiple&&!r.buttonToggleGroup.hideMultipleSelectionIndicator)?2:-1),n.\u0275\u0275advance(4),n.\u0275\u0275property("matRippleTrigger",d)("matRippleDisabled",r.disableRipple||r.disabled)}},dependencies:[v.r6,g.w],styles:[`.mat-button-toggle-standalone,
.mat-button-toggle-group {
  position: relative;
  display: inline-flex;
  flex-direction: row;
  white-space: nowrap;
  overflow: hidden;
  -webkit-tap-highlight-color: transparent;
  border-radius: var(--mat-button-toggle-legacy-shape);
  transform: translateZ(0);
}
.mat-button-toggle-standalone:not([class*=mat-elevation-z]),
.mat-button-toggle-group:not([class*=mat-elevation-z]) {
  box-shadow: 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12);
}
@media (forced-colors: active) {
  .mat-button-toggle-standalone,
  .mat-button-toggle-group {
    outline: solid 1px;
  }
}

.mat-button-toggle-standalone.mat-button-toggle-appearance-standard,
.mat-button-toggle-group-appearance-standard {
  border-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
.mat-button-toggle-standalone.mat-button-toggle-appearance-standard .mat-pseudo-checkbox,
.mat-button-toggle-group-appearance-standard .mat-pseudo-checkbox {
  --mat-pseudo-checkbox-minimal-selected-checkmark-color: var(--mat-button-toggle-selected-state-text-color, var(--mat-sys-on-secondary-container));
}
.mat-button-toggle-standalone.mat-button-toggle-appearance-standard:not([class*=mat-elevation-z]),
.mat-button-toggle-group-appearance-standard:not([class*=mat-elevation-z]) {
  box-shadow: none;
}
@media (forced-colors: active) {
  .mat-button-toggle-standalone.mat-button-toggle-appearance-standard,
  .mat-button-toggle-group-appearance-standard {
    outline: 0;
  }
}

.mat-button-toggle-vertical {
  flex-direction: column;
}
.mat-button-toggle-vertical .mat-button-toggle-label-content {
  display: block;
}

.mat-button-toggle {
  white-space: nowrap;
  position: relative;
  color: var(--mat-button-toggle-legacy-text-color);
  font-family: var(--mat-button-toggle-legacy-label-text-font);
  font-size: var(--mat-button-toggle-legacy-label-text-size);
  line-height: var(--mat-button-toggle-legacy-label-text-line-height);
  font-weight: var(--mat-button-toggle-legacy-label-text-weight);
  letter-spacing: var(--mat-button-toggle-legacy-label-text-tracking);
  --mat-pseudo-checkbox-minimal-selected-checkmark-color: var(--mat-button-toggle-legacy-selected-state-text-color);
}
.mat-button-toggle.cdk-keyboard-focused .mat-button-toggle-focus-overlay {
  opacity: var(--mat-button-toggle-legacy-focus-state-layer-opacity);
}
.mat-button-toggle .mat-icon svg {
  vertical-align: top;
}

.mat-button-toggle-checkbox-wrapper {
  display: inline-block;
  justify-content: flex-start;
  align-items: center;
  width: 0;
  height: 18px;
  line-height: 18px;
  overflow: hidden;
  box-sizing: border-box;
  position: absolute;
  top: 50%;
  left: 16px;
  transform: translate3d(0, -50%, 0);
}
[dir=rtl] .mat-button-toggle-checkbox-wrapper {
  left: auto;
  right: 16px;
}
.mat-button-toggle-appearance-standard .mat-button-toggle-checkbox-wrapper {
  left: 12px;
}
[dir=rtl] .mat-button-toggle-appearance-standard .mat-button-toggle-checkbox-wrapper {
  left: auto;
  right: 12px;
}
.mat-button-toggle-checked .mat-button-toggle-checkbox-wrapper {
  width: 18px;
}
.mat-button-toggle-animations-enabled .mat-button-toggle-checkbox-wrapper {
  transition: width 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-button-toggle-vertical .mat-button-toggle-checkbox-wrapper {
  transition: none;
}

.mat-button-toggle-checked {
  color: var(--mat-button-toggle-legacy-selected-state-text-color);
  background-color: var(--mat-button-toggle-legacy-selected-state-background-color);
}

.mat-button-toggle-disabled {
  pointer-events: none;
  color: var(--mat-button-toggle-legacy-disabled-state-text-color);
  background-color: var(--mat-button-toggle-legacy-disabled-state-background-color);
  --mat-pseudo-checkbox-minimal-disabled-selected-checkmark-color: var(--mat-button-toggle-legacy-disabled-state-text-color);
}
.mat-button-toggle-disabled.mat-button-toggle-checked {
  background-color: var(--mat-button-toggle-legacy-disabled-selected-state-background-color);
}

.mat-button-toggle-disabled-interactive {
  pointer-events: auto;
}

.mat-button-toggle-appearance-standard {
  color: var(--mat-button-toggle-text-color, var(--mat-sys-on-surface));
  background-color: var(--mat-button-toggle-background-color, transparent);
  font-family: var(--mat-button-toggle-label-text-font, var(--mat-sys-label-large-font));
  font-size: var(--mat-button-toggle-label-text-size, var(--mat-sys-label-large-size));
  line-height: var(--mat-button-toggle-label-text-line-height, var(--mat-sys-label-large-line-height));
  font-weight: var(--mat-button-toggle-label-text-weight, var(--mat-sys-label-large-weight));
  letter-spacing: var(--mat-button-toggle-label-text-tracking, var(--mat-sys-label-large-tracking));
}
.mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard + .mat-button-toggle-appearance-standard {
  border-left: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
[dir=rtl] .mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard + .mat-button-toggle-appearance-standard {
  border-left: none;
  border-right: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle-appearance-standard + .mat-button-toggle-appearance-standard {
  border-left: none;
  border-right: none;
  border-top: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
.mat-button-toggle-appearance-standard.mat-button-toggle-checked {
  color: var(--mat-button-toggle-selected-state-text-color, var(--mat-sys-on-secondary-container));
  background-color: var(--mat-button-toggle-selected-state-background-color, var(--mat-sys-secondary-container));
}
.mat-button-toggle-appearance-standard.mat-button-toggle-disabled {
  color: var(--mat-button-toggle-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
  background-color: var(--mat-button-toggle-disabled-state-background-color, transparent);
}
.mat-button-toggle-appearance-standard.mat-button-toggle-disabled .mat-pseudo-checkbox {
  --mat-pseudo-checkbox-minimal-disabled-selected-checkmark-color: var(--mat-button-toggle-disabled-selected-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-button-toggle-appearance-standard.mat-button-toggle-disabled.mat-button-toggle-checked {
  color: var(--mat-button-toggle-disabled-selected-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
  background-color: var(--mat-button-toggle-disabled-selected-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) 12%, transparent));
}
.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay {
  background-color: var(--mat-button-toggle-state-layer-color, var(--mat-sys-on-surface));
}
.mat-button-toggle-appearance-standard:hover .mat-button-toggle-focus-overlay {
  opacity: var(--mat-button-toggle-hover-state-layer-opacity, var(--mat-sys-hover-state-layer-opacity));
}
.mat-button-toggle-appearance-standard.cdk-keyboard-focused .mat-button-toggle-focus-overlay {
  opacity: var(--mat-button-toggle-focus-state-layer-opacity, var(--mat-sys-focus-state-layer-opacity));
}
@media (hover: none) {
  .mat-button-toggle-appearance-standard:hover .mat-button-toggle-focus-overlay {
    display: none;
  }
}

.mat-button-toggle-label-content {
  -webkit-user-select: none;
  user-select: none;
  display: inline-block;
  padding: 0 16px;
  line-height: var(--mat-button-toggle-legacy-height);
  position: relative;
}
.mat-button-toggle-appearance-standard .mat-button-toggle-label-content {
  padding: 0 12px;
  line-height: var(--mat-button-toggle-height, 40px);
}

.mat-button-toggle-label-content > * {
  vertical-align: middle;
}

.mat-button-toggle-focus-overlay {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  border-radius: inherit;
  pointer-events: none;
  opacity: 0;
  background-color: var(--mat-button-toggle-legacy-state-layer-color);
}

@media (forced-colors: active) {
  .mat-button-toggle-checked .mat-button-toggle-focus-overlay {
    border-bottom: solid 500px;
    opacity: 0.5;
    height: 0;
  }
  .mat-button-toggle-checked:hover .mat-button-toggle-focus-overlay {
    opacity: 0.6;
  }
  .mat-button-toggle-checked.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay {
    border-bottom: solid 500px;
  }
}
.mat-button-toggle .mat-button-toggle-ripple {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  pointer-events: none;
}

.mat-button-toggle-button {
  border: 0;
  background: none;
  color: inherit;
  padding: 0;
  margin: 0;
  font: inherit;
  outline: none;
  width: 100%;
  cursor: pointer;
}
.mat-button-toggle-animations-enabled .mat-button-toggle-button {
  transition: padding 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-button-toggle-vertical .mat-button-toggle-button {
  transition: none;
}
.mat-button-toggle-disabled .mat-button-toggle-button {
  cursor: default;
}
.mat-button-toggle-button::-moz-focus-inner {
  border: 0;
}
.mat-button-toggle-checked .mat-button-toggle-button:has(.mat-button-toggle-checkbox-wrapper) {
  padding-left: 30px;
}
[dir=rtl] .mat-button-toggle-checked .mat-button-toggle-button:has(.mat-button-toggle-checkbox-wrapper) {
  padding-left: 0;
  padding-right: 30px;
}

.mat-button-toggle-standalone.mat-button-toggle-appearance-standard {
  --mat-focus-indicator-border-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}

.mat-button-toggle-group-appearance-standard:not(.mat-button-toggle-vertical) .mat-button-toggle:last-of-type .mat-button-toggle-button::before {
  border-top-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-bottom-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}
.mat-button-toggle-group-appearance-standard:not(.mat-button-toggle-vertical) .mat-button-toggle:first-of-type .mat-button-toggle-button::before {
  border-top-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-bottom-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}

.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle:last-of-type .mat-button-toggle-button::before {
  border-bottom-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-bottom-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}
.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle:first-of-type .mat-button-toggle-button::before {
  border-top-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-top-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(b,[{type:n.Component,args:[{selector:"mat-button-toggle",encapsulation:n.ViewEncapsulation.None,exportAs:"matButtonToggle",changeDetection:n.ChangeDetectionStrategy.OnPush,host:{"[class.mat-button-toggle-standalone]":"!buttonToggleGroup","[class.mat-button-toggle-checked]":"checked","[class.mat-button-toggle-disabled]":"disabled","[class.mat-button-toggle-disabled-interactive]":"disabledInteractive","[class.mat-button-toggle-appearance-standard]":'appearance === "standard"',class:"mat-button-toggle","[attr.aria-label]":"null","[attr.aria-labelledby]":"null","[attr.id]":"id","[attr.name]":"null","(focus)":"focus()",role:"presentation"},imports:[v.r6,g.w],template:`<button #button class="mat-button-toggle-button mat-focus-indicator"
        type="button"
        [id]="buttonId"
        [attr.role]="isSingleSelector() ? 'radio' : 'button'"
        [attr.tabindex]="disabled && !disabledInteractive ? -1 : tabIndex"
        [attr.aria-pressed]="!isSingleSelector() ? checked : null"
        [attr.aria-checked]="isSingleSelector() ? checked : null"
        [disabled]="(disabled && !disabledInteractive) || null"
        [attr.name]="_getButtonName()"
        [attr.aria-label]="ariaLabel"
        [attr.aria-labelledby]="ariaLabelledby"
        [attr.aria-disabled]="disabled && disabledInteractive ? 'true' : null"
        (click)="_onButtonClick()">
  @if (buttonToggleGroup && (
    !buttonToggleGroup.multiple && !buttonToggleGroup.hideSingleSelectionIndicator ||
    buttonToggleGroup.multiple && !buttonToggleGroup.hideMultipleSelectionIndicator)
  ) {
    <div class="mat-button-toggle-checkbox-wrapper">
      <mat-pseudo-checkbox
        [disabled]="disabled"
        state="checked"
        aria-hidden="true"
        appearance="minimal"/>
    </div>
  }

  <span class="mat-button-toggle-label-content">
    <ng-content></ng-content>
  </span>
</button>

<span class="mat-button-toggle-focus-overlay"></span>
<span class="mat-button-toggle-ripple" matRipple
     [matRippleTrigger]="button"
     [matRippleDisabled]="disableRipple || disabled">
</span>
`,styles:[`.mat-button-toggle-standalone,
.mat-button-toggle-group {
  position: relative;
  display: inline-flex;
  flex-direction: row;
  white-space: nowrap;
  overflow: hidden;
  -webkit-tap-highlight-color: transparent;
  border-radius: var(--mat-button-toggle-legacy-shape);
  transform: translateZ(0);
}
.mat-button-toggle-standalone:not([class*=mat-elevation-z]),
.mat-button-toggle-group:not([class*=mat-elevation-z]) {
  box-shadow: 0px 3px 1px -2px rgba(0, 0, 0, 0.2), 0px 2px 2px 0px rgba(0, 0, 0, 0.14), 0px 1px 5px 0px rgba(0, 0, 0, 0.12);
}
@media (forced-colors: active) {
  .mat-button-toggle-standalone,
  .mat-button-toggle-group {
    outline: solid 1px;
  }
}

.mat-button-toggle-standalone.mat-button-toggle-appearance-standard,
.mat-button-toggle-group-appearance-standard {
  border-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
.mat-button-toggle-standalone.mat-button-toggle-appearance-standard .mat-pseudo-checkbox,
.mat-button-toggle-group-appearance-standard .mat-pseudo-checkbox {
  --mat-pseudo-checkbox-minimal-selected-checkmark-color: var(--mat-button-toggle-selected-state-text-color, var(--mat-sys-on-secondary-container));
}
.mat-button-toggle-standalone.mat-button-toggle-appearance-standard:not([class*=mat-elevation-z]),
.mat-button-toggle-group-appearance-standard:not([class*=mat-elevation-z]) {
  box-shadow: none;
}
@media (forced-colors: active) {
  .mat-button-toggle-standalone.mat-button-toggle-appearance-standard,
  .mat-button-toggle-group-appearance-standard {
    outline: 0;
  }
}

.mat-button-toggle-vertical {
  flex-direction: column;
}
.mat-button-toggle-vertical .mat-button-toggle-label-content {
  display: block;
}

.mat-button-toggle {
  white-space: nowrap;
  position: relative;
  color: var(--mat-button-toggle-legacy-text-color);
  font-family: var(--mat-button-toggle-legacy-label-text-font);
  font-size: var(--mat-button-toggle-legacy-label-text-size);
  line-height: var(--mat-button-toggle-legacy-label-text-line-height);
  font-weight: var(--mat-button-toggle-legacy-label-text-weight);
  letter-spacing: var(--mat-button-toggle-legacy-label-text-tracking);
  --mat-pseudo-checkbox-minimal-selected-checkmark-color: var(--mat-button-toggle-legacy-selected-state-text-color);
}
.mat-button-toggle.cdk-keyboard-focused .mat-button-toggle-focus-overlay {
  opacity: var(--mat-button-toggle-legacy-focus-state-layer-opacity);
}
.mat-button-toggle .mat-icon svg {
  vertical-align: top;
}

.mat-button-toggle-checkbox-wrapper {
  display: inline-block;
  justify-content: flex-start;
  align-items: center;
  width: 0;
  height: 18px;
  line-height: 18px;
  overflow: hidden;
  box-sizing: border-box;
  position: absolute;
  top: 50%;
  left: 16px;
  transform: translate3d(0, -50%, 0);
}
[dir=rtl] .mat-button-toggle-checkbox-wrapper {
  left: auto;
  right: 16px;
}
.mat-button-toggle-appearance-standard .mat-button-toggle-checkbox-wrapper {
  left: 12px;
}
[dir=rtl] .mat-button-toggle-appearance-standard .mat-button-toggle-checkbox-wrapper {
  left: auto;
  right: 12px;
}
.mat-button-toggle-checked .mat-button-toggle-checkbox-wrapper {
  width: 18px;
}
.mat-button-toggle-animations-enabled .mat-button-toggle-checkbox-wrapper {
  transition: width 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-button-toggle-vertical .mat-button-toggle-checkbox-wrapper {
  transition: none;
}

.mat-button-toggle-checked {
  color: var(--mat-button-toggle-legacy-selected-state-text-color);
  background-color: var(--mat-button-toggle-legacy-selected-state-background-color);
}

.mat-button-toggle-disabled {
  pointer-events: none;
  color: var(--mat-button-toggle-legacy-disabled-state-text-color);
  background-color: var(--mat-button-toggle-legacy-disabled-state-background-color);
  --mat-pseudo-checkbox-minimal-disabled-selected-checkmark-color: var(--mat-button-toggle-legacy-disabled-state-text-color);
}
.mat-button-toggle-disabled.mat-button-toggle-checked {
  background-color: var(--mat-button-toggle-legacy-disabled-selected-state-background-color);
}

.mat-button-toggle-disabled-interactive {
  pointer-events: auto;
}

.mat-button-toggle-appearance-standard {
  color: var(--mat-button-toggle-text-color, var(--mat-sys-on-surface));
  background-color: var(--mat-button-toggle-background-color, transparent);
  font-family: var(--mat-button-toggle-label-text-font, var(--mat-sys-label-large-font));
  font-size: var(--mat-button-toggle-label-text-size, var(--mat-sys-label-large-size));
  line-height: var(--mat-button-toggle-label-text-line-height, var(--mat-sys-label-large-line-height));
  font-weight: var(--mat-button-toggle-label-text-weight, var(--mat-sys-label-large-weight));
  letter-spacing: var(--mat-button-toggle-label-text-tracking, var(--mat-sys-label-large-tracking));
}
.mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard + .mat-button-toggle-appearance-standard {
  border-left: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
[dir=rtl] .mat-button-toggle-group-appearance-standard .mat-button-toggle-appearance-standard + .mat-button-toggle-appearance-standard {
  border-left: none;
  border-right: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle-appearance-standard + .mat-button-toggle-appearance-standard {
  border-left: none;
  border-right: none;
  border-top: solid 1px var(--mat-button-toggle-divider-color, var(--mat-sys-outline));
}
.mat-button-toggle-appearance-standard.mat-button-toggle-checked {
  color: var(--mat-button-toggle-selected-state-text-color, var(--mat-sys-on-secondary-container));
  background-color: var(--mat-button-toggle-selected-state-background-color, var(--mat-sys-secondary-container));
}
.mat-button-toggle-appearance-standard.mat-button-toggle-disabled {
  color: var(--mat-button-toggle-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
  background-color: var(--mat-button-toggle-disabled-state-background-color, transparent);
}
.mat-button-toggle-appearance-standard.mat-button-toggle-disabled .mat-pseudo-checkbox {
  --mat-pseudo-checkbox-minimal-disabled-selected-checkmark-color: var(--mat-button-toggle-disabled-selected-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-button-toggle-appearance-standard.mat-button-toggle-disabled.mat-button-toggle-checked {
  color: var(--mat-button-toggle-disabled-selected-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
  background-color: var(--mat-button-toggle-disabled-selected-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) 12%, transparent));
}
.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay {
  background-color: var(--mat-button-toggle-state-layer-color, var(--mat-sys-on-surface));
}
.mat-button-toggle-appearance-standard:hover .mat-button-toggle-focus-overlay {
  opacity: var(--mat-button-toggle-hover-state-layer-opacity, var(--mat-sys-hover-state-layer-opacity));
}
.mat-button-toggle-appearance-standard.cdk-keyboard-focused .mat-button-toggle-focus-overlay {
  opacity: var(--mat-button-toggle-focus-state-layer-opacity, var(--mat-sys-focus-state-layer-opacity));
}
@media (hover: none) {
  .mat-button-toggle-appearance-standard:hover .mat-button-toggle-focus-overlay {
    display: none;
  }
}

.mat-button-toggle-label-content {
  -webkit-user-select: none;
  user-select: none;
  display: inline-block;
  padding: 0 16px;
  line-height: var(--mat-button-toggle-legacy-height);
  position: relative;
}
.mat-button-toggle-appearance-standard .mat-button-toggle-label-content {
  padding: 0 12px;
  line-height: var(--mat-button-toggle-height, 40px);
}

.mat-button-toggle-label-content > * {
  vertical-align: middle;
}

.mat-button-toggle-focus-overlay {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  border-radius: inherit;
  pointer-events: none;
  opacity: 0;
  background-color: var(--mat-button-toggle-legacy-state-layer-color);
}

@media (forced-colors: active) {
  .mat-button-toggle-checked .mat-button-toggle-focus-overlay {
    border-bottom: solid 500px;
    opacity: 0.5;
    height: 0;
  }
  .mat-button-toggle-checked:hover .mat-button-toggle-focus-overlay {
    opacity: 0.6;
  }
  .mat-button-toggle-checked.mat-button-toggle-appearance-standard .mat-button-toggle-focus-overlay {
    border-bottom: solid 500px;
  }
}
.mat-button-toggle .mat-button-toggle-ripple {
  top: 0;
  left: 0;
  right: 0;
  bottom: 0;
  position: absolute;
  pointer-events: none;
}

.mat-button-toggle-button {
  border: 0;
  background: none;
  color: inherit;
  padding: 0;
  margin: 0;
  font: inherit;
  outline: none;
  width: 100%;
  cursor: pointer;
}
.mat-button-toggle-animations-enabled .mat-button-toggle-button {
  transition: padding 150ms 45ms cubic-bezier(0.4, 0, 0.2, 1);
}
.mat-button-toggle-vertical .mat-button-toggle-button {
  transition: none;
}
.mat-button-toggle-disabled .mat-button-toggle-button {
  cursor: default;
}
.mat-button-toggle-button::-moz-focus-inner {
  border: 0;
}
.mat-button-toggle-checked .mat-button-toggle-button:has(.mat-button-toggle-checkbox-wrapper) {
  padding-left: 30px;
}
[dir=rtl] .mat-button-toggle-checked .mat-button-toggle-button:has(.mat-button-toggle-checkbox-wrapper) {
  padding-left: 0;
  padding-right: 30px;
}

.mat-button-toggle-standalone.mat-button-toggle-appearance-standard {
  --mat-focus-indicator-border-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}

.mat-button-toggle-group-appearance-standard:not(.mat-button-toggle-vertical) .mat-button-toggle:last-of-type .mat-button-toggle-button::before {
  border-top-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-bottom-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}
.mat-button-toggle-group-appearance-standard:not(.mat-button-toggle-vertical) .mat-button-toggle:first-of-type .mat-button-toggle-button::before {
  border-top-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-bottom-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}

.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle:last-of-type .mat-button-toggle-button::before {
  border-bottom-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-bottom-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}
.mat-button-toggle-group-appearance-standard.mat-button-toggle-vertical .mat-button-toggle:first-of-type .mat-button-toggle-button::before {
  border-top-right-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
  border-top-left-radius: var(--mat-button-toggle-shape, var(--mat-sys-corner-extra-large));
}
`]}]}],()=>[],{ariaLabel:[{type:n.Input,args:["aria-label"]}],ariaLabelledby:[{type:n.Input,args:["aria-labelledby"]}],_buttonElement:[{type:n.ViewChild,args:["button"]}],id:[{type:n.Input}],name:[{type:n.Input}],value:[{type:n.Input}],tabIndex:[{type:n.Input}],disableRipple:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],appearance:[{type:n.Input}],checked:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],disabled:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],disabledInteractive:[{type:n.Input,args:[{transform:n.booleanAttribute}]}],change:[{type:n.Output}]});class f{static \u0275fac=function(s){return new(s||f)};static \u0275mod=n.\u0275\u0275defineNgModule({type:f});static \u0275inj=n.\u0275\u0275defineInjector({imports:[M.p,b,C.BidiModule]})}(typeof ngDevMode>"u"||ngDevMode)&&n.\u0275setClassMetadata(f,[{type:n.NgModule,args:[{imports:[M.p,p,b],exports:[C.BidiModule,p,b]}]}],null,null)},45683(V,T,l){l.r(T),l.d(T,{MAT_DRAWER_DEFAULT_AUTOSIZE:()=>b,MatDrawer:()=>a,MatDrawerContainer:()=>s,MatDrawerContent:()=>u,MatSidenav:()=>d,MatSidenavContainer:()=>c,MatSidenavContent:()=>r,MatSidenavModule:()=>_,throwMatDuplicatedDrawerError:()=>p});var x=l(17220),C=l(38912),y=l(88208),k=l(9812),E=l(9204),n=l(25924),t=l(40231),v=l(26233),g=l(83229),O=l(34630),F=l(65868);const M=["*"],j=["content"],z=[[["mat-drawer"]],[["mat-drawer-content"]],"*"],G=["mat-drawer","mat-drawer-content","*"];function A(w,e){if(w&1){const o=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"div",1),t.\u0275\u0275listener("click",function(){t.\u0275\u0275restoreView(o);const m=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(m._onBackdropClicked())}),t.\u0275\u0275elementEnd()}if(w&2){const o=t.\u0275\u0275nextContext();t.\u0275\u0275classProp("mat-drawer-shown",o._isShowingBackdrop())}}function R(w,e){w&1&&(t.\u0275\u0275elementStart(0,"mat-drawer-content"),t.\u0275\u0275projection(1,2),t.\u0275\u0275elementEnd())}const P=[[["mat-sidenav"]],[["mat-sidenav-content"]],"*"],I=["mat-sidenav","mat-sidenav-content","*"];function D(w,e){if(w&1){const o=t.\u0275\u0275getCurrentView();t.\u0275\u0275elementStart(0,"div",1),t.\u0275\u0275listener("click",function(){t.\u0275\u0275restoreView(o);const m=t.\u0275\u0275nextContext();return t.\u0275\u0275resetView(m._onBackdropClicked())}),t.\u0275\u0275elementEnd()}if(w&2){const o=t.\u0275\u0275nextContext();t.\u0275\u0275classProp("mat-drawer-shown",o._isShowingBackdrop())}}function S(w,e){w&1&&(t.\u0275\u0275elementStart(0,"mat-sidenav-content"),t.\u0275\u0275projection(1,2),t.\u0275\u0275elementEnd())}const B=`.mat-drawer-container {
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
`;function p(w){throw Error(`A drawer was already declared for 'position="${w}"'`)}const b=new t.InjectionToken("MAT_DRAWER_DEFAULT_AUTOSIZE",{providedIn:"root",factory:()=>!1}),f=new t.InjectionToken("MAT_DRAWER_CONTAINER");class u extends n.CdkScrollable{_platform=(0,t.inject)(E.Platform);_changeDetectorRef=(0,t.inject)(t.ChangeDetectorRef);_container=(0,t.inject)(s);constructor(){const e=(0,t.inject)(t.ElementRef),o=(0,t.inject)(n.ScrollDispatcher),i=(0,t.inject)(t.NgZone);super(e,o,i)}ngAfterContentInit(){this._container._contentMarginChanges.subscribe(()=>{this._changeDetectorRef.markForCheck()})}_shouldBeHidden(){if(this._platform.isBrowser)return!1;const{start:e,end:o}=this._container;return e!=null&&e.mode!=="over"&&e.opened||o!=null&&o.mode!=="over"&&o.opened}static \u0275fac=function(o){return new(o||u)};static \u0275cmp=t.\u0275\u0275defineComponent({type:u,selectors:[["mat-drawer-content"]],hostAttrs:[1,"mat-drawer-content"],hostVars:6,hostBindings:function(o,i){o&2&&(t.\u0275\u0275styleProp("margin-left",i._container._contentMargins.left,"px")("margin-right",i._container._contentMargins.right,"px"),t.\u0275\u0275classProp("mat-drawer-content-hidden",i._shouldBeHidden()))},features:[t.\u0275\u0275ProvidersFeature([{provide:n.CdkScrollable,useExisting:u}]),t.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:M,decls:1,vars:0,template:function(o,i){o&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275projection(0))},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(u,[{type:t.Component,args:[{selector:"mat-drawer-content",template:"<ng-content></ng-content>",host:{class:"mat-drawer-content","[style.margin-left.px]":"_container._contentMargins.left","[style.margin-right.px]":"_container._contentMargins.right","[class.mat-drawer-content-hidden]":"_shouldBeHidden()"},changeDetection:t.ChangeDetectionStrategy.OnPush,encapsulation:t.ViewEncapsulation.None,providers:[{provide:n.CdkScrollable,useExisting:u}]}]}],()=>[],null);class a{_elementRef=(0,t.inject)(t.ElementRef);_focusTrapFactory=(0,t.inject)(x.FocusTrapFactory);_focusMonitor=(0,t.inject)(x.FocusMonitor);_platform=(0,t.inject)(E.Platform);_ngZone=(0,t.inject)(t.NgZone);_renderer=(0,t.inject)(t.Renderer2);_interactivityChecker=(0,t.inject)(x.InteractivityChecker);_doc=(0,t.inject)(t.DOCUMENT);_container=(0,t.inject)(f,{optional:!0});_focusTrap=null;_elementFocusedBeforeDrawerWasOpened=null;_eventCleanups;_isAttached=!1;_anchor=null;get position(){return this._position}set position(e){e=e==="end"?"end":"start",e!==this._position&&(this._isAttached&&this._updatePositionInParent(e),this._position=e,this.onPositionChanged.emit())}_position="start";get mode(){return this._mode}set mode(e){this._mode=e,this._updateFocusTrapState(),this._modeChanged.next()}_mode="over";get disableClose(){return this._disableClose}set disableClose(e){this._disableClose=(0,y.coerceBooleanProperty)(e)}_disableClose=!1;get autoFocus(){const e=this._autoFocus;return e??(this.mode==="side"?"dialog":"first-tabbable")}set autoFocus(e){(e==="true"||e==="false"||e==null)&&(e=(0,y.coerceBooleanProperty)(e)),this._autoFocus=e}_autoFocus;get opened(){return this._opened()}set opened(e){this.toggle((0,y.coerceBooleanProperty)(e))}_opened=(0,t.signal)(!1,...ngDevMode?[{debugName:"_opened"}]:[]);_openedVia=null;_animationStarted=new v.Subject;_animationEnd=new v.Subject;openedChange=new t.EventEmitter(!0);_openedStream=this.openedChange.pipe((0,g.filter)(e=>e),(0,g.map)(()=>{}));openedStart=this._animationStarted.pipe((0,g.filter)(()=>this.opened),(0,g.mapTo)(void 0));_closedStream=this.openedChange.pipe((0,g.filter)(e=>!e),(0,g.map)(()=>{}));closedStart=this._animationStarted.pipe((0,g.filter)(()=>!this.opened),(0,g.mapTo)(void 0));_destroyed=new v.Subject;onPositionChanged=new t.EventEmitter;_content;_modeChanged=new v.Subject;_injector=(0,t.inject)(t.Injector);_changeDetectorRef=(0,t.inject)(t.ChangeDetectorRef);constructor(){this.openedChange.pipe((0,g.takeUntil)(this._destroyed)).subscribe(e=>{e?(this._elementFocusedBeforeDrawerWasOpened=this._doc.activeElement,this._takeFocus()):this._isFocusWithinDrawer()&&this._restoreFocus(this._openedVia||"program")}),this._eventCleanups=this._ngZone.runOutsideAngular(()=>{const e=this._renderer,o=this._elementRef.nativeElement;return[e.listen(o,"keydown",i=>{i.keyCode===k.ESCAPE&&!this.disableClose&&!(0,k.hasModifierKey)(i)&&this._ngZone.run(()=>{this.close(),i.stopPropagation(),i.preventDefault()})}),e.listen(o,"transitionend",this._handleTransitionEvent),e.listen(o,"transitioncancel",this._handleTransitionEvent)]}),this._animationEnd.subscribe(()=>{this.openedChange.emit(this.opened)})}_forceFocus(e,o){this._interactivityChecker.isFocusable(e)||(e.tabIndex=-1,this._ngZone.runOutsideAngular(()=>{const i=()=>{m(),h(),e.removeAttribute("tabindex")},m=this._renderer.listen(e,"blur",i),h=this._renderer.listen(e,"mousedown",i)})),e.focus(o)}_focusByCssSelector(e,o){let i=this._elementRef.nativeElement.querySelector(e);i&&this._forceFocus(i,o)}_takeFocus(){if(!this._focusTrap)return;const e=this._elementRef.nativeElement;switch(this.autoFocus){case!1:case"dialog":return;case!0:case"first-tabbable":(0,t.afterNextRender)(()=>{!this._focusTrap.focusInitialElement()&&typeof e.focus=="function"&&e.focus()},{injector:this._injector});break;case"first-heading":this._focusByCssSelector('h1, h2, h3, h4, h5, h6, [role="heading"]');break;default:this._focusByCssSelector(this.autoFocus);break}}_restoreFocus(e){this.autoFocus!=="dialog"&&(this._elementFocusedBeforeDrawerWasOpened?this._focusMonitor.focusVia(this._elementFocusedBeforeDrawerWasOpened,e):this._elementRef.nativeElement.blur(),this._elementFocusedBeforeDrawerWasOpened=null)}_isFocusWithinDrawer(){const e=this._doc.activeElement;return!!e&&this._elementRef.nativeElement.contains(e)}ngAfterViewInit(){this._isAttached=!0,this._position==="end"&&this._updatePositionInParent("end"),this._platform.isBrowser&&(this._focusTrap=this._focusTrapFactory.create(this._elementRef.nativeElement),this._updateFocusTrapState())}ngOnDestroy(){this._eventCleanups.forEach(e=>e()),this._focusTrap?.destroy(),this._anchor?.remove(),this._anchor=null,this._animationStarted.complete(),this._animationEnd.complete(),this._modeChanged.complete(),this._destroyed.next(),this._destroyed.complete()}open(e){return this.toggle(!0,e)}close(){return this.toggle(!1)}_closeViaBackdropClick(){return this._setOpen(!1,!0,"mouse")}toggle(e=!this.opened,o){e&&o&&(this._openedVia=o);const i=this._setOpen(e,!e&&this._isFocusWithinDrawer(),this._openedVia||"program");return e||(this._openedVia=null),i}_setOpen(e,o,i){return e===this.opened?Promise.resolve(e?"open":"close"):(this._opened.set(e),this._container?._transitionsEnabled?(this._setIsAnimating(!0),setTimeout(()=>this._animationStarted.next())):setTimeout(()=>{this._animationStarted.next(),this._animationEnd.next()}),this._elementRef.nativeElement.classList.toggle("mat-drawer-opened",e),!e&&o&&this._restoreFocus(i),this._changeDetectorRef.markForCheck(),this._updateFocusTrapState(),new Promise(m=>{this.openedChange.pipe((0,g.take)(1)).subscribe(h=>m(h?"open":"close"))}))}_setIsAnimating(e){this._elementRef.nativeElement.classList.toggle("mat-drawer-animating",e)}_getWidth(){return this._elementRef.nativeElement.offsetWidth||0}_updateFocusTrapState(){this._focusTrap&&(this._focusTrap.enabled=this.opened&&!!this._container?._isShowingBackdrop())}_updatePositionInParent(e){if(!this._platform.isBrowser)return;const o=this._elementRef.nativeElement,i=o.parentNode;e==="end"?(this._anchor||(this._anchor=this._doc.createComment("mat-drawer-anchor"),i.insertBefore(this._anchor,o)),i.appendChild(o)):this._anchor&&this._anchor.parentNode.insertBefore(o,this._anchor)}_handleTransitionEvent=e=>{const o=this._elementRef.nativeElement;e.target===o&&this._ngZone.run(()=>{e.type==="transitionend"&&this._setIsAnimating(!1),this._animationEnd.next(e)})};static \u0275fac=function(o){return new(o||a)};static \u0275cmp=t.\u0275\u0275defineComponent({type:a,selectors:[["mat-drawer"]],viewQuery:function(o,i){if(o&1&&t.\u0275\u0275viewQuery(j,5),o&2){let m;t.\u0275\u0275queryRefresh(m=t.\u0275\u0275loadQuery())&&(i._content=m.first)}},hostAttrs:[1,"mat-drawer"],hostVars:12,hostBindings:function(o,i){o&2&&(t.\u0275\u0275attribute("align",null)("tabIndex",i.mode!=="side"?"-1":null),t.\u0275\u0275styleProp("visibility",!i._container&&!i.opened?"hidden":null),t.\u0275\u0275classProp("mat-drawer-end",i.position==="end")("mat-drawer-over",i.mode==="over")("mat-drawer-push",i.mode==="push")("mat-drawer-side",i.mode==="side"))},inputs:{position:"position",mode:"mode",disableClose:"disableClose",autoFocus:"autoFocus",opened:"opened"},outputs:{openedChange:"openedChange",_openedStream:"opened",openedStart:"openedStart",_closedStream:"closed",closedStart:"closedStart",onPositionChanged:"positionChanged"},exportAs:["matDrawer"],ngContentSelectors:M,decls:3,vars:0,consts:[["content",""],["cdkScrollable","",1,"mat-drawer-inner-container"]],template:function(o,i){o&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275elementStart(0,"div",1,0),t.\u0275\u0275projection(2),t.\u0275\u0275elementEnd())},dependencies:[n.CdkScrollable],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(a,[{type:t.Component,args:[{selector:"mat-drawer",exportAs:"matDrawer",host:{class:"mat-drawer","[attr.align]":"null","[class.mat-drawer-end]":'position === "end"',"[class.mat-drawer-over]":'mode === "over"',"[class.mat-drawer-push]":'mode === "push"',"[class.mat-drawer-side]":'mode === "side"',"[style.visibility]":'(!_container && !opened) ? "hidden" : null',"[attr.tabIndex]":'(mode !== "side") ? "-1" : null'},changeDetection:t.ChangeDetectionStrategy.OnPush,encapsulation:t.ViewEncapsulation.None,imports:[n.CdkScrollable],template:`<div class="mat-drawer-inner-container" cdkScrollable #content>\r
  <ng-content></ng-content>\r
</div>\r
`}]}],()=>[],{position:[{type:t.Input}],mode:[{type:t.Input}],disableClose:[{type:t.Input}],autoFocus:[{type:t.Input}],opened:[{type:t.Input}],openedChange:[{type:t.Output}],_openedStream:[{type:t.Output,args:["opened"]}],openedStart:[{type:t.Output}],_closedStream:[{type:t.Output,args:["closed"]}],closedStart:[{type:t.Output}],onPositionChanged:[{type:t.Output,args:["positionChanged"]}],_content:[{type:t.ViewChild,args:["content"]}]});class s{_dir=(0,t.inject)(C.Directionality,{optional:!0});_element=(0,t.inject)(t.ElementRef);_ngZone=(0,t.inject)(t.NgZone);_changeDetectorRef=(0,t.inject)(t.ChangeDetectorRef);_animationDisabled=(0,O.Rc)();_transitionsEnabled=!1;_allDrawers;_drawers=new t.QueryList;_content;_userContent;get start(){return this._start}get end(){return this._end}get autosize(){return this._autosize}set autosize(e){this._autosize=(0,y.coerceBooleanProperty)(e)}_autosize=(0,t.inject)(b);get hasBackdrop(){return this._drawerHasBackdrop(this._start)||this._drawerHasBackdrop(this._end)}set hasBackdrop(e){this._backdropOverride=e==null?null:(0,y.coerceBooleanProperty)(e)}_backdropOverride=null;backdropClick=new t.EventEmitter;_start=null;_end=null;_left=null;_right=null;_destroyed=new v.Subject;_doCheckSubject=new v.Subject;_contentMargins={left:null,right:null};_contentMarginChanges=new v.Subject;get scrollable(){return this._userContent||this._content}_injector=(0,t.inject)(t.Injector);constructor(){const e=(0,t.inject)(E.Platform),o=(0,t.inject)(n.ViewportRuler);this._dir?.change.pipe((0,g.takeUntil)(this._destroyed)).subscribe(()=>{this._validateDrawers(),this.updateContentMargins()}),o.change().pipe((0,g.takeUntil)(this._destroyed)).subscribe(()=>this.updateContentMargins()),!this._animationDisabled&&e.isBrowser&&this._ngZone.runOutsideAngular(()=>{setTimeout(()=>{this._element.nativeElement.classList.add("mat-drawer-transition"),this._transitionsEnabled=!0},200)})}ngAfterContentInit(){this._allDrawers.changes.pipe((0,g.startWith)(this._allDrawers),(0,g.takeUntil)(this._destroyed)).subscribe(e=>{this._drawers.reset(e.filter(o=>!o._container||o._container===this)),this._drawers.notifyOnChanges()}),this._drawers.changes.pipe((0,g.startWith)(null)).subscribe(()=>{this._validateDrawers(),this._drawers.forEach(e=>{this._watchDrawerToggle(e),this._watchDrawerPosition(e),this._watchDrawerMode(e)}),(!this._drawers.length||this._isDrawerOpen(this._start)||this._isDrawerOpen(this._end))&&this.updateContentMargins(),this._changeDetectorRef.markForCheck()}),this._ngZone.runOutsideAngular(()=>{this._doCheckSubject.pipe((0,g.debounceTime)(10),(0,g.takeUntil)(this._destroyed)).subscribe(()=>this.updateContentMargins())})}ngOnDestroy(){this._contentMarginChanges.complete(),this._doCheckSubject.complete(),this._drawers.destroy(),this._destroyed.next(),this._destroyed.complete()}open(){this._drawers.forEach(e=>e.open())}close(){this._drawers.forEach(e=>e.close())}updateContentMargins(){let e=0,o=0;if(this._left&&this._left.opened){if(this._left.mode=="side")e+=this._left._getWidth();else if(this._left.mode=="push"){const i=this._left._getWidth();e+=i,o-=i}}if(this._right&&this._right.opened){if(this._right.mode=="side")o+=this._right._getWidth();else if(this._right.mode=="push"){const i=this._right._getWidth();o+=i,e-=i}}e=e||null,o=o||null,(e!==this._contentMargins.left||o!==this._contentMargins.right)&&(this._contentMargins={left:e,right:o},this._ngZone.run(()=>this._contentMarginChanges.next(this._contentMargins)))}ngDoCheck(){this._autosize&&this._isPushed()&&this._ngZone.runOutsideAngular(()=>this._doCheckSubject.next())}_watchDrawerToggle(e){e._animationStarted.pipe((0,g.takeUntil)(this._drawers.changes)).subscribe(()=>{this.updateContentMargins(),this._changeDetectorRef.markForCheck()}),e.mode!=="side"&&e.openedChange.pipe((0,g.takeUntil)(this._drawers.changes)).subscribe(()=>this._setContainerClass(e.opened))}_watchDrawerPosition(e){e.onPositionChanged.pipe((0,g.takeUntil)(this._drawers.changes)).subscribe(()=>{(0,t.afterNextRender)({read:()=>this._validateDrawers()},{injector:this._injector})})}_watchDrawerMode(e){e._modeChanged.pipe((0,g.takeUntil)((0,v.merge)(this._drawers.changes,this._destroyed))).subscribe(()=>{this.updateContentMargins(),this._changeDetectorRef.markForCheck()})}_setContainerClass(e){const o=this._element.nativeElement.classList,i="mat-drawer-container-has-open";e?o.add(i):o.remove(i)}_validateDrawers(){this._start=this._end=null,this._drawers.forEach(e=>{e.position=="end"?(this._end!=null&&(typeof ngDevMode>"u"||ngDevMode)&&p("end"),this._end=e):(this._start!=null&&(typeof ngDevMode>"u"||ngDevMode)&&p("start"),this._start=e)}),this._right=this._left=null,this._dir&&this._dir.value==="rtl"?(this._left=this._end,this._right=this._start):(this._left=this._start,this._right=this._end)}_isPushed(){return this._isDrawerOpen(this._start)&&this._start.mode!="over"||this._isDrawerOpen(this._end)&&this._end.mode!="over"}_onBackdropClicked(){this.backdropClick.emit(),this._closeModalDrawersViaBackdrop()}_closeModalDrawersViaBackdrop(){[this._start,this._end].filter(e=>e&&!e.disableClose&&this._drawerHasBackdrop(e)).forEach(e=>e._closeViaBackdropClick())}_isShowingBackdrop(){return this._isDrawerOpen(this._start)&&this._drawerHasBackdrop(this._start)||this._isDrawerOpen(this._end)&&this._drawerHasBackdrop(this._end)}_isDrawerOpen(e){return e!=null&&e.opened}_drawerHasBackdrop(e){return this._backdropOverride==null?!!e&&e.mode!=="side":this._backdropOverride}static \u0275fac=function(o){return new(o||s)};static \u0275cmp=t.\u0275\u0275defineComponent({type:s,selectors:[["mat-drawer-container"]],contentQueries:function(o,i,m){if(o&1&&t.\u0275\u0275contentQuery(m,u,5)(m,a,5),o&2){let h;t.\u0275\u0275queryRefresh(h=t.\u0275\u0275loadQuery())&&(i._content=h.first),t.\u0275\u0275queryRefresh(h=t.\u0275\u0275loadQuery())&&(i._allDrawers=h)}},viewQuery:function(o,i){if(o&1&&t.\u0275\u0275viewQuery(u,5),o&2){let m;t.\u0275\u0275queryRefresh(m=t.\u0275\u0275loadQuery())&&(i._userContent=m.first)}},hostAttrs:[1,"mat-drawer-container"],hostVars:2,hostBindings:function(o,i){o&2&&t.\u0275\u0275classProp("mat-drawer-container-explicit-backdrop",i._backdropOverride)},inputs:{autosize:"autosize",hasBackdrop:"hasBackdrop"},outputs:{backdropClick:"backdropClick"},exportAs:["matDrawerContainer"],features:[t.\u0275\u0275ProvidersFeature([{provide:f,useExisting:s}])],ngContentSelectors:G,decls:4,vars:2,consts:[[1,"mat-drawer-backdrop",3,"mat-drawer-shown"],[1,"mat-drawer-backdrop",3,"click"]],template:function(o,i){o&1&&(t.\u0275\u0275projectionDef(z),t.\u0275\u0275conditionalCreate(0,A,1,2,"div",0),t.\u0275\u0275projection(1),t.\u0275\u0275projection(2,1),t.\u0275\u0275conditionalCreate(3,R,2,0,"mat-drawer-content")),o&2&&(t.\u0275\u0275conditional(i.hasBackdrop?0:-1),t.\u0275\u0275advance(3),t.\u0275\u0275conditional(i._content?-1:3))},dependencies:[u],styles:[`.mat-drawer-container {
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
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(s,[{type:t.Component,args:[{selector:"mat-drawer-container",exportAs:"matDrawerContainer",host:{class:"mat-drawer-container","[class.mat-drawer-container-explicit-backdrop]":"_backdropOverride"},changeDetection:t.ChangeDetectionStrategy.OnPush,encapsulation:t.ViewEncapsulation.None,providers:[{provide:f,useExisting:s}],imports:[u],template:`@if (hasBackdrop) {
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
`]}]}],()=>[],{_allDrawers:[{type:t.ContentChildren,args:[a,{descendants:!0}]}],_content:[{type:t.ContentChild,args:[u]}],_userContent:[{type:t.ViewChild,args:[u]}],autosize:[{type:t.Input}],hasBackdrop:[{type:t.Input}],backdropClick:[{type:t.Output}]});class r extends u{static \u0275fac=(()=>{let e;return function(i){return(e||(e=t.\u0275\u0275getInheritedFactory(r)))(i||r)}})();static \u0275cmp=t.\u0275\u0275defineComponent({type:r,selectors:[["mat-sidenav-content"]],hostAttrs:[1,"mat-drawer-content","mat-sidenav-content"],features:[t.\u0275\u0275ProvidersFeature([{provide:n.CdkScrollable,useExisting:r}]),t.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:M,decls:1,vars:0,template:function(o,i){o&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275projection(0))},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(r,[{type:t.Component,args:[{selector:"mat-sidenav-content",template:"<ng-content></ng-content>",host:{class:"mat-drawer-content mat-sidenav-content"},changeDetection:t.ChangeDetectionStrategy.OnPush,encapsulation:t.ViewEncapsulation.None,providers:[{provide:n.CdkScrollable,useExisting:r}]}]}],null,null);class d extends a{get fixedInViewport(){return this._fixedInViewport}set fixedInViewport(e){this._fixedInViewport=(0,y.coerceBooleanProperty)(e)}_fixedInViewport=!1;get fixedTopGap(){return this._fixedTopGap}set fixedTopGap(e){this._fixedTopGap=(0,y.coerceNumberProperty)(e)}_fixedTopGap=0;get fixedBottomGap(){return this._fixedBottomGap}set fixedBottomGap(e){this._fixedBottomGap=(0,y.coerceNumberProperty)(e)}_fixedBottomGap=0;static \u0275fac=(()=>{let e;return function(i){return(e||(e=t.\u0275\u0275getInheritedFactory(d)))(i||d)}})();static \u0275cmp=t.\u0275\u0275defineComponent({type:d,selectors:[["mat-sidenav"]],hostAttrs:[1,"mat-drawer","mat-sidenav"],hostVars:16,hostBindings:function(o,i){o&2&&(t.\u0275\u0275attribute("tabIndex",i.mode!=="side"?"-1":null)("align",null),t.\u0275\u0275styleProp("top",i.fixedInViewport?i.fixedTopGap:null,"px")("bottom",i.fixedInViewport?i.fixedBottomGap:null,"px"),t.\u0275\u0275classProp("mat-drawer-end",i.position==="end")("mat-drawer-over",i.mode==="over")("mat-drawer-push",i.mode==="push")("mat-drawer-side",i.mode==="side")("mat-sidenav-fixed",i.fixedInViewport))},inputs:{fixedInViewport:"fixedInViewport",fixedTopGap:"fixedTopGap",fixedBottomGap:"fixedBottomGap"},exportAs:["matSidenav"],features:[t.\u0275\u0275ProvidersFeature([{provide:a,useExisting:d}]),t.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:M,decls:3,vars:0,consts:[["content",""],["cdkScrollable","",1,"mat-drawer-inner-container"]],template:function(o,i){o&1&&(t.\u0275\u0275projectionDef(),t.\u0275\u0275elementStart(0,"div",1,0),t.\u0275\u0275projection(2),t.\u0275\u0275elementEnd())},dependencies:[n.CdkScrollable],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(d,[{type:t.Component,args:[{selector:"mat-sidenav",exportAs:"matSidenav",host:{class:"mat-drawer mat-sidenav","[attr.tabIndex]":'(mode !== "side") ? "-1" : null',"[attr.align]":"null","[class.mat-drawer-end]":'position === "end"',"[class.mat-drawer-over]":'mode === "over"',"[class.mat-drawer-push]":'mode === "push"',"[class.mat-drawer-side]":'mode === "side"',"[class.mat-sidenav-fixed]":"fixedInViewport","[style.top.px]":"fixedInViewport ? fixedTopGap : null","[style.bottom.px]":"fixedInViewport ? fixedBottomGap : null"},changeDetection:t.ChangeDetectionStrategy.OnPush,encapsulation:t.ViewEncapsulation.None,imports:[n.CdkScrollable],providers:[{provide:a,useExisting:d}],template:`<div class="mat-drawer-inner-container" cdkScrollable #content>\r
  <ng-content></ng-content>\r
</div>\r
`}]}],null,{fixedInViewport:[{type:t.Input}],fixedTopGap:[{type:t.Input}],fixedBottomGap:[{type:t.Input}]});class c extends s{_allDrawers=void 0;_content=void 0;static \u0275fac=(()=>{let e;return function(i){return(e||(e=t.\u0275\u0275getInheritedFactory(c)))(i||c)}})();static \u0275cmp=t.\u0275\u0275defineComponent({type:c,selectors:[["mat-sidenav-container"]],contentQueries:function(o,i,m){if(o&1&&t.\u0275\u0275contentQuery(m,r,5)(m,d,5),o&2){let h;t.\u0275\u0275queryRefresh(h=t.\u0275\u0275loadQuery())&&(i._content=h.first),t.\u0275\u0275queryRefresh(h=t.\u0275\u0275loadQuery())&&(i._allDrawers=h)}},hostAttrs:[1,"mat-drawer-container","mat-sidenav-container"],hostVars:2,hostBindings:function(o,i){o&2&&t.\u0275\u0275classProp("mat-drawer-container-explicit-backdrop",i._backdropOverride)},exportAs:["matSidenavContainer"],features:[t.\u0275\u0275ProvidersFeature([{provide:f,useExisting:c},{provide:s,useExisting:c}]),t.\u0275\u0275InheritDefinitionFeature],ngContentSelectors:I,decls:4,vars:2,consts:[[1,"mat-drawer-backdrop",3,"mat-drawer-shown"],[1,"mat-drawer-backdrop",3,"click"]],template:function(o,i){o&1&&(t.\u0275\u0275projectionDef(P),t.\u0275\u0275conditionalCreate(0,D,1,2,"div",0),t.\u0275\u0275projection(1),t.\u0275\u0275projection(2,1),t.\u0275\u0275conditionalCreate(3,S,2,0,"mat-sidenav-content")),o&2&&(t.\u0275\u0275conditional(i.hasBackdrop?0:-1),t.\u0275\u0275advance(3),t.\u0275\u0275conditional(i._content?-1:3))},dependencies:[r],styles:[B],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(c,[{type:t.Component,args:[{selector:"mat-sidenav-container",exportAs:"matSidenavContainer",host:{class:"mat-drawer-container mat-sidenav-container","[class.mat-drawer-container-explicit-backdrop]":"_backdropOverride"},changeDetection:t.ChangeDetectionStrategy.OnPush,encapsulation:t.ViewEncapsulation.None,providers:[{provide:f,useExisting:c},{provide:s,useExisting:c}],imports:[r],template:`@if (hasBackdrop) {
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
`]}]}],null,{_allDrawers:[{type:t.ContentChildren,args:[d,{descendants:!0}]}],_content:[{type:t.ContentChild,args:[r]}]});class _{static \u0275fac=function(o){return new(o||_)};static \u0275mod=t.\u0275\u0275defineNgModule({type:_});static \u0275inj=t.\u0275\u0275defineInjector({imports:[n.CdkScrollableModule,C.BidiModule,n.CdkScrollableModule]})}(typeof ngDevMode>"u"||ngDevMode)&&t.\u0275setClassMetadata(_,[{type:t.NgModule,args:[{imports:[n.CdkScrollableModule,a,s,u,d,c,r],exports:[C.BidiModule,n.CdkScrollableModule,a,s,u,d,c,r]}]}],null,null)}}]);
