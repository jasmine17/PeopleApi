namespace PeopleApi.Models
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsActive { get; set; }
    }
}
