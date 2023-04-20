using CoreApplication.Contracts.Repository;
using CoreApplication.Contracts.Services;
using HRMAPI.Utility;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<ICandidateRepository, CandidateRepository>();
builder.Services.AddScoped<ICandidateService, CandidateService>();

builder.Services.AddDbContext<RecruitingDbContext>(option => {
    option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    option.UseSqlServer(builder.Configuration.GetConnectionString("RecruitingDbContext"));
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//use for api end points
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //middle ware swagger
    app.UseSwaggerUI();
    app.UseMiddlewareExtension();
   /* app.UseExceptionHandler(options =>
    {
        options.Run(async context =>
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
                //log the exception to the serilog
                await context.Response.WriteAsync(ex.Error.Message);
            }
        });

    });
   */


}



app.UseAuthorization(); //midleware authication

app.MapControllers(); //add endpoints
//app.UseEndpoints(endpoin)

app.Run();
