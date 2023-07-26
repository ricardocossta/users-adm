using System.ComponentModel.DataAnnotations;

namespace SetisUsersAdm.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public Entidade Entidade { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime? DataAcesso { get; set; }
        public ICollection<Perfil> Perfis { get; set; }
    }
}
