using System.Threading.Tasks;

namespace DesafioBackend.Mottu.Data;

public interface IMottuDbSchemaMigrator
{
    Task MigrateAsync();
}
