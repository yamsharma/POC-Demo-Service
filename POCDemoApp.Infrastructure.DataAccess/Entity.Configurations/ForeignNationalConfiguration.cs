using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POCDemoApp.Domain.Entities;

namespace POCDemoApp.Infrastructure.DataAccess.Entity.Configurations
{
	public class ForeignNationalConfiguration : IEntityTypeConfiguration<ForeignNational>
	{
		public void Configure(EntityTypeBuilder<ForeignNational> builder)
		{
			builder.ToTable("fnl");

			builder.HasKey(f => f.Id);

			builder.Property(f => f.Id)
				.HasColumnName("fnl_key")
				.HasDefaultValueSql("nextval('seq_fnl')");

			builder.Property(f => f.LastName)
				.HasColumnName("fnl_lname")
				.IsRequired()
				.HasMaxLength(50);

			builder.Property(f => f.FirstName)
				.HasColumnName("fnl_fname")
				.IsRequired()
				.HasMaxLength(50);

			builder.HasMany(f => f.CaseNotes)
				.WithOne(c => c.ForeignNational);
		}
	}
}
