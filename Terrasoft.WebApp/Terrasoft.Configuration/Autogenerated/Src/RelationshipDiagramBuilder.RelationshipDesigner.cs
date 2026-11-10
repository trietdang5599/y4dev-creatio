namespace Terrasoft.Configuration.RelationshipDesigner
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.Serialization;
	using Terrasoft.Common;
	using Terrasoft.Core;
	using Terrasoft.Core.DB;
	using Terrasoft.Core.Entities;
	using Terrasoft.Core.Factories;
	using Terrasoft.Configuration.RightsService;
	using System.Data;

	#region Interface: IRelationshipDiagramBuilder

	public interface IRelationshipDiagramBuilder
	{
		DiagramInfo GetDiagram(Guid recordId, string schemaName);

		DiagramConfig GetDiagramConfig();

		// TODO DONT USE!!!!!!!!!!!!!!!!
		List<EntityInfo> GetEntitiesFromDiagram(Guid recordId, DiagramConfiguration diagramConfiguration);

		List<ConnectionInfo> GetDiagramConnections(IEnumerable<Guid> recordIds);

		List<Guid> GetOnlyConnectedEntities(Guid sourceRecordId, List<Guid> entities, List<ConnectionInfo> connections);
	}

	#endregion

	#region Class: RelationshipDiagramBuilder

	[DefaultBinding(typeof(IRelationshipDiagramBuilder), Name = "RelationshipDiagramBuilder")]
	public class RelationshipDiagramBuilder : IRelationshipDiagramBuilder
	{

		#region Fields: Private

		private readonly string defaultAccountImage = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1NiIgaGVpZ2h0PSI1NiIgdmlld0JveD0iMCAwIDU2IDU2Ij48ZGVmcz48c3R5bGU+LmF7ZmlsbDojMDA2Y2UwO30uYSwuYntvcGFjaXR5OjAuNDt9LmIsLmR7ZmlsbDojOTljNGYzO30uY3tmaWxsOiNjY2UxZjk7fS5le2ZpbGw6I2ZmZjt9LmYsLmh7ZmlsbDpub25lO30uZntzdHJva2U6I2U0ZTRlNDt9Lmd7c3Ryb2tlOm5vbmU7fTwvc3R5bGU+PC9kZWZzPjxwYXRoIGNsYXNzPSJhIiBkPSJNNTItOTE1LjVINzFWLTk1Nkg1MlpNNjIuNS05NTJINjl2Mi41SDYyLjVabTAsNS41SDY5djIuNUg2Mi41Wm0wLDUuNUg2OXYyLjVINjIuNVptMCw1LjVINjl2Mi41SDYyLjVaTTU0LTk1Mmg2LjV2Mi41SDU0Wm0wLDUuNWg2LjV2Mi41SDU0Wm0wLDUuNWg2LjV2Mi41SDU0Wm0wLDUuNWg2LjV2Mi41SDU0WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTM4IDk3MS41KSIvPjxwYXRoIGNsYXNzPSJiIiBkPSJNOTAtOTQ0djMuNWg2LjV2Mkg5MHYyaDYuNXYySDkwdjJoNi41djJIOTB2Mmg2LjV2Mkg5MHYxN2gxMFYtOTQ0WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTU3IDk2NS41KSIvPjxwYXRoIGNsYXNzPSJjIiBkPSJNNzMuMTUyLTk3NS4yOTRhMS4xODIsMS4xODIsMCwwLDAtLjkuNDU2LDIuMTI4LDIuMTI4LDAsMCwwLTEuODY3LTEuNDg0LDEuNzY4LDEuNzY4LDAsMCwwLTEuMi40OTJBMy4zMjYsMy4zMjYsMCwwLDAsNjYuMy05NzhhMy4xODMsMy4xODMsMCwwLDAtMi42ODIsMS43NiwxLjYxNiwxLjYxNiwwLDAsMC0uNS0uMDgyYy0xLjE3MSwwLTIuMTIsMS4yNjMtMi4xMiwyLjgyMUg3NC41Qzc0LjUtOTc0LjQ5LDczLjktOTc1LjI5NCw3My4xNTItOTc1LjI5NFoiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC00Mi41IDk4Mi41KSIvPjxwYXRoIGNsYXNzPSJkIiBkPSJNNTItOTc0LjY5M2ExLjksMS45LDAsMCwwLTEuMzI4LjU1OCwzLjExMywzLjExMywwLDAsMC0yLjc2NS0xLjgxMywyLjkzNSwyLjkzNSwwLDAsMC0xLjc3MS42QTQuOTMzLDQuOTMzLDAsMCwwLDQxLjg1Mi05NzhhNC44NjEsNC44NjEsMCwwLDAtMy45NzMsMi4xNTIsMi44NDgsMi44NDgsMCwwLDAtLjczOC0uMUEzLjMwNiwzLjMwNiwwLDAsMCwzNC05NzIuNUg1NEEyLjEsMi4xLDAsMCwwLDUyLTk3NC42OTNaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtMjkgOTgyLjUpIi8+PHBhdGggY2xhc3M9ImMiIGQ9Ik0xMTkuOC05NTYuOWExLjEwNiwxLjEwNiwwLDAsMC0uOC4zNTUsMS44NjgsMS44NjgsMCwwLDAtMS42NTktMS4xNTQsMS43LDEuNywwLDAsMC0xLjA2Mi4zODJBMi45NDYsMi45NDYsMCwwLDAsMTEzLjcxMS05NTlhMi44NzgsMi44NzgsMCwwLDAtMi4zODQsMS4zNywxLjYwOSwxLjYwOSwwLDAsMC0uNDQyLS4wNjNBMi4wNTcsMi4wNTcsMCwwLDAsMTA5LTk1NS41aDEyQTEuMzA4LDEuMzA4LDAsMCwwLDExOS44LTk1Ni45WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTY2LjUgOTczKSIvPjxwYXRoIGNsYXNzPSJiIiBkPSJNMjQuMDc5LTkwNy41LDI0LTkzNC41bDQtNS41SDM4djMyLjVaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtMjQgOTYzLjUpIi8+PHBhdGggY2xhc3M9ImEiIGQ9Ik0xMTAuMDczLTkwMywxMTAtOTI1LjVsNi41LTUuNSw2LjUsNS41Vi05MDNaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtNjcgOTU5KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg0IDM0KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg0IDI5KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg0IDM5KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg0IDQ0KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg5IDM0KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg5IDI5KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg5IDM5KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSIzIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg5IDQ0KSIvPjxnIHRyYW5zZm9ybT0idHJhbnNsYXRlKDE5LjQwMSAzNy41KSI+PHBhdGggY2xhc3M9ImMiIGQ9Ik03MS4yMzMtOTEwLjkxN2EzLjgzNSwzLjgzNSwwLDAsMC02LjEsMS44MTRjLS4wNDMuMTMyLS4xMTcuMjU1LS4xNTYuMzg4YS4xLjEsMCwwLDEsMCwuMDE0LDIuMzcxLDIuMzcxLDAsMCwwLTEuODU3LDEuODU0LDEuNTY3LDEuNTY3LDAsMCwwLS4wMDYuMTY3LDMuNywzLjcsMCwwLDAsLjI5NCwzLjUsMy42MywzLjYzLDAsMCwwLDMuMTc0LDEuNzkzYy4wMjguMDM4LjA1NC4wNzguMDgxLjExNWwxLjE3Mi4zNDMtLjA1OS0uMDg2Yy4wMzUuMDMzLjA2OS4wNjYuMS4xbC4wNDMuMDEyLS4wNDMtLjAxMmE5LjE4Nyw5LjE4NywwLDAsMSwuODUxLjlsMS4wMjcuMTkzLDAtLjAxMiwxLjQ0NS0uMDgzLjA2OS0xMS4wMzNaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtNjIuODAxIDkxMS44OTkpIi8+PHBhdGggY2xhc3M9ImQiIGQ9Ik04Ny43NDQtOTA3LjUwOWEuNDguNDgsMCwwLDAsMC0uMDY2LDIuODUxLDIuODUxLDAsMCwwLS4yOC0uOTc0LDIuNzcsMi43NywwLDAsMC0zLjEzNy0yLjA5LDMuNTkxLDMuNTkxLDAsMCwwLTEuNjctMS4yMDcsMi44MSwyLjgxLDAsMCwwLTMuMDA5LjhsLS4wNjksMTEuMDMyLjU2Ny0uMDMyLjc2OS0uMWMuMDY4LS4xNDQuMTM5LS4yODUuMjE1LS40MmEuNC40LDAsMCwxLC4yMjktLjIwNiw0LjU2OCw0LjU2OCwwLDAsMCwxLjA3Ny4zOTRsMCwuMDA3Ljc0NS4xNTNjLjAwOS0uMDMyLjAyMi0uMDY0LjAzMS0uMWEyLjY0OCwyLjY0OCwwLDAsMCwxLjI3MS0uNDE5LDIuNDkxLDIuNDkxLDAsMCwwLDEuMTIxLTEuODA5LjQ3My40NzMsMCwwLDEsLjQxNi0uMjg4LDIuNDkxLDIuNDkxLDAsMCwwLDIuMjQzLTIuMjgxQTMuOTQzLDMuOTQzLDAsMCwwLDg3Ljc0NC05MDcuNTA5WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTcxLjE4OSA5MTIpIi8+PHBhdGggY2xhc3M9ImUiIGQ9Ik03Ny45LTg4OS43NDRhNC44ODYsNC44ODYsMCwwLDEtMS4xMzcsMS45NzJjLS4zODYuNDA5LS44MjYuNzU1LTEuMjI1LDEuMTI5YTExLjkyOSwxMS45MjksMCwwLDEsLjg0My0yLjg3NmwtLjc2OC4xLjA0MSwwYS43NTYuNzU2LDAsMCwxLS4wNTMuMTQ3Yy0uMTcuMjg4LS4zLDEuMDQyLS41NjYsMS40NTJhLjU0My41NDMsMCwwLDEtLjM1MS4yNjhjLS4yNjMuMDQtLjg2My0xLjI4OC0xLjA3OS0xLjczN2wtMS4wMjctLjE5My4wMjQuMDI4YTMuNzE1LDMuNzE1LDAsMCwxLC40MzEsMS4wNjhjLS40MzQtLjY4Mi0uODg2LTEuMzUyLTEuMzQ5LTIuMDE0bC0xLjE3My0uMzQzYTU1LDU1LDAsMCwxLDMuNDMyLDUuMzYsNi4xMTcsNi4xMTcsMCwwLDEtLjMsMS4wMDVjLS4zMTkuODc4LS4wMjgsMS4zMjMuOTA4LDEuMzU3YTMuNzE5LDMuNzE5LDAsMCwwLC40MjMsMCwuMjM2LjIzNiwwLDAsMCwuMDI3LDAsLjcxMi43MTIsMCwwLDAsLjY1OC0uOTY1LDcuNjY5LDcuNjY5LDAsMCwxLS4zMTYtMS4wNDVjMC0uMDE3LDAtLjEuMDExLS4yMzIuNTM1LTEsMS43MTktMS41ODEsMi4zODctMi40ODdhNS43LDUuNywwLDAsMCwuOS0xLjgzNloiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC02Ni42NTYgOTAxLjM3KSIvPjwvZz48cGF0aCBjbGFzcz0iYyIgZD0iTTI0LjA3OC04ODQuNzcxaDIyLjY4YTMuMzI1LDMuMzI1LDAsMCwwLS42NTYtNC43ODRjLTEuNzc2LTEuNTY1LTMuNTUyLjc4Ny0zLjU1Mi43ODdzLjgzOC01Ljc2OC02LjExNS01Ljc2OGMtNi42MzMsMC01Ljc2NCw0Ljg0Ni01Ljc2NCw0Ljg0NlMyMy4xNTUtODkxLjg0MiwyNC4wNzgtODg0Ljc3MVoiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0yNCA5NDAuNzY4KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMyIgaGVpZ2h0PSI2IiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg0NiAzOSkiLz48cmVjdCBjbGFzcz0iZSIgd2lkdGg9IjIiIGhlaWdodD0iNiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoNTAgMzkpIi8+PHJlY3QgY2xhc3M9ImUiIHdpZHRoPSIzIiBoZWlnaHQ9IjUiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDQ2IDQ2KSIvPjxyZWN0IGNsYXNzPSJlIiB3aWR0aD0iMiIgaGVpZ2h0PSI1IiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg1MCA0NikiLz48cGF0aCBjbGFzcz0iYyIgZD0iTTEyMC4wNzktODgySDEwNi4xYTIuMDQ1LDIuMDQ1LDAsMCwxLDAtMy4yMzYsMi4yMywyLjIzLDAsMCwxLDIuNywwQTMuNTM4LDMuNTM4LDAsMCwxLDExMi42MzQtODg5YzQuMzMzLS4wNDIsNCwzLjUsNCwzLjVTMTIwLjcxOS04ODYuOSwxMjAuMDc5LTg4MloiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC02NC42MzQgOTM4KSIvPjxwYXRoIGNsYXNzPSJkIiBkPSJNNTEuNDczLTg3OS43MTdINjIuNTE2YTEuNiwxLjYsMCwwLDAtLjMxOS0yLjMxMWMtLjg2NS0uNzU1LTEuNzI5LjM4LTEuNzI5LjM4cy40MDgtMi43ODYtMi45NzgtMi43ODZjLTMuMjMsMC0yLjgwNywyLjM0MS0yLjgwNywyLjM0MVM1MS4wMjMtODgzLjEzMyw1MS40NzMtODc5LjcxN1oiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0zNy43MTcgOTM1LjcxNykiLz48Y2lyY2xlIGNsYXNzPSJlIiBjeD0iMS41IiBjeT0iMS41IiByPSIxLjUiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDQ4IDM0KSIvPjxnIGNsYXNzPSJmIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwKSI+PHJlY3QgY2xhc3M9ImciIHdpZHRoPSI1NiIgaGVpZ2h0PSI1NiIvPjxyZWN0IGNsYXNzPSJoIiB4PSIwLjUiIHk9IjAuNSIgd2lkdGg9IjU1IiBoZWlnaHQ9IjU1Ii8+PC9nPjwvc3ZnPg==";
		private readonly string defaultAccountNoAccessImage = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1NiIgaGVpZ2h0PSI1NiIgdmlld0JveD0iMCAwIDU2IDU2Ij48ZGVmcz48c3R5bGU+LmF7ZmlsbDojZmZmO30uYntmaWxsOiNjYWNhY2E7fS5je2ZpbGw6I2RkZDt9LmR7ZmlsbDojZTVlNWU1O30uZXtmaWxsOiM5MTkxOTE7fS5me2ZpbGw6I2E4YThhODt9Lmd7ZmlsbDojNmQ2ZDZkO30uaCwuantmaWxsOm5vbmU7fS5oe3N0cm9rZTojZTRlNGU0O30uaXtzdHJva2U6bm9uZTt9PC9zdHlsZT48L2RlZnM+PGcgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCkiPjxyZWN0IGNsYXNzPSJhIiB3aWR0aD0iNTYiIGhlaWdodD0iNTYiLz48L2c+PGcgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTI0IDk4NykiPjxwYXRoIGNsYXNzPSJiIiBkPSJNNTItOTE1LjVINzFWLTk1Nkg1MlpNNjIuNS05NTJINjl2Mi41SDYyLjVabTAsNS41SDY5djIuNUg2Mi41Wm0wLDUuNUg2OXYyLjVINjIuNVptMCw1LjVINjl2Mi41SDYyLjVaTTU0LTk1Mmg2LjV2Mi41SDU0Wm0wLDUuNWg2LjV2Mi41SDU0Wm0wLDUuNWg2LjV2Mi41SDU0Wm0wLDUuNWg2LjV2Mi41SDU0WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTE0IC0xNS41KSIvPjxwYXRoIGNsYXNzPSJjIiBkPSJNOTAtOTQ0djMuNWg2LjV2Mkg5MHYyaDYuNXYySDkwdjJoNi41djJIOTB2Mmg2LjV2Mkg5MHYxN2gxMFYtOTQ0WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTMzIC0yMS41KSIvPjxwYXRoIGNsYXNzPSJkIiBkPSJNNzMuMTUyLTk3NS4yOTRhMS4xODIsMS4xODIsMCwwLDAtLjkuNDU2LDIuMTI4LDIuMTI4LDAsMCwwLTEuODY3LTEuNDg0LDEuNzY4LDEuNzY4LDAsMCwwLTEuMi40OTJBMy4zMjYsMy4zMjYsMCwwLDAsNjYuMy05NzhhMy4xODMsMy4xODMsMCwwLDAtMi42ODIsMS43NiwxLjYxNiwxLjYxNiwwLDAsMC0uNS0uMDgyYy0xLjE3MSwwLTIuMTIsMS4yNjMtMi4xMiwyLjgyMUg3NC41Qzc0LjUtOTc0LjQ5LDczLjktOTc1LjI5NCw3My4xNTItOTc1LjI5NFoiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC0xOC41IC00LjUpIi8+PHBhdGggY2xhc3M9ImIiIGQ9Ik01Mi05NzQuNjkzYTEuOSwxLjksMCwwLDAtMS4zMjguNTU4LDMuMTEzLDMuMTEzLDAsMCwwLTIuNzY1LTEuODEzLDIuOTM1LDIuOTM1LDAsMCwwLTEuNzcxLjZBNC45MzMsNC45MzMsMCwwLDAsNDEuODUyLTk3OGE0Ljg2MSw0Ljg2MSwwLDAsMC0zLjk3MywyLjE1MiwyLjg0OCwyLjg0OCwwLDAsMC0uNzM4LS4xQTMuMzA2LDMuMzA2LDAsMCwwLDM0LTk3Mi41SDU0QTIuMSwyLjEsMCwwLDAsNTItOTc0LjY5M1oiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC01IC00LjUpIi8+PHBhdGggY2xhc3M9ImMiIGQ9Ik0xMTkuOC05NTYuOWExLjEwNiwxLjEwNiwwLDAsMC0uOC4zNTUsMS44NjgsMS44NjgsMCwwLDAtMS42NTktMS4xNTQsMS43LDEuNywwLDAsMC0xLjA2Mi4zODJBMi45NDYsMi45NDYsMCwwLDAsMTEzLjcxMS05NTlhMi44NzgsMi44NzgsMCwwLDAtMi4zODQsMS4zNywxLjYwOSwxLjYwOSwwLDAsMC0uNDQyLS4wNjNBMi4wNTcsMi4wNTcsMCwwLDAsMTA5LTk1NS41aDEyQTEuMzA4LDEuMzA4LDAsMCwwLDExOS44LTk1Ni45WiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTQyLjUgLTE0KSIvPjxwYXRoIGNsYXNzPSJkIiBkPSJNMjQuMDc5LTkwNy41LDI0LTkzNC41bDQtNS41SDM4djMyLjVaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwIC0yMy41KSIvPjxwYXRoIGNsYXNzPSJiIiBkPSJNMTEwLjA3My05MDMsMTEwLTkyNS41bDYuNS01LjUsNi41LDUuNVYtOTAzWiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTQzIC0yOCkiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMjggLTk1MykiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMjggLTk1OCkiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMjggLTk0OCkiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMjggLTk0MykiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMzMgLTk1MykiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMzMgLTk1OCkiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMzMgLTk0OCkiLz48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjMiIGhlaWdodD0iMyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMzMgLTk0MykiLz48ZyB0cmFuc2Zvcm09InRyYW5zbGF0ZSg0My40IC05NDkuNSkiPjxwYXRoIGNsYXNzPSJlIiBkPSJNNzEuMjMzLTkxMC45MTdhMy44MzUsMy44MzUsMCwwLDAtNi4xLDEuODE0Yy0uMDQzLjEzMi0uMTE3LjI1NS0uMTU2LjM4OGEuMS4xLDAsMCwxLDAsLjAxNCwyLjM3MSwyLjM3MSwwLDAsMC0xLjg1NywxLjg1NCwxLjU2NywxLjU2NywwLDAsMC0uMDA2LjE2NywzLjcsMy43LDAsMCwwLC4yOTQsMy41LDMuNjMsMy42MywwLDAsMCwzLjE3NCwxLjc5M2MuMDI4LjAzOC4wNTQuMDc4LjA4MS4xMTVsMS4xNzIuMzQzLS4wNTktLjA4NmMuMDM1LjAzMy4wNjkuMDY2LjEuMWwuMDQzLjAxMi0uMDQzLS4wMTJhOS4xODcsOS4xODcsMCwwLDEsLjg1MS45bDEuMDI3LjE5MywwLS4wMTIsMS40NDUtLjA4My4wNjktMTEuMDMzWiIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoLTYyLjgwMSA5MTEuODk5KSIvPjxwYXRoIGNsYXNzPSJmIiBkPSJNODcuNzQ0LTkwNy41MDlhLjQ4LjQ4LDAsMCwwLDAtLjA2NiwyLjg1MSwyLjg1MSwwLDAsMC0uMjgtLjk3NCwyLjc3LDIuNzcsMCwwLDAtMy4xMzctMi4wOSwzLjU5MSwzLjU5MSwwLDAsMC0xLjY3LTEuMjA3LDIuODEsMi44MSwwLDAsMC0zLjAwOS44bC0uMDY5LDExLjAzMi41NjctLjAzMi43NjktLjFjLjA2OC0uMTQ0LjEzOS0uMjg1LjIxNS0uNDJhLjQuNCwwLDAsMSwuMjI5LS4yMDYsNC41NjgsNC41NjgsMCwwLDAsMS4wNzcuMzk0bDAsLjAwNy43NDUuMTUzYy4wMDktLjAzMi4wMjItLjA2NC4wMzEtLjFhMi42NDgsMi42NDgsMCwwLDAsMS4yNzEtLjQxOSwyLjQ5MSwyLjQ5MSwwLDAsMCwxLjEyMS0xLjgwOS40NzMuNDczLDAsMCwxLC40MTYtLjI4OCwyLjQ5MSwyLjQ5MSwwLDAsMCwyLjI0My0yLjI4MUEzLjk0MywzLjk0MywwLDAsMCw4Ny43NDQtOTA3LjUwOVoiIHRyYW5zZm9ybT0idHJhbnNsYXRlKC03MS4xODkgOTEyKSIvPjxwYXRoIGNsYXNzPSJnIiBkPSJNNzcuOS04ODkuNzQ0YTQuODg2LDQuODg2LDAsMCwxLTEuMTM3LDEuOTcyYy0uMzg2LjQwOS0uODI2Ljc1NS0xLjIyNSwxLjEyOWExMS45MjksMTEuOTI5LDAsMCwxLC44NDMtMi44NzZsLS43NjguMS4wNDEsMGEuNzU2Ljc1NiwwLDAsMS0uMDUzLjE0N2MtLjE3LjI4OC0uMywxLjA0Mi0uNTY2LDEuNDUyYS41NDMuNTQzLDAsMCwxLS4zNTEuMjY4Yy0uMjYzLjA0LS44NjMtMS4yODgtMS4wNzktMS43MzdsLTEuMDI3LS4xOTMuMDI0LjAyOGEzLjcxNSwzLjcxNSwwLDAsMSwuNDMxLDEuMDY4Yy0uNDM0LS42ODItLjg4Ni0xLjM1Mi0xLjM0OS0yLjAxNGwtMS4xNzMtLjM0M2E1NSw1NSwwLDAsMSwzLjQzMiw1LjM2LDYuMTE3LDYuMTE3LDAsMCwxLS4zLDEuMDA1Yy0uMzE5Ljg3OC0uMDI4LDEuMzIzLjkwOCwxLjM1N2EzLjcxOSwzLjcxOSwwLDAsMCwuNDIzLDAsLjIzNi4yMzYsMCwwLDAsLjAyNywwLC43MTIuNzEyLDAsMCwwLC42NTgtLjk2NSw3LjY2OSw3LjY2OSwwLDAsMS0uMzE2LTEuMDQ1YzAtLjAxNywwLS4xLjAxMS0uMjMyLjUzNS0xLDEuNzE5LTEuNTgxLDIuMzg3LTIuNDg3YTUuNyw1LjcsMCwwLDAsLjktMS44MzZaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtNjYuNjU2IDkwMS4zNykiLz48L2c+PHBhdGggY2xhc3M9ImYiIGQ9Ik0yNC4wNzgtODg0Ljc3MWgyMi42OGEzLjMyNSwzLjMyNSwwLDAsMC0uNjU2LTQuNzg0Yy0xLjc3Ni0xLjU2NS0zLjU1Mi43ODctMy41NTIuNzg3cy44MzgtNS43NjgtNi4xMTUtNS43NjhjLTYuNjMzLDAtNS43NjQsNC44NDYtNS43NjQsNC44NDZTMjMuMTU1LTg5MS44NDIsMjQuMDc4LTg4NC43NzFaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwIC00Ni4yMzIpIi8+PHJlY3QgY2xhc3M9ImEiIHdpZHRoPSIzIiBoZWlnaHQ9IjYiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDcwIC05NDgpIi8+PHJlY3QgY2xhc3M9ImEiIHdpZHRoPSIyIiBoZWlnaHQ9IjYiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDc0IC05NDgpIi8+PHJlY3QgY2xhc3M9ImEiIHdpZHRoPSIzIiBoZWlnaHQ9IjUiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDcwIC05NDEpIi8+PHJlY3QgY2xhc3M9ImEiIHdpZHRoPSIyIiBoZWlnaHQ9IjUiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDc0IC05NDEpIi8+PHBhdGggY2xhc3M9ImYiIGQ9Ik0xMjAuMDc5LTg4MkgxMDYuMWEyLjA0NSwyLjA0NSwwLDAsMSwwLTMuMjM2LDIuMjMsMi4yMywwLDAsMSwyLjcsMEEzLjUzOCwzLjUzOCwwLDAsMSwxMTIuNjM0LTg4OWM0LjMzMy0uMDQyLDQsMy41LDQsMy41UzEyMC43MTktODg2LjksMTIwLjA3OS04ODJaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtNDAuNjM0IC00OSkiLz48cGF0aCBjbGFzcz0iZSIgZD0iTTUxLjQ3My04NzkuNzE3SDYyLjUxNmExLjYsMS42LDAsMCwwLS4zMTktMi4zMTFjLS44NjUtLjc1NS0xLjcyOS4zOC0xLjcyOS4zOHMuNDA4LTIuNzg2LTIuOTc4LTIuNzg2Yy0zLjIzLDAtMi44MDcsMi4zNDEtMi44MDcsMi4zNDFTNTEuMDIzLTg4My4xMzMsNTEuNDczLTg3OS43MTdaIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgtMTMuNzE3IC01MS4yODMpIi8+PGNpcmNsZSBjbGFzcz0iYSIgY3g9IjEuNSIgY3k9IjEuNSIgcj0iMS41IiB0cmFuc2Zvcm09InRyYW5zbGF0ZSg3MiAtOTUzKSIvPjxnIGNsYXNzPSJoIiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgyNCAtOTg3KSI+PHJlY3QgY2xhc3M9ImkiIHdpZHRoPSI1NiIgaGVpZ2h0PSI1NiIvPjxyZWN0IGNsYXNzPSJqIiB4PSIwLjUiIHk9IjAuNSIgd2lkdGg9IjU1IiBoZWlnaHQ9IjU1Ii8+PC9nPjwvZz48L3N2Zz4=";
		private readonly string defaultContactImage = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1NiIgaGVpZ2h0PSI1NiIgdmlld0JveD0iMCAwIDU2IDU2Ij48ZGVmcz48c3R5bGU+LmF7ZmlsbDojZmZmO30uYntmaWxsOiMwMDZjZTA7b3BhY2l0eTowLjQ7fTwvc3R5bGU+PC9kZWZzPjxyZWN0IGNsYXNzPSJhIiB3aWR0aD0iNTYiIGhlaWdodD0iNTYiLz48cGF0aCBjbGFzcz0iYiIgZD0iTTU1LjQ1LDQ5LjM0NCwzOS43LDQyLjgyNWwtLjYtMS43NjljLS4yLS42MDUtLjQ1LTEuMjExLTEuMDUtMS4zNWEuNzQ5Ljc0OSwwLDAsMS0uNDUtLjYwNWwtLjM1LTMuNDkyYTEuMDE3LDEuMDE3LDAsMCwxLC4zLS43NDUsNy42ODcsNy42ODcsMCwwLDAsMS44LTMuOTU4LDE4Ljg3NSwxOC44NzUsMCwwLDEsLjc1LTIuMTg5bC44NS00LjE0NGMuMS0uNTU5LjA1LS45NzgtLjYtMS4xNjQtLjItLjA0Ny0uMzUtLjMyNi0uMzUtLjc0NSwwLDAsLjgtNS40LjU1LTcuMzExLS4zNS0yLjUxNS0yLjQtNy41OS04LTcuMzExLTE0LjktNC4wNTEtMTMuOCwyLjctMTguOTUsNC43YTMuMzE3LDMuMzE3LDAsMCwwLDMuMjUuNTU5Yy0uMjUuMTg2LTIuMDUuMjc5LTIuOSwzLjYzMmE0Ljk3Niw0Ljk3NiwwLDAsMSwyLjMtMS42M2MtMS43Ljg4NS0uMTUsNi4xOTMtLjEsNi43MDV2LjdjMCwuMzI2LS4xNS43LS4zNS43NDUtLjY1LjIzMy0uNjUuNjUyLS42LDEuMTY0bC44NSw0LjE0NGExOC44NzUsMTguODc1LDAsMCwxLC43NSwyLjE4OSw3LjY4Nyw3LjY4NywwLDAsMCwxLjgsMy45NTgsMS4yNjgsMS4yNjgsMCwwLDEsLjMuNzQ1bC0uMzUsMy40OTJjLS4wNS4yMzMtLjI1LjU1OS0uNDUuNjA1YTEuNjQsMS42NCwwLDAsMC0xLjA1LDEuMzVsLS42LDEuNzY5TC41NSw0OS4zNDRhLjk4OC45ODgsMCwwLDAtLjU1Ljg4NVY1NS43N0g1NlY1MC4yMjlhLjk4OC45ODgsMCwwLDAtLjU1LS44ODUiIHRyYW5zZm9ybT0idHJhbnNsYXRlKDAgMC4yMykiLz48L3N2Zz4=";
		private readonly string defaultContactNoAccessImage = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHdpZHRoPSI1NiIgaGVpZ2h0PSI1NiIgdmlld0JveD0iMCAwIDU2IDU2Ij48ZGVmcz48c3R5bGU+LmF7ZmlsbDojZmZmO30uYntmaWxsOiNjYWNhY2E7fTwvc3R5bGU+PC9kZWZzPjxnIHRyYW5zZm9ybT0idHJhbnNsYXRlKDApIj48cmVjdCBjbGFzcz0iYSIgd2lkdGg9IjU2IiBoZWlnaHQ9IjU2Ii8+PHBhdGggY2xhc3M9ImIiIGQ9Ik01NS40NSw0OS4zNDQsMzkuNyw0Mi44MjVsLS42LTEuNzY5Yy0uMi0uNjA1LS40NS0xLjIxMS0xLjA1LTEuMzVhLjc0OS43NDksMCwwLDEtLjQ1LS42MDVsLS4zNS0zLjQ5MmExLjAxNywxLjAxNywwLDAsMSwuMy0uNzQ1LDcuNjg3LDcuNjg3LDAsMCwwLDEuOC0zLjk1OCwxOC44NzUsMTguODc1LDAsMCwxLC43NS0yLjE4OWwuODUtNC4xNDRjLjEtLjU1OS4wNS0uOTc4LS42LTEuMTY0LS4yLS4wNDctLjM1LS4zMjYtLjM1LS43NDUsMCwwLC44LTUuNC41NS03LjMxMS0uMzUtMi41MTUtMi40LTcuNTktOC03LjMxMS0xNC45LTQuMDUxLTEzLjgsMi43LTE4Ljk1LDQuN2EzLjMxNywzLjMxNywwLDAsMCwzLjI1LjU1OWMtLjI1LjE4Ni0yLjA1LjI3OS0yLjksMy42MzJhNC45NzYsNC45NzYsMCwwLDEsMi4zLTEuNjNjLTEuNy44ODUtLjE1LDYuMTkzLS4xLDYuNzA1di43YzAsLjMyNi0uMTUuNy0uMzUuNzQ1LS42NS4yMzMtLjY1LjY1Mi0uNiwxLjE2NGwuODUsNC4xNDRhMTguODc1LDE4Ljg3NSwwLDAsMSwuNzUsMi4xODksNy42ODcsNy42ODcsMCwwLDAsMS44LDMuOTU4LDEuMjY4LDEuMjY4LDAsMCwxLC4zLjc0NWwtLjM1LDMuNDkyYy0uMDUuMjMzLS4yNS41NTktLjQ1LjYwNWExLjY0LDEuNjQsMCwwLDAtMS4wNSwxLjM1bC0uNiwxLjc2OUwuNTUsNDkuMzQ0YS45ODguOTg4LDAsMCwwLS41NS44ODVWNTUuNzdINTZWNTAuMjI5YS45ODguOTg4LDAsMCwwLS41NS0uODg1IiB0cmFuc2Zvcm09InRyYW5zbGF0ZSgwIDAuMjMpIi8+PC9nPjwvc3ZnPg==";
		private readonly string toggleCollapse = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdib3g9IjAgMCAxMCA0IiBoZWlnaHQ9IjQiIHdpZHRoPSIxMCI+DQoJPGc+DQoJCTxwYXRoIGZpbGw9Im5vbmUiIHN0cm9rZT0iIzYwNzc5RiIgZD0iTTAuNSAzLjUgTDUgMC41IEw5LjUgMy41IiAvPg0KCTwvZz4NCjwvc3ZnPg==";
		private readonly string toggleExpand = "data:image/svg+xml;base64,PHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZpZXdib3g9IjAgMCAxMCA0IiBoZWlnaHQ9IjQiIHdpZHRoPSIxMCI+Cgk8Zz4KCQk8cGF0aCBmaWxsPSJub25lIiBzdHJva2U9IiM2MDc3OUYiIGQ9Ik0wLjUgMC41IEw1IDMuNSBMOS41IDAuNSIgLz4KCTwvZz4KPC9zdmc+";

		private readonly string RelationshipTypeEnum_RelationshipItem = "relationship-item";
		private readonly string RelationshipTypeEnum_RelationshipContainer = "relationship-container";
		private readonly string RelationshipTypeEnum_Connection = "connection";
		private readonly string RelationshipTypeEnum_IndirectConnection = "indirect-connection";
		private readonly string RelationshipTypeEnum_ParentConnection = "parent-connection";

		private readonly Guid RelationConnectionType_Formal = RelationshipDesignerConstants.RelationTypeConnectionType_Formal;
		private readonly string ConnectionLabel_Type = "label";

		private readonly int _queryMaxParametersCount = 2000;

		private RightsHelper _rightsHelper;
		private IRelationshipDiagramConfigProvider _diagramConfigProvider;
		private IRelationshipDiagramManager _diagramManager;

		#endregion

		#region Constructors: Public

		public RelationshipDiagramBuilder(UserConnection userConnection) {
			this.UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		/// <summary>
		/// User connection.
		/// </summary>
		private UserConnection UserConnection {
			get; set;
		}

		public RightsHelper RightsHelper =>
			_rightsHelper ?? (_rightsHelper = ClassFactory.Get<RightsHelper>(
				new ConstructorArgument("userConnection", UserConnection)));

		public IRelationshipDiagramConfigProvider DiagramConfigProvider =>
			_diagramConfigProvider ?? (_diagramConfigProvider = ClassFactory.Get<IRelationshipDiagramConfigProvider>());

		public IRelationshipDiagramManager DiagramManager =>
			_diagramManager ?? (_diagramManager = ClassFactory.Get<IRelationshipDiagramManager>(
				new ConstructorArgument("userConnection", UserConnection)));

		#endregion

		#region Methods: Private

		#region DiagramConfig
		private List<DiagramElement> GetDiagramElementsConfigMockData() {
			var accountSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Account");
			var contactSchema = UserConnection.EntitySchemaManager.GetInstanceByName("Contact");
			var noAccessCaption = UserConnection.GetLocalizableString(GetType().Name, "NoAccessElementCaption");
			return new List<DiagramElement> {
					new DiagramElement() {
						Caption = accountSchema.Name,
						CaptionNoAccess = noAccessCaption,
						Width = 300,
						Height = 56,
						ImageWidth = 56,
						ImageHeight = 56,
						Fill = "#F8F9FE",
						FillInParent = "#FFFFFF",
						Stroke = "#E4E4E4",
						RelationshipType = RelationshipTypeEnum_RelationshipContainer,
						LargeImage = defaultAccountImage,
						LargeImageNoAccess = defaultAccountNoAccessImage,
						EntitySchemaData = new EntitySchemaData {
							Name = accountSchema.Name,
							Caption = accountSchema.Caption,
							UId = accountSchema.UId
						}
					},
					new DiagramElement() {
						Caption = contactSchema.Name,
						CaptionNoAccess = noAccessCaption,
						Width = 300,
						Height = 56,
						ImageWidth = 56,
						ImageHeight = 56,
						Fill = "#F8F9FE",
						FillInParent = "#FFFFFF",
						Stroke = "#E4E4E4",
						RelationshipType = RelationshipTypeEnum_RelationshipItem,
						LargeImage = defaultContactImage,
						LargeImageNoAccess = defaultContactNoAccessImage,
						EntitySchemaData = new EntitySchemaData {
							Name = contactSchema.Name,
							Caption = contactSchema.Caption,
							UId = contactSchema.UId
						}
					},
					new DiagramElement() {
						RelationshipType = RelationshipTypeEnum_IndirectConnection
					}
			};
		}
		private string GetImageUrl(string elementName) {
			return string.Format("../img/resource-manager/hash/Terrasoft.Nui/{0}", elementName);
		}

		private ElementToolsConfig GetElementToolsConfig() {
			return new ElementToolsConfig {
				AddItems = new List<ToolItem>(),
				Tools = new ToolObject {
					Add = new ToolItem {
						ImageUrl = "data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjQiIGhlaWdodD0iMjQiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyI+CiA8IS0tIENyZWF0ZWQgd2l0aCBNZXRob2QgRHJhdyAtIGh0dHA6Ly9naXRodWIuY29tL2R1b3BpeGVsL01ldGhvZC1EcmF3LyAtLT4KIDxnPgogIDx0aXRsZT5iYWNrZ3JvdW5kPC90aXRsZT4KICA8cmVjdCBmaWxsPSJub25lIiBpZD0iY2FudmFzX2JhY2tncm91bmQiIGhlaWdodD0iMjYiIHdpZHRoPSIyNiIgeT0iLTEiIHg9Ii0xIi8+CiAgPGcgZGlzcGxheT0ibm9uZSIgb3ZlcmZsb3c9InZpc2libGUiIHk9IjAiIHg9IjAiIGhlaWdodD0iMTAwJSIgd2lkdGg9IjEwMCUiIGlkPSJjYW52YXNHcmlkIj4KICAgPHJlY3QgZmlsbD0idXJsKCNncmlkcGF0dGVybikiIHN0cm9rZS13aWR0aD0iMCIgeT0iMCIgeD0iMCIgaGVpZ2h0PSIxMDAlIiB3aWR0aD0iMTAwJSIvPgogIDwvZz4KIDwvZz4KIDxnPgogIDx0aXRsZT5MYXllciAxPC90aXRsZT4KICA8dGV4dCB4bWw6c3BhY2U9InByZXNlcnZlIiB0ZXh0LWFuY2hvcj0ic3RhcnQiIGZvbnQtZmFtaWx5PSJIZWx2ZXRpY2EsIEFyaWFsLCBzYW5zLXNlcmlmIiBmb250LXNpemU9IjI0IiBpZD0ic3ZnXzEiIHk9IjIwLjMxNDE4IiB4PSI0Ljk4NTc5IiBzdHJva2Utd2lkdGg9IjAiIHN0cm9rZT0iIzAwMCIgZmlsbD0iIzU0NjU3ZCI+KzwvdGV4dD4KIDwvZz4KPC9zdmc+"
					},
					Connect = new ToolItem {
						ImageUrl = GetImageUrl("ProcessSchemaDesigner.ElementTools.ArrowToolsImage.svg")

					},
					Setup = new ToolItem {
						ImageUrl = GetImageUrl("ProcessSchemaDesigner.ElementTools.SetupToolsImage.svg")
					},
					Delete = new ToolItem {
						ImageUrl = GetImageUrl("ProcessSchemaDesigner.ElementTools.DeleteToolsImage.svg")
					}
				},
				InnerTools = new InnerToolObject {
					Toggle = new InnerToolItem {
						ExpandImageUrl = toggleExpand,
						CollapseImageUrl = toggleCollapse
					}
				}
			};
		}

		#endregion

		private string GetEntityImage(Entity entity, string columnName, string defaultValue) {
			var imageId = entity.GetTypedColumnValue<Guid>(columnName);
			if (imageId.IsEmpty()) {
				return defaultValue;
			}
			try {
				var imageEntity = UserConnection.EntitySchemaManager.GetInstanceByName("SysImage")
					.CreateEntity(UserConnection);
				imageEntity.FetchFromDB("Id", imageId);
				var mimeType = imageEntity.GetTypedColumnValue<string>("MimeType");
				var fileContent = Convert.ToBase64String(imageEntity.GetBytesValue("Data"));
				var result = $"data:{mimeType};base64,{fileContent}";
				return result;
			} catch (Exception e) {
				return defaultValue;
			}
		}

		private bool IsFirstLevel(Guid schemaUId, DiagramConfiguration configuration) {
			return configuration.FirstLevelConfig.SchemaUId == schemaUId;
		}

		private Guid GetDiagramIdByEntityRecordId(Guid entityRecordId) {
			var entitySelect = new Select(UserConnection)
				.Column("RelationEntInDiagram", "RelationshipDiagramId")
				.From("RelationEntInDiagram")
				.InnerJoin("RelationshipEntity")
					.On("RelationEntInDiagram", "RelationshipEntityId")
					.IsEqual("RelationshipEntity", "Id")
				.Where("RecordId").IsEqual(Column.Parameter(entityRecordId)) as Select;
			return entitySelect.ExecuteScalar<Guid>();
		}

		private List<ConnectionLabel> GetConnectionLabels(List<ConnectionInfo> connections) {
			List<ConnectionLabel> connectionLabels = new List<ConnectionLabel>();
			var notEmptyConnections = connections.Where(e => !string.IsNullOrEmpty(e.Comment)).ToList();
			foreach (ConnectionInfo connectionInfo in notEmptyConnections) {
				connectionLabels.Add(new ConnectionLabel {
					Caption = connectionInfo.Comment,
					Type = ConnectionLabel_Type,
					Parent = connectionInfo.Id
				});
			}
			return connectionLabels;
		}

		private Dictionary<Guid, RelationshipGroup> GetRelationshipGroupWithEntities(Guid diagramId) {
			Dictionary<Guid, RelationshipGroup> relationshipGroupDictionary = new Dictionary<Guid, RelationshipGroup>();
			var groupSelect = new Select(UserConnection)
				.Column("RelationshipGroup", "Id").As("Id")
				.Column("RelationshipGroup", "Name").As("Name")
				.Column("RelationshipGroup", "Color").As("Color")
				.Column("RelationshipGroup", "Comment").As("Comment")
				.Column("RelationEntityInGroup", "RelationshipEntityId").As("RelationshipEntityId")
				.From("RelationshipGroup").As("RelationshipGroup")
				.InnerJoin("RelationEntityInGroup").As("RelationEntityInGroup")
					.On("RelationEntityInGroup", "RelationshipGroupId").IsEqual("RelationshipGroup", "Id")
				.InnerJoin("RelationEntInDiagram").As("RelationEntInDiagram")
					.On("RelationEntInDiagram", "RelationshipEntityId").IsEqual("RelationEntityInGroup", "RelationshipEntityId")
				.Where("RelationEntInDiagram", "RelationshipDiagramId").IsEqual(Column.Parameter(diagramId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = groupSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var entityId = reader.GetColumnValue<Guid>("RelationshipEntityId");
						var groupId = reader.GetColumnValue<Guid>("Id");
						var name = reader.GetColumnValue<string>("Name");
						var color = reader.GetColumnValue<string>("Color");
						var comment = reader.GetColumnValue<string>("Comment");
						var relationshipGroup = new RelationshipGroup();
						if (relationshipGroupDictionary.TryGetValue(groupId, out relationshipGroup)) {
							relationshipGroup.Entities.AddIfNotExists(entityId);
						} else {
							relationshipGroupDictionary.Add(groupId, new RelationshipGroup {
								Caption = name,
								Id = groupId,
								Color = color,
								Comment = comment,
								Entities = new List<Guid> { entityId }
							});
						}
					}
				}
			}

			return relationshipGroupDictionary;
		}

		private Dictionary<Guid, List<RelationshipInGroup>> GetRelationshipEntetiesInGroups(Guid diagramId) {
			Dictionary<Guid, List<RelationshipInGroup>> relationshipEntetiesInGroups = new Dictionary<Guid, List<RelationshipInGroup>>();
			var groupSelect = new Select(UserConnection)
				.Column("RelationEntityInGroup", "RelationshipEntityId").As("EntityId")
				.Column("RelationEntityInGroup", "RelationshipGroupId").As("GroupId")
				.Column("RelationEntityInGroup", "Comment").As("Comment")
				.From("RelationEntityInGroup").As("RelationEntityInGroup")
				.InnerJoin("RelationEntInDiagram").As("RelationEntInDiagram")
					.On("RelationEntInDiagram", "RelationshipEntityId").IsEqual("RelationEntityInGroup", "RelationshipEntityId")
				.Where("RelationEntInDiagram", "RelationshipDiagramId").IsEqual(Column.Parameter(diagramId)) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = groupSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var entityId = reader.GetColumnValue<Guid>("EntityId");
						var groupId = reader.GetColumnValue<Guid>("GroupId");
						var comment = reader.GetColumnValue<string>("Comment");
						var relationshipInGroup = new RelationshipInGroup {
							GroupId = groupId,
							Comment = comment
						};
						if (relationshipEntetiesInGroups.ContainsKey(entityId)) {
							relationshipEntetiesInGroups[entityId].Add(relationshipInGroup);
						} else {
							var entetiesInGroups = new List<RelationshipInGroup>();
							entetiesInGroups.Add(relationshipInGroup);
							relationshipEntetiesInGroups[entityId] = entetiesInGroups;
						}
					}
				}
			}
			return relationshipEntetiesInGroups;
		}


		private List<EntityInfo> AddGroupsToEntities(List<EntityInfo> entities, Dictionary<Guid, List<RelationshipInGroup>> relationshipEntetiesInGroups) {
			var resultEntities = new List<EntityInfo>();
			foreach (var entity in entities) {
				if (relationshipEntetiesInGroups.Any() && entity.CanRead && relationshipEntetiesInGroups.ContainsKey(entity.Id)) {
					entity.Groups = relationshipEntetiesInGroups[entity.Id];
				}
				resultEntities.Add(entity);
			}
			return resultEntities;
		}

		private List<ConnectionInfo> ApplyEntitiesRightsToConnections(List<EntityInfo> diagramEntities, List<ConnectionInfo> diagramConnections) {
			foreach (ConnectionInfo diagramConnection in diagramConnections) {
				var sourceOrTargetCanNotRead = diagramEntities
					.Any(entity => (entity.Id == diagramConnection.Source || entity.Id == diagramConnection.Target) && !entity.CanRead);
				if (sourceOrTargetCanNotRead) {
					diagramConnection.Comment = string.Empty;
				}
			}
			return diagramConnections;
		}

		private string GetConnectionType(Guid connectionType, bool includeIntoContainer) {
			if (connectionType.Equals(RelationConnectionType_Formal)) {
				return includeIntoContainer ? RelationshipTypeEnum_ParentConnection : RelationshipTypeEnum_Connection;
			} else {
				return RelationshipTypeEnum_IndirectConnection;
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns part of diagram connections.
		/// </summary>
		/// <param name="recordIds">Part of entities ids.</param>
		/// <param name="isOrCondition">Is apply OR condition for entities.</param>
		/// <returns>Diagram connections.</returns>
		protected List<ConnectionInfo> GetPartDiagramConnections(IEnumerable<Guid> recordIds, bool isOrCondition = false) {
			var result = new List<ConnectionInfo>();
			if (recordIds.IsEmpty()) {
				return result;
			}
			var entityConnectionsSelect = GetDiagramConnectionsSelect(recordIds, isOrCondition);
			entityConnectionsSelect.ExecuteReader((reader) => {
				result.Add(CreateDigramConnection(reader));
			});
			return result;
		}

		/// <summary>
		/// Returns diagram connections select.
		/// </summary>
		/// <param name="recordIds">Entities ids.</param>
		/// <param name="isOrCondition">Is apply OR condition for entities.</param>
		/// <returns>Select.</returns>
		protected Select GetDiagramConnectionsSelect(IEnumerable<Guid> recordIds, bool isOrCondition = false) {
			Guid currentUserCultureId = UserConnection.CurrentUser.SysCultureId;
			var select = new Select(UserConnection)
				.Column("RC", "Id")
				.Column("RC", "RelationshipEntityAId")
				.Column("RC", "RelationshipEntityBId")
				.Column("RC", "Comment")
				.Column("RC", "Name")
				.Column("RT", "Id").As("RelationTypeId")
				.Column(Func.IsNull(Column.SourceColumn("SRTL", "Name"), Column.SourceColumn("RT", "Name"))).As("RelationTypeName")
				.Column("RT", "IncludeIntoContainer").As("IncludeIntoContainer")
				.Column(Func.IsNull(Column.SourceColumn("SRRTL", "Name"), Column.SourceColumn("RRT", "Name"))).As("ReverseRelationTypeName")
				.Column("RCT", "Id").As("RelationConnectionTypeId")
				.Column(Func.IsNull(Column.SourceColumn("SRCTL", "Name"), Column.SourceColumn("RCT", "Name"))).As("RelationConnectionTypeName")
				.Column("EntityA", "SchemaUId").As("EntityASchemaUId")
				.Column("EntityB", "SchemaUId").As("EntityBSchemaUId")
				.Column("RTP", "Value").As("Position")
				.From("RelationshipConnection").As("RC")
				.InnerJoin("RelationshipEntity").As("EntityA").On("EntityA", "Id").IsEqual("RC", "RelationshipEntityAId")
				.InnerJoin("RelationshipEntity").As("EntityB").On("EntityB", "Id").IsEqual("RC", "RelationshipEntityBId")
				.LeftOuterJoin("RelationType").As("RT").On("RC", "RelationTypeId").IsEqual("RT", "Id")
				.LeftOuterJoin("SysRelationTypeLcz").As("SRTL").On("RT", "Id").IsEqual("SRTL", "RecordId")
					.And("SRTL", "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId))
				.LeftOuterJoin("RelationConnectionType").As("RCT").On("RT", "RelationConnectionTypeId").IsEqual("RCT", "Id")
				.LeftOuterJoin("SysRelationConnectionTypeLcz").As("SRCTL").On("RCT", "Id").IsEqual("SRCTL", "RecordId")
					.And("SRCTL", "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId))
				.LeftOuterJoin("RelationTypePosition").As("RTP").On("RT", "PositionId").IsEqual("RTP", "Id")
				.LeftOuterJoin("RelationType").As("RRT").On("RT", "ReverseRelationTypeId").IsEqual("RRT", "Id")
				.LeftOuterJoin("SysRelationTypeLcz").As("SRRTL").On("RRT", "Id").IsEqual("SRRTL", "RecordId")
					.And("SRRTL", "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId))
				.Where("RelationshipEntityAId")
					.In(Column.Parameters(recordIds)) as Select;
			if (isOrCondition) {
				select.Or("RelationshipEntityBId")
					.In(Column.Parameters(recordIds));
			} else {
				select.And("RelationshipEntityBId")
					.In(Column.Parameters(recordIds));
			}
			return select;
		}

		/// <summary>
		/// Creates diagram connection.
		/// </summary>
		/// <param name="reader">Reader.</param>
		/// <returns>Diagram connection.</returns>
		protected ConnectionInfo CreateDigramConnection(IDataReader reader) {
			var relationConnectionTypeId = reader.GetColumnValue<Guid>("RelationConnectionTypeId");
			var includeIntoContainer = GetDiagramConnectionIncludePropertyValue(reader);
			var typeOfConnection = GetConnectionType(relationConnectionTypeId, includeIntoContainer);
			return new ConnectionInfo {
				Id = reader.GetColumnValue<Guid>("Id"),
				Source = reader.GetColumnValue<Guid>("RelationshipEntityAId"),
				Target = reader.GetColumnValue<Guid>("RelationshipEntityBId"),
				ElementType = typeOfConnection,
				Name = reader.GetColumnValue<string>("Name"),
				Comment = reader.GetColumnValue<string>("Comment"),
				RelationshipType = CreateDiagramConnectionRelationType(reader)
			};
		}

		/// <summary>
		/// Returns diagram connection include property value.
		/// </summary>
		/// <param name="reader">Reader.</param>
		/// <returns>Connection include property value.</returns>
		protected bool GetDiagramConnectionIncludePropertyValue(IDataReader reader) {
			var relationConnectionTypeId = reader.GetColumnValue<Guid>("RelationConnectionTypeId");
			var entityASchemaUId = reader.GetColumnValue<string>("EntityASchemaUId");
			var entityBSchemaUId = reader.GetColumnValue<string>("EntityBSchemaUId");
			var includeIntoContainer = reader.GetColumnValue<bool>("IncludeIntoContainer");
			return includeIntoContainer &&
				relationConnectionTypeId.Equals(RelationConnectionType_Formal) &&
				!entityASchemaUId.Equals(entityBSchemaUId);
		}

		/// <summary>
		/// Creates diagram connection relation type.
		/// </summary>
		/// <param name="reader">Reader.</param>
		/// <returns>Connection relation type.</returns>
		protected RelationshipType CreateDiagramConnectionRelationType(IDataReader reader) {
			var includeIntoContainer = GetDiagramConnectionIncludePropertyValue(reader);
			return new RelationshipType {
				Id = reader.GetColumnValue<Guid>("RelationTypeId"),
				Name = $"{reader.GetColumnValue<string>("RelationTypeName")} - {reader.GetColumnValue<string>("ReverseRelationTypeName")}",
				IncludeIntoContainer = includeIntoContainer,
				Position = reader.GetColumnValue<int>("Position"),
				ConnectionType = new LookupItem {
					Id = reader.GetColumnValue<Guid>("RelationConnectionTypeId"),
					Name = reader.GetColumnValue<string>("RelationConnectionTypeName")
				},
			};
		}

		/// <summary>
		/// Returns true if is need distinct diagram connections list.
		/// </summary>
		/// <param name="entitiesRecordsParts">Entities records parts.</param>
		/// <returns>Is need distinct</returns>
		protected bool IsNeedDiagramConnectionsDistinct(IEnumerable<IEnumerable<Guid>> entitiesRecordsParts) {
			return entitiesRecordsParts.Count() > 1;
		}

		/// <summary>
		/// Returns diagram connections chunk size.
		/// </summary>
		/// <returns>Chunk size.</returns>
		protected int GetDiagramConenctionsListChunkSize() {
			return _queryMaxParametersCount / 2;
		}

		#endregion

		#region Methods: Public

		public DiagramInfo GetDiagramData(Guid recordId, string schemaName, DiagramConfiguration configuration, Guid diagramId) {
			if (diagramId.IsEmpty()) {
				diagramId = GetDiagramIdByEntityRecordId(recordId);
			}
			var diagramEntities = GetEntitiesFromDiagram(recordId, configuration);
			diagramEntities = diagramEntities.Where(entity => !entity.IsDeleted).ToList();
			var entityIds = diagramEntities.Select(x => x.Id).ToList();
			var diagramConnections = GetDiagramConnections(entityIds);
			var rootRecordId = diagramEntities.First(x => x.RecordId == recordId).Id;
			var filteredEntityIds = GetOnlyConnectedEntities(rootRecordId, entityIds, diagramConnections);
			diagramEntities = diagramEntities.Where(x => filteredEntityIds.Contains(x.Id)).ToList();
			diagramConnections = diagramConnections.Where(x =>
				filteredEntityIds.Contains(x.Source) && filteredEntityIds.Contains(x.Target)).ToList();
			diagramConnections = ApplyEntitiesRightsToConnections(diagramEntities, diagramConnections);
			var connectionLabels = GetConnectionLabels(diagramConnections);
			var groups = GetRelationshipGroupWithEntities(diagramId);
			var relationshipEntitiesInGroups = GetRelationshipEntetiesInGroups(diagramId);
			var diagramGroups = new List<RelationshipGroup>();
			if (groups.Any()) {
				diagramGroups = groups.Values.ToList();
				diagramEntities = AddGroupsToEntities(diagramEntities, relationshipEntitiesInGroups);
			}

			return new DiagramInfo {
				Id = diagramId,
				Caption = "Coolbrook",
				Entities = diagramEntities,
				Connections = diagramConnections,
				Labels = connectionLabels,
				Groups = diagramGroups,
				RootElementId = recordId
			};
		}

		public List<EntityInfo> GetEntitiesFromDiagram(Guid recordId, DiagramConfiguration diagramConfiguration) {
			var result = new List<EntityInfo>();
			var entitiesSelect = new Select(UserConnection)
				.Column("Id")
				.Column("RecordId")
				.Column("SchemaUId")
				.From("RelationshipEntity")
				.Where("Id").In(new Select(UserConnection)
					.Column("RelationshipEntityId")
					.From("RelationEntInDiagram")
					.Where("RelationshipDiagramId").In(new Select(UserConnection)
						.Column("RelationshipDiagramId")
						.From("RelationEntInDiagram")
						.Where("RelationshipEntityId").In(new Select(UserConnection)
							.Column("Id")
							.From("RelationshipEntity")
							.Where("RecordId").IsEqual(Column.Parameter(recordId)) as Select) as Select) as Select) as Select;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				using (var reader = entitiesSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						var Id = reader.GetColumnValue<Guid>("Id");
						var entityRecordId = reader.GetColumnValue<Guid>("RecordId");
						var schemaUId = reader.GetColumnValue<Guid>("SchemaUId");
						var isFirstLevel = IsFirstLevel(schemaUId, diagramConfiguration);
						var entityConfiguration = isFirstLevel ? diagramConfiguration.FirstLevelConfig : diagramConfiguration.SecondLevelConfig;
						var entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(schemaUId);
						var typeOfEntity = isFirstLevel ? RelationshipTypeEnum_RelationshipContainer : RelationshipTypeEnum_RelationshipItem;
						var defaultImage = isFirstLevel ? defaultAccountImage : defaultContactImage;
						var canRead = RightsHelper.GetCanReadSchemaRecordRight(entitySchema.Name, entityRecordId);
						var entityInfo = new EntityInfo {
							Id = Id,
							RecordId = entityRecordId,
							ElementType = typeOfEntity,
							SubCaption = entitySchema.Caption,
							CanRead = canRead,
							IsDeleted = false
						};
						if (!canRead) {
							result.Add(entityInfo);
							continue;
						}
						// TODO Need use diagramconfig for entity
						var entity = entitySchema.CreateEntity(UserConnection);
						// TODO: Add some cleanup for entities that have no records (RelationshipEntity exists when underlying Account/Contact was deleted)
						if (!entity.FetchFromDB("Id", entityRecordId)) {
							entityInfo.IsDeleted = true;
							result.Add(entityInfo);
							continue;
						}
						entityInfo.Caption = entity.GetTypedColumnValue<string>(entityConfiguration.DisplayValueColumn);
						string subCaptionEntityColumnName = isFirstLevel ? "TypeName" : "JobName";
						entityInfo.SubCaption = entity.GetTypedColumnValue<string>(subCaptionEntityColumnName);
						string info = isFirstLevel ? entity.GetTypedColumnValue<string>("AUM") : "";
						info = info.IsNotEmpty() ? string.Format("AUM: {0}", info) : null;
						entityInfo.Info = isFirstLevel ? info : null;
						entityInfo.Image = GetEntityImage(entity, entityConfiguration.ImageColumn, defaultImage);
						result.Add(entityInfo);
					}
				}
			}
			return result;
		}

		/// <summary>
		/// Returns diagram connections by entities.
		/// </summary>
		/// <param name="recordIds">Entities ids.</param>
		/// <returns>Diagram connections.</returns>
		public List<ConnectionInfo> GetDiagramConnections(IEnumerable<Guid> recordIds) {
			var result = new List<ConnectionInfo>();
			if (recordIds.IsEmpty()) {
				return result;
			}
			var chunkSize = GetDiagramConenctionsListChunkSize();
			var parts = recordIds.SplitOnChunks(chunkSize);
			var isNeedDistinct = IsNeedDiagramConnectionsDistinct(parts);
			parts.ForEach(part => {
				result.AddRange(GetPartDiagramConnections(part, isNeedDistinct));
			});
			if (isNeedDistinct) {
				result = result.Distinct().ToList();
			}
			return result;
		}

		public List<Guid> GetOnlyConnectedEntities(Guid sourceRecordId, List<Guid> entities, List<ConnectionInfo> connections) {
			bool isNeedToContinue = true;
			var result = new List<Guid> {
				sourceRecordId
			};
			while (isNeedToContinue) {
				isNeedToContinue = false;
				foreach (var connection in connections) {
					if (result.Contains(connection.Source) && !result.Contains(connection.Target)) {
						result.Add(connection.Target);
						isNeedToContinue = true;
					} else if (result.Contains(connection.Target) && !result.Contains(connection.Source)) {
						result.Add(connection.Source);
						isNeedToContinue = true;
					}
				}
			}
			return result;
		}

		public bool IsRelationshipEntityExistsForCurrentRecord(Guid recordId) {
			var entitySelect = new Select(UserConnection)
				.Column(Func.Count(Column.Asterisk())).As("Count")
				.From("RelationshipEntity")
				.Where("RecordId").IsEqual(Column.Parameter(recordId)) as Select;
			return entitySelect.ExecuteScalar<int>() > 0;
		}

		public DiagramInfo GetDiagram(Guid recordId, string schemaName) {
			if (recordId.IsEmpty()) {
				return new DiagramInfo();
			}
			var configuration = DiagramConfigProvider.GetConfiguration();
			var diagramId = Guid.Empty;
			if (!IsRelationshipEntityExistsForCurrentRecord(recordId)) {
				var createdResult = DiagramManager.CreateRelationshipEntityAndDiagramForRecord(recordId, schemaName);
				diagramId = createdResult.CreatedDiagramId;
				// TODO Optimize. Return empty diagram.
			}
			return GetDiagramData(recordId, schemaName, configuration, diagramId);
		}

		public DiagramConfig GetDiagramConfig() {
			return new DiagramConfig {
				CustomDiagramElements = GetDiagramElementsConfigMockData(),
				CustomElementToolsConfig = GetElementToolsConfig(),
			};
		}

		#endregion

	}

	#endregion

	#region RelationshipDiagramStructure

	#region RelationshipTypeEnum

	[DataContract(Name = "RelationshipTypeEnum")]
	public enum RelationshipTypeEnum
	{
		[EnumMember(Value = "relationship-item")]
		RelationshipItem,

		[EnumMember(Value = "relationship-container")]
		RelationshipContainer,

		[EnumMember(Value = "connection")]
		Connection,

		[EnumMember(Value = "indirect-connection")]
		IndirectConnection
	};

	#endregion

	#region Class: LookupItem

	[DataContract]
	public class LookupItem
	{
		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "name")]
		public string Name {
			get; set;
		}
	}

	#endregion

	#region Class: RelationshipType

	[DataContract]
	public class RelationshipType : LookupItem, IEquatable<RelationshipType>
	{
		#region Properties: Public

		[DataMember(Name = "position")]
		public int Position {
			get; set;
		}

		[DataMember(Name = "includeIntoContainer")]
		public bool IncludeIntoContainer {
			get; set;
		}

		[DataMember(Name = "connectionType")]
		public LookupItem ConnectionType {
			get; set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Equals relationship type with this.
		/// </summary>
		/// <param name="relationshipType">Relationship type.</param>
		/// <returns>Equals value.</returns>
		public bool Equals(RelationshipType relationshipType) {
			if (ReferenceEquals(relationshipType, null)) {
				return false;
			}

			if (ReferenceEquals(this, relationshipType)) {
				return true;
			}

			return Id.Equals(relationshipType.Id);
		}

		/// <summary>
		/// Returns hash code.
		/// </summary>
		/// <returns>Hash code.</returns>
		public override int GetHashCode() {
			return Id.GetHashCode();
		}

		#endregion

	}

	#endregion

	#region Class: DiagramInfo

	[DataContract]
	public class DiagramInfo
	{

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "rootElementId")]
		public Guid RootElementId {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "elements")]
		public List<EntityInfo> Entities {
			get; set;
		}

		[DataMember(Name = "connections")]
		public List<ConnectionInfo> Connections {
			get; set;
		}

		[DataMember(Name = "labels")]
		public List<ConnectionLabel> Labels {
			get; set;
		}

		[DataMember(Name = "groups")]
		public List<RelationshipGroup> Groups {
			get; set;
		}

		public DiagramInfo() {
			Id = Guid.Empty;
			RootElementId = Guid.Empty;
			Caption = string.Empty;
			Entities = new List<EntityInfo>();
			Connections = new List<ConnectionInfo>();
			Labels = new List<ConnectionLabel>();
			Groups = new List<RelationshipGroup>();
		}

	}

	#endregion

	#region Class: EntityInfo

	[DataContract]
	public class EntityInfo
	{
		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "recordId")]
		public Guid RecordId {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "subCaption")]
		public string SubCaption {
			get; set;
		}

		[DataMember(Name = "info")]
		public string Info {
			get; set;
		}

		[DataMember(Name = "largeImage")]
		public string Image {
			get; set;
		}

		[DataMember(Name = "type")]
		public string ElementType {
			get; set;
		}

		[DataMember(Name = "groups")]
		public List<RelationshipInGroup> Groups {
			get; set;
		}

		[DataMember(Name = "canRead")]
		public bool CanRead {
			get; set;
		}

		[DataMember(Name = "isDeleted")]
		public bool IsDeleted {
			get; set;
		}

	}

	#endregion

	#region Class: ConnectionInfo

	[DataContract]
	public class ConnectionInfo : IEquatable<ConnectionInfo>
	{
		#region Properties: Public

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "source")]
		public Guid Source {
			get; set;
		}

		[DataMember(Name = "target")]
		public Guid Target {
			get; set;
		}

		[DataMember(Name = "type")]
		public string ElementType {
			get; set;
		}

		[DataMember(Name = "relationshipType")]
		public RelationshipType RelationshipType {
			get; set;
		}

		[DataMember(Name = "comment")]
		public string Comment {
			get; set;
		}

		[DataMember(Name = "name")]
		public string Name {
			get; set;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Equals connection with this.
		/// </summary>
		/// <param name="connection">Conenction.</param>
		/// <returns>Equals value.</returns>
		public bool Equals(ConnectionInfo connection) {
			if (ReferenceEquals(connection, null)) {
				return false;
			}

			if (ReferenceEquals(this, connection)) {
				return true;
			}

			return Source.Equals(connection.Source) && Target.Equals(connection.Target)
				&& ElementType.Equals(connection.ElementType) && RelationshipType.Equals(connection.RelationshipType);
		}

		/// <summary>
		/// Returns hash code.
		/// </summary>
		/// <returns>Hash code.</returns>
		public override int GetHashCode() {
			int sourceHash = Source.GetHashCode();
			int targetHash = Target.GetHashCode();
			int elementTypeHash = ElementType.GetHashCode();
			int relationshipType = RelationshipType.GetHashCode();
			return sourceHash ^ targetHash ^ elementTypeHash ^ relationshipType;
		}

		#endregion

	}

	#endregion

	#region Class: ConnectionLabel

	[DataContract]
	public class ConnectionLabel
	{
		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "type")]
		public string Type {
			get; set;
		}

		[DataMember(Name = "parent")]
		public Guid Parent {
			get; set;
		}


	}

	#endregion

	#region Class: RelationshipGroup

	[DataContract]
	public class RelationshipGroup
	{

		[DataMember(Name = "id")]
		public Guid Id {
			get; set;
		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "color")]
		public string Color {
			get; set;
		}

		[DataMember(Name = "comment")]
		public string Comment {
			get; set;
		}

		public List<Guid> Entities {
			get; set;
		}
	}

	#endregion

	#region Class: RelationshipInGroup

	[DataContract]
	public class RelationshipInGroup
	{
		[DataMember(Name = "id")]
		public Guid GroupId {
			get; set;
		}

		[DataMember(Name = "comment")]
		public String Comment {
			get; set;
		}

	}

	#endregion

	#region DiagramElement

	#region Class: DiagramElement

	[DataContract]
	public class DiagramElement
	{
		[DataMember(Name = "caption", EmitDefaultValue = false)]
		public string Caption {
			get; set;
		}

		[DataMember(Name = "captionNoAccess", EmitDefaultValue = false)]
		public string CaptionNoAccess {
			get; set;
		}

		[DataMember(Name = "width", EmitDefaultValue = false)]
		public int Width {
			get; set;
		}

		[DataMember(Name = "height", EmitDefaultValue = false)]
		public int Height {
			get; set;
		}

		[DataMember(Name = "imageWidth", EmitDefaultValue = false)]
		public int ImageWidth {
			get; set;
		}

		[DataMember(Name = "imageHeight", EmitDefaultValue = false)]
		public int ImageHeight {
			get; set;
		}


		[DataMember(Name = "fill", EmitDefaultValue = false)]
		public string Fill {
			get; set;
		}


		[DataMember(Name = "fillInParent", EmitDefaultValue = false)]
		public string FillInParent {
			get; set;
		}

		[DataMember(Name = "stroke", EmitDefaultValue = false)]
		public string Stroke {
			get; set;
		}


		[DataMember(Name = "type")]
		public string RelationshipType {
			get; set;
		}

		[DataMember(Name = "largeImage", EmitDefaultValue = false)]
		public string LargeImage {
			get; set;
		}

		[DataMember(Name = "largeImageNoAccess", EmitDefaultValue = false)]
		public string LargeImageNoAccess {
			get; set;
		}

		[DataMember(Name = "entitySchemaData", EmitDefaultValue = false)]
		public EntitySchemaData EntitySchemaData {
			get; set;
		}

	}

	#endregion

	#region Class: EntitySchemaData

	[DataContract]
	public class EntitySchemaData
	{
		[DataMember(Name = "name")]
		public string Name {
			get; set;

		}

		[DataMember(Name = "caption")]
		public string Caption {
			get; set;

		}

		[DataMember(Name = "uId")]
		public Guid UId {
			get; set;

		}
	}

	#endregion

	#region Class: ElementToolsConfig

	[DataContract]
	public class ElementToolsConfig
	{

		[DataMember(Name = "addItems")]
		public List<ToolItem> AddItems {
			get; set;
		}

		[DataMember(Name = "tools")]
		public ToolObject Tools {
			get; set;
		}

		[DataMember(Name = "innerTools")]
		public InnerToolObject InnerTools {
			get; set;
		}

	}

	#endregion

	#region Class: ToolObject

	[DataContract]
	public class ToolObject
	{

		[DataMember(Name = "add")]
		public ToolItem Add {
			get; set;
		}

		[DataMember(Name = "connect")]
		public ToolItem Connect {
			get; set;
		}


		[DataMember(Name = "setup")]
		public ToolItem Setup {
			get; set;
		}

		[DataMember(Name = "delete")]
		public ToolItem Delete {
			get; set;
		}

	}

	#endregion

	#region Class: InnerToolObject

	[DataContract]
	public class InnerToolObject
	{

		[DataMember(Name = "toggle")]
		public InnerToolItem Toggle {
			get; set;
		}

	}

	#endregion

	#region Class: ToolItem

	[DataContract]
	public class ToolItem
	{

		[DataMember(Name = "imageUrl", EmitDefaultValue = false)]
		public string ImageUrl {
			get; set;
		}

		[DataMember(Name = "title")]
		public string Title {
			get; set;
		}

		[DataMember(Name = "type", EmitDefaultValue = false)]
		public string Type {
			get; set;
		}

	}

	#endregion

	#region Class: InnerToolItem

	[DataContract]
	public class InnerToolItem
	{

		[DataMember(Name = "collapseImageUrl")]
		public string CollapseImageUrl {
			get; set;
		}

		[DataMember(Name = "expandImageUrl")]
		public string ExpandImageUrl {
			get; set;
		}

	}

	#endregion

	#region Class: DiagramConfig

	[DataContract]
	public class DiagramConfig
	{

		[DataMember(Name = "customDiagramElements")]
		public List<DiagramElement> CustomDiagramElements {
			get; set;
		}

		[DataMember(Name = "customElementToolsConfig")]
		public ElementToolsConfig CustomElementToolsConfig {
			get; set;
		}

	}

	#endregion

	#endregion

}

#endregion

