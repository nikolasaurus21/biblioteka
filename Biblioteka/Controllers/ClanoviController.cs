using Biblioteka.DTO;
using Biblioteka.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

namespace Biblioteka.Controllers
{
    public class ClanoviController : Controller
    {
        private BibliotekaEntities _context;

        public ClanoviController()
        {
            _context = new BibliotekaEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Clanovi
        public ActionResult Index()
        {
            var clanoviDTO = _context.Clan.Select(c => new ClanGetDTO
            {
                ClanID = c.ClanID,
                Ime = c.Ime,
                Prezime = c.Prezime,
                MaticniBroj = c.MaticniBroj,
                Email = c.Email,
                Adresa = c.Adresa,
                DatumRodjenja = c.DatumRodjenja
            })
            .OrderByDescending(c => c.ClanID)
            .ToList();

            return View(clanoviDTO);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Clanovi/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( ClanSaveDTO clanSaveDTO)
        {

            var existingClan = _context.Clan.SingleOrDefault(c => c.MaticniBroj == clanSaveDTO.MaticniBroj);
            if (existingClan != null)
            {
                ModelState.AddModelError("MaticniBroj", "Matični broj već postoji.");
            }
            if (ModelState.IsValid)
            {
                
                var clan = new Clan
                {
                    Ime = clanSaveDTO.Ime,
                    Prezime = clanSaveDTO.Prezime,
                    MaticniBroj = clanSaveDTO.MaticniBroj,
                    Email = clanSaveDTO.Email,
                    Adresa = clanSaveDTO.Adresa,
                    DatumRodjenja = clanSaveDTO.DatumRodjenja
                };

                _context.Clan.Add(clan);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(clanSaveDTO);
        }
    }
}
