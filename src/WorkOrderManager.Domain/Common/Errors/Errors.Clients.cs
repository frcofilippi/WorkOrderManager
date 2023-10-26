
namespace WorkOrderManager.Domain.Common.Errors;

using ErrorOr;
public static partial class Errors
{
    public static partial class Clients
    {
        public static Error UserDoesNotExists => Error.Validation(
            nameof(UserDoesNotExists),
            "The user you specified in the request does not exist on the system.");

        public static Error RequesterAndClientDoesNotMatch => Error.Unauthorized(
            nameof(RequesterAndClientDoesNotMatch),
            "UserId could not be parsed from the request.");
    }
}