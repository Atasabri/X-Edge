using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Videos;

namespace Xedge.Repo.Repositories.Implementation.Videos
{
    public class VideosRepository : GenericRepository<Video>, IVideosRepository
    {
        public VideosRepository(DB context)
             : base(context)
        {
        }
    }
}
