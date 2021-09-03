using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POCDemoApp.Domain.Entities;

namespace POCDemoApp.Infrastructure.DataAccess.Entity.Configurations
{
	public class FnCaseNoteConfiguration : IEntityTypeConfiguration<FnCaseNote>
	{
		public void Configure(EntityTypeBuilder<FnCaseNote> builder)
		{
			builder.ToTable("doc");

			builder.HasKey(c => c.Id);

			builder.Property(c => c.Id)
				.HasColumnName("doc_key")
				.HasDefaultValueSql("nextval('seq_doc')");

			builder.Property(c => c.Title)
				.HasColumnName("doc_referrence")
				.HasMaxLength(80)
				.IsRequired();

			builder.Property(c => c.ForeignKeyTable)
				.HasColumnName("doc_fk_table")
				.IsRequired();

			builder.Property(c => c.ForeignKeyId)
				.HasColumnName("doc_fk_key")
				.IsRequired();

			builder
				.HasOne(c => c.ForeignNational)
				.WithMany(f => f.CaseNotes)
				.HasForeignKey(c => c.ForeignKeyId);
		}
	}
}
