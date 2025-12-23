namespace ApiMapaCRUEH.Request
{
		public class ParametrosGestionarAsignacionAmbulanciaAPHDto
		{
				public long ID { get; set; }
				public long IDAmbulancia { get; set; }
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
				public DateTime FechaEvento { get; set; }
				public bool Acepta { get; set; }
				public string Observacion { get; set; }
		}
}
