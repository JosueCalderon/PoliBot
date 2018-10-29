using System;

namespace Entities_POJO
{
    public class User : BaseEntity
    {

        public User()
        {

        }

        public User(string[] info)
        {

            if (info != null && info.Length >= 2)
            {
                UserId = info[0];
                Name = info[1];
            }
            else
            { throw new Exception("All values are require [UserId,Name]"); }
        }

        public string UserId { get; set; }
        public string Name { get; set; }

    }
}

