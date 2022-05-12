using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPIServices
{
    public interface IJwtTokenManager
    {
        string Authenticate(string userName, string password);
    }
}
