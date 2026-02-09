namespace DotNetDevtest.Services;

using DotNetDevtest.Models;

/// <summary>
/// Default validator: requires non-empty Id and Label.
/// </summary>
public sealed class InputValidator : IInputValidator
{
    /// <inheritdoc />
    public bool IsValid(PipelineInput input)
    {
        if (input == null)
            return false;
        return !string.IsNullOrWhiteSpace(input.Id) && !string.IsNullOrWhiteSpace(input.Label);
    }
}
