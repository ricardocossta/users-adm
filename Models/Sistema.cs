using System.ComponentModel.DataAnnotations;

namespace SetisUsersAdm.Models
{
    public class Sistema
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }
    }
}
