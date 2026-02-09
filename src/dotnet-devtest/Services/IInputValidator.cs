namespace DotNetDevtest.Services;

using DotNetDevtest.Models;

/// <summary>
/// Validates pipeline inputs before they are mapped to report entries.
/// </summary>
public interface IInputValidator
{
    /// <summary>
    /// Returns true if the input should be included in the report.
    /// </summary>
    bool IsValid(PipelineInput input);
}
