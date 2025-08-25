using System;
using WSDK.Configuration;
using Xunit;

namespace WSDK.Tests;

public class WalacorClientBuilderTests
{
    [Fact]
    public void BuildCreatesClient()
    {
        var client = new WalacorClientBuilder()
            .WithBaseAddress(new Uri("https://example.com"))
            .Build();

        Assert.NotNull(client);
        Assert.NotNull(client.Auth);
    }
}
