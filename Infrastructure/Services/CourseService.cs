using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CourseService
{
    private readonly DataContext _context;
    public CourseService(DataContext context)
    {
        _context = context;
    }
    public async Task<Response<List<GetCourseDto>>> Get()
    {
        var list = await _context.Courses.Select(t => new GetCourseDto()
        {
            CourseId = t.CourseId,
            CourseName = t.CourseName,
            Description = t.Description
        }).ToListAsync();
        await _context.SaveChangesAsync();
        return new Response<List<GetCourseDto>>(list);
    }

    public async Task<Response<AddCourseDto>> Add(AddCourseDto course)
    {
        var newCourse = new Course()
        {
            CourseName = course.CourseName,
            Description = course.Description
        };
        _context.Courses.Add(newCourse);
        await _context.SaveChangesAsync();
        return new Response<AddCourseDto>(course);
    }

    public async Task<Response<AddCourseDto>> Update(AddCourseDto course)
    {
        var find = await _context.Courses.FindAsync(course.CourseId);
        find.CourseId = course.CourseId;
        find.CourseName = course.CourseName;
        find.Description = course.Description;
        await _context.SaveChangesAsync();
        return new Response<AddCourseDto>(course);
    }

    public async Task<Response<string>> Delete(int id)
    {
        var find = await _context.Courses.FindAsync(id);
        _context.Courses.Remove(find);
        await _context.SaveChangesAsync();
        return new Response<string>("Course succesfullt deleted");
    }
}
