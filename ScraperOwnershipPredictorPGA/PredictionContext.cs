using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScraperOwnershipPredictorPGA
{
    class PredictionContext : DbContext
    {
        public DbSet<DKtourney> DKtourneys { get; set; }

        public DbSet<OwnedGolfer> OwnedGolfers { get; set; }

        public DbSet<PredictionGolfer> PredictionGolfers { get; set; }

    }
}
