namespace lesson4_exercice.Dto
{
    public class UserDto
    {
        public UserDto(string id, string name, int age, string address, string gender)
        {
            Id = id;
            Name = name;
            Age = age;
            Address = address;
            Gender = gender;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
