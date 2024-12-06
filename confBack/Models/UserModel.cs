namespace confBack.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Schooling { get; set; }
    }
}
