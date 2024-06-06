using DataAccessLayer.Concrete;
using Traversal.UI.CQRS.Commands.DestinationCommands;

namespace Traversal.UI.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
           var commandId = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(commandId);
            _context.SaveChanges();
        }
    }
}
