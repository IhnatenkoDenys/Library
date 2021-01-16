using System.ComponentModel.DataAnnotations;

namespace LibraryDataAccess.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
