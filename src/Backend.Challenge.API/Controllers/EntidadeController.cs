using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.API.Controllers
{
    [Route("api/[controller]")]
    public class EntidadeController : ControllerBase
    {

        [HttpGet]
        public Task ObterTodas([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 1)
        {
            //chama application service

            return Task.CompletedTask;
        }
    }
}
