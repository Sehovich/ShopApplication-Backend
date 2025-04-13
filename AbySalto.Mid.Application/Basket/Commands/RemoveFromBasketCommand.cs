using MediatR;
using System;

namespace AbySalto.Mid.Application.BasketItems.Commands
{
    public class RemoveFromBasketCommand : IRequest
    {
        public Guid UserId { get; set; }
        public int ProductId { get; set; }
    }
}
