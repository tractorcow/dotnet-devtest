namespace DotNetDevtest.Tests;

using DotNetDevtest.Models;
using DotNetDevtest.Pipeline;
using DotNetDevtest.Services;
using Xunit;

public sealed class ReportPipelineTests
{
    [Fact]
    public void Run_FullEnumeration_ReturnsAllMappedEntries()
    {
        var finalizer = new CountingReportFinalizer();
        var pipeline = new ReportPipeline(new InputValidator(), new EntryMapper(), finalizer);
        var inputs = new[]
        {
            new PipelineInput { Id = "a", Label = "First", Value = 10m },
            new PipelineInput { Id = "b", Label = "Second", Value = 20m },
            new PipelineInput { Id = "c", Label = "Third", Value = null },
        };

        var results = pipeline.Run(inputs).ToList();

        Assert.Equal(3, results.Count);
        Assert.Equal("a", results[0].SourceId);
        Assert.Equal("b", results[1].SourceId);
        Assert.Equal("c", results[2].SourceId);
        Assert.Equal(1, results[0].SequenceNumber);
        Assert.Equal(2, results[1].SequenceNumber);
        Assert.Equal(3, results[2].SequenceNumber);
        Assert.Contains("First", results[0].Line);
        Assert.Contains("Second", results[1].Line);
        Assert.Contains("Third", results[2].Line);
    }

    [Fact]
    public void Run_FullEnumeration_FinalizerCountMatchesYieldedCount()
    {
        var finalizer = new CountingReportFinalizer();
        var pipeline = new ReportPipeline(new InputValidator(), new EntryMapper(), finalizer);
        var inputs = new[]
        {
            new PipelineInput { Id = "x", Label = "One" },
            new PipelineInput { Id = "y", Label = "Two" },
        };

        var results = pipeline.Run(inputs).ToList();

        Assert.Equal(2, results.Count);
        Assert.Equal(2, finalizer.FinalizedCount);
    }
}
