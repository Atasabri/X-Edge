using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.News;

namespace Xedge.Repo.Repositories.Implementation.News
{
    public class NewsImagesRepository : GenericRepository<NewsImages>, INewsImagesRepository
    {
        public NewsImagesRepository(DB context)
    : base(context)
        {
        }
    }
}
