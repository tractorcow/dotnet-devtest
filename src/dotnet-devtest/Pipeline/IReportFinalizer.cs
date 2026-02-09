namespace DotNetDevtest.Pipeline;

using DotNetDevtest.Models;

/// <summary>
/// Called when a report entry has been yielded and should be committed for bookkeeping.
/// </summary>
public interface IReportFinalizer
{
    /// <summary>
    /// Finalize the given entry (e.g. record that it was emitted).
    /// </summary>
    void FinalizeEntry(ReportEntry entry);
}
