using Xunit;
using MyProject.Infrastructure.Persistence;
using System.IO;

namespace MyProject.Tests.Infrastructure;

public class FileStorageTests
{
    [Fact]
    public void Should_Write_And_Open_File()
    {
        var storage = new FileStorage();

        var path = Path.GetTempFileName();

        storage.Open(path);
        storage.Write("test data");
        storage.Dispose();

        var content = File.ReadAllText(path);

        Assert.Contains("test data", content);
    }
}