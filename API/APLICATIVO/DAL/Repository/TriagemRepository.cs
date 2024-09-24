using System.Linq.Expressions;
using BLL.Interface.Repository;
using BLL.Models;
using DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository;

public class TriagemRepository:IRepository<Triagem>
{
    private readonly SQLContext _context;
    
    public TriagemRepository(SQLContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Triagem>> GetAllAsync()
    {
        return await _context.Triagens.ToListAsync();
    }

    public async Task<Triagem> GetByIdAsync(Guid id)
    {
        return await _context.Triagens.FindAsync(id);
    }

    public async Task<Triagem> AddAsync(Triagem entity)
    {
        await _context.Triagens.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Triagem> UpdateAsync(Triagem entity)
    {
        _context.Triagens.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await GetByIdAsync(id);
        if (entity == null)
            return false;
        _context.Triagens.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Triagem> GetByConditionAsync(Expression<Func<Triagem, bool>> expression)
    {
        return await _context.Triagens.FirstOrDefaultAsync(expression);
    }
}