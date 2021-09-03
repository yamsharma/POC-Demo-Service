using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace POCDemoApp.Infrastructure.DataAccess.Tests.Helpers
{
	public class MockDbSetGenerator
	{
		public static Mock<DbSet<T>> CreateMockDbSet<T>(IEnumerable<T> elements) where T : class
		{
			var elementsAsQueryable = elements.AsQueryable();
			var mockDbSet = new Mock<DbSet<T>>();

			mockDbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
			mockDbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
			mockDbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
			mockDbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

			return mockDbSet;
		}
	}
}
