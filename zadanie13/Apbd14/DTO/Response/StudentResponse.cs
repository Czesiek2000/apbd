namespace Apbd14.DTO.Response
{
    public class StudentResponse
    {
        public int IdStudent { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Index { get; set; }
        public GroupResponse Group { get; set; }
    }
}
