using MessageClient;
using Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Core.Mappers;
using UserProfileService.Core.Services;

namespace UserProfileService
{
    public class UserService
    {
        private readonly MessageClient<UserRequestMessage> _newUserClient;
        private readonly MessageClient<UserResponseMessage> _userCompletionClient;
        private readonly UserCRUD _userCRUD;
        private readonly UserResponseMapper _userResponseMapper;

        public UserService(MessageClient<UserRequestMessage> newUserClient, MessageClient<UserResponseMessage> userCompletionClient, UserCRUD userCRUD, UserResponseMapper userResponseMapper)
        {
            _newUserClient = newUserClient;
            _userCompletionClient = userCompletionClient;
            _userCRUD = userCRUD;
            _userResponseMapper = userResponseMapper;
        }

        public void Start()
        {
            Action<UserRequestMessage> callback = HandleNewUser;
            _newUserClient.Connect();
            _newUserClient.ListenUsingTopic(callback, "", "newUser");
        }

        public void HandleNewUser(UserRequestMessage user)
        {

        }
    }
}
