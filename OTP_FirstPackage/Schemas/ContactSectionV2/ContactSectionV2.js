define("ContactSectionV2", ["ProcessModuleUtilities", "ServiceHelper"], 
function(ProcessModuleUtilities, ServiceHelper) {
	return {
		entitySchemaName: "Contact",
		messages:{
			
			/**
			 * Subscribed on: ContactPageV2 
			 */
			"SectionActionClicked":{
				mode: this.Terrasoft.MessageMode.PTP,
				direction: this.Terrasoft.MessageDirectionType.PUBLISH
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "PrimaryContactButtonRed",
				"parentName": "CombinedModeActionButtonsCardLeftContainer", //INVISIBLE in section, visible on the page
				"propertyName": "items",
				"values":{
					itemType: this.Terrasoft.ViewItemType.BUTTON,
					style: Terrasoft.controls.ButtonEnums.style.RED,
					classes: {
						"textClass": ["actions-button-margin-right"],
						"wrapperClass": ["actions-button-margin-right"]
					},
					caption: "Section Red Button",
					hint: "Section red button hint",
					click: {"bindTo": "onMyMainButtonClick"},
					tag: "CombinedModeActionButtonsCardLeftContainer_Red"
				}
			},
			{
				"operation": "insert",
				"name": "PrimaryContactButtonGreen",
				"parentName": "SeparateModeActionButtonsLeftContainer", //visible in section and on a page
				"propertyName": "items",
				"values":{
					itemType: this.Terrasoft.ViewItemType.BUTTON,
					style: Terrasoft.controls.ButtonEnums.style.GREEN,
					classes: {
						textClass: ["actions-button-margin-right"],
						wrapperClass: ["actions-button-margin-right"]
					},
					caption: "Section Green Button",
					hint: "Section red button hint",
					click: {"bindTo": "onMyMainButtonClick"},
					tag: "ActionButtonsContainer_Red"
				}
			},
		]/**SCHEMA_DIFF*/,
		methods: {
			
			onMyMainButtonClick: function() {
				
				var primaryColumnValue = this.$ActiveRow;
				this.runProcess(primaryColumnValue);

				//this.sandbox.publish("SectionActionClicked", null, [this.sandbox.id+"_CardModuleV2"]);
			},

			getSectionActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuSeparator());
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Tag": "action1",
					"Caption": "Section Action One",
					"Click": {"bindTo": "onActionClick"},
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Tag": "action2",
					"Caption": "Section Action Two",
					"Click": {"bindTo": "onActionClick"}
				}));
				return actionMenuItems;
			},
			onActionClick: function(tag){
				//this.showInformationDialog("Section Action Clicked with tag: "+ tag);
				this.callConfigurationWebService();
			},

			runProcess: function (primaryColumnValue){
				var id = primaryColumnValue;
				var scope = this;
				var args = {
					sysProcessName: "Process_f95babb",
					parameters:{
						recordId: id
					},
					//callback: scope.onProcessCompleted(),
					scope: scope
				}
				ProcessModuleUtilities.executeProcess(args);
			},

			/**
			 * Call Custom Configuration WebService
			 * @tutorial https://academy.creatio.com/docs/developer/back-end_development/configuration_web_service/configuration_web_service#case-1241
			 */
			callConfigurationWebService: function(){
				
				var serviceData = {
					"id": this.$ActiveRow
				};


				// Calling the web service and processing the results.
				// Can only execute/send POST requests
				//https://baseUrl/0/rest/CustomExample/PostMethodName
				ServiceHelper.callService(
					"DemoServiceTwo", 			//CS - ClassName
					"PostMethodJs", 			//CS - Method
					function(response) 
					{
						var name = response.name;
						var email = response.email;
						 this.showInformationDialog(name+" "+email);
					}, 
					serviceData, 				// Payload
					this
				);

			}

		}
	};
});
