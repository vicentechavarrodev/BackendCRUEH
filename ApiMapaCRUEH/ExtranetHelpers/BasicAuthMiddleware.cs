using System.Text;

namespace ApiMapaCRUEH.ExtranetHelpers
{
		public class BasicAuthMiddleware
		{
				private readonly RequestDelegate _next;

				public BasicAuthMiddleware(RequestDelegate next) => _next = next;

				public async Task InvokeAsync(HttpContext context, IEXSession session)
				{
						var authHeader = context.Request.Headers["Authorization"].ToString();

						if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
						{
								try
								{
										var base64EncodedBytes = Convert.FromBase64String(authHeader.Substring(6));
										var credentials = Encoding.UTF8.GetString(base64EncodedBytes).Split(':');

										session.Usuario = credentials[0];
										session.Password = credentials[1];
										await session.ObtenerSessionExtranet();
								}
								catch { }
						}

						await _next(context);
				}
		}
}
