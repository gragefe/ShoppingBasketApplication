namespace Unit.Tests._04___Data;

using Data.SqlServer;
using Data.SqlServer.Repositories;
using Domain.Model.Entities;
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
        var random = new Random();
        var items = new List<Item>();

        for (int i = 0; i < 100; i++)
        {
            items.Add(new Item
            {
                Name = $"Name{i + 1}",
                Description = $"Description{i + 1}",
                Discounts = new List<Guid> { Guid.NewGuid() },
                Price = random.Next(1, 4)
            });
        }

        foreach (var item in items)
        {
            await _repository.CreateAsync(item);
        }

        // Act
        var result = await _repository.SearchAsync(new ItemSearchContext());

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Results);
        
        Assert.Equal(1, result.CurrentPage);
        Assert.Equal(20, result.TotalPages);
        Assert.Equal(100, result.TotalItems);
        

        Assert.Equal(items.ElementAt(0).Name, result.Results.ElementAt(0).Name);
        Assert.Equal(items.ElementAt(1).Name, result.Results.ElementAt(1).Name);
        Assert.Equal(items.ElementAt(2).Name, result.Results.ElementAt(2).Name);
    }

    [Fact]
    public async Task SearchAsync_ShouldReturnPagesWithSpecificSize()
    {
        // Arrange
        var random = new Random();
        var items = new List<Item>();

        for (int i = 0; i < 100; i++)
        {
            items.Add(new Item
            {
                Name = $"Name{i + 1}",
                Description = $"Description{i + 1}",
                Discounts = new List<Guid> { Guid.NewGuid() },
                Price = random.Next(1, 4)
            });
        }

        foreach (var item in items)
        {
            await _repository.CreateAsync(item);
        }

        // Act
        var result = await _repository.SearchAsync(new ItemSearchContext { PageSize = 25 });

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Results);

        Assert.Equal(1, result.CurrentPage);
        Assert.Equal(4, result.TotalPages);
        Assert.Equal(100, result.TotalItems);


        Assert.Equal(items.ElementAt(0).Name, result.Results.ElementAt(0).Name);
        Assert.Equal(items.ElementAt(1).Name, result.Results.ElementAt(1).Name);
        Assert.Equal(items.ElementAt(2).Name, result.Results.ElementAt(2).Name);
    }

    [Fact]
    public async Task SearchAsync_ShouldReturnItemsFromSpecificPage()
    {
        // Arrange
        var random = new Random();
        var items = new List<Item>();

        for (int i = 0; i < 100; i++)
        {
            items.Add(new Item
            {
                Name = $"Name{i + 1}",
                Description = $"Description{i + 1}",
                Discounts = new List<Guid> { Guid.NewGuid() },
                Price = random.Next(1, 4)
            });
        }

        foreach (var item in items)
        {
            await _repository.CreateAsync(item);
        }

        // Act
        var result = await _repository.SearchAsync(new ItemSearchContext { PageNumber = 2});

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Results);

        Assert.Equal(2, result.CurrentPage);
        Assert.Equal(20, result.TotalPages);
        Assert.Equal(100, result.TotalItems);


        Assert.Equal(items.ElementAt(5).Name, result.Results.ElementAt(0).Name);
        Assert.Equal(items.ElementAt(6).Name, result.Results.ElementAt(1).Name);
        Assert.Equal(items.ElementAt(7).Name, result.Results.ElementAt(2).Name);
    }

    [Fact]
    public async Task SearchAsync_ShouldReturnItemContainingSpecificName()
    {
        // Arrange
        var item = new Item
        {
            Name = "item 0001",
            Description = "Item description",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 1.86
        };

        var item2 = new Item
        {
            Name = "item 0002",
            Description = "Item description",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 20.99
        };

        var item3 = new Item
        {
            Name = "item 3",
            Description = "Item description",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 18.53
        };

        var item4 = new Item
        {
            Name = "item 4",
            Description = "Item description",
            Discounts = new List<Guid> { Guid.NewGuid() },
            Price = 17.30
        };

        await _repository.CreateAsync(item);
        await _repository.CreateAsync(item2);
  
        // Act
        var result = await _repository.SearchAsync(new ItemSearchContext { Name = "item 000" });

        // Assert
        Assert.NotNull(result);
        Assert.NotNull(result.Results);

        Assert.Equal(1, result.CurrentPage);
        Assert.Equal(1, result.TotalPages);
        Assert.Equal(2, result.TotalItems);

        Assert.Equal(item.Name, result.Results.ElementAt(0).Name);
        Assert.Equal(item2.Name, result.Results.ElementAt(1).Name);
    }
}