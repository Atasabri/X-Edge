using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Context;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.News;

namespace Xedge.Repo.Repositories.Implementation.News
{
    public class NewsRepository : GenericRepository<Domain.Models.News>, INewsRepository
    {
        public NewsRepository(DB context)
    : base(context)
        {
        }
    }
}
