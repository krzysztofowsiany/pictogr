using System;
using Autofac;
using Xunit;
using Shouldly;
using FakeItEasy;
using PictOgr.Core.AutoFac;
using PictOgr.Core.CQRS;
using PictOgr.Core.CQRS.Command;

namespace PictOgr.Tests.Core.CQRS
{
    public class CommandBusTest
    {
        private IContainer container;

        public CommandBusTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<CQRSModule>();
            container = builder.Build();
        }

        [Fact]
        public void test_command_bus_are_correct_resolved()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var command_bus = scope.Resolve<ICommandBus>();


                command_bus.ShouldBeOfType<CommandBus>();

                Should.Throw<Exception>(() =>
                {
                    command_bus.SendCommand(new CommandTest());
                });
            }
        }
    }
}
