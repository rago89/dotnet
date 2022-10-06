﻿namespace lesson4_exercice.Models
{
    public class User
    {
        private readonly string _id = String.Empty;
        private string _email = String.Empty;
        private string _password = String.Empty;
        private string _name = String.Empty;
        private int _age;
        private string _address = String.Empty;
        private string _gender = String.Empty;

        public User() { }

        public User(string name, int age, string address, string gender, string email, string password)
        {
            _id = Guid.NewGuid().ToString();
            Name = name;
            Age = age;
            Address = address;
            Gender = gender;
            Email = email;
            Password = password;
        }

        public string Id { get => _id; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }

        public string Name
        {
            get => _name;
            set => _name = IsValidStringInput(value) ? value : String.Empty;
        }

        public int Age
        {
            get => _age;
            set => _age = (value < 1 || value > 120) ? 0 : value;
        }

        public string Address
        {
            get => _address;
            set => _address = IsValidStringInput(value) ? value : String.Empty;

        }

        public string Gender
        {
            get => _gender;
            set => _gender = IsValidStringInput(value) ? value : String.Empty;
        }
        private static bool IsValidStringInput(string? value)
        {
            if (String.IsNullOrEmpty(value)) return false;
            return true;
        }
    }
}
