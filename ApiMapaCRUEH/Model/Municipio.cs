using Newtonsoft.Json;

namespace ApiMapaCRUEH.Model
{
		public class Municipio
		{
				[JsonProperty(":id")] // <-- Cambia JsonPropertyName por JsonProperty
				public string Id { get; set; }

				[JsonProperty(":version")]
				public string Version { get; set; }

				[JsonProperty(":created_at")]
				public string CreatedAt { get; set; }

				[JsonProperty(":updated_at")]
				public string UpdatedAt { get; set; }

				[JsonProperty("cod_dpto")]
				public string CodDpto { get; set; }

				[JsonProperty("dpto")]
				public string Dpto { get; set; }

				[JsonProperty("cod_mpio")]
				public string CodMpio { get; set; }

				[JsonProperty("nom_mpio")]
				public string NomMpio { get; set; }

				[JsonProperty("tipo_municipio")]
				public string TipoMunicipio { get; set; }

				[JsonProperty("longitud")]
				public string Longitud { get; set; }

				[JsonProperty("latitud")]
				public string Latitud { get; set; }
		}
}
