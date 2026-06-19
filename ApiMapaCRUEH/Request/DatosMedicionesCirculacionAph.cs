namespace ApiMapaCRUEH.Request
{
		public class DatosMedicionesCirculacionAph
		{
				public int Id { get; set; }

				public string? PulsoRadialPresente { get; set; }

				public double FrecuenciaCardiaca { get; set; }

				public double PAS { get; set; } = 0;

				public double PAD { get; set; } = 0;

				public string? Hemorragia { get; set; } = "N/A";

				public string? LlenadoCapilar { get; set; } = "N/A";

				public int IdToma { get; set; }
		}
}