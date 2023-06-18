using System.ComponentModel.DataAnnotations;

namespace BackPustokTemplate.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20,ErrorMessage ="20-den uzun ola bilmez")]
        public string Name { get; set; }

        public List<Book> Books { get;}
    }
}