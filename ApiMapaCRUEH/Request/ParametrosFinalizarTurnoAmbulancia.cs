namespace ApiMapaCRUEH.Request
{
		public class ParametrosFinalizarTurnoAmbulancia
		{
				public Guid ID { get; set; }
				public DateTime FechaFin { get; set; }
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
				public decimal Latitud { get; set; }
				public decimal Longitud { get; set; }
		}
}
