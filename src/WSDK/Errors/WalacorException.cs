using System;
using System.Net;

namespace WSDK.Errors;

/// <summary>
/// Represents an error returned by the Walacor service.
/// </summary>
public class WalacorException : Exception
{
    public HttpStatusCode StatusCode { get; }
    public string? Code { get; }
    public string? RequestId { get; }
    public string? BodyPreview { get; }

    public WalacorException(
        HttpStatusCode statusCode,
        string? code,
        string? message,
        string? requestId,
        string? bodyPreview,
        Exception? innerException = null) : base(message, innerException)
    {
        StatusCode = statusCode;
        Code = code;
        RequestId = requestId;
        BodyPreview = bodyPreview;
    }
}
