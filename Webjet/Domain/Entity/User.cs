using System;

namespace Domain.Entity
{
    public class User
    {
        public Guid Id { set; get; }
        public string Username { set; get; }
        public string Password { set; get; }
    }
}
