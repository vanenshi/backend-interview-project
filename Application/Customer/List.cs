using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Customer.Dtos;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Customer
{
    public class List
    {
        public class Query : IRequest<List<CustomerResultDto>>
        {

        }

        public class Handler : IRequestHandler<Query, List<CustomerResultDto>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<CustomerResultDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var customers = await _context.Customers
                    .AsNoTracking()
                    .ProjectTo<CustomerResultDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return customers;
            }
        }
    }
}
