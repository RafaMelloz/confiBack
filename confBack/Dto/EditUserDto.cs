namespace confBack.Dto
{
    public class EditUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateOnly Birthdate { get; set; }
        public string Schooling { get; set; }
    }
}
