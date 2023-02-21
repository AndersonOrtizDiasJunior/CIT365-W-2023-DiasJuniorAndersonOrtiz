using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Entries
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<Entry> Entry { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Books { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? EntryBook { get; set; }

        [BindProperty(SupportsGet = true)]
        public bool sortByDate { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> bookQuery = from e in _context.Entry
                                            orderby e.Book
                                            select e.Book;
            
            var entries = from e in _context.Entry
                         select e;
            //if (sortByDate)
            //{
            //    entries = from e in _context.Entry
            //              orderby e.Date
            //              select e;
            //}

            if (!string.IsNullOrEmpty(SearchString))
            {
                entries = entries.Where(s => s.Annotation.ToLower().Contains(SearchString.ToLower()));
            }

            if (!string.IsNullOrEmpty(EntryBook))
            {
                entries = entries.Where(x => x.Book == EntryBook);
            }

            if (sortByDate)
            {
                entries = entries.OrderBy(s => s.Date);
            } else
            {
                entries = entries.OrderBy(s => s.Book);
            }

            Books = new SelectList(await bookQuery.Distinct().ToListAsync());
            Entry = await entries.ToListAsync();
        }
    }
}
