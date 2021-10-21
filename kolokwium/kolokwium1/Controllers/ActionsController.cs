using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using kolokwium1.DTO;
using kolokwium1.Models;
using Microsoft.EntityFrameworkCore;
using Action = kolokwium1.Models.Action;

namespace kolokwium1.Controllers
{
    [ApiController]
    [Route("/api/actions")]
    public class ActionsController : ControllerBase
    {
        private readonly s20613Context _context;
        public ActionsController ( s20613Context context )
        {
            _context = context;
        }

        [HttpGet( "{idStrazak}" )]
        public async Task<IActionResult> GetActions ( int idStrazak )
        {
            var result = await _context.Firefighters.ToListAsync();

            if ( result.Count != 0 )
            {
                var strazak = ( from f in _context.Firefighters
                                join fa in _context.FirefighterActions on f.IdFirefighter equals fa.IdFirefighter
                                join a in _context.Actions on fa.IdAction equals a.IdAction
                                where f.IdFirefighter.Equals( idStrazak )
                                select new FirefighterDTO { IdFirefighter = f.IdFirefighter, IdAction = a.IdAction, EndTime = a.EndTime, StartTime = a.StartTime } ).ToList()
                    .OrderByDescending( e => e.EndTime );


                return Ok( strazak );
            }

            return NotFound( "Firefighter not found in database" );
        }

        //[HttpPost]
        //public async Task<IActionResult> AddAction(int idAction, int idWozu)
        //{
        //    var action = await _context.Actions.ToListAsync();
        //    var woz = await _context.FiretruckActions.ToListAsync();
        //    var akcje = await _context.Actions.ToListAsync();

        //    var uzywany = woz.Any(e => e.IdFiretruck == idWozu);

        //    if (uzywany)
        //    {
        //        return BadRequest($"Woz o id {idWozu} jest juz uzywany");
        //    }

        //    var akcja = akcje.Any(e => e.IdAction == idAction);
        //    if (!akcja)
        //    {
        //        return BadRequest("Akcja nie istnieje");
        //    }

        //    //var newAkcja = new Action()
        //    //{
        //    //    IdAction = idAction,
        //    //    EndTime = 
        //    //};

        //    return Ok("");
        //}

    }
}
