using System;

namespace WeddingPlanner.WebApp.Models.EventViewModels
{
    public class EventViewModel
    {
        public int StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string GitHubLogin { get; set; }
    }
}
