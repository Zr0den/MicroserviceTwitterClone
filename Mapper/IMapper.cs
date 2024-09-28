using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapper
{
    public interface IMapper<T, U>
    {
        U map(T model);
        T map(U model);
    }
}
