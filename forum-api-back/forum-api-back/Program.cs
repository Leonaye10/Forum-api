using forum_api_back.Repositories;
using forum_api_back.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Ajout des repositories
builder.Services.AddTransient<TopicRepository>();
builder.Services.AddTransient<CommentRepository>();

// Ajout des Services
builder.Services.AddTransient<TopicService>();
builder.Services.AddTransient<CommentService>();


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
