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
    public class ProvinciasController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ProvinciasController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetProvincias")]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetProvincia()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa de las provincias";
                response.Data = await _context.Provincias.ToListAsync();
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
        [Route("GetProvincia/{id}")]
        public async Task<ActionResult<Provincia>> GetProvincia(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa de la provincia";
                response.Data = await _context.Provincias.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Provincia no encontrada";
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
        [Route("PostProvincia")]
        public async Task<ActionResult<Provincia>> PostProvincia(Provincia item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa de la provincia";
                _context.Provincias.Add(item);
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
        [Route("PutProvincia/{id}")]
        public async Task<IActionResult> PutProvincia(int id, Provincia item)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id != item.Id)
                {
                    throw new ArgumentException("id de la provincia no coincide");
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa de la provincia";
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
        [Route("DeleteProvincia/{id}")]
        public async Task<IActionResult> DeleteProvincia(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id de la provincia no es valida");
                }
                Provincia provincia = await _context.Provincias.FindAsync(id);
                if (provincia == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Provincia no encontrada";
                    return NotFound(response);
                }
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito la provincia";
                _context.Provincias.Remove(provincia);
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
