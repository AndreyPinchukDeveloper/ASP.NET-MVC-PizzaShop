using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PizzaShop.Controllers.Base;
using PizzaShop.Models;
using ShopApplication.Orders.Commands.DeleteOrder;
using ShopApplication.Orders.Commands.UpdateOrder;
using ShopApplication.Orders.Queries.GetOrderDetails;
using ShopApplication.Orders.Queries.GetOrderList;

namespace PizzaShop.Controllers
{
    [Route("api/{version:apiVersion}/[controller]")]
    public class ShopController:BaseController
    {
        private readonly IMapper _mapper;

        public ShopController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<OrderListViewModel>> GetAll()
        {
            var query = new GetOrderListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        [Authorize]
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

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDTO)
        {
            var query = new GetOrderDetailsQuery
            {
                UserId = UserId,
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Update([FromBody] UpdateOrderDTO updateOrderDTO)
        {
            var command = _mapper.Map<UpdateOrderCommand>(updateOrderDTO);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
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
