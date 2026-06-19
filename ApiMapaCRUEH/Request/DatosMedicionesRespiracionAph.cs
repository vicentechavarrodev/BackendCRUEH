namespace ApiMapaCRUEH.Request
{
		public class DatosMedicionesRespiracionAph
		{
				public int Id { get; set; }

				public double FrecuenciaRespiratoria { get; set; }

				public double SaturacionOxigeno { get; set; }

				public string? MusculosAccesorios { get; set; } = "N/A";

				public string? AuscultacionPulmonar { get; set; } = "N/A";

				public string? OxigenoAdministrado { get; set; } = "N/A";

				public int IdToma { get; set; }
		}
}