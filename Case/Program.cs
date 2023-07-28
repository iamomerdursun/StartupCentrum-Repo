using Repository;
using Repository.DesingPattern;
using Repository.Repository.Student;
using Repository.Repository.StudentRepo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region DI
builder.Services.AddTransient<AppDbContext>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
#endregion

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
