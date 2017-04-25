namespace PictOgr.Tests.Database
{
    using System.Collections.Generic;
    using FakeItEasy;
    using Infrastructure.Services.DatabaseService;
    using Xunit;
    using Ploeh.AutoFixture;
    using Shouldly;

    public class DeleteDatabaseTests
    {
        private Fixture fixture;

        public DeleteDatabaseTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void test_insert_data_to_database_should_be_saved_and_cant_get()
        {
            //arragne
            var customers = new List<Customer>();

            var fakeDatabase = A.Fake<IDatabaseService>();

            A.CallTo(() => fakeDatabase.Insert(A<Customer>._))
                .Invokes((Customer c) =>
                {
                    customers.Add(c);
                }).Returns(true);

            A.CallTo(() => fakeDatabase.FetchAll<Customer>()).Returns(customers);

            A.CallTo(() => fakeDatabase.Delete(A<Customer>._))
                .Invokes((Customer c) =>
                {
                    customers.Remove(c);
                }).Returns(true);

            //act
            for (var i = 0; i < 10; i++)
            {
                var customer = new Customer() { Id = this.fixture.Create<int>(), Name = fixture.Create<string>() };
                fakeDatabase.Insert(customer);
                fakeDatabase.Delete(customer);
            }

            //assert
            customers.Count.Equals(0).ShouldBeTrue();
        }
    }
}
