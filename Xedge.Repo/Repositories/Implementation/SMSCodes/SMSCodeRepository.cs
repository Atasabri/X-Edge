using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.SMSCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.SMSCodes
{
    public class SMSCodeRepository : GenericRepository<SmsCode>, ISMSCodeRepository
    {
        public SMSCodeRepository(DB context)
            : base(context)
        {
        }
    }
}
