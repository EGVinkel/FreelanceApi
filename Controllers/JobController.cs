using System.Collections.Generic;
using Freelance_Api.Models;
using Freelance_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freelance_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController: ControllerBase
    {
        private readonly JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public ActionResult<List<Job>> Get() =>
            _jobService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Job> Get(string id)
        {
            var job = _jobService.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            return job;
        }

        [HttpPost]
        public ActionResult<Job> Create(Job job)
        {
            _jobService.Create(job);

            return job;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Job jobin)
        {
            var job = _jobService.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            _jobService.Update(id, jobin);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var job = _jobService.Get(id);

            if (job == null)
            {
                return NotFound();
            }

            _jobService.Remove(job.Id);



            return NoContent();
        }
    }
}