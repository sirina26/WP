using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.WebApp.Models.DemoViewModels
{
    public class DemoWishListViewModel
    {
        public int CLassId { get; set; }

        [Required( ErrorMessage = "Le nom de la tâche ne peut être vide" )]
        [Display( Name = "Nom de tâche", Description = "blablabla" )]
        public string Name { get; set; }

        [Required]
        [MinLength( 2 )]
        [MaxLength( 3 )]
        [Display( Name = "Niveau de la tâche" )]
        public string Level { get; set; }
    }
}
