namespace ReboteqTask.Application.Bases;
public class Response<T>
{
    public HttpStatusCode StatusCode { get; set; }
    public bool Succedded { get; set; }
    public object Meta { get; set; }
    public string Message { get; set; }
    public Dictionary<string, string> Error { get; set; } = new();
    public T Data { get; set; }

    public Response() { }

    public Response(T data, string message = null)
    {
        Succedded = true;
        Data = data;
        Message = message ?? "Success";
    }

    public Response(string message)
    {
        Succedded = false;
        AddError("General", message);
    }

    public Response(string message, bool succedded)
    {
        Succedded = succedded;
        AddError("General", message);
    }

    public void AddError(string key, string value)
    {
        if (!Error.ContainsKey(key))
            Error[key] = value;
    }

    public void AddErrors(Dictionary<string, string> errors)
    {
        foreach (var error in errors)
        {
            AddError(error.Key, error.Value);
        }
    }
}

