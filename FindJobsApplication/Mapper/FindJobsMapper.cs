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
        }
    }
}