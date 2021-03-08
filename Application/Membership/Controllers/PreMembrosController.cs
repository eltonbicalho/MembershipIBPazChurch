using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Membership.Data;
using Membership.Models;

namespace Membership.Controllers
{
    public class PreMembrosController : Controller
    {
        private readonly MembresiaContext _context;

        public PreMembrosController(MembresiaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["IdIgreja"] = new SelectList(_context.Igrejas, "IdIgreja", "Nome");
            return View("Create");
        }

        public IActionResult Create()
        {
            ViewData["IdIgreja"] = new SelectList(_context.Igrejas, "IdIgreja", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPreMembro,IdIgreja,Nome,Email,Telefone,Observacoes,DataUpdate")] PreMembros preMembros)
        {
            preMembros.Active = false;
            if (ModelState.IsValid)
            {
                _context.Add(preMembros);
                await _context.SaveChangesAsync();
                return View("Details", preMembros);
            }
            ViewData["IdIgreja"] = new SelectList(_context.Igrejas, "IdIgreja", "Nome", preMembros.IdIgreja);
            return View(preMembros);
        }
    }
}
