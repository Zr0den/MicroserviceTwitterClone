using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserProfileService.Core.Entities;
using UserProfileService.Core.Helpers;

namespace UserProfileService.Core.Repositories
{
    public class UserRepository : EntityFrameworkRepository<User>
    {
        public UserRepository(DataContext context) : base(context) { }
    }
}
