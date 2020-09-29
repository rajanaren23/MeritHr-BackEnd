using CommonDataModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dawn.Services
{
    public interface IUserManagement 
    {
        public List<UserRegistration> Get();

        public UserRegistration Get(string id);

        public UserRegistration Create(UserRegistration book);

        public void Update(string id, UserRegistration bookIn);
        public void Remove(UserRegistration bookIn);

        public void Remove(string id);
    }
}
