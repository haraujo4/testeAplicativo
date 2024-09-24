using System.Linq.Expressions;
using BLL.Interface.Repository;
using BLL.Models;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class PacienteRepository : IRepository<Paciente>
{
        private readonly SQLContext _context;

        public PacienteRepository(SQLContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(Guid id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task<Paciente> AddAsync(Paciente entity)
        {
            _context.Pacientes.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Paciente> UpdateAsync(Paciente entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if(paciente == null)
                return false;
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
            
        }

        public async Task<Paciente> GetByConditionAsync(Expression<Func<Paciente, bool>> expression)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(expression);
        }
}