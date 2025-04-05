using Microsoft.EntityFrameworkCore;
using proyecto.Domain;
using System.Collections.Generic;
using System.Linq;

namespace proyecto.Infrastructure
{
    public class CitaRepository
    {
        private readonly AppDbContext _context;

        public CitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Cita cita)
        {
            _context.Citas.Add(cita);
            _context.SaveChanges();
        }

        public List<Cita> GetAll()
        {
            return _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .ToList();
        }

        public Cita GetById(int id)
        {
            return _context.Citas
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefault(c => c.Id_Cita == id);
        }

        public void Update(Cita cita)
        {
            _context.Citas.Update(cita);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cita = _context.Citas.Find(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                _context.SaveChanges();
            }
        }
    }
}
