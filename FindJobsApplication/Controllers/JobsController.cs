using AutoMapper;
using FindJobsApplication.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace FindJobsApplication.Controllers
{
    [AllowAnonymous]
    [Route("odata/[controller]")]
    [ApiController]
    public class JobsController : ODataController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public JobsController(IUnitOfWork unitOfWork, IConfiguration configuration, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
            _mapper = mapper;
        }

        [HttpGet("jobs")]
        [EnableQuery]
        [AllowAnonymous]
        public IActionResult GetJobsOData()
        {
            var jobs = _unitOfWork.Job.GetAll().AsQueryable();
            return Ok(jobs);
        }


    }
}
