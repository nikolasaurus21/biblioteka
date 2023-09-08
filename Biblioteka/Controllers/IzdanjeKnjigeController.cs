using Biblioteka.DTO;
using Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.UI;
using PagedList;
using Biblioteka.Entities;

namespace Biblioteka.Controllers
{
    public class IzdanjeKnjigeController : Controller
    {
        private BibliotekaEntities _context;

        public IzdanjeKnjigeController()
        {
            _context = new BibliotekaEntities();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: IzdanjeKnjige
        public ActionResult ListaIzdanja(/*int? page*/)
        {
            //int pageSize = 7; // broj redova po stranici
            //int pageNumber = (page ?? 1);

            int trenutnaGodina = DateTime.Now.Year; 
            int proslaGodina = trenutnaGodina - 1; 

            var izdanja = _context.IzdanjaKnjiga
                .Include(x => x.IzdavackeKuce)
                .Include(x => x.Knjige)
                .Where(x => x.Godina >= proslaGodina) 
                .OrderBy(x => x.Knjige.Naslov) 
                .Select(x => new NajnovijaIzdanjaDTO
                {
                    IzdanjeID = x.Id,
                    Godina = x.Godina,
                    IzdavackaKuca = x.IzdavackeKuce.Naziv,
                    Knjiga = x.Knjige.Naslov,
                    SlikaKorica = x.SlikaKorica,
                    BrojNaStanju = x.Knjige.BrojNaStanju,
                    BrojIzdatih = x.Knjige.BrojIzdatih,
                }).ToList();

            //return View(izdanja.ToPagedList(pageNumber, pageSize));
            return View(izdanja);
        }

    }
}