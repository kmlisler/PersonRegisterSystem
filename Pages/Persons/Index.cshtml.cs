using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyDotnetCoreWebApp.Data;
using MyDotnetCoreWebApp.Models;

namespace MyDotnetCoreWebApp.Pages.Persons
{
    public class IndexModel : PageModel
    {
        private readonly RegistrationContext _context;

        public IndexModel(RegistrationContext context)
        {
            _context = context;
        }

        public IList<Person> Person { get;set; }

        public async Task OnGetAsync()
        {
            //Person = await _context.Person.ToListAsync();
        }
        [BindProperty]
        public DataTables.DataTablesRequest DataTablesRequest { get; set; }

        public async Task<JsonResult> OnPostAsync()
        {
            var recordsTotal = _context.Person.Count();

            var personQuery = _context.Person.AsQueryable();

            var searchText = DataTablesRequest.Search.Value?.ToUpper();
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                personQuery = personQuery.Where(s =>
                    s.Name.ToUpper().Contains(searchText) ||
                    s.Surname.ToUpper().Contains(searchText) ||             
                    s.LivingCity.ToUpper().Contains(searchText)
                   
                );
            }

            var recordsFiltered = personQuery.Count();

            var sortColumnName = DataTablesRequest.Columns.ElementAt(DataTablesRequest.Order.ElementAt(0).Column).Name;
            var sortDirection = DataTablesRequest.Order.ElementAt(0).Dir.ToLower();

            //using System.Linq.Dynamic.Core;
            //personQuery = personQuery.OrderBy($"{sortColumnName} {sortDirection}");

            var skip = DataTablesRequest.Start;
            var take = DataTablesRequest.Length;
            var data = await personQuery
                .Skip(skip)
                .Take(take)
                .ToListAsync();

            return new JsonResult(new
            {
                Draw = DataTablesRequest.Draw,
                RecordsTotal = recordsTotal,
                RecordsFiltered = recordsFiltered,
                Data = data
            });
        }
    }
}
