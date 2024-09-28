using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Core.Entities;

namespace UserProfileService.Core.Services
{
    public class UserCRUD
    {
        private readonly IRepository<User> _repository;

        public UserCRUD(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User GetUser(int id)
        {
            return _repository.GetById(id);
        }

        public void CreateUser(User user)
        {
            _repository.Add(user);
        }

        public void CompleteUser(User user)
        {
            _repository.Update(user);
        }

    }
}
