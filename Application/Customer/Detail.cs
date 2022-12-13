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
    public class Detail
    {
        public class Query : IRequest<CustomerResultDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, CustomerResultDto>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CustomerResultDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var customer = await _context.Customers
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                var customerOut = _mapper.Map<CustomerResultDto>(customer);
                return customerOut;
            }
        }
    }
}
