using System;
using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
            var result = _context.Users.SingleOrDefault(u => u.Username == user.Username);

            if(result == null){
                return (null, false, String.Empty);
            }

            if(CheckPassword(result.Password, user.Password)){

            }

        }

        private bool CheckPassword(string passwordHash, string password)
        {
            
        }

        public void Register(Users user)
        {
            user.Password = HashPassword(user.Password);
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return $"{Convert.ToBase64String(salt)}.{hashed}";
        }
    }
}