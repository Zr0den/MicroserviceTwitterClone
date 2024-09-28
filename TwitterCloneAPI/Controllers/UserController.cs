using MessageClient;
using Messages;
using Microsoft.AspNetCore.Mvc;

namespace TwitterCloneAPI.Controllers
{
    internal static class MessageWaiter
    {
        public static async Task<T?>? WaitForMessage<T>(MessageClient<T> messageClient, string clientId, int timeout = 5000)
        {
            var tcs = new TaskCompletionSource<T?>();
            var cancellationTokenSource = new CancellationTokenSource(timeout);
            cancellationTokenSource.Token.Register(() => tcs.TrySetResult(default));

            using (
                var connection = messageClient.ListenUsingTopic<T>(message =>
                {
                    tcs.TrySetResult(message);
                }, "customer" + clientId, clientId)
            )
            {
            }

            return await tcs.Task;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MessageClient<UserResponseMessage> _userResponseMessageClient;
        private readonly MessageClient<UserRequestMessage> _userRequestMessageClient;

        public UserController(MessageClient<UserResponseMessage> userResponseMessageClient, MessageClient<UserRequestMessage> userRequestMessageClient)
        {
            _userResponseMessageClient = userResponseMessageClient;
            _userRequestMessageClient = userRequestMessageClient;
        }

        [HttpPost]
        public async Task<ActionResult<string>> PostUser(UserModel user)
        {
            _userRequestMessageClient.SendUsingTopic(new UserRequestMessage
            {
                UserId = user.UserId,
                Status = "Create User Started",
            }, "newUser");

            var response = await MessageWaiter.WaitForMessage(_userResponseMessageClient, user.UserId.ToString())!;

            return response != null ? response.Status : "Transaction timed out";
        }
    }
}
