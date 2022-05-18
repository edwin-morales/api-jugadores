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
    public class VideosController : ControllerBase
    {
        private readonly DatabaseContext _context;
        public VideosController(DatabaseContext contexto)
        {
            _context = contexto;
        }


        [HttpGet]
        [Route("GetVideos")]
        public async Task<ActionResult<IEnumerable<Video>>> GetVideos()
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del los videos";
                response.Data = await _context.Videos.ToListAsync();
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
        [Route("GetVideo/{id}")]
        public async Task<ActionResult<Video>> GetVideo(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Consulta exitosa del video";
                response.Data = await _context.Videos.FindAsync(id);
                if (response.Data == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Video no encontrado";
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
        [Route("PostVideo")]
        public async Task<ActionResult<Video>> PostVideo(Video item)
        {

            ResponseDto response = new ResponseDto();
            try
            {
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Creacion exitosa del video";
                _context.Videos.Add(item);
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
        [Route("PutVideo/{id}")]
        public async Task<IActionResult> PutVideo(int id, Video item)
        {
            ResponseDto response = new ResponseDto();
            try
            {

                if (id != item.Id)
                {
                    throw new ArgumentException("id del video no coincide");
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Actualizacion exitosa del video";
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
        [Route("DeleteVideo/{id}")]
        public async Task<IActionResult> DeleteVideo(int id)
        {
            ResponseDto response = new ResponseDto();
            try
            {
                if (id < 1)
                {
                    throw new ArgumentException("id del video no es valido");
                }

                Video video = await _context.Videos.FindAsync(id);
                if (video == null)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    response.Message = "Video no encontrado";
                    return NotFound(response);
                }

                response.StatusCode = (int)HttpStatusCode.OK;
                response.Message = "Se elimino con exito el video";
                _context.Videos.Remove(video);
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
