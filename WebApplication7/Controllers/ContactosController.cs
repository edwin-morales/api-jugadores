using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication7.Data;
using WebApplication7.Models;

namespace WebApplication7.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ContactosController : ControllerBase
    {
        private readonly Data.DatabaseContext _context;
        public ContactosController(Data.DatabaseContext contexto)
        {
            _context = contexto;

        }

        [HttpGet]
        [Route("GetContactoItems")]
        public async Task<ActionResult<IEnumerable<Contacto>>> GetContactoItems()
        {

            try
            {
                return Ok(await _context.Contactos.ToListAsync());
            }
            catch (System.Exception ex)
            {
                string message = ex.Message;
            }
            return Ok(new List<Contacto>());
        }

       

        [HttpGet]
        [Route("GetContactoItem/{id}")]
        public async Task<ActionResult<Contacto>> GetContactoItem(int id)
        {
            var contactoItem = await _context.Contactos.FindAsync(id);
            if (contactoItem == null)
            {
                return NotFound();
            }
            return Ok (contactoItem);
        }

        [HttpPost]
        [Route("PostContactoItem")]
        public async Task<ActionResult<Contacto>> PostContactoItem(Contacto item)
        {
            _context.Contactos.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetContactoItem), new { id = item.Id }, item);

        }

        [HttpPut]
        [Route("PutContactoItems/{id}")]
        public async Task<IActionResult> PutContactoItem(int id, Contacto item)
        {
            if (id != item.Id)
            { 
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();

        }

        [HttpDelete]
        [Route("DeleteContactoItems/{id}")]
        public async Task<IActionResult> DeleteContactoItem(int id)
        {
            var contactoItem = await _context.Contactos.FindAsync(id);
            if (contactoItem == null)
            {
                return NoContent();
            }
            _context.Contactos.Remove(contactoItem);
            await _context.SaveChangesAsync();
            return NoContent();

        }


    }
}
