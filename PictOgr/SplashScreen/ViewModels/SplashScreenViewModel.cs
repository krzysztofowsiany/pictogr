
using System.Windows.Input;
using Autofac.Extras.NLog;
using PictOgr.Core;
using PictOgr.Core.CQRS.Bus;
using PictOgr.Core.Models;
using PictOgr.Core.Queries;
using PictOgr.SplashScreen.Commands;

namespace PictOgr.SplashScreen.ViewModels
{
	public class SplashScreenViewModel : BaseViewModel
	{
		private readonly ExitBoxCommand exitBoxCommand;

		public ApplicationInformation ApplicationInformation { get; private set; }

		public ICommand ExitBoxCommand => exitBoxCommand;

		public SplashScreenViewModel(ExitBoxCommand exitBoxCommand, IQueryBus queryBus, ILogger logger) : base(queryBus, logger)
		{
			this.exitBoxCommand = exitBoxCommand;

			Initialize();
		}

		private void Initialize()
		{
			ApplicationInformation =
				QueryBus.Process<GetApplicationInformation, ApplicationInformation>(new GetApplicationInformation());

			Logger.Info($"Start applicaiton. Version: {ApplicationInformation.Version}.");
			Logger.Info($"Show view: {GetType().Name}.");
		}
	}
}
