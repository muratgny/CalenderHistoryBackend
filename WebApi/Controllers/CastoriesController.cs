using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastoriesController : ControllerBase
    {
        ICastoryService _castoryService;
        public CastoriesController(ICastoryService castoryService)
        {
            _castoryService = castoryService;
        }

        [HttpGet("getall")]//burada alias verdik, isminide Get den, GetAll a cevirdik metodun. postmandan artık root adresi girxikten sonra
                           //api/products/getall yazdığımızda hepsi gelecek ürünlerin
        public async Task<IActionResult> GetAll()
        {
            var result = await _castoryService.GetList();
            if (result.Success)
            {
                return Ok(result);//Code 200
            }

            return BadRequest(result);//Code 400
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _castoryService.GetById(id);
            if (result.Success)
            {
                return Ok(result);//Code 200
            }

            return BadRequest(result);//Code 400
        }

        [HttpPost("Add")]
        public IActionResult Post(Castory castory)
        {
            var result = _castoryService.Add(castory);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update(Castory castory)
        {
            var result = _castoryService.Update(castory);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Castory castory)
        {
            var result = _castoryService.Delete(castory);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
