﻿using Bogus;
using FluentAssertions;
using Moq;
using RocketseatAuction.API.Comunication.Requests;
using RocketseatAuction.API.Contracts;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Services;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;
using Xunit;

namespace UseCases.Test.Auctions.Offers.CreateOffer;
public class CreateOfferUseCaseTest
{
    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(3)]
    public void Sucess(int itemId)
    {
        var request = new Faker<ResquestCreateOfferJson>()
            .RuleFor(request => request.Price, f => f.Random.Decimal(1, 700)).Generate();

        var offerRepository = new Mock<IOfferRepository>();
        var loggedUser = new Mock<ILoggedUser>();
        loggedUser.Setup(i => i.User()).Returns(new User());

        var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

        var act = () => useCase.Execute(itemId, request);

        act.Should().NotThrow();
    }
}
