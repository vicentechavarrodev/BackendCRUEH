namespace ApiMapaCRUEH.Request
{
		public class ParametrosIniciarTurnoAmbulancia
		{
				public string CodigoIPS { set; get; }
				public string NombreIPS { set; get; }
				public string PlacasAmbulancia { set; get; }
				public string TipoTransporte { set; get; }
				public DateTime FechaInicio { set; get; }
				public int Duracion { set; get; }
				public long IDUsuario { set; get; }
				public string NombreUsuario { set; get; }
				public decimal Latitud { get; set; }
				public decimal Longitud { get; set; }
				public List<ParametrosTripulacionTurnoAmbulancia> Tripulacion { get; set; }
		}
}
