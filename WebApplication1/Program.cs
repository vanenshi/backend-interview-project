using Application.Common;
using Application.Customer;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<DataContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddControllers();
builder.Services.AddMediatR(typeof(Create.Command));
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfiles()); });
var mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
