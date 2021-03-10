namespace LibraryServices.DTO
{
    public class AuthorBookDTO
    {
        public int AuthorId { get; set; }

        public AuthorDTO Author { get; set; }

        public int BookId { get; set; }

        public BookDTO Book { get; set; }
    }
}
