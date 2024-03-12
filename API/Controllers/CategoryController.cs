using API.Common;
using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Commands.UpdateCategory;
using Application.Features.Categories.Query.GetCategoryById;
using Application.Features.Categories.Query.GetPaginatedCategories;
using Application.Features.Categories.ViewModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost(Name = "CreateCategory")]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            var categoryId = await _mediator.Send(createCategoryCommand);

            var uri = Url.Action("GetCategoryById", new { Id = categoryId });
            var absoluteUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}{uri}";

            return Created(absoluteUri, new DefaultResponse { Success = true, Message = "New category successfully created" });
        }

        [HttpPut("{id}", Name = "UpdateCategory")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult> UpdateCategory(int id, [FromBody] UpdateCategoryCommand updateCategoryCommand)
        {
            updateCategoryCommand.Id = id;

            await _mediator.Send(updateCategoryCommand);

            return Ok(new DefaultResponse { Success = true, Message = "Category updated succesfully" });
        }

        [HttpGet("{id}", Name = "GetCategoryById")]
        [ProducesResponseType(typeof(CategoryViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<CategoryViewModel>> GetCategoryById(int id)
        {
            var getCategoryByIdCommand = new GetCategoryByIdCommand { Id = id };

            var result = await _mediator.Send(getCategoryByIdCommand);

            return Ok(result);
        }

        [HttpGet(Name = "GetCategories")]
        [ProducesResponseType(typeof(IEnumerable<CategoryViewModel>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CategoryViewModel>>> GetCategories([FromQuery] GetPaginatedCategoriesQuery getPaginatedCategoriesQuery)
        {
            var results = await _mediator.Send(getPaginatedCategoriesQuery);

            return Ok(results);
        }

    }
}
