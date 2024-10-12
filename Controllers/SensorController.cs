using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MonitoramentoAmbientalEndpoints.Models;
using MonitoramentoAmbientalEndpoints.Services;
using MonitoramentoAmbientalEndpoints.ViewModel;

namespace MonitoramentoAmbientalEndpoints.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SensorController : ControllerBase
    {
        private readonly ISensorService _sensorService;
        private readonly IMapper _mapper;

        public SensorController(ISensorService sensorService, IMapper mapper1)
        {
            _sensorService = sensorService;
            _mapper = mapper1;
        }

        [HttpGet]
        [Authorize(Roles = "operador, gerente")]
        public ActionResult<IEnumerable<SensorPaginacaoViewModel>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 10) {
            var sensores = _sensorService.ListarSensores(page, pageSize);
            var viewModelList = _mapper.Map<IEnumerable<SensorViewModel>>(sensores);

            var viewModel = new SensorPaginacaoViewModel
            {
                Sensors = viewModelList,
                CurrentPage = page,
                PageSize = pageSize
            };
            return Ok(viewModel);
        }
        //public IEnumerable<SensorViewModel> Get() {
        //    var sensores = _sensorService.ListarSensores();
        //    var viewModelList = _mapper.Map<IEnumerable<SensorViewModel>>(sensores);

        //    return viewModelList;
        //}

        [HttpGet("{id}")]
        [Authorize(Roles = "operador, gerente")]
        public ActionResult<SensorViewModel> Get(int id) {
            var sensor = _sensorService.ObterSensorPorId(id);
            if (sensor == null) {
                return NotFound();
            }
            
            var viewModel = _mapper.Map<SensorViewModel>(sensor);
            return Ok(viewModel);
        }

        [HttpPost]
        [Authorize(Roles = "operador, gerente")]
        public ActionResult Post([FromBody] SensorViewModel viewModel) {
            var sensor = _mapper.Map<SensorModel>(viewModel);
            _sensorService.CriarSensor(sensor);
                return CreatedAtAction(nameof(Get), new { id = sensor.Id }, viewModel);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(int id, [FromBody] SensorViewModel viewModel) {
            var sensorExistente = _sensorService.ObterSensorPorId(id);
            if (sensorExistente == null)
            {
                return NotFound();
            }

            _mapper.Map(viewModel, sensorExistente);
            _sensorService.AtualizarSensor(sensorExistente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(int id) {
            _sensorService.DeletarSensor(id);
            return NoContent();
        }
    }
}