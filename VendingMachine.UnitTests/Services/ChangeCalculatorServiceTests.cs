using FluentAssertions;
using Moq;
using VendingMachine.Application.Contracts;
using VendingMachine.Application.Models;
using VendingMachine.Application.Repositories;
using VendingMachine.Application.Services;
using VendingMachine.Application.Services.Implementations;

namespace VendingMachine.UnitTests.Services;

public class ChangeCalculatorServiceTests
{
    private readonly Mock<ICashRepository> _cashRepositoryMock;
    private readonly IChangeCalculatorService _sut;
    
    public ChangeCalculatorServiceTests()
    {
        _cashRepositoryMock = new Mock<ICashRepository>();
        _sut = new ChangeCalculatorService(_cashRepositoryMock.Object);
    }
    
    [Fact]
    public void GetChange_1pChangeAvailable_ShouldReturnCorrectChange()
    {
        // Arrange
        var change = new List<ICoin>
        {
            new GenericDenomination(1, "1p")
        };
        
        _cashRepositoryMock.Setup(x => x.Count(It.IsAny<Func<ICoin, bool>>())).Returns(1);
        
        // Act
        var result = _sut.GetChange(1);
        
        // Assert
        result.Should().BeEquivalentTo(change);

        _cashRepositoryMock.Verify(x => x.Count(It.IsAny<Func<ICoin, bool>>()), Times.Exactly(8));
    }
    
    [Fact]
    public void GetChange_2pChangeAvailable_ShouldReturnCorrectChange()
    {
        // Arrange
        var change = new List<ICoin>
        {
            new GenericDenomination(2, "2p"),
        };
        
        _cashRepositoryMock.Setup(x => x.Count(It.IsAny<Func<ICoin, bool>>())).Returns(2);
        
        // Act
        var result = _sut.GetChange(2);
        
        // Assert
        result.Should().BeEquivalentTo(change);
        
        _cashRepositoryMock.Verify(x => x.Count(It.IsAny<Func<ICoin, bool>>()), Times.Exactly(8));
    }

    [Fact]
    public void GetChange_15pChangeAvailable_ShouldReturnCorrectChange()
    {
        // Arrange
        var change = new List<ICoin>
        {
            new GenericDenomination(10, "10p"),
            new GenericDenomination(5, "5p")
        };
        
        _cashRepositoryMock.Setup(x => x.Count(It.IsAny<Func<ICoin, bool>>())).Returns(2);
        
        // Act
        var result = _sut.GetChange(15);
        
        // Assert
        result.Should().BeEquivalentTo(change);
        
        _cashRepositoryMock.Verify(x => x.Count(It.IsAny<Func<ICoin, bool>>()), Times.Exactly(8));
    }
    
    [Fact]
    public void GetChange_3pChangeAvailable_ShouldReturnCorrectChange()
    {
        // Arrange
        var change = new List<ICoin>
        {
            new GenericDenomination(2, "2p"),
            new GenericDenomination(1, "1p")
        };
        
        _cashRepositoryMock.Setup(x => x.Count(It.IsAny<Func<ICoin, bool>>())).Returns(2);
        
        // Act
        var result = _sut.GetChange(3);
        
        // Assert
        result.Should().BeEquivalentTo(change);
        
        _cashRepositoryMock.Verify(x => x.Count(It.IsAny<Func<ICoin, bool>>()), Times.Exactly(8));
    }
    
    [Fact]
    public void GetChange_WhenChangeIsNotAvailable_ShouldThrowException()
    {
        // Arrange
        _cashRepositoryMock.Setup(x => x.Count(It.IsAny<Func<ICoin, bool>>())).Returns(0);
        
        // Act
        var act = () => _sut.GetChange(1);
        
        // Assert
        act.Should().Throw<Exception>();
    }
}