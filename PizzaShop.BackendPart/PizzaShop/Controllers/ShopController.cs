using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Controllers.Base;
using PizzaShop.Models;
using ShopApplication.Orders.Commands.CreateOrder;
using ShopApplication.Orders.Commands.DeleteOrder;
using ShopApplication.Orders.Commands.UpdateOrder;
using ShopApplication.Orders.Queries.GetOrderDetails;
using ShopApplication.Orders.Queries.GetOrderList;

namespace PizzaShop.Controllers
{
    //[ApiVersion("1.0")]//we can add 2.0/3.0 etc one for another
    [ApiVersionNeutral]//guarantee that controller will be called even if ApiVersion isn't suitable
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ShopController:BaseController
    {
        private readonly IMapper _mapper;

        public ShopController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of orders
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET / order
        /// </remarks>
        /// <returns> Returns OrderListViewModel</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderListViewModel>> GetAll()
        {
            var query = new GetOrderListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET / order / 027AD4D4-008E-41D7-BB20-7EE994A51276
        /// <param name="id">Order Id(guid)</param>
        /// </remarks>
        /// <returns> Returns OrderListViewModel</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<OrderListViewModel>> Get(Guid id)
        {
            var query = new GetOrderDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /order
        /// {
        ///     title: "order title",
        ///     details: "not details"
        /// }
        /// </remarks>
        /// <param name="createOrderDTO">Create createOrderDTO object</param>
        /// <returns>Returns id(guid)</returns>
        /// /// <response code="201">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDTO createOrderDTO)
        {
            var command = _mapper.Map<CreateOrderCommand>(createOrderDTO);
            command.UserId = UserId;
            var noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        /// <summary>
        /// Update the order
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /order
        /// {
        ///     title: "updated order title",
        ///     details: "not details"
        /// }
        /// </remarks>
        /// <param name="createOrderDTO">Update createOrderDTO object</param>
        /// <returns>Returns NoContent</returns>
        /// /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDTO updateOrderDTO)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateOrderDTO);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Delete the order by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /order/A77490DF-6288-45C6-ADED-C75F575A7CB4
        /// </remarks>
        /// <param name="id">Id of the order (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// /// <response code="204">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteOrderCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
