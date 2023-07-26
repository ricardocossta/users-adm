using System.ComponentModel.DataAnnotations;

namespace SetisUsersAdm.Models
{
    public class Perfil
    {
        [Key]
        public int Id { get; set; }
        public Sistema Sistema { get; set; }
        public string Nome { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
