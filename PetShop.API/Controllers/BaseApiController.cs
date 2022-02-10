using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace PetShop.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BaseApiController : ControllerBase
    {
        //private readonly IMapper mapper;
        private IMediator _mediator;

        // public BaseApiController(IMediator mediator, IMapper mapper)
        // {
        //     _mediator = mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        //     this.mapper = mapper;
        // }

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}