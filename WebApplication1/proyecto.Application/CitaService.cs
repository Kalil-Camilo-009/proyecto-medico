using proyecto.Domain;
using proyecto.Infrastructure;
using System.Collections.Generic;

namespace proyecto.Application
{
    public class CitaService
    {
        private readonly CitaRepository _repository;

        public CitaService(CitaRepository repository)
        {
            _repository = repository;
        }

        public void AddCita(Cita cita)
        {
            _repository.Add(cita);
        }

        public List<Cita> GetAllCitas()
        {
            return _repository.GetAll();
        }

        public Cita GetCitaById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateCita(Cita cita)
        {
            _repository.Update(cita);
        }

        public void DeleteCita(int id)
        {
            _repository.Delete(id);
        }
    }
}
