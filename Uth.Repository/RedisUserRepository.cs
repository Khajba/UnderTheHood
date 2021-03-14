using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Uth.Common.Entities;
using Uth.core;
using Uth.Repository.Abstract;

namespace Uth.Repository
{
    public class RedisUserRepository : IUserRepository
    {
        const string _keyUsers = "uth_users";
        private readonly IDistributedCache _distributedCache;

        public RedisUserRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public void Register(string email, string firstname, string lastname, string password)
        {
            var userString = _distributedCache.GetString("_keyUsers");

            List<User> users;

            if (userString != null)
            {
                users = JsonConvert.DeserializeObject<List<User>>(userString);
                if (users.Any(u => u.Email == email))
                {
                    throw new UthException("Email already exists");
                }
                
            }

            else
            {
                users = new List<User>();
            }

            var user = new User();
            user.Id = GetNextUserId(users);
            user.Email = email;
            user.Firstname = firstname;
            user.Password = password;

            users.Add(user);
            userString = JsonConvert.SerializeObject(users);
            _distributedCache.SetString("_keyUsers", userString);



        }

        private int GetNextUserId(List<User> users)
        {
            if (users.Any())
            {
                return users.Max(u => u.Id);
            }

            return 1;
        }
    }
}
