using SetisUsersAdm.Models;

namespace SetisUsersAdm.Service
{
    public interface IUserService
    {
        void PopularListaDeUsuarios(IFormFile file, ICollection<Usuario> usuarios);
    }
}
