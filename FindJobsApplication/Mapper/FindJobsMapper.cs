using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.ViewModel;

namespace FindJobsApplication.Mapper
{
    public class FindJobsMapper : Profile
    {
        public FindJobsMapper()
        {
            CreateMap<Job, JobViewModel>().ReverseMap();
            CreateMap<JobApply, JobApplyViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<JobService, JobServiceViewModel>().ReverseMap();
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Hire, HireViewModel>().ReverseMap();
            CreateMap<User, CreateUserViewModels>().ReverseMap();
            CreateMap<User, UpdateUserViewModel>().ReverseMap();
        }
    }
}