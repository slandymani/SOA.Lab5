using System.Text.Json.Serialization;
using Laba5.StudentsApi.Students;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppJsonSerializerContext.Default);
});

builder.Services.AddSingleton<IStudentService>(sp =>
{
    var he = sp.GetRequiredService<IWebHostEnvironment>();
    return new StudentService(he.ContentRootPath);
});
builder.Services.AddCors();

var app = builder.Build();
app.UseCors(cp => cp.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapGet("/students", 
    (IStudentService studentService, [FromQuery] double minScore, [FromQuery] double maxScore) =>
        Results.Ok(studentService.GetStudentsByScore(minScore, maxScore)));

app.Run();

[JsonSerializable(typeof(IEnumerable<Student>))]
internal partial class AppJsonSerializerContext : JsonSerializerContext
{
}