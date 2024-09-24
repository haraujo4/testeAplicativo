using System.Linq.Expressions;
using BLL.Interface.Repository;
using BLL.Models;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class AtendimentoRepository:IRepository<Atendimento>
{
    private readonly SQLContext _context;
    
    public AtendimentoRepository(SQLContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Atendimento>> GetAllAsync()
    {
        return await _context.Atendimentos.ToListAsync();
    }

    public async Task<Atendimento> GetByIdAsync(Guid id)
    {
        return await _context.Atendimentos.FindAsync(id);
    }

    public async Task<Atendimento> AddAsync(Atendimento entity)
    {
        await _context.Atendimentos.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Atendimento> UpdateAsync(Atendimento entity)
    {
        _context.Atendimentos.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return false;
        _context.Atendimentos.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Atendimento> GetByConditionAsync(Expression<Func<Atendimento, bool>> expression)
    {
        return await _context.Atendimentos.FirstOrDefaultAsync(expression);
    }
}