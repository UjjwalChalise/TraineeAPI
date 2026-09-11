namespace TraineeAPI.Exceptions;

public class DuplicateEnrollmentException : Exception
{
    public DuplicateEnrollmentException(int studentId, int moduleId)
        : base($"Student {studentId} is already enrolled in Module {moduleId}.")
    {
    }
}