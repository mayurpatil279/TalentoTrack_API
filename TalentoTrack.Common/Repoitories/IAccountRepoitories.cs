using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentoTrack.Common.Entity;

namespace TalentoTrack.Common.Repoitories
{
    public interface IAccountRepoitories
    {
        Task<LoginDetails> GetLoginDetails(string userName, string password);
    }
}
