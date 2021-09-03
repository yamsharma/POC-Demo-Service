using AutoMapper;
using POCDemoApp.Core.Api.Entities;
using POCDemoApp.Domain.Entities;

namespace POCDemoApp.Core.AutoMapper
{
	public class DomainToApiModelProfile : Profile
	{
		public DomainToApiModelProfile()
		{
			// Foreign National
			CreateMap<ForeignNational, ForeignNationalApiModel>();

			// FN Case Note
			CreateMap<FnCaseNote, FnCaseNoteApiModel>()
				.ForMember(dest => dest.ForeignNationalId,
				opts => opts.MapFrom(src => src.ForeignKeyId));
		}
	}
}
