namespace ApiMapaCRUEH.Request
{
		public class ParametrosCambiarDisponibilidadAmbulancia
		{
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
				public DateTime FechaCambio { get; set; }
				public bool Disponible { get; set; }
				public long? IDMotivoIndisponibilidad { get; set; }
				public Guid IDTurno { get; set; }
				public decimal Latitud { get; set; }
				public decimal Longitud { get; set; }
		}
}
