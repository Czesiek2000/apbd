using Xunit;

namespace Apbd14.Tests
{
    [CollectionDefinition("Integration tests")]
    public class IntegrationTestsFixtureCollection : ICollectionFixture<TestApbdWebApplicationFactory<TestStartup>>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
