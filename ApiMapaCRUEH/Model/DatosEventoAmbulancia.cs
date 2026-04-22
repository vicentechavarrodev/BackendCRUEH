namespace ApiMapaCRUEH.Model
{
		public class DatosEventoAmbulancia
		{
				public long ID { get; set; }
				public long IDEvento { get; set; }
				public int TipoEvento { get; set; }
				public long IDMedioRecepcion { get; set; }
				public long IDSectorReportante { get; set; }
				public DateTime HoraReporte { get; set; }
				public string NombreReporta { get; set; }
				public string TelefonoReporta { get; set; }
				public int? TipoTrauma { get; set; }
				public long? IDRolTransito { get; set; }
				public int? MecanismoLesion { get; set; }
				public string DatosArl { get; set; }
				public string Direccion { get; set; }
				public DateTime? HoraLlegadaSitio { get; set; }
				public DateTime? HoraSalidaSitio { get; set; }
				public string CodigoIPSLlegada { get; set; }
				public decimal? Latitud { get; set; }
				public decimal? Longitud { get; set; }
				public int? TriageAmbulancia { get; set; }

		}
}
