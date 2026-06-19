namespace ApiMapaCRUEH.Request
{
		public class DatosTomasMedicionAph
		{
				public int IdToma { get; set; }
				public DateTime FechaHora { get; set; }
				public long IdEvento { get; set; }

				public DatosMedicionesViaAereaAph? MedicionesViaAerea { get; set; }
				public DatosMedicionesRespiracionAph? MedicionesRespiracion { get; set; }
				public DatosMedicionesCirculacionAph? MedicionesCirculacion { get; set; }
				public DatosMedicionesEstadoNeurologicoAph? MedicionesEstadoNeurologico { get; set; }
				public DatosMedicionesExposicionAph? MedicionesExposicion { get; set; }
		}
}
