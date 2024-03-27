using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace DesafioBackend.Mottu.Pages;

public class Index_Tests : MottuWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
