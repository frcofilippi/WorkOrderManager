
namespace WorkOrderManager.Domain.Common.Errors;

using ErrorOr;
public static partial class Errors
{
    public static partial class Authentication
    {
        public static Error UserAlreadyExist => Error.Validation(
            nameof(UserAlreadyExist),
            "Email already in use.");

        public static Error WrongLoginInformation => Error.Unauthorized(
        nameof(WrongLoginInformation),
        "Invalid credentials.");

        public static Error CouldNotParseUserFromRequest => Error.Unauthorized(
            nameof(CouldNotParseUserFromRequest),
            "UserId could not be parsed from the request.");
    }
}