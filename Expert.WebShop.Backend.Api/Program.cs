using Azure.Core;
using Expert.WebShop.Backend.Api.MojaBaza;
using Microsoft.DotNet.Scaffolding.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
var dbConnectionString = builder.Configuration.
    GetValue<string>("ConnectionString");
// Add services to the container.
builder.Services.AddDbContext<WebShopVjezba2Context>
    (options => options.
    UseSqlServer(dbConnectionString));
builder.Services.AddControllers();

builder.Services.AddDirectoryBrowser();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
               .AllowAnyMethod()
               .AllowAnyHeader()
               .SetIsOriginAllowed(origin => true) // allow any origin
               .AllowCredentials()); // allow credentials

app.UseStaticFiles();

app.UseFileServer(
    new FileServerOptions
    {
        FileProvider = new
        PhysicalFileProvider(
            Path.Combine(builder.Environment
            .ContentRootPath, "WebShopPictures")),
        RequestPath = "/WebShopPictures",
        EnableDirectoryBrowsing = true
    }
    );

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();