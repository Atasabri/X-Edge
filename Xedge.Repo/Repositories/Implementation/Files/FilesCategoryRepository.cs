using System;
using System.Collections.Generic;
using System.Text;
using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Files;

namespace Xedge.Repo.Repositories.Implementation.Files
{
    public class FilesCategoryRepository : GenericRepository<FileCategory>, IFilesCategoryRepository
    {
        public FilesCategoryRepository(DB context)
    : base(context)
        {
        }
    }
}
