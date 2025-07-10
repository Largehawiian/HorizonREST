using HorizonREST.Classes;
using System.Management.Automation;

namespace HorizonREST.PowerShell;

[Cmdlet(VerbsData.Update, "HorizonToken")]

public sealed class RefreshTokenCommand : PSCmdlet
{
    protected override void ProcessRecord()
    {
        Classes.HorizonREST.ApiClient.RefreshToken(AuthContainer.Instance.LastAuthResponse.HorizonServer, AuthContainer.Instance.LastAuthResponse.access_token);
    }
}