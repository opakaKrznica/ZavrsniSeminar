using Expert.WebShop.Backend.Api.MojaBaza;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<WebShopVjezba2Context>(options => options.UseSqlServer("Data Source=DESKTOP-JE9G202;Initial" +
    " Catalog=WebShopVjezba2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application" +
    " Intent=ReadWrite;Multi Subnet Failover=False\r\n"));
builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
