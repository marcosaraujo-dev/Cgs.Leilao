using Bogus;
using Cgs.Leilao.API.Communication.Requests;
using Cgs.Leilao.API.Contracts;
using Cgs.Leilao.API.Entities;
using Cgs.Leilao.API.Services;
using Cgs.Leilao.API.UseCases.Leiloes.GetCurrent;
using Cgs.Leilao.API.UseCases.Offers.CreateOffer;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UseCases.Test.Offers.CreateOffer
{
    public class CreateOfferUseCaseTest
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Sucess(int itemId)
        {
            //Arrange

            var request = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700))
                .Generate();

            var offerRepository = new Mock<IOfferRepository>();

            var loggedUser = new Mock<ILoggedUser>();
            loggedUser.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

            //Act
            var act = () =>  useCase.Execute(itemId, request);

            //Assert
           act.Should().NotThrow();
        }

      
    }
}
