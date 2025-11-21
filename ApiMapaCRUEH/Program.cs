using ApiMapaCRUEH.ExtranetHelpers;
using ApiMapaCRUEH.Services;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IApiHelper, ApiHelper>();
builder.Services.AddSingleton<IEXSession, EXSession>();

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
app.UseSwagger();
    app.UseSwaggerUI();
//}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
