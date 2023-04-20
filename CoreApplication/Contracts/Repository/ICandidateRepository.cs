using CoreApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreApplication.Contracts.Repository
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {
        Task<Candidate> GetUserByEmail(string email);
        Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where,
          params Expression<Func<Candidate, object>>[] includes);
    }
}
