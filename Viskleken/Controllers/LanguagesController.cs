using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LostInTranslation.Models;
using LostInTranslation.Viewmodels;

namespace LostInTranslation.Controllers
{
    public class LanguagesController : Controller
    {
        private LostInTranslationContext db = new LostInTranslationContext();

        // GET: Languages
        public ActionResult Index()
        {
            return View(db.Languages.ToList());
        }

        // GET: Languages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // GET: Languages/Select
        public ActionResult SelectLanguage()
        {
            LanguageSelectorVM languageSelectorVM = new LanguageSelectorVM();

            List<SelectListItem> languages = new List<SelectListItem>();

            languages = db.Languages.ToList().ConvertAll(l => new SelectListItem
            {
                Value = $"{l.Id}",
                Text = l.Name
            });
            languageSelectorVM.Language = new SelectList(languages, "Value", "Text");

            languageSelectorVM.Heading = "Lost in Translation";
            languageSelectorVM.StageInProcess = 1;

            return View(languageSelectorVM);
        }

        // POST: Languages/Select
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectLanguage(LanguageSelectorVM preLanguageSelectorVM)
        {
            LanguageSelectorVM languageSelectorVM = new LanguageSelectorVM();

            List<SelectListItem> languages = new List<SelectListItem>();

            languages = db.Languages.ToList().ConvertAll(l => new SelectListItem
            {
                Value = $"{l.Id}",
                Text = l.Name
            });
            languageSelectorVM.Language = new SelectList(languages, "Value", "Text");
            languageSelectorVM.SelectedLanguageId = preLanguageSelectorVM.SelectedLanguageId;
            languageSelectorVM.Heading = "Lost in Translation";

            if (preLanguageSelectorVM.SelectedLanguageId == null)
            {
                ModelState.AddModelError("Language", "The field Language is required.");
            }

            if (preLanguageSelectorVM.Phrase != null && preLanguageSelectorVM.SelectedLanguageId != null && ModelState.IsValid)
            {   
                languageSelectorVM.StageInProcess = 2;

                string builder = "";

                System.IO.File.WriteAllText("C:\\Users\\paulh\\OneDrive\\Documents\\Bitoreq AB\\APL\\LostInTranslation\\File.txt", builder);

                return View(languageSelectorVM);
            }

            preLanguageSelectorVM.StageInProcess = 1;

            return View(languageSelectorVM);
        }

        // GET: Languages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: Languages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Language language)
        {
            if (ModelState.IsValid)
            {
                db.Entry(language).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(language);
        }

        // GET: Languages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Language language = db.Languages.Find(id);
            if (language == null)
            {
                return HttpNotFound();
            }
            return View(language);
        }

        // POST: Languages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Language language = db.Languages.Find(id);
            db.Languages.Remove(language);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
