
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TaskManagement.Domain.SeedWork;
using TaskManagement.Infrastructure;
using TaskManagement.Infrastructure.Repository;
using TaskManagement.WebAPI.Security;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
            new BadRequestObjectResult(new
            {
                Detail = context.ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage,
                StatusCode = (int)HttpStatusCode.BadRequest
            });
    });

builder.Services.AddDataProtection();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TaskManagementContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
    {
        options.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
    });
});

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<JwtAuth>();
builder.Services.AddScoped<DataProtector>();

var app = builder.Build();

await SeedAsync(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

async Task SeedAsync(WebApplication host)
{
    using (var scope = host.Services.CreateScope())
    {
        var service = scope.ServiceProvider;
        var context = service.GetRequiredService<TaskManagementContext>();
        await TaskManagementContextSeed.SendAsync(context);
    }
}
