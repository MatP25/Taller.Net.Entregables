using WebApi1.Controllers;

var builder = WebApplication.CreateBuilder(args);

//Add controllers services
builder.Services.AddSingleton<TaskController>();
builder.Services.AddSingleton<EmployeeController>();
// Add services to the container.
builder.Services.AddMvc().AddControllersAsServices();
// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = "docs/api/v1"; //set documentation route at /docs/api/v1
    });
}

// app.UseHttpsRedirection();
// app.UseAuthorization();
app.MapControllers();
app.Run(); //run with >dotnet run

