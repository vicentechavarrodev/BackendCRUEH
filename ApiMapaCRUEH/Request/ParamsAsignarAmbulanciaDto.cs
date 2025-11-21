namespace ApiMapaCRUEH.Request
{
    public class ParamsAsignarAmbulanciaDto
    {
        public long ID { get; set; }
        public string CodigoIPSAsignada { get; set; }
        public string NombreIPSAsignada { get; set; }
        public long? CodigoAmbulancia { get; set; }
        public string PlacasAmbulancia { get; set; }
        public int TipoTransporte { get; set; }
        public DateTime HoraNotificacionAmbulancia { get; set; }
        public long IDUsuario { get; set; }
        public string NombreUsuario { get; set; }
    }
}
