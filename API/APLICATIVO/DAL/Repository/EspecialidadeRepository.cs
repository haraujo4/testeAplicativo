using System.Linq.Expressions;
using BLL.Interface.Repository;
using BLL.Models;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class EspecialidadeRepository:IRepository<Especialidade>
{
    private readonly SQLContext _context;
    
    public EspecialidadeRepository(SQLContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Especialidade>> GetAllAsync()
    {
        return await _context.Especialidades.ToListAsync();
    }

    public async Task<Especialidade> GetByIdAsync(Guid id)
    {
        return await _context.Especialidades.FindAsync(id);
    }

    public async Task<Especialidade> AddAsync(Especialidade entity)
    {
        await _context.Especialidades.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Especialidade> UpdateAsync(Especialidade entity)
    {
        _context.Especialidades.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return false;
        _context.Especialidades.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Especialidade> GetByConditionAsync(Expression<Func<Especialidade, bool>> expression)
    {
        return await _context.Especialidades.FirstOrDefaultAsync(expression);
    }
}