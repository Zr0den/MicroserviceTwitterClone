using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public class UserRequestMessage
    {
        public int UserId { get; set; }
        public string Status {  get; set; }
        //public List<UserModel> Items { get; set; }
    }
}
