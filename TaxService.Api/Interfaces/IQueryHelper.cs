namespace TaxService.Api.Interfaces
{
    public interface IQueryHelper
    {
        string AppendObjectToQueryString(string uri, object requestObject);
    }
}