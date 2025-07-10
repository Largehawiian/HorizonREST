using HorizonREST.Classes;
using System.Management.Automation;

namespace HorizonREST.PowerShell;

[Cmdlet(VerbsCommunications.Disconnect, "HorizonServer")]

public sealed class DisconnectHorizonCommand : PSCmdlet
{
    protected override void ProcessRecord()
    {
        Classes.HorizonREST.ApiClient.Disconnect(AuthContainer.Instance.LastAuthResponse.refresh_token);
    }
}