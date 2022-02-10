using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Interfaces;
using PetShop.Core.Models;
using PetShop.Infrastructure.Dtos;
using PetShop.Infrastructure.Pets;

namespace PetShop.API.Controllers
{
    
    public class PetController : BaseApiController
    {
        // private readonly IUnitOfWork unitOfWork;
        // private readonly IMediator mediator;
        private readonly IMapper mapper;

        // public PetController(IUnitOfWork unitOfWork, 
        //                     IMediator mediator, 
        //                     IMapper mapper)
        // {
        //     this.unitOfWork = unitOfWork;
        //     this.mediator = mediator;
        //     this.mapper = mapper;
        // }

        public PetController(IMapper mapper)
        {
            this.mapper = mapper;
        }


        [HttpGet]
        [Route("GetAllPets")]
        public async Task<IActionResult> GetAll()
        {
            var pets = await Mediator.Send(new List.Query());
            //SendAsync(new List.Query());
            //var petDtos = mapper.Map<IEnumerable<PetDto>>(pets);
            return Ok (pets);
        }

        [HttpGet]
        [Route("GetPetById/{id}")]
        public async Task<ActionResult<Pet>> GetById(int id)
        {
            //var data = await unitOfWork.Pets.GetByIdAsync(id);
            //if (data == null) return Ok();
            return await Mediator.Send(new Details.Query{id = id});
        }

        [HttpPost]
        [Route("AddPet")]
        //public async Task<IActionResult> Add(PetDto petDto)
        public async Task<IActionResult> Add(PetDto petDto)
        {
            var pet = mapper.Map<Pet>(petDto);
            //var data = await unitOfWork.Pets.AddAsync(pet);
            return Ok(await Mediator.Send(new Create.Command {Pet = pet}));
        }

        [HttpDelete]
        [Route("DeletePet/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var data = await unitOfWork.Pets.DeleteAsync(id);
            //return Ok(data);
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }

        [HttpPut]
        [Route("UpdatePet")]
        public async Task<IActionResult> Update(Pet pet)
        {
            //var data = await unitOfWork.Pets.UpdateAsync(pet);
            return Ok(await Mediator.Send(new Edit.Command{Pet = pet}));
            //return Ok(data);
        }
    



    }
}