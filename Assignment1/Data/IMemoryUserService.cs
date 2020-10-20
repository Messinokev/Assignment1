using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Models;


namespace Assignment1.Data
{
    public class IMemoryUserService : IUserService
    {
        private List<User> users;

        public IMemoryUserService()
        {
            users = new[] {
            new User {
                ID = 1,
                City = "Horsens",
                Password = "123456",
                Role = "Admin",
                BirthYear = 1986,
                SecurityLevel = 3,
                UserName = "Troels"
            },
            new User {
                ID = 2,
                City = "Aarhus",
                Password = "123456",
                Role = "User",
                BirthYear = 1998,
                SecurityLevel = 2,
                UserName = "Jakob"
            },
            new User {
                ID = 3,
                City = "Vejle",
                Password = "123456",
                Role = "User",
                BirthYear = 1973,
                SecurityLevel = 1,
                UserName = "Kasper"
            }
        }.ToList();
        }


        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}