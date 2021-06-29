namespace TaxService.Interfaces
{
    public interface IQueryHelper
    {
        string AppendObjectToQueryString(string uri, object requestObject);
    }
}