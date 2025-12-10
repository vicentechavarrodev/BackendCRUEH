using System.ComponentModel.DataAnnotations;

namespace ApiMapaCRUEH.Model
{
		public class NotificationHubOptions
		{
				[Required]
				public string Name { get; set; }

				[Required]
				public string ConnectionString { get; set; }
		}
}
