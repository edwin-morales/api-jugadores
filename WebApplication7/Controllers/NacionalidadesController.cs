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
    public class NacionalidadesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public NacionalidadesController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetNacionalidades")]
        public async Task<ActionResult<IEnumerable<Nacionalidad>>> GetNacionalidades()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa de la nacionalidad";
                response.Data = await _context.Nacionalidades.ToListAsync();
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
        [Route("GetNacionalidad/{id}")]
        public async Task<ActionResult<Nacionalidad>> GetNacionalidad(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa de la nacionalidad ";
                response.Data = await _context.Nacionalidades.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Nacionalidad del jugador no encontrada";
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
        [Route("PostNacionalidad")]
        public async Task<ActionResult<Nacionalidad>> PostNacionalidad(Nacionalidad item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa de la nacionalidad";
                _context.Nacionalidades.Add(item);
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
        [Route("PutNacionalidad/{id}")]
        public async Task<IActionResult> PutNacionalidad(int id, Nacionalidad item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id != item.Id)
                {
                    throw new ArgumentException("id de la nacionalidad no coincide");
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa de la nacionalidad";
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
        [Route("DeleteNacionalidad/{id}")]
        public async Task<IActionResult> DeleteNacionalidad(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id de la nacionalidad no es valido");
                }
                Nacionalidad nacionalidad = await _context.Nacionalidades.FindAsync(id);
                if (nacionalidad == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Nacionalidad no encontrada";
                    return NotFound(response);
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito la nacionalidad";
                _context.Nacionalidades.Remove(nacionalidad);
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
