namespace ApiMapaCRUEH.Model
{
		public class PushTemplates
		{
				public class Generic
				{
						public const string Android = "{ \"message\" : { \"notification\" : {\"body\" : \"$(alertMessage)\",\"title\" : \"NUEVA EMERGENCIA\"}, \"data\" : { \"action\" : \"$(alertAction)\",\"idEvento\" : \"$(idEvento)\" } } }";
						public const string iOS = "{ \"aps\" : {\"alert\" : \"$(alertMessage)\"}, \"action\" : \"$(alertAction)\" }";
				}

				public class Silent
				{

						public const string Android = "{ \"message\" : { \"notification\" : {\"body\" : \"$(alertMessage)\",\"title\" : \"NUEVA EMERGENCIA\"}, \"data\" : { \"action\" : \"$(alertAction)\",\"idEvento\" : \"$(idEvento)\" } } }";
						public const string iOS = "{ \"aps\" : {\"content-available\" : 1, \"apns-priority\": 5, \"sound\" : \"\", \"badge\" : 0}, \"message\" : \"$(alertMessage)\", \"action\" : \"$(alertAction)\" }";
				}
		}
}
