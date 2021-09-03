using AutoMapper;

namespace POCDemoApp.Core.AutoMapper
{
	public class AutoMapperConfiguration
	{
		public static MapperConfiguration RegisterMappings()
		{
			return new MapperConfiguration(config =>
			{
				// Commands
				config.AddProfile(new ApiModelToCommandProfile());
				config.AddProfile(new CommandToDomainProfile());

				// Queries
				config.AddProfile(new DomainToApiModelProfile());
			});
		}
	}
}
