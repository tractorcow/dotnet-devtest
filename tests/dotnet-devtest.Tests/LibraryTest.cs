namespace DotNetDevtest.Tests;

using DotNetDevtest;
using DotNetDevtest.Models;
using DotNetDevtest.Pipeline;
using DotNetDevtest.Services;
using Xunit;

public sealed class LibraryTest
{
    /// <summary>
    /// GetFirstEntry returns the first report entry;
    /// </summary>
    [Fact]
    public void GetFirstEntry_WithMultipleInputs_ReturnsFirstEntry()
    {
        var processedCountTracker = new CountingReportFinalizer();
        var pipeline = new ReportPipeline(new InputValidator(), new EntryMapper(), processedCountTracker);
        var inputs = new[]
        {
            new PipelineInput { Id = "a", Label = "First", Value = 1m },
            new PipelineInput { Id = "b", Label = "Second", Value = 2m },
        };

        ReportEntry? first = Library.GetFirstEntry(pipeline, inputs);

        Assert.NotNull(first);
        Assert.Equal("a", first.SourceId);
        Assert.Equal(1, processedCountTracker.FinalizedCount);
    }
}
