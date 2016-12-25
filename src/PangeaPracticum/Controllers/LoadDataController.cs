using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PangeaPracticum.lib.Messaging;
using PangeaPracticum.lib.Messaging.Messages;

namespace PangeaPracticum.Controllers
{
    [Route("[controller]")]
    public class LoadDataController : Controller
    {
        private IBusPublisher _publisher;

        public LoadDataController(IBusPublisher publisher)
        {
            _publisher = publisher;
        }

        [HttpGet]
        public void Get()
        {
            _publisher.Publish(new LoadDataRequest());    
        }
    }
}
