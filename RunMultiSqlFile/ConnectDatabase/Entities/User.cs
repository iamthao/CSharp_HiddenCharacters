using System.Collections.Generic;

namespace ConnectDatabase.Entities
{
    public class User : Entity
    {
        public User()
        {
           
        }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
