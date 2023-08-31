using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Moq;
namespace Rapidata.Application.UnitTests;

[TestFixture]
public abstract class BaseTest<TEntity>
{
    [TearDown]
    public void TearDown()
    {
        foreach (var mock in _mocks)
        {
            mock.Reset();
        }
    }

    [SetUp]
    public virtual void SetUp()
    {
    }
    private readonly IList<Mock> _mocks;
    protected readonly TEntity Subject;

    protected BaseTest()
    {
        var subjectType = typeof(TEntity);
        var constructor = subjectType.GetConstructors().First();
        var parameters = constructor.GetParameters();
        _mocks = new List<Mock>();
        foreach (var parameter in parameters)
        {
            var mockType = typeof(Mock<>).MakeGenericType(parameter.ParameterType);
            var mock = (Mock)Activator.CreateInstance(mockType)!;
            _mocks.Add(mock);
        }

        Subject = (TEntity)constructor.Invoke(_mocks.Select(e => e.Object).ToArray())!;
    }

    protected Mock<TMock> Mock<TMock>() where TMock : class
    {
        return _mocks.First(e => e.GetType() == typeof(Mock<TMock>)) as Mock<TMock> ??
               throw new ArgumentException("Mock not found");
    }

    public void VerifyLog(LogLevel level)
    {
        Mock<ILogger<TEntity>>().Verify(
            x => x.Log(
                level,
                It.IsAny<EventId>(),
                It.Is<It.IsAnyType>((v, t) => true),
                It.IsAny<Exception>(),
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)), Times.Once);
    }
}
