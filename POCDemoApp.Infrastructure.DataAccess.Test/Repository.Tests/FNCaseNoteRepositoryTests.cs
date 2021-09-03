using Microsoft.EntityFrameworkCore;
using Moq;
using POCDemoApp.Domain.Entities;
using POCDemoApp.Infrastructure.DataAccess.Context;
using POCDemoApp.Infrastructure.DataAccess.Repositories;
using System.Collections.Generic;
using Xunit;

namespace POCDemoApp.Infrastructure.DataAccess.Tests.Repository.Tests
{
	public class FNCaseNoteRepositoryTests
	{
		private readonly Mock<DbSet<FnCaseNote>> _mockCaseNotes;
		private readonly Mock<EdgeDbContext> _mockContext;
		private readonly FnCaseNoteRepository _repository;

		public FNCaseNoteRepositoryTests()
		{
			// Creating mock DbSet
			_mockCaseNotes = new Mock<DbSet<FnCaseNote>>();

			// Setting up mock context
			_mockContext = new Mock<EdgeDbContext>();
			_mockContext.Setup(context => context.Set<FnCaseNote>()).Returns(_mockCaseNotes.Object);
			_mockContext.Setup(context => context.CaseNotes).Returns(_mockCaseNotes.Object);

			_repository = new FnCaseNoteRepository(_mockContext.Object);
		}

		#region Add

		[Theory]
		[MemberData(nameof(CreateDataSet.GetValidDataSet), MemberType = typeof(CreateDataSet))]
		public void Add_ValidCaseNotePassed_CallsAddOnContext(FnCaseNote caseNote)
		{
			// Act
			_repository.Add(caseNote);

			// Assert
			_mockCaseNotes.Verify(caseNotes => caseNotes.Add(caseNote), Times.Exactly(1));
		}

		#endregion

		#region UpdateTitle

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetValidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void UpdateTitle_ValidCaseNotePassed_CallsFindOnContext(FnCaseNote caseNote)
		{
			// Arrange
			_mockCaseNotes.Setup(caseNotes => caseNotes.Find(caseNote.Id))
				.Returns(caseNote);

			// Act
			_repository.UpdateTitle(caseNote);

			// Assert
			_mockCaseNotes.Verify(caseNotes => caseNotes.Find(caseNote.Id), Times.Exactly(1));
		}

		#endregion

		#region Delete

		[Theory]
		[MemberData(nameof(UpdateDeleteDataSet.GetValidDataSet), MemberType = typeof(UpdateDeleteDataSet))]
		public void Delete_ValidCaseNotePassed_CallsRemoveOnContext(FnCaseNote caseNote)
		{
			// Act
			_repository.Delete(caseNote);

			// Assert
			_mockCaseNotes.Verify(caseNotes => caseNotes.Remove(caseNote), Times.Exactly(1));
		}

		#endregion

		#region DataSets

		private static class CreateDataSet
		{
			public static IEnumerable<object[]> GetValidDataSet
			{
				get
				{
					yield return new object[]
					{
						new FnCaseNote
						{
							Id = 1,
							Title = "New Case Note",
							ForeignKeyId = 25
						}
					};
					yield return new object[]
					{
						new FnCaseNote
						{
							Title = "New Case Note 2",
							ForeignKeyId = 25
						}
					};
				}
			}
		}

		private static class UpdateDeleteDataSet
		{
			public static IEnumerable<object[]> GetValidDataSet
			{
				get
				{
					yield return new object[]
					{
						new FnCaseNote
						{
							Id = 1,
							Title = "New Title",
							ForeignKeyId = 25
						}
					};
				}
			}
		}

		#endregion
	}
}
