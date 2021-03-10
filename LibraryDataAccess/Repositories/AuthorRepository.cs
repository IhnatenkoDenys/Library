using LibraryDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryDataAccess.Repositories
{
    public class AuthorRepository : EfRepository<Author>
    {
        public AuthorRepository(LibraryContext dbContext) 
            : base(dbContext)
        {
        }

        public override async Task<Author> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Author>().Include(x => x.Country).FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<List<Author>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Author>().Include(x => x.Country).ToListAsync(cancellationToken);
        }

        public override async Task<List<Author>> ListAllAsync(Expression<Func<Author, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Author>().Include(x => x.Country).Where(predicate).ToListAsync(cancellationToken);
        }
    }
}
