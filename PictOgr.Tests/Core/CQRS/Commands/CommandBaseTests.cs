namespace PictOgr.Tests.Core.CQRS.Commands
{
    using System;
    using Autofac;
    using FakeItEasy;
    using PictOgr.Core.AutoFac;
    using PictOgr.Core.CQRS.Bus;
    using PictOgr.Core.CQRS.Command;

    public class CommandBaseTests<T> where T : ICommand
    {
        protected ICommandBus commandBus;
        protected Action<ICommand> handleMethod;

        public CommandBaseTests()
        {
            var builder = Container.CreateBuilder();

            var fakeHandler = A.Fake<ICommandHandler<T>>();

            A.CallTo(() => fakeHandler.Handle(A<T>._))
                .Invokes((T command) =>
                {
                    handleMethod(command);
                });

            builder.Register(c => fakeHandler).AsImplementedInterfaces();

            var container = builder.Build();

            commandBus = container.Resolve<ICommandBus>();
        }
    }
}
