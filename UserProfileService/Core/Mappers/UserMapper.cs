using Mapper;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Core.Entities;

namespace UserProfileService.Core.Mappers
{
    public class UserRequestMapper : IMapper<UserRequestMessage, User>
    {
        public User map(UserRequestMessage model)
        {
            return new User
            {
                Id = model.UserId,
                Status = model.Status,
            };
        }

        public UserRequestMessage map(User model)
        {
            return new UserRequestMessage
            {
                UserId = model.Id,
                Status = model.Status,
            };
        }
    }
    public class UserResponseMapper : IMapper<UserResponseMessage, User>
    {
        public User map(UserResponseMessage model)
        {
            return new User
            {
                Id = model.UserId,
                Status = model.Status,
            };
        }

        public UserResponseMessage map(User model)
        {
            return new UserResponseMessage
            {
                UserId = model.Id,
                Status = model.Status,
            };
        }
    }

}
