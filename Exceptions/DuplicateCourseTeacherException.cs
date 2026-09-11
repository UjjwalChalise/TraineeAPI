namespace TraineeAPI.Exceptions;

public class DuplicateCourseTeacherException : Exception
{
    public DuplicateCourseTeacherException(int courseId, int teacherId)
        : base($"Teacher {teacherId} is already assigned to Course {courseId}.")
    {
    }
}