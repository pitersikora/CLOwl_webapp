using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClowlWebApp.Entities
{
    public class CategoryItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Title { get; set; }

        public string Description { get; set; }

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Please select a valid item from the '{0}' dropdown list")]
        [Display(Name = "Media Type")]
        public int MediaTypeId { get; set; }

        [NotMapped]
        public virtual ICollection<SelectListItem> MediaTypes { get; set; }

        [Display(Name = "Release Date")]
        public DateTime DateTimeItemReleased { get; set; }

        [NotMapped]
        public int ContentId { get; set; }

    }
}