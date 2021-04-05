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

    public class BreweriesController : ControllerBase
    {
        private readonly IBreweriesDAO breweriesDAO;

        public BreweriesController(IBreweriesDAO _breweriesDAO)
        {
            breweriesDAO = _breweriesDAO;
        }
    }


}

