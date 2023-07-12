namespace Evolent.Project.Models
{
    public class Employee : ModelBase
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string EmailAddress { get; set; } = default!;
        public int Age { get; set; } = default!;

        public virtual Address Address { get; set; }
    }
}
