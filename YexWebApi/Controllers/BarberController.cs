using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using YexWebApi.Data;
using YexWebApi.Models.Barber;
using YexWebApi.Models.Barber.DAO;
using YexWebApi.Services.BarberServices;

namespace YexWebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BarberController : ControllerBase
    {
        private readonly IBarberServices _barberServices;

        public BarberController(IBarberServices barberServices) {
            _barberServices = barberServices;
        }

        [HttpGet]
        [Route("GetAllBarbers")]
        public async Task<IActionResult> GetBarbers([FromServices] AppDbContext context, [FromQuery] int skip = 0, [FromQuery] int take = 10)
        {
            if(take > 30)
            {
                return BadRequest();
            }
            
            List<Barber> barbers = await _barberServices.findAllAsync(skip, take);
            return Ok(barbers);
        }

        [HttpGet]
        [Route("GetBarber/{id}")]
        public async Task<IActionResult> GetById([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var barber = await _barberServices.findById(id);
            return barber == null ? NotFound() : Ok(barber);
        }


        [HttpPost]
        public async Task<IActionResult> CreateBarber([FromServices] AppDbContext context, BarberModel model)
        {   
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
        
            try
            {
                var barber = await _barberServices.create(model);
                return Created($"api/v1/barbers/{barber.Id}", barber);

            } catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut]
        [Route("Barber/{id}")]
        public async Task<IActionResult> UpdateBarber([FromServices] AppDbContext context, [FromRoute] int id, [FromBody] BarberModel model)
        {                 
            try
            {
                Barber barber = await _barberServices.update(id, model);
                if(barber == null)
                {
                    return NotFound();
                }

                return Ok(barber);

            }catch(Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete]
        [Route("Barber/{id}")]
        public async Task<IActionResult> DeleteBarber([FromServices] AppDbContext context, [FromRoute] int id)
        {
            var barber = await _barberServices.delete(id);

            if (barber == false)
            {
                return NotFound();
            }

            try
            {
                context.Remove(barber);
                await context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
