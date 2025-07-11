using System.Management.Automation;
using HorizonREST.Models;

namespace HorizonREST.PowerShell;

[Cmdlet(VerbsCommunications.Connect, "HorizonServer")]

public sealed class GetHorizonServerCommand : PSCmdlet
{

    [Parameter(Mandatory = true)]
    public string Server { get; set; }
    
    [Parameter(Mandatory = true)]
    public PSCredential Credentials { get; set; }

    private Action<string>? _renewalHandler;

    protected override void ProcessRecord()
    {
        if (_renewalHandler == null)
        {
            _renewalHandler = msg => ConnectionState.Log($"Renewal event received: {msg}");
            ConnectionState.Instance.OnRenewal += _renewalHandler;
        }
        var result = HorizonREST.ApiClient.ConnectHorizon(Server, Credentials).GetAwaiter().GetResult();
        AuthContainer.Instance.LastAuthResponse = result;
    }
}