namespace DotNetDevtest.Pipeline;

/// <summary>
/// Optional configuration for the report pipeline (reserved for future use).
/// </summary>
public sealed class PipelineOptions
{
    /// <summary>
    /// Maximum number of entries to produce (0 = no limit).
    /// </summary>
    public int MaxEntries { get; set; }
}
