﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC.ProcessPayment.Api.Common;
using GC.ProcessPayment.Api.Entities;
using GC.ProcessPayment.Api.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GC.ProcessPayment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ValidateModel]
    public class PaymentsController : ControllerBase
    {
        private IBankingSystem _bankingSystem;

        public PaymentsController(IBankingSystem bankingSystem)
        {
            _bankingSystem = bankingSystem;
        }
        // POST api/paymments
        [HttpPost]
        public IActionResult Post([FromBody] Payment value)
        {
            return Ok(_bankingSystem.Process(value));
        }
    }
}
