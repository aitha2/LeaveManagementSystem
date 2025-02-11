using System.Drawing.Text;
using AutoMapper;
using LeaveManagementSystem.Data;
using LeaveManagementSystem.Models.LeaveTypes;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementSystem.Services;
public class LeaveTypesService(ApplicationDbContext _context, IMapper _mapper) : ILeaveTypesService
{

    public async Task<List<LeaveTypeReadOnlyVM>> GetAllLeaveTypes()
    {
        var data = await _context.LeaveTypes.ToListAsync();
        var viewData = _mapper.Map<List<LeaveTypeReadOnlyVM>>(data);
        return viewData;
    }

    public async Task<T> Get<T>(int id) where T : class
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);
        if (data == null)
        {
            return null;
        }
        var viewData = _mapper.Map<T>(data);
        return viewData;
    }

    public async Task Remove(int id)
    {
        var data = await _context.LeaveTypes.FirstOrDefaultAsync(m => m.Id == id);
        if (data != null)
        {
            _context.LeaveTypes.Remove(data);
            await _context.SaveChangesAsync();
        }
    }

    public async Task Edit(LeaveTypeEditVM leaveTypeEdit)
    {
        var leaveType = _mapper.Map<LeaveType>(leaveTypeEdit);
        _context.Update(leaveType);
        await _context.SaveChangesAsync();
    }
    public async Task Create(LeaveTypeCreateVM leaveTypeCreate)
    {
        var leaveType = _mapper.Map<LeaveType>(leaveTypeCreate);
        _context.Add(leaveType);
        await _context.SaveChangesAsync();
    }
    public bool LeaveTypeExists(int id)
    {
        return _context.LeaveTypes.Any(e => e.Id == id);
    }
    public async Task<bool> checkLeaveTypeNameExists(string name)
    {
        var lowercasename = name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercasename));
    }

    public async Task<bool> checkLeaveTypeNameExistsForEdit(LeaveTypeEditVM leaveTypeEdit)
    {
        var lowercasename = leaveTypeEdit.Name.ToLower();
        return await _context.LeaveTypes.AnyAsync(q => q.Name.ToLower().Equals(lowercasename) &&
        q.Id != leaveTypeEdit.Id);
    }


}

        
