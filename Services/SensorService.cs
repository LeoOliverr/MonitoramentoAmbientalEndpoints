using MonitoramentoAmbientalEndpoints.Data.Repository;
using MonitoramentoAmbientalEndpoints.Models;

namespace MonitoramentoAmbientalEndpoints.Services
{
    public class SensorService : ISensorService
    {
        private readonly ISensorRepository _repository;

        public SensorService(ISensorRepository repository) { 
            _repository = repository;
        }

        public IEnumerable<SensorModel> ListarSensores() => _repository.GetAll();

        public IEnumerable<SensorModel> ListarSensores(int page = 1, int pageSize = 10) { 
            return _repository.GetAll(page, pageSize);
        }

        public SensorModel ObterSensorPorId(int id) => _repository.GetById(id);

        public void CriarSensor(SensorModel sensor) => _repository.Add(sensor);

        public void AtualizarSensor(SensorModel sensor) => _repository.Update(sensor);

        public void DeletarSensor(int id) { 
            var sensor = _repository.GetById(id);
            if (sensor != null) { 
                _repository.Delete(sensor);
            }
        }


    }
}
