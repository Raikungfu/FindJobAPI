using AutoMapper;
using FindJobsApplication.Models;
using FindJobsApplication.Models.ViewModel;
using FindJobsApplication.Repository.IRepository;
using FindJobsApplication.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FindJobsApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobServiceController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUploadFileService _uploadFileService;

        public JobServiceController(IUnitOfWork unitOfWork, IMapper mapper, IUploadFileService uploadFileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadFileService = uploadFileService;
        }

        // GET: api/<JobServiceController>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_unitOfWork.JobService.GetAll(filter: null, orderBy: query => query.OrderBy(job => job.Price), null).ToList());
        }

        // GET api/<JobServiceController>/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_unitOfWork.JobService.GetFirstOrDefault(x => x.JobServiceId == id));
        }

        // POST api/<JobServiceController>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Post([FromBody] JobServiceViewModel jobService)
        {
            try
            {
                ModelState.Remove("Image");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var claimId = User.FindFirstValue("Id");
                if (claimId == null || !int.TryParse(claimId, out int adminId))
                {
                    return Unauthorized("User not logged in. Please log in to continue.");
                }

                JobService newJobServie = _mapper.Map<JobService>(jobService);

                if (jobService.Image != null)
                {
                    newJobServie.Image = _uploadFileService.uploadImage(jobService.Image, "Images");
                }

                newJobServie.AdminId = adminId;
                _unitOfWork.JobService.Add(newJobServie);
                _unitOfWork.Save();
                return CreatedAtRoute("GetJob", new { jobId = newJobServie.JobServiceId }, jobService);
            }
            catch (Exception e)
            {
                return BadRequest("Error while create: " + e.Message);
            }
           
        }

        // PUT api/<JobServiceController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] JobServiceViewModel jobService)
        {
            try
            {
                ModelState.Remove("Image");
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var claimId = User.FindFirstValue("Id");
                if (claimId == null || !int.TryParse(claimId, out int adminId))
                {
                    return Unauthorized("User not logged in. Please log in to continue.");
                }

                JobService updateJobService = _mapper.Map<JobService>(jobService);

                if (jobService.Image != null)
                {
                    updateJobService.Image = _uploadFileService.uploadImage(jobService.Image, "Images");
                }

                _unitOfWork.JobService.Update(updateJobService);
                _unitOfWork.Save();

                return CreatedAtRoute("GetJob", new { jobId = updateJobService.JobServiceId }, updateJobService);
            }catch(Exception e)
            {
                return BadRequest("Error while update: " + e.Message);
            }
        }

        // DELETE api/<JobServiceController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _unitOfWork.JobService.Remove(id);
                _unitOfWork.Save();
                return Ok("Delete job service success!");
            }catch(Exception e)
            {
                return BadRequest("Error while delete: " + e.Message);
            }
        }
    }
}
