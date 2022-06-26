using CirclePlayAPI.Member;
using CirclePlayAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CirclePlayAPI.Controllers
{
    [Route("api/[Controller]")]
    public class PlayersController : ControllerBase
    {
        private List<Player> _players = GroupMember.GetPlayers(10);

        //[HttpGet]
        //public List<Player> Get()
        //{
        //    return _players;
        //}

        [HttpGet("{id}")]
        public Player Get(int id)
        {
            var player = _players.FirstOrDefault(x => x.Id == id);
            return player;
        }

        [HttpGet]
        public List<Player> Get([FromBody] Player winnerPlayer)
        {
            //loserPlayers have BallOwner "xx"
            for (int i = 0; i < _players.Count(); i++)
            {
                _players[i + 2].BallOwner = "xx";
            }

            var winnerPlayer = _players.FirstOrDefault(x => x.BallOwner != "xx");
            return winnerPlayer;
        }

        [HttpPut]
        public Player Put([FromBody] Player player)
        {
            for (int i = 0; i < _players.Count(); i++)
            {
                _players[i + 2].BallOwner = "xx";
            }

            return player;

        }
    }
}
