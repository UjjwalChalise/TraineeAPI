using TraineeAPI.Models;
using TraineeAPI.Repositories;
using TraineeAPI.ViewModel;

namespace TraineeAPI.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceService(IAttendanceRepository attendanceRepository) => _attendanceRepository = attendanceRepository;

    public async Task<IEnumerable<AttendanceViewModel>> GetAttendanceBySessionIdAsync(int sessionId)
        => (await _attendanceRepository.GetBySessionIdAsync(sessionId)).Select(MapToViewModel);

    public async Task<AttendanceViewModel> MarkAttendanceAsync(MarkAttendanceViewModel model)
    {
        // Upsert: if this student already has a record for this session, correct it instead of duplicating
        var existing = await _attendanceRepository.GetBySessionAndStudentAsync(model.CourseSessionId, model.StudentId);

        if (existing is not null)
        {
            existing.Status = model.Status;
            existing.Remarks = model.Remarks;
            _attendanceRepository.Update(existing);
            await _attendanceRepository.SaveChangesAsync();
            return MapToViewModel(existing);
        }

        var attendance = new Attendance
        {
            CourseSessionId = model.CourseSessionId,
            StudentId = model.StudentId,
            Status = model.Status,
            Remarks = model.Remarks
        };

        await _attendanceRepository.AddAsync(attendance);
        await _attendanceRepository.SaveChangesAsync();
        return MapToViewModel(attendance);
    }

    private static AttendanceViewModel MapToViewModel(Attendance attendance) => new()
    {
        Id = attendance.Id,
        CourseSessionId = attendance.CourseSessionId,
        StudentId = attendance.StudentId,
        Status = attendance.Status,
        Remarks = attendance.Remarks
    };
}