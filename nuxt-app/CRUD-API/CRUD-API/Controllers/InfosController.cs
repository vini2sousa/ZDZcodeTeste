using APITeste.Models;
using CRUD_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace CRUD_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InfosController : ControllerBase
    {
        private readonly EFDBContext _context;

        public InfosController(EFDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Infos> Get()
        {
            return _context.Infos.ToList();
        }

        [HttpPost]
        public ActionResult<Infos> Post([FromBody] Infos infos)
        {
            _context.Infos.Add(infos);
            _context.SaveChanges(); 

            return infos; 
        }

 
        [HttpDelete("{cpf}")]
        public IActionResult Delete(string cpf)
        {
            var info = _context.Infos.FirstOrDefault(i => i.Cpf == cpf);
            if (info == null)
            {
                return NotFound(); 
            }

            _context.Infos.Remove(info);
            _context.SaveChanges(); 

            return NoContent(); 
        }

        [HttpPut("{cpf}")]
        public ActionResult<Infos> Put(string cpf, [FromBody] Infos updatedInfo)
        {
            if (updatedInfo == null)
            {
                return BadRequest(); 
            }

            var info = _context.Infos.FirstOrDefault(i => i.Cpf == cpf);
            if (info == null)
            {
                return NotFound(); 
            }

            info.NomeCompleto = updatedInfo.NomeCompleto;
            info.Email = updatedInfo.Email;
            info.Cpf = updatedInfo.Cpf;

            _context.SaveChanges(); 

            return info; 
        }
    }
}
