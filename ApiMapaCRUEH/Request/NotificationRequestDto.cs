namespace ApiMapaCRUEH.Request
{
		public class NotificationRequestDto
		{
				public string Text { get; set; }
				public string Action { get; set; }
				public string[] Tags { get; set; } = Array.Empty<string>();
				public bool Silent { get; set; }
				public string IdEvento { get; set; }
		}
}
