using POCDemoApp.Domain.Core.Events;
using System;

namespace POCDemoApp.Domain.Core.Commands
{
	public abstract class Command : Message
	{
		public DateTime Timestamp { get; protected set; }

		protected Command()
		{
			Timestamp = DateTime.Now;
		}
	}
}
