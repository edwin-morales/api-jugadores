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
    public class EstadiosController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public EstadiosController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetEstadios")]
        public async Task<ActionResult<IEnumerable<Estadio>>> GetEstadios()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del estadio";
                response.Data = await _context.Estadios.ToListAsync();
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
        [Route("GetEstadio/{id}")]
        public async Task<ActionResult<Estadio>> GetEstadio(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del estadio";
                response.Data = await _context.Estadios.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Estadio no encontrado";
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
        [Route("PostEstadio")]
        public async Task<ActionResult<Estadio>> PostEstadio(Estadio item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa del estadio";
                _context.Estadios.Add(item);
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
        [Route("PutEstadio/{id}")]
        public async Task<IActionResult> PutEstadio(int id, Estadio item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id != item.Id)
                {
                    throw new ArgumentException("id del estadio no coincide");
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa del estadio";
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
        [Route("DeleteEstadio/{id}")]
        public async Task<IActionResult> DeleteEstadio(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id del estadio no es valido");
                }
                Estadio estadio = await _context.Estadios.FindAsync(id);
                if (estadio == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Estadio no encontrado";
                    return NotFound(response);
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito el estadio";
                _context.Estadios.Remove(estadio);
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
