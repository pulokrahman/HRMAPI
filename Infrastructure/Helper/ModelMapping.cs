using CoreApplication.Entities;
using CoreApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helper
{
    public static class ModelMapping
    {
        public static CandidateResponseModel ToCandidateResponseModel(this Candidate candidate)
        {
            return new CandidateResponseModel
            {
                Id = candidate.Id,
                Email = candidate.Email,
                FirstName = candidate.FirstName,
                LastName = candidate.LastName,
                MiddleName = candidate.MiddleName,
                ResumeURL = candidate.ResumeURL
            };
        }
    }
}
