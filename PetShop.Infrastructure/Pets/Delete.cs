using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Pets
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id { get; set;}
            //public Pet Pet { get; set;}
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
                //var pet = await unitOfWork.Pets.GetByIdAsync(request.Id);
                
                await unitOfWork.Pets.DeleteAsync(request.Id);
                return Unit.Value;
            }
        }



    }
}