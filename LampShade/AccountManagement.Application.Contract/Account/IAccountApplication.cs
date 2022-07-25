using _0_Framwork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract.Account
{
    public interface IAccountApplication
    {
        OprationResult Register(Register command);
        OprationResult Edit(EditAccount command);
        OprationResult ChangePassword(ChangePassword command);
        OprationResult Login(Login command);
        EditAccount GetDetails(long Id);
        List<AccountViewModel> Search(AccountSearchModel model);
        void Logout();
    }
}
