namespace DotNetDevtest.Pipeline;

using DotNetDevtest.Models;

/// <summary>
/// Finalizer that counts how many entries have been finalized (for tests and bookkeeping).
/// </summary>
public sealed class CountingReportFinalizer : IReportFinalizer
{
    /// <summary>
    /// Number of entries that have been finalized.
    /// </summary>
    public int FinalizedCount { get; private set; }

    /// <inheritdoc />
    public void FinalizeEntry(ReportEntry entry)
    {
        FinalizedCount++;
    }
}
