namespace DotNetDevtest;

using DotNetDevtest.Models;
using DotNetDevtest.Pipeline;
using DotNetDevtest.Services;

/// <summary>
/// Entry point for the dotnet-devtest library. Use this to obtain a report pipeline and run operations that require a pipeline.
/// </summary>
public static class Library
{
    /// <summary>
    /// Creates a report pipeline with default validator, mapper, and finalizer.
    /// Use this when you want a ready-to-use pipeline without custom dependencies.
    /// </summary>
    /// <returns>An <see cref="IReportPipeline"/> instance configured with default components.</returns>
    public static IReportPipeline CreatePipeline()
    {
        return new ReportPipeline(new InputValidator(), new EntryMapper(), new CountingReportFinalizer());
    }

    /// <summary>
    /// Creates a report pipeline with default validator and mapper, and the supplied finalizer.
    /// Use this when you need custom finalization (e.g. logging, metrics, or dependency injection).
    /// </summary>
    /// <param name="finalizer">The finalizer to call after each entry is yielded.</param>
    /// <returns>An <see cref="IReportPipeline"/> instance.</returns>
    public static IReportPipeline CreatePipeline(IReportFinalizer finalizer)
    {
        return new ReportPipeline(new InputValidator(), new EntryMapper(), finalizer);
    }

    /// <summary>
    /// Runs the given pipeline and returns only the first report entry, if any.
    /// </summary>
    /// <param name="pipeline">The report pipeline to run.</param>
    /// <param name="inputs">The pipeline inputs to process.</param>
    /// <returns>The first report entry, or null if the pipeline yields no entries.</returns>
    public static ReportEntry? GetFirstEntry(IReportPipeline pipeline, IEnumerable<PipelineInput> inputs)
    {
        return pipeline.Run(inputs).FirstOrDefault();
    }
}
