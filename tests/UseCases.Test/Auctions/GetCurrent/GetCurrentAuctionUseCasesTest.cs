using Bogus;
using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Entities;
using Cgs.Leilao.API.Enums;
using Cgs.Leilao.API.UseCases.Leiloes.GetCurrent;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCasesTest
    {
        [Fact]
        public void Sucess()
        {
            //Arrange

            var fakeEntity = new Faker<Auction>()
                .RuleFor(auction => auction.Id, f => f.Random.Number(1,700))
                .RuleFor(auction => auction.Name, f => f.Lorem.Word())
                .RuleFor(auction => auction.Starts, f => f.Date.Past())
                .RuleFor(auction => auction.Ends, f => f.Date.Future())
                .RuleFor(auction => auction.Items, (f,auction) => new List<Item>
                {
                    new Item 
                    { 
                        Id = f.Random.Number(1,700),
                        Name = f.Commerce.ProductName(),
                        Brand = f.Commerce.Department(),
                        BasePrice = f.Random.Decimal(50, 1200),
                        Condition = f.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();

            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(fakeEntity);

            var useCase = new GetCurrentAuctionUseCases(mock.Object);

            //Act
            var auction = useCase.Execute();

            //Assert
            auction.Should().NotBeNull();
            auction.Id.Should().Be(fakeEntity.Id);
            auction.Name.Should().Be(fakeEntity.Name);
        }

        [Fact]
        public void ReturnsNullSucess()
        {
            //Arrange
            var mock = new Mock<IAuctionRepository>();

            var useCase = new GetCurrentAuctionUseCases(mock.Object);

            //Act
            var auction = useCase.Execute();

            //Assert
            auction.Should().BeNull();

        }
    }
}
