using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CafeTechContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "CafeTech API");
app.MapFuncionarioApi();
app.MapClienteApi();
app.MapServicoApi();

app.Run();

