namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    public class Seller
    {
        public Seller()
        {
            BoardgamesSellers = new List<BoardgameSeller>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(30, MinimumLength = 2)]
        public string Address { get; set; } = null!;

        [Required]
        public string Country { get; set; } = null!;

        [Required]
        
        public string Website { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
