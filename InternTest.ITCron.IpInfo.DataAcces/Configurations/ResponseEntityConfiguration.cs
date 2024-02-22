using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternTest.ITCron.IpInfo.DataAcces.Configurations
{
    public class ResponseEntityConfiguration : IEntityTypeConfiguration<ResponseEntity>
    {
        public void Configure(EntityTypeBuilder<ResponseEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IP).IsRequired();
        }
    }
}
