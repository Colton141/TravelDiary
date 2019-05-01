using Microsoft.AspNetCore.Mvc;
using TravelDiary.Models;
using System.Collections.Generic;


namespace TravelDiary.Controllers
{
  public class PLacesController : Controller
  {
    [HttpGet("/places")]
    public ActionResult Index()
    {
      List<Place> allPlaces = Place.GetAll();
      return View(allPlaces);
    }
    [HttpGet("/places/new")]
    public ActionResult New()
    {
      return View();
    }
    [HttpPost("/places")]
    public ActionResult Create(string name, string notes, string year)
    {
      Place myPlace = new Place(name, notes, year);
      return RedirectToAction("Index");
    }
    [HttpPost("/places/delete")]
    public ActionResult DeleteAll()
    {
      Place.ClearAll();
      return View();
    }
    [HttpGet("/places/{id}")]
    public ActionResult Show(int id)
    {
      Place place = Place.Find(id);
      return View(place);
    }
    [HttpPost("/places/{id}")]
    public ActionResult Destroy(int id)
    {
      Place.DestroyPlace(id);
      return View();
    }
    [HttpPost("/places/search")]
    public ActionResult Search(string year)
    {
    List<Place> results = Place.FindAll(year);
      return View(results);
    }
    [HttpGet("/places/searchform")]
    public ActionResult SearchForm()
    {
      return View();
    }
  }
}
