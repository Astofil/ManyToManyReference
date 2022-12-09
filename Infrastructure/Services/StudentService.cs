using Domain.Dtos;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class StudentService
{
    private readonly DataContext _context;
    public StudentService(DataContext context)
    {
        _context = context;
    }
    public async Task<List<GetStudentDto>> Get()
    {
        var list = await _context.Students.Select(t => new GetStudentDto()
        {
            StudentId = t.StudentId,
            Name = t.Name
        }).ToListAsync();
        return list;
    }

    public async Task<AddStudentDto> Add(AddStudentDto student)
    {
        var newStudent = new Student()
        {
            Name = student.Name,
        };
        _context.Students.Add(newStudent);
        await _context.SaveChangesAsync();
        return student;
    }

    public async Task<AddStudentDto> Update(AddStudentDto student)
    {
        var find = await _context.Students.FindAsync(student.StudentId);
        find.Name = student.Name;
        await _context.SaveChangesAsync();
        return student;

    }

    public async Task<string> Delete(int id)
    {
        var find = await _context.Students.FindAsync(id);
        _context.Students.Remove(find);
        await _context.SaveChangesAsync();
        return "Student deleted succesfully";
    }
}
