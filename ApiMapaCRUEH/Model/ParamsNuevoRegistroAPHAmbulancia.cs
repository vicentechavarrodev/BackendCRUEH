namespace ApiMapaCRUEH.Model
{
    public class ParamsNuevoRegistroAPHAmbulancia
    {
        public DateTime FechaReporte { get; set; }
        public long IDMedioRecepcion { get; set; }
        public string NombreReporta { get; set; }
        public long IDSectorReportante { get; set; }
        public string TelefonoReporta { get; set; }
        public int TipoEvento { get; set; }
        public long IDEvento { get; set; }
        public int? TipoTrauma { get; set; }
        public long? IDRolTransito { get; set; }
        public int? MecanismoLesion { get; set; }
        public string DatosARL { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Direccion { get; set; }
        public decimal? Latitud { get; set; }
        public decimal? Longitud { get; set; }
        public long IDUsuario { get; set; }
        public string NombreUsuario { get; set; }
    }
}
