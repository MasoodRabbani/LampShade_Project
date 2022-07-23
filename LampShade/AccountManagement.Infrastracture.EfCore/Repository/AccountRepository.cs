using _0_Framwork.Application;
using _0_Framwork.Infrastructure;
using AccountManagement.Application.Contract.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Infrastracture.EfCore.Repository
{
    public class AccountRepository : RepositoryBase<long, Account>, IAccountRepository
    {
        private readonly AccountContext context;

        public AccountRepository(AccountContext context):base(context)
        {
            this.context = context;
        }

        public Account GetBy(string username)
        {
            return context.Accounts.FirstOrDefault(s => s.UserName == username);
        }

        public EditAccount GetDetails(long Id)
        {
            return context.Accounts.Select(s => new EditAccount
            {
                FullName = s.FullName,
                Id = s.Id,
                Mobile = s.Mobile,
                Password = s.Password,
                RoleId = s.RoleId,
                UserName = s.UserName
            }).FirstOrDefault(s => s.Id==Id);
        }

        public List<AccountViewModel> Search(AccountSearchModel model)
        {
            var query = context.Accounts.Include(s=>s.Role).Select(s => new AccountViewModel
            {
                Id=s.Id,
                UserName = s.UserName,
                FullName = s.FullName,
                Mobile = s.Mobile,
                ProfilePhoto = s.ProfilePhoto,
                RoleId=s.RoleId,
                Role=s.Role.Name,
                CreationDate=s.CreationDate.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(model.FullName))
                query = query.Where(s => s.FullName.Contains(model.FullName));

            if (!string.IsNullOrWhiteSpace(model.UserName))
                query = query.Where(s => s.UserName.Contains(model.UserName));

            if (!string.IsNullOrWhiteSpace(model.Mobile))
                query = query.Where(s => s.Mobile.Contains(model.Mobile));
            if (model.RoleId > 0)
                query=query.Where(s=>s.RoleId==model.RoleId);
            return query.OrderByDescending(s=>s.Id).ToList();


        }
    }
}
