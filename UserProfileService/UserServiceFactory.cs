using MessageClient.Factory;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Core.Helpers;
using UserProfileService.Core.Mappers;
using UserProfileService.Core.Repositories;
using UserProfileService.Core.Services;


namespace UserProfileService
{
    public static class UserServiceFactory
    {
        public static UserService CreateUserService()
        {
            var easyNetQFactory = new EasyNetQFactory();
            var newOrderClient = easyNetQFactory.CreateTopicMessageClient<UserRequestMessage>("UserService", "newUser");
            var userCompletionClient = easyNetQFactory.CreatePubSubMessageClient<UserResponseMessage>("");

            var dataContext = new DataContext();
            var userRepository = new UserRepository(dataContext);
            var userService = new UserCRUD(userRepository);
            var userResponseMapper = new UserResponseMapper();

            return new UserService(
                newOrderClient,
                userCompletionClient,
                userService,
                userResponseMapper
                );
        }
    }
}
