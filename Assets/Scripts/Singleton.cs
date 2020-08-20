using System.Collections;
using System.Collections.Generic;

public class Singleton
{
  private static Singleton instance;

  private Singleton() { }

  private int service01Price;
  private int service02Price;
  private int service03Price;
  private int service04Price;
  private int service05Price;
  private int service06Price;

  private bool isInOfficeRange;

  public static Singleton Instance
  {
      get
      {
          if (instance == null)
          {
              instance = new Singleton();
          }
          return instance;
      }
      set
      {
          instance = value;
      }
  }

  public int Service01Price
  {
    get{return service01Price;}
    set{service01Price = value;}
  }

  public int Service02Price
  {
    get{return service02Price;}
    set{service02Price = value;}
  }

  public int Service03Price
  {
    get{return service03Price;}
    set{service03Price = value;}
  }

  public int Service04Price
  {
    get{return service04Price;}
    set{service04Price = value;}
  }

  public int Service05Price
  {
    get{return service05Price;}
    set{service05Price = value;}
  }

  public int Service06Price
  {
    get{return service06Price;}
    set{service06Price = value;}
  }

  public bool IsInOfficeRange
  {
    get{return isInOfficeRange;}
    set{isInOfficeRange = value;}
  }

}//class











//space
