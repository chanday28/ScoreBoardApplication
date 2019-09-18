using ScoreBoard_Application.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ScoreBoard_Application.Controllers
{
    public class ScoreBoardController : Controller
    {
        private readonly ScoreBoardContext _context = new ScoreBoardContext();
        // GET: ScoreBoard
        public ActionResult Index()
        {
            var playerScores = _context.Player_Scores.OrderByDescending(x=>x.Score).ToList();
            return View(playerScores);
        }

        public ActionResult ShowPlayerDetails()
        {
            var playerScores = _context.Player_Scores.OrderByDescending(x => x.Score).ToList();
            return View(playerScores);
        }

        // Get  
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Player_Score playerScore)
        {
            if (ModelState.IsValid)
            {
                _context.Player_Scores.Add(playerScore);
                _context.SaveChanges();
                return RedirectToAction("ShowPlayerDetails");
            }
            return View(playerScore);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var playerScore = _context.Player_Scores.SingleOrDefault(e => e.PlayerScoreId == id);
            if (playerScore == null)
            {
                return HttpNotFound("Record Not Found");
            }
            return View(playerScore);
        }
        [HttpPost]
        public ActionResult Edit(Player_Score playerScore)
        {
            if (ModelState.IsValid)
            {

                _context.Entry(playerScore).State = EntityState.Modified;
                playerScore.ModifiedDate = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("ShowPlayerDetails");
            }

            return View(playerScore);
        }
        public ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var playerScore = _context.Player_Scores.SingleOrDefault(e => e.PlayerScoreId == id);
            if (playerScore == null)
            {
                return HttpNotFound();
            }
            return View(playerScore);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var playerScore = _context.Player_Scores.SingleOrDefault(x => x.PlayerScoreId == id);
            _context.Player_Scores.Remove(playerScore);
            _context.SaveChanges();
            return RedirectToAction("ShowPlayerDetails");
        }
    }
}