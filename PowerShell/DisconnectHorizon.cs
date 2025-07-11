using HorizonREST.Models;
using System.Management.Automation;

namespace HorizonREST.PowerShell;

[Cmdlet(VerbsCommunications.Disconnect, "HorizonServer")]

public sealed class DisconnectHorizonCommand : PSCmdlet
{
    protected override void ProcessRecord()
    {
        HorizonREST.ApiClient.Disconnect(AuthContainer.Instance.LastAuthResponse.refresh_token);
    }
}