using AutoMapper;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Domain.Commands;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;

namespace POCDemoApp.Core.AutoMapper
{
	public class ApiModelToCommandProfile : Profile
	{
		public ApiModelToCommandProfile()
		{
			// FN Case Note
			CreateMap<FnCaseNoteApiModel, CreateFnCaseNoteCommand>();
			CreateMap<FnCaseNoteApiModel, UpdateFnCaseNoteCommand>();
			CreateMap<FnCaseNoteApiModel, DeleteFnCaseNoteCommand>();
		}
	}
}
