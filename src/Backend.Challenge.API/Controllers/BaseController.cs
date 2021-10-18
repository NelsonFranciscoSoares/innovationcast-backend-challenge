using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Challenge.API.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
      protected BaseController() { }
    }
}
