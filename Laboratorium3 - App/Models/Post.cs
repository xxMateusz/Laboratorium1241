using Laboratorium3___App.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Laboratorium3___App.Models
{
    public class Post
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "Wprowadź zawartość posta!")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Podaj autora!")]
        public string Author { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublicationDate { get; set; }
        [Display(Name = "Status")]
        public PostStatus Status { get; set; }

        public string Tags { get; set; }

        [StringLength(500, ErrorMessage = "Komentarz nie może przekraczać 500 znaków")]
        public string Comment { get; set; }
        [Display(Name = "Data utworzenia")]
        [HiddenInput]
        public DateTime Created { get; set; }
    }
}
