using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Added services to the container.
builder.Services.AddDbContext<DataContext>(options =>
    options.UseInMemoryDatabase("TodoList"));

builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
