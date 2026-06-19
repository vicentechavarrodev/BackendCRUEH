namespace ApiMapaCRUEH.Request
{
		public class DatosMedicionesExposicionAph
		{
				public int Id { get; set; }

				public string? Detalle { get; set; } = "N/A";

				public double TemperaturaCorporal { get; set; }

				public string? Fractura { get; set; } = "N/A";

				public string? ExposicionToxicos { get; set; } = "N/A";

				public int IdToma { get; set; }
		}
}