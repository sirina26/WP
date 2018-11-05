using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingPlanner.WebApp.Models.DemoViewModels
{
    public class DemoClassViewModel
    {
        public int ClassId { get; set; }

        [Required( ErrorMessage = "Le nom de la classe ne peut être vide")]
        [Display(Name = "Nom de la classe", Description = "blablabla")]
        public string Name { get; set; }

        [Required]
        [MinLength( 2 )]
        [MaxLength( 3 )]
        [Display(Name = "Niveau de la classe")]
        public string Level { get; set; }
    }
}
