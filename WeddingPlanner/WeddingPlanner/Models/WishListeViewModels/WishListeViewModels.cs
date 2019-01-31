using System;
namespace WeddingPlanner.WebApp.Models.WishListeViewModels
{
    public class WishListeViewModel
    {
        public string FirstName { get; set; }

        public int TaskId { get; set; }

        public int CustomerId { get; set; }

        public string Task { get; set; }

        public bool StateTask { get; set; }
    }
}
