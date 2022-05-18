using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using WebApplication7.Data;
using WebApplication7.Entities.Dto;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JugadoresController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public JugadoresController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetJugadores")]
        public async Task<ActionResult<IEnumerable<Jugador>>> GetJugadores()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del los jugadores";
                response.Data = await _context.Jugadores.ToListAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


        [HttpGet]
        [Route("GetJugador/{id}")]
        public async Task<ActionResult<Jugador>> GetJugador(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del jugador";
                response.Data = await _context.Jugadores.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Jugador no encontrado";
                    return NotFound(response);
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


        [HttpPost]
        [Route("PostJugador")]
        public async Task<ActionResult<Jugador>> PostJugador(Jugador item)
        {

            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa del jugador";
                _context.Jugadores.Add(item);
                await _context.SaveChangesAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }


        [HttpPut]
        [Route("PutJugador/{id}")]
        public async Task<IActionResult> PutJugador(int id, Jugador item)
        {
            ResponseDto response = new ResponseDto();
            try
            {

                if (id != item.Id)
                {
                    throw new ArgumentException("id del jugador no coinciden");
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa del jugador";
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }

        [HttpDelete]
        [Route("DeleteJugador/{id}")]
        public async Task<IActionResult> DeleteJugador(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id del jugador no es valido");
                }

                Jugador jugador = await _context.Jugadores.FindAsync(id);
                if (jugador == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Jugador no encontrado";
                    return NotFound(response);
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito el jugador";
                _context.Jugadores.Remove(jugador);
                await _context.SaveChangesAsync();
                return Ok(response);
            }
            catch (Exception ex)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
                response.Message = ex.Message;
                return BadRequest(response);
            }
        }
    }
}
