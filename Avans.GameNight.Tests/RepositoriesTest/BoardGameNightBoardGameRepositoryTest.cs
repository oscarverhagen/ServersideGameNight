using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avans.GameNight.Core.Domain.Models;
using Avans.GameNight.Infrastructure.EntityFramework.Repository;
using Avans.GameNight.Infrastructure.EntityFramework.DataContext;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Avans.GameNight.Tests.RepositoriesTest
{
    public class BoardGameNightBoardGameRepositoryTest
    {
        //[Fact]
        //public async Task AddBoardGameNightBoardGame_Should_AddToDatabase()
        //{
        //    // Arrange
        //    var boardGameNightBoardGame = new BoardGameNightBoardGame();
        //    var mockContext = new Mock<AppDbContext>();
        //    var repository = new BoardGameNightBoardGameRepository(mockContext.Object);

        //    // Act
        //    await repository.AddBoardGameNightBoardGame(boardGameNightBoardGame);

        //    // Assert
        //    mockContext.Verify(c => c.Add(boardGameNightBoardGame), Times.Once);
        //    mockContext.Verify(c => c.SaveChangesAsync(CancellationToken.None), Times.Once);
        //}

        //[Fact]
        //public async Task UpdateBoardGameNightBoardGame_Should_UpdateInDatabase()
        //{
        //    // Arrange
        //    var boardGameNightBoardGame = new BoardGameNightBoardGame();
        //    var mockContext = new Mock<AppDbContext>();
        //    var repository = new BoardGameNightBoardGameRepository(mockContext.Object);

        //    // Act
        //    await repository.UpdateBoardGameNightBoardGame(boardGameNightBoardGame);

        //    // Assert
        //    mockContext.Verify(c => c.Update(boardGameNightBoardGame), Times.Once);
        //    mockContext.Verify(c => c.SaveChangesAsync(CancellationToken.None), Times.Once);
        //}

        //[Fact]
        //public async Task DestroyBoardGameNightBoardGame_Should_RemoveFromDatabase()
        //{
        //    // Arrange
        //    var boardGameNightBoardGame = new BoardGameNightBoardGame();
        //    var mockContext = new Mock<AppDbContext>();
        //    var repository = new BoardGameNightBoardGameRepository(mockContext.Object);

        //    // Act
        //    await repository.DestroyBoardGameNightBoardGame(boardGameNightBoardGame);

        //    // Assert
        //    mockContext.Verify(c => c.Remove(boardGameNightBoardGame), Times.Once);
        //    mockContext.Verify(c => c.SaveChangesAsync(CancellationToken.None), Times.Once);
        //}
    }
}
