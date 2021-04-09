using Capstone.DAO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingsDAO ratingsDAO;

        public RatingsController(IRatingsDAO _ratingsDAO)
        {
            ratingsDAO = _ratingsDAO;
        }
    }
 
}
