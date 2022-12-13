using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Customer.Dtos;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Customer
{
    public class Edit
    {
        public class Command : IRequest<CustomerResultDto>
        {
            public int Id { get; set; }
            public CustomerRequestDto CustomerDto { get; set; }
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
                var customer = await _context.Customers
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);


                _mapper.Map(request.CustomerDto, customer);

                var result = await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<CustomerResultDto>(customer);
            }
        }
    }
}
