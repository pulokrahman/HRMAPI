using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Infrastructure.Services;
using CoreApplication.Contracts.Services;
using CoreApplication.Entities;
using CoreApplication.Models;

namespace HRMAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
     
   
        private readonly ICandidateService candidateService;
       public CandidateController(ICandidateService _candidateService)
        {
            candidateService = _candidateService; 
        }



        [HttpGet]
        public async Task<IActionResult> GetCandidates()
        {
            try
            {
                var cand = await candidateService.GetAllCandidates();
            
                    return Ok(cand);
            }
            catch
            { //BadRequest();
              //404 if not found
                return NotFound();
                //return Ok();
            }


        }
        [HttpGet]
        [Route("FindSingle/{id}")]
        public async Task<IActionResult> FindSingleCandidate(int id)
        {
            try
            {
                var can=await candidateService.GetCandidateByIdAsync(id);
                return Ok(can);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidateRequestModel can)
        {
            try
            {
                await candidateService.AddCandidateAsync(can);
                return Ok(can);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            try
            {
                await candidateService.DeleteCandidateAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }


        }
        [HttpPut]
        public async Task<IActionResult> UpdateCandidate(CandidateRequestModel can)
           {
            try
            {
                await candidateService.UpdateCandidateAsync(can);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

    }
}
