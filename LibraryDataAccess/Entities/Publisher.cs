using System.ComponentModel.DataAnnotations;

namespace LibraryDataAccess.Entities
{
    public class Publisher : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
