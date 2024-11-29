namespace Unit.Tests._04___Data;

using Data.SqlServer;
using Data.SqlServer.Entities;
using Data.SqlServer.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

public class ItemRepositoryTests
{
    private readonly SqlDbContext _context;
    private readonly ItemRepository _repository;

    public ItemRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<SqlDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        _context = new SqlDbContext(options);
        _repository = new ItemRepository(_context);
    }

    [Fact]
    public async Task SearchAsync_ShouldReturnAllItems()
    {
        // Arrange
        // Act
        // Assert
    }
}