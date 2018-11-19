using System;

namespace WeddingPlanner.WebApp.Models.EventViewModels
{
    public class EventViewModel
    {
        public float MaximumPrice { get; set; }

        public int EventId { get; set; }

        public int CustomerId { get; set; }

        public int OrganizerId { get; set; }

        public int NumberOfGuestes { get; set; }

        public string EventName { get; set; }

        public string Note { get; set; }

        public string Place { get; set; }

        public DateTime WeddingDate { get; set; }
       
    }
}
