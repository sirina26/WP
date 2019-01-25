using System;

namespace WeddingPlanner.WebApp.Models.CommentViewModels
{
    public class CommentViewModels
    {
        public int PropositionId { get; set; }

        public int EventId { get; set; }

        public int OrganizerId { get; set; }

        public string Proposition { get; set; }

        public DateTime PropositionDate { get; set; }

    }
}
