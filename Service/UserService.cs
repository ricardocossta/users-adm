using SetisUsersAdm.Models;
using System.Xml.Linq;

namespace SetisUsersAdm.Service
{
    public class UserService : IUserService
    {
        public void PopularListaDeUsuarios(IFormFile file, ICollection<Usuario> usuarios)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyTo(memoryStream);
                memoryStream.Position = 0;

                XDocument xmlDocument = XDocument.Load(memoryStream);

                foreach (var u in xmlDocument.Descendants("Usuario"))
                {
                    var usuario = new Usuario
                    {
                        Id = int.Parse(u.Element("Id").Value),
                        Nome = u.Element("Nome").Value,
                        Login = u.Element("Login").Value,
                        Senha = u.Element("Senha").Value,
                        Bloqueado = u.Element("Bloqueado").Value == "1" ? true : false,
                        DataAcesso = DateTime.Parse(u.Element("DataAcesso").Value),
                        Entidade = new Entidade
                        {
                            Id = int.Parse(u.Element("Entidade").Element("Id").Value),
                            Nome = u.Element("Entidade").Element("Nome").Value,
                            Responsavel = u.Element("Entidade").Element("Responsavel").Value,
                            TerminalPrefixo = int.Parse(u.Element("Entidade").Element("TerminalPrefixo").Value)
                        },
                        Perfis = new List<Perfil>()
                    };
                    foreach (var p in u.Descendants("Perfil"))
                    {
                        usuario.Perfis.Add(new Perfil
                        {
                            Id = int.Parse(p.Element("Id").Value),
                            Nome = p.Element("Nome").Value,
                            Sistema = new Sistema
                            {
                                Id = int.Parse(p.Element("Sistema").Element("Id").Value),
                                Nome = p.Element("Sistema").Element("Nome").Value,
                                Link = p.Element("Sistema").Element("Link").Value
                            }
                        });
                    }
                    usuarios.Add(usuario);
                }
            }
        }
    }
}
