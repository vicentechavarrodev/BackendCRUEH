using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Services;
using Microsoft.OpenApi.Models;

//ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
//ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
		c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
		{
				Name = "Authorization",
				Type = SecuritySchemeType.Http,
				Scheme = "basic",
				In = ParameterLocation.Header,
				Description = "Ingrese su usuario y contraseña de Extranet"
		});
		c.AddSecurityRequirement(new OpenApiSecurityRequirement {
				{
						new OpenApiSecurityScheme {
								Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "basic" }
						},
						new string[] {}
				}
		});
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddSingleton<IApiHelper, ApiHelper>();
builder.Services.AddScoped<IEXSession, EXSession>();
builder.Services.AddSingleton<INotificationService, NotificationHubService>();
builder.Services.AddOptions<NotificationHubOptions>()
		.Configure(builder.Configuration.GetSection("NotificationHub").Bind)
		.ValidateDataAnnotations();

builder.Services.AddProblemDetails();

var app = builder.Build();
app.UseMiddleware<BasicAuthMiddleware>();
app.UseCors(builder =>
{
		builder
		.WithOrigins("http://localhost", "http://localhost:3000", "http://localhost:3001", "http://186.147.196.166")
		.AllowAnyMethod()
		.AllowAnyHeader();
});



//if (app.Environment.IsDevelopment())
//{
app.UseExceptionHandler();
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
