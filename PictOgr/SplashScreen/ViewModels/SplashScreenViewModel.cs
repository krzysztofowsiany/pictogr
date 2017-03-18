
using System.Windows.Input;
using PictOgr.Core;
using PictOgr.Core.CQRS.Query;
using PictOgr.Core.Queries;
using PictOgr.SplashScreen.Commands;

namespace PictOgr.SplashScreen.ViewModels
{
	public class SplashScreenViewModel : BaseViewModel
	{
		private readonly ShowMessageBoxCommand messageBoxCommand;

		public ApplicationInformation ApplicationInformation { get; private set; }

		public ICommand MessageBoxCommand => messageBoxCommand;


		public SplashScreenViewModel(ShowMessageBoxCommand messageBoxCommand, IQueryBus queryBus) : base(queryBus)
		{
			this.messageBoxCommand = messageBoxCommand;

			ApplicationInformation = queryBus.Process<GetApplicationInformation, ApplicationInformation>(new GetApplicationInformation());
		}
	}
}
