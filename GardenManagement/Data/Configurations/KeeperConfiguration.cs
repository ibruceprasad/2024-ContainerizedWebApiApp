using Garden.Management.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace Garden.Management.Data.Configurations
{
    public class KeeperConfiguration : IEntityTypeConfiguration<Keeper>
    {
        public void Configure(EntityTypeBuilder<Keeper> builder)
        {
            builder.HasData( new Keeper
                            {
                                Id = Guid.Parse("056fcd24-ed30-4d42-8a55-61710289b921"),
                                Name = "Sam",
                            });
        }
    }
}
