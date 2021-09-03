using MediatR;
using Microsoft.Extensions.DependencyInjection;
using POCDemoApp.Core.AutoMapper;
using POCDemoApp.Core.Service.Interfaces;
using POCDemoApp.Core.Services;
using POCDemoApp.Domain.CommandHandlers;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;
using POCDemoApp.Domain.Core.Bus;
using POCDemoApp.Domain.Repository.Interfaces;
using POCDemoApp.Domain.Repository.Interfaces.Core;
using POCDemoApp.Infrastructure.Bus;
using POCDemoApp.Infrastructure.DataAccess.Context;
using POCDemoApp.Infrastructure.DataAccess.Repositories;
using POCDemoApp.Infrastructure.DataAccess.UnitOfWork;

namespace POCDemoApp.Infrastructure.IoC
{
	public class DependencyContainer
	{
		public static void RegisterServices(IServiceCollection services)
		{
			// AutoMapper
			var mapper = AutoMapperConfiguration.RegisterMappings().CreateMapper();
			services.AddSingleton(mapper);

			// Domain InMemoryBus - MediatR
			services.AddScoped<IMediatorHandler, InMemoryBus>();

			// Service Layer
			services.AddScoped<IForeignNationalService, ForeignNationalService>();
			services.AddScoped<IFnCaseNoteService, FnCaseNoteService>();

			// Domain Handlers
			services.AddScoped<IRequestHandler<CreateFnCaseNoteCommand, int>, FnCaseNoteCommandHandler>();
			services.AddScoped<IRequestHandler<UpdateFnCaseNoteCommand, int>, FnCaseNoteCommandHandler>();
			services.AddScoped<IRequestHandler<DeleteFnCaseNoteCommand, int>, FnCaseNoteCommandHandler>();

			// Data Access Layer
			services.AddScoped<EdgeDbContext>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			services.AddScoped<IForeignNationalRepository, ForeignNationalRepository>();
			services.AddScoped<IFnCaseNoteRepository, FnCaseNoteRepository>();
		}
	}
}
