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
    public class PiesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public PiesController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetPies")]
        public async Task<ActionResult<IEnumerable<Pie>>> GetPies()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del pie dominate";
                response.Data = await _context.Pies.ToListAsync();
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
        [Route("GetPie/{id}")]
        public async Task<ActionResult<Pie>> GetDemarcacion(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del pie ";
                response.Data = await _context.Pies.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Pie del jugador no encontrado";
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
        [Route("PostPie")]
        public async Task<ActionResult<Pie>> PostPie(Pie item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa del la demarcacion";
                _context.Pies.Add(item);
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
        [Route("PutPie/{id}")]
        public async Task<IActionResult> PutPie(int id, Pie item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id != item.Id)
                {
                    throw new ArgumentException("id del pie no coincide");
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa del pie";
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
        [Route("DeletePie/{id}")]
        public async Task<IActionResult> DeletePie(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id del Pie no es valido");
                }
                Pie pie = await _context.Pies.FindAsync(id);
                if (pie == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Pie no encontrado";
                    return NotFound(response);
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito el pie";
                _context.Pies.Remove(pie);
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
