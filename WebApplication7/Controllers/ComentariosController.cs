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
using System.Linq;

namespace WebApplication7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public ComentariosController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetComentarios")]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentarios()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del los comentarios";
                response.Data = await _context.Comentarios.ToListAsync();
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
        [Route("GetComentario/{id}")]
        public async Task<ActionResult<Comentario>> GetComentarios(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del comentario";
                response.Data = await _context.Comentarios.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Comentario no encontrado";
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

        [HttpGet]
        [Route("GetComentariosByIdVideo/{idVideo}")]
        public async Task<ActionResult<Comentario>> GetComentariosByIdVideo(int idVideo)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del comentario";
                response.Data = _context.Comentarios.Where(x=> x.IdVideo == idVideo).ToList();
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Comentario no encontrado";
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
        [Route("PostComentario")]
        public async Task<ActionResult<Comentario>> PostComentario(Comentario comentario)
        {

            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa del comentario";
                comentario.CreatedBy = "Edwin";
                comentario.CreatedAt = DateTime.Now;
                _context.Comentarios.Add(comentario);
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
        [Route("PutComentario/{id}")]
        public async Task<IActionResult> PutComentario(int id, Comentario comentario)
        {
            ResponseDto response = new ResponseDto();
            try
            {

                if (id != comentario.Id)
                {
                    throw new ArgumentException("id del comentario no coincide");
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa del comentario";
                comentario.UpdatedBy = "Morales";
                comentario.UpdatedAt = DateTime.Now;
                _context.Entry(comentario).State = EntityState.Modified;
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
        [Route("DeleteComentario/{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id del comentario no es valido");
                }

                Comentario comentario = await _context.Comentarios.FindAsync(id);
                if (comentario == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Comentario no encontrado";
                    return NotFound(response);
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito el comentario";
                _context.Comentarios.Remove(comentario);
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
