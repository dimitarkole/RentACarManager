namespace RentCar.Services.Data.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RentCar.Data;
    using RentCar.Services.Data.Tests.ClassFixtures;
    using RentCar.Services.Data.Tests.Factories;
    using Xunit;

    public class BaseTestClass : IClassFixture<MappingsProvider>
    {
        protected readonly ApplicationDbContext context;

        public BaseTestClass()
        {
            this.context = ApplicationDbContextFactory.CreateInMemoryDatabase();
        }
    }
}
