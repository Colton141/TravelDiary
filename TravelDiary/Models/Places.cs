using System.Collections.Generic;

namespace TravelDiary.Models
{
  public class Place
  {
    private string _name;
    private string _notes;
    private string _year;
    private int _id;
    private static List<Place> _instances = new List<Place> {};

    public string Name {get=>_name; set=> _name = value;}
    public string Notes {get=>_notes; set=> _notes = value;}
    public string Year {get=>_year; set=> _year = value;}

    public Place (string name, string notes, string year)
    {
      _name = name;
      _notes = notes;
      _year = year;
      _instances.Add(this);
      _id = _instances.Count;
    }

    public int GetId()
    {
      return _id;
    }

    public static Place Find(int searchId)
    {
      for(int i = 0; i < _instances.Count; i++)
      {
        if(_instances[i].GetId() == searchId)
        {
        return _instances[i];
        }
      }
      return _instances[0];
    }

    public static List<Place> GetAll()
    {
      return _instances;
    }

    public static void DestroyPlace(int id)
    {
      for(int i = 0; i < _instances.Count; i++)
      {
        if(_instances[i].GetId() == id)
        {
          _instances.RemoveAt(i);
        }
      }
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Place> FindAll(string year)
    {
      List<Place> places = new List<Place>{};
      for (int i = 0; i < _instances.Count; i++)
      {
        if (year == _instances[i].Year)
        {
          places.Add(_instances[i]);
        }
      }
      return places;
    }
  }
}
