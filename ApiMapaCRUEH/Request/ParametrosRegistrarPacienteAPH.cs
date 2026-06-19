namespace ApiMapaCRUEH.Request
{
		public class ParametrosRegistrarPacienteAPH
		{
				public long ID { get; set; }
				public string TipoIdentificacion { get; set; }
				public string NumeroIdentificacion { get; set; }
				public string PrimerNombre { get; set; }
				public string SegundoNombre { get; set; }
				public string PrimerApellido { get; set; }
				public string SegundoApellido { get; set; }
				public string Sexo { get; set; }
				public int? Edad { get; set; }
				public int? TipoEdad { get; set; }
				public long IDUsuario { get; set; }
				public string NombreUsuario { get; set; }
		}
}
