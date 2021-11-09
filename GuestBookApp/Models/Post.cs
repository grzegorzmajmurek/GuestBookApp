using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public DateTime ReleaseDate { get; set; }
    }
}
