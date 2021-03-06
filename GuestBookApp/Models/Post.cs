using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GuestBookApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        [DisplayName("Nick")]
        [Required(ErrorMessage = "Please write a Nick")]
        [MaxLength(20)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please write a Comment")]
        [MaxLength(50)]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Please write a email")]
        [MaxLength(30)]
        public string Email { get; set; }
        public DateTime ReleaseDate { get; set; }

        public Post()
        {
            ReleaseDate = DateTime.Now;
        }
    }
}
