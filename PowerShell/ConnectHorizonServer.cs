using System.Management.Automation;
using HorizonREST.Classes;

namespace HorizonREST.PowerShell;

[Cmdlet(VerbsCommunications.Connect, "HorizonServer")]

public sealed class GetHorizonServerCommand : PSCmdlet
{
    [Parameter(Mandatory = true)]
    public string Server { get; set; }
    
    [Parameter(Mandatory = true)]
    public PSCredential Credentials { get; set; }

    protected override void ProcessRecord()
    {
        var result = Classes.HorizonREST.ApiClient.ConnectHorizon(Server, Credentials).GetAwaiter().GetResult();
        AuthContainer.Instance.LastAuthResponse = result;
    }
}