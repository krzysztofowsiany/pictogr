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

    public class EventdBusTest : IDisposable
    {
        private readonly IContainer container;
        private IEvent eventFromInvoke;
        private IEvent fakeEvent;
        private IEventHandler<IEvent> fakeEventHandler;

        public EventdBusTest()
        {
            container = Container.CreateBuilder().Build();

            fakeEvent = A.Fake<IEvent>();

            fakeEventHandler = A.Fake<IEventHandler<IEvent>>();

            A.CallTo(() => fakeEventHandler.Handle(A<IEvent>._))
                  .Invokes((IEvent ev) =>
                  {
                      eventFromInvoke = ev;
                  });
        }

        [Fact]
        public void test_event_bus_are_correct_resolved()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var eventBus = scope.Resolve<IEventBus>();

                eventBus.ShouldBeOfType<EventBus>();
            }
        }

        [Fact]
        public void event_bus_publish_should_throw_excetion()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var eventBus = scope.Resolve<IEventBus>();

                var fakeEvent = A.Fake<IEvent>();

                Should.Throw<TypeUnloadedException>(() => { eventBus.Publish(fakeEvent); });
            }
        }

        [Fact]
        public void event_bus_register_should_add_event_handler()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var eventBus = scope.Resolve<IEventBus>();

                eventBus.Register(fakeEventHandler);
                eventBus.Publish(fakeEvent);
                eventBus.UnRegister(fakeEventHandler);

                eventFromInvoke.ShouldBeSameAs(fakeEvent);
            }
        }

        [Fact]
        public void event_bus_register_and_unregister_should_throw_exception_when_publish()
        {
            using (var scope = container.BeginLifetimeScope())
            {
                var eventBus = scope.Resolve<IEventBus>();

                eventBus.Register(fakeEventHandler);
                eventBus.UnRegister(fakeEventHandler);

                Should.Throw<TypeUnloadedException>(() => { eventBus.Publish(fakeEvent); });
                eventFromInvoke.ShouldBeNull();
            }
        }

        public void Dispose()
        {
        }
    }
}
