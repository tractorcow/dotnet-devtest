namespace DotNetDevtest.Services;

using System.Globalization;
using DotNetDevtest.Models;

/// <summary>
/// Maps pipeline input to a formatted report entry line.
/// </summary>
public sealed class EntryMapper : IEntryMapper
{
    /// <inheritdoc />
    public ReportEntry Map(PipelineInput input, int sequenceNumber)
    {
        var valuePart = input.Value.HasValue
            ? input.Value.Value.ToString(CultureInfo.InvariantCulture)
            : "—";
        var line = $"{sequenceNumber}. [{input.Id}] {input.Label}: {valuePart}";
        return new ReportEntry
        {
            SourceId = input.Id,
            Line = line,
            SequenceNumber = sequenceNumber,
        };
    }
}
