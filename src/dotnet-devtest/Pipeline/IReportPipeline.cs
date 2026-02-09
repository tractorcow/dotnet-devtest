namespace DotNetDevtest.Pipeline;

using DotNetDevtest.Models;

/// <summary>
/// Produces a stream of report entries from pipeline inputs.
/// </summary>
public interface IReportPipeline
{
    /// <summary>
    /// Run the pipeline over the given inputs and yield report entries.
    /// </summary>
    IEnumerable<ReportEntry> Run(IEnumerable<PipelineInput> inputs);
}
