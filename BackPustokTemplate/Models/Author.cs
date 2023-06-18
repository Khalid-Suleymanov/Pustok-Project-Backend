using System.ComponentModel.DataAnnotations;

namespace BackPustokTemplate.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        public List<Book> Books { get; set; }
    }
}