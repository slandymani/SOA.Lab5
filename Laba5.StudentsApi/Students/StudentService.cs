using System.Xml.Linq;

namespace Laba5.StudentsApi.Students;

public class StudentService(string contentPath) : IStudentService
{
    public IEnumerable<Student> GetStudentsByScore(double minScore, double maxScore) =>
        XDocument.Load(Path.Combine(contentPath, "students.xml")).Descendants("student").Select(x =>
                new Student(x.Element("lastName")?.Value ?? "",
                    x.Element("firstName")?.Value ?? "", x.Element("middleName")?.Value ?? "",
                    double.Parse(x.Element("averageScore")?.Value ?? "0")))
            .Where(s => s.AverageScore >= minScore && s.AverageScore <= maxScore);
}