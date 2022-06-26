using Bogus;
using CirclePlayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CirclePlayAPI.Member
{
    public static class GroupMember
    {
        private static List<Player> _players;
        public static List<Player> GetPlayers(int number)
        {
            if (_players == null)
            {


                _players = new Faker<Player>()
                    .RuleFor(p => p.Id, f => f.IndexFaker + 1)
                    .RuleFor(p => p.Index, f => f.IndexFaker)
                    .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                    .RuleFor(p => p.LastName, f => f.Name.LastName())
                    .RuleFor(p => p.BallOwner, f => f.Name.FirstName())
                    .Generate(number);
            }
            return _players;
        }
    }
}
