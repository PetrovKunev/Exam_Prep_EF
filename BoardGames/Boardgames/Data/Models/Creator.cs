

namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Creator
    {
        public Creator() 
        {
            Boardgames = new List<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(7, MinimumLength = 2)]
        public string LastName { get; set; } = null!;

        public ICollection<Boardgame> Boardgames { get; set; }
    }
}
