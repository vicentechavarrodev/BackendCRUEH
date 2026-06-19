namespace ApiMapaCRUEH.Request
{
		public class ParametrosEntregarPacienteRegistroAPH
		{
				public long ID { get; set; }
				public DateTime FechaHoraLlegadaIPS { get; set; }
				public string ObservacionesEntrega { get; set; }
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
		}
}
