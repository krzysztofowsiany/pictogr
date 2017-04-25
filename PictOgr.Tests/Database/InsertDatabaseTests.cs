namespace PictOgr.Tests.Database
{
    using System.Collections.Generic;
    using FakeItEasy;
    using Infrastructure.Services.DatabaseService;
    using Xunit;
    using Ploeh.AutoFixture;
    using Shouldly;

    public class InsertDatabaseTests
    {
        private Fixture fixture;

        public InsertDatabaseTests()
        {
            fixture = new Fixture();
        }
       
        [Fact]
        public void test_insert_data_to_database_should_return_true()
        {
            var customer = new Customer() { Id = 1, Name = "TEST1" };
            var fakeDatabase = A.Fake<IDatabaseService>();

            A.CallTo(() => fakeDatabase.Insert(customer)).Returns(true);

            fakeDatabase.Insert(customer).ShouldBeTrue();
        }


        [Fact]
        public void should_by_able_to_insert_and_count_of_data_must_be_eual()
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


            //act
            for (var i = 0; i < 10; i++)
            {
                var customer = new Customer() { Id = this.fixture.Create<int>(), Name = fixture.Create<string>() };
                fakeDatabase.Insert(customer);
            }

            //assert
            customers.Count.Equals(10).ShouldBeTrue();
        }
    }
}
