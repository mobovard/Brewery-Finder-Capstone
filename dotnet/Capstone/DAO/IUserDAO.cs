using Capstone.Models;
using System;

namespace Capstone.DAO
{
    public interface IUserDAO
    {
        User GetUser(string username);
        User AddUser(string username, string password, string role,string firstName,string lastName,string email);


    }
}
