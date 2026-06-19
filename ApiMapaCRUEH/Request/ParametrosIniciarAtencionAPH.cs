namespace ApiMapaCRUEH.Request
{
		public class ParametrosIniciarAtencionAPH
		{
				public long ID { get; set; }
				public int Triage { get; set; }
				public int TipoEvento { get; set; }
				public long IDEvento { get; set; }
				public int? TipoTrauma { get; set; }
				public long? IDRolTransito { get; set; }
				public int? MecanismoLesion { get; set; }
				public string DatosARL { get; set; }
				public DateTime HoraLlegadaSitio { get; set; }
				public decimal LatitudLlegadaSitio { get; set; }
				public decimal LongitudLlegadaSitio { get; set; }
				public DateTime HoraInicioAtencion { get; set; }
				public decimal LatitudInicioAtencion { get; set; }
				public decimal LongitudInicioAtencion { get; set; }
				public string ObservacionesPaciente { get; set; }
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
		}
}
