using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Data;
using SalesWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Models.ViewModels;
namespace SalesWebMvc.Services
{
    public class DepartamentService
    {
        private readonly SalesWebMvcContext _context;
        public DepartamentService(SalesWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<Departament>> FindAllAsync()
        {
            return  await _context.Departament.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
