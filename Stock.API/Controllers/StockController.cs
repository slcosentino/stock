
using Stock.Logic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Stock.Models;
using System.Linq;
using Stock.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Cors;

namespace Stock.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("MyPolicy")]
    public class StockController : ControllerBase
    {
        IMapper _mapper;
       
        
        public StockController(IMapper mapper )
        {
            _mapper = mapper;            
        }

        [HttpGet]
        public IEnumerable<ElementModel> Get()
        {
            var stock = new Logic.Stock();
            var elements = stock.GetAll();
            var elementModels = elements.Select(x => _mapper.Map<ElementModel>(x));

            return elementModels;
        }

        [HttpGet("{id}")]
        public ElementModel Get(int id)
        {
            var stock = new Logic.Stock();
            var element = stock.GetElementById(id);

            var elementModel = _mapper.Map<ElementModel>(element);

            return elementModel;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ElementModel model)
        {
            try
            {
                var element = _mapper.Map<Element>(model);
                var stock = new Logic.Stock();
                stock.Add(element);
                return Ok(new { data = "The element has been created."});
            }
            catch (ValidationException e2)
            {                
                return StatusCode(500, new { Error = "Validation Error.", Message = e2.Message });
            }
            catch (System.Exception e)
            {             
                return StatusCode(500, new { Error = "Internal error.", Message = "It can not be possible to add the new element." });
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var stock = new Logic.Stock();
                var entity = stock.Delete(id);                
                return Ok(new { data = "The element has been deleted." });
            }
            catch (ValidationException e2)
            {              
                return StatusCode(500, new { Error = "Validation Error.", Message = e2.Message });
            }
            catch (System.Exception e)
            {             
                return StatusCode(500, new { Error = "Internal error.", Message = "It can not be possible to delete the element." });
            }
        }
    }
}
