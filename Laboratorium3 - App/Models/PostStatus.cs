using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Laboratorium3___App.Models
{
    public enum PostStatus
    {
        [Display(Name = "Oczekujący")]
        Pending,
        [Display(Name = "Opublikowany")]
        Published,
        [Display(Name = "Archiwalny")]
        Archived
    }
}
