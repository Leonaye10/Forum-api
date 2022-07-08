using forum_api_back.DataAccess.DataObjects;
using forum_api_back.Interfaces;
using forum_api_back.Repositories;
using forum_api_back.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<forumdbContext>();

// Ajout des repositories
builder.Services.AddTransient<ITopicRepository, TopicRepository>();
builder.Services.AddTransient<ICommentRepository, CommentRepository>();

// Ajout des Services
builder.Services.AddTransient<ITopicService, TopicService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddTransient<IWorldFilterService, WorldFilterService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("EnableCORS", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EnableCORS");
app.UseAuthorization();

app.MapControllers();

app.Run();
