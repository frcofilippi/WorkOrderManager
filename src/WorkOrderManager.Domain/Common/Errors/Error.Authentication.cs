
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
    }
}