namespace ApiMapaCRUEH.Model
{
		public class DatosSesionAmbulancia
		{
				public Ambulancia Ambulancia { get; set; }
				public List<ItemLista> ListaTriageAPH { get; set; }
				public List<ItemListaEvento> ListaEventos { get; set; }
				public List<ItemLista> ListaRolesAccidenteTransito { get; set; }
				public List<ItemLista> ListaMotivosRechazo { get; set; }
				public List<ItemLista> ListaMotivosCancelacion { get; set; }
				public string Error { get; set; }
		}
}
