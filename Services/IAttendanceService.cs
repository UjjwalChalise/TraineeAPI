using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public interface IAttendanceService
{
    Task<IEnumerable<AttendanceViewModel>> GetAttendanceBySessionIdAsync(int sessionId);
    Task<AttendanceViewModel> MarkAttendanceAsync(MarkAttendanceViewModel model);
}