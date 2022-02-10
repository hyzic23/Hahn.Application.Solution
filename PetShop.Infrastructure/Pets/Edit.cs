using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Pets
{
    public class Edit
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
                var pet = await unitOfWork.Pets.GetByIdAsync(request.Pet.Id);

                pet.PetName = request.Pet.PetName ?? pet.PetName;
                pet.PetType = request.Pet.PetType ?? pet.PetType;
                await unitOfWork.Pets.UpdateAsync(pet);
                //await unitOfWork.Pets.UpdateAsync(request.Pet);
                return Unit.Value;
            }
        }
    }
}