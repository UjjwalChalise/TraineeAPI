namespace TraineeAPI.Exceptions;

public class SubmissionLimitExceededException : Exception
{
    public SubmissionLimitExceededException(int assignmentId, int studentId)
        : base($"Student {studentId} has already submitted 3 times for Assignment {assignmentId}. No further submissions allowed.")
    {
    }
}