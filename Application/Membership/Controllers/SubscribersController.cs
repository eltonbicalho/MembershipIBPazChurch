using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Membership.Data;
using Membership.Models;
using Microsoft.AspNetCore.Authorization;

namespace Membership.Controllers
{
    public class SubscribersController : Controller
    {
        private readonly MembresiaContext _context;

        public SubscribersController(MembresiaContext context)
        {
            _context = context;
        }

        // GET: Subscribers
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View("Create");
        }

        // GET: Subscribers/Create
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSubscriber,Nome,Email,Telefone,ReceiveWhatsApp,ReceiveNewsletter,DataUpdate")] Subscribers subscribers)
        {
            if (ModelState.IsValid)
            {
                //will wait for confirmation e-mail
                subscribers.Active = false;

                _context.Add(subscribers);
                await _context.SaveChangesAsync();
                return View("Details", subscribers);
            }
            return View(subscribers);
        }
    }
}
