namespace ApiMapaCRUEH.Model
{
		public class PushTemplates
		{
				public class Generic
				{
						public const string Android = "{\"message\":{\"android\":{\"priority\":\"high\"},\"data\":{\"title\":\"$(alertTitle)\",\"body\":\"$(alertMessage)\",\"action\":\"$(alertAction)\",\"idEvento\":\"$(idEvento)\",\"detalles\":\"$(extraData)\",\"tag\":\"app_unica\"}}}";

						public const string iOS = "{ \"aps\" : {\"alert\" : \"$(alertMessage)\"}, \"action\" : \"$(alertAction)\" }";
				}

				public class Silent
				{
						public const string Android = "{\"message\":{\"android\":{\"priority\":\"high\"},\"data\":{\"title\":\"$(alertTitle)\",\"body\":\"$(alertMessage)\",\"action\":\"$(alertAction)\",\"idEvento\":\"$(idEvento)\",\"detalles\":\"$(extraData)\",\"tag\":\"app_unica\"}}}";

						public const string iOS = "{ \"aps\" : {\"content-available\" : 1, \"apns-priority\": 5, \"sound\" : \"\", \"badge\" : 0}, \"message\" : \"$(alertMessage)\", \"action\" : \"$(alertAction)\" }";
				}
		}
}
