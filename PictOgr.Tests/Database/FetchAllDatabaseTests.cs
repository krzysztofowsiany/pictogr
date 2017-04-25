namespace PictOgr.Tests.Database
{
    using Autofac;
    using Xunit;
    using System.Collections.Generic;
    using FakeItEasy;
    using Infrastructure.Services.DatabaseService;
    using Ploeh.AutoFixture;
    using Shouldly;

    public class FetchAllDatabaseTests
    {
        private readonly IContainer container;

        private Fixture fixture;

        private List<Customer> customers;

        private IDatabaseService fakeDatabase;

        public FetchAllDatabaseTests()
        {
            fixture = new Fixture();
            customers = new List<Customer>();
            fakeDatabase = A.Fake<IDatabaseService>();
        }

        [Fact]
        public void should_be_able_to_insert_and_get_inserted_data_to_list()
        {
            //arragne
            A.CallTo(() => fakeDatabase.Insert(A<object>._))
                .Invokes((object o) =>
                {
                    customers.Add((Customer)o);
                }).Returns(true);

            A.CallTo(() => fakeDatabase.FetchAll<Customer>()).Returns(customers);

            var customersFromDatabase = Act();

            for (var i = 0; i < customers.Count; i++)
            {
                customers[i].ShouldBe(customersFromDatabase[i]);
            }
        }

        private IList<Customer> Act()
        {
            for (var i = 0; i < 10; i++)
            {
                var customer = new Customer() { Id = this.fixture.Create<int>(), Name = this.fixture.Create<string>() };
                fakeDatabase.Insert(customer);
            }

            return fakeDatabase.FetchAll<Customer>();
        }
    }
}
