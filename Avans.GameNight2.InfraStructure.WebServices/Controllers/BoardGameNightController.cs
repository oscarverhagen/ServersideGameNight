using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Avans.GameNight.InfraStructure.WebServices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardGameNightController : ControllerBase
    {
        private readonly IBoardGameNightRepository _BoardGameNightRepo;
        private readonly IBoardGameNightPlayerRepository _BoardGameNightPlayerRepo;
        private readonly IPlayerRepository _PlayerRepo;
        private readonly IBoardGameNightBoardGameRepository _BoardGameNightBoardGameRepo;
        private readonly IBoardGameRepository _BoardGameRepo;

        public BoardGameNightController()
        {
           
        }
    }
}
