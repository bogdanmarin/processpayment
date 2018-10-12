using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GC.ProcessPayment.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GC.ProcessPayment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessPaymentController : ControllerBase
    {

        // POST api/processpayment
        [HttpPost]
        public void Post([FromBody] Payment value)
        {
        }

    }
}
