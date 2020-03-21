using Xunit;
using PizzaBox.Storing.Repositories;
using PizzaBox.Domain;
using System.Linq;

namespace PizzaBox.Testing.Specs
{
  public class PizzaTests
  {
    [Fact]
    public void Test_RepositoryGet()
    {
      var sut = new PizzaRepository();
      var actual = sut.Get();

      Assert.True(actual.Count() >= 0);
    }
  }
}