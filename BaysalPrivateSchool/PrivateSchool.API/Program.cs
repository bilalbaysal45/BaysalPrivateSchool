using Microsoft.EntityFrameworkCore;
using PrivateSchool.Business.Abstract;
using PrivateSchool.Business.Concrete;
using PrivateSchool.Data.Abstract;
using PrivateSchool.Data.Concrete.EfCore.Contexts;
using PrivateSchool.Data.Concrete.EfCore.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddDbContext<PrivateSchoolDbContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));

builder.Services.AddScoped<ITeacherRepository,EfCoreTeacherRepository>();
builder.Services.AddScoped<ITeacherService, TeacherManager>();

builder.Services.AddScoped<ISchoolInfoRepository, EfCoreSchoolInfoRepository>();
builder.Services.AddScoped<ISchoolInfoService, SchoolInfoManager>();

builder.Services.AddScoped<IStudentClubRepository, EfCoreStudentClubRepository>();
builder.Services.AddScoped<IStudentClubService, StudentClubManager>();

builder.Services.AddScoped<INewsRepository,EfCoreNewsRepository>();
builder.Services.AddScoped<INewsService,NewsManager>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


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
