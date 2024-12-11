namespace ReboteqTask.Application.Bases;

public class ResponseHandler
{
    public ResponseHandler() { }

    public Response<T> Delete<T>(string message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.OK,
            Succedded = true,
            Message = message ?? "Deleted Successfully"
        };
    }

    public Response<T> Success<T>(T entity, string message = null, object meta = null)
    {
        return new Response<T>
        {
            Data = entity,
            StatusCode = HttpStatusCode.OK,
            Succedded = true,
            Message = message ?? "Success",
            Meta = meta
        };
    }

    public Response<T> Success<T>(string message = null, object meta = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.OK,
            Succedded = true,
            Message = message ?? "Success",
            Meta = meta
        };
    }

    public Response<T> UnAuthorized<T>()
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.Unauthorized,
            Succedded = false,
            Message = "UnAuthorized"
        };
    }

    public Response<T> BadRequest<T>(string message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.BadRequest,
            Succedded = false,
            Message = message ?? "Bad request"
        };
    }

    public Response<T> UnprocessableEntity<T>(string message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.UnprocessableEntity,
            Succedded = false,
            Message = message ?? "Can't complete this process"
        };
    }

    public Response<T> NotFound<T>(string message = null)
    {
        return new Response<T>
        {
            StatusCode = HttpStatusCode.NotFound,
            Succedded = false,
            Message = message ?? "Not Found"
        };
    }

    public Response<T> Created<T>(T entity, string? message = null, object meta = null)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

        return new Response<T>
        {
            Meta = meta,
            Succedded = true,
            StatusCode = HttpStatusCode.Created,
            Message = message ?? "Created",
            Data = entity
        };
    }
}