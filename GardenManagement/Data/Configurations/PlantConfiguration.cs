using Garden.Management.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Garden.Management.Data.Configurations
{
    public class PlantConfiguration : IEntityTypeConfiguration<Plant>
    {
        public void Configure(EntityTypeBuilder<Plant> builder)
        {
            builder.HasData(new Plant
            {
                Id = Guid.Parse("3a853de2-ceee-47fd-a653-9c2611b56eac"),
                Name = "Plant1",
            },
            new Plant
            {
                Id = Guid.Parse("3a853de2-ceee-47fd-a653-9c2611b56ead"),
                Name = "Plant2",
            }
            );
        }
    }
}
