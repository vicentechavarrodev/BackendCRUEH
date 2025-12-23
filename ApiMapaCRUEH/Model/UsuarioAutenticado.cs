namespace ApiMapaCRUEH.Model
{
		public class UsuarioAutenticado : DatosSesionAmbulancia
		{
				public string Respuesta { get; set; }
				public object Mensaje { get; set; }
				public int IDUsuario { get; set; }
				public string NombreUsuario { get; set; }

		}
}
