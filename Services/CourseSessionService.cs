using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class CourseSessionService : ICourseSessionService
{
    private readonly ICourseSessionRepository _sessionRepository;

    public CourseSessionService(ICourseSessionRepository sessionRepository) => _sessionRepository = sessionRepository;

    public async Task<IEnumerable<CourseSessionViewModel>> GetSessionsByCourseIdAsync(int courseId)
        => (await _sessionRepository.GetByCourseIdAsync(courseId)).Select(MapToViewModel);

    public async Task<CourseSessionViewModel?> GetSessionByIdAsync(int id)
    {
        var session = await _sessionRepository.GetByIdAsync(id);
        return session is null ? null : MapToViewModel(session);
    }

    public async Task<CourseSessionViewModel> CreateSessionAsync(CreateCourseSessionViewModel model)
    {
        var session = new CourseSession
        {
            CourseId = model.CourseId,
            SessionDate = model.SessionDate,
            StartTime = model.StartTime,
            EndTime = model.EndTime,
            Topic = model.Topic
        };

        await _sessionRepository.AddAsync(session);
        await _sessionRepository.SaveChangesAsync();

        var saved = await _sessionRepository.GetByIdAsync(session.Id);
        return MapToViewModel(saved!);
    }

    public async Task<bool> DeleteSessionAsync(int id)
    {
        var session = await _sessionRepository.GetByIdAsync(id);
        if (session is null) return false;

        _sessionRepository.Delete(session);
        return await _sessionRepository.SaveChangesAsync();
    }

    private static CourseSessionViewModel MapToViewModel(CourseSession session) => new()
    {
        Id = session.Id,
        CourseId = session.CourseId,
        CourseTitle = session.Course.Title,
        SessionDate = session.SessionDate,
        StartTime = session.StartTime,
        EndTime = session.EndTime,
        Topic = session.Topic
    };
}