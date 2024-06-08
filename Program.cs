using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//Configuração CORs
builder.Services.AddCors();


builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<CafeTechContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

var app = builder.Build();

//Configuração CORs
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
);


app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/", () => "CafeTech API");
app.MapFuncionarioApi();
app.MapClienteApi();
app.MapServicoApi();

app.Run();

