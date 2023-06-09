﻿using CoreApplication.Contracts.Repository;
using CoreApplication.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CandidateRepository : BaseRepository<Candidate>, ICandidateRepository
    {
        public CandidateRepository(RecruitingDbContext context) : base(context)
        {
        }

        public async Task<Candidate> FirstOrDefaultWithIncludesAsync(Expression<Func<Candidate, bool>> where,
            params Expression<Func<Candidate, object>>[] includes)
        {
            var query = _dbContext.Set<Candidate>().AsQueryable();

            if (includes != null)
                foreach (var navigationProperty in includes)
                    query = query.Include(navigationProperty);

            return await query.FirstOrDefaultAsync(where);
        }


        public async Task<Candidate> GetUserByEmail(string email)
        {
            return await _dbContext.Candidates.Where(x => x.Email == email).FirstOrDefaultAsync();
        }
    }
}