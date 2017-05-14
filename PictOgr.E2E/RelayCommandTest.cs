using PictOgr.MVVM.Base;
using Shouldly;
using Xunit;

namespace PictOgr.E2E
{
	public class RelayCommandTest
	{
		private string executeParam;
		private readonly RelayCommand relayCommand;
		private bool canExecute;

		public RelayCommandTest()
		{
			relayCommand = new RelayCommand(ExecuteDelegate, CanExecute);
		}

		private bool CanExecute(object parameter)
		{
			var testString = parameter.ToString();
			
			canExecute = !string.IsNullOrWhiteSpace(testString);

			return canExecute;
		}

		private void ExecuteDelegate(object parameter)
		{
			executeParam = parameter.ToString();
		}

		[Fact]
		public void execute_relaycommand_should_set_param_and_can_execute()
		{
			var testString = "ok";

			relayCommand.CanExecute(testString);
			relayCommand.Execute(testString);

			executeParam.ShouldBe(testString);
			canExecute.ShouldBeTrue();
		}

		[Fact]
		public void execute_relaycommand_should_not_set_param_and_can_execute()
		{
			var testString = string.Empty;

			relayCommand.CanExecute(testString);

			canExecute.ShouldBeFalse();
		}
	}
}