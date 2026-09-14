using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TraineeAPI.Models
{
    [Table("Users")]
    public class User
    {

        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }


        public string LastName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }
    }
}
