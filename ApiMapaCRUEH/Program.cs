using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Model;
using ApiMapaCRUEH.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IApiHelper, ApiHelper>();
builder.Services.AddSingleton<IEXSession, EXSession>();
builder.Services.AddSingleton<INotificationService, NotificationHubService>();
builder.Services.AddOptions<NotificationHubOptions>()
		.Configure(builder.Configuration.GetSection("NotificationHub").Bind)
		.ValidateDataAnnotations();

builder.Services.AddProblemDetails();

var app = builder.Build();
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
