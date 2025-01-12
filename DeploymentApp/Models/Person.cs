using System.ComponentModel;

namespace DeploymentApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }
    }
}
