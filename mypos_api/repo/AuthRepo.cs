using System;
using mypos_api.Database;
using mypos_api.Models;

namespace mypos_api.repo
{
    public class AuthRepo : IAuthRepo
    {
        private readonly DatabaseContext _context;

        public AuthRepo(DatabaseContext context)
        {
            this._context = context;
        }

        public (Users, bool, string) Login(Users user)
        {
            throw new System.NotImplementedException();
        }

        public void Register(Users user)
        {
            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private string HashPassword(string password)
        {
           
        }
    }
}