namespace DotNetDevtest.Services;

using DotNetDevtest.Models;

/// <summary>
/// Maps a pipeline input to a report entry.
/// </summary>
public interface IEntryMapper
{
    /// <summary>
    /// Create a report entry from the input and sequence number.
    /// </summary>
    ReportEntry Map(PipelineInput input, int sequenceNumber);
}
