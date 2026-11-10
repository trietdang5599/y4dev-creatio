namespace Terrasoft.Configuration
{

	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.Configuration;

	#region Class: MapsToolsSchema

	/// <exclude/>
	public class MapsToolsSchema : Terrasoft.Core.SourceCodeSchema
	{

		#region Constructors: Public

		public MapsToolsSchema(SourceCodeSchemaManager sourceCodeSchemaManager)
			: base(sourceCodeSchemaManager) {
		}

		public MapsToolsSchema(MapsToolsSchema source)
			: base( source) {
		}

		#endregion

		#region Methods: Protected

		protected override void InitializeProperties() {
			base.InitializeProperties();
			UId = new Guid("6695633c-183e-4546-aee4-b7c12b985585");
			Name = "MapsTools";
			ParentSchemaUId = new Guid("50e3acc0-26fc-4237-a095-849a1d534bd3");
			CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6");
			ZipBody = new byte[] { 31,139,8,0,0,0,0,0,4,0,237,91,221,110,27,199,21,190,166,1,191,195,100,13,88,75,152,90,74,178,227,40,82,148,66,166,104,153,181,68,42,36,21,37,49,12,97,181,28,73,27,45,119,152,217,93,253,68,33,80,164,23,69,129,94,244,49,122,89,20,40,208,38,168,251,10,242,27,245,204,207,206,238,204,238,82,146,45,163,65,27,35,145,150,51,231,156,249,230,204,249,155,179,84,18,249,225,17,26,92,68,49,30,175,222,191,151,228,62,58,67,124,30,171,177,33,166,212,141,200,97,236,236,118,156,61,124,208,34,97,76,73,16,57,233,67,9,101,139,80,236,236,80,226,225,136,211,29,250,71,9,117,99,159,132,21,196,38,130,78,207,28,105,145,32,192,30,19,17,57,155,56,196,212,247,76,146,46,46,67,221,34,227,113,110,93,73,187,25,144,3,55,240,191,215,65,117,241,89,12,11,48,182,223,70,124,252,254,189,87,3,88,139,147,30,4,248,245,253,123,147,228,32,240,61,228,5,110,20,161,109,119,178,67,252,48,70,151,181,251,247,106,114,42,29,220,34,30,23,31,161,236,9,93,162,35,128,137,34,246,99,154,241,68,49,101,0,214,71,35,10,58,187,134,10,116,65,232,53,52,157,240,144,236,249,225,136,156,189,136,199,193,53,196,189,131,111,65,183,93,119,140,11,132,240,95,179,137,134,189,141,222,10,122,32,255,169,7,227,153,125,64,218,140,54,11,255,26,106,16,149,16,229,168,117,102,36,153,5,152,220,48,210,57,243,2,216,1,162,121,244,196,89,112,224,127,120,50,128,22,144,151,96,168,218,168,194,161,239,207,153,41,133,67,89,6,40,130,219,62,142,227,201,74,179,249,45,104,61,114,66,110,121,39,112,24,142,71,198,77,151,122,199,254,41,110,46,45,44,46,53,23,150,154,139,139,205,111,97,63,243,33,142,231,159,204,47,204,83,28,96,55,194,243,203,243,7,201,209,252,161,127,14,34,220,104,114,94,119,242,58,50,244,169,61,26,154,51,53,88,56,73,248,41,37,151,108,18,189,98,218,6,71,7,123,74,188,152,208,215,85,154,203,63,59,204,184,10,156,69,63,66,118,29,93,74,91,44,76,73,11,14,192,191,226,100,132,191,116,131,4,55,82,187,14,72,120,84,50,236,74,47,91,67,97,18,4,106,216,215,93,198,152,245,184,211,137,65,192,3,88,106,7,132,4,232,216,141,50,247,94,67,135,110,16,177,112,150,205,174,171,213,178,57,255,16,217,133,48,225,12,233,69,235,24,123,39,59,46,5,163,136,49,141,108,99,95,250,134,234,18,71,45,15,0,44,169,24,129,174,145,195,49,213,140,157,192,129,8,176,211,20,241,71,66,21,78,39,234,130,18,122,180,61,158,196,23,182,212,166,2,147,237,87,206,40,233,217,76,38,187,86,83,210,181,245,31,62,68,31,101,44,169,236,248,152,146,51,190,197,117,122,148,140,113,24,183,207,61,60,97,44,182,149,50,163,137,210,31,34,135,40,62,198,104,194,141,5,62,140,221,9,242,35,20,146,24,14,148,82,136,122,86,253,38,155,212,109,67,237,181,99,154,140,78,247,30,146,91,210,220,184,217,229,84,53,133,31,211,107,243,146,8,232,82,121,12,36,90,201,229,170,204,143,54,19,127,132,118,59,35,61,236,231,28,77,207,75,195,139,9,174,36,229,246,222,137,118,168,63,118,233,133,78,134,100,14,65,246,3,39,117,255,250,10,210,34,130,204,13,122,72,109,24,145,204,72,40,13,125,34,155,253,53,115,149,80,60,248,53,115,153,50,223,49,115,149,37,174,156,43,20,220,175,152,193,138,36,220,23,33,34,17,58,2,143,52,147,85,67,248,151,175,252,75,166,19,147,142,187,168,145,186,72,86,222,165,51,44,160,148,165,78,147,85,79,20,239,147,49,217,138,43,232,0,206,30,205,206,70,141,108,203,186,252,134,144,200,69,241,32,201,2,215,90,166,50,30,37,59,57,5,41,101,173,242,213,215,53,13,229,244,197,25,123,121,37,101,26,91,21,81,119,214,193,125,192,131,170,11,173,197,199,126,196,237,3,238,56,103,236,183,93,207,107,41,93,170,145,151,221,200,73,171,27,198,71,78,225,122,228,143,112,186,238,144,12,248,131,45,179,207,169,75,81,116,32,139,9,49,245,44,241,131,17,166,118,189,162,182,41,79,110,105,250,214,152,52,77,151,243,101,36,165,235,73,221,205,92,147,209,212,225,244,84,125,161,173,156,166,217,232,192,89,159,76,112,56,210,150,148,92,211,10,102,86,156,232,96,138,226,172,6,74,43,11,77,138,206,36,23,202,241,149,161,159,22,249,25,4,3,212,15,63,152,160,74,23,176,86,144,89,242,20,235,172,2,158,28,7,197,113,66,67,176,15,39,51,155,85,225,35,188,48,185,225,149,57,43,245,46,103,84,7,249,112,110,166,134,124,150,43,84,44,91,50,196,164,117,200,132,146,24,52,133,71,85,119,224,173,52,8,205,224,152,113,199,191,205,69,68,106,249,118,181,190,8,68,53,181,175,53,125,41,126,62,217,30,214,12,118,121,64,124,7,212,63,117,99,230,251,192,239,161,83,2,105,199,132,114,187,205,204,58,63,173,190,67,149,41,53,151,143,112,90,209,179,54,20,108,196,90,143,17,171,25,160,126,15,49,171,225,93,89,250,71,172,146,247,195,83,176,180,145,197,247,159,26,116,105,92,208,54,83,191,201,141,66,67,2,254,172,73,40,122,119,249,170,229,55,182,91,45,171,137,200,59,111,26,171,61,18,66,68,143,119,40,57,133,168,78,101,224,238,38,227,3,76,159,19,58,118,99,81,132,112,78,131,216,17,100,27,216,131,28,18,12,48,187,60,197,60,111,91,142,208,106,179,89,206,178,73,73,50,185,61,131,255,61,78,239,169,224,64,175,208,107,48,160,199,104,170,14,48,102,151,7,121,7,226,82,32,206,108,16,112,59,172,31,161,211,199,147,192,245,48,132,90,22,108,29,171,158,141,32,43,181,86,135,31,67,189,97,234,72,106,17,129,251,122,199,200,86,218,191,51,187,80,91,73,67,112,113,55,218,185,254,130,182,83,106,111,170,14,202,71,78,30,65,120,114,46,233,93,220,62,34,230,142,254,118,177,113,246,230,101,198,202,218,47,249,60,198,91,17,185,205,241,28,166,101,172,77,66,142,2,12,17,63,26,194,78,35,113,127,150,65,148,98,119,68,194,224,2,237,70,152,194,9,135,162,71,141,246,19,237,243,106,25,139,214,24,23,162,247,189,194,88,41,107,39,140,241,145,198,232,27,35,171,218,73,25,232,140,143,92,75,144,243,116,117,149,108,129,171,72,183,1,67,57,182,33,90,151,33,15,196,144,12,193,160,100,169,18,85,200,168,81,212,155,109,72,20,6,81,208,137,228,55,149,87,202,109,90,58,55,218,77,204,19,190,172,108,68,241,195,45,80,217,186,57,155,171,53,89,160,134,82,42,9,88,82,203,123,179,234,8,150,215,179,229,50,85,165,38,23,142,78,89,0,46,160,139,28,11,61,42,135,5,227,150,35,92,92,214,22,16,184,31,228,122,42,122,139,64,165,115,180,71,232,73,52,129,192,132,90,253,197,79,30,63,125,242,148,51,179,253,41,29,23,128,24,134,225,40,33,16,229,34,146,80,15,232,8,117,143,192,185,45,101,77,16,246,96,99,178,61,169,116,23,68,70,229,169,249,179,32,43,30,225,134,207,23,134,107,210,103,66,103,105,40,250,60,61,86,94,199,237,178,23,65,155,152,120,100,4,15,235,19,191,112,189,147,159,143,148,225,175,239,116,94,226,11,121,239,139,142,201,217,158,75,67,166,123,121,70,80,29,193,230,145,18,138,128,1,193,121,95,144,4,157,249,209,49,138,9,84,156,108,18,163,6,58,9,201,89,152,174,134,35,222,22,97,34,58,49,108,237,187,196,135,97,233,116,172,8,141,184,48,88,222,73,201,132,92,8,19,115,49,58,115,195,152,73,7,251,230,109,208,19,124,193,103,61,151,123,166,41,39,191,214,68,36,150,8,185,41,54,42,195,225,33,228,250,35,181,23,5,20,141,46,66,119,236,195,177,67,124,58,164,100,204,157,26,82,252,36,137,149,224,103,73,204,128,68,152,239,5,71,80,195,185,20,62,64,112,155,15,252,177,207,170,109,192,59,242,35,15,108,2,172,1,185,7,12,168,108,227,130,192,83,31,76,166,224,78,204,228,170,15,88,90,9,55,80,163,217,97,45,88,217,156,217,235,200,79,78,40,20,72,145,136,86,139,106,244,123,2,251,92,67,11,106,128,181,198,90,132,23,224,11,215,248,181,217,55,103,236,135,188,88,3,45,100,23,107,48,206,231,198,168,98,21,142,193,237,14,180,52,192,97,196,235,176,44,209,113,161,153,165,246,133,210,179,188,122,173,234,36,182,218,165,245,29,56,163,9,111,218,72,103,193,178,96,222,244,137,108,62,226,216,128,68,225,204,249,112,70,70,146,24,204,133,213,63,94,116,106,229,198,49,27,75,226,195,101,107,42,198,154,205,75,235,40,176,166,220,28,197,219,91,48,153,144,85,16,204,88,101,64,155,150,105,97,151,250,236,112,217,81,69,43,205,230,24,134,28,49,203,59,152,236,115,19,12,252,55,214,106,118,177,185,250,179,115,245,151,171,191,95,253,237,237,31,224,231,191,174,126,186,122,3,55,156,171,127,95,189,185,250,249,237,239,97,240,175,111,127,124,251,39,244,246,71,152,253,9,6,254,120,245,143,171,127,194,252,219,223,93,189,129,193,55,140,225,234,231,155,28,137,80,10,0,44,164,47,7,76,225,5,128,174,96,177,103,8,173,103,122,144,142,39,148,160,43,229,209,245,184,10,114,64,200,30,62,144,212,78,11,42,148,24,219,217,26,117,228,70,136,129,206,136,210,104,46,56,182,113,124,76,88,27,207,218,108,15,45,125,14,164,141,160,82,245,93,158,86,178,79,45,215,59,198,206,6,62,116,193,251,115,68,25,56,55,242,124,191,29,202,24,37,140,124,125,208,234,116,210,49,187,110,44,69,200,137,143,217,87,26,92,63,84,55,40,99,52,101,146,25,0,60,96,2,25,3,63,135,96,55,128,200,132,211,102,167,160,18,70,105,203,56,197,41,121,183,82,44,8,103,217,151,163,182,174,36,49,152,70,133,84,12,168,31,187,99,37,73,126,92,83,3,121,129,98,210,86,145,165,86,83,170,192,161,39,162,83,58,194,248,148,82,152,135,205,47,203,138,191,124,11,125,40,65,149,126,196,66,98,200,214,161,53,228,82,57,16,181,82,133,233,130,29,246,107,72,218,225,200,86,40,164,199,139,95,226,103,117,84,45,174,145,33,200,7,232,157,52,158,167,13,149,124,239,164,40,196,25,76,2,63,182,231,26,115,41,172,92,164,7,71,117,192,81,224,36,175,151,254,106,225,117,42,129,183,222,148,148,53,180,180,176,144,41,43,159,111,110,37,127,81,201,175,153,201,238,6,220,75,175,21,179,153,13,111,192,253,56,229,206,157,213,180,144,65,191,129,164,153,101,156,98,10,130,237,178,214,127,252,121,218,142,174,93,46,52,208,226,180,81,187,92,108,160,37,246,123,169,129,62,102,191,31,55,208,50,251,253,4,230,129,0,9,234,143,225,19,144,161,203,167,240,240,152,61,124,2,15,79,24,225,50,60,60,101,35,159,194,195,178,0,168,242,116,166,243,207,144,58,10,45,197,79,139,164,159,163,79,13,210,197,229,140,86,14,85,236,253,149,26,127,205,191,107,36,115,185,15,209,151,21,54,45,241,134,26,248,11,118,146,213,22,38,241,195,135,101,53,104,109,0,99,249,178,246,133,20,184,13,105,28,234,44,187,250,106,99,241,70,39,120,25,17,85,50,30,181,41,133,92,94,111,40,147,208,170,112,6,198,129,2,193,182,82,3,97,101,188,214,124,91,45,80,166,38,100,149,223,237,243,180,76,133,64,198,52,155,171,33,138,116,202,78,129,88,233,121,38,135,80,100,170,25,43,219,95,9,215,204,187,70,118,93,228,106,207,170,162,137,175,206,32,61,53,117,4,3,143,250,147,248,198,175,96,24,1,79,37,172,60,112,163,19,73,250,133,28,98,215,45,54,108,220,187,50,94,207,157,200,203,119,94,138,35,237,166,37,102,57,181,122,25,176,5,73,208,182,14,147,80,92,219,111,177,55,123,12,9,84,62,139,46,19,235,29,37,204,58,211,108,99,172,194,32,142,5,3,64,156,155,91,173,160,19,141,87,38,139,185,134,44,227,120,73,183,41,175,45,3,62,235,244,94,178,78,181,56,184,85,52,173,16,135,161,114,70,55,150,249,77,187,223,219,239,183,7,187,91,195,1,147,158,3,204,174,221,51,124,106,55,228,247,60,89,71,115,135,106,185,80,27,91,117,118,45,159,67,171,83,116,39,8,123,95,182,251,251,95,236,182,251,95,239,111,117,182,59,195,219,161,132,178,115,219,13,47,192,166,168,143,63,32,202,126,27,32,14,134,251,27,237,110,167,189,113,59,140,34,63,115,108,31,14,96,167,251,229,250,86,103,99,95,2,189,29,194,109,63,98,117,20,211,226,197,109,32,50,23,56,19,238,152,115,29,88,208,112,166,89,174,145,162,252,136,249,16,131,93,34,240,17,204,33,123,14,224,164,212,143,208,92,125,174,218,73,218,231,172,110,231,164,207,200,185,35,185,236,10,106,174,158,52,218,176,45,55,42,8,139,208,170,40,13,0,189,151,55,36,220,91,239,119,59,221,205,42,234,52,178,217,7,49,107,85,174,78,25,114,171,138,154,189,148,175,152,170,167,71,98,140,167,10,157,241,10,245,102,89,100,195,167,242,203,208,255,131,105,100,198,230,254,27,121,36,131,115,151,153,164,32,245,221,115,73,38,138,71,151,111,48,37,66,113,209,221,196,194,162,2,126,153,73,165,128,243,125,210,138,161,84,217,187,216,192,161,143,71,37,112,107,119,129,119,123,253,171,253,189,245,175,119,122,157,238,112,176,223,254,170,213,110,111,188,39,238,109,247,124,207,189,224,95,127,141,216,123,49,60,42,133,127,23,232,187,189,225,254,243,222,110,247,253,0,195,45,227,57,73,194,15,5,114,183,251,178,219,219,235,238,183,251,253,94,255,206,11,141,59,177,130,247,170,53,222,177,26,250,181,212,248,127,45,53,228,155,101,254,45,160,235,122,4,178,32,41,228,96,246,165,114,170,221,157,11,175,60,211,137,204,40,139,239,30,16,239,252,232,47,30,88,231,103,134,185,119,137,48,248,180,243,153,183,121,249,246,224,242,227,133,217,50,42,92,38,101,127,186,176,56,147,189,170,186,207,248,151,102,242,87,223,4,51,9,143,175,145,224,158,186,126,192,198,103,73,89,156,173,134,103,238,232,37,46,223,193,210,108,206,234,132,46,36,76,85,177,168,187,93,73,120,73,187,90,149,70,227,200,102,124,4,88,13,42,254,117,71,142,216,88,6,130,142,133,108,230,96,149,98,95,233,51,175,153,51,214,173,172,171,197,203,104,240,14,173,198,102,239,104,138,95,82,112,100,189,190,167,129,144,85,185,142,44,171,162,35,62,13,90,132,81,214,20,183,237,202,63,187,220,97,140,242,175,24,97,220,17,152,195,24,212,231,180,18,74,113,168,126,191,112,195,81,128,105,221,121,238,67,66,21,2,192,222,243,107,89,252,221,131,54,36,162,73,126,132,117,199,228,6,10,74,40,11,38,217,197,165,240,230,82,127,153,94,246,205,136,252,31,13,169,65,217,165,211,190,16,101,61,82,33,174,138,138,127,147,10,233,145,80,235,217,77,255,3,210,87,119,254,7,59,0,0 };
		}

		protected override void InitializeLocalizableStrings() {
			base.InitializeLocalizableStrings();
			SetLocalizableStringsDefInheritance();
			LocalizableStrings.Add(CreateStartPointIsNotLocatedErrorLocalizableString());
			LocalizableStrings.Add(CreateStartPointIsNotDefinedLocalizableString());
			LocalizableStrings.Add(CreateFinishPointIsNotLocatedErrorLocalizableString());
			LocalizableStrings.Add(CreatePointIsNotLocatedErrorLocalizableString());
			LocalizableStrings.Add(CreateServerErrorErrorCauseLocalizableString());
			LocalizableStrings.Add(CreateMissingQueryErrorCauseLocalizableString());
			LocalizableStrings.Add(CreateUnknownAddressErrorCauseLocalizableString());
			LocalizableStrings.Add(CreateUnavailableAddressErrorCauseLocalizableString());
			LocalizableStrings.Add(CreateBadKeyErrorCauseLocalizableString());
			LocalizableStrings.Add(CreateTooManyQueriesErrorCauseLocalizableString());
			LocalizableStrings.Add(CreateNoServerResponseErrorCauseLocalizableString());
			LocalizableStrings.Add(CreateDirectionsErrorLocalizableString());
			LocalizableStrings.Add(CreateDirectionsErrorZeroResultsCauseLocalizableString());
			LocalizableStrings.Add(CreateDirectionsErrorRequestDeniedCauseLocalizableString());
			LocalizableStrings.Add(CreateDirectionsErrorMaxWaypointsExceededCauseLocalizableString());
			LocalizableStrings.Add(CreateDirectionsErrorNotFoundCauseLocalizableString());
		}

		protected virtual SchemaLocalizableString CreateStartPointIsNotLocatedErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("cbddb5c8-f56f-4f25-a0eb-1fed9eee9db5"),
				Name = "StartPointIsNotLocatedError",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateStartPointIsNotDefinedLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5768b2f6-3d6c-4c36-a583-582ffbeeb9b8"),
				Name = "StartPointIsNotDefined",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateFinishPointIsNotLocatedErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ea24aebb-cf9b-49dc-bad1-c358ac485e1c"),
				Name = "FinishPointIsNotLocatedError",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreatePointIsNotLocatedErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("025601fa-6178-408c-8962-606133cd45d0"),
				Name = "PointIsNotLocatedError",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateServerErrorErrorCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("57508a72-d39f-4c7d-bc69-63c1bd0c8159"),
				Name = "ServerErrorErrorCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateMissingQueryErrorCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("13183777-efc5-44d2-8060-bb91b9802db7"),
				Name = "MissingQueryErrorCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateUnknownAddressErrorCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("fa459144-5196-4840-b7f8-37bf454b7e91"),
				Name = "UnknownAddressErrorCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateUnavailableAddressErrorCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("ede157b6-6da6-4bac-a365-58844aa74f20"),
				Name = "UnavailableAddressErrorCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateBadKeyErrorCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("486504b1-d294-414f-a69e-70ec142bd7a5"),
				Name = "BadKeyErrorCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateTooManyQueriesErrorCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("984ccb61-ab38-4e3c-b389-02a15f614d0e"),
				Name = "TooManyQueriesErrorCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateNoServerResponseErrorCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5e78d1ed-2ff0-4c03-8b00-d32fa8c4ad07"),
				Name = "NoServerResponseErrorCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateDirectionsErrorLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("5922dd8c-cafb-4871-ab50-bdd1df90d590"),
				Name = "DirectionsError",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateDirectionsErrorZeroResultsCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("e9bb669a-37c8-4c99-bef5-35a1fb7b602f"),
				Name = "DirectionsErrorZeroResultsCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateDirectionsErrorRequestDeniedCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("dad2a39b-608f-4111-b050-5d78c80609b9"),
				Name = "DirectionsErrorRequestDeniedCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateDirectionsErrorMaxWaypointsExceededCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("32ae0b81-e362-4903-b6b7-8d20cb3324cb"),
				Name = "DirectionsErrorMaxWaypointsExceededCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		protected virtual SchemaLocalizableString CreateDirectionsErrorNotFoundCauseLocalizableString() {
			SchemaLocalizableString localizableString = new SchemaLocalizableString() {
				UId = new Guid("9f4e5568-1e02-4c1d-a1f3-646ed7dc9672"),
				Name = "DirectionsErrorNotFoundCause",
				CreatedInPackageId = new Guid("66e9e705-64b4-4dda-925e-d1e05a389eb6"),
				CreatedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585"),
				ModifiedInSchemaUId = new Guid("6695633c-183e-4546-aee4-b7c12b985585")
			};
			return localizableString;
		}

		#endregion

		#region Methods: Public

		public override void GetParentRealUIds(Collection<Guid> realUIds) {
			base.GetParentRealUIds(realUIds);
			realUIds.Add(new Guid("6695633c-183e-4546-aee4-b7c12b985585"));
		}

		#endregion

	}

	#endregion

}

