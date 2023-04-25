using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserService.Entities
{
    public class User
    {
        [Key]

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string email { get; set; }   
        public string password { get; set; }
        
    }
}
