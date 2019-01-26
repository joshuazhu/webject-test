using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entity;
using Repository.Interface;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        public static List<User> _users = new List<User>();

        public UserRepository()
        {
            PopulateDummyMovies();
        }

        public User Get(string username, string password)
        {
            return _users.FirstOrDefault(x => x.Username == username && x.Password == password);
        }

        private static void PopulateDummyMovies()
        {
            _users.Add(new User
            {
                Id = Guid.NewGuid(),
                Username = "test",
                Password = "test"
            });
        }
    }
}
