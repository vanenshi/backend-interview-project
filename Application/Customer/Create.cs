using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Customer.Dtos;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Customer
{
    public class Create
    {
        public class Command : IRequest<CustomerResultDto>
        {
            public CustomerRequestDto Customer { get; set; }
        }
        public class Handler : IRequestHandler<Command, CustomerResultDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CustomerResultDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var customer = _mapper.Map<Domain.Customer>(request.Customer);

                await _context.Customers.AddAsync(customer, cancellationToken);

                var result = await _context.SaveChangesAsync(cancellationToken);

                return _mapper.Map<CustomerResultDto>(customer);
            }
        }
    }
}
