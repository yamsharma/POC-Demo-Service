using AutoMapper;
using Moq;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using POCDemoApp.Core.Services;
using POCDemoApp.Domain.Core.Bus;
using POCDemoApp.Domain.Entities;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace POCDemoApp.Core.Tests.Service.Tests
{
	public class ForeignNationalServiceTests
	{
		private readonly Mock<IUnitOfWork> _mockUnitOfWork;
		private readonly Mock<IMediatorHandler> _mockBus;
		private readonly Mock<IMapper> _mockAutoMapper;
		private readonly IForeignNationalService _service;

		public ForeignNationalServiceTests()
		{
			_mockUnitOfWork = new Mock<IUnitOfWork>();
			_mockBus = new Mock<IMediatorHandler>();
			_mockAutoMapper = new Mock<IMapper>();
			_service = new ForeignNationalService(_mockUnitOfWork.Object, _mockBus.Object, _mockAutoMapper.Object);
		}

		#region Get

		[Fact]
		public void Get_UnknownIdPassed_ReturnsNull()
		{
			// Arrange
			const int unknownId = 1;

			ForeignNational foreignNational = null;

			ForeignNationalApiModel foreignNationalApiModel = null;

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.ForeignNationals.Get(unknownId))
				.Returns(foreignNational);

			_mockAutoMapper.Setup(mapper => mapper.Map<ForeignNationalApiModel>(foreignNational))
				.Returns(foreignNationalApiModel);

			// Act
			var result = _service.Get(unknownId);

			// Assert
			Assert.Null(result);
		}

		[Fact]
		public void Get_KnownIdPassed_ReturnsCorrectEntity()
		{
			// Arrange
			const int knownForeignNationalId = 25;

			var foreignNational = new ForeignNational
			{
				Id = knownForeignNationalId,
				FirstName = "Michael",
				LastName = "Scofield"
			};

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.ForeignNationals.Get(knownForeignNationalId))
				.Returns(foreignNational);

			_mockAutoMapper.Setup(mapper => mapper.Map<ForeignNationalApiModel>(foreignNational))
				.Returns(new ForeignNationalApiModel
				{
					Id = knownForeignNationalId,
					FirstName = "Michael",
					LastName = "Scofield"
				});

			// Act
			var result = _service.Get(knownForeignNationalId);

			// Assert
			Assert.NotNull(result);
			Assert.Equal(knownForeignNationalId, result.Id);
			Assert.Equal("Michael", result.FirstName);
			Assert.Equal("Scofield", result.LastName);
		}

		#endregion

		#region GetCaseNotes

		[Fact]
		public void GetCaseNotes_UnknownIdPassed_ReturnsEmptyList()
		{
			// Arrange
			const int unknownId = 1;

			var caseNotes = new List<FnCaseNote>();

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.ForeignNationals.GetCaseNotes(unknownId))
				.Returns(caseNotes);

			_mockAutoMapper.Setup(mapper => mapper.Map<List<FnCaseNoteApiModel>>(caseNotes))
				.Returns(new List<FnCaseNoteApiModel>());

			// Act
			var result = _service.GetCaseNotes(unknownId);

			// Assert
			Assert.Empty(result);
		}

		[Fact]
		public void GetCaseNotes_KnownIdPassed_ReturnsCorrectList()
		{
			// Arrange
			const int knownId = 25;

			var caseNotes = new List<FnCaseNote>
			{
				new FnCaseNote {Id = 1, Title = "GDPR Notification", ForeignKeyId = knownId},
				new FnCaseNote {Id = 2, Title = "MFA Notification", ForeignKeyId = knownId},
				new FnCaseNote {Id = 3, Title = "TOS Notification", ForeignKeyId = knownId}
			};

			_mockUnitOfWork.Setup(unitOfWork => unitOfWork.ForeignNationals.GetCaseNotes(knownId))
				.Returns(caseNotes);

			_mockAutoMapper.Setup(mapper => mapper.Map<IEnumerable<FnCaseNoteApiModel>>(caseNotes))
				.Returns(new List<FnCaseNoteApiModel>
				{
					new FnCaseNoteApiModel {Id = 1, Title = "GDPR Notification", ForeignNationalId = knownId},
					new FnCaseNoteApiModel {Id = 2, Title = "MFA Notification", ForeignNationalId = knownId},
					new FnCaseNoteApiModel {Id = 3, Title = "TOS Notification", ForeignNationalId = knownId}
				});

			// Act
			var result = _service.GetCaseNotes(knownId);

			// Assert
			Assert.Equal(3, result.Count());
			Assert.Equal("GDPR Notification", result.ElementAt(0).Title);
			Assert.Equal("MFA Notification", result.ElementAt(1).Title);
			Assert.Equal("TOS Notification", result.ElementAt(2).Title);
		}

		#endregion

		#region Unimplemented methods

		[Fact]
		public void GetAll_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.GetAll());
		}

		[Fact]
		public void Find_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.Find(c => c.Id == 1));
		}

		[Fact]
		public void Add_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.Add(null));
		}

		[Fact]
		public void AddRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.AddRange(null));
		}


		[Fact]
		public void Delete_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.Delete(null));
		}

		[Fact]
		public void DeleteRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _service.DeleteRange(null));
		}

		#endregion
	}
}
