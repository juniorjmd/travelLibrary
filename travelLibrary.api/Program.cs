using Microsoft.EntityFrameworkCore;
using travelLibrary.AccesoDatos.Data;
using travelLibrary.AccesoDatos.Data.Repository.IRepository;
using travelLibrary.AccesoDatos.Data.Repository;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*" , "http://localhost:4200")
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod();
                      });
});


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Cadena de conexion 'ConexionSql' no encontrada.");
builder.Services.AddDbContext<MyDBContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>(); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//contenedor de trabajo agregado




var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
