(self.webpackChunkapp_studio_enterprise_structure_explorer=self.webpackChunkapp_studio_enterprise_structure_explorer||[]).push([[2839],{43955(ie,T,c){c.d(T,{Ju:()=>p,MJ:()=>_,de:()=>v});var e=c(39638),m=c(88632);const p=new e.InjectionToken("MAT_DATE_LOCALE",{providedIn:"root",factory:()=>(0,e.inject)(e.LOCALE_ID)}),h="Method not implemented";class _{locale;_localeChanges=new m.Subject;localeChanges=this._localeChanges;setTime(d,u,g,A){throw new Error(h)}getHours(d){throw new Error(h)}getMinutes(d){throw new Error(h)}getSeconds(d){throw new Error(h)}parseTime(d,u){throw new Error(h)}addSeconds(d,u){throw new Error(h)}getValidDateOrNull(d){return this.isDateInstance(d)&&this.isValid(d)?d:null}deserialize(d){return d==null||this.isDateInstance(d)&&this.isValid(d)?d:this.invalid()}setLocale(d){this.locale=d,this._localeChanges.next()}compareDate(d,u){return this.getYear(d)-this.getYear(u)||this.getMonth(d)-this.getMonth(u)||this.getDate(d)-this.getDate(u)}compareTime(d,u){return this.getHours(d)-this.getHours(u)||this.getMinutes(d)-this.getMinutes(u)||this.getSeconds(d)-this.getSeconds(u)}sameDate(d,u){if(d&&u){let g=this.isValid(d),A=this.isValid(u);return g&&A?!this.compareDate(d,u):g==A}return d==u}sameTime(d,u){if(d&&u){const g=this.isValid(d),A=this.isValid(u);return g&&A?!this.compareTime(d,u):g==A}return d==u}clampDate(d,u,g){return u&&this.compareDate(d,u)<0?u:g&&this.compareDate(d,g)>0?g:d}}const v=new e.InjectionToken("mat-date-formats")},48827(ie,T,c){c.d(T,{_:()=>m,e:()=>p});var e=c(39638);class m{isErrorState(_,v){return!!(_&&_.invalid&&(_.dirty||v&&v.submitted))}static \u0275fac=function(v){return new(v||m)};static \u0275prov=e.\u0275\u0275defineInjectable({token:m,factory:m.\u0275fac})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(m,[{type:e.Injectable}],null,null);class p{isErrorState(_,v){return!!(_&&_.invalid&&(_.touched||v&&v.submitted))}static \u0275fac=function(v){return new(v||p)};static \u0275prov=e.\u0275\u0275defineInjectable({token:p,factory:p.\u0275fac,providedIn:"root"})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(p,[{type:e.Injectable,args:[{providedIn:"root"}]}],null,null)},3146(ie,T,c){c.d(T,{X:()=>e});class e{_defaultMatcher;ngControl;_parentFormGroup;_parentForm;_stateChanges;errorState=!1;matcher;constructor(p,h,_,v,o){this._defaultMatcher=p,this.ngControl=h,this._parentFormGroup=_,this._parentForm=v,this._stateChanges=o}updateErrorState(){const p=this.errorState,h=this._parentFormGroup||this._parentForm,_=this.matcher||this._defaultMatcher,v=this.ngControl?this.ngControl.control:null,o=_?.isErrorState(v,h)??!1;o!==p&&(this.errorState=o,this._stateChanges.next())}}},21584(ie,T,c){c.d(T,{O:()=>m});var e=c(39638);const m=new e.InjectionToken("MAT_INPUT_VALUE_ACCESSOR")},52839(ie,T,c){c.r(T),c.d(T,{DateRange:()=>f,DefaultMatCalendarRangeStrategy:()=>K,MAT_DATEPICKER_SCROLL_STRATEGY:()=>Oe,MAT_DATEPICKER_VALIDATORS:()=>ve,MAT_DATEPICKER_VALUE_ACCESSOR:()=>fe,MAT_DATE_RANGE_SELECTION_STRATEGY:()=>$,MatCalendar:()=>M,MatCalendarBody:()=>b,MatCalendarCell:()=>de,MatCalendarHeader:()=>N,MatDateRangeInput:()=>P,MatDateRangePicker:()=>L,MatDateSelectionModel:()=>w,MatDatepicker:()=>F,MatDatepickerActions:()=>J,MatDatepickerApply:()=>G,MatDatepickerCancel:()=>Q,MatDatepickerContent:()=>B,MatDatepickerInput:()=>O,MatDatepickerInputEvent:()=>ne,MatDatepickerIntl:()=>C,MatDatepickerModule:()=>re,MatDatepickerToggle:()=>W,MatDatepickerToggleIcon:()=>Y,MatEndDate:()=>x,MatMonthView:()=>I,MatMultiYearView:()=>V,MatRangeDateSelectionModel:()=>z,MatSingleDateSelectionModel:()=>H,MatStartDate:()=>E,MatYearView:()=>R,yearsPerPage:()=>D,yearsPerRow:()=>pe});var e=c(39638),m=c(88632),p=c(43955),h=c(60447),_=c(90459),v=c(73971),o=c(88783),d=c(15893),u=c(52455),g=c(34883),A=c(24884),U=c(4295),Pe=c(30184),q=c(72221),se=c(86504),Ce=c(68041),we=c(34630),y=c(58102),ke=c(21584),oe=c(51029),Ae=c(33807),Le=c(48827),Ne=c(3146),pt=c(15047),mt=c(90508),ut=c(69005);const Be=["mat-calendar-body",""];function Ye(s,t){return this._trackRow(t)}const Me=(s,t)=>t.id;function je(s,t){if(s&1&&(e.\u0275\u0275domElementStart(0,"tr",0)(1,"td",3),e.\u0275\u0275text(2),e.\u0275\u0275domElementEnd()()),s&2){const a=e.\u0275\u0275nextContext();e.\u0275\u0275advance(),e.\u0275\u0275styleProp("padding-top",a._cellPadding)("padding-bottom",a._cellPadding),e.\u0275\u0275attribute("colspan",a.numCols),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate1(" ",a.label," ")}}function He(s,t){if(s&1&&(e.\u0275\u0275domElementStart(0,"td",3),e.\u0275\u0275text(1),e.\u0275\u0275domElementEnd()),s&2){const a=e.\u0275\u0275nextContext(2);e.\u0275\u0275styleProp("padding-top",a._cellPadding)("padding-bottom",a._cellPadding),e.\u0275\u0275attribute("colspan",a._firstRowOffset),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate1(" ",a._firstRowOffset>=a.labelMinRequiredCells?a.label:""," ")}}function ze(s,t){if(s&1){const a=e.\u0275\u0275getCurrentView();e.\u0275\u0275domElementStart(0,"td",6)(1,"button",7),e.\u0275\u0275domListener("click",function(r){const i=e.\u0275\u0275restoreView(a).$implicit,l=e.\u0275\u0275nextContext(2);return e.\u0275\u0275resetView(l._cellClicked(i,r))})("focus",function(r){const i=e.\u0275\u0275restoreView(a).$implicit,l=e.\u0275\u0275nextContext(2);return e.\u0275\u0275resetView(l._emitActiveDateChange(i,r))}),e.\u0275\u0275domElementStart(2,"span",8),e.\u0275\u0275text(3),e.\u0275\u0275domElementEnd(),e.\u0275\u0275domElement(4,"span",9),e.\u0275\u0275domElementEnd()()}if(s&2){const a=t.$implicit,n=t.$index,r=e.\u0275\u0275nextContext().$index,i=e.\u0275\u0275nextContext();e.\u0275\u0275styleProp("width",i._cellWidth)("padding-top",i._cellPadding)("padding-bottom",i._cellPadding),e.\u0275\u0275attribute("data-mat-row",r)("data-mat-col",n),e.\u0275\u0275advance(),e.\u0275\u0275classMap(a.cssClasses),e.\u0275\u0275classProp("mat-calendar-body-disabled",!a.enabled)("mat-calendar-body-active",i._isActiveCell(r,n))("mat-calendar-body-range-start",i._isRangeStart(a.compareValue))("mat-calendar-body-range-end",i._isRangeEnd(a.compareValue))("mat-calendar-body-in-range",i._isInRange(a.compareValue))("mat-calendar-body-comparison-bridge-start",i._isComparisonBridgeStart(a.compareValue,r,n))("mat-calendar-body-comparison-bridge-end",i._isComparisonBridgeEnd(a.compareValue,r,n))("mat-calendar-body-comparison-start",i._isComparisonStart(a.compareValue))("mat-calendar-body-comparison-end",i._isComparisonEnd(a.compareValue))("mat-calendar-body-in-comparison-range",i._isInComparisonRange(a.compareValue))("mat-calendar-body-preview-start",i._isPreviewStart(a.compareValue))("mat-calendar-body-preview-end",i._isPreviewEnd(a.compareValue))("mat-calendar-body-in-preview",i._isInPreview(a.compareValue)),e.\u0275\u0275domProperty("tabIndex",i._isActiveCell(r,n)?0:-1),e.\u0275\u0275attribute("aria-label",a.ariaLabel)("aria-disabled",!a.enabled||null)("aria-pressed",i._isSelected(a.compareValue))("aria-current",i.todayValue===a.compareValue?"date":null)("aria-describedby",i._getDescribedby(a.compareValue)),e.\u0275\u0275advance(),e.\u0275\u0275classProp("mat-calendar-body-selected",i._isSelected(a.compareValue))("mat-calendar-body-comparison-identical",i._isComparisonIdentical(a.compareValue))("mat-calendar-body-today",i.todayValue===a.compareValue),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate1(" ",a.displayValue," ")}}function Ke(s,t){if(s&1&&(e.\u0275\u0275domElementStart(0,"tr",1),e.\u0275\u0275conditionalCreate(1,He,2,6,"td",4),e.\u0275\u0275repeaterCreate(2,ze,5,49,"td",5,Me),e.\u0275\u0275domElementEnd()),s&2){const a=t.$implicit,n=t.$index,r=e.\u0275\u0275nextContext();e.\u0275\u0275advance(),e.\u0275\u0275conditional(n===0&&r._firstRowOffset?1:-1),e.\u0275\u0275advance(),e.\u0275\u0275repeater(a)}}function We(s,t){if(s&1&&(e.\u0275\u0275elementStart(0,"th",2)(1,"span",6),e.\u0275\u0275text(2),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(3,"span",3),e.\u0275\u0275text(4),e.\u0275\u0275elementEnd()()),s&2){const a=t.$implicit;e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate(a.long),e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate(a.narrow)}}const Ee=["*"];function Ue(s,t){}function $e(s,t){if(s&1){const a=e.\u0275\u0275getCurrentView();e.\u0275\u0275elementStart(0,"mat-month-view",4),e.\u0275\u0275twoWayListener("activeDateChange",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275twoWayBindingSet(i.activeDate,r)||(i.activeDate=r),e.\u0275\u0275resetView(r)}),e.\u0275\u0275listener("_userSelection",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(i._dateSelected(r))})("dragStarted",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(i._dragStarted(r))})("dragEnded",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(i._dragEnded(r))}),e.\u0275\u0275elementEnd()}if(s&2){const a=e.\u0275\u0275nextContext();e.\u0275\u0275twoWayProperty("activeDate",a.activeDate),e.\u0275\u0275property("selected",a.selected)("dateFilter",a.dateFilter)("maxDate",a.maxDate)("minDate",a.minDate)("dateClass",a.dateClass)("comparisonStart",a.comparisonStart)("comparisonEnd",a.comparisonEnd)("startDateAccessibleName",a.startDateAccessibleName)("endDateAccessibleName",a.endDateAccessibleName)("activeDrag",a._activeDrag)}}function Ge(s,t){if(s&1){const a=e.\u0275\u0275getCurrentView();e.\u0275\u0275elementStart(0,"mat-year-view",5),e.\u0275\u0275twoWayListener("activeDateChange",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275twoWayBindingSet(i.activeDate,r)||(i.activeDate=r),e.\u0275\u0275resetView(r)}),e.\u0275\u0275listener("monthSelected",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(i._monthSelectedInYearView(r))})("selectedChange",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(i._goToDateInView(r,"month"))}),e.\u0275\u0275elementEnd()}if(s&2){const a=e.\u0275\u0275nextContext();e.\u0275\u0275twoWayProperty("activeDate",a.activeDate),e.\u0275\u0275property("selected",a.selected)("dateFilter",a.dateFilter)("maxDate",a.maxDate)("minDate",a.minDate)("dateClass",a.dateClass)}}function Qe(s,t){if(s&1){const a=e.\u0275\u0275getCurrentView();e.\u0275\u0275elementStart(0,"mat-multi-year-view",6),e.\u0275\u0275twoWayListener("activeDateChange",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275twoWayBindingSet(i.activeDate,r)||(i.activeDate=r),e.\u0275\u0275resetView(r)}),e.\u0275\u0275listener("yearSelected",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(i._yearSelectedInMultiYearView(r))})("selectedChange",function(r){e.\u0275\u0275restoreView(a);const i=e.\u0275\u0275nextContext();return e.\u0275\u0275resetView(i._goToDateInView(r,"year"))}),e.\u0275\u0275elementEnd()}if(s&2){const a=e.\u0275\u0275nextContext();e.\u0275\u0275twoWayProperty("activeDate",a.activeDate),e.\u0275\u0275property("selected",a.selected)("dateFilter",a.dateFilter)("maxDate",a.maxDate)("minDate",a.minDate)("dateClass",a.dateClass)}}function Je(s,t){}const qe=["button"],Xe=[[["","matDatepickerToggleIcon",""]]],Ze=["[matDatepickerToggleIcon]"];function et(s,t){s&1&&(e.\u0275\u0275namespaceSVG(),e.\u0275\u0275elementStart(0,"svg",2),e.\u0275\u0275element(1,"path",3),e.\u0275\u0275elementEnd())}const tt=[[["input","matStartDate",""]],[["input","matEndDate",""]]],at=["input[matStartDate]","input[matEndDate]"];function nt(s,t){s&1&&(e.\u0275\u0275domElementStart(0,"div",0),e.\u0275\u0275projection(1),e.\u0275\u0275domElementEnd())}function S(s){return Error(`MatDatepicker: No provider found for ${s}. You must add one of the following to your app config: provideNativeDateAdapter, provideDateFnsAdapter, provideLuxonDateAdapter, provideMomentDateAdapter, or provide a custom implementation.`)}class C{changes=new m.Subject;calendarLabel="Calendar";openCalendarLabel="Open calendar";closeCalendarLabel="Close calendar";prevMonthLabel="Previous month";nextMonthLabel="Next month";prevYearLabel="Previous year";nextYearLabel="Next year";prevMultiYearLabel="Previous 24 years";nextMultiYearLabel="Next 24 years";switchToMonthViewLabel="Choose date";switchToMultiYearViewLabel="Choose month and year";startDateLabel="Start date";endDateLabel="End date";comparisonDateLabel="Comparison range";formatYearRange(t,a){return`${t} \u2013 ${a}`}formatYearRangeLabel(t,a){return`${t} to ${a}`}static \u0275fac=function(a){return new(a||C)};static \u0275prov=e.\u0275\u0275defineInjectable({token:C,factory:C.\u0275fac,providedIn:"root"})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(C,[{type:e.Injectable,args:[{providedIn:"root"}]}],null,null);let rt=0;class de{value;displayValue;ariaLabel;enabled;compareValue;rawValue;id=rt++;cssClasses;constructor(t,a,n,r,i,l=t,j){this.value=t,this.displayValue=a,this.ariaLabel=n,this.enabled=r,this.compareValue=l,this.rawValue=j,this.cssClasses=i instanceof Set?Array.from(i):i}}const it={passive:!1,capture:!0},le={passive:!0,capture:!0},xe={passive:!0};class b{_elementRef=(0,e.inject)(e.ElementRef);_ngZone=(0,e.inject)(e.NgZone);_platform=(0,e.inject)(u.Platform);_intl=(0,e.inject)(C);_eventCleanups;_skipNextFocus=!1;_focusActiveCellAfterViewChecked=!1;label;rows;todayValue;startValue;endValue;labelMinRequiredCells;numCols=7;activeCell=0;ngAfterViewChecked(){this._focusActiveCellAfterViewChecked&&(this._focusActiveCell(),this._focusActiveCellAfterViewChecked=!1)}isRange=!1;cellAspectRatio=1;comparisonStart=null;comparisonEnd=null;previewStart=null;previewEnd=null;startDateAccessibleName=null;endDateAccessibleName=null;selectedValueChange=new e.EventEmitter;previewChange=new e.EventEmitter;activeDateChange=new e.EventEmitter;dragStarted=new e.EventEmitter;dragEnded=new e.EventEmitter;_firstRowOffset;_cellPadding;_cellWidth;_startDateLabelId;_endDateLabelId;_comparisonStartDateLabelId;_comparisonEndDateLabelId;_didDragSinceMouseDown=!1;_injector=(0,e.inject)(e.Injector);comparisonDateAccessibleName=this._intl.comparisonDateLabel;_trackRow=t=>t;constructor(){const t=(0,e.inject)(e.Renderer2),a=(0,e.inject)(h._IdGenerator);this._startDateLabelId=a.getId("mat-calendar-body-start-"),this._endDateLabelId=a.getId("mat-calendar-body-end-"),this._comparisonStartDateLabelId=a.getId("mat-calendar-body-comparison-start-"),this._comparisonEndDateLabelId=a.getId("mat-calendar-body-comparison-end-"),(0,e.inject)(U._CdkPrivateStyleLoader).load(Pe.A),this._ngZone.runOutsideAngular(()=>{const n=this._elementRef.nativeElement,r=[t.listen(n,"touchmove",this._touchmoveHandler,it),t.listen(n,"mouseenter",this._enterHandler,le),t.listen(n,"focus",this._enterHandler,le),t.listen(n,"mouseleave",this._leaveHandler,le),t.listen(n,"blur",this._leaveHandler,le),t.listen(n,"mousedown",this._mousedownHandler,xe),t.listen(n,"touchstart",this._mousedownHandler,xe)];this._platform.isBrowser&&r.push(t.listen("window","mouseup",this._mouseupHandler),t.listen("window","touchend",this._touchendHandler)),this._eventCleanups=r})}_cellClicked(t,a){this._didDragSinceMouseDown||t.enabled&&this.selectedValueChange.emit({value:t.value,event:a})}_emitActiveDateChange(t,a){t.enabled&&this.activeDateChange.emit({value:t.value,event:a})}_isSelected(t){return this.startValue===t||this.endValue===t}ngOnChanges(t){const a=t.numCols,{rows:n,numCols:r}=this;(t.rows||a)&&(this._firstRowOffset=n&&n.length&&n[0].length?r-n[0].length:0),(t.cellAspectRatio||a||!this._cellPadding)&&(this._cellPadding=`${50*this.cellAspectRatio/r}%`),(a||!this._cellWidth)&&(this._cellWidth=`${100/r}%`)}ngOnDestroy(){this._eventCleanups.forEach(t=>t())}_isActiveCell(t,a){let n=t*this.numCols+a;return t&&(n-=this._firstRowOffset),n==this.activeCell}_focusActiveCell(t=!0){(0,e.afterNextRender)(()=>{setTimeout(()=>{const a=this._elementRef.nativeElement.querySelector(".mat-calendar-body-active");a&&(t||(this._skipNextFocus=!0),a.focus())})},{injector:this._injector})}_scheduleFocusActiveCellAfterViewChecked(){this._focusActiveCellAfterViewChecked=!0}_isRangeStart(t){return _e(t,this.startValue,this.endValue)}_isRangeEnd(t){return ge(t,this.startValue,this.endValue)}_isInRange(t){return be(t,this.startValue,this.endValue,this.isRange)}_isComparisonStart(t){return _e(t,this.comparisonStart,this.comparisonEnd)}_isComparisonBridgeStart(t,a,n){if(!this._isComparisonStart(t)||this._isRangeStart(t)||!this._isInRange(t))return!1;let r=this.rows[a][n-1];if(!r){const i=this.rows[a-1];r=i&&i[i.length-1]}return r&&!this._isRangeEnd(r.compareValue)}_isComparisonBridgeEnd(t,a,n){if(!this._isComparisonEnd(t)||this._isRangeEnd(t)||!this._isInRange(t))return!1;let r=this.rows[a][n+1];if(!r){const i=this.rows[a+1];r=i&&i[0]}return r&&!this._isRangeStart(r.compareValue)}_isComparisonEnd(t){return ge(t,this.comparisonStart,this.comparisonEnd)}_isInComparisonRange(t){return be(t,this.comparisonStart,this.comparisonEnd,this.isRange)}_isComparisonIdentical(t){return this.comparisonStart===this.comparisonEnd&&t===this.comparisonStart}_isPreviewStart(t){return _e(t,this.previewStart,this.previewEnd)}_isPreviewEnd(t){return ge(t,this.previewStart,this.previewEnd)}_isInPreview(t){return be(t,this.previewStart,this.previewEnd,this.isRange)}_getDescribedby(t){if(!this.isRange)return null;if(this.startValue===t&&this.endValue===t)return`${this._startDateLabelId} ${this._endDateLabelId}`;if(this.startValue===t)return this._startDateLabelId;if(this.endValue===t)return this._endDateLabelId;if(this.comparisonStart!==null&&this.comparisonEnd!==null){if(t===this.comparisonStart&&t===this.comparisonEnd)return`${this._comparisonStartDateLabelId} ${this._comparisonEndDateLabelId}`;if(t===this.comparisonStart)return this._comparisonStartDateLabelId;if(t===this.comparisonEnd)return this._comparisonEndDateLabelId}return null}_enterHandler=t=>{if(this._skipNextFocus&&t.type==="focus"){this._skipNextFocus=!1;return}if(t.target&&this.isRange){const a=this._getCellFromElement(t.target);a&&this._ngZone.run(()=>this.previewChange.emit({value:a.enabled?a:null,event:t}))}};_touchmoveHandler=t=>{if(!this.isRange)return;const a=Se(t),n=a?this._getCellFromElement(a):null;a!==t.target&&(this._didDragSinceMouseDown=!0),he(t.target)&&t.preventDefault(),this._ngZone.run(()=>this.previewChange.emit({value:n?.enabled?n:null,event:t}))};_leaveHandler=t=>{this.previewEnd!==null&&this.isRange&&(t.type!=="blur"&&(this._didDragSinceMouseDown=!0),t.target&&this._getCellFromElement(t.target)&&!(t.relatedTarget&&this._getCellFromElement(t.relatedTarget))&&this._ngZone.run(()=>this.previewChange.emit({value:null,event:t})))};_mousedownHandler=t=>{if(!this.isRange)return;this._didDragSinceMouseDown=!1;const a=t.target&&this._getCellFromElement(t.target);!a||!this._isInRange(a.compareValue)||this._ngZone.run(()=>{this.dragStarted.emit({value:a.rawValue,event:t})})};_mouseupHandler=t=>{if(!this.isRange)return;const a=he(t.target);if(!a){this._ngZone.run(()=>{this.dragEnded.emit({value:null,event:t})});return}a.closest(".mat-calendar-body")===this._elementRef.nativeElement&&this._ngZone.run(()=>{const n=this._getCellFromElement(a);this.dragEnded.emit({value:n?.rawValue??null,event:t})})};_touchendHandler=t=>{const a=Se(t);a&&this._mouseupHandler({target:a})};_getCellFromElement(t){const a=he(t);if(a){const n=a.getAttribute("data-mat-row"),r=a.getAttribute("data-mat-col");if(n&&r)return this.rows[parseInt(n)]?.[parseInt(r)]||null}return null}static \u0275fac=function(a){return new(a||b)};static \u0275cmp=e.\u0275\u0275defineComponent({type:b,selectors:[["","mat-calendar-body",""]],hostAttrs:[1,"mat-calendar-body"],inputs:{label:"label",rows:"rows",todayValue:"todayValue",startValue:"startValue",endValue:"endValue",labelMinRequiredCells:"labelMinRequiredCells",numCols:"numCols",activeCell:"activeCell",isRange:"isRange",cellAspectRatio:"cellAspectRatio",comparisonStart:"comparisonStart",comparisonEnd:"comparisonEnd",previewStart:"previewStart",previewEnd:"previewEnd",startDateAccessibleName:"startDateAccessibleName",endDateAccessibleName:"endDateAccessibleName"},outputs:{selectedValueChange:"selectedValueChange",previewChange:"previewChange",activeDateChange:"activeDateChange",dragStarted:"dragStarted",dragEnded:"dragEnded"},exportAs:["matCalendarBody"],features:[e.\u0275\u0275NgOnChangesFeature],attrs:Be,decls:11,vars:11,consts:[["aria-hidden","true"],["role","row"],[1,"mat-calendar-body-hidden-label",3,"id"],[1,"mat-calendar-body-label"],[1,"mat-calendar-body-label",3,"paddingTop","paddingBottom"],["role","gridcell",1,"mat-calendar-body-cell-container",3,"width","paddingTop","paddingBottom"],["role","gridcell",1,"mat-calendar-body-cell-container"],["type","button",1,"mat-calendar-body-cell",3,"click","focus","tabindex"],[1,"mat-calendar-body-cell-content","mat-focus-indicator"],["aria-hidden","true",1,"mat-calendar-body-cell-preview"]],template:function(a,n){a&1&&(e.\u0275\u0275conditionalCreate(0,je,3,6,"tr",0),e.\u0275\u0275repeaterCreate(1,Ke,4,1,"tr",1,Ye,!0),e.\u0275\u0275domElementStart(3,"span",2),e.\u0275\u0275text(4),e.\u0275\u0275domElementEnd(),e.\u0275\u0275domElementStart(5,"span",2),e.\u0275\u0275text(6),e.\u0275\u0275domElementEnd(),e.\u0275\u0275domElementStart(7,"span",2),e.\u0275\u0275text(8),e.\u0275\u0275domElementEnd(),e.\u0275\u0275domElementStart(9,"span",2),e.\u0275\u0275text(10),e.\u0275\u0275domElementEnd()),a&2&&(e.\u0275\u0275conditional(n._firstRowOffset<n.labelMinRequiredCells?0:-1),e.\u0275\u0275advance(),e.\u0275\u0275repeater(n.rows),e.\u0275\u0275advance(2),e.\u0275\u0275domProperty("id",n._startDateLabelId),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate1(" ",n.startDateAccessibleName,`
`),e.\u0275\u0275advance(),e.\u0275\u0275domProperty("id",n._endDateLabelId),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate1(" ",n.endDateAccessibleName,`
`),e.\u0275\u0275advance(),e.\u0275\u0275domProperty("id",n._comparisonStartDateLabelId),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate2(" ",n.comparisonDateAccessibleName," ",n.startDateAccessibleName,`
`),e.\u0275\u0275advance(),e.\u0275\u0275domProperty("id",n._comparisonEndDateLabelId),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate2(" ",n.comparisonDateAccessibleName," ",n.endDateAccessibleName,`
`))},styles:[`.mat-calendar-body {
  min-width: 224px;
}

.mat-calendar-body-today:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  border-color: var(--mat-datepicker-calendar-date-today-outline-color, var(--mat-sys-primary));
}

.mat-calendar-body-label {
  height: 0;
  line-height: 0;
  text-align: start;
  padding-left: 4.7142857143%;
  padding-right: 4.7142857143%;
  font-size: var(--mat-datepicker-calendar-body-label-text-size, var(--mat-sys-title-small-size));
  font-weight: var(--mat-datepicker-calendar-body-label-text-weight, var(--mat-sys-title-small-weight));
  color: var(--mat-datepicker-calendar-body-label-text-color, var(--mat-sys-on-surface));
}

.mat-calendar-body-hidden-label {
  display: none;
}

.mat-calendar-body-cell-container {
  position: relative;
  height: 0;
  line-height: 0;
}

.mat-calendar-body-cell {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: none;
  text-align: center;
  outline: none;
  margin: 0;
  font-family: var(--mat-datepicker-calendar-text-font, var(--mat-sys-body-medium-font));
  font-size: var(--mat-datepicker-calendar-text-size, var(--mat-sys-body-medium-size));
  -webkit-user-select: none;
  user-select: none;
  cursor: pointer;
  outline: none;
  border: none;
  -webkit-tap-highlight-color: transparent;
}
.mat-calendar-body-cell::-moz-focus-inner {
  border: 0;
}

.mat-calendar-body-cell::before,
.mat-calendar-body-cell::after,
.mat-calendar-body-cell-preview {
  content: "";
  position: absolute;
  top: 5%;
  left: 0;
  z-index: 0;
  box-sizing: border-box;
  display: block;
  height: 90%;
  width: 100%;
}

.mat-calendar-body-range-start:not(.mat-calendar-body-in-comparison-range)::before,
.mat-calendar-body-range-start::after,
.mat-calendar-body-comparison-start:not(.mat-calendar-body-comparison-bridge-start)::before,
.mat-calendar-body-comparison-start::after,
.mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  left: 5%;
  width: 95%;
  border-top-left-radius: 999px;
  border-bottom-left-radius: 999px;
}
[dir=rtl] .mat-calendar-body-range-start:not(.mat-calendar-body-in-comparison-range)::before,
[dir=rtl] .mat-calendar-body-range-start::after,
[dir=rtl] .mat-calendar-body-comparison-start:not(.mat-calendar-body-comparison-bridge-start)::before,
[dir=rtl] .mat-calendar-body-comparison-start::after,
[dir=rtl] .mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  left: 0;
  border-radius: 0;
  border-top-right-radius: 999px;
  border-bottom-right-radius: 999px;
}

.mat-calendar-body-range-end:not(.mat-calendar-body-in-comparison-range)::before,
.mat-calendar-body-range-end::after,
.mat-calendar-body-comparison-end:not(.mat-calendar-body-comparison-bridge-end)::before,
.mat-calendar-body-comparison-end::after,
.mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  width: 95%;
  border-top-right-radius: 999px;
  border-bottom-right-radius: 999px;
}
[dir=rtl] .mat-calendar-body-range-end:not(.mat-calendar-body-in-comparison-range)::before,
[dir=rtl] .mat-calendar-body-range-end::after,
[dir=rtl] .mat-calendar-body-comparison-end:not(.mat-calendar-body-comparison-bridge-end)::before,
[dir=rtl] .mat-calendar-body-comparison-end::after,
[dir=rtl] .mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  left: 5%;
  border-radius: 0;
  border-top-left-radius: 999px;
  border-bottom-left-radius: 999px;
}

[dir=rtl] .mat-calendar-body-comparison-bridge-start.mat-calendar-body-range-end::after,
[dir=rtl] .mat-calendar-body-comparison-bridge-end.mat-calendar-body-range-start::after {
  width: 95%;
  border-top-right-radius: 999px;
  border-bottom-right-radius: 999px;
}

.mat-calendar-body-comparison-start.mat-calendar-body-range-end::after, [dir=rtl] .mat-calendar-body-comparison-start.mat-calendar-body-range-end::after,
.mat-calendar-body-comparison-end.mat-calendar-body-range-start::after,
[dir=rtl] .mat-calendar-body-comparison-end.mat-calendar-body-range-start::after {
  width: 90%;
}

.mat-calendar-body-in-preview {
  color: var(--mat-datepicker-calendar-date-preview-state-outline-color, var(--mat-sys-primary));
}
.mat-calendar-body-in-preview .mat-calendar-body-cell-preview {
  border-top: dashed 1px;
  border-bottom: dashed 1px;
}

.mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  border-left: dashed 1px;
}
[dir=rtl] .mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  border-left: 0;
  border-right: dashed 1px;
}

.mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  border-right: dashed 1px;
}
[dir=rtl] .mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  border-right: 0;
  border-left: dashed 1px;
}

.mat-calendar-body-disabled {
  cursor: default;
}
.mat-calendar-body-disabled > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  color: var(--mat-datepicker-calendar-date-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-calendar-body-disabled > .mat-calendar-body-today:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  border-color: var(--mat-datepicker-calendar-date-today-disabled-state-outline-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
@media (forced-colors: active) {
  .mat-calendar-body-disabled {
    opacity: 0.5;
  }
}

.mat-calendar-body-cell-content {
  top: 5%;
  left: 5%;
  z-index: 1;
  display: flex;
  align-items: center;
  justify-content: center;
  box-sizing: border-box;
  width: 90%;
  height: 90%;
  line-height: 1;
  border-width: 1px;
  border-style: solid;
  border-radius: 999px;
  color: var(--mat-datepicker-calendar-date-text-color, var(--mat-sys-on-surface));
  border-color: var(--mat-datepicker-calendar-date-outline-color, transparent);
}
.mat-calendar-body-cell-content.mat-focus-indicator {
  position: absolute;
}
@media (forced-colors: active) {
  .mat-calendar-body-cell-content {
    border: none;
  }
}

.cdk-keyboard-focused .mat-calendar-body-active > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical), .cdk-program-focused .mat-calendar-body-active > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  background-color: var(--mat-datepicker-calendar-date-focus-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-focus-state-layer-opacity) * 100%), transparent));
}

@media (hover: hover) {
  .mat-calendar-body-cell:not(.mat-calendar-body-disabled):hover > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
    background-color: var(--mat-datepicker-calendar-date-hover-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-hover-state-layer-opacity) * 100%), transparent));
  }
}
.mat-calendar-body-selected {
  background-color: var(--mat-datepicker-calendar-date-selected-state-background-color, var(--mat-sys-primary));
  color: var(--mat-datepicker-calendar-date-selected-state-text-color, var(--mat-sys-on-primary));
}
.mat-calendar-body-disabled > .mat-calendar-body-selected {
  background-color: var(--mat-datepicker-calendar-date-selected-disabled-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-calendar-body-selected.mat-calendar-body-today {
  box-shadow: inset 0 0 0 1px var(--mat-datepicker-calendar-date-today-selected-state-outline-color, var(--mat-sys-primary));
}

.mat-calendar-body-in-range::before {
  background: var(--mat-datepicker-calendar-date-in-range-state-background-color, var(--mat-sys-primary-container));
}

.mat-calendar-body-comparison-identical,
.mat-calendar-body-in-comparison-range::before {
  background: var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container));
}

.mat-calendar-body-comparison-identical,
.mat-calendar-body-in-comparison-range::before {
  background: var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container));
}

.mat-calendar-body-comparison-bridge-start::before,
[dir=rtl] .mat-calendar-body-comparison-bridge-end::before {
  background: linear-gradient(to right, var(--mat-datepicker-calendar-date-in-range-state-background-color, var(--mat-sys-primary-container)) 50%, var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container)) 50%);
}

.mat-calendar-body-comparison-bridge-end::before,
[dir=rtl] .mat-calendar-body-comparison-bridge-start::before {
  background: linear-gradient(to left, var(--mat-datepicker-calendar-date-in-range-state-background-color, var(--mat-sys-primary-container)) 50%, var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container)) 50%);
}

.mat-calendar-body-in-range > .mat-calendar-body-comparison-identical,
.mat-calendar-body-in-comparison-range.mat-calendar-body-in-range::after {
  background: var(--mat-datepicker-calendar-date-in-overlap-range-state-background-color, var(--mat-sys-secondary-container));
}

.mat-calendar-body-comparison-identical.mat-calendar-body-selected,
.mat-calendar-body-in-comparison-range > .mat-calendar-body-selected {
  background: var(--mat-datepicker-calendar-date-in-overlap-range-selected-state-background-color, var(--mat-sys-secondary));
}

@media (forced-colors: active) {
  .mat-datepicker-popup:not(:empty),
  .mat-calendar-body-cell:not(.mat-calendar-body-in-range) .mat-calendar-body-selected {
    outline: solid 1px;
  }
  .mat-calendar-body-today {
    outline: dotted 1px;
  }
  .mat-calendar-body-cell::before,
  .mat-calendar-body-cell::after,
  .mat-calendar-body-selected {
    background: none;
  }
  .mat-calendar-body-in-range::before,
  .mat-calendar-body-comparison-bridge-start::before,
  .mat-calendar-body-comparison-bridge-end::before {
    border-top: solid 1px;
    border-bottom: solid 1px;
  }
  .mat-calendar-body-range-start::before {
    border-left: solid 1px;
  }
  [dir=rtl] .mat-calendar-body-range-start::before {
    border-left: 0;
    border-right: solid 1px;
  }
  .mat-calendar-body-range-end::before {
    border-right: solid 1px;
  }
  [dir=rtl] .mat-calendar-body-range-end::before {
    border-right: 0;
    border-left: solid 1px;
  }
  .mat-calendar-body-in-comparison-range::before {
    border-top: dashed 1px;
    border-bottom: dashed 1px;
  }
  .mat-calendar-body-comparison-start::before {
    border-left: dashed 1px;
  }
  [dir=rtl] .mat-calendar-body-comparison-start::before {
    border-left: 0;
    border-right: dashed 1px;
  }
  .mat-calendar-body-comparison-end::before {
    border-right: dashed 1px;
  }
  [dir=rtl] .mat-calendar-body-comparison-end::before {
    border-right: 0;
    border-left: dashed 1px;
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(b,[{type:e.Component,args:[{selector:"[mat-calendar-body]",host:{class:"mat-calendar-body"},exportAs:"matCalendarBody",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,template:`<!--
  If there's not enough space in the first row, create a separate label row. We mark this row as
  aria-hidden because we don't want it to be read out as one of the weeks in the month.
-->
@if (_firstRowOffset < labelMinRequiredCells) {
  <tr aria-hidden="true">
    <td class="mat-calendar-body-label"
        [attr.colspan]="numCols"
        [style.paddingTop]="_cellPadding"
        [style.paddingBottom]="_cellPadding">
      {{label}}
    </td>
  </tr>
}

<!-- Create the first row separately so we can include a special spacer cell. -->
@for (row of rows; track _trackRow(row); let rowIndex = $index) {
  <tr role="row">
    <!--
      This cell is purely decorative, but we can't put \`aria-hidden\` or \`role="presentation"\` on it,
      because it throws off the week days for the rest of the row on NVDA. The aspect ratio of the
      table cells is maintained by setting the top and bottom padding as a percentage of the width
      (a variant of the trick described here: https://www.w3schools.com/howto/howto_css_aspect_ratio.asp).
    -->
    @if (rowIndex === 0 && _firstRowOffset) {
      <td
        class="mat-calendar-body-label"
        [attr.colspan]="_firstRowOffset"
        [style.paddingTop]="_cellPadding"
        [style.paddingBottom]="_cellPadding">
        {{_firstRowOffset >= labelMinRequiredCells ? label : ''}}
      </td>
    }
    <!--
      Each gridcell in the calendar contains a button, which signals to assistive technology that the
      cell is interactable, as well as the selection state via \`aria-pressed\`. See #23476 for
      background.
    -->
    @for (item of row; track item.id; let colIndex = $index) {
      <td
        role="gridcell"
        class="mat-calendar-body-cell-container"
        [style.width]="_cellWidth"
        [style.paddingTop]="_cellPadding"
        [style.paddingBottom]="_cellPadding"
        [attr.data-mat-row]="rowIndex"
        [attr.data-mat-col]="colIndex"
      >
        <button
            type="button"
            class="mat-calendar-body-cell"
            [class]="item.cssClasses"
            [tabindex]="_isActiveCell(rowIndex, colIndex) ? 0 : -1"
            [class.mat-calendar-body-disabled]="!item.enabled"
            [class.mat-calendar-body-active]="_isActiveCell(rowIndex, colIndex)"
            [class.mat-calendar-body-range-start]="_isRangeStart(item.compareValue)"
            [class.mat-calendar-body-range-end]="_isRangeEnd(item.compareValue)"
            [class.mat-calendar-body-in-range]="_isInRange(item.compareValue)"
            [class.mat-calendar-body-comparison-bridge-start]="_isComparisonBridgeStart(item.compareValue, rowIndex, colIndex)"
            [class.mat-calendar-body-comparison-bridge-end]="_isComparisonBridgeEnd(item.compareValue, rowIndex, colIndex)"
            [class.mat-calendar-body-comparison-start]="_isComparisonStart(item.compareValue)"
            [class.mat-calendar-body-comparison-end]="_isComparisonEnd(item.compareValue)"
            [class.mat-calendar-body-in-comparison-range]="_isInComparisonRange(item.compareValue)"
            [class.mat-calendar-body-preview-start]="_isPreviewStart(item.compareValue)"
            [class.mat-calendar-body-preview-end]="_isPreviewEnd(item.compareValue)"
            [class.mat-calendar-body-in-preview]="_isInPreview(item.compareValue)"
            [attr.aria-label]="item.ariaLabel"
            [attr.aria-disabled]="!item.enabled || null"
            [attr.aria-pressed]="_isSelected(item.compareValue)"
            [attr.aria-current]="todayValue === item.compareValue ? 'date' : null"
            [attr.aria-describedby]="_getDescribedby(item.compareValue)"
            (click)="_cellClicked(item, $event)"
            (focus)="_emitActiveDateChange(item, $event)">
            <span class="mat-calendar-body-cell-content mat-focus-indicator"
              [class.mat-calendar-body-selected]="_isSelected(item.compareValue)"
              [class.mat-calendar-body-comparison-identical]="_isComparisonIdentical(item.compareValue)"
              [class.mat-calendar-body-today]="todayValue === item.compareValue">
              {{item.displayValue}}
            </span>
            <span class="mat-calendar-body-cell-preview" aria-hidden="true"></span>
        </button>
      </td>
    }
  </tr>
}

<span [id]="_startDateLabelId" class="mat-calendar-body-hidden-label">
  {{startDateAccessibleName}}
</span>
<span [id]="_endDateLabelId" class="mat-calendar-body-hidden-label">
  {{endDateAccessibleName}}
</span>
<span [id]="_comparisonStartDateLabelId" class="mat-calendar-body-hidden-label">
  {{comparisonDateAccessibleName}} {{startDateAccessibleName}}
</span>
<span [id]="_comparisonEndDateLabelId" class="mat-calendar-body-hidden-label">
  {{comparisonDateAccessibleName}} {{endDateAccessibleName}}
</span>
`,styles:[`.mat-calendar-body {
  min-width: 224px;
}

.mat-calendar-body-today:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  border-color: var(--mat-datepicker-calendar-date-today-outline-color, var(--mat-sys-primary));
}

.mat-calendar-body-label {
  height: 0;
  line-height: 0;
  text-align: start;
  padding-left: 4.7142857143%;
  padding-right: 4.7142857143%;
  font-size: var(--mat-datepicker-calendar-body-label-text-size, var(--mat-sys-title-small-size));
  font-weight: var(--mat-datepicker-calendar-body-label-text-weight, var(--mat-sys-title-small-weight));
  color: var(--mat-datepicker-calendar-body-label-text-color, var(--mat-sys-on-surface));
}

.mat-calendar-body-hidden-label {
  display: none;
}

.mat-calendar-body-cell-container {
  position: relative;
  height: 0;
  line-height: 0;
}

.mat-calendar-body-cell {
  position: absolute;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  background: none;
  text-align: center;
  outline: none;
  margin: 0;
  font-family: var(--mat-datepicker-calendar-text-font, var(--mat-sys-body-medium-font));
  font-size: var(--mat-datepicker-calendar-text-size, var(--mat-sys-body-medium-size));
  -webkit-user-select: none;
  user-select: none;
  cursor: pointer;
  outline: none;
  border: none;
  -webkit-tap-highlight-color: transparent;
}
.mat-calendar-body-cell::-moz-focus-inner {
  border: 0;
}

.mat-calendar-body-cell::before,
.mat-calendar-body-cell::after,
.mat-calendar-body-cell-preview {
  content: "";
  position: absolute;
  top: 5%;
  left: 0;
  z-index: 0;
  box-sizing: border-box;
  display: block;
  height: 90%;
  width: 100%;
}

.mat-calendar-body-range-start:not(.mat-calendar-body-in-comparison-range)::before,
.mat-calendar-body-range-start::after,
.mat-calendar-body-comparison-start:not(.mat-calendar-body-comparison-bridge-start)::before,
.mat-calendar-body-comparison-start::after,
.mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  left: 5%;
  width: 95%;
  border-top-left-radius: 999px;
  border-bottom-left-radius: 999px;
}
[dir=rtl] .mat-calendar-body-range-start:not(.mat-calendar-body-in-comparison-range)::before,
[dir=rtl] .mat-calendar-body-range-start::after,
[dir=rtl] .mat-calendar-body-comparison-start:not(.mat-calendar-body-comparison-bridge-start)::before,
[dir=rtl] .mat-calendar-body-comparison-start::after,
[dir=rtl] .mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  left: 0;
  border-radius: 0;
  border-top-right-radius: 999px;
  border-bottom-right-radius: 999px;
}

.mat-calendar-body-range-end:not(.mat-calendar-body-in-comparison-range)::before,
.mat-calendar-body-range-end::after,
.mat-calendar-body-comparison-end:not(.mat-calendar-body-comparison-bridge-end)::before,
.mat-calendar-body-comparison-end::after,
.mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  width: 95%;
  border-top-right-radius: 999px;
  border-bottom-right-radius: 999px;
}
[dir=rtl] .mat-calendar-body-range-end:not(.mat-calendar-body-in-comparison-range)::before,
[dir=rtl] .mat-calendar-body-range-end::after,
[dir=rtl] .mat-calendar-body-comparison-end:not(.mat-calendar-body-comparison-bridge-end)::before,
[dir=rtl] .mat-calendar-body-comparison-end::after,
[dir=rtl] .mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  left: 5%;
  border-radius: 0;
  border-top-left-radius: 999px;
  border-bottom-left-radius: 999px;
}

[dir=rtl] .mat-calendar-body-comparison-bridge-start.mat-calendar-body-range-end::after,
[dir=rtl] .mat-calendar-body-comparison-bridge-end.mat-calendar-body-range-start::after {
  width: 95%;
  border-top-right-radius: 999px;
  border-bottom-right-radius: 999px;
}

.mat-calendar-body-comparison-start.mat-calendar-body-range-end::after, [dir=rtl] .mat-calendar-body-comparison-start.mat-calendar-body-range-end::after,
.mat-calendar-body-comparison-end.mat-calendar-body-range-start::after,
[dir=rtl] .mat-calendar-body-comparison-end.mat-calendar-body-range-start::after {
  width: 90%;
}

.mat-calendar-body-in-preview {
  color: var(--mat-datepicker-calendar-date-preview-state-outline-color, var(--mat-sys-primary));
}
.mat-calendar-body-in-preview .mat-calendar-body-cell-preview {
  border-top: dashed 1px;
  border-bottom: dashed 1px;
}

.mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  border-left: dashed 1px;
}
[dir=rtl] .mat-calendar-body-preview-start .mat-calendar-body-cell-preview {
  border-left: 0;
  border-right: dashed 1px;
}

.mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  border-right: dashed 1px;
}
[dir=rtl] .mat-calendar-body-preview-end .mat-calendar-body-cell-preview {
  border-right: 0;
  border-left: dashed 1px;
}

.mat-calendar-body-disabled {
  cursor: default;
}
.mat-calendar-body-disabled > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  color: var(--mat-datepicker-calendar-date-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-calendar-body-disabled > .mat-calendar-body-today:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  border-color: var(--mat-datepicker-calendar-date-today-disabled-state-outline-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
@media (forced-colors: active) {
  .mat-calendar-body-disabled {
    opacity: 0.5;
  }
}

.mat-calendar-body-cell-content {
  top: 5%;
  left: 5%;
  z-index: 1;
  display: flex;
  align-items: center;
  justify-content: center;
  box-sizing: border-box;
  width: 90%;
  height: 90%;
  line-height: 1;
  border-width: 1px;
  border-style: solid;
  border-radius: 999px;
  color: var(--mat-datepicker-calendar-date-text-color, var(--mat-sys-on-surface));
  border-color: var(--mat-datepicker-calendar-date-outline-color, transparent);
}
.mat-calendar-body-cell-content.mat-focus-indicator {
  position: absolute;
}
@media (forced-colors: active) {
  .mat-calendar-body-cell-content {
    border: none;
  }
}

.cdk-keyboard-focused .mat-calendar-body-active > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical), .cdk-program-focused .mat-calendar-body-active > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
  background-color: var(--mat-datepicker-calendar-date-focus-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-focus-state-layer-opacity) * 100%), transparent));
}

@media (hover: hover) {
  .mat-calendar-body-cell:not(.mat-calendar-body-disabled):hover > .mat-calendar-body-cell-content:not(.mat-calendar-body-selected):not(.mat-calendar-body-comparison-identical) {
    background-color: var(--mat-datepicker-calendar-date-hover-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) calc(var(--mat-sys-hover-state-layer-opacity) * 100%), transparent));
  }
}
.mat-calendar-body-selected {
  background-color: var(--mat-datepicker-calendar-date-selected-state-background-color, var(--mat-sys-primary));
  color: var(--mat-datepicker-calendar-date-selected-state-text-color, var(--mat-sys-on-primary));
}
.mat-calendar-body-disabled > .mat-calendar-body-selected {
  background-color: var(--mat-datepicker-calendar-date-selected-disabled-state-background-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-calendar-body-selected.mat-calendar-body-today {
  box-shadow: inset 0 0 0 1px var(--mat-datepicker-calendar-date-today-selected-state-outline-color, var(--mat-sys-primary));
}

.mat-calendar-body-in-range::before {
  background: var(--mat-datepicker-calendar-date-in-range-state-background-color, var(--mat-sys-primary-container));
}

.mat-calendar-body-comparison-identical,
.mat-calendar-body-in-comparison-range::before {
  background: var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container));
}

.mat-calendar-body-comparison-identical,
.mat-calendar-body-in-comparison-range::before {
  background: var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container));
}

.mat-calendar-body-comparison-bridge-start::before,
[dir=rtl] .mat-calendar-body-comparison-bridge-end::before {
  background: linear-gradient(to right, var(--mat-datepicker-calendar-date-in-range-state-background-color, var(--mat-sys-primary-container)) 50%, var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container)) 50%);
}

.mat-calendar-body-comparison-bridge-end::before,
[dir=rtl] .mat-calendar-body-comparison-bridge-start::before {
  background: linear-gradient(to left, var(--mat-datepicker-calendar-date-in-range-state-background-color, var(--mat-sys-primary-container)) 50%, var(--mat-datepicker-calendar-date-in-comparison-range-state-background-color, var(--mat-sys-tertiary-container)) 50%);
}

.mat-calendar-body-in-range > .mat-calendar-body-comparison-identical,
.mat-calendar-body-in-comparison-range.mat-calendar-body-in-range::after {
  background: var(--mat-datepicker-calendar-date-in-overlap-range-state-background-color, var(--mat-sys-secondary-container));
}

.mat-calendar-body-comparison-identical.mat-calendar-body-selected,
.mat-calendar-body-in-comparison-range > .mat-calendar-body-selected {
  background: var(--mat-datepicker-calendar-date-in-overlap-range-selected-state-background-color, var(--mat-sys-secondary));
}

@media (forced-colors: active) {
  .mat-datepicker-popup:not(:empty),
  .mat-calendar-body-cell:not(.mat-calendar-body-in-range) .mat-calendar-body-selected {
    outline: solid 1px;
  }
  .mat-calendar-body-today {
    outline: dotted 1px;
  }
  .mat-calendar-body-cell::before,
  .mat-calendar-body-cell::after,
  .mat-calendar-body-selected {
    background: none;
  }
  .mat-calendar-body-in-range::before,
  .mat-calendar-body-comparison-bridge-start::before,
  .mat-calendar-body-comparison-bridge-end::before {
    border-top: solid 1px;
    border-bottom: solid 1px;
  }
  .mat-calendar-body-range-start::before {
    border-left: solid 1px;
  }
  [dir=rtl] .mat-calendar-body-range-start::before {
    border-left: 0;
    border-right: solid 1px;
  }
  .mat-calendar-body-range-end::before {
    border-right: solid 1px;
  }
  [dir=rtl] .mat-calendar-body-range-end::before {
    border-right: 0;
    border-left: solid 1px;
  }
  .mat-calendar-body-in-comparison-range::before {
    border-top: dashed 1px;
    border-bottom: dashed 1px;
  }
  .mat-calendar-body-comparison-start::before {
    border-left: dashed 1px;
  }
  [dir=rtl] .mat-calendar-body-comparison-start::before {
    border-left: 0;
    border-right: dashed 1px;
  }
  .mat-calendar-body-comparison-end::before {
    border-right: dashed 1px;
  }
  [dir=rtl] .mat-calendar-body-comparison-end::before {
    border-right: 0;
    border-left: dashed 1px;
  }
}
`]}]}],()=>[],{label:[{type:e.Input}],rows:[{type:e.Input}],todayValue:[{type:e.Input}],startValue:[{type:e.Input}],endValue:[{type:e.Input}],labelMinRequiredCells:[{type:e.Input}],numCols:[{type:e.Input}],activeCell:[{type:e.Input}],isRange:[{type:e.Input}],cellAspectRatio:[{type:e.Input}],comparisonStart:[{type:e.Input}],comparisonEnd:[{type:e.Input}],previewStart:[{type:e.Input}],previewEnd:[{type:e.Input}],startDateAccessibleName:[{type:e.Input}],endDateAccessibleName:[{type:e.Input}],selectedValueChange:[{type:e.Output}],previewChange:[{type:e.Output}],activeDateChange:[{type:e.Output}],dragStarted:[{type:e.Output}],dragEnded:[{type:e.Output}]});function ue(s){return s?.nodeName==="TD"}function he(s){let t;return ue(s)?t=s:ue(s.parentNode)?t=s.parentNode:ue(s.parentNode?.parentNode)&&(t=s.parentNode.parentNode),t?.getAttribute("data-mat-row")!=null?t:null}function _e(s,t,a){return a!==null&&t!==a&&s<a&&s===t}function ge(s,t,a){return t!==null&&t!==a&&s>=t&&s===a}function be(s,t,a,n){return n&&t!==null&&a!==null&&t!==a&&s>=t&&s<=a}function Se(s){const t=s.changedTouches[0];return document.elementFromPoint(t.clientX,t.clientY)}class f{start;end;_disableStructuralEquivalency;constructor(t,a){this.start=t,this.end=a}}class w{selection;_adapter;_selectionChanged=new m.Subject;selectionChanged=this._selectionChanged;constructor(t,a){this.selection=t,this._adapter=a,this.selection=t}updateSelection(t,a){const n=this.selection;this.selection=t,this._selectionChanged.next({selection:t,source:a,oldValue:n})}ngOnDestroy(){this._selectionChanged.complete()}_isValidDateInstance(t){return this._adapter.isDateInstance(t)&&this._adapter.isValid(t)}static \u0275fac=function(a){e.\u0275\u0275invalidFactory()};static \u0275prov=e.\u0275\u0275defineInjectable({token:w,factory:w.\u0275fac})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(w,[{type:e.Injectable}],()=>[{type:void 0},{type:p.MJ}],null);class H extends w{constructor(t){super(null,t)}add(t){super.updateSelection(t,this)}isValid(){return this.selection!=null&&this._isValidDateInstance(this.selection)}isComplete(){return this.selection!=null}clone(){const t=new H(this._adapter);return t.updateSelection(this.selection,this),t}static \u0275fac=function(a){return new(a||H)(e.\u0275\u0275inject(p.MJ))};static \u0275prov=e.\u0275\u0275defineInjectable({token:H,factory:H.\u0275fac})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(H,[{type:e.Injectable}],()=>[{type:p.MJ}],null);class z extends w{constructor(t){super(new f(null,null),t)}add(t){let{start:a,end:n}=this.selection;a==null?a=t:n==null?n=t:(a=t,n=null),super.updateSelection(new f(a,n),this)}isValid(){const{start:t,end:a}=this.selection;return t==null&&a==null?!0:t!=null&&a!=null?this._isValidDateInstance(t)&&this._isValidDateInstance(a)&&this._adapter.compareDate(t,a)<=0:(t==null||this._isValidDateInstance(t))&&(a==null||this._isValidDateInstance(a))}isComplete(){return this.selection.start!=null&&this.selection.end!=null}clone(){const t=new z(this._adapter);return t.updateSelection(this.selection,this),t}static \u0275fac=function(a){return new(a||z)(e.\u0275\u0275inject(p.MJ))};static \u0275prov=e.\u0275\u0275defineInjectable({token:z,factory:z.\u0275fac})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(z,[{type:e.Injectable}],()=>[{type:p.MJ}],null);const ce={provide:w,useFactory:()=>(0,e.inject)(w,{optional:!0,skipSelf:!0})||new H((0,e.inject)(p.MJ))},Ie={provide:w,useFactory:()=>(0,e.inject)(w,{optional:!0,skipSelf:!0})||new z((0,e.inject)(p.MJ))},$=new e.InjectionToken("MAT_DATE_RANGE_SELECTION_STRATEGY");class K{_dateAdapter;constructor(t){this._dateAdapter=t}selectionFinished(t,a){let{start:n,end:r}=a;return n==null?n=t:r==null&&t&&this._dateAdapter.compareDate(t,n)>=0?r=t:(n=t,r=null),new f(n,r)}createPreview(t,a){let n=null,r=null;return a.start&&!a.end&&t&&(n=a.start,r=t),new f(n,r)}createDrag(t,a,n){let r=a.start,i=a.end;if(!r||!i)return null;const l=this._dateAdapter,j=l.compareDate(r,i)!==0,ee=l.getYear(n)-l.getYear(t),te=l.getMonth(n)-l.getMonth(t),me=l.getDate(n)-l.getDate(t);return j&&l.sameDate(t,a.start)?(r=n,l.compareDate(n,i)>0&&(i=l.addCalendarYears(i,ee),i=l.addCalendarMonths(i,te),i=l.addCalendarDays(i,me))):j&&l.sameDate(t,a.end)?(i=n,l.compareDate(n,r)<0&&(r=l.addCalendarYears(r,ee),r=l.addCalendarMonths(r,te),r=l.addCalendarDays(r,me))):(r=l.addCalendarYears(r,ee),r=l.addCalendarMonths(r,te),r=l.addCalendarDays(r,me),i=l.addCalendarYears(i,ee),i=l.addCalendarMonths(i,te),i=l.addCalendarDays(i,me)),new f(r,i)}static \u0275fac=function(a){return new(a||K)(e.\u0275\u0275inject(p.MJ))};static \u0275prov=e.\u0275\u0275defineInjectable({token:K,factory:K.\u0275fac})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(K,[{type:e.Injectable}],()=>[{type:p.MJ}],null);const ye=7;let st=0;class I{_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_dateFormats=(0,e.inject)(p.de,{optional:!0});_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_dir=(0,e.inject)(_.Directionality,{optional:!0});_rangeStrategy=(0,e.inject)($,{optional:!0});_rerenderSubscription=m.Subscription.EMPTY;_selectionKeyPressed=!1;get activeDate(){return this._activeDate}set activeDate(t){const a=this._activeDate,n=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))||this._dateAdapter.today();this._activeDate=this._dateAdapter.clampDate(n,this.minDate,this.maxDate),this._hasSameMonthAndYear(a,this._activeDate)||this._init()}_activeDate;get selected(){return this._selected}set selected(t){t instanceof f?this._selected=t:this._selected=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t)),this._setRanges(this._selected)}_selected=null;get minDate(){return this._minDate}set minDate(t){this._minDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_minDate=null;get maxDate(){return this._maxDate}set maxDate(t){this._maxDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_maxDate=null;dateFilter;dateClass;comparisonStart=null;comparisonEnd=null;startDateAccessibleName=null;endDateAccessibleName=null;activeDrag=null;selectedChange=new e.EventEmitter;_userSelection=new e.EventEmitter;dragStarted=new e.EventEmitter;dragEnded=new e.EventEmitter;activeDateChange=new e.EventEmitter;_matCalendarBody;_monthLabel=(0,e.signal)("",...ngDevMode?[{debugName:"_monthLabel"}]:[]);_weeks=(0,e.signal)([],...ngDevMode?[{debugName:"_weeks"}]:[]);_firstWeekOffset=(0,e.signal)(0,...ngDevMode?[{debugName:"_firstWeekOffset"}]:[]);_rangeStart=(0,e.signal)(null,...ngDevMode?[{debugName:"_rangeStart"}]:[]);_rangeEnd=(0,e.signal)(null,...ngDevMode?[{debugName:"_rangeEnd"}]:[]);_comparisonRangeStart=(0,e.signal)(null,...ngDevMode?[{debugName:"_comparisonRangeStart"}]:[]);_comparisonRangeEnd=(0,e.signal)(null,...ngDevMode?[{debugName:"_comparisonRangeEnd"}]:[]);_previewStart=(0,e.signal)(null,...ngDevMode?[{debugName:"_previewStart"}]:[]);_previewEnd=(0,e.signal)(null,...ngDevMode?[{debugName:"_previewEnd"}]:[]);_isRange=(0,e.signal)(!1,...ngDevMode?[{debugName:"_isRange"}]:[]);_todayDate=(0,e.signal)(null,...ngDevMode?[{debugName:"_todayDate"}]:[]);_weekdays=(0,e.signal)([],...ngDevMode?[{debugName:"_weekdays"}]:[]);constructor(){if((0,e.inject)(U._CdkPrivateStyleLoader).load(U._VisuallyHiddenLoader),typeof ngDevMode>"u"||ngDevMode){if(!this._dateAdapter)throw S("DateAdapter");if(!this._dateFormats)throw S("MAT_DATE_FORMATS")}this._activeDate=this._dateAdapter.today()}ngAfterContentInit(){this._rerenderSubscription=this._dateAdapter.localeChanges.pipe((0,A.startWith)(null)).subscribe(()=>this._init())}ngOnChanges(t){const a=t.comparisonStart||t.comparisonEnd;a&&!a.firstChange&&this._setRanges(this.selected),t.activeDrag&&!this.activeDrag&&this._clearPreview()}ngOnDestroy(){this._rerenderSubscription.unsubscribe()}_dateSelected(t){const a=t.value,n=this._getDateFromDayOfMonth(a);let r,i;this._selected instanceof f?(r=this._getDateInCurrentMonth(this._selected.start),i=this._getDateInCurrentMonth(this._selected.end)):r=i=this._getDateInCurrentMonth(this._selected),(r!==a||i!==a)&&this.selectedChange.emit(n),this._userSelection.emit({value:n,event:t.event}),this._clearPreview(),this._changeDetectorRef.markForCheck()}_updateActiveDate(t){const a=t.value,n=this._activeDate;this.activeDate=this._getDateFromDayOfMonth(a),this._dateAdapter.compareDate(n,this.activeDate)&&this.activeDateChange.emit(this._activeDate)}_handleCalendarBodyKeydown(t){const a=this._activeDate,n=this._isRtl();switch(t.keyCode){case o.LEFT_ARROW:this.activeDate=this._dateAdapter.addCalendarDays(this._activeDate,n?1:-1);break;case o.RIGHT_ARROW:this.activeDate=this._dateAdapter.addCalendarDays(this._activeDate,n?-1:1);break;case o.UP_ARROW:this.activeDate=this._dateAdapter.addCalendarDays(this._activeDate,-7);break;case o.DOWN_ARROW:this.activeDate=this._dateAdapter.addCalendarDays(this._activeDate,7);break;case o.HOME:this.activeDate=this._dateAdapter.addCalendarDays(this._activeDate,1-this._dateAdapter.getDate(this._activeDate));break;case o.END:this.activeDate=this._dateAdapter.addCalendarDays(this._activeDate,this._dateAdapter.getNumDaysInMonth(this._activeDate)-this._dateAdapter.getDate(this._activeDate));break;case o.PAGE_UP:this.activeDate=t.altKey?this._dateAdapter.addCalendarYears(this._activeDate,-1):this._dateAdapter.addCalendarMonths(this._activeDate,-1);break;case o.PAGE_DOWN:this.activeDate=t.altKey?this._dateAdapter.addCalendarYears(this._activeDate,1):this._dateAdapter.addCalendarMonths(this._activeDate,1);break;case o.ENTER:case o.SPACE:this._selectionKeyPressed=!0,this._canSelect(this._activeDate)&&t.preventDefault();return;case o.ESCAPE:this._previewEnd()!=null&&!(0,o.hasModifierKey)(t)&&(this._clearPreview(),this.activeDrag?this.dragEnded.emit({value:null,event:t}):(this.selectedChange.emit(null),this._userSelection.emit({value:null,event:t})),t.preventDefault(),t.stopPropagation());return;default:return}this._dateAdapter.compareDate(a,this.activeDate)&&(this.activeDateChange.emit(this.activeDate),this._focusActiveCellAfterViewChecked()),t.preventDefault()}_handleCalendarBodyKeyup(t){(t.keyCode===o.SPACE||t.keyCode===o.ENTER)&&(this._selectionKeyPressed&&this._canSelect(this._activeDate)&&this._dateSelected({value:this._dateAdapter.getDate(this._activeDate),event:t}),this._selectionKeyPressed=!1)}_init(){this._setRanges(this.selected),this._todayDate.set(this._getCellCompareValue(this._dateAdapter.today())),this._monthLabel.set(this._dateFormats.display.monthLabel?this._dateAdapter.format(this.activeDate,this._dateFormats.display.monthLabel):this._dateAdapter.getMonthNames("short")[this._dateAdapter.getMonth(this.activeDate)].toLocaleUpperCase());let t=this._dateAdapter.createDate(this._dateAdapter.getYear(this.activeDate),this._dateAdapter.getMonth(this.activeDate),1);this._firstWeekOffset.set((ye+this._dateAdapter.getDayOfWeek(t)-this._dateAdapter.getFirstDayOfWeek())%ye),this._initWeekdays(),this._createWeekCells(),this._changeDetectorRef.markForCheck()}_focusActiveCell(t){this._matCalendarBody._focusActiveCell(t)}_focusActiveCellAfterViewChecked(){this._matCalendarBody._scheduleFocusActiveCellAfterViewChecked()}_previewChanged({event:t,value:a}){if(this._rangeStrategy){const n=a?a.rawValue:null,r=this._rangeStrategy.createPreview(n,this.selected,t);if(this._previewStart.set(this._getCellCompareValue(r.start)),this._previewEnd.set(this._getCellCompareValue(r.end)),this.activeDrag&&n){const i=this._rangeStrategy.createDrag?.(this.activeDrag.value,this.selected,n,t);i&&(this._previewStart.set(this._getCellCompareValue(i.start)),this._previewEnd.set(this._getCellCompareValue(i.end)))}}}_dragEnded(t){if(this.activeDrag)if(t.value){const a=this._rangeStrategy?.createDrag?.(this.activeDrag.value,this.selected,t.value,t.event);this.dragEnded.emit({value:a??null,event:t.event})}else this.dragEnded.emit({value:null,event:t.event})}_getDateFromDayOfMonth(t){return this._dateAdapter.createDate(this._dateAdapter.getYear(this.activeDate),this._dateAdapter.getMonth(this.activeDate),t)}_initWeekdays(){const t=this._dateAdapter.getFirstDayOfWeek(),a=this._dateAdapter.getDayOfWeekNames("narrow"),r=this._dateAdapter.getDayOfWeekNames("long").map((i,l)=>({long:i,narrow:a[l],id:st++}));this._weekdays.set(r.slice(t).concat(r.slice(0,t)))}_createWeekCells(){const t=this._dateAdapter.getNumDaysInMonth(this.activeDate),a=this._dateAdapter.getDateNames(),n=[[]];for(let r=0,i=this._firstWeekOffset();r<t;r++,i++){i==ye&&(n.push([]),i=0);const l=this._dateAdapter.createDate(this._dateAdapter.getYear(this.activeDate),this._dateAdapter.getMonth(this.activeDate),r+1),j=this._shouldEnableDate(l),ee=this._dateAdapter.format(l,this._dateFormats.display.dateA11yLabel),te=this.dateClass?this.dateClass(l,"month"):void 0;n[n.length-1].push(new de(r+1,a[r],ee,j,te,this._getCellCompareValue(l),l))}this._weeks.set(n)}_shouldEnableDate(t){return!!t&&(!this.minDate||this._dateAdapter.compareDate(t,this.minDate)>=0)&&(!this.maxDate||this._dateAdapter.compareDate(t,this.maxDate)<=0)&&(!this.dateFilter||this.dateFilter(t))}_getDateInCurrentMonth(t){return t&&this._hasSameMonthAndYear(t,this.activeDate)?this._dateAdapter.getDate(t):null}_hasSameMonthAndYear(t,a){return!!(t&&a&&this._dateAdapter.getMonth(t)==this._dateAdapter.getMonth(a)&&this._dateAdapter.getYear(t)==this._dateAdapter.getYear(a))}_getCellCompareValue(t){if(t){const a=this._dateAdapter.getYear(t),n=this._dateAdapter.getMonth(t),r=this._dateAdapter.getDate(t);return new Date(a,n,r).getTime()}return null}_isRtl(){return this._dir&&this._dir.value==="rtl"}_setRanges(t){t instanceof f?(this._rangeStart.set(this._getCellCompareValue(t.start)),this._rangeEnd.set(this._getCellCompareValue(t.end)),this._isRange.set(!0)):(this._rangeStart.set(this._getCellCompareValue(t)),this._rangeEnd.set(this._rangeStart()),this._isRange.set(!1)),this._comparisonRangeStart.set(this._getCellCompareValue(this.comparisonStart)),this._comparisonRangeEnd.set(this._getCellCompareValue(this.comparisonEnd))}_canSelect(t){return!this.dateFilter||this.dateFilter(t)}_clearPreview(){this._previewStart.set(null),this._previewEnd.set(null)}static \u0275fac=function(a){return new(a||I)};static \u0275cmp=e.\u0275\u0275defineComponent({type:I,selectors:[["mat-month-view"]],viewQuery:function(a,n){if(a&1&&e.\u0275\u0275viewQuery(b,5),a&2){let r;e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n._matCalendarBody=r.first)}},inputs:{activeDate:"activeDate",selected:"selected",minDate:"minDate",maxDate:"maxDate",dateFilter:"dateFilter",dateClass:"dateClass",comparisonStart:"comparisonStart",comparisonEnd:"comparisonEnd",startDateAccessibleName:"startDateAccessibleName",endDateAccessibleName:"endDateAccessibleName",activeDrag:"activeDrag"},outputs:{selectedChange:"selectedChange",_userSelection:"_userSelection",dragStarted:"dragStarted",dragEnded:"dragEnded",activeDateChange:"activeDateChange"},exportAs:["matMonthView"],features:[e.\u0275\u0275NgOnChangesFeature],decls:8,vars:14,consts:[["role","grid",1,"mat-calendar-table"],[1,"mat-calendar-table-header"],["scope","col"],["aria-hidden","true"],["colspan","7",1,"mat-calendar-table-header-divider"],["mat-calendar-body","",3,"selectedValueChange","activeDateChange","previewChange","dragStarted","dragEnded","keyup","keydown","label","rows","todayValue","startValue","endValue","comparisonStart","comparisonEnd","previewStart","previewEnd","isRange","labelMinRequiredCells","activeCell","startDateAccessibleName","endDateAccessibleName"],[1,"cdk-visually-hidden"]],template:function(a,n){a&1&&(e.\u0275\u0275elementStart(0,"table",0)(1,"thead",1)(2,"tr"),e.\u0275\u0275repeaterCreate(3,We,5,2,"th",2,Me),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(5,"tr",3),e.\u0275\u0275element(6,"th",4),e.\u0275\u0275elementEnd()(),e.\u0275\u0275elementStart(7,"tbody",5),e.\u0275\u0275listener("selectedValueChange",function(i){return n._dateSelected(i)})("activeDateChange",function(i){return n._updateActiveDate(i)})("previewChange",function(i){return n._previewChanged(i)})("dragStarted",function(i){return n.dragStarted.emit(i)})("dragEnded",function(i){return n._dragEnded(i)})("keyup",function(i){return n._handleCalendarBodyKeyup(i)})("keydown",function(i){return n._handleCalendarBodyKeydown(i)}),e.\u0275\u0275elementEnd()()),a&2&&(e.\u0275\u0275advance(3),e.\u0275\u0275repeater(n._weekdays()),e.\u0275\u0275advance(4),e.\u0275\u0275property("label",n._monthLabel())("rows",n._weeks())("todayValue",n._todayDate())("startValue",n._rangeStart())("endValue",n._rangeEnd())("comparisonStart",n._comparisonRangeStart())("comparisonEnd",n._comparisonRangeEnd())("previewStart",n._previewStart())("previewEnd",n._previewEnd())("isRange",n._isRange())("labelMinRequiredCells",3)("activeCell",n._dateAdapter.getDate(n.activeDate)-1)("startDateAccessibleName",n.startDateAccessibleName)("endDateAccessibleName",n.endDateAccessibleName))},dependencies:[b],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(I,[{type:e.Component,args:[{selector:"mat-month-view",exportAs:"matMonthView",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,imports:[b],template:`<table class="mat-calendar-table" role="grid">
  <thead class="mat-calendar-table-header">
    <tr>
      @for (day of _weekdays(); track day.id) {
        <th scope="col">
          <span class="cdk-visually-hidden">{{day.long}}</span>
          <span aria-hidden="true">{{day.narrow}}</span>
        </th>
      }
    </tr>
    <tr aria-hidden="true"><th class="mat-calendar-table-header-divider" colspan="7"></th></tr>
  </thead>
  <tbody mat-calendar-body
         [label]="_monthLabel()"
         [rows]="_weeks()"
         [todayValue]="_todayDate()!"
         [startValue]="_rangeStart()!"
         [endValue]="_rangeEnd()!"
         [comparisonStart]="_comparisonRangeStart()"
         [comparisonEnd]="_comparisonRangeEnd()"
         [previewStart]="_previewStart()"
         [previewEnd]="_previewEnd()"
         [isRange]="_isRange()"
         [labelMinRequiredCells]="3"
         [activeCell]="_dateAdapter.getDate(activeDate) - 1"
         [startDateAccessibleName]="startDateAccessibleName"
         [endDateAccessibleName]="endDateAccessibleName"
         (selectedValueChange)="_dateSelected($event)"
         (activeDateChange)="_updateActiveDate($event)"
         (previewChange)="_previewChanged($event)"
         (dragStarted)="dragStarted.emit($event)"
         (dragEnded)="_dragEnded($event)"
         (keyup)="_handleCalendarBodyKeyup($event)"
         (keydown)="_handleCalendarBodyKeydown($event)">
  </tbody>
</table>
`}]}],()=>[],{activeDate:[{type:e.Input}],selected:[{type:e.Input}],minDate:[{type:e.Input}],maxDate:[{type:e.Input}],dateFilter:[{type:e.Input}],dateClass:[{type:e.Input}],comparisonStart:[{type:e.Input}],comparisonEnd:[{type:e.Input}],startDateAccessibleName:[{type:e.Input}],endDateAccessibleName:[{type:e.Input}],activeDrag:[{type:e.Input}],selectedChange:[{type:e.Output}],_userSelection:[{type:e.Output}],dragStarted:[{type:e.Output}],dragEnded:[{type:e.Output}],activeDateChange:[{type:e.Output}],_matCalendarBody:[{type:e.ViewChild,args:[b]}]});const D=24,pe=4;class V{_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_dir=(0,e.inject)(_.Directionality,{optional:!0});_rerenderSubscription=m.Subscription.EMPTY;_selectionKeyPressed=!1;get activeDate(){return this._activeDate}set activeDate(t){let a=this._activeDate;const n=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))||this._dateAdapter.today();this._activeDate=this._dateAdapter.clampDate(n,this.minDate,this.maxDate),Ve(this._dateAdapter,a,this._activeDate,this.minDate,this.maxDate)||this._init()}_activeDate;get selected(){return this._selected}set selected(t){t instanceof f?this._selected=t:this._selected=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t)),this._setSelectedYear(t)}_selected=null;get minDate(){return this._minDate}set minDate(t){this._minDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_minDate=null;get maxDate(){return this._maxDate}set maxDate(t){this._maxDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_maxDate=null;dateFilter;dateClass;selectedChange=new e.EventEmitter;yearSelected=new e.EventEmitter;activeDateChange=new e.EventEmitter;_matCalendarBody;_years=(0,e.signal)([],...ngDevMode?[{debugName:"_years"}]:[]);_todayYear=(0,e.signal)(0,...ngDevMode?[{debugName:"_todayYear"}]:[]);_selectedYear=(0,e.signal)(null,...ngDevMode?[{debugName:"_selectedYear"}]:[]);constructor(){if(!this._dateAdapter&&(typeof ngDevMode>"u"||ngDevMode))throw S("DateAdapter");this._activeDate=this._dateAdapter.today()}ngAfterContentInit(){this._rerenderSubscription=this._dateAdapter.localeChanges.pipe((0,A.startWith)(null)).subscribe(()=>this._init())}ngOnDestroy(){this._rerenderSubscription.unsubscribe()}_init(){this._todayYear.set(this._dateAdapter.getYear(this._dateAdapter.today()));const a=this._dateAdapter.getYear(this._activeDate)-ae(this._dateAdapter,this.activeDate,this.minDate,this.maxDate),n=[];for(let r=0,i=[];r<D;r++)i.push(a+r),i.length==pe&&(n.push(i.map(l=>this._createCellForYear(l))),i=[]);this._years.set(n),this._changeDetectorRef.markForCheck()}_yearSelected(t){const a=t.value,n=this._dateAdapter.createDate(a,0,1),r=this._getDateFromYear(a);this.yearSelected.emit(n),this.selectedChange.emit(r)}_updateActiveDate(t){const a=t.value,n=this._activeDate;this.activeDate=this._getDateFromYear(a),this._dateAdapter.compareDate(n,this.activeDate)&&this.activeDateChange.emit(this.activeDate)}_handleCalendarBodyKeydown(t){const a=this._activeDate,n=this._isRtl();switch(t.keyCode){case o.LEFT_ARROW:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,n?1:-1);break;case o.RIGHT_ARROW:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,n?-1:1);break;case o.UP_ARROW:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,-pe);break;case o.DOWN_ARROW:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,pe);break;case o.HOME:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,-ae(this._dateAdapter,this.activeDate,this.minDate,this.maxDate));break;case o.END:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,D-ae(this._dateAdapter,this.activeDate,this.minDate,this.maxDate)-1);break;case o.PAGE_UP:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,t.altKey?-D*10:-D);break;case o.PAGE_DOWN:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,t.altKey?D*10:D);break;case o.ENTER:case o.SPACE:this._selectionKeyPressed=!0;break;default:return}this._dateAdapter.compareDate(a,this.activeDate)&&this.activeDateChange.emit(this.activeDate),this._focusActiveCellAfterViewChecked(),t.preventDefault()}_handleCalendarBodyKeyup(t){(t.keyCode===o.SPACE||t.keyCode===o.ENTER)&&(this._selectionKeyPressed&&this._yearSelected({value:this._dateAdapter.getYear(this._activeDate),event:t}),this._selectionKeyPressed=!1)}_getActiveCell(){return ae(this._dateAdapter,this.activeDate,this.minDate,this.maxDate)}_focusActiveCell(){this._matCalendarBody._focusActiveCell()}_focusActiveCellAfterViewChecked(){this._matCalendarBody._scheduleFocusActiveCellAfterViewChecked()}_getDateFromYear(t){const a=this._dateAdapter.getMonth(this.activeDate),n=this._dateAdapter.getNumDaysInMonth(this._dateAdapter.createDate(t,a,1));return this._dateAdapter.createDate(t,a,Math.min(this._dateAdapter.getDate(this.activeDate),n))}_createCellForYear(t){const a=this._dateAdapter.createDate(t,0,1),n=this._dateAdapter.getYearName(a),r=this.dateClass?this.dateClass(a,"multi-year"):void 0;return new de(t,n,n,this._shouldEnableYear(t),r)}_shouldEnableYear(t){if(t==null||this.maxDate&&t>this._dateAdapter.getYear(this.maxDate)||this.minDate&&t<this._dateAdapter.getYear(this.minDate))return!1;if(!this.dateFilter)return!0;const a=this._dateAdapter.createDate(t,0,1);for(let n=a;this._dateAdapter.getYear(n)==t;n=this._dateAdapter.addCalendarDays(n,1))if(this.dateFilter(n))return!0;return!1}_isRtl(){return this._dir&&this._dir.value==="rtl"}_setSelectedYear(t){if(this._selectedYear.set(null),t instanceof f){const a=t.start||t.end;a&&this._selectedYear.set(this._dateAdapter.getYear(a))}else t&&this._selectedYear.set(this._dateAdapter.getYear(t))}static \u0275fac=function(a){return new(a||V)};static \u0275cmp=e.\u0275\u0275defineComponent({type:V,selectors:[["mat-multi-year-view"]],viewQuery:function(a,n){if(a&1&&e.\u0275\u0275viewQuery(b,5),a&2){let r;e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n._matCalendarBody=r.first)}},inputs:{activeDate:"activeDate",selected:"selected",minDate:"minDate",maxDate:"maxDate",dateFilter:"dateFilter",dateClass:"dateClass"},outputs:{selectedChange:"selectedChange",yearSelected:"yearSelected",activeDateChange:"activeDateChange"},exportAs:["matMultiYearView"],decls:5,vars:7,consts:[["role","grid",1,"mat-calendar-table"],["aria-hidden","true",1,"mat-calendar-table-header"],["colspan","4",1,"mat-calendar-table-header-divider"],["mat-calendar-body","",3,"selectedValueChange","activeDateChange","keyup","keydown","rows","todayValue","startValue","endValue","numCols","cellAspectRatio","activeCell"]],template:function(a,n){a&1&&(e.\u0275\u0275elementStart(0,"table",0)(1,"thead",1)(2,"tr"),e.\u0275\u0275element(3,"th",2),e.\u0275\u0275elementEnd()(),e.\u0275\u0275elementStart(4,"tbody",3),e.\u0275\u0275listener("selectedValueChange",function(i){return n._yearSelected(i)})("activeDateChange",function(i){return n._updateActiveDate(i)})("keyup",function(i){return n._handleCalendarBodyKeyup(i)})("keydown",function(i){return n._handleCalendarBodyKeydown(i)}),e.\u0275\u0275elementEnd()()),a&2&&(e.\u0275\u0275advance(4),e.\u0275\u0275property("rows",n._years())("todayValue",n._todayYear())("startValue",n._selectedYear())("endValue",n._selectedYear())("numCols",4)("cellAspectRatio",4/7)("activeCell",n._getActiveCell()))},dependencies:[b],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(V,[{type:e.Component,args:[{selector:"mat-multi-year-view",exportAs:"matMultiYearView",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,imports:[b],template:`<table class="mat-calendar-table" role="grid">
  <thead aria-hidden="true" class="mat-calendar-table-header">
    <tr><th class="mat-calendar-table-header-divider" colspan="4"></th></tr>
  </thead>
  <tbody mat-calendar-body
         [rows]="_years()"
         [todayValue]="_todayYear()"
         [startValue]="_selectedYear()!"
         [endValue]="_selectedYear()!"
         [numCols]="4"
         [cellAspectRatio]="4 / 7"
         [activeCell]="_getActiveCell()"
         (selectedValueChange)="_yearSelected($event)"
         (activeDateChange)="_updateActiveDate($event)"
         (keyup)="_handleCalendarBodyKeyup($event)"
         (keydown)="_handleCalendarBodyKeydown($event)">
  </tbody>
</table>
`}]}],()=>[],{activeDate:[{type:e.Input}],selected:[{type:e.Input}],minDate:[{type:e.Input}],maxDate:[{type:e.Input}],dateFilter:[{type:e.Input}],dateClass:[{type:e.Input}],selectedChange:[{type:e.Output}],yearSelected:[{type:e.Output}],activeDateChange:[{type:e.Output}],_matCalendarBody:[{type:e.ViewChild,args:[b]}]});function Ve(s,t,a,n,r){const i=s.getYear(t),l=s.getYear(a),j=Re(s,n,r);return Math.floor((i-j)/D)===Math.floor((l-j)/D)}function ae(s,t,a,n){const r=s.getYear(t);return ot(r-Re(s,a,n),D)}function Re(s,t,a){let n=0;return a?n=s.getYear(a)-D+1:t&&(n=s.getYear(t)),n}function ot(s,t){return(s%t+t)%t}class R{_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_dateFormats=(0,e.inject)(p.de,{optional:!0});_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_dir=(0,e.inject)(_.Directionality,{optional:!0});_rerenderSubscription=m.Subscription.EMPTY;_selectionKeyPressed=!1;get activeDate(){return this._activeDate}set activeDate(t){let a=this._activeDate;const n=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))||this._dateAdapter.today();this._activeDate=this._dateAdapter.clampDate(n,this.minDate,this.maxDate),this._dateAdapter.getYear(a)!==this._dateAdapter.getYear(this._activeDate)&&this._init()}_activeDate;get selected(){return this._selected}set selected(t){t instanceof f?this._selected=t:this._selected=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t)),this._setSelectedMonth(t)}_selected=null;get minDate(){return this._minDate}set minDate(t){this._minDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_minDate=null;get maxDate(){return this._maxDate}set maxDate(t){this._maxDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_maxDate=null;dateFilter;dateClass;selectedChange=new e.EventEmitter;monthSelected=new e.EventEmitter;activeDateChange=new e.EventEmitter;_matCalendarBody;_months=(0,e.signal)([],...ngDevMode?[{debugName:"_months"}]:[]);_yearLabel=(0,e.signal)("",...ngDevMode?[{debugName:"_yearLabel"}]:[]);_todayMonth=(0,e.signal)(null,...ngDevMode?[{debugName:"_todayMonth"}]:[]);_selectedMonth=(0,e.signal)(null,...ngDevMode?[{debugName:"_selectedMonth"}]:[]);constructor(){if(typeof ngDevMode>"u"||ngDevMode){if(!this._dateAdapter)throw S("DateAdapter");if(!this._dateFormats)throw S("MAT_DATE_FORMATS")}this._activeDate=this._dateAdapter.today()}ngAfterContentInit(){this._rerenderSubscription=this._dateAdapter.localeChanges.pipe((0,A.startWith)(null)).subscribe(()=>this._init())}ngOnDestroy(){this._rerenderSubscription.unsubscribe()}_monthSelected(t){const a=t.value,n=this._dateAdapter.createDate(this._dateAdapter.getYear(this.activeDate),a,1);this.monthSelected.emit(n);const r=this._getDateFromMonth(a);this.selectedChange.emit(r)}_updateActiveDate(t){const a=t.value,n=this._activeDate;this.activeDate=this._getDateFromMonth(a),this._dateAdapter.compareDate(n,this.activeDate)&&this.activeDateChange.emit(this.activeDate)}_handleCalendarBodyKeydown(t){const a=this._activeDate,n=this._isRtl();switch(t.keyCode){case o.LEFT_ARROW:this.activeDate=this._dateAdapter.addCalendarMonths(this._activeDate,n?1:-1);break;case o.RIGHT_ARROW:this.activeDate=this._dateAdapter.addCalendarMonths(this._activeDate,n?-1:1);break;case o.UP_ARROW:this.activeDate=this._dateAdapter.addCalendarMonths(this._activeDate,-4);break;case o.DOWN_ARROW:this.activeDate=this._dateAdapter.addCalendarMonths(this._activeDate,4);break;case o.HOME:this.activeDate=this._dateAdapter.addCalendarMonths(this._activeDate,-this._dateAdapter.getMonth(this._activeDate));break;case o.END:this.activeDate=this._dateAdapter.addCalendarMonths(this._activeDate,11-this._dateAdapter.getMonth(this._activeDate));break;case o.PAGE_UP:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,t.altKey?-10:-1);break;case o.PAGE_DOWN:this.activeDate=this._dateAdapter.addCalendarYears(this._activeDate,t.altKey?10:1);break;case o.ENTER:case o.SPACE:this._selectionKeyPressed=!0;break;default:return}this._dateAdapter.compareDate(a,this.activeDate)&&(this.activeDateChange.emit(this.activeDate),this._focusActiveCellAfterViewChecked()),t.preventDefault()}_handleCalendarBodyKeyup(t){(t.keyCode===o.SPACE||t.keyCode===o.ENTER)&&(this._selectionKeyPressed&&this._monthSelected({value:this._dateAdapter.getMonth(this._activeDate),event:t}),this._selectionKeyPressed=!1)}_init(){this._setSelectedMonth(this.selected),this._todayMonth.set(this._getMonthInCurrentYear(this._dateAdapter.today())),this._yearLabel.set(this._dateAdapter.getYearName(this.activeDate));let t=this._dateAdapter.getMonthNames("short");this._months.set([[0,1,2,3],[4,5,6,7],[8,9,10,11]].map(a=>a.map(n=>this._createCellForMonth(n,t[n])))),this._changeDetectorRef.markForCheck()}_focusActiveCell(){this._matCalendarBody._focusActiveCell()}_focusActiveCellAfterViewChecked(){this._matCalendarBody._scheduleFocusActiveCellAfterViewChecked()}_getMonthInCurrentYear(t){return t&&this._dateAdapter.getYear(t)==this._dateAdapter.getYear(this.activeDate)?this._dateAdapter.getMonth(t):null}_getDateFromMonth(t){const a=this._dateAdapter.createDate(this._dateAdapter.getYear(this.activeDate),t,1),n=this._dateAdapter.getNumDaysInMonth(a);return this._dateAdapter.createDate(this._dateAdapter.getYear(this.activeDate),t,Math.min(this._dateAdapter.getDate(this.activeDate),n))}_createCellForMonth(t,a){const n=this._dateAdapter.createDate(this._dateAdapter.getYear(this.activeDate),t,1),r=this._dateAdapter.format(n,this._dateFormats.display.monthYearA11yLabel),i=this.dateClass?this.dateClass(n,"year"):void 0;return new de(t,a.toLocaleUpperCase(),r,this._shouldEnableMonth(t),i)}_shouldEnableMonth(t){const a=this._dateAdapter.getYear(this.activeDate);if(t==null||this._isYearAndMonthAfterMaxDate(a,t)||this._isYearAndMonthBeforeMinDate(a,t))return!1;if(!this.dateFilter)return!0;const n=this._dateAdapter.createDate(a,t,1);for(let r=n;this._dateAdapter.getMonth(r)==t;r=this._dateAdapter.addCalendarDays(r,1))if(this.dateFilter(r))return!0;return!1}_isYearAndMonthAfterMaxDate(t,a){if(this.maxDate){const n=this._dateAdapter.getYear(this.maxDate),r=this._dateAdapter.getMonth(this.maxDate);return t>n||t===n&&a>r}return!1}_isYearAndMonthBeforeMinDate(t,a){if(this.minDate){const n=this._dateAdapter.getYear(this.minDate),r=this._dateAdapter.getMonth(this.minDate);return t<n||t===n&&a<r}return!1}_isRtl(){return this._dir&&this._dir.value==="rtl"}_setSelectedMonth(t){t instanceof f?this._selectedMonth.set(this._getMonthInCurrentYear(t.start)||this._getMonthInCurrentYear(t.end)):this._selectedMonth.set(this._getMonthInCurrentYear(t))}static \u0275fac=function(a){return new(a||R)};static \u0275cmp=e.\u0275\u0275defineComponent({type:R,selectors:[["mat-year-view"]],viewQuery:function(a,n){if(a&1&&e.\u0275\u0275viewQuery(b,5),a&2){let r;e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n._matCalendarBody=r.first)}},inputs:{activeDate:"activeDate",selected:"selected",minDate:"minDate",maxDate:"maxDate",dateFilter:"dateFilter",dateClass:"dateClass"},outputs:{selectedChange:"selectedChange",monthSelected:"monthSelected",activeDateChange:"activeDateChange"},exportAs:["matYearView"],decls:5,vars:9,consts:[["role","grid",1,"mat-calendar-table"],["aria-hidden","true",1,"mat-calendar-table-header"],["colspan","4",1,"mat-calendar-table-header-divider"],["mat-calendar-body","",3,"selectedValueChange","activeDateChange","keyup","keydown","label","rows","todayValue","startValue","endValue","labelMinRequiredCells","numCols","cellAspectRatio","activeCell"]],template:function(a,n){a&1&&(e.\u0275\u0275elementStart(0,"table",0)(1,"thead",1)(2,"tr"),e.\u0275\u0275element(3,"th",2),e.\u0275\u0275elementEnd()(),e.\u0275\u0275elementStart(4,"tbody",3),e.\u0275\u0275listener("selectedValueChange",function(i){return n._monthSelected(i)})("activeDateChange",function(i){return n._updateActiveDate(i)})("keyup",function(i){return n._handleCalendarBodyKeyup(i)})("keydown",function(i){return n._handleCalendarBodyKeydown(i)}),e.\u0275\u0275elementEnd()()),a&2&&(e.\u0275\u0275advance(4),e.\u0275\u0275property("label",n._yearLabel())("rows",n._months())("todayValue",n._todayMonth())("startValue",n._selectedMonth())("endValue",n._selectedMonth())("labelMinRequiredCells",2)("numCols",4)("cellAspectRatio",4/7)("activeCell",n._dateAdapter.getMonth(n.activeDate)))},dependencies:[b],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(R,[{type:e.Component,args:[{selector:"mat-year-view",exportAs:"matYearView",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,imports:[b],template:`<table class="mat-calendar-table" role="grid">
  <thead aria-hidden="true" class="mat-calendar-table-header">
    <tr><th class="mat-calendar-table-header-divider" colspan="4"></th></tr>
  </thead>
  <tbody mat-calendar-body
         [label]="_yearLabel()"
         [rows]="_months()"
         [todayValue]="_todayMonth()!"
         [startValue]="_selectedMonth()!"
         [endValue]="_selectedMonth()!"
         [labelMinRequiredCells]="2"
         [numCols]="4"
         [cellAspectRatio]="4 / 7"
         [activeCell]="_dateAdapter.getMonth(activeDate)"
         (selectedValueChange)="_monthSelected($event)"
         (activeDateChange)="_updateActiveDate($event)"
         (keyup)="_handleCalendarBodyKeyup($event)"
         (keydown)="_handleCalendarBodyKeydown($event)">
  </tbody>
</table>
`}]}],()=>[],{activeDate:[{type:e.Input}],selected:[{type:e.Input}],minDate:[{type:e.Input}],maxDate:[{type:e.Input}],dateFilter:[{type:e.Input}],dateClass:[{type:e.Input}],selectedChange:[{type:e.Output}],monthSelected:[{type:e.Output}],activeDateChange:[{type:e.Output}],_matCalendarBody:[{type:e.ViewChild,args:[b]}]});class N{_intl=(0,e.inject)(C);calendar=(0,e.inject)(M);_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_dateFormats=(0,e.inject)(p.de,{optional:!0});_periodButtonText;_periodButtonDescription;_periodButtonLabel;_prevButtonLabel;_nextButtonLabel;constructor(){(0,e.inject)(U._CdkPrivateStyleLoader).load(U._VisuallyHiddenLoader);const t=(0,e.inject)(e.ChangeDetectorRef);this._updateLabels(),this.calendar.stateChanges.subscribe(()=>{this._updateLabels(),t.markForCheck()})}get periodButtonText(){return this._periodButtonText}get periodButtonDescription(){return this._periodButtonDescription}get periodButtonLabel(){return this._periodButtonLabel}get prevButtonLabel(){return this._prevButtonLabel}get nextButtonLabel(){return this._nextButtonLabel}currentPeriodClicked(){this.calendar.currentView=this.calendar.currentView=="month"?"multi-year":"month"}previousClicked(){this.previousEnabled()&&(this.calendar.activeDate=this.calendar.currentView=="month"?this._dateAdapter.addCalendarMonths(this.calendar.activeDate,-1):this._dateAdapter.addCalendarYears(this.calendar.activeDate,this.calendar.currentView=="year"?-1:-D))}nextClicked(){this.nextEnabled()&&(this.calendar.activeDate=this.calendar.currentView=="month"?this._dateAdapter.addCalendarMonths(this.calendar.activeDate,1):this._dateAdapter.addCalendarYears(this.calendar.activeDate,this.calendar.currentView=="year"?1:D))}previousEnabled(){return this.calendar.minDate?!this.calendar.minDate||!this._isSameView(this.calendar.activeDate,this.calendar.minDate):!0}nextEnabled(){return!this.calendar.maxDate||!this._isSameView(this.calendar.activeDate,this.calendar.maxDate)}_updateLabels(){const t=this.calendar,a=this._intl,n=this._dateAdapter;t.currentView==="month"?(this._periodButtonText=n.format(t.activeDate,this._dateFormats.display.monthYearLabel).toLocaleUpperCase(),this._periodButtonDescription=n.format(t.activeDate,this._dateFormats.display.monthYearLabel).toLocaleUpperCase(),this._periodButtonLabel=a.switchToMultiYearViewLabel,this._prevButtonLabel=a.prevMonthLabel,this._nextButtonLabel=a.nextMonthLabel):t.currentView==="year"?(this._periodButtonText=n.getYearName(t.activeDate),this._periodButtonDescription=n.getYearName(t.activeDate),this._periodButtonLabel=a.switchToMonthViewLabel,this._prevButtonLabel=a.prevYearLabel,this._nextButtonLabel=a.nextYearLabel):(this._periodButtonText=a.formatYearRange(...this._formatMinAndMaxYearLabels()),this._periodButtonDescription=a.formatYearRangeLabel(...this._formatMinAndMaxYearLabels()),this._periodButtonLabel=a.switchToMonthViewLabel,this._prevButtonLabel=a.prevMultiYearLabel,this._nextButtonLabel=a.nextMultiYearLabel)}_isSameView(t,a){return this.calendar.currentView=="month"?this._dateAdapter.getYear(t)==this._dateAdapter.getYear(a)&&this._dateAdapter.getMonth(t)==this._dateAdapter.getMonth(a):this.calendar.currentView=="year"?this._dateAdapter.getYear(t)==this._dateAdapter.getYear(a):Ve(this._dateAdapter,t,a,this.calendar.minDate,this.calendar.maxDate)}_formatMinAndMaxYearLabels(){const a=this._dateAdapter.getYear(this.calendar.activeDate)-ae(this._dateAdapter,this.calendar.activeDate,this.calendar.minDate,this.calendar.maxDate),n=a+D-1,r=this._dateAdapter.getYearName(this._dateAdapter.createDate(a,0,1)),i=this._dateAdapter.getYearName(this._dateAdapter.createDate(n,0,1));return[r,i]}_periodButtonLabelId=(0,e.inject)(h._IdGenerator).getId("mat-calendar-period-label-");static \u0275fac=function(a){return new(a||N)};static \u0275cmp=e.\u0275\u0275defineComponent({type:N,selectors:[["mat-calendar-header"]],exportAs:["matCalendarHeader"],ngContentSelectors:Ee,decls:17,vars:13,consts:[[1,"mat-calendar-header"],[1,"mat-calendar-controls"],["aria-live","polite",1,"cdk-visually-hidden",3,"id"],["matButton","","type","button",1,"mat-calendar-period-button",3,"click"],["aria-hidden","true"],["viewBox","0 0 10 5","focusable","false","aria-hidden","true",1,"mat-calendar-arrow"],["points","0,0 5,5 10,0"],[1,"mat-calendar-spacer"],["matIconButton","","type","button","disabledInteractive","",1,"mat-calendar-previous-button",3,"click","disabled","matTooltip"],["viewBox","0 0 24 24","focusable","false","aria-hidden","true"],["d","M15.41 7.41L14 6l-6 6 6 6 1.41-1.41L10.83 12z"],["matIconButton","","type","button","disabledInteractive","",1,"mat-calendar-next-button",3,"click","disabled","matTooltip"],["d","M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"]],template:function(a,n){a&1&&(e.\u0275\u0275projectionDef(),e.\u0275\u0275elementStart(0,"div",0)(1,"div",1)(2,"span",2),e.\u0275\u0275text(3),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(4,"button",3),e.\u0275\u0275listener("click",function(){return n.currentPeriodClicked()}),e.\u0275\u0275elementStart(5,"span",4),e.\u0275\u0275text(6),e.\u0275\u0275elementEnd(),e.\u0275\u0275namespaceSVG(),e.\u0275\u0275elementStart(7,"svg",5),e.\u0275\u0275element(8,"polygon",6),e.\u0275\u0275elementEnd()(),e.\u0275\u0275namespaceHTML(),e.\u0275\u0275element(9,"div",7),e.\u0275\u0275projection(10),e.\u0275\u0275elementStart(11,"button",8),e.\u0275\u0275listener("click",function(){return n.previousClicked()}),e.\u0275\u0275namespaceSVG(),e.\u0275\u0275elementStart(12,"svg",9),e.\u0275\u0275element(13,"path",10),e.\u0275\u0275elementEnd()(),e.\u0275\u0275namespaceHTML(),e.\u0275\u0275elementStart(14,"button",11),e.\u0275\u0275listener("click",function(){return n.nextClicked()}),e.\u0275\u0275namespaceSVG(),e.\u0275\u0275elementStart(15,"svg",9),e.\u0275\u0275element(16,"path",12),e.\u0275\u0275elementEnd()()()()),a&2&&(e.\u0275\u0275advance(2),e.\u0275\u0275property("id",n._periodButtonLabelId),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate(n.periodButtonDescription),e.\u0275\u0275advance(),e.\u0275\u0275attribute("aria-label",n.periodButtonLabel)("aria-describedby",n._periodButtonLabelId),e.\u0275\u0275advance(2),e.\u0275\u0275textInterpolate(n.periodButtonText),e.\u0275\u0275advance(),e.\u0275\u0275classProp("mat-calendar-invert",n.calendar.currentView!=="month"),e.\u0275\u0275advance(4),e.\u0275\u0275property("disabled",!n.previousEnabled())("matTooltip",n.prevButtonLabel),e.\u0275\u0275attribute("aria-label",n.prevButtonLabel),e.\u0275\u0275advance(3),e.\u0275\u0275property("disabled",!n.nextEnabled())("matTooltip",n.nextButtonLabel),e.\u0275\u0275attribute("aria-label",n.nextButtonLabel))},dependencies:[q.MatButton,se.iY,Ce.oV],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(N,[{type:e.Component,args:[{selector:"mat-calendar-header",exportAs:"matCalendarHeader",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,imports:[q.MatButton,se.iY,Ce.oV],template:`<div class="mat-calendar-header">
  <div class="mat-calendar-controls">
    <!-- [Firefox Issue: https://bugzilla.mozilla.org/show_bug.cgi?id=1880533]
      Relocated label next to related button and made visually hidden via cdk-visually-hidden
      to enable label to appear in a11y tree for SR when using Firefox -->
    <span [id]="_periodButtonLabelId" class="cdk-visually-hidden" aria-live="polite">{{periodButtonDescription}}</span>
    <button matButton type="button" class="mat-calendar-period-button"
            (click)="currentPeriodClicked()" [attr.aria-label]="periodButtonLabel"
            [attr.aria-describedby]="_periodButtonLabelId">
      <span aria-hidden="true">{{periodButtonText}}</span>
      <svg class="mat-calendar-arrow" [class.mat-calendar-invert]="calendar.currentView !== 'month'"
           viewBox="0 0 10 5" focusable="false" aria-hidden="true">
           <polygon points="0,0 5,5 10,0"/>
      </svg>
    </button>

    <div class="mat-calendar-spacer"></div>

    <ng-content></ng-content>

    <button matIconButton type="button" class="mat-calendar-previous-button"
            [disabled]="!previousEnabled()" (click)="previousClicked()"
            [matTooltip]="prevButtonLabel" [attr.aria-label]="prevButtonLabel" disabledInteractive>
      <svg viewBox="0 0 24 24" focusable="false" aria-hidden="true">
        <path d="M15.41 7.41L14 6l-6 6 6 6 1.41-1.41L10.83 12z"/>
       </svg>
    </button>

    <button matIconButton type="button" class="mat-calendar-next-button"
            [disabled]="!nextEnabled()" (click)="nextClicked()"
            [matTooltip]="nextButtonLabel" [attr.aria-label]="nextButtonLabel" disabledInteractive>
      <svg viewBox="0 0 24 24" focusable="false" aria-hidden="true">
        <path d="M10 6L8.59 7.41 13.17 12l-4.58 4.59L10 18l6-6z"/>
      </svg>
    </button>
  </div>
</div>
`}]}],()=>[],null);class M{_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_dateFormats=(0,e.inject)(p.de,{optional:!0});_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_elementRef=(0,e.inject)(e.ElementRef);headerComponent;_calendarHeaderPortal;_intlChanges;_moveFocusOnNextTick=!1;get startAt(){return this._startAt}set startAt(t){this._startAt=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_startAt=null;startView="month";get selected(){return this._selected}set selected(t){t instanceof f?this._selected=t:this._selected=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_selected=null;get minDate(){return this._minDate}set minDate(t){this._minDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_minDate=null;get maxDate(){return this._maxDate}set maxDate(t){this._maxDate=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_maxDate=null;dateFilter;dateClass;comparisonStart=null;comparisonEnd=null;startDateAccessibleName=null;endDateAccessibleName=null;selectedChange=new e.EventEmitter;yearSelected=new e.EventEmitter;monthSelected=new e.EventEmitter;viewChanged=new e.EventEmitter(!0);_userSelection=new e.EventEmitter;_userDragDrop=new e.EventEmitter;monthView;yearView;multiYearView;get activeDate(){return this._clampedActiveDate}set activeDate(t){this._clampedActiveDate=this._dateAdapter.clampDate(t,this.minDate,this.maxDate),this.stateChanges.next(),this._changeDetectorRef.markForCheck()}_clampedActiveDate;get currentView(){return this._currentView}set currentView(t){const a=this._currentView!==t?t:null;this._currentView=t,this._moveFocusOnNextTick=!0,this._changeDetectorRef.markForCheck(),a&&(this.stateChanges.next(),this.viewChanged.emit(a))}_currentView;_activeDrag=null;stateChanges=new m.Subject;constructor(){if(typeof ngDevMode>"u"||ngDevMode){if(!this._dateAdapter)throw S("DateAdapter");if(!this._dateFormats)throw S("MAT_DATE_FORMATS")}this._intlChanges=(0,e.inject)(C).changes.subscribe(()=>{this._changeDetectorRef.markForCheck(),this.stateChanges.next()})}ngAfterContentInit(){this._calendarHeaderPortal=new g.ComponentPortal(this.headerComponent||N),this.activeDate=this.startAt||this._dateAdapter.today(),this._currentView=this.startView}ngAfterViewChecked(){this._moveFocusOnNextTick&&(this._moveFocusOnNextTick=!1,this.focusActiveCell())}ngOnDestroy(){this._intlChanges.unsubscribe(),this.stateChanges.complete()}ngOnChanges(t){const a=t.minDate&&!this._dateAdapter.sameDate(t.minDate.previousValue,t.minDate.currentValue)?t.minDate:void 0,n=t.maxDate&&!this._dateAdapter.sameDate(t.maxDate.previousValue,t.maxDate.currentValue)?t.maxDate:void 0,r=a||n||t.dateFilter;if(r&&!r.firstChange){const i=this._getCurrentViewComponent();i&&(this._elementRef.nativeElement.contains((0,u._getFocusedElementPierceShadowDom)())&&(this._moveFocusOnNextTick=!0),this._changeDetectorRef.detectChanges(),i._init())}this.stateChanges.next()}focusActiveCell(){this._getCurrentViewComponent()?._focusActiveCell(!1)}updateTodaysDate(){this._getCurrentViewComponent()?._init()}_dateSelected(t){const a=t.value;(this.selected instanceof f||a&&!this._dateAdapter.sameDate(a,this.selected))&&this.selectedChange.emit(a),this._userSelection.emit(t)}_yearSelectedInMultiYearView(t){this.yearSelected.emit(t)}_monthSelectedInYearView(t){this.monthSelected.emit(t)}_goToDateInView(t,a){this.activeDate=t,this.currentView=a}_dragStarted(t){this._activeDrag=t}_dragEnded(t){this._activeDrag&&(t.value&&this._userDragDrop.emit(t),this._activeDrag=null)}_getCurrentViewComponent(){return this.monthView||this.yearView||this.multiYearView}static \u0275fac=function(a){return new(a||M)};static \u0275cmp=e.\u0275\u0275defineComponent({type:M,selectors:[["mat-calendar"]],viewQuery:function(a,n){if(a&1&&e.\u0275\u0275viewQuery(I,5)(R,5)(V,5),a&2){let r;e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n.monthView=r.first),e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n.yearView=r.first),e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n.multiYearView=r.first)}},hostAttrs:[1,"mat-calendar"],inputs:{headerComponent:"headerComponent",startAt:"startAt",startView:"startView",selected:"selected",minDate:"minDate",maxDate:"maxDate",dateFilter:"dateFilter",dateClass:"dateClass",comparisonStart:"comparisonStart",comparisonEnd:"comparisonEnd",startDateAccessibleName:"startDateAccessibleName",endDateAccessibleName:"endDateAccessibleName"},outputs:{selectedChange:"selectedChange",yearSelected:"yearSelected",monthSelected:"monthSelected",viewChanged:"viewChanged",_userSelection:"_userSelection",_userDragDrop:"_userDragDrop"},exportAs:["matCalendar"],features:[e.\u0275\u0275ProvidersFeature([ce]),e.\u0275\u0275NgOnChangesFeature],decls:5,vars:2,consts:[[3,"cdkPortalOutlet"],["cdkMonitorSubtreeFocus","","tabindex","-1",1,"mat-calendar-content"],[3,"activeDate","selected","dateFilter","maxDate","minDate","dateClass","comparisonStart","comparisonEnd","startDateAccessibleName","endDateAccessibleName","activeDrag"],[3,"activeDate","selected","dateFilter","maxDate","minDate","dateClass"],[3,"activeDateChange","_userSelection","dragStarted","dragEnded","activeDate","selected","dateFilter","maxDate","minDate","dateClass","comparisonStart","comparisonEnd","startDateAccessibleName","endDateAccessibleName","activeDrag"],[3,"activeDateChange","monthSelected","selectedChange","activeDate","selected","dateFilter","maxDate","minDate","dateClass"],[3,"activeDateChange","yearSelected","selectedChange","activeDate","selected","dateFilter","maxDate","minDate","dateClass"]],template:function(a,n){if(a&1&&(e.\u0275\u0275template(0,Ue,0,0,"ng-template",0),e.\u0275\u0275elementStart(1,"div",1),e.\u0275\u0275conditionalCreate(2,$e,1,11,"mat-month-view",2)(3,Ge,1,6,"mat-year-view",3)(4,Qe,1,6,"mat-multi-year-view",3),e.\u0275\u0275elementEnd()),a&2){let r;e.\u0275\u0275property("cdkPortalOutlet",n._calendarHeaderPortal),e.\u0275\u0275advance(2),e.\u0275\u0275conditional((r=n.currentView)==="month"?2:r==="year"?3:r==="multi-year"?4:-1)}},dependencies:[g.CdkPortalOutlet,h.CdkMonitorFocus,I,R,V],styles:[`.mat-calendar {
  display: block;
  line-height: normal;
  font-family: var(--mat-datepicker-calendar-text-font, var(--mat-sys-body-medium-font));
  font-size: var(--mat-datepicker-calendar-text-size, var(--mat-sys-body-medium-size));
}

.mat-calendar-header {
  padding: 8px 8px 0 8px;
}

.mat-calendar-content {
  padding: 0 8px 8px 8px;
  outline: none;
}

.mat-calendar-controls {
  display: flex;
  align-items: center;
  margin: 5% calc(4.7142857143% - 16px);
}

.mat-calendar-spacer {
  flex: 1 1 auto;
}

.mat-calendar-period-button {
  min-width: 0;
  margin: 0 8px;
  font-size: var(--mat-datepicker-calendar-period-button-text-size, var(--mat-sys-title-small-size));
  font-weight: var(--mat-datepicker-calendar-period-button-text-weight, var(--mat-sys-title-small-weight));
  --mat-button-text-label-text-color: var(--mat-datepicker-calendar-period-button-text-color, var(--mat-sys-on-surface-variant));
}

.mat-calendar-arrow {
  display: inline-block;
  width: 10px;
  height: 5px;
  margin: 0 0 0 5px;
  vertical-align: middle;
  fill: var(--mat-datepicker-calendar-period-button-icon-color, var(--mat-sys-on-surface-variant));
}
.mat-calendar-arrow.mat-calendar-invert {
  transform: rotate(180deg);
}
[dir=rtl] .mat-calendar-arrow {
  margin: 0 5px 0 0;
}
@media (forced-colors: active) {
  .mat-calendar-arrow {
    fill: CanvasText;
  }
}

.mat-datepicker-content .mat-calendar-previous-button:not(.mat-mdc-button-disabled),
.mat-datepicker-content .mat-calendar-next-button:not(.mat-mdc-button-disabled) {
  color: var(--mat-datepicker-calendar-navigation-button-icon-color, var(--mat-sys-on-surface-variant));
}
[dir=rtl] .mat-calendar-previous-button,
[dir=rtl] .mat-calendar-next-button {
  transform: rotate(180deg);
}

.mat-calendar-table {
  border-spacing: 0;
  border-collapse: collapse;
  width: 100%;
}

.mat-calendar-table-header th {
  text-align: center;
  padding: 0 0 8px 0;
  color: var(--mat-datepicker-calendar-header-text-color, var(--mat-sys-on-surface-variant));
  font-size: var(--mat-datepicker-calendar-header-text-size, var(--mat-sys-title-small-size));
  font-weight: var(--mat-datepicker-calendar-header-text-weight, var(--mat-sys-title-small-weight));
}

.mat-calendar-table-header-divider {
  position: relative;
  height: 1px;
}
.mat-calendar-table-header-divider::after {
  content: "";
  position: absolute;
  top: 0;
  left: -8px;
  right: -8px;
  height: 1px;
  background: var(--mat-datepicker-calendar-header-divider-color, transparent);
}

.mat-calendar-body-cell-content::before {
  margin: calc(calc(var(--mat-focus-indicator-border-width, 3px) + 3px) * -1);
}

.mat-calendar-body-cell:focus-visible .mat-focus-indicator::before {
  content: "";
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(M,[{type:e.Component,args:[{selector:"mat-calendar",host:{class:"mat-calendar"},exportAs:"matCalendar",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,providers:[ce],imports:[g.CdkPortalOutlet,h.CdkMonitorFocus,I,R,V],template:`<ng-template [cdkPortalOutlet]="_calendarHeaderPortal"></ng-template>

<div class="mat-calendar-content" cdkMonitorSubtreeFocus tabindex="-1">
  @switch (currentView) {
    @case ('month') {
        <mat-month-view
            [(activeDate)]="activeDate"
            [selected]="selected"
            [dateFilter]="dateFilter"
            [maxDate]="maxDate"
            [minDate]="minDate"
            [dateClass]="dateClass"
            [comparisonStart]="comparisonStart"
            [comparisonEnd]="comparisonEnd"
            [startDateAccessibleName]="startDateAccessibleName"
            [endDateAccessibleName]="endDateAccessibleName"
            (_userSelection)="_dateSelected($event)"
            (dragStarted)="_dragStarted($event)"
            (dragEnded)="_dragEnded($event)"
            [activeDrag]="_activeDrag"></mat-month-view>
    }

    @case ('year') {
        <mat-year-view
            [(activeDate)]="activeDate"
            [selected]="selected"
            [dateFilter]="dateFilter"
            [maxDate]="maxDate"
            [minDate]="minDate"
            [dateClass]="dateClass"
            (monthSelected)="_monthSelectedInYearView($event)"
            (selectedChange)="_goToDateInView($event, 'month')"></mat-year-view>
    }

    @case ('multi-year') {
        <mat-multi-year-view
            [(activeDate)]="activeDate"
            [selected]="selected"
            [dateFilter]="dateFilter"
            [maxDate]="maxDate"
            [minDate]="minDate"
            [dateClass]="dateClass"
            (yearSelected)="_yearSelectedInMultiYearView($event)"
            (selectedChange)="_goToDateInView($event, 'year')"></mat-multi-year-view>
    }
  }
</div>
`,styles:[`.mat-calendar {
  display: block;
  line-height: normal;
  font-family: var(--mat-datepicker-calendar-text-font, var(--mat-sys-body-medium-font));
  font-size: var(--mat-datepicker-calendar-text-size, var(--mat-sys-body-medium-size));
}

.mat-calendar-header {
  padding: 8px 8px 0 8px;
}

.mat-calendar-content {
  padding: 0 8px 8px 8px;
  outline: none;
}

.mat-calendar-controls {
  display: flex;
  align-items: center;
  margin: 5% calc(4.7142857143% - 16px);
}

.mat-calendar-spacer {
  flex: 1 1 auto;
}

.mat-calendar-period-button {
  min-width: 0;
  margin: 0 8px;
  font-size: var(--mat-datepicker-calendar-period-button-text-size, var(--mat-sys-title-small-size));
  font-weight: var(--mat-datepicker-calendar-period-button-text-weight, var(--mat-sys-title-small-weight));
  --mat-button-text-label-text-color: var(--mat-datepicker-calendar-period-button-text-color, var(--mat-sys-on-surface-variant));
}

.mat-calendar-arrow {
  display: inline-block;
  width: 10px;
  height: 5px;
  margin: 0 0 0 5px;
  vertical-align: middle;
  fill: var(--mat-datepicker-calendar-period-button-icon-color, var(--mat-sys-on-surface-variant));
}
.mat-calendar-arrow.mat-calendar-invert {
  transform: rotate(180deg);
}
[dir=rtl] .mat-calendar-arrow {
  margin: 0 5px 0 0;
}
@media (forced-colors: active) {
  .mat-calendar-arrow {
    fill: CanvasText;
  }
}

.mat-datepicker-content .mat-calendar-previous-button:not(.mat-mdc-button-disabled),
.mat-datepicker-content .mat-calendar-next-button:not(.mat-mdc-button-disabled) {
  color: var(--mat-datepicker-calendar-navigation-button-icon-color, var(--mat-sys-on-surface-variant));
}
[dir=rtl] .mat-calendar-previous-button,
[dir=rtl] .mat-calendar-next-button {
  transform: rotate(180deg);
}

.mat-calendar-table {
  border-spacing: 0;
  border-collapse: collapse;
  width: 100%;
}

.mat-calendar-table-header th {
  text-align: center;
  padding: 0 0 8px 0;
  color: var(--mat-datepicker-calendar-header-text-color, var(--mat-sys-on-surface-variant));
  font-size: var(--mat-datepicker-calendar-header-text-size, var(--mat-sys-title-small-size));
  font-weight: var(--mat-datepicker-calendar-header-text-weight, var(--mat-sys-title-small-weight));
}

.mat-calendar-table-header-divider {
  position: relative;
  height: 1px;
}
.mat-calendar-table-header-divider::after {
  content: "";
  position: absolute;
  top: 0;
  left: -8px;
  right: -8px;
  height: 1px;
  background: var(--mat-datepicker-calendar-header-divider-color, transparent);
}

.mat-calendar-body-cell-content::before {
  margin: calc(calc(var(--mat-focus-indicator-border-width, 3px) + 3px) * -1);
}

.mat-calendar-body-cell:focus-visible .mat-focus-indicator::before {
  content: "";
}
`]}]}],()=>[],{headerComponent:[{type:e.Input}],startAt:[{type:e.Input}],startView:[{type:e.Input}],selected:[{type:e.Input}],minDate:[{type:e.Input}],maxDate:[{type:e.Input}],dateFilter:[{type:e.Input}],dateClass:[{type:e.Input}],comparisonStart:[{type:e.Input}],comparisonEnd:[{type:e.Input}],startDateAccessibleName:[{type:e.Input}],endDateAccessibleName:[{type:e.Input}],selectedChange:[{type:e.Output}],yearSelected:[{type:e.Output}],monthSelected:[{type:e.Output}],viewChanged:[{type:e.Output}],_userSelection:[{type:e.Output}],_userDragDrop:[{type:e.Output}],monthView:[{type:e.ViewChild,args:[I]}],yearView:[{type:e.ViewChild,args:[R]}],multiYearView:[{type:e.ViewChild,args:[V]}]});const Oe=new e.InjectionToken("mat-datepicker-scroll-strategy",{providedIn:"root",factory:()=>{const s=(0,e.inject)(e.Injector);return()=>(0,d.createRepositionScrollStrategy)(s)}});class B{_elementRef=(0,e.inject)(e.ElementRef);_animationsDisabled=(0,we.Rc)();_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_globalModel=(0,e.inject)(w);_dateAdapter=(0,e.inject)(p.MJ);_ngZone=(0,e.inject)(e.NgZone);_rangeSelectionStrategy=(0,e.inject)($,{optional:!0});_stateChanges;_model;_eventCleanups;_animationFallback;_calendar;color;datepicker;comparisonStart=null;comparisonEnd=null;startDateAccessibleName=null;endDateAccessibleName=null;_isAbove=!1;_animationDone=new m.Subject;_isAnimating=!1;_closeButtonText;_closeButtonFocused=!1;_actionsPortal=null;_dialogLabelId=null;constructor(){if((0,e.inject)(U._CdkPrivateStyleLoader).load(U._VisuallyHiddenLoader),this._closeButtonText=(0,e.inject)(C).closeCalendarLabel,!this._animationsDisabled){const t=this._elementRef.nativeElement,a=(0,e.inject)(e.Renderer2);this._eventCleanups=this._ngZone.runOutsideAngular(()=>[a.listen(t,"animationstart",this._handleAnimationEvent),a.listen(t,"animationend",this._handleAnimationEvent),a.listen(t,"animationcancel",this._handleAnimationEvent)])}}ngAfterViewInit(){this._stateChanges=this.datepicker.stateChanges.subscribe(()=>{this._changeDetectorRef.markForCheck()}),this._calendar.focusActiveCell()}ngOnDestroy(){clearTimeout(this._animationFallback),this._eventCleanups?.forEach(t=>t()),this._stateChanges?.unsubscribe(),this._animationDone.complete()}_handleUserSelection(t){const a=this._model.selection,n=t.value,r=a instanceof f;if(r&&this._rangeSelectionStrategy){const i=this._rangeSelectionStrategy.selectionFinished(n,a,t.event);this._model.updateSelection(i,this)}else n&&(r||!this._dateAdapter.sameDate(n,a))&&this._model.add(n);(!this._model||this._model.isComplete())&&!this._actionsPortal&&this.datepicker.close()}_handleUserDragDrop(t){this._model.updateSelection(t.value,this)}_startExitAnimation(){this._elementRef.nativeElement.classList.add("mat-datepicker-content-exit"),this._animationsDisabled?this._animationDone.next():(clearTimeout(this._animationFallback),this._animationFallback=setTimeout(()=>{this._isAnimating||this._animationDone.next()},200))}_handleAnimationEvent=t=>{const a=this._elementRef.nativeElement;t.target!==a||!t.animationName.startsWith("_mat-datepicker-content")||(clearTimeout(this._animationFallback),this._isAnimating=t.type==="animationstart",a.classList.toggle("mat-datepicker-content-animating",this._isAnimating),this._isAnimating||this._animationDone.next())};_getSelected(){return this._model.selection}_applyPendingSelection(){this._model!==this._globalModel&&this._globalModel.updateSelection(this._model.selection,this)}_assignActions(t,a){this._model=t?this._globalModel.clone():this._globalModel,this._actionsPortal=t,a&&this._changeDetectorRef.detectChanges()}static \u0275fac=function(a){return new(a||B)};static \u0275cmp=e.\u0275\u0275defineComponent({type:B,selectors:[["mat-datepicker-content"]],viewQuery:function(a,n){if(a&1&&e.\u0275\u0275viewQuery(M,5),a&2){let r;e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n._calendar=r.first)}},hostAttrs:[1,"mat-datepicker-content"],hostVars:6,hostBindings:function(a,n){a&2&&(e.\u0275\u0275classMap(n.color?"mat-"+n.color:""),e.\u0275\u0275classProp("mat-datepicker-content-touch",n.datepicker.touchUi)("mat-datepicker-content-animations-enabled",!n._animationsDisabled))},inputs:{color:"color"},exportAs:["matDatepickerContent"],decls:5,vars:26,consts:[["cdkTrapFocus","","role","dialog",1,"mat-datepicker-content-container"],[3,"yearSelected","monthSelected","viewChanged","_userSelection","_userDragDrop","id","startAt","startView","minDate","maxDate","dateFilter","headerComponent","selected","dateClass","comparisonStart","comparisonEnd","startDateAccessibleName","endDateAccessibleName"],[3,"cdkPortalOutlet"],["type","button","matButton","elevated",1,"mat-datepicker-close-button",3,"focus","blur","click","color"]],template:function(a,n){a&1&&(e.\u0275\u0275elementStart(0,"div",0)(1,"mat-calendar",1),e.\u0275\u0275listener("yearSelected",function(i){return n.datepicker._selectYear(i)})("monthSelected",function(i){return n.datepicker._selectMonth(i)})("viewChanged",function(i){return n.datepicker._viewChanged(i)})("_userSelection",function(i){return n._handleUserSelection(i)})("_userDragDrop",function(i){return n._handleUserDragDrop(i)}),e.\u0275\u0275elementEnd(),e.\u0275\u0275template(2,Je,0,0,"ng-template",2),e.\u0275\u0275elementStart(3,"button",3),e.\u0275\u0275listener("focus",function(){return n._closeButtonFocused=!0})("blur",function(){return n._closeButtonFocused=!1})("click",function(){return n.datepicker.close()}),e.\u0275\u0275text(4),e.\u0275\u0275elementEnd()()),a&2&&(e.\u0275\u0275classProp("mat-datepicker-content-container-with-custom-header",n.datepicker.calendarHeaderComponent)("mat-datepicker-content-container-with-actions",n._actionsPortal),e.\u0275\u0275attribute("aria-modal",!0)("aria-labelledby",n._dialogLabelId??void 0),e.\u0275\u0275advance(),e.\u0275\u0275classMap(n.datepicker.panelClass),e.\u0275\u0275property("id",n.datepicker.id)("startAt",n.datepicker.startAt)("startView",n.datepicker.startView)("minDate",n.datepicker._getMinDate())("maxDate",n.datepicker._getMaxDate())("dateFilter",n.datepicker._getDateFilter())("headerComponent",n.datepicker.calendarHeaderComponent)("selected",n._getSelected())("dateClass",n.datepicker.dateClass)("comparisonStart",n.comparisonStart)("comparisonEnd",n.comparisonEnd)("startDateAccessibleName",n.startDateAccessibleName)("endDateAccessibleName",n.endDateAccessibleName),e.\u0275\u0275advance(),e.\u0275\u0275property("cdkPortalOutlet",n._actionsPortal),e.\u0275\u0275advance(),e.\u0275\u0275classProp("cdk-visually-hidden",!n._closeButtonFocused),e.\u0275\u0275property("color",n.color||"primary"),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate(n._closeButtonText))},dependencies:[h.CdkTrapFocus,M,g.CdkPortalOutlet,q.MatButton],styles:[`@keyframes _mat-datepicker-content-dropdown-enter {
  from {
    opacity: 0;
    transform: scaleY(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-datepicker-content-dialog-enter {
  from {
    opacity: 0;
    transform: scale(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-datepicker-content-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-datepicker-content {
  display: block;
  background-color: var(--mat-datepicker-calendar-container-background-color, var(--mat-sys-surface-container-high));
  color: var(--mat-datepicker-calendar-container-text-color, var(--mat-sys-on-surface));
  box-shadow: var(--mat-datepicker-calendar-container-elevation-shadow, 0px 0px 0px 0px rgba(0, 0, 0, 0.2), 0px 0px 0px 0px rgba(0, 0, 0, 0.14), 0px 0px 0px 0px rgba(0, 0, 0, 0.12));
  border-radius: var(--mat-datepicker-calendar-container-shape, var(--mat-sys-corner-large));
}
.mat-datepicker-content.mat-datepicker-content-animations-enabled {
  animation: _mat-datepicker-content-dropdown-enter 120ms cubic-bezier(0, 0, 0.2, 1);
}
.mat-datepicker-content .mat-calendar {
  width: 296px;
  height: 354px;
}
.mat-datepicker-content .mat-datepicker-content-container-with-custom-header .mat-calendar {
  height: auto;
}
.mat-datepicker-content .mat-datepicker-close-button {
  position: absolute;
  top: 100%;
  left: 0;
  margin-top: 8px;
}
.mat-datepicker-content-animating .mat-datepicker-content .mat-datepicker-close-button {
  display: none;
}

.mat-datepicker-content-container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.mat-datepicker-content-touch {
  display: block;
  max-height: 80vh;
  box-shadow: var(--mat-datepicker-calendar-container-touch-elevation-shadow, 0px 0px 0px 0px rgba(0, 0, 0, 0.2), 0px 0px 0px 0px rgba(0, 0, 0, 0.14), 0px 0px 0px 0px rgba(0, 0, 0, 0.12));
  border-radius: var(--mat-datepicker-calendar-container-touch-shape, var(--mat-sys-corner-extra-large));
  position: relative;
  overflow: visible;
  min-height: fit-content;
}
.mat-datepicker-content-touch.mat-datepicker-content-animations-enabled {
  animation: _mat-datepicker-content-dialog-enter 150ms cubic-bezier(0, 0, 0.2, 1);
}
.mat-datepicker-content-touch .mat-datepicker-content-container {
  min-height: 312px;
  max-height: 788px;
  min-width: 250px;
  max-width: 750px;
}
.mat-datepicker-content-touch .mat-calendar {
  width: 100%;
  height: auto;
}

.mat-datepicker-content-exit.mat-datepicker-content-animations-enabled {
  animation: _mat-datepicker-content-exit 100ms linear;
}

@media all and (orientation: landscape) {
  .mat-datepicker-content-touch .mat-datepicker-content-container {
    width: 64vh;
    height: 80vh;
  }
}
@media all and (orientation: portrait) {
  .mat-datepicker-content-touch .mat-datepicker-content-container {
    width: 80vw;
    height: 100vw;
  }
  .mat-datepicker-content-touch .mat-datepicker-content-container-with-actions {
    height: 115vw;
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(B,[{type:e.Component,args:[{selector:"mat-datepicker-content",host:{class:"mat-datepicker-content","[class]":'color ? "mat-" + color : ""',"[class.mat-datepicker-content-touch]":"datepicker.touchUi","[class.mat-datepicker-content-animations-enabled]":"!_animationsDisabled"},exportAs:"matDatepickerContent",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,imports:[h.CdkTrapFocus,M,g.CdkPortalOutlet,q.MatButton],template:`<div
  cdkTrapFocus
  role="dialog"
  [attr.aria-modal]="true"
  [attr.aria-labelledby]="_dialogLabelId ?? undefined"
  class="mat-datepicker-content-container"
  [class.mat-datepicker-content-container-with-custom-header]="datepicker.calendarHeaderComponent"
  [class.mat-datepicker-content-container-with-actions]="_actionsPortal">
  <mat-calendar
    [id]="datepicker.id"
    [class]="datepicker.panelClass"
    [startAt]="datepicker.startAt"
    [startView]="datepicker.startView"
    [minDate]="datepicker._getMinDate()"
    [maxDate]="datepicker._getMaxDate()"
    [dateFilter]="datepicker._getDateFilter()"
    [headerComponent]="datepicker.calendarHeaderComponent"
    [selected]="_getSelected()"
    [dateClass]="datepicker.dateClass"
    [comparisonStart]="comparisonStart"
    [comparisonEnd]="comparisonEnd"
    [startDateAccessibleName]="startDateAccessibleName"
    [endDateAccessibleName]="endDateAccessibleName"
    (yearSelected)="datepicker._selectYear($event)"
    (monthSelected)="datepicker._selectMonth($event)"
    (viewChanged)="datepicker._viewChanged($event)"
    (_userSelection)="_handleUserSelection($event)"
    (_userDragDrop)="_handleUserDragDrop($event)"></mat-calendar>

  <ng-template [cdkPortalOutlet]="_actionsPortal"></ng-template>

  <!-- Invisible close button for screen reader users. -->
  <button
    type="button"
    matButton="elevated"
    [color]="color || 'primary'"
    class="mat-datepicker-close-button"
    [class.cdk-visually-hidden]="!_closeButtonFocused"
    (focus)="_closeButtonFocused = true"
    (blur)="_closeButtonFocused = false"
    (click)="datepicker.close()">{{ _closeButtonText }}</button>
</div>
`,styles:[`@keyframes _mat-datepicker-content-dropdown-enter {
  from {
    opacity: 0;
    transform: scaleY(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-datepicker-content-dialog-enter {
  from {
    opacity: 0;
    transform: scale(0.8);
  }
  to {
    opacity: 1;
    transform: none;
  }
}
@keyframes _mat-datepicker-content-exit {
  from {
    opacity: 1;
  }
  to {
    opacity: 0;
  }
}
.mat-datepicker-content {
  display: block;
  background-color: var(--mat-datepicker-calendar-container-background-color, var(--mat-sys-surface-container-high));
  color: var(--mat-datepicker-calendar-container-text-color, var(--mat-sys-on-surface));
  box-shadow: var(--mat-datepicker-calendar-container-elevation-shadow, 0px 0px 0px 0px rgba(0, 0, 0, 0.2), 0px 0px 0px 0px rgba(0, 0, 0, 0.14), 0px 0px 0px 0px rgba(0, 0, 0, 0.12));
  border-radius: var(--mat-datepicker-calendar-container-shape, var(--mat-sys-corner-large));
}
.mat-datepicker-content.mat-datepicker-content-animations-enabled {
  animation: _mat-datepicker-content-dropdown-enter 120ms cubic-bezier(0, 0, 0.2, 1);
}
.mat-datepicker-content .mat-calendar {
  width: 296px;
  height: 354px;
}
.mat-datepicker-content .mat-datepicker-content-container-with-custom-header .mat-calendar {
  height: auto;
}
.mat-datepicker-content .mat-datepicker-close-button {
  position: absolute;
  top: 100%;
  left: 0;
  margin-top: 8px;
}
.mat-datepicker-content-animating .mat-datepicker-content .mat-datepicker-close-button {
  display: none;
}

.mat-datepicker-content-container {
  display: flex;
  flex-direction: column;
  justify-content: space-between;
}

.mat-datepicker-content-touch {
  display: block;
  max-height: 80vh;
  box-shadow: var(--mat-datepicker-calendar-container-touch-elevation-shadow, 0px 0px 0px 0px rgba(0, 0, 0, 0.2), 0px 0px 0px 0px rgba(0, 0, 0, 0.14), 0px 0px 0px 0px rgba(0, 0, 0, 0.12));
  border-radius: var(--mat-datepicker-calendar-container-touch-shape, var(--mat-sys-corner-extra-large));
  position: relative;
  overflow: visible;
  min-height: fit-content;
}
.mat-datepicker-content-touch.mat-datepicker-content-animations-enabled {
  animation: _mat-datepicker-content-dialog-enter 150ms cubic-bezier(0, 0, 0.2, 1);
}
.mat-datepicker-content-touch .mat-datepicker-content-container {
  min-height: 312px;
  max-height: 788px;
  min-width: 250px;
  max-width: 750px;
}
.mat-datepicker-content-touch .mat-calendar {
  width: 100%;
  height: auto;
}

.mat-datepicker-content-exit.mat-datepicker-content-animations-enabled {
  animation: _mat-datepicker-content-exit 100ms linear;
}

@media all and (orientation: landscape) {
  .mat-datepicker-content-touch .mat-datepicker-content-container {
    width: 64vh;
    height: 80vh;
  }
}
@media all and (orientation: portrait) {
  .mat-datepicker-content-touch .mat-datepicker-content-container {
    width: 80vw;
    height: 100vw;
  }
  .mat-datepicker-content-touch .mat-datepicker-content-container-with-actions {
    height: 115vw;
  }
}
`]}]}],()=>[],{_calendar:[{type:e.ViewChild,args:[M]}],color:[{type:e.Input}]});class k{_injector=(0,e.inject)(e.Injector);_viewContainerRef=(0,e.inject)(e.ViewContainerRef);_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_dir=(0,e.inject)(_.Directionality,{optional:!0});_model=(0,e.inject)(w);_animationsDisabled=(0,we.Rc)();_scrollStrategy=(0,e.inject)(Oe);_inputStateChanges=m.Subscription.EMPTY;_document=(0,e.inject)(e.DOCUMENT);calendarHeaderComponent;get startAt(){return this._startAt||(this.datepickerInput?this.datepickerInput.getStartValue():null)}set startAt(t){this._startAt=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t))}_startAt=null;startView="month";get color(){return this._color||(this.datepickerInput?this.datepickerInput.getThemePalette():void 0)}set color(t){this._color=t}_color;touchUi=!1;get disabled(){return this._disabled===void 0&&this.datepickerInput?this.datepickerInput.disabled:!!this._disabled}set disabled(t){t!==this._disabled&&(this._disabled=t,this.stateChanges.next(void 0))}_disabled;xPosition="start";yPosition="below";restoreFocus=!0;yearSelected=new e.EventEmitter;monthSelected=new e.EventEmitter;viewChanged=new e.EventEmitter(!0);dateClass;openedStream=new e.EventEmitter;closedStream=new e.EventEmitter;get panelClass(){return this._panelClass}set panelClass(t){this._panelClass=(0,v.coerceStringArray)(t)}_panelClass;get opened(){return this._opened}set opened(t){t?this.open():this.close()}_opened=!1;id=(0,e.inject)(h._IdGenerator).getId("mat-datepicker-");_getMinDate(){return this.datepickerInput&&this.datepickerInput.min}_getMaxDate(){return this.datepickerInput&&this.datepickerInput.max}_getDateFilter(){return this.datepickerInput&&this.datepickerInput.dateFilter}_overlayRef=null;_componentRef=null;_focusedElementBeforeOpen=null;_backdropHarnessClass=`${this.id}-backdrop`;_actionsPortal=null;datepickerInput;stateChanges=new m.Subject;_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);constructor(){if(!this._dateAdapter&&(typeof ngDevMode>"u"||ngDevMode))throw S("DateAdapter");this._model.selectionChanged.subscribe(()=>{this._changeDetectorRef.markForCheck()})}ngOnChanges(t){const a=t.xPosition||t.yPosition;if(a&&!a.firstChange&&this._overlayRef){const n=this._overlayRef.getConfig().positionStrategy;n instanceof d.FlexibleConnectedPositionStrategy&&(this._setConnectedPositions(n),this.opened&&this._overlayRef.updatePosition())}this.stateChanges.next(void 0)}ngOnDestroy(){this._destroyOverlay(),this.close(),this._inputStateChanges.unsubscribe(),this.stateChanges.complete()}select(t){this._model.add(t)}_selectYear(t){this.yearSelected.emit(t)}_selectMonth(t){this.monthSelected.emit(t)}_viewChanged(t){this.viewChanged.emit(t)}registerInput(t){if(this.datepickerInput&&(typeof ngDevMode>"u"||ngDevMode))throw Error("A MatDatepicker can only be associated with a single input.");return this._inputStateChanges.unsubscribe(),this.datepickerInput=t,this._inputStateChanges=t.stateChanges.subscribe(()=>this.stateChanges.next(void 0)),this._model}registerActions(t){if(this._actionsPortal&&(typeof ngDevMode>"u"||ngDevMode))throw Error("A MatDatepicker can only be associated with a single actions row.");this._actionsPortal=t,this._componentRef?.instance._assignActions(t,!0)}removeActions(t){t===this._actionsPortal&&(this._actionsPortal=null,this._componentRef?.instance._assignActions(null,!0))}open(){if(!(this._opened||this.disabled||this._componentRef?.instance._isAnimating)){if(!this.datepickerInput&&(typeof ngDevMode>"u"||ngDevMode))throw Error("Attempted to open an MatDatepicker with no associated input.");this._focusedElementBeforeOpen=(0,u._getFocusedElementPierceShadowDom)(),this._openOverlay(),this._opened=!0,this.openedStream.emit()}}close(){if(!this._opened||this._componentRef?.instance._isAnimating)return;const t=this.restoreFocus&&this._focusedElementBeforeOpen&&typeof this._focusedElementBeforeOpen.focus=="function",a=()=>{this._opened&&(this._opened=!1,this.closedStream.emit())};if(this._componentRef){const{instance:n,location:r}=this._componentRef;n._animationDone.pipe((0,A.take)(1)).subscribe(()=>{const i=this._document.activeElement;t&&(!i||i===this._document.activeElement||r.nativeElement.contains(i))&&this._focusedElementBeforeOpen.focus(),this._focusedElementBeforeOpen=null,this._destroyOverlay()}),n._startExitAnimation()}t?setTimeout(a):a()}_applyPendingSelection(){this._componentRef?.instance?._applyPendingSelection()}_forwardContentValues(t){t.datepicker=this,t.color=this.color,t._dialogLabelId=this.datepickerInput.getOverlayLabelId(),t._assignActions(this._actionsPortal,!1)}_openOverlay(){this._destroyOverlay();const t=this.touchUi,a=new g.ComponentPortal(B,this._viewContainerRef),n=this._overlayRef=(0,d.createOverlayRef)(this._injector,new d.OverlayConfig({positionStrategy:t?this._getDialogStrategy():this._getDropdownStrategy(),hasBackdrop:!0,backdropClass:[t?"cdk-overlay-dark-backdrop":"mat-overlay-transparent-backdrop",this._backdropHarnessClass],direction:this._dir||"ltr",scrollStrategy:t?(0,d.createBlockScrollStrategy)(this._injector):this._scrollStrategy(),panelClass:`mat-datepicker-${t?"dialog":"popup"}`,disableAnimations:this._animationsDisabled}));this._getCloseStream(n).subscribe(r=>{r&&r.preventDefault(),this.close()}),n.keydownEvents().subscribe(r=>{const i=r.keyCode;(i===o.UP_ARROW||i===o.DOWN_ARROW||i===o.LEFT_ARROW||i===o.RIGHT_ARROW||i===o.PAGE_UP||i===o.PAGE_DOWN)&&r.preventDefault()}),this._componentRef=n.attach(a),this._forwardContentValues(this._componentRef.instance),t||(0,e.afterNextRender)(()=>{n.updatePosition()},{injector:this._injector})}_destroyOverlay(){this._overlayRef&&(this._overlayRef.dispose(),this._overlayRef=this._componentRef=null)}_getDialogStrategy(){return(0,d.createGlobalPositionStrategy)(this._injector).centerHorizontally().centerVertically()}_getDropdownStrategy(){const t=(0,d.createFlexibleConnectedPositionStrategy)(this._injector,this.datepickerInput.getConnectedOverlayOrigin()).withTransformOriginOn(".mat-datepicker-content").withFlexibleDimensions(!1).withViewportMargin(8).withLockedPosition();return this._setConnectedPositions(t)}_setConnectedPositions(t){const a=this.xPosition==="end"?"end":"start",n=a==="start"?"end":"start",r=this.yPosition==="above"?"bottom":"top",i=r==="top"?"bottom":"top";return t.withPositions([{originX:a,originY:i,overlayX:a,overlayY:r},{originX:a,originY:r,overlayX:a,overlayY:i},{originX:n,originY:i,overlayX:n,overlayY:r},{originX:n,originY:r,overlayX:n,overlayY:i}])}_getCloseStream(t){const a=["ctrlKey","shiftKey","metaKey"];return(0,m.merge)(t.backdropClick(),t.detachments(),t.keydownEvents().pipe((0,A.filter)(n=>n.keyCode===o.ESCAPE&&!(0,o.hasModifierKey)(n)||this.datepickerInput&&(0,o.hasModifierKey)(n,"altKey")&&n.keyCode===o.UP_ARROW&&a.every(r=>!(0,o.hasModifierKey)(n,r)))))}static \u0275fac=function(a){return new(a||k)};static \u0275dir=e.\u0275\u0275defineDirective({type:k,inputs:{calendarHeaderComponent:"calendarHeaderComponent",startAt:"startAt",startView:"startView",color:"color",touchUi:[2,"touchUi","touchUi",e.booleanAttribute],disabled:[2,"disabled","disabled",e.booleanAttribute],xPosition:"xPosition",yPosition:"yPosition",restoreFocus:[2,"restoreFocus","restoreFocus",e.booleanAttribute],dateClass:"dateClass",panelClass:"panelClass",opened:[2,"opened","opened",e.booleanAttribute]},outputs:{yearSelected:"yearSelected",monthSelected:"monthSelected",viewChanged:"viewChanged",openedStream:"opened",closedStream:"closed"},features:[e.\u0275\u0275NgOnChangesFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(k,[{type:e.Directive}],()=>[],{calendarHeaderComponent:[{type:e.Input}],startAt:[{type:e.Input}],startView:[{type:e.Input}],color:[{type:e.Input}],touchUi:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],disabled:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],xPosition:[{type:e.Input}],yPosition:[{type:e.Input}],restoreFocus:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],yearSelected:[{type:e.Output}],monthSelected:[{type:e.Output}],viewChanged:[{type:e.Output}],dateClass:[{type:e.Input}],openedStream:[{type:e.Output,args:["opened"]}],closedStream:[{type:e.Output,args:["closed"]}],panelClass:[{type:e.Input}],opened:[{type:e.Input,args:[{transform:e.booleanAttribute}]}]});class F extends k{static \u0275fac=(()=>{let t;return function(n){return(t||(t=e.\u0275\u0275getInheritedFactory(F)))(n||F)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:F,selectors:[["mat-datepicker"]],exportAs:["matDatepicker"],features:[e.\u0275\u0275ProvidersFeature([ce,{provide:k,useExisting:F}]),e.\u0275\u0275InheritDefinitionFeature],decls:0,vars:0,template:function(a,n){},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(F,[{type:e.Component,args:[{selector:"mat-datepicker",template:"",exportAs:"matDatepicker",changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,providers:[ce,{provide:k,useExisting:F}]}]}],null,null);class ne{target;targetElement;value=null;constructor(t,a){this.target=t,this.targetElement=a,this.value=this.target.value}}class X{_elementRef=(0,e.inject)(e.ElementRef);_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_dateFormats=(0,e.inject)(p.de,{optional:!0});_isInitialized=!1;get value(){return this._model?this._getValueFromModel(this._model.selection):this._pendingValue}set value(t){this._assignValueProgrammatically(t,!0)}_model;get disabled(){return!!this._disabled||this._parentDisabled()}set disabled(t){const a=t,n=this._elementRef.nativeElement;this._disabled!==a&&(this._disabled=a,this.stateChanges.next(void 0)),a&&this._isInitialized&&n.blur&&n.blur()}_disabled;dateChange=new e.EventEmitter;dateInput=new e.EventEmitter;stateChanges=new m.Subject;_onTouched=()=>{};_validatorOnChange=()=>{};_cvaOnChange=()=>{};_valueChangesSubscription=m.Subscription.EMPTY;_localeSubscription=m.Subscription.EMPTY;_pendingValue=null;_parseValidator=()=>this._lastValueValid?null:{matDatepickerParse:{text:this._elementRef.nativeElement.value}};_filterValidator=t=>{const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t.value));return!a||this._matchesFilter(a)?null:{matDatepickerFilter:!0}};_minValidator=t=>{const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t.value)),n=this._getMinDate();return!n||!a||this._dateAdapter.compareDate(n,a)<=0?null:{matDatepickerMin:{min:n,actual:a}}};_maxValidator=t=>{const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t.value)),n=this._getMaxDate();return!n||!a||this._dateAdapter.compareDate(n,a)>=0?null:{matDatepickerMax:{max:n,actual:a}}};_getValidators(){return[this._parseValidator,this._minValidator,this._maxValidator,this._filterValidator]}_registerModel(t){this._model=t,this._valueChangesSubscription.unsubscribe(),this._pendingValue&&this._assignValue(this._pendingValue),this._valueChangesSubscription=this._model.selectionChanged.subscribe(a=>{if(this._shouldHandleChangeEvent(a)){const n=this._getValueFromModel(a.selection);this._lastValueValid=this._isValidValue(n),this._cvaOnChange(n),this._onTouched(),this._formatValue(n),this.dateInput.emit(new ne(this,this._elementRef.nativeElement)),this.dateChange.emit(new ne(this,this._elementRef.nativeElement))}})}_lastValueValid=!1;constructor(){if(typeof ngDevMode>"u"||ngDevMode){if(!this._dateAdapter)throw S("DateAdapter");if(!this._dateFormats)throw S("MAT_DATE_FORMATS")}this._localeSubscription=this._dateAdapter.localeChanges.subscribe(()=>{this._assignValueProgrammatically(this.value,!0)})}ngAfterViewInit(){this._isInitialized=!0}ngOnChanges(t){Te(t,this._dateAdapter)&&this.stateChanges.next(void 0)}ngOnDestroy(){this._valueChangesSubscription.unsubscribe(),this._localeSubscription.unsubscribe(),this.stateChanges.complete()}registerOnValidatorChange(t){this._validatorOnChange=t}validate(t){return this._validator?this._validator(t):null}writeValue(t){this._assignValueProgrammatically(t,t!==this.value)}registerOnChange(t){this._cvaOnChange=t}registerOnTouched(t){this._onTouched=t}setDisabledState(t){this.disabled=t}_onKeydown(t){const a=["ctrlKey","shiftKey","metaKey"];(0,o.hasModifierKey)(t,"altKey")&&t.keyCode===o.DOWN_ARROW&&a.every(r=>!(0,o.hasModifierKey)(t,r))&&!this._elementRef.nativeElement.readOnly&&(this._openPopup(),t.preventDefault())}_onInput(t){const a=t.target.value,n=this._lastValueValid;let r=this._dateAdapter.parse(a,this._dateFormats.parse.dateInput);this._lastValueValid=this._isValidValue(r),r=this._dateAdapter.getValidDateOrNull(r);const i=!this._dateAdapter.sameDate(r,this.value);!r||i?this._cvaOnChange(r):(a&&!this.value&&this._cvaOnChange(r),n!==this._lastValueValid&&this._validatorOnChange()),i&&(this._assignValue(r),this.dateInput.emit(new ne(this,this._elementRef.nativeElement)))}_onChange(){this.dateChange.emit(new ne(this,this._elementRef.nativeElement))}_onBlur(){this.value&&this._formatValue(this.value),this._onTouched()}_formatValue(t){this._elementRef.nativeElement.value=t!=null?this._dateAdapter.format(t,this._dateFormats.display.dateInput):""}_assignValue(t){this._model?(this._assignValueToModel(t),this._pendingValue=null):this._pendingValue=t}_isValidValue(t){return!t||this._dateAdapter.isValid(t)}_parentDisabled(){return!1}_assignValueProgrammatically(t,a){t=this._dateAdapter.deserialize(t),this._lastValueValid=this._isValidValue(t),t=this._dateAdapter.getValidDateOrNull(t),this._assignValue(t),a&&this._formatValue(t)}_matchesFilter(t){const a=this._getDateFilter();return!a||a(t)}static \u0275fac=function(a){return new(a||X)};static \u0275dir=e.\u0275\u0275defineDirective({type:X,inputs:{value:"value",disabled:[2,"disabled","disabled",e.booleanAttribute]},outputs:{dateChange:"dateChange",dateInput:"dateInput"},features:[e.\u0275\u0275NgOnChangesFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(X,[{type:e.Directive}],()=>[],{value:[{type:e.Input}],disabled:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],dateChange:[{type:e.Output}],dateInput:[{type:e.Output}]});function Te(s,t){const a=Object.keys(s);for(let n of a){const{previousValue:r,currentValue:i}=s[n];if(t.isDateInstance(r)&&t.isDateInstance(i)){if(!t.sameDate(r,i))return!0}else return!0}return!1}const fe={provide:y.NG_VALUE_ACCESSOR,useExisting:(0,e.forwardRef)(()=>O),multi:!0},ve={provide:y.NG_VALIDATORS,useExisting:(0,e.forwardRef)(()=>O),multi:!0};class O extends X{_formField=(0,e.inject)(oe.xb,{optional:!0});_closedSubscription=m.Subscription.EMPTY;_openedSubscription=m.Subscription.EMPTY;set matDatepicker(t){t&&(this._datepicker=t,this._ariaOwns.set(t.opened?t.id:null),this._closedSubscription=t.closedStream.subscribe(()=>{this._onTouched(),this._ariaOwns.set(null)}),this._openedSubscription=t.openedStream.subscribe(()=>{this._ariaOwns.set(t.id)}),this._registerModel(t.registerInput(this)))}_datepicker;_ariaOwns=(0,e.signal)(null,...ngDevMode?[{debugName:"_ariaOwns"}]:[]);get min(){return this._min}set min(t){const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t));this._dateAdapter.sameDate(a,this._min)||(this._min=a,this._validatorOnChange())}_min=null;get max(){return this._max}set max(t){const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t));this._dateAdapter.sameDate(a,this._max)||(this._max=a,this._validatorOnChange())}_max=null;get dateFilter(){return this._dateFilter}set dateFilter(t){const a=this._matchesFilter(this.value);this._dateFilter=t,this._matchesFilter(this.value)!==a&&this._validatorOnChange()}_dateFilter;_validator=null;constructor(){super(),this._validator=y.Validators.compose(super._getValidators())}getConnectedOverlayOrigin(){return this._formField?this._formField.getConnectedOverlayOrigin():this._elementRef}getOverlayLabelId(){return this._formField?this._formField.getLabelId():this._elementRef.nativeElement.getAttribute("aria-labelledby")}getThemePalette(){return this._formField?this._formField.color:void 0}getStartValue(){return this.value}ngOnDestroy(){super.ngOnDestroy(),this._closedSubscription.unsubscribe(),this._openedSubscription.unsubscribe()}_openPopup(){this._datepicker&&this._datepicker.open()}_getValueFromModel(t){return t}_assignValueToModel(t){this._model&&this._model.updateSelection(t,this)}_getMinDate(){return this._min}_getMaxDate(){return this._max}_getDateFilter(){return this._dateFilter}_shouldHandleChangeEvent(t){return t.source!==this}static \u0275fac=function(a){return new(a||O)};static \u0275dir=e.\u0275\u0275defineDirective({type:O,selectors:[["input","matDatepicker",""]],hostAttrs:[1,"mat-datepicker-input"],hostVars:6,hostBindings:function(a,n){a&1&&e.\u0275\u0275listener("input",function(i){return n._onInput(i)})("change",function(){return n._onChange()})("blur",function(){return n._onBlur()})("keydown",function(i){return n._onKeydown(i)}),a&2&&(e.\u0275\u0275domProperty("disabled",n.disabled),e.\u0275\u0275attribute("aria-haspopup",n._datepicker?"dialog":null)("aria-owns",n._ariaOwns())("min",n.min?n._dateAdapter.toIso8601(n.min):null)("max",n.max?n._dateAdapter.toIso8601(n.max):null)("data-mat-calendar",n._datepicker?n._datepicker.id:null))},inputs:{matDatepicker:"matDatepicker",min:"min",max:"max",dateFilter:[0,"matDatepickerFilter","dateFilter"]},exportAs:["matDatepickerInput"],features:[e.\u0275\u0275ProvidersFeature([fe,ve,{provide:ke.O,useExisting:O}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(O,[{type:e.Directive,args:[{selector:"input[matDatepicker]",providers:[fe,ve,{provide:ke.O,useExisting:O}],host:{class:"mat-datepicker-input","[attr.aria-haspopup]":'_datepicker ? "dialog" : null',"[attr.aria-owns]":"_ariaOwns()","[attr.min]":"min ? _dateAdapter.toIso8601(min) : null","[attr.max]":"max ? _dateAdapter.toIso8601(max) : null","[attr.data-mat-calendar]":"_datepicker ? _datepicker.id : null","[disabled]":"disabled","(input)":"_onInput($event)","(change)":"_onChange()","(blur)":"_onBlur()","(keydown)":"_onKeydown($event)"},exportAs:"matDatepickerInput"}]}],()=>[],{matDatepicker:[{type:e.Input}],min:[{type:e.Input}],max:[{type:e.Input}],dateFilter:[{type:e.Input,args:["matDatepickerFilter"]}]});class Y{static \u0275fac=function(a){return new(a||Y)};static \u0275dir=e.\u0275\u0275defineDirective({type:Y,selectors:[["","matDatepickerToggleIcon",""]]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(Y,[{type:e.Directive,args:[{selector:"[matDatepickerToggleIcon]"}]}],null,null);class W{_intl=(0,e.inject)(C);_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_stateChanges=m.Subscription.EMPTY;datepicker;tabIndex=null;ariaLabel;get disabled(){return this._disabled===void 0&&this.datepicker?this.datepicker.disabled:!!this._disabled}set disabled(t){this._disabled=t}_disabled;disableRipple=!1;_customIcon;_button;constructor(){const t=(0,e.inject)(new e.HostAttributeToken("tabindex"),{optional:!0}),a=Number(t);this.tabIndex=a||a===0?a:null}ngOnChanges(t){t.datepicker&&this._watchStateChanges()}ngOnDestroy(){this._stateChanges.unsubscribe()}ngAfterContentInit(){this._watchStateChanges()}_open(t){this.datepicker&&!this.disabled&&(this.datepicker.open(),t.stopPropagation())}_watchStateChanges(){const t=this.datepicker?this.datepicker.stateChanges:(0,m.of)(),a=this.datepicker&&this.datepicker.datepickerInput?this.datepicker.datepickerInput.stateChanges:(0,m.of)(),n=this.datepicker?(0,m.merge)(this.datepicker.openedStream,this.datepicker.closedStream):(0,m.of)();this._stateChanges.unsubscribe(),this._stateChanges=(0,m.merge)(this._intl.changes,t,a,n).subscribe(()=>this._changeDetectorRef.markForCheck())}static \u0275fac=function(a){return new(a||W)};static \u0275cmp=e.\u0275\u0275defineComponent({type:W,selectors:[["mat-datepicker-toggle"]],contentQueries:function(a,n,r){if(a&1&&e.\u0275\u0275contentQuery(r,Y,5),a&2){let i;e.\u0275\u0275queryRefresh(i=e.\u0275\u0275loadQuery())&&(n._customIcon=i.first)}},viewQuery:function(a,n){if(a&1&&e.\u0275\u0275viewQuery(qe,5),a&2){let r;e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n._button=r.first)}},hostAttrs:[1,"mat-datepicker-toggle"],hostVars:8,hostBindings:function(a,n){a&1&&e.\u0275\u0275listener("click",function(i){return n._open(i)}),a&2&&(e.\u0275\u0275attribute("tabindex",null)("data-mat-calendar",n.datepicker?n.datepicker.id:null),e.\u0275\u0275classProp("mat-datepicker-toggle-active",n.datepicker&&n.datepicker.opened)("mat-accent",n.datepicker&&n.datepicker.color==="accent")("mat-warn",n.datepicker&&n.datepicker.color==="warn"))},inputs:{datepicker:[0,"for","datepicker"],tabIndex:"tabIndex",ariaLabel:[0,"aria-label","ariaLabel"],disabled:[2,"disabled","disabled",e.booleanAttribute],disableRipple:"disableRipple"},exportAs:["matDatepickerToggle"],features:[e.\u0275\u0275NgOnChangesFeature],ngContentSelectors:Ze,decls:4,vars:7,consts:[["button",""],["matIconButton","","type","button",3,"tabIndex","disabled","disableRipple"],["viewBox","0 0 24 24","width","24px","height","24px","fill","currentColor","focusable","false","aria-hidden","true",1,"mat-datepicker-toggle-default-icon"],["d","M19 3h-1V1h-2v2H8V1H6v2H5c-1.11 0-1.99.9-1.99 2L3 19c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm0 16H5V8h14v11zM7 10h5v5H7z"]],template:function(a,n){a&1&&(e.\u0275\u0275projectionDef(Xe),e.\u0275\u0275elementStart(0,"button",1,0),e.\u0275\u0275conditionalCreate(2,et,2,0,":svg:svg",2),e.\u0275\u0275projection(3),e.\u0275\u0275elementEnd()),a&2&&(e.\u0275\u0275property("tabIndex",n.disabled?-1:n.tabIndex)("disabled",n.disabled)("disableRipple",n.disableRipple),e.\u0275\u0275attribute("aria-haspopup",n.datepicker?"dialog":null)("aria-label",n.ariaLabel||n._intl.openCalendarLabel)("aria-expanded",n.datepicker?n.datepicker.opened:null),e.\u0275\u0275advance(2),e.\u0275\u0275conditional(n._customIcon?-1:2))},dependencies:[se.iY],styles:[`.mat-datepicker-toggle {
  pointer-events: auto;
  color: var(--mat-datepicker-toggle-icon-color, var(--mat-sys-on-surface-variant));
}
.mat-datepicker-toggle button {
  color: inherit;
}

.mat-datepicker-toggle-active {
  color: var(--mat-datepicker-toggle-active-state-icon-color, var(--mat-sys-primary));
}

@media (forced-colors: active) {
  .mat-datepicker-toggle-default-icon {
    color: CanvasText;
  }
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(W,[{type:e.Component,args:[{selector:"mat-datepicker-toggle",host:{class:"mat-datepicker-toggle","[attr.tabindex]":"null","[class.mat-datepicker-toggle-active]":"datepicker && datepicker.opened","[class.mat-accent]":'datepicker && datepicker.color === "accent"',"[class.mat-warn]":'datepicker && datepicker.color === "warn"',"[attr.data-mat-calendar]":"datepicker ? datepicker.id : null","(click)":"_open($event)"},exportAs:"matDatepickerToggle",encapsulation:e.ViewEncapsulation.None,changeDetection:e.ChangeDetectionStrategy.OnPush,imports:[se.iY],template:`<button
  #button
  matIconButton
  type="button"
  [attr.aria-haspopup]="datepicker ? 'dialog' : null"
  [attr.aria-label]="ariaLabel || _intl.openCalendarLabel"
  [tabIndex]="disabled ? -1 : tabIndex"
  [attr.aria-expanded]="datepicker ? datepicker.opened : null"
  [disabled]="disabled"
  [disableRipple]="disableRipple">

  @if (!_customIcon) {
    <svg
      class="mat-datepicker-toggle-default-icon"
      viewBox="0 0 24 24"
      width="24px"
      height="24px"
      fill="currentColor"
      focusable="false"
      aria-hidden="true">
      <path d="M19 3h-1V1h-2v2H8V1H6v2H5c-1.11 0-1.99.9-1.99 2L3 19c0 1.1.89 2 2 2h14c1.1 0 2-.9 2-2V5c0-1.1-.9-2-2-2zm0 16H5V8h14v11zM7 10h5v5H7z"/>
    </svg>
  }

  <ng-content select="[matDatepickerToggleIcon]"></ng-content>
</button>
`,styles:[`.mat-datepicker-toggle {
  pointer-events: auto;
  color: var(--mat-datepicker-toggle-icon-color, var(--mat-sys-on-surface-variant));
}
.mat-datepicker-toggle button {
  color: inherit;
}

.mat-datepicker-toggle-active {
  color: var(--mat-datepicker-toggle-active-state-icon-color, var(--mat-sys-primary));
}

@media (forced-colors: active) {
  .mat-datepicker-toggle-default-icon {
    color: CanvasText;
  }
}
`]}]}],()=>[],{datepicker:[{type:e.Input,args:["for"]}],tabIndex:[{type:e.Input}],ariaLabel:[{type:e.Input,args:["aria-label"]}],disabled:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],disableRipple:[{type:e.Input}],_customIcon:[{type:e.ContentChild,args:[Y]}],_button:[{type:e.ViewChild,args:["button"]}]});class P{_changeDetectorRef=(0,e.inject)(e.ChangeDetectorRef);_elementRef=(0,e.inject)(e.ElementRef);_dateAdapter=(0,e.inject)(p.MJ,{optional:!0});_formField=(0,e.inject)(oe.xb,{optional:!0});_closedSubscription=m.Subscription.EMPTY;_openedSubscription=m.Subscription.EMPTY;_startInput;_endInput;get value(){return this._model?this._model.selection:null}id=(0,e.inject)(h._IdGenerator).getId("mat-date-range-input-");focused=!1;get shouldLabelFloat(){return this.focused||!this.empty}controlType="mat-date-range-input";get placeholder(){const t=this._startInput?._getPlaceholder()||"",a=this._endInput?._getPlaceholder()||"";return t||a?`${t} ${this.separator} ${a}`:""}get rangePicker(){return this._rangePicker}set rangePicker(t){t&&(this._model=t.registerInput(this),this._rangePicker=t,this._closedSubscription.unsubscribe(),this._openedSubscription.unsubscribe(),this._ariaOwns.set(this.rangePicker.opened?t.id:null),this._closedSubscription=t.closedStream.subscribe(()=>{this._startInput?._onTouched(),this._endInput?._onTouched(),this._ariaOwns.set(null)}),this._openedSubscription=t.openedStream.subscribe(()=>{this._ariaOwns.set(t.id)}),this._registerModel(this._model))}_rangePicker;_ariaOwns=(0,e.signal)(null,...ngDevMode?[{debugName:"_ariaOwns"}]:[]);get required(){return this._required??(this._isTargetRequired(this)||this._isTargetRequired(this._startInput)||this._isTargetRequired(this._endInput))??!1}set required(t){this._required=t}_required;get dateFilter(){return this._dateFilter}set dateFilter(t){const a=this._startInput,n=this._endInput,r=a&&a._matchesFilter(a.value),i=n&&n._matchesFilter(a.value);this._dateFilter=t,a&&a._matchesFilter(a.value)!==r&&a._validatorOnChange(),n&&n._matchesFilter(n.value)!==i&&n._validatorOnChange()}_dateFilter;get min(){return this._min}set min(t){const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t));this._dateAdapter.sameDate(a,this._min)||(this._min=a,this._revalidate())}_min=null;get max(){return this._max}set max(t){const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t));this._dateAdapter.sameDate(a,this._max)||(this._max=a,this._revalidate())}_max=null;get disabled(){return this._startInput&&this._endInput?this._startInput.disabled&&this._endInput.disabled:this._groupDisabled}set disabled(t){t!==this._groupDisabled&&(this._groupDisabled=t,this.stateChanges.next(void 0))}_groupDisabled=!1;get errorState(){return this._startInput&&this._endInput?this._startInput.errorState||this._endInput.errorState:!1}get empty(){const t=this._startInput?this._startInput.isEmpty():!1,a=this._endInput?this._endInput.isEmpty():!1;return t&&a}_ariaDescribedBy=null;_model;separator="\u2013";comparisonStart=null;comparisonEnd=null;ngControl;stateChanges=new m.Subject;disableAutomaticLabeling=!0;constructor(){if(!this._dateAdapter&&(typeof ngDevMode>"u"||ngDevMode))throw S("DateAdapter");this._formField?._elementRef.nativeElement.classList.contains("mat-mdc-form-field")&&this._elementRef.nativeElement.classList.add("mat-mdc-input-element","mat-mdc-form-field-input-control","mdc-text-field__input"),this.ngControl=(0,e.inject)(y.ControlContainer,{optional:!0,self:!0})}get describedByIds(){return this._elementRef.nativeElement.getAttribute("aria-describedby")?.split(" ")||[]}setDescribedByIds(t){this._ariaDescribedBy=t.length?t.join(" "):null}onContainerClick(){!this.focused&&!this.disabled&&(!this._model||!this._model.selection.start?this._startInput.focus():this._endInput.focus())}ngAfterContentInit(){if(typeof ngDevMode>"u"||ngDevMode){if(!this._startInput)throw Error("mat-date-range-input must contain a matStartDate input");if(!this._endInput)throw Error("mat-date-range-input must contain a matEndDate input")}this._model&&this._registerModel(this._model),(0,m.merge)(this._startInput.stateChanges,this._endInput.stateChanges).subscribe(()=>{this.stateChanges.next(void 0)})}ngOnChanges(t){Te(t,this._dateAdapter)&&this.stateChanges.next(void 0)}ngOnDestroy(){this._closedSubscription.unsubscribe(),this._openedSubscription.unsubscribe(),this.stateChanges.complete()}getStartValue(){return this.value?this.value.start:null}getThemePalette(){return this._formField?this._formField.color:void 0}getConnectedOverlayOrigin(){return this._formField?this._formField.getConnectedOverlayOrigin():this._elementRef}getOverlayLabelId(){return this._formField?this._formField.getLabelId():null}_getInputMirrorValue(t){const a=t==="start"?this._startInput:this._endInput;return a?a.getMirrorValue():""}_shouldHidePlaceholders(){return this._startInput?!this._startInput.isEmpty():!1}_handleChildValueChange(){this.stateChanges.next(void 0),this._changeDetectorRef.markForCheck()}_openDatepicker(){this._rangePicker&&this._rangePicker.open()}_shouldHideSeparator(){return(!this._formField||this._formField.getLabelId()&&!this._formField._shouldLabelFloat())&&this.empty}_getAriaLabelledby(){const t=this._formField;return t&&t._hasFloatingLabel()?t._labelId:null}_getStartDateAccessibleName(){return this._startInput._getAccessibleName()}_getEndDateAccessibleName(){return this._endInput._getAccessibleName()}_updateFocus(t){this.focused=t!==null,this.stateChanges.next()}_revalidate(){this._startInput&&this._startInput._validatorOnChange(),this._endInput&&this._endInput._validatorOnChange()}_registerModel(t){this._startInput&&this._startInput._registerModel(t),this._endInput&&this._endInput._registerModel(t)}_isTargetRequired(t){return t?.ngControl?.control?.hasValidator(y.Validators.required)}static \u0275fac=function(a){return new(a||P)};static \u0275cmp=e.\u0275\u0275defineComponent({type:P,selectors:[["mat-date-range-input"]],hostAttrs:["role","group",1,"mat-date-range-input"],hostVars:8,hostBindings:function(a,n){a&2&&(e.\u0275\u0275attribute("id",n.id)("aria-labelledby",n._getAriaLabelledby())("aria-describedby",n._ariaDescribedBy)("data-mat-calendar",n.rangePicker?n.rangePicker.id:null),e.\u0275\u0275classProp("mat-date-range-input-hide-placeholders",n._shouldHidePlaceholders())("mat-date-range-input-required",n.required))},inputs:{rangePicker:"rangePicker",required:[2,"required","required",e.booleanAttribute],dateFilter:"dateFilter",min:"min",max:"max",disabled:[2,"disabled","disabled",e.booleanAttribute],separator:"separator",comparisonStart:"comparisonStart",comparisonEnd:"comparisonEnd"},exportAs:["matDateRangeInput"],features:[e.\u0275\u0275ProvidersFeature([{provide:oe.qT,useExisting:P}]),e.\u0275\u0275NgOnChangesFeature],ngContentSelectors:at,decls:11,vars:5,consts:[["cdkMonitorSubtreeFocus","",1,"mat-date-range-input-container",3,"cdkFocusChange"],[1,"mat-date-range-input-wrapper"],["aria-hidden","true",1,"mat-date-range-input-mirror"],[1,"mat-date-range-input-separator"],[1,"mat-date-range-input-wrapper","mat-date-range-input-end-wrapper"]],template:function(a,n){a&1&&(e.\u0275\u0275projectionDef(tt),e.\u0275\u0275elementStart(0,"div",0),e.\u0275\u0275listener("cdkFocusChange",function(i){return n._updateFocus(i)}),e.\u0275\u0275elementStart(1,"div",1),e.\u0275\u0275projection(2),e.\u0275\u0275elementStart(3,"span",2),e.\u0275\u0275text(4),e.\u0275\u0275elementEnd()(),e.\u0275\u0275elementStart(5,"span",3),e.\u0275\u0275text(6),e.\u0275\u0275elementEnd(),e.\u0275\u0275elementStart(7,"div",4),e.\u0275\u0275projection(8,1),e.\u0275\u0275elementStart(9,"span",2),e.\u0275\u0275text(10),e.\u0275\u0275elementEnd()()()),a&2&&(e.\u0275\u0275advance(4),e.\u0275\u0275textInterpolate(n._getInputMirrorValue("start")),e.\u0275\u0275advance(),e.\u0275\u0275classProp("mat-date-range-input-separator-hidden",n._shouldHideSeparator()),e.\u0275\u0275advance(),e.\u0275\u0275textInterpolate(n.separator),e.\u0275\u0275advance(4),e.\u0275\u0275textInterpolate(n._getInputMirrorValue("end")))},dependencies:[h.CdkMonitorFocus],styles:[`.mat-date-range-input {
  display: block;
  width: 100%;
}

.mat-date-range-input-container {
  display: flex;
  align-items: center;
}

.mat-date-range-input-separator {
  transition: opacity 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
  margin: 0 4px;
  color: var(--mat-datepicker-range-input-separator-color, var(--mat-sys-on-surface));
}
.mat-form-field-disabled .mat-date-range-input-separator {
  color: var(--mat-datepicker-range-input-disabled-state-separator-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
._mat-animation-noopable .mat-date-range-input-separator {
  transition: none;
}

.mat-date-range-input-separator-hidden {
  -webkit-user-select: none;
  user-select: none;
  opacity: 0;
  transition: none;
}

.mat-date-range-input-wrapper {
  position: relative;
  overflow: hidden;
  max-width: calc(50% - 4px);
}

.mat-date-range-input-end-wrapper {
  flex-grow: 1;
}

.mat-date-range-input-inner {
  position: absolute;
  top: 0;
  left: 0;
  font: inherit;
  background: transparent;
  color: currentColor;
  border: none;
  outline: none;
  padding: 0;
  margin: 0;
  vertical-align: bottom;
  text-align: inherit;
  -webkit-appearance: none;
  width: 100%;
  height: 100%;
}
.mat-date-range-input-inner:-moz-ui-invalid {
  box-shadow: none;
}
.mat-date-range-input-inner::placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner::-moz-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner::-webkit-input-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner:-ms-input-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner[disabled] {
  color: var(--mat-datepicker-range-input-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner::placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner::placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::placeholder {
    opacity: 0;
  }
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner::-moz-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-moz-placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner::-moz-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-moz-placeholder {
    opacity: 0;
  }
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner::-webkit-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-webkit-input-placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner::-webkit-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-webkit-input-placeholder {
    opacity: 0;
  }
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner:-ms-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner:-ms-input-placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner:-ms-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner:-ms-input-placeholder {
    opacity: 0;
  }
}
._mat-animation-noopable .mat-date-range-input-inner::placeholder {
  transition: none;
}
._mat-animation-noopable .mat-date-range-input-inner::-moz-placeholder {
  transition: none;
}
._mat-animation-noopable .mat-date-range-input-inner::-webkit-input-placeholder {
  transition: none;
}
._mat-animation-noopable .mat-date-range-input-inner:-ms-input-placeholder {
  transition: none;
}

.mat-date-range-input-mirror {
  -webkit-user-select: none;
  user-select: none;
  visibility: hidden;
  white-space: nowrap;
  display: inline-block;
  min-width: 2px;
}

.mat-mdc-form-field-type-mat-date-range-input .mat-mdc-form-field-infix {
  width: 200px;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(P,[{type:e.Component,args:[{selector:"mat-date-range-input",exportAs:"matDateRangeInput",host:{class:"mat-date-range-input","[class.mat-date-range-input-hide-placeholders]":"_shouldHidePlaceholders()","[class.mat-date-range-input-required]":"required","[attr.id]":"id",role:"group","[attr.aria-labelledby]":"_getAriaLabelledby()","[attr.aria-describedby]":"_ariaDescribedBy","[attr.data-mat-calendar]":"rangePicker ? rangePicker.id : null"},changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,providers:[{provide:oe.qT,useExisting:P}],imports:[h.CdkMonitorFocus],template:`<div
  class="mat-date-range-input-container"
  cdkMonitorSubtreeFocus
  (cdkFocusChange)="_updateFocus($event)">
  <div class="mat-date-range-input-wrapper">
    <ng-content select="input[matStartDate]"></ng-content>
    <span
      class="mat-date-range-input-mirror"
      aria-hidden="true">{{_getInputMirrorValue('start')}}</span>
  </div>

  <span
    class="mat-date-range-input-separator"
    [class.mat-date-range-input-separator-hidden]="_shouldHideSeparator()">{{separator}}</span>

  <div class="mat-date-range-input-wrapper mat-date-range-input-end-wrapper">
    <ng-content select="input[matEndDate]"></ng-content>
    <span
      class="mat-date-range-input-mirror"
      aria-hidden="true">{{_getInputMirrorValue('end')}}</span>
  </div>
</div>

`,styles:[`.mat-date-range-input {
  display: block;
  width: 100%;
}

.mat-date-range-input-container {
  display: flex;
  align-items: center;
}

.mat-date-range-input-separator {
  transition: opacity 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
  margin: 0 4px;
  color: var(--mat-datepicker-range-input-separator-color, var(--mat-sys-on-surface));
}
.mat-form-field-disabled .mat-date-range-input-separator {
  color: var(--mat-datepicker-range-input-disabled-state-separator-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
._mat-animation-noopable .mat-date-range-input-separator {
  transition: none;
}

.mat-date-range-input-separator-hidden {
  -webkit-user-select: none;
  user-select: none;
  opacity: 0;
  transition: none;
}

.mat-date-range-input-wrapper {
  position: relative;
  overflow: hidden;
  max-width: calc(50% - 4px);
}

.mat-date-range-input-end-wrapper {
  flex-grow: 1;
}

.mat-date-range-input-inner {
  position: absolute;
  top: 0;
  left: 0;
  font: inherit;
  background: transparent;
  color: currentColor;
  border: none;
  outline: none;
  padding: 0;
  margin: 0;
  vertical-align: bottom;
  text-align: inherit;
  -webkit-appearance: none;
  width: 100%;
  height: 100%;
}
.mat-date-range-input-inner:-moz-ui-invalid {
  box-shadow: none;
}
.mat-date-range-input-inner::placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner::-moz-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner::-webkit-input-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner:-ms-input-placeholder {
  transition: color 400ms 133.3333333333ms cubic-bezier(0.25, 0.8, 0.25, 1);
}
.mat-date-range-input-inner[disabled] {
  color: var(--mat-datepicker-range-input-disabled-state-text-color, color-mix(in srgb, var(--mat-sys-on-surface) 38%, transparent));
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner::placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner::placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::placeholder {
    opacity: 0;
  }
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner::-moz-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-moz-placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner::-moz-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-moz-placeholder {
    opacity: 0;
  }
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner::-webkit-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-webkit-input-placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner::-webkit-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner::-webkit-input-placeholder {
    opacity: 0;
  }
}
.mat-form-field-hide-placeholder .mat-date-range-input-inner:-ms-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner:-ms-input-placeholder {
  -webkit-user-select: none;
  user-select: none;
  color: transparent !important;
  -webkit-text-fill-color: transparent;
  transition: none;
}
@media (forced-colors: active) {
  .mat-form-field-hide-placeholder .mat-date-range-input-inner:-ms-input-placeholder, .mat-date-range-input-hide-placeholders .mat-date-range-input-inner:-ms-input-placeholder {
    opacity: 0;
  }
}
._mat-animation-noopable .mat-date-range-input-inner::placeholder {
  transition: none;
}
._mat-animation-noopable .mat-date-range-input-inner::-moz-placeholder {
  transition: none;
}
._mat-animation-noopable .mat-date-range-input-inner::-webkit-input-placeholder {
  transition: none;
}
._mat-animation-noopable .mat-date-range-input-inner:-ms-input-placeholder {
  transition: none;
}

.mat-date-range-input-mirror {
  -webkit-user-select: none;
  user-select: none;
  visibility: hidden;
  white-space: nowrap;
  display: inline-block;
  min-width: 2px;
}

.mat-mdc-form-field-type-mat-date-range-input .mat-mdc-form-field-infix {
  width: 200px;
}
`]}]}],()=>[],{rangePicker:[{type:e.Input}],required:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],dateFilter:[{type:e.Input}],min:[{type:e.Input}],max:[{type:e.Input}],disabled:[{type:e.Input,args:[{transform:e.booleanAttribute}]}],separator:[{type:e.Input}],comparisonStart:[{type:e.Input}],comparisonEnd:[{type:e.Input}]});function dt(s){return De(s,!0)}function Fe(s){return s.nodeType===Node.ELEMENT_NODE}function lt(s){return s.nodeName==="INPUT"}function ct(s){return s.nodeName==="TEXTAREA"}function De(s,t){if(Fe(s)&&t){const n=(s.getAttribute?.("aria-labelledby")?.split(/\s+/g)||[]).reduce((r,i)=>{const l=document.getElementById(i);return l&&r.push(l),r},[]);if(n.length)return n.map(r=>De(r,!1)).join(" ")}if(Fe(s)){const a=s.getAttribute("aria-label")?.trim();if(a)return a}if(lt(s)||ct(s)){if(s.labels?.length)return Array.from(s.labels).map(r=>De(r,!1)).join(" ");const a=s.getAttribute("placeholder")?.trim();if(a)return a;const n=s.getAttribute("title")?.trim();if(n)return n}return(s.textContent||"").replace(/\s+/g," ").trim()}class Z extends X{_rangeInput=(0,e.inject)(P);_elementRef=(0,e.inject)(e.ElementRef);_defaultErrorStateMatcher=(0,e.inject)(Le.e);_injector=(0,e.inject)(e.Injector);_rawValue=(0,e.signal)("",...ngDevMode?[{debugName:"_rawValue"}]:[]);_parentForm=(0,e.inject)(y.NgForm,{optional:!0});_parentFormGroup=(0,e.inject)(y.FormGroupDirective,{optional:!0});ngControl;_dir=(0,e.inject)(_.Directionality,{optional:!0});_errorStateTracker;get errorStateMatcher(){return this._errorStateTracker.matcher}set errorStateMatcher(t){this._errorStateTracker.matcher=t}get errorState(){return this._errorStateTracker.errorState}set errorState(t){this._errorStateTracker.errorState=t}constructor(){super(),this._errorStateTracker=new Ne.X(this._defaultErrorStateMatcher,null,this._parentFormGroup,this._parentForm,this.stateChanges)}ngOnInit(){const t=this._injector.get(y.NgControl,null,{optional:!0,self:!0});t&&(this.ngControl=t,this._errorStateTracker.ngControl=t)}ngAfterContentInit(){this._register()}ngDoCheck(){this.ngControl&&this.updateErrorState(),this._rawValue.set(this._elementRef.nativeElement.value)}isEmpty(){return this._rawValue().length===0}_getPlaceholder(){return this._elementRef.nativeElement.placeholder}focus(){this._elementRef.nativeElement.focus()}getMirrorValue(){const t=this._rawValue();return t.length>0?t:this._getPlaceholder()}updateErrorState(){this._errorStateTracker.updateErrorState()}_onInput(t){super._onInput(t),this._rangeInput._handleChildValueChange()}_openPopup(){this._rangeInput._openDatepicker()}_getMinDate(){return this._rangeInput.min}_getMaxDate(){return this._rangeInput.max}_getDateFilter(){return this._rangeInput.dateFilter}_parentDisabled(){return this._rangeInput._groupDisabled}_shouldHandleChangeEvent({source:t}){return t!==this._rangeInput._startInput&&t!==this._rangeInput._endInput}_assignValueProgrammatically(t,a){super._assignValueProgrammatically(t,a),(this===this._rangeInput._startInput?this._rangeInput._endInput:this._rangeInput._startInput)?._validatorOnChange(),this._rawValue.set(this._elementRef.nativeElement.value)}_formatValue(t){super._formatValue(t),this._rangeInput._handleChildValueChange()}_getAccessibleName(){return dt(this._elementRef.nativeElement)}static \u0275fac=function(a){return new(a||Z)};static \u0275dir=e.\u0275\u0275defineDirective({type:Z,inputs:{errorStateMatcher:"errorStateMatcher"},features:[e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(Z,[{type:e.Directive}],()=>[],{errorStateMatcher:[{type:e.Input}]});class E extends Z{_startValidator=t=>{const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t.value)),n=this._model?this._model.selection.end:null;return!a||!n||this._dateAdapter.compareDate(a,n)<=0?null:{matStartDateInvalid:{end:n,actual:a}}};_validator=y.Validators.compose([...super._getValidators(),this._startValidator]);_register(){this._rangeInput._startInput=this}_getValueFromModel(t){return t.start}_shouldHandleChangeEvent(t){return super._shouldHandleChangeEvent(t)?t.oldValue?.start?!t.selection.start||!!this._dateAdapter.compareDate(t.oldValue.start,t.selection.start):!!t.selection.start:!1}_assignValueToModel(t){if(this._model){const a=new f(t,this._model.selection.end);this._model.updateSelection(a,this),this._rangeInput._handleChildValueChange()}}_onKeydown(t){const a=this._rangeInput._endInput,n=this._elementRef.nativeElement,r=this._dir?.value!=="rtl";(t.keyCode===o.RIGHT_ARROW&&r||t.keyCode===o.LEFT_ARROW&&!r)&&n.selectionStart===n.value.length&&n.selectionEnd===n.value.length?(t.preventDefault(),a._elementRef.nativeElement.setSelectionRange(0,0),a.focus()):super._onKeydown(t)}static \u0275fac=(()=>{let t;return function(n){return(t||(t=e.\u0275\u0275getInheritedFactory(E)))(n||E)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:E,selectors:[["input","matStartDate",""]],hostAttrs:["type","text",1,"mat-start-date","mat-date-range-input-inner"],hostVars:5,hostBindings:function(a,n){a&1&&e.\u0275\u0275listener("input",function(i){return n._onInput(i)})("change",function(){return n._onChange()})("keydown",function(i){return n._onKeydown(i)})("blur",function(){return n._onBlur()}),a&2&&(e.\u0275\u0275domProperty("disabled",n.disabled),e.\u0275\u0275attribute("aria-haspopup",n._rangeInput.rangePicker?"dialog":null)("aria-owns",n._rangeInput._ariaOwns()||null)("min",n._getMinDate()?n._dateAdapter.toIso8601(n._getMinDate()):null)("max",n._getMaxDate()?n._dateAdapter.toIso8601(n._getMaxDate()):null))},outputs:{dateChange:"dateChange",dateInput:"dateInput"},features:[e.\u0275\u0275ProvidersFeature([{provide:y.NG_VALUE_ACCESSOR,useExisting:E,multi:!0},{provide:y.NG_VALIDATORS,useExisting:E,multi:!0}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(E,[{type:e.Directive,args:[{selector:"input[matStartDate]",host:{class:"mat-start-date mat-date-range-input-inner","[disabled]":"disabled","(input)":"_onInput($event)","(change)":"_onChange()","(keydown)":"_onKeydown($event)","[attr.aria-haspopup]":'_rangeInput.rangePicker ? "dialog" : null',"[attr.aria-owns]":"_rangeInput._ariaOwns() || null","[attr.min]":"_getMinDate() ? _dateAdapter.toIso8601(_getMinDate()!) : null","[attr.max]":"_getMaxDate() ? _dateAdapter.toIso8601(_getMaxDate()!) : null","(blur)":"_onBlur()",type:"text"},providers:[{provide:y.NG_VALUE_ACCESSOR,useExisting:E,multi:!0},{provide:y.NG_VALIDATORS,useExisting:E,multi:!0}],outputs:["dateChange","dateInput"]}]}],null,null);class x extends Z{_endValidator=t=>{const a=this._dateAdapter.getValidDateOrNull(this._dateAdapter.deserialize(t.value)),n=this._model?this._model.selection.start:null;return!a||!n||this._dateAdapter.compareDate(a,n)>=0?null:{matEndDateInvalid:{start:n,actual:a}}};_register(){this._rangeInput._endInput=this}_validator=y.Validators.compose([...super._getValidators(),this._endValidator]);_getValueFromModel(t){return t.end}_shouldHandleChangeEvent(t){return super._shouldHandleChangeEvent(t)?t.oldValue?.end?!t.selection.end||!!this._dateAdapter.compareDate(t.oldValue.end,t.selection.end):!!t.selection.end:!1}_assignValueToModel(t){if(this._model){const a=new f(this._model.selection.start,t);this._model.updateSelection(a,this)}}_moveCaretToEndOfStartInput(){const t=this._rangeInput._startInput._elementRef.nativeElement,a=t.value;a.length>0&&t.setSelectionRange(a.length,a.length),t.focus()}_onKeydown(t){const a=this._elementRef.nativeElement,n=this._dir?.value!=="rtl";t.keyCode===o.BACKSPACE&&!a.value?this._moveCaretToEndOfStartInput():(t.keyCode===o.LEFT_ARROW&&n||t.keyCode===o.RIGHT_ARROW&&!n)&&a.selectionStart===0&&a.selectionEnd===0?(t.preventDefault(),this._moveCaretToEndOfStartInput()):super._onKeydown(t)}static \u0275fac=(()=>{let t;return function(n){return(t||(t=e.\u0275\u0275getInheritedFactory(x)))(n||x)}})();static \u0275dir=e.\u0275\u0275defineDirective({type:x,selectors:[["input","matEndDate",""]],hostAttrs:["type","text",1,"mat-end-date","mat-date-range-input-inner"],hostVars:5,hostBindings:function(a,n){a&1&&e.\u0275\u0275listener("input",function(i){return n._onInput(i)})("change",function(){return n._onChange()})("keydown",function(i){return n._onKeydown(i)})("blur",function(){return n._onBlur()}),a&2&&(e.\u0275\u0275domProperty("disabled",n.disabled),e.\u0275\u0275attribute("aria-haspopup",n._rangeInput.rangePicker?"dialog":null)("aria-owns",n._rangeInput._ariaOwns()||null)("min",n._getMinDate()?n._dateAdapter.toIso8601(n._getMinDate()):null)("max",n._getMaxDate()?n._dateAdapter.toIso8601(n._getMaxDate()):null))},outputs:{dateChange:"dateChange",dateInput:"dateInput"},features:[e.\u0275\u0275ProvidersFeature([{provide:y.NG_VALUE_ACCESSOR,useExisting:x,multi:!0},{provide:y.NG_VALIDATORS,useExisting:x,multi:!0}]),e.\u0275\u0275InheritDefinitionFeature]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(x,[{type:e.Directive,args:[{selector:"input[matEndDate]",host:{class:"mat-end-date mat-date-range-input-inner","[disabled]":"disabled","(input)":"_onInput($event)","(change)":"_onChange()","(keydown)":"_onKeydown($event)","[attr.aria-haspopup]":'_rangeInput.rangePicker ? "dialog" : null',"[attr.aria-owns]":"_rangeInput._ariaOwns() || null","[attr.min]":"_getMinDate() ? _dateAdapter.toIso8601(_getMinDate()!) : null","[attr.max]":"_getMaxDate() ? _dateAdapter.toIso8601(_getMaxDate()!) : null","(blur)":"_onBlur()",type:"text"},providers:[{provide:y.NG_VALUE_ACCESSOR,useExisting:x,multi:!0},{provide:y.NG_VALIDATORS,useExisting:x,multi:!0}],outputs:["dateChange","dateInput"]}]}],null,null);class L extends k{_forwardContentValues(t){super._forwardContentValues(t);const a=this.datepickerInput;a&&(t.comparisonStart=a.comparisonStart,t.comparisonEnd=a.comparisonEnd,t.startDateAccessibleName=a._getStartDateAccessibleName(),t.endDateAccessibleName=a._getEndDateAccessibleName())}static \u0275fac=(()=>{let t;return function(n){return(t||(t=e.\u0275\u0275getInheritedFactory(L)))(n||L)}})();static \u0275cmp=e.\u0275\u0275defineComponent({type:L,selectors:[["mat-date-range-picker"]],exportAs:["matDateRangePicker"],features:[e.\u0275\u0275ProvidersFeature([Ie,{provide:$,useFactory:()=>(0,e.inject)($,{optional:!0,skipSelf:!0})||new K((0,e.inject)(p.MJ))},{provide:k,useExisting:L}]),e.\u0275\u0275InheritDefinitionFeature],decls:0,vars:0,template:function(a,n){},encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(L,[{type:e.Component,args:[{selector:"mat-date-range-picker",template:"",exportAs:"matDateRangePicker",changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,providers:[Ie,{provide:$,useFactory:()=>(0,e.inject)($,{optional:!0,skipSelf:!0})||new K((0,e.inject)(p.MJ))},{provide:k,useExisting:L}]}]}],null,null);class G{_datepicker=(0,e.inject)(k);constructor(){}_applySelection(){this._datepicker._applyPendingSelection(),this._datepicker.close()}static \u0275fac=function(a){return new(a||G)};static \u0275dir=e.\u0275\u0275defineDirective({type:G,selectors:[["","matDatepickerApply",""],["","matDateRangePickerApply",""]],hostBindings:function(a,n){a&1&&e.\u0275\u0275listener("click",function(){return n._applySelection()})}})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(G,[{type:e.Directive,args:[{selector:"[matDatepickerApply], [matDateRangePickerApply]",host:{"(click)":"_applySelection()"}}]}],()=>[],null);class Q{_datepicker=(0,e.inject)(k);constructor(){}static \u0275fac=function(a){return new(a||Q)};static \u0275dir=e.\u0275\u0275defineDirective({type:Q,selectors:[["","matDatepickerCancel",""],["","matDateRangePickerCancel",""]],hostBindings:function(a,n){a&1&&e.\u0275\u0275listener("click",function(){return n._datepicker.close()})}})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(Q,[{type:e.Directive,args:[{selector:"[matDatepickerCancel], [matDateRangePickerCancel]",host:{"(click)":"_datepicker.close()"}}]}],()=>[],null);class J{_datepicker=(0,e.inject)(k);_viewContainerRef=(0,e.inject)(e.ViewContainerRef);_template;_portal;constructor(){}ngAfterViewInit(){this._portal=new g.TemplatePortal(this._template,this._viewContainerRef),this._datepicker.registerActions(this._portal)}ngOnDestroy(){this._datepicker.removeActions(this._portal),this._portal&&this._portal.isAttached&&this._portal?.detach()}static \u0275fac=function(a){return new(a||J)};static \u0275cmp=e.\u0275\u0275defineComponent({type:J,selectors:[["mat-datepicker-actions"],["mat-date-range-picker-actions"]],viewQuery:function(a,n){if(a&1&&e.\u0275\u0275viewQuery(e.TemplateRef,5),a&2){let r;e.\u0275\u0275queryRefresh(r=e.\u0275\u0275loadQuery())&&(n._template=r.first)}},ngContentSelectors:Ee,decls:1,vars:0,consts:[[1,"mat-datepicker-actions"]],template:function(a,n){a&1&&(e.\u0275\u0275projectionDef(),e.\u0275\u0275domTemplate(0,nt,2,0,"ng-template"))},styles:[`.mat-datepicker-actions {
  display: flex;
  justify-content: flex-end;
  align-items: center;
  padding: 0 8px 8px 8px;
}
.mat-datepicker-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 8px;
}
[dir=rtl] .mat-datepicker-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 0;
  margin-right: 8px;
}
`],encapsulation:2,changeDetection:0})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(J,[{type:e.Component,args:[{selector:"mat-datepicker-actions, mat-date-range-picker-actions",template:`
    <ng-template>
      <div class="mat-datepicker-actions">
        <ng-content></ng-content>
      </div>
    </ng-template>
  `,changeDetection:e.ChangeDetectionStrategy.OnPush,encapsulation:e.ViewEncapsulation.None,styles:[`.mat-datepicker-actions {
  display: flex;
  justify-content: flex-end;
  align-items: center;
  padding: 0 8px 8px 8px;
}
.mat-datepicker-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 8px;
}
[dir=rtl] .mat-datepicker-actions .mat-mdc-button-base + .mat-mdc-button-base {
  margin-left: 0;
  margin-right: 8px;
}
`]}]}],()=>[],{_template:[{type:e.ViewChild,args:[e.TemplateRef]}]});class re{static \u0275fac=function(a){return new(a||re)};static \u0275mod=e.\u0275\u0275defineNgModule({type:re});static \u0275inj=e.\u0275\u0275defineInjector({providers:[C],imports:[q.MatButtonModule,d.OverlayModule,h.A11yModule,g.PortalModule,B,W,N,_.BidiModule,Ae.CdkScrollableModule]})}(typeof ngDevMode>"u"||ngDevMode)&&e.\u0275setClassMetadata(re,[{type:e.NgModule,args:[{imports:[q.MatButtonModule,d.OverlayModule,h.A11yModule,g.PortalModule,M,b,F,B,O,W,Y,I,R,V,N,P,E,x,L,J,Q,G],exports:[_.BidiModule,Ae.CdkScrollableModule,M,b,F,B,O,W,Y,I,R,V,N,P,E,x,L,J,Q,G],providers:[C]}]}],null,null)}}]);
