using ApiSysSchoolar.Repositories.Application;
using ApiSysSchoolar.Repositories;

SQLitePCL.Batteries.Init();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IClassRepo, ClassRepo>();
builder.Services.AddScoped<INotesRepo, NotesRepo>();
builder.Services.AddScoped<ISchedulesRepo, SchedulesRepo>();
builder.Services.AddScoped<ISchoolarLevelsRepo, SchoolarLevelsRepo>();
builder.Services.AddScoped<IStudentsRepo, StudentsRepo>();
builder.Services.AddScoped<ISubjectFullRepo, SubjectFullRepo>();
builder.Services.AddScoped<ISubjectsRepo, SubjectsRepo>();
builder.Services.AddScoped<ISublevelsRepo, SubLevelsRepo>();
builder.Services.AddScoped<ITeachersRepo, TeachersRepo>();

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
