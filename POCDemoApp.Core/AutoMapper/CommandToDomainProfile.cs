using AutoMapper;
using POCDemoApp.Domain.Commands;
using POCDemoApp.Domain.Commands.FnCaseNoteCommands;
using POCDemoApp.Domain.Entities;

namespace POCDemoApp.Core.AutoMapper
{
	public class CommandToDomainProfile : Profile
	{
		public CommandToDomainProfile()
		{
			// FN Case Note
			CreateMap<CreateFnCaseNoteCommand, FnCaseNote>()
				.ForMember(dest => dest.ForeignKeyId,
					opts => opts.MapFrom(src => src.ForeignNationalId));

			CreateMap<UpdateFnCaseNoteCommand, FnCaseNote>()
				.ForMember(dest => dest.ForeignKeyId,
					opts => opts.MapFrom(src => src.ForeignNationalId));

			CreateMap<DeleteFnCaseNoteCommand, FnCaseNote>()
				.ForMember(dest => dest.ForeignKeyId,
					opts => opts.MapFrom(src => src.ForeignNationalId));
		}
	}
}
