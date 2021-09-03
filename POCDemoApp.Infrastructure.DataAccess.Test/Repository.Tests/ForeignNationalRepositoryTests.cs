using Microsoft.EntityFrameworkCore;
using Moq;
using POCDemoApp.Domain.Entities;
using POCDemoApp.Infrastructure.DataAccess.Context;
using POCDemoApp.Infrastructure.DataAccess.Repositories;
using POCDemoApp.Infrastructure.DataAccess.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace POCDemoApp.Infrastructure.DataAccess.Tests.Repository.Tests
{
	public class ForeignNationalRepositoryTests
	{
		private readonly Mock<DbSet<ForeignNational>> _mockForeignNationals;
		private readonly Mock<EdgeDbContext> _mockContext;
		private readonly ForeignNationalRepository _repository;

		public ForeignNationalRepositoryTests()
		{
			// Creating mock DbSet
			_mockForeignNationals = MockDbSetGenerator.CreateMockDbSet(new List<ForeignNational>
			{
				new ForeignNational {Id = 25, FirstName = "Michael", LastName = "Scofield", CaseNotes = new List<FnCaseNote>
				{
					new FnCaseNote {Id = 1, Title = "GDPR Notification", ForeignKeyId = 25},
					new FnCaseNote {Id = 2, Title = "MFA Notification", ForeignKeyId = 25},
					new FnCaseNote {Id = 3, Title = "TOS Notification", ForeignKeyId = 25}
				}},
				new ForeignNational {Id = 26, FirstName = "Monica", LastName = "Geller", CaseNotes = null}
			});

			// Setting up mock context
			_mockContext = new Mock<EdgeDbContext>();
			_mockContext.Setup(context => context.Set<ForeignNational>()).Returns(_mockForeignNationals.Object);
			_mockContext.Setup(context => context.ForeignNationals).Returns(_mockForeignNationals.Object);

			_repository = new ForeignNationalRepository(_mockContext.Object);
		}

		#region Get

		[Fact]
		public void Get_UnknownIdPassed_ReturnsNull()
		{
			// Arrange
			const int unknownId = 1;

			// Act
			var result = _repository.Get(unknownId);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void Get_KnownIdPassed_ReturnsCorrectEntity()
		{
			// Arrange
			const int knownId = 25;

			// Act
			var result = _repository.Get(knownId);

			// Assert
			_mockForeignNationals.Verify(foreignNationals => foreignNationals.Find(It.Is<long>(l => l == knownId)), Times.Exactly(1));
		}

		#endregion

		#region GetCaseNotes

		[Fact]
		public void GetCaseNotes_UnknownIdPassed_ReturnsEmptyList()
		{
			// Arrange
			const int unknownForeignNationalId = 1;

			// Act
			var result = _repository.GetCaseNotes(unknownForeignNationalId);

			// Assert
			Assert.Empty(result);
		}

		[Fact]
		public void GetCaseNotes_KnownIdPassed_ReturnsCorrectList()
		{
			// Arrange
			const int knownForeignNationalId = 25;

			// Act
			var result = _repository.GetCaseNotes(knownForeignNationalId);

			// Assert
			Assert.Equal(3, result.Count());
			Assert.Equal("GDPR Notification", result.ElementAt(0).Title);
			Assert.Equal("MFA Notification", result.ElementAt(1).Title);
			Assert.Equal("TOS Notification", result.ElementAt(2).Title);
		}

		#endregion
	}
}
