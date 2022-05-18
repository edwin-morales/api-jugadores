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
    public class AuthorVideosController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public AuthorVideosController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetAuthorVideos")]
        public async Task<ActionResult<IEnumerable<AuthorVideo>>> GetAuthorVideos()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del author";
                response.Data = await _context.AuthorVideos.ToListAsync();
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
        [Route("GetAuthorVideo/{id}")]
        public async Task<ActionResult<AuthorVideo>> GetAuthorVideo(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del author";
                response.Data = await _context.AuthorVideos.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Author no encontrado";
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
        [Route("PostAuthorVideo")]
        public async Task<ActionResult<AuthorVideo>> PostAuthorVideo(AuthorVideo item)
        {

            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa del author";
                _context.AuthorVideos.Add(item);
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
        [Route("PutAuthorVideos/{id}")]
        public async Task<IActionResult> PutAuthorVideo(int id, AuthorVideo item)
        {
            ResponseDto response = new ResponseDto();
            try
            {

                if (id != item.Id)
                {
                    throw new ArgumentException("id del author no coincide");
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa del author";
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
        [Route("DeleteAuthorVideo/{id}")]
        public async Task<IActionResult> DeleteAuthorVideo(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id del author no es valido");
                }

                AuthorVideo authorVideo = await _context.AuthorVideos.FindAsync(id);
                if (authorVideo == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Author no encontrado";
                    return NotFound(response);
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito el author";
                _context.AuthorVideos.Remove(authorVideo);
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
