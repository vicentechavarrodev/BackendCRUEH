namespace ApiMapaCRUEH.Model
{
    public class IPS
    {
        public string ID { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public object? Dv { get; set; }
        public int Sede { get; set; }
        public string CodigoMunicipio { get; set; }
        public string Municipio { get; set; }
        public bool EsESE { get; set; }
        public int? Nivel { get; set; }
        public int? CodigoClpr { get; set; }
        public object? CodigoNaju { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
    }
}
