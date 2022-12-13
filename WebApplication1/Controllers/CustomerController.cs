using System.Net;
using Application.Customer;
using Application.Customer.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace backend_interview_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly IMediator _mediator;


        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Result<CustomerResultDto>>> Create([FromBody] CustomerRequestDto customer)
        {
            try
            {
                return new Result<CustomerResultDto>
                {
                    IsSuccess = true,
                    Data = await _mediator.Send(new Create.Command
                    {
                        Customer = customer
                    }),
                    Message = "Success",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new Result<CustomerResultDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Failure : {e.InnerException}",
                    Status = HttpStatusCode.NotAcceptable
                };
            }
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<CustomerResultDto>>>> List()
        {
            try
            {
                return new Result<List<CustomerResultDto>>
                {
                    IsSuccess = true,
                    Data = await _mediator.Send(new List.Query()),
                    Message = "Success",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new Result<List<CustomerResultDto>>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Failure : {e.Message}",
                    Status = HttpStatusCode.NotAcceptable
                };
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<CustomerResultDto>>> Detail(int id)
        {
            try
            {
                return new Result<CustomerResultDto>
                {
                    IsSuccess = true,
                    Data = await _mediator.Send(new Detail.Query()
                    {
                        Id = id
                    }),
                    Message = "Success",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new Result<CustomerResultDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Failure : {e.Message}",
                    Status = HttpStatusCode.NotAcceptable
                };
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<CustomerResultDto>>> Edit(int id, [FromBody] CustomerRequestDto customerDto)
        {
            try
            {
                return new Result<CustomerResultDto>
                {
                    IsSuccess = true,
                    Data = await _mediator.Send(new Edit.Command
                    {
                        Id = id,
                        CustomerDto = customerDto
                    }),
                    Message = "Success",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new Result<CustomerResultDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = $"Failure : {e.Message}",
                    Status = HttpStatusCode.NotAcceptable
                };
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Result> Delete(int id)
        {
            try
            {
                return new Result
                {
                    IsSuccess = true,
                    Message = "Success",
                    Status = HttpStatusCode.OK
                };
            }
            catch (Exception e)
            {
                return new Result
                {
                    IsSuccess = false,
                    Message = $"Failure : {e.Message}",
                    Status = HttpStatusCode.NotAcceptable
                };
            }
        }
    }
}
