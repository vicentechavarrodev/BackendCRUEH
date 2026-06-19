namespace ApiMapaCRUEH.Model
{
		public class RespuestaObtenerListaAfiliados
		{
				public List<DatosAfiliado> Datos { get; set; }
				public int Total { get; set; }
				public string _Tipo { get; set; }
		}
}
