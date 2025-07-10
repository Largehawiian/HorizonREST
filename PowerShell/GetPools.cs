using System.Management.Automation;

namespace HorizonREST.PowerShell;

[Cmdlet(VerbsCommon.Get, "HorizonPools")]

public sealed class GetHorizonPoolsCommand : PSCmdlet
{
    protected override void ProcessRecord()
    {
        var result = Classes.HorizonREST.ApiClient.GetPools().GetAwaiter().GetResult();
        WriteObject(result);
    }
}
