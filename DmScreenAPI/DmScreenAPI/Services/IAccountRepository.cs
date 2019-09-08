using DmScreenAPI.Context.Entities;
using DmScreenAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Services
{
    public interface IAccountRepository
    {
        Account Register(Account account, string password);
        Account Login(string username, string password);
        bool AccountExists(string username);
        IEnumerable<AccountResource> GetAccountResources(int id);
        void RemoveAccountResources(IEnumerable<AccountResource> accountResources);
        void Add(AccountResource entity);
    }
}
