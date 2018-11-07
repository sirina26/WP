using System;

namespace WeddingPlanner.DAL
{
    public class EventData
    {
        public int EventId { get; set; }

        public int CustomerId { get; set; }

        public int OrganizerId { get; set; }

        public int NumberOfGuestes { get; set; }

        public string EventName { get; set; }

        public float MaximumPrice { get; set; }

        public DateTime WeddingDate { get; set; }

        public string Note { get; set; }
    
    }
}
