using Grocery.Models.Dto.CustomerDto;
using Grocery.Service.CustomerServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var data = _customerService.Get();
                if (data == null || data.Count == 0)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to get all customers");
            }

        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var data = _customerService.Get(id);
                if (data == null)
                    return NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest($"Unable to get customer # {id}");
            }

        }
        
        [HttpPost]
        public IActionResult Create(CreateCustomerDto dto)
        {
            try
            {
                var data = _customerService.create(dto);
                if (data == null)
                    return BadRequest("Unable to create customer");
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to create customer");
            }
        }
        [HttpPut]
        public IActionResult Update(UpdateCustomerDto dto)
        {
            try
            {
                var data = _customerService.update(dto);
                if (data == null)
                    NotFound();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest("Unable to update customer");
            }
        }
    }
}
