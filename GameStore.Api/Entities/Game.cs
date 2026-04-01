using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Entities;

    public class Game
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(50)]
        public string Name { get; set; } = String.Empty;
        public required string Genre { get; set; 
        }
        public decimal Price { get; set; } 
        public DateTime ReleaseDate { get; set; }
        [Url]
        public required string ImageUrl { get; set; }

    
    }
