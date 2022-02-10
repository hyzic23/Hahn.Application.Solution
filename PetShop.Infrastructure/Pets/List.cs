using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;

namespace PetShop.Infrastructure.Pets
{
    public class List
    {
        public class Query : IRequest<List<Pet>>{}

        public class Handler : IRequestHandler<Query, List<Pet>>
        {
            private readonly IUnitOfWork unitOfWork;

            public Handler(IUnitOfWork unitOfWork)
            {
                this.unitOfWork = unitOfWork;
            }

            public async Task<List<Pet>> Handle(Query request, CancellationToken cancellationToken)
            //public async Task<IEnumerable<Pet>> Handle(Query request, CancellationToken cancellationToken)
            {
                //return (List<Pet>)(IReadOnlyList<Pet>)unitOfWork.Pets.GetAllAsync();
                IEnumerable<Pet> petList = await unitOfWork.Pets.GetAllAsync();
                return (List<Pet>)petList;
            }

            
        }
    }
}