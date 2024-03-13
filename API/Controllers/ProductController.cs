using API.Common;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.UpdateProduct;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost(Name = "CreateProduct")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand createProductCommand)
        {
            var result = await _mediator.Send(createProductCommand);

            return Created("", new DefaultResponse { Success = true, Message = "New product successfully created" });
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> CreateProduct(int id, [FromBody] UpdateProductCommand updateProductCommand)
        {
            updateProductCommand.Id = id;

            await _mediator.Send(updateProductCommand);

            return Ok(new DefaultResponse { Success = true, Message = "Product successfully updated" });
        }
    }
}
