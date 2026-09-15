namespace TraineeAPI.Models;

public class Attachment
{
    public int Id { get; set; }
    public string FileName { get; set; }
    public string FilePath { get; set; }
    public string FileType { get; set; }

    public int LessonId { get; set; }
    public Lesson Lesson { get; set; }
}