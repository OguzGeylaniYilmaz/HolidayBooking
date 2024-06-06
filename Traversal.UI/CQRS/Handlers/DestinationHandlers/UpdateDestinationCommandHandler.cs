using DataAccessLayer.Concrete;
using Traversal.UI.CQRS.Commands.DestinationCommands;

namespace Traversal.UI.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
           
            var editedId = _context.Destinations.Find(command.DestinationID);
            editedId.City = command.City;
            editedId.DayNight = command.DayNight;
            editedId.Price = command.Price;
            _context.SaveChanges(); 
        }
    }
}
