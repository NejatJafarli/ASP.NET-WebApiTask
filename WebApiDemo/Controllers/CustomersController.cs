using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDemo.DataAccess;
using WebApiDemo.Entities;

namespace WebApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerDal _efCustomerDal;

        public CustomersController(ICustomerDal iCustomerEf)
        {
            _efCustomerDal = iCustomerEf;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var customers = _efCustomerDal.GetList();
            return Ok(customers);
        }
        [HttpGet("{customerId}")]
        public IActionResult GetById(string customerId)
        {
            try
            {
                var customer = _efCustomerDal.Get(p => p.CustomerId == customerId);
                if (customer == null)
                    return NotFound($"There is no customer with this ID : {customerId}");
                return Ok(customer);
            }
            catch (Exception ex) { }
            return BadRequest();
        }

        [HttpPost("")]
        public IActionResult Post(Customer customer)
        {
            try
            {
                _efCustomerDal.Add(customer);
                return new StatusCodeResult(201);
            }
            catch (Exception ex) { }
            return BadRequest();
        }

        [HttpPut("")]
        public IActionResult Put(Customer customer)
        {
            try
            {
                _efCustomerDal.Update(customer);
                return Ok();
            }
            catch (Exception ex) { }
            return BadRequest();
        }

        [HttpDelete("{customerId}")]
        public IActionResult Delete(string customerId)
        {
            try
            {
                var customer = _efCustomerDal.Get(p => p.CustomerId == customerId);
                if (customer == null)
                    return NotFound($"There is no customer with this ID : {customerId}");
                _efCustomerDal.Delete(customer);
                return Ok();
            }
            catch (Exception ex) { }
            return BadRequest();
        }


        [HttpPost("Order/{customerId}")]
        public IActionResult Order(string customerId)
        {
            try
            {
                var customerOrders = _efCustomerDal.GetCustomerOrders(customerId);

                if (customerOrders == null)
                    return NotFound($"There is no customer with this ID : {customerId}");
                return Ok(customerOrders);
            }
            catch (Exception ex) { }
            return BadRequest();

        }
    }
}
