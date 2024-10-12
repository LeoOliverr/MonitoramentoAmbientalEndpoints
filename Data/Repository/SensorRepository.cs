using Microsoft.EntityFrameworkCore;
using MonitoramentoAmbientalEndpoints.Data.Contexts;
using MonitoramentoAmbientalEndpoints.Models;


namespace MonitoramentoAmbientalEndpoints.Data.Repository { 
    public class SensorRepository : ISensorRepository
    {
        private readonly DatabaseContext _context;

        public SensorRepository(DatabaseContext context) { 
        
            _context = context;
        }

    public IEnumerable<SensorModel> GetAll()
    {
        return _context.Sensores.ToList();
    }

    public IEnumerable<SensorModel> GetAll(int page, int pageSize) {
            return _context.Sensores
                        .Skip((page - 1) * page)
                        .Take(pageSize)
                        .AsNoTracking()
                        .ToList();
        }
    public SensorModel GetById(int id)
    {
        return _context.Sensores.Find(id);
    }

    public void Add(SensorModel sensor) { 
        _context.Sensores.Add(sensor);
        _context.SaveChanges();
    }

    public void Update(SensorModel sensor) {
        _context.Update(sensor);
        _context.SaveChanges();
    }

    public void Delete(SensorModel sensor) {
        _context.Sensores.Remove(sensor);
        _context.SaveChanges();
    }
    }

}