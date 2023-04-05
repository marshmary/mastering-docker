using System.ComponentModel.DataAnnotations;

namespace LightNovelService.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string JpName { get; set; } = null!;

        public string RomajiName { get; set; } = null!;

        [Url]
        public string Twitter { get; set; } = null!;
    }
}