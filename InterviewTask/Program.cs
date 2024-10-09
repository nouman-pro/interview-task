using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.GenericRepository;
using Repository.UnitOfWork;
using Services.AutoMappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<Services.Services.Register.IRegisterService, Services.Services.Register.RegisterService>();
builder.Services.AddControllers();

builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
