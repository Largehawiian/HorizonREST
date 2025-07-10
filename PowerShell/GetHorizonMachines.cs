using System.Management.Automation;

namespace HorizonREST.PowerShell;

[Cmdlet(VerbsCommon.Get, "HorizonMachines")]

public sealed class GetHorizonMachinesCommand : PSCmdlet
{
    protected override void ProcessRecord()
    {
        var result = Classes.HorizonREST.ApiClient.GetMachines().GetAwaiter().GetResult();
        WriteObject(result);
    }
}