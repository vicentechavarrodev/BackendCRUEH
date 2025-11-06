using System.ComponentModel;

namespace ApiMapaCRUEH.Request
{
    public class ConsultarAmbulaciasDto
    {
        [DefaultValue("0")]
        public string? CodigoMunicipio { get; set; } = "";
        [DefaultValue("0")]
        public string? CodigoIPS { get; set; } = "";
        public bool Disponible { get; set; }
        [DefaultValue("0")]
        public string? IMEI { get; set; } = "";
    }
}
