namespace ApiMapaCRUEH.Request
{
		public class DatosMedicionesEstadoNeurologicoAph
		{
				public int Id { get; set; }

				public string? AVPU { get; set; } = "N/A";

				public int GlasgowOcular { get; set; }

				public int GlasgowVerbal { get; set; }

				public int GlasgowMotora { get; set; }

				public int GlasgowTotal { get; set; }

				public int IdToma { get; set; }
		}
}