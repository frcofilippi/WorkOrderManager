using ErrorOr;

using MediatR;

using WorkOrderManager.Domain.Clients;

namespace WorkOrderManager.Application.Clients.Commands;
public record CreateClientCommand : IRequest<ErrorOr<Client>>
{
        public CreateClientCommand(string firstName, string lastName, string password, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Email = email;
        }

        public string FirstName { get; }

        public string LastName { get; }

        public string Password { get; }

        public string Email { get; }
}
