using Microsoft.EntityFrameworkCore;
using POCDemoApp.Domain.Entities;
using POCDemoApp.Infrastructure.DataAccess.Entity.Configurations;

namespace POCDemoApp.Infrastructure.DataAccess.Context
{
	public class EdgeDbContext : DbContext
	{
		public virtual DbSet<ForeignNational> ForeignNationals { get; set; }
		public virtual DbSet<FnCaseNote> CaseNotes { get; set; }

		public EdgeDbContext() { }

		public EdgeDbContext(DbContextOptions options)
			: base(options)
		{ }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ForeignNationalConfiguration());

			modelBuilder.ApplyConfiguration(new FnCaseNoteConfiguration());
		}
	}
}
