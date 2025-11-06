namespace ApiMapaCRUEH.Model
{
    public class Ambulancia
    {
        public int ID { get; set; }
        public string? Tipo { get; set; }
        public string? CodigoIPS { get; set; }
        public string? NombreIPS { get; set; }
        public string? CodigoMunicipio { get; set; }
        public string? Municipio { get; set; }
        public string? Placas { get; set; }
        public string? Modelo { get; set; }
        public string? NaturalezaJuridica { get; set; }
        public bool Disponible { get; set; }
        public string? IMEI { get; set; }
    }
}
