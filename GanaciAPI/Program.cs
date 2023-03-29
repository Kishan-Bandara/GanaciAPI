using GanaciAPI.Models;
using GanaciAPI.Models.DataBaseSettings;
using GanaciAPI.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Dependency Injection
//Read database connection string 
builder.Services.Configure<StudentStoreDatabaseSettings>(
                builder.Configuration.GetSection(nameof(StudentStoreDatabaseSettings)));

builder.Services.AddSingleton<IStudentStoreDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<StudentStoreDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("StudentStoreDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<IStudentService, StudentService>();

//Define SingUp
//Read database connection string 
builder.Services.Configure<UserDetailsDatabaseSettings>(
                builder.Configuration.GetSection(nameof(UserDetailsDatabaseSettings)));

builder.Services.AddSingleton<IUserDetailsDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<UserDetailsDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
        new MongoClient(builder.Configuration.GetValue<string>("UserDetailsDatabaseSettings:ConnectionString")));

builder.Services.AddScoped<ISignUpService, SignUpService>();
//builder.Services.AddScoped<ISignUpService, SignUpService>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//Enable Cross Origin
builder.Services.AddCors(options => options.AddPolicy(name: "ganaciOrigins",
    policy =>
    {
        policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
    }));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ganaciOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
