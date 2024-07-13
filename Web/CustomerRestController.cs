using bank.Dto;
using bank.Service;
using Microsoft.AspNetCore.Mvc;

namespace bank.Web
{
    [ApiController]
    [Route("customers")]
    public class CustomerRestController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerRestController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get/{id}")]
        public ActionResult<CustomerDTO> GetCustomerById(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        [HttpGet("list")]
        public ActionResult<List<CustomerDTO>> GetAllCustomers()
        {
            var customers = _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("search/{keyword}")]
        public ActionResult<List<CustomerDTO>> SearchCustomers(string keyword)
        {
            var customers = _customerService.SearchCustomers(keyword);
            return Ok(customers);
        }

        [HttpPost("create")]
        public ActionResult<CustomerDTO> CreateCustomer([FromBody] CustomerDTO dto)
        {
            var createdCustomer = _customerService.CreateCustomer(dto);
            return CreatedAtAction(nameof(GetCustomerById), new { id = createdCustomer.Id }, createdCustomer);
        }

        [HttpPut("update/{id}")]
        public ActionResult<CustomerDTO> UpdateCustomer(string id, [FromBody] CustomerDTO dto)
        {
            var updatedCustomer = _customerService.UpdateCustomer(id, dto);
            if (updatedCustomer == null)
            {
                return NotFound();
            }
            return Ok(updatedCustomer);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteCustomerById(string id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            _customerService.DeleteCustomerById(id);
            return NoContent();
        }

        [HttpDelete("clear")]
        public IActionResult DeleteAllCustomers()
        {
            _customerService.DeleteAllCustomers();
            return NoContent();
        }
    }
}
