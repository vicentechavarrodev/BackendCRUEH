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
				public decimal? Latitud { get; set; }
				public decimal? Longitud { get; set; }
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
		}
}
