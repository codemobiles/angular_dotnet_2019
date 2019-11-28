using AutoMapper;
using mypos_api.Models;
using mypos_api.ViewModel;

namespace mypos_api.Util
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
           CreateMap<UsersViewModel, Users>();
        }
    }
}