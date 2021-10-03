using Xedge.Domain.Context;
using Xedge.Domain.Models;
using Xedge.Repo.Generic;
using Xedge.Repo.Repositories.Interfaces.Sliders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xedge.Repo.Repositories.Implementation.Sliders
{
    public class SlidersRepository : GenericRepository<Slider>, ISlidersRepository
    {
        public SlidersRepository(DB context)
        : base(context)
        {
        }
    }
}
