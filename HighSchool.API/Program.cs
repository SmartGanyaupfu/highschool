using HighSchool.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Add services to the container.

if (app.Environment.IsDevelopment())
{
    builder.Services.ConfigureSqliteContext(builder.Configuration);
}
if (app.Environment.IsProduction())
{
    builder.Services.ConfigureSqlServerContext(builder.Configuration);
}
builder.Services.ConfigureCors();
builder.Services.ConfigureEmail(builder.Configuration);
builder.Services.ConfigureEmailService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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

