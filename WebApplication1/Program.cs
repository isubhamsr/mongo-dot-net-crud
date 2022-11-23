using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;
using WebApplication1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.Configure<SchoolDatabaseSettings>(
//        builder.Configuration.GetSection(nameof(SchoolDatabaseSettings)));

//builder.Services.AddSingleton<ISchoolDatabaseSettings>(provider =>
//    provider.GetRequiredService<IOptions<SchoolDatabaseSettings>>().Value);

//builder.Services.AddSingleton<IMongoClient>(s =>
//new MongoClient(builder.Configuration.GetValue<string>("DatabaseSettings")));

builder.Services.Configure<SchoolDatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));


//builder.Services.AddScoped<IStudentService, StudentService>();

builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<CourseService>();

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
