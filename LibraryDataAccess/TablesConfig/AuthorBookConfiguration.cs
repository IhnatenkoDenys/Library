using LibraryDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryDataAccess.TablesConfig
{
    public class AuthorBookConfiguration : IEntityTypeConfiguration<AuthorBook>
    {
        public void Configure(EntityTypeBuilder<AuthorBook> builder)
        {
            builder.HasKey(t => new { t.AuthorId, t.BookId });

            builder.HasOne(authorBook => authorBook.Author)
                   .WithMany(author => author.AuthorBooks)
                   .HasForeignKey(authorBook => authorBook.AuthorId);

            builder.HasOne(authorBook => authorBook.Book)
                   .WithMany(book => book.AuthorBooks)
                   .HasForeignKey(authorBook => authorBook.BookId);
        }
    }
}
