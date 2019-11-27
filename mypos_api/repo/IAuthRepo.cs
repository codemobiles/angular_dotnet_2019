using mypos_api.Models;

namespace mypos_api.repo
{
    public interface IAuthRepo
    {
        (Users, string) Login(Users user);

        void Register(Users user);
    }
}