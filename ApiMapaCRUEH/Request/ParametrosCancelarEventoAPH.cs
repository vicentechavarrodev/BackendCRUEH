namespace ApiMapaCRUEH.Request
{
		public class ParametrosCancelarEventoAPH
		{
				public long ID { get; set; }
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
				public DateTime FechaAccion { get; set; }
				public long IDMotivoCancelacion { get; set; }
				public decimal Latitud { get; set; }
				public decimal Longitud { get; set; }
		}

}
