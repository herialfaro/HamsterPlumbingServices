using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class GPSLocationFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public float device_latitude;
    public float device_longitude;

    public void RequestGPSPermission()
    {
        while (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            //REQUESTS PERMISSION FOR GPS USE
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }
    }
    public IEnumerator InitializeLocation()
    {
        Input.location.Start();
        int maxtimeWait = 20;
        while (Input.location.status == LocationServiceStatus.Initializing && maxtimeWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxtimeWait--;
        }
        if (maxtimeWait <= 0)
        {
            //TIMEOUT
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            //ERROR: UNABLE TO DETECT LOCATION
            yield break;
        }

        device_latitude = Input.location.lastData.latitude;
        device_longitude = Input.location.lastData.longitude;

        yield break;
    }
}
