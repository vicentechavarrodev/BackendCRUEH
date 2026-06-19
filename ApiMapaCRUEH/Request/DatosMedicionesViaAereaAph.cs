namespace ApiMapaCRUEH.Request
{
		public class DatosMedicionesViaAereaAph
		{
				public int Id { get; set; }
				public string? Detalle { get; set; } = "N/A";
				public string? ProteccionCervical { get; set; } = "N/A";
				public string? Secrecion { get; set; } = "N/A";
				public string? CuerpoExtrano { get; set; } = "N/A";
				public string? Intervencion { get; set; } = "N/A";
				public int IdToma { get; set; }
		}
}