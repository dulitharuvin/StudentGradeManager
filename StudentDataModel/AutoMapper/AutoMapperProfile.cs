using AutoMapper;
using StudentDataModel.DTO;

namespace StudentDataModel.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentDTO>();
            CreateMap<Course, CourseDTO>();
            CreateMap<StudentDTO, Student>();
            CreateMap<CourseDTO, Course>();
        }
    }
}
