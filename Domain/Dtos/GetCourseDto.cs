using Domain.Entities;

namespace Domain.Dtos;

public class GetCourseDto
{
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string Description { get; set; }
    // public string Name { get; set; }
}

