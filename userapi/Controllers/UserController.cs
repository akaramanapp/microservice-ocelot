using Microsoft.AspNetCore.Mvc;

namespace userapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IEventBus _eventBus;
        public UserController(IEventBus evantBus){
            _eventBus = evantBus;
        }
        // POST api/user
        [HttpPost]
        public void Post([FromBody] string email)
        {
            // TODO: Bu kısımda user kayıt işlemleri yapılacak

            //User kayıt işleminden sonra MQTT event tetikleniyor.
            _eventBus.SendEmailEvent(email);
        }
    }
}
