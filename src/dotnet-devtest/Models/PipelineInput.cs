namespace DotNetDevtest.Models;

/// <summary>
/// Raw input item for the report pipeline.
/// </summary>
public class PipelineInput
{
    /// <summary>
    /// Unique identifier for the input record.
    /// </summary>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Display label or title.
    /// </summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>
    /// Optional numeric value to include in the report.
    /// </summary>
    public decimal? Value { get; set; }
}
