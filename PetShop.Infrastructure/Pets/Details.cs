using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Pets
{
    public class Details
    {
        public class Query : IRequest<Pet>
        {
            public int id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Pet>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<Pet> Handle(Query request, CancellationToken cancellationToken)
            {
                return await unitOfWork.Pets.GetByIdAsync(request.id);
            }
        }

    }
}