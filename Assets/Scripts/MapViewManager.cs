using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MapViewManager : MonoBehaviour
{
    public RawImage img;
    bool mapDrawn = false;
    uint zoom;
    public string APIKEY;
    public int Width, Height;
    public enum MapType { Roadmap, Satellite, Hybrid };
    public MapType MapSelection;
    public int scale;

    GPSLocationFinder LocationFinderInstance;
    DistanceCalculator DistanceCalculatorInstance;
    GoogleMapsAPIManager GoogleMapsManager;

    //INFORMATION DISPLAYED, THIS WILL BE REMOVED LATER
    public float office_lat, office_lon;
    private float current_lat, current_lon;
    private uint distance;

    // Start is called before the first frame update
    void Start()
    {
        /////////CREATING CLASS INSTANCES/////////////////////////////////////////
        GameObject GPSLF = new GameObject();
        GPSLF.AddComponent<GPSLocationFinder>();
        LocationFinderInstance = GPSLF.GetComponent<GPSLocationFinder>();

        GameObject DC = new GameObject();
        DC.AddComponent<DistanceCalculator>();
        DistanceCalculatorInstance = DC.GetComponent<DistanceCalculator>();

        GameObject GMM = new GameObject();
        GMM.AddComponent<GoogleMapsAPIManager>();
        GoogleMapsManager = GMM.GetComponent<GoogleMapsAPIManager>();
        /////////////////////////////////////////////////////////////////////////

        LocationFinderInstance.RequestGPSPermission();
        StartCoroutine(LocationFinderInstance.InitializeLocation());

        //SET COORDINATES FOR HAMSTER PLUMBING OFFICES
        DistanceCalculatorInstance.lat1 = office_lat;
        DistanceCalculatorInstance.lon1 = office_lon;

        //GoogleMapsManager.img = gameObject.GetComponent<RawImage>();
        StartCoroutine(CheckDistance(5f));
    }

    // Update is called once per frame
    void Update()
    {
        //SET COORDINATES FOR USER DEVICE
        current_lat = LocationFinderInstance.device_latitude;
        current_lon = LocationFinderInstance.device_longitude;

        DistanceCalculatorInstance.lat2 = current_lat;
        DistanceCalculatorInstance.lon2 = current_lon;

        distance = DistanceCalculatorInstance.CalculateDistance();

        if(!mapDrawn && distance < 100000)
        {
            //DRAW GOOGLE MAP
            zoom = GoogleMapsManager.DetermineZoom(distance);
            StartCoroutine(GoogleMapsManager.Map(current_lat, current_lon, office_lat, office_lon,APIKEY,zoom,Width,Height,MapSelection.ToString(),scale,img));
            mapDrawn = true;
        }
    }

    IEnumerator CheckDistance(float _timer)
    {
      yield return new WaitForSeconds(_timer);
      if(distance <= 10000) {
        //Plumber service available :)
        Singleton.Instance.IsInOfficeRange = true;
      } else {
        //Plumber service not available :(
        Singleton.Instance.IsInOfficeRange = false;
      }
      yield return new WaitForSeconds(1.5f);
      SceneManager.LoadScene("FinalScreen");
    }
}//class
