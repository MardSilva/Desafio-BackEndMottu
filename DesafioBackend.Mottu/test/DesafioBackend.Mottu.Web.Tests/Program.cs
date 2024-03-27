using Microsoft.AspNetCore.Builder;
using DesafioBackend.Mottu;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<MottuWebTestModule>();

public partial class Program
{
}
