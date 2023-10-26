using ErrorOr;

namespace WorkOrderManager.Domain.Common.Errors;

public static partial class Errors 
{
    public static partial class Orders
    {
       public static Error OrderNotFound => Error.NotFound(
           nameof(OrderNotFound),
           "The provided ID does not match with any order in the system");
    }
}