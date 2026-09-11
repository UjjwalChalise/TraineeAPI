namespace TraineeAPI.Exceptions;

public class UnauthorizedAssignmentException : Exception
{
    public UnauthorizedAssignmentException(int teacherId, int courseId)
        : base($"Teacher {teacherId} is not assigned to Course {courseId} and cannot create assignments for it.")
    {
    }
}