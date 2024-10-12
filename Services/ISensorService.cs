using MonitoramentoAmbientalEndpoints.Models;

namespace MonitoramentoAmbientalEndpoints.Services
{
    public interface ISensorService
    {
        IEnumerable<SensorModel> ListarSensores();
        IEnumerable<SensorModel> ListarSensores(int page = 0, int pageSize = 10);
        SensorModel ObterSensorPorId(int id);
        void CriarSensor(SensorModel sensor);
        void AtualizarSensor(SensorModel sensor);
        void DeletarSensor(int id);
    }
}
