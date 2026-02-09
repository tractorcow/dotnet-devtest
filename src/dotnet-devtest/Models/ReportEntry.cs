namespace DotNetDevtest.Models;

/// <summary>
/// A single entry produced by the report pipeline.
/// </summary>
public class ReportEntry
{
    /// <summary>
    /// Source input id.
    /// </summary>
    public string SourceId { get; set; } = string.Empty;

    /// <summary>
    /// Formatted line for the report.
    /// </summary>
    public string Line { get; set; } = string.Empty;

    /// <summary>
    /// One-based sequence number when the entry was produced.
    /// </summary>
    public int SequenceNumber { get; set; }
}
