using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xedge.Repo.Repositories.Implementation.User
{
    public class FavoritesRepository : GenericRepository<Favorites>, IFavoritesRepository
    {
        public FavoritesRepository(DB context)
            : base(context)
        {
        }
    }
}
