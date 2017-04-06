namespace PictOgr.Tests.Core.CQRS.Events
{
    using System;
    using Autofac;
    using FakeItEasy;
    using PictOgr.Core.AutoFac;
    using PictOgr.Core.CQRS.Bus;
    using PictOgr.Core.CQRS.Event;
    using Shouldly;
    using Xunit;

    public class EventdBusTest
    {
        private readonly IContainer container;

        public EventdBusTest()
        {
            this.container = Container.CreateBuilder().Build();
        }

        [Fact]
        public void test_event_bus_are_correct_resolved()
        {
            using (var scope = this.container.BeginLifetimeScope())
            {
                var eventBus = scope.Resolve<IEventBus>();

                eventBus.ShouldBeOfType<EventBus>();

                Should.Throw<Exception>(() =>
                    {
                        var fakeEvent = A.Fake<IEvent>();
                        eventBus.Publish(fakeEvent);
                    });
            }
        }
    }
}
