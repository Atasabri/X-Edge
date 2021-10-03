using Xedge.Domain.Context;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Settings;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Implementation.Settings
{
    public class SettingsRepository : GenericRepository<Xedge.Domain.Models.Settings>, ISettingsRepository
    {
        public SettingsRepository(DB context)
        : base(context)
        {
        }

        public async Task<string> GetSettingValueUsingKeyAsync(string Key)
        {
            return (await FindElementAsync(setting => setting.Key == Key))?.Value;
        }
    }
}
