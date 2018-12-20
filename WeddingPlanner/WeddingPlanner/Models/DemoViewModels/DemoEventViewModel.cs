using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingPlanner.WebApp.Models.DemoViewModels
{
    public class DemoEventViewModel
    {
        public int ClassId { get; set; }

        [Required( ErrorMessage = "Le nom de l'évènement ne peut être vide")]
        [Display(Name = "Nom de l'évènement", Description = "blablabla")]
        public string Name { get; set; }

        [Required]
        [MinLength( 2 )]
        [MaxLength( 3 )]
        [Display(Name = "Niveau de l'évènement" )]
        public string Level { get; set; }
    }
}
