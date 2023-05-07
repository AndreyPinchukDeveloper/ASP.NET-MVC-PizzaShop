﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApplication.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand:IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Deatils { get; set; }
    }
}