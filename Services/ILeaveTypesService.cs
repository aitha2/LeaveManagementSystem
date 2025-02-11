using LeaveManagementSystem.Models.LeaveTypes;

namespace LeaveManagementSystem.Services
{
    public interface ILeaveTypesService
    {
        Task<bool> checkLeaveTypeNameExists(string name);
        Task<bool> checkLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit);
        Task Create(LeaveTypeCreateVM leaveTypeCreate);
        Task Edit(LeaveTypeEditVM leaveTypeEdit);
        Task<T> Get<T>(int id) where T : class;
        Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes();
        bool LeaveTypeExists(int id);
        Task Remove(int id);
    }
}