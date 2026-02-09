namespace DotNetDevtest.Pipeline;

using DotNetDevtest.Models;
using DotNetDevtest.Services;

/// <summary>
/// Report pipeline: validates inputs, maps to entries, yields them, then finalizes for bookkeeping.
/// </summary>
public sealed class ReportPipeline : IReportPipeline
{
    private readonly IInputValidator _validator;
    private readonly IEntryMapper _mapper;
    private readonly IReportFinalizer _finalizer;

    public ReportPipeline(IInputValidator validator, IEntryMapper mapper, IReportFinalizer finalizer)
    {
        _validator = validator;
        _mapper = mapper;
        _finalizer = finalizer;
    }

    /// <inheritdoc />
    public IEnumerable<ReportEntry> Run(IEnumerable<PipelineInput> inputs)
    {
        var sequence = 0;
        foreach (var input in inputs)
        {
            if (!_validator.IsValid(input))
                continue;

            sequence++;
            var entry = _mapper.Map(input, sequence);
            yield return entry;
            _finalizer.FinalizeEntry(entry);
        }
    }
}
