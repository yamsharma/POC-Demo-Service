﻿using MediatR;

namespace POCDemoApp.Domain.Core.Events
{
	public abstract class Message : IRequest<int>
	{
		public string MessageType { get; protected set; }

		protected Message()
		{
			MessageType = GetType().Name;
		}
	}
}
