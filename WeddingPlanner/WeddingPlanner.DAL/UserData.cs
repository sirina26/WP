namespace WeddingPlanner.DAL
{
    public class UserData
    {
        public int UserId { get; set; }

        public string Email { get; set; }

        public byte[] Password { get; set; }

        public string GoogleRefreshToken { get; set; }

        public string GoogleId { get; set; }

        public bool IsOrganizer { get; set; }
    }
}
