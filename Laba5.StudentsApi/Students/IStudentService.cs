namespace Laba5.StudentsApi.Students;

public interface IStudentService
{
    IEnumerable<Student> GetStudentsByScore(double minScore, double maxScore);
}