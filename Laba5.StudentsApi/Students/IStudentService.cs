namespace Laba5.StudentsApi.Students;

public interface IStudentService
{
    IEnumerable<Student> GetStudentsByScore(GetStudentsByScoreDto dto);
}