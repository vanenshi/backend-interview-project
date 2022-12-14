using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Customer.Dtos;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence;

namespace Application.Customer
{
    public class Delete
    {
        public class Command : IRequest<Unit>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                _context.Customers.Remove(customer);

                var result = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
