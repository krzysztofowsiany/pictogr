using System;
using Autofac;
using Xunit;
using Shouldly;
using FakeItEasy;
using PictOgr.Core.AutoFac;
using PictOgr.Core.CQRS.Command;

namespace PictOgr.Tests.Core.CQRS
{
    public class command_bus_test
    {
        private IContainer container;

        public command_bus_test()
        {
            container = Container.CreateBuilder().Build();
        }

        [Fact]
        public void test_command()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var command_bus = scope.Resolve<ICommandBus>();


                command_bus.ShouldBeOfType<ICommandBus>();
                

                Should.Throw<Exception>(() =>
                {
                    command_bus.SendCommand(new CommandTest());
                });
            }
        }
    }
}
