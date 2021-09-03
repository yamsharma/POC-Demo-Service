using POCDemoApp.Domain.Core.Commands;
using System.Threading.Tasks;

namespace POCDemoApp.Domain.Core.Bus
{
	public interface IMediatorHandler
	{
		Task SendCommand<T>(T command) where T : Command;
	}
}
