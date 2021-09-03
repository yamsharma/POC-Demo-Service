using Microsoft.AspNetCore.Mvc;
using Moq;
using POCDemoApp.API.Controllers;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Core.Service.Interfaces;
using System;
using System.Collections.Generic;
using Xunit;

namespace POCDemoApp.API.Tests.Controller.Tests
{
	public class ForeignNationalsControllerTests
	{
		private readonly Mock<IForeignNationalService> _mockService;
		private readonly ForeignNationalsController _controller;

		public ForeignNationalsControllerTests()
		{
			_mockService = new Mock<IForeignNationalService>();
			_controller = new ForeignNationalsController(_mockService.Object);
		}

		#region Get

		[Fact]
		public void Get_UnknownIdPassed_ReturnsNotFound()
		{
			// Arrange
			const int unknownId = 1;

			ForeignNationalApiModel foreignNationalApiModel = null;

			_mockService.Setup(service => service.Get(unknownId))
				.Returns(foreignNationalApiModel);

			// Act
			var actionResult = _controller.Get(unknownId);

			// Assert
			Assert.IsType<NotFoundResult>(actionResult.Result);
		}

		[Fact]
		public void Get_KnownIdPassed_ReturnsCorrectEntity()
		{
			// Arrange
			const int knownId = 25;

			_mockService.Setup(service => service.Get(knownId))
				.Returns(new ForeignNationalApiModel
				{
					Id = knownId,
					FirstName = "Michael",
					LastName = "Scofield"
				});

			// Act
			var actionResult = _controller.Get(knownId).Result as OkObjectResult;

			// Assert
			Assert.NotNull(actionResult);
			var result = actionResult.Value as ForeignNationalApiModel;
			Assert.Equal(knownId, result.Id);
			Assert.Equal("Michael", result.FirstName);
			Assert.Equal("Scofield", result.LastName);
		}

		#endregion

		#region GetCaseNotes

		[Fact]
		public void GetCaseNotes_UnknownIdPassed_ReturnsNotFound()
		{
			// Arrange
			var unknownForeignNationalId = 1;

			_mockService.Setup(service => service.GetCaseNotes(unknownForeignNationalId))
				.Returns(new List<FnCaseNoteApiModel>());

			// Act
			var actionResult = _controller.GetCaseNotes(unknownForeignNationalId);

			// Assert
			Assert.IsType<NotFoundResult>(actionResult.Result);
		}

		[Fact]
		public void GetCaseNotes_KnownIdPassed_ReturnsCorrectEntity()
		{
			// Arrange
			const int knownForeignNationalId = 25;

			_mockService.Setup(service => service.GetCaseNotes(knownForeignNationalId))
				.Returns(new List<FnCaseNoteApiModel>
				{
					new FnCaseNoteApiModel {Id = 1, Title = "GDPR Notification", ForeignNationalId = knownForeignNationalId},
					new FnCaseNoteApiModel {Id = 2, Title = "MFA Notification", ForeignNationalId = knownForeignNationalId},
					new FnCaseNoteApiModel {Id = 3, Title = "TOS Notification", ForeignNationalId = knownForeignNationalId}
				});

			// Act
			var actionResult = _controller.GetCaseNotes(knownForeignNationalId).Result as OkObjectResult;

			// Assert
			Assert.NotNull(actionResult);
			var result = actionResult.Value as List<FnCaseNoteApiModel>;
			Assert.NotNull(result);
			Assert.Equal(3, result.Count);
		}

		#endregion

		#region Unimplemented methods

		[Fact]
		public void GetAll_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.ThrowsAsync<NotImplementedException>(() => _controller.GetAll());
		}

		[Fact]
		public void Find_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.ThrowsAsync<NotImplementedException>(() => _controller.Find(c => c.Id == 1));
		}

		[Fact]
		public void Add_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.Add(null));
		}

		[Fact]
		public void AddRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.AddRange(null));
		}

		[Fact]
		public void Update_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.Update(null));
		}

		[Fact]
		public void Delete_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.Delete(null));
		}

		[Fact]
		public void DeleteRange_WhenCalled_ThrowsNotImplementedException()
		{
			// Act and Assert
			Assert.Throws<NotImplementedException>(() => _controller.DeleteRange(null));
		}

		#endregion
	}
}