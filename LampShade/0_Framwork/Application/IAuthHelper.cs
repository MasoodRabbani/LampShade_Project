using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framwork.Application
{
    public interface IAuthHelper
    {

        bool IsAuthenticated();
        void Sigin(AuthViewModel account);
        void Sigout();
        AuthViewModel CurrentAccountInfo();
        string CurrentAccountRoleId();
        List<int> GetPermission();
    }
}
