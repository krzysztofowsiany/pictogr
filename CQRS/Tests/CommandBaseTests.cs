using System;
using Autofac;
using CQRS.Bus.Command;
using CQRS.Command;
using FakeItEasy;

namespace CQRS.Tests
{
	public class CommandBaseTests<T> where T : ICommand
	{
		protected ICommandBus commandBus;
		protected Action<ICommand> handleMethod;

		public CommandBaseTests(ContainerBuilder builder)
		{
			var fakeHandler = A.Fake<ICommandHandler<T>>();

			A.CallTo(() => fakeHandler.Handle(A<T>._))
				.Invokes((T command) =>
				{
					handleMethod?.Invoke(command);
				});

			builder.Register(c => fakeHandler).AsImplementedInterfaces();

			var container = builder.Build();

			commandBus = container.Resolve<ICommandBus>();
		}
	}
}
