using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SecuritySystem.Application.KeyCard.Dto;
using SecuritySystem.Application.Services;
using SecuritySystem.Core.Models;
using SecuritySystem.Core.Repositories;

namespace SecuritySystem.Web.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyCardController :  ControllerBase
    {
        IAppService<KeyCardDto, KeyCardInsertDto, Guid> _service;
        public KeyCardController(IAppService<KeyCardDto, KeyCardInsertDto, Guid> service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetAll()
        {
           var keycards = await _service.GetAllAsync();
           return Ok(keycards);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
           if(id == Guid.Empty)
              return BadRequest();

           var keycard = await _service.GetAsync(id);
           return Ok(keycard);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(KeyCardInsertDto entity)
        {
             if(entity == null)
                return BadRequest();

             var keycard = await _service.InsertAsync(entity); 

             return Ok(keycard);
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(KeyCardInsertDto entity)
        {
             if(entity == null)
                return BadRequest();

             var keycard = await _service.UpdateAsync(entity); 

             return Ok(keycard);
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid guid)
        {
             if(guid == Guid.Empty)
                return BadRequest();

             await _service.DeleteAsync(guid); 

             return Ok();
        }
    
    }
}