using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentoTrack.Common.Entity;
using TalentoTrack.Common.Repoitories;
using TalentoTrack.Dao.Db;

namespace TalentoTrack.Dao.Repoitories
{
    public class AccountRepositories : IAccountRepoitories
    {
        public TalentoTrack_DbContext _DbContext;

        public AccountRepositories(TalentoTrack_DbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<LoginDetails> GetLoginDetails(string userName, string password)
        {
            var dbRecord = await _DbContext.tbl_login_details.Where(p => (p.UserName != null && p.UserName.Equals(userName)) && (p.Password != null && p.Password.Equals(password))).FirstOrDefaultAsync();
            return dbRecord!;

        }
    }
    }
