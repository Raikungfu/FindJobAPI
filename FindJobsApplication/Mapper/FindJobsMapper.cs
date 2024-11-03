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
        }
    }
}