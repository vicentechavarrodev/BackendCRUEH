using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Request;
using Microsoft.Azure.NotificationHubs;
using Microsoft.Extensions.Options;

namespace ApiMapaCRUEH.Services
{
		public class NotificationHubService : INotificationService
		{
				readonly NotificationHubClient _hub;
				readonly Dictionary<string, NotificationPlatform> _installationPlatform;
				readonly ILogger<NotificationHubService> _logger;

				public NotificationHubService(IOptions<NotificationHubOptions> options, ILogger<NotificationHubService> logger)
				{
						_logger = logger;
						var retryOptions = new NotificationHubRetryOptions
						{
								Mode = NotificationHubRetryMode.Exponential,
								MaxRetries = 5,
								Delay = TimeSpan.FromSeconds(2),
								MaxDelay = TimeSpan.FromSeconds(30)
						};
						var settings = new NotificationHubSettings
						{
								RetryOptions = retryOptions
						};
						_hub = new NotificationHubClient(options.Value.ConnectionString, options.Value.Name);
						_installationPlatform = new Dictionary<string, NotificationPlatform>
				{
						{ nameof(NotificationPlatform.Apns).ToLower(), NotificationPlatform.Apns },
						{ nameof(NotificationPlatform.FcmV1).ToLower(), NotificationPlatform.FcmV1 },
						 { "browser", NotificationPlatform.Wns }
				};
				}

				public async Task<bool> CreateOrUpdateInstallationAsync(DeviceInstallation deviceInstallation, CancellationToken token)
				{
						if (string.IsNullOrWhiteSpace(deviceInstallation?.InstallationId) ||
								string.IsNullOrWhiteSpace(deviceInstallation?.Platform) ||
								string.IsNullOrWhiteSpace(deviceInstallation?.PushChannel))
								return false;

						var installation = new Installation()
						{
								InstallationId = deviceInstallation.InstallationId,
								PushChannel = deviceInstallation.PushChannel,
								Tags = deviceInstallation.Tags
						};

						if (_installationPlatform.TryGetValue(deviceInstallation.Platform, out var platform))
								installation.Platform = platform;
						else
								return false;

						try
						{
								await _hub.CreateOrUpdateInstallationAsync(installation, token);
						}
						catch
						{
								return false;
						}

						return true;
				}

				public async Task<bool> DeleteInstallationByIdAsync(string installationId, CancellationToken token)
				{
						if (string.IsNullOrWhiteSpace(installationId))
								return false;

						try
						{
								await _hub.DeleteInstallationAsync(installationId);

						}
						catch
						{
								return false;
						}

						return true;
				}

				public async Task<bool> RequestNotificationAsync(NotificationRequestDto notificationRequest, CancellationToken token)
				{
						if ((notificationRequest.Silent &&
								string.IsNullOrWhiteSpace(notificationRequest?.Action)) ||
								(!notificationRequest.Silent &&
								string.IsNullOrWhiteSpace(notificationRequest?.Text)))
								return false;

						var androidPushTemplate = notificationRequest.Silent ?
								PushTemplates.Silent.Android :
								PushTemplates.Generic.Android;

						var androidPayload = PrepareNotificationPayload(
								androidPushTemplate,
								notificationRequest.Text,
								notificationRequest.Action,
								notificationRequest.IdEvento,
								notificationRequest.Datos,
								notificationRequest.Title
								);
						try
						{
								if (notificationRequest.Tags.Length == 0)
								{
										await SendPlatformNotificationsAsync(androidPayload, token);
								}
								else if (notificationRequest.Tags.Length <= 20)
								{
										try
										{
												await SendPlatformNotificationsAsync(androidPayload, notificationRequest.Tags, token);
										}
										catch (Exception ex)
										{
												Console.WriteLine($"Error de comunicación: {ex.Message}");
												Console.WriteLine($"Detalle interno: {ex.InnerException?.Message}");
												return false;
										}


								}
								else
								{
										var notificationTasks = notificationRequest.Tags
												.Select((value, index) => (value, index))
												.GroupBy(g => g.index / 20, i => i.value)
												.Select(tags => SendPlatformNotificationsAsync(androidPayload, tags, token));

										await Task.WhenAll(notificationTasks);
								}

								return true;
						}

						catch (Exception e)
						{
								_logger.LogError(e, "Unexpected error sending notification");
								return false;
						}
				}


				string PrepareNotificationPayload(string template, string text, string action, string idEvento, string datos, string title) => template
					.Replace("$(alertMessage)", text, StringComparison.InvariantCulture)
					.Replace("$(alertAction)", action, StringComparison.InvariantCulture)
					.Replace("$(idEvento)", idEvento, StringComparison.InvariantCulture)
					.Replace("$(extraData)", datos, StringComparison.InvariantCulture)
					.Replace("$(alertTitle)", title, StringComparison.InvariantCulture)
					;

				Task SendPlatformNotificationsAsync(string androidPayload, CancellationToken token)
				{
						var sendTasks = new Task[]
						{
						_hub.SendFcmV1NativeNotificationAsync(androidPayload, token),

						};

						return Task.WhenAll(sendTasks);
				}

				Task SendPlatformNotificationsAsync(string androidPayload, IEnumerable<string> tags, CancellationToken token)
				{
						var sendTasks = new Task[]
						{

						_hub.SendFcmV1NativeNotificationAsync(androidPayload, tags, token),

						};

						return Task.WhenAll(sendTasks);
				}

				public async Task<bool> RequestWebNotificationAsync(NotificationRequestDto notificationRequest, CancellationToken token)
				{
						if ((notificationRequest.Silent && string.IsNullOrWhiteSpace(notificationRequest?.Action)) ||
								(!notificationRequest.Silent && string.IsNullOrWhiteSpace(notificationRequest?.Text)))
								return false;

						var webPayloadObj = new
						{
								title = notificationRequest.Title ?? "Nueva Alerta",
								body = notificationRequest.Text,
								action = notificationRequest.Action,
								idEvento = notificationRequest.IdEvento,
								datos = notificationRequest.Datos,
								silent = notificationRequest.Silent
						};
						string webPayload = System.Text.Json.JsonSerializer.Serialize(webPayloadObj);

						// Creamos la notificación compatible con navegadores Web mediante la clase base del SDK
						var webHeaders = new Dictionary<string, string> { { "Content-Type", "application/json;charset=utf-8" } };

						// El formato nativo reconocido por Azure para Web Push es "browser"
						var webNotification = new WindowsNotification(webPayload, new Dictionary<string, string> { { "X-WNS-Type", "wns/raw" } });

						try
						{
								// 3. Envío masivo
								if (notificationRequest.Tags.Length == 0)
								{
										await _hub.SendNotificationAsync(webNotification, token);
								}
								// 4. Envío segmentado hasta 20 etiquetas
								else if (notificationRequest.Tags.Length <= 20)
								{
										try
										{
												await _hub.SendNotificationAsync(webNotification, notificationRequest.Tags, token);
										}
										catch (Exception ex)
										{
												_logger.LogError(ex, $"Error de comunicación Web Push: {ex.Message}");
												return false;
										}
								}
								// 5. División en bloques si supera el límite de Azure
								else
								{
										var notificationTasks = notificationRequest.Tags
												.Select((value, index) => (value, index))
												.GroupBy(g => g.index / 20, i => i.value)
												.Select(tags => _hub.SendNotificationAsync(webNotification, tags, token));

										await Task.WhenAll(notificationTasks);
								}

								return true;
						}
						catch (Exception e)
						{
								_logger.LogError(e, "Unexpected error sending web notification");
								return false;
						}
				}
		}
}
