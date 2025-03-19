using EnglishApp.Domain.Repositories;
using EnglishApp.Domain.Services;
using EnglishApp.Infrastructure.Repositories;
using EnglishApp.Infrastructure.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        // SQL Server Service の登録
        builder.Services.AddSingleton<SqlServerService>();

        // Repository の登録
        builder.Services.AddScoped<IPrefectureRepository, PrefectureRepository>();
        builder.Services.AddScoped<IUserGradeRepository, UserGradeRepository>();
        builder.Services.AddScoped<IUserLearningPurposeRepository, UserLearningPurposeRepository>();
        builder.Services.AddScoped<IEnglishTextRepository, EnglishTextRepository>();
        builder.Services.AddScoped<IEnglishChoiceQuestionRepository, EnglishChoiceQuestionRepository>();

        // サービスの登録（追加）
        builder.Services.AddScoped<IRepositoryService, RepositoryService>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();

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
    }
}