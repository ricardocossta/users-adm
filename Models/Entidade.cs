using System.ComponentModel.DataAnnotations;

namespace SetisUsersAdm.Models
{
    public class Entidade
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Responsavel { get; set; }
        public int? TerminalPrefixo { get; set; }

    }
}
