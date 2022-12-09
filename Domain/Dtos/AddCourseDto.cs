using Domain.Entities;

namespace Domain.Dtos;

public class AddCourseDto
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    public int StudentId { get; set; }
}

