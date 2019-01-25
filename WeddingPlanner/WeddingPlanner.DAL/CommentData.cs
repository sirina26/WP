using System;

namespace WeddingPlanner.DAL
{
   public class CommentData
    {
        public int PropositionId { get; set; }

        public int EventId { get; set; }

        public int OrganizerId { get; set; }

        public string Proposition { get; set; }

        public DateTime PropositionDate { get; set; }
    }
}
