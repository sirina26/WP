using System;

namespace WeddingPlanner.DAL
{
    public class WishListeData
    {
        public int TaskId { get; set; }

        public int CustomerId { get; set; }

        public string Task { get; set; }

        public byte[] StateTask { get; set; }
    }
}



