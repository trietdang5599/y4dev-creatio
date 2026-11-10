Terrasoft.configuration.Structures["ProductDetailV2"] = {innerHierarchyStack: ["ProductDetailV2"], structureParent: "BaseGridDetailV2"};
define('ProductDetailV2Structure', ['ProductDetailV2Resources'], function(resources) {return {schemaUId:'956729e3-33ef-4895-9d70-9e252958b63c',schemaCaption: "Base detail - Products", parentSchemaName: "BaseGridDetailV2", packageName: "CrtUIv2", schemaName:'ProductDetailV2',parentSchemaUId:'01eb38ee-668a-42f0-999d-c2534f979089',extendParent:false,type:Terrasoft.SchemaType.GRID_DETAIL_VIEW_MODEL_SCHEMA,entitySchema:'',name:'',extend:'Terrasoft.model.BaseViewModel',schema:{leftPanel:[],rightPanel:[],actions:[],analytics:[]},methods:{},controlsConfig:{},customBindings:{},bindings:{},schemaDifferences:function(){

}};});
define("ProductDetailV2", ["terrasoft"],
		function(Terrasoft) {
			return {
				entitySchemaName: "BaseProductEntry",
				attributes: {},
				methods: {},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "merge",
						"name": "DataGrid",
						"values": {
							"type": "listed",
							"listedConfig": {
								"name": "DataGridListedConfig",
								"items": [
									{
										"name": "NameListedGridColumn",
										"bindTo": "Name",
										"position": {
											"column": 1,
											"colSpan": 12
										},
										"type": Terrasoft.GridCellType.TITLE
									},
									{
										"name": "QuantityListedGridColumn",
										"bindTo": "Quantity",
										"position": {
											"column": 13,
											"colSpan": 6
										}
									},
									{
										"name": "TotalAmountListedGridColumn",
										"bindTo": "TotalAmount",
										"position": {
											"column": 19,
											"colSpan": 6
										}
									}
								]
							},
							"tiledConfig": {
								"name": "DataGridTiledConfig",
								"grid": {
									"columns": 24,
									"rows": 3
								},
								"items": [
									{
										"name": "NameTiledGridColumn",
										"bindTo": "Name",
										"position": {
											"row": 1,
											"column": 1,
											"colSpan": 16
										},
										"type": Terrasoft.GridCellType.TITLE
									},
									{
										"name": "QuantityTiledGridColumn",
										"bindTo": "Quantity",
										"position": {
											"row": 1,
											"column": 17,
											"colSpan": 8
										}
									},
									{
										"name": "PriceTiledGridColumn",
										"bindTo": "Price",
										"position": {
											"row": 2,
											"column": 1,
											"colSpan": 8
										}
									},
									{
										"name": "DiscountPercentTiledGridColumn",
										"bindTo": "DiscountPercent",
										"position": {
											"row": 2,
											"column": 9,
											"colSpan": 8
										}
									},
									{
										"name": "TotalAmountTiledGridColumn",
										"bindTo": "TotalAmount",
										"position": {
											"row": 2,
											"column": 17,
											"colSpan": 8
										}
									}
								]
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		}
);


