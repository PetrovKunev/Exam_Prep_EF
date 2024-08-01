
namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Boardgames.Data.Models.Enums;

    public class Boardgame
    {
        public Boardgame()
        {
            BoardgamesSellers = new List<BoardgameSeller>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 10)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 10)]
        public double Rating { get; set; }

        [Required]
        [Range(2018, 2023)]
        public int YearPublished { get; set; }

        [Required]
        public CategoryType CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Creator))]
        public int CreatorId { get; set; }
        public Creator Creator { get; set; } = null!;

        public ICollection<BoardgameSeller> BoardgamesSellers { get; set; }
    }
}
