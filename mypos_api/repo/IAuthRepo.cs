using mypos_api.Models;

namespace mypos_api.repo
{
    public interface IAuthRepo
    {
        (Users, bool, string) Login(Users user);

        void Register(Users user);
    }
}