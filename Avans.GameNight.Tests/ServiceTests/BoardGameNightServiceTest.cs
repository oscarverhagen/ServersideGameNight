using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avans.GameNight.Core.Domain.Interfaces;
using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Core.DomainServices.Interfaces;
using Avans.GameNight.Core.DomainServices.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using Xunit;

namespace Avans.GameNight.Tests.ServiceTests
{
    public class BoardGameNightServiceTest
    {
        [Fact]
        public async Task GetBoardGameNights_Should_ReturnListOfBoardGameNights()
        {
            // Arrange
            var boardGameNights = new List<BoardGameNight>(); // Prepare your expected data
            var boardGameNightRepo = new Mock<IBoardGameNightRepository>();
            boardGameNightRepo.Setup(repo => repo.GetBoardGameNights()).ReturnsAsync(boardGameNights);

            var service = new BoardGameNightService(
                userManager: null, 
                boardGameNightRepo.Object,
                playerRepo: null, 
                boardGameRepo: null, 
                boardGameNightPlayerRepo: null, 
                boardGameNightBoardGameRepo: null 
            );

            // Act
            var result = await service.GetBoardGameNights();

            // Assert
            Xunit.Assert.Same(boardGameNights, result);
        }

        [Fact]
        public async Task GetBoardGameNightByName_Should_ReturnBoardGameNight()
        {
            // Arrange
            var boardGameNight = new BoardGameNight(); // Prepare your expected data
            var boardGameNightRepo = new Mock<IBoardGameNightRepository>();
            boardGameNightRepo.Setup(repo => repo.GetBoardGameNightByName(It.IsAny<string>())).ReturnsAsync(boardGameNight);

            var service = new BoardGameNightService(
                userManager: null,
                boardGameNightRepo.Object,
                playerRepo: null, 
                boardGameRepo: null,
                boardGameNightPlayerRepo: null, 
                boardGameNightBoardGameRepo: null 
            );

            // Act
            var result = await service.GetBoardGameNightByName("SomeName");

            // Assert
            Xunit.Assert.Same(boardGameNight, result);
        }

    }
}
