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
    public class PaisesController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public PaisesController(DatabaseContext contexto)
        {
            _context = contexto;
        }

        [HttpGet]
        [Route("GetPaises")]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del los paises";
                response.Data = await _context.Paises.ToListAsync();
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
        [Route("GetPais/{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del pais";
                response.Data = await _context.Paises.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Pais no encontrado";
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
        [Route("PostPais")]
        public async Task<ActionResult<Pais>> PostPais(Pais item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa del pais";
                _context.Paises.Add(item);
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
        [Route("PutPais/{id}")]
        public async Task<IActionResult> PutPais(int id, Pais item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id != item.Id)
                {
                    throw new ArgumentException("id del pais no coincide");
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa del pais";
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
        [Route("DeletePais/{id}")]
        public async Task<IActionResult> DeletePais(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id del pais no es valido");
                }
                Pais pais = await _context.Paises.FindAsync(id);
                if (pais == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Pais no encontrado";
                    return NotFound(response);
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito el pais";
                _context.Paises.Remove(pais);
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
