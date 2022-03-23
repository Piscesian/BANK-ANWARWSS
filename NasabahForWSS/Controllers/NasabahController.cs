using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nasabah.ServiceProvider;
using Nasabah.ViewModel;

namespace NasabahForWSS.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NasabahController : ControllerBase
    {
        private NasabahProvider _provider;
        public NasabahController (NasabahProvider prov) { _provider = prov; }
        [HttpGet]
        public ActionResult GetAllData() { 
            var data = _provider.GetAllData();
            return Ok(data);
        }
        [HttpGet]
        public JsonResult GetDataByKtp(string NoKTP) { 
            var data = _provider.GetDataByKTP(NoKTP);
            return new JsonResult(data);
        }
        [HttpPost]
        public ActionResult CreateData(NasabahViewModel model) {
            var result = new AjaxViewModel();
            try
            {
                result = _provider.CreateNewData(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
                return Ok(result);
            }
        }
        [HttpPost]
        public ActionResult UpdateData(NasabahEditModel model)
        {
            var result = new AjaxViewModel();
            try
            {
                result = _provider.UpdateData(model);
                return Ok(result);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
                return Ok(result);
            }
        }
        [HttpPost]
        public ActionResult DeleteData(int id)
        {
            var result = new AjaxViewModel();
            try
            {
                result = _provider.DeleteData(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
                return Ok(result);
            }
        }

    }
}
