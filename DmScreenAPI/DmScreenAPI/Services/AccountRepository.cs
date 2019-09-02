using DmScreenAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Services
{
    public class AccountRepository: IAccountRepository
    {
        private readonly DatabaseContext _db;

        public AccountRepository(DatabaseContext db)
        {
            _db = db;
        }
        public Account Login(string email, string password)
        {
            var account = _db.Accounts.FirstOrDefault(u => u.Email == email);
            if (account == null)
            {
                return null;
            }
            if (!VerifyPasswordHash(password, account.PasswordHash, account.PasswordSalt))
            {
                return null;
            }
            return account;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                //we need to compare each byte in the byte array to ensure they match
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
                return true;
            }
        }
        public bool AccountExists(string email)
        {
            if (_db.Accounts.Any(acc => acc.Email== email))
            {
                return true;
            }
            return false;
        }
        public Account Register(Account account, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            account.PasswordHash = passwordHash;
            account.PasswordSalt = passwordSalt;

            _db.Accounts.Add(account);
            _db.SaveChanges();

            return account;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
