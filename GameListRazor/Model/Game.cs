using System.ComponentModel.DataAnnotations;

namespace GameListRazor
{
    public class Game
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string GameSystem { get; set; }
        public string Genre { get; set; }
    }
}
