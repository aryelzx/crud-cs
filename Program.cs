var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner.
builder.Services.AddControllers();
// Configurando o Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); //dotnet add package Swashbuckle.AspNetCore

//construindo o app
var app = builder.Build();

// Configurando o pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); //dotnet add package Swashbuckle.AspNetCore.SwaggerUI
}

// Habilitando o uso de controllers
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Iniciando o app
app.Run();