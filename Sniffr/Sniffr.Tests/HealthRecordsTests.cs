namespace Sniffr.Tests;
using sniffr;

public class HealthRecordTests
{
    HealthRecord healthRecord = new HealthRecord();

    Dictionary<string,int> medications;
    Dictionary<string, DateTime> medicationAdministered;
    
    [Fact]
    public void Test_ViewMedicationDue()
    {
        var stringWriter = new StringWriter();
        medications = new Dictionary<string, int>();
        medicationAdministered = new Dictionary<string, DateTime>();
        medications.Add("Apoquel", 1);
        medicationAdministered.Add("Apoquel", DateTime.Now);
        Console.SetOut(stringWriter);
        healthRecord.ViewMedicationDue(medications, medicationAdministered);
        var output = stringWriter.ToString();
        Assert.Equal($"Apoquel is due {DateTime.Now.AddDays(1).ToString("MM/dd/yyyy")}"+Environment.NewLine, output);
        
    }
}
