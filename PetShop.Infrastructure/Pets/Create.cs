using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Pets
{
    public class Create
    {
        public class Command : IRequest
        {
            public Pet Pet { get; set;}
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                await unitOfWork.Pets.AddAsync(request.Pet);
                //await unitOfWork.SaveAsync();
                return Unit.Value;
            }
        }


    }
}