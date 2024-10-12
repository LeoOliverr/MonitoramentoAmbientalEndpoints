using MonitoramentoAmbientalEndpoints.Models;

namespace MonitoramentoAmbientalEndpoints.Data.Repository
{
    public interface ISensorRepository
    {
        IEnumerable<SensorModel> GetAll();
        IEnumerable<SensorModel> GetAll(int page, int pageSize);
        SensorModel GetById(int id);
        void Add(SensorModel sensor);
        void Update(SensorModel sensor);
        void Delete(SensorModel sensor);
    }
}
