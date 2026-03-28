
using ProblemDetails = Microsoft.AspNetCore.Mvc.ProblemDetails;
using Refit;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EducationPlatformMicroservice.Shared
{
    public class ServiceResult
    {
        [JsonIgnore] public HttpStatusCode Status { get; set; }

        public ProblemDetails? Fail { get; set; }

        [JsonIgnore] public bool IsSuccess => Fail is null;
        [JsonIgnore] public bool IsFail => !IsSuccess;

        //Static facroty methods
        public static ServiceResult SuccessAsNoContent()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NoContent
            };
        }

        public static ServiceResult ErrorAsNotFound()
        {
            return new ServiceResult
            {
                Status = HttpStatusCode.NotFound,
                Fail = new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = "The requested resource was not found.",
                }
            };
        }

        public static ServiceResult Error(ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult()
            {
                Fail = problemDetails,
                Status = statusCode
            };
        }

        public static ServiceResult Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult()
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Detail = description,
                    Title = title,
                    Status = statusCode.GetHashCode()
                }

            };
        }

        public static ServiceResult Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult()
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Status = statusCode.GetHashCode()
                }

            };
        }

        public static ServiceResult ErrorFromProblemDetails(ApiException exception)
        {


            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult()
                {
                    Fail = new ProblemDetails
                    {
                        Title = exception.Message
                    },
                    Status = exception.StatusCode
                };
            }

            var problemDetails = JsonSerializer.Deserialize<ProblemDetails>(exception.Content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // büyük küçük harfe dikkat etme
                });

            return new ServiceResult()
            {
                Fail = problemDetails,
                Status = exception.StatusCode
            };



        }

        public static ServiceResult ErrorFromValidation(IDictionary<string, object> errors)
        {
            return new ServiceResult()
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Validation errors occured",
                    Detail = "Please check the errors property for more details.",
                    Extensions =
                    {
                        { "errors", errors }
                    },
                    Status = HttpStatusCode.BadRequest.GetHashCode()

                }

            };
        }


    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; set; }
        [JsonIgnore] public string? UrlAsCreated { get; set; }

        //200
        public static ServiceResult<T> SuccessAsOk(T data)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.OK,
                Data = data
            };
        }

        //201 => Created => Response body header => location = api/products/4
        // created olduğıunda response body headerında location bilgisi verilir. burada created edilen veriye nasıl erişileceğini gösterir.
        public static ServiceResult<T> SuccessAsCreated(T data, string url)
        {
            return new ServiceResult<T>
            {
                Status = HttpStatusCode.Created,
                Data = data,
                UrlAsCreated = url
            };
        }


        public new static ServiceResult<T> Error(ProblemDetails problemDetails, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>()
            {
                Fail = problemDetails,
                Status = statusCode
            };
        }

        public new static ServiceResult<T> Error(string title, string description, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>()
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Detail = description,
                    Title = title,
                    Status = statusCode.GetHashCode()
                }

            };
        }

        public new static ServiceResult<T> Error(string title, HttpStatusCode statusCode)
        {
            return new ServiceResult<T>()
            {
                Status = statusCode,
                Fail = new ProblemDetails()
                {
                    Title = title,
                    Status = statusCode.GetHashCode()
                }

            };
        }

        public new static ServiceResult<T> ErrorFromProblemDetails(ApiException exception)
        {


            if (string.IsNullOrEmpty(exception.Content))
            {
                return new ServiceResult<T>()
                {
                    Fail = new ProblemDetails
                    {
                        Title = exception.Message
                    },
                    Status = exception.StatusCode
                };
            }

            var problemDetails = JsonSerializer.Deserialize<Microsoft.AspNetCore.Mvc.ProblemDetails>(exception.Content,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // büyük küçük harfe dikkat etme
                });

            return new ServiceResult<T>()
            {
                Fail = problemDetails,
                Status = exception.StatusCode
            };



        }


        public new static ServiceResult<T> ErrorFromValidation(IDictionary<string, object> errors)
        {
            return new ServiceResult<T>()
            {
                Status = HttpStatusCode.BadRequest,
                Fail = new ProblemDetails()
                {
                    Title = "Validation errors occured",
                    Detail = "Please check the errors property for more details.",
                    Extensions =
                    {
                        { "errors", errors }
                    },
                    Status = HttpStatusCode.BadRequest.GetHashCode()

                }

            };
        }

    }

}
