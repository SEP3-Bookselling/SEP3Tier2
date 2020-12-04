﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tier2.Data;
using Tier2.Models;
using Tier2.Models.BookSale;
using Tier2.Network;

namespace Tier2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : Controller
    {
        private ISaleService saleService;

        public SalesController(ISaleService saleService)
        {
            this.saleService = saleService;
        }

/*      [HttpGet]
        //<-- Remember to add something like public async Task<ActionResult<User>> ValidateUser([FromQuery] string UserName, string Password) to get a specific BookSale
        public async Task<ActionResult<string>> GetBookSale()
        {
            try
            {
                string bookSale = await _network.GetSaleAsync();
                return Ok(bookSale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<string>> GetAllBookSales()
        {            
            Console.WriteLine("TESTController");
            try
            {
                string bookSales = await _network.GetBookSaleAsync();
                Console.WriteLine("Test: " + bookSales);

                return Ok(bookSales);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
*/
        [HttpGet]
        public async Task<ActionResult<IList<BookSale>>> GetAllBookSalesAsync([FromQuery] string username)
        {
            
            // Console.WriteLine("Test controller tier2???1: ");
            try
            {
                IList<BookSale> bookSales = await saleService.GetBookSaleAsync(username);
                for (int i = 0; i < bookSales.Count; i++)
                {
                    Console.WriteLine(bookSales[i].bookSaleID);
                }
                return Ok(bookSales);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
                // TODO Add more exceptions? 404?
            }
        }


        [HttpPost]
        public async Task<ActionResult<BookSale>> CreateBookSaleAsync([FromBody] BookSale bookSale)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }
            try
            {
                BookSale addedBookSale = await saleService.CreateBookSaleAsync(bookSale);
                Console.WriteLine("IM IN THE HOLE CONTROLLER");
                return Created($"/{addedBookSale.title}",addedBookSale);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
           
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> DeleteBookSale([FromRoute] int id) {
            try {
                await saleService.RemoveSaleAsync(id);
                return Ok();
            }
            catch (Exception e) {
                Console.WriteLine(e);
                return StatusCode(500, e.Message);
            }
        }
    }
}