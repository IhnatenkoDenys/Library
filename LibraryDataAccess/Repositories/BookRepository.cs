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
    public class BookRepository : EfRepository<Book>
    {
        public BookRepository(LibraryContext dbContext) : base(dbContext)
        {
        }

        public override async Task<Book> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Books
                                   .Include(x => x.AuthorBooks)
                                   .ThenInclude(x => x.Author)
                                   .Include(x => x.Publisher)
                                   .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public override async Task<List<Book>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Books
                                   .Include(x => x.AuthorBooks)
                                   .ThenInclude(x => x.Author)
                                   .Include(x => x.Publisher)
                                   .ToListAsync(cancellationToken);
        }

        public override async Task<List<Book>> ListAllAsync(Expression<Func<Book, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Books
                                   .Include(x => x.AuthorBooks)
                                   .ThenInclude(x => x.Author)
                                   .Include(x => x.Publisher)
                                   .Where(predicate)
                                   .ToListAsync(cancellationToken);
        }
    }
}
