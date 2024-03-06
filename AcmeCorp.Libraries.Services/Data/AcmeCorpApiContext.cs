using Microsoft.EntityFrameworkCore;
using AcmeCorp.Libraries.Models;

namespace AcmeCorp.Libraries.Services.Data;

public class AcmeCorpApiContext : DbContext
{
    public AcmeCorpApiContext(DbContextOptions<AcmeCorpApiContext> options)
        : base(options)
    {
    }

    public DbSet<DrawEntry> DrawEntries { get; set; } = default!;
    //public DbSet<SurfboardApi.Models.Bookings> Bookings { get; set; }
}
