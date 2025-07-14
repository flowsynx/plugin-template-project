using FlowSynx.PluginCore;
using FlowSynx.PluginCore.Extensions;
using FlowSynx.PluginCore.Helpers;
using FlowSynx.Plugins.Template.Models;

namespace FlowSynx.Plugins.Template;

public class MathPlugin : IPlugin
{
    private IPluginLogger? _logger;
    private bool _isInitialized;

    public PluginMetadata Metadata => new()
    {
        Id = Guid.Parse("5cb7390d-d578-4cd0-8368-b73d8bae1b0a"),
        Name = "MyPlugin",
        CompanyName = "MyCompany",
        Description = "This is the test plugin for FlowSynx workflow engine.",
        Version = new Version(1, 0, 0),
        Category = PluginCategory.Data,
        Authors = new List<string> { "MyCompany" },
        Copyright = "© MyCompany. All rights reserved.",
        Icon = "flowsynx.png",
        ReadMe = "README.md",
        ProjectUrl = "https://example.com",
        Tags = new List<string>() { "mycompany", "test-plugin", "data", "data-platform", "plugin", "flowsynx" },
        MinimumFlowSynxVersion = new Version(1, 0, 0),
    };

    public PluginSpecifications? Specifications { get; set; }

    public Type SpecificationsType => typeof(MathPluginSpecifications);

    private Dictionary<string, Func<InputParameter, CancellationToken, Task<object?>>> OperationMap
        => new(StringComparer.OrdinalIgnoreCase)
        {
            ["plus"] = ExecuteAddAsync,
            ["subtract"] = ExecuteSubtractAsync,
            ["multiply"] = ExecuteMultiplyAsync,
            ["divide"] = ExecuteDivideAsync
        };

    public IReadOnlyCollection<string> SupportedOperations => OperationMap.Keys;

    public Task Initialize(IPluginLogger logger)
    {
        if (ReflectionHelper.IsCalledViaReflection())
            throw new InvalidOperationException("Reflection-based access is not allowed.");

        ArgumentNullException.ThrowIfNull(logger);
        _logger = logger;
        _isInitialized = true;
        return Task.CompletedTask;
    }

    public async Task<object?> ExecuteAsync(PluginParameters parameters, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (ReflectionHelper.IsCalledViaReflection())
            throw new InvalidOperationException("Reflection-based access is not allowed.");

        if (!_isInitialized)
            throw new InvalidOperationException($"Plugin '{Metadata.Name}' v{Metadata.Version} is not initialized.");

        var inputParameter = parameters.ToObject<InputParameter>();
        if (!OperationMap.TryGetValue(inputParameter.Operation, out var handler))
            throw new NotSupportedException($"Operation '{inputParameter.Operation}' is not supported.");

        return await handler(inputParameter, cancellationToken);
    }

    #region private methods
    private Task<object?> ExecuteAddAsync(InputParameter parameters, CancellationToken cancellationToken)
    {
        double result = parameters.Number1 + parameters.Number2;
        _logger?.LogInfo($"Adding {parameters.Number1} + {parameters.Number2} = {result}");
        return Task.FromResult<object?>(result);
    }

    private Task<object?> ExecuteSubtractAsync(InputParameter parameters, CancellationToken cancellationToken)
    {
        double result = parameters.Number1 - parameters.Number2;
        _logger?.LogInfo($"Subtracting {parameters.Number1} - {parameters.Number2} = {result}");
        return Task.FromResult<object?>(result);
    }

    private Task<object?> ExecuteMultiplyAsync(InputParameter parameters, CancellationToken cancellationToken)
    {
        double result = parameters.Number1 * parameters.Number2;
        _logger?.LogInfo($"Multiplying {parameters.Number1} * {parameters.Number2} = {result}");
        return Task.FromResult<object?>(result);
    }

    private Task<object?> ExecuteDivideAsync(InputParameter parameters, CancellationToken cancellationToken)
    {
        if (parameters.Number2 == 0)
        {
            _logger?.LogError("Division by zero attempted.");
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        double result = parameters.Number1 / parameters.Number2;
        _logger?.LogInfo($"Dividing {parameters.Number1} / {parameters.Number2} = {result}");
        return Task.FromResult<object?>(result);
    }
    #endregion
}