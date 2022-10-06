namespace lesson4_exercice.Models
{
    public class DB
    {
        public DB()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; set; }
    }
}
