namespace lesson4_exercice.Models
{
    public class DBUser
    {
        public DBUser()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; set; }
    }
}
