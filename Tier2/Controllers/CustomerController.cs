﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tier2.Data;
using Tier2.Models.Users;

namespace Tier2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService) {
            this.customerService = customerService;
        }

        [HttpGet]
        public async Task<ActionResult<IList<Customer>>> GetSpecificCustomerAsync([FromQuery] string username) {
            try {
                IList<Customer> customer = await customerService.GetCustomerAsync(username);
                return Ok(customer);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Customer customerToAdd = await customerService.CreateCustomerAsync(customer);
                return Created($"/{customerToAdd.username}", customerToAdd);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }

        [HttpPatch]
        [Route("{username}")]
        public async Task<ActionResult<Customer>> UpdateCustomer([FromBody] Customer customer)
        {
            try
            {
                await customerService.UpdateCustomerAsync(customer);
                return Ok(customer);
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpDelete("{username}")]
        public async Task<ActionResult> DeleteCustomer([FromRoute]string username)
        {
            try
            {
                Console.WriteLine($"Customer is {username}");
                await customerService.DeleteCustomerAsync(username);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
        
    }
}