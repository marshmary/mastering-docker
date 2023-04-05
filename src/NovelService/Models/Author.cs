using System.ComponentModel.DataAnnotations;

namespace LightNovelService.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string JpName { get; set; } = null!;

        public string RomajiName { get; set; } = null!;

        public string Twitter { get; set; } = null!;
    }
}