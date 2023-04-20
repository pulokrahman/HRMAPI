using CoreApplication.Entities;
using CoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplication.Contracts.Services
{
    public interface ICandidateService
    {

        Task<int> AddCandidateAsync(CandidateRequestModel can);
        Task<int> UpdateCandidateAsync(CandidateRequestModel can);
        Task<int> DeleteCandidateAsync(int id);
        //Task <CandidateInfoResponseModel> GetCandidateInfo(int id);
        Task<IEnumerable<CandidateResponseModel>> GetAllCandidates();
        Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
    }
}
