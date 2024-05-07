namespace ApartmentManagement.Core.Utils;

public class BusinessRuleException : Exception
{
    public List<string> Codes { get; set; }

    public BusinessRuleException(List<string> codes)
    {
        Codes = codes;
    }
}