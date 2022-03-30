using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMVC.Models;
using SalesWebMVC.Data;
using Microsoft.EntityFrameworkCore;


namespace SalesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SalesWebMVCContext _context;

        public DepartmentService(SalesWebMVCContext context) //injeção  de dependencia
        {
            _context = context;
        }

        /*operação sincronna (sync)
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }*/
        //operação assincrona (async)
        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
