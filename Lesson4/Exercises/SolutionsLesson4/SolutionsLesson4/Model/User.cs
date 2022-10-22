using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SolutionsLesson4.Model
{
    public class User
    {
        public User(string name, int age, string address, Gender gender)
        {
            Name = name;
            Age = age;
            Address = address;
            Gender = gender;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public Gender Gender { get; set; }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Gender
    {
        Male,
        Female,
        Other
    }
}
