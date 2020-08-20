using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GoogleMapsAPIManager : MonoBehaviour
{
    string url;

	public IEnumerator Map(float lat1, float lon1, float lat2, float lon2, string APIKEY,
		uint zoom, int mapWidth, int mapHeight, string mapSelected, int scale, RawImage img)
	{
		///url = "https://maps.googleapis.com/maps/api/staticmap?center=20.604347,-100.362266&path=color:0xff0000ff|weight:3|20.604347,-100.362266|20.589581,-100.362179&zoom=14&size=640x640&scale=0&maptype=Roadmap&markers=color:blue%7Clabel:B%7C20.604347,-100.362266&markers=color:green%7Clabel:A%7C20.589581,-100.362179&key=AIzaSyAHEjkCiSXHd7pdZ5QdTgRygd2beu7xMI0";

		url = "https://maps.googleapis.com/maps/api/staticmap?center=" +
			lat1 + "," + lon1 +
			"&path=color:0xff0000ff|weight:3|" +
			lat1 + "," + lon1 +
			"|" + lat2 + "," + lon2 +
			"&zoom=" + zoom +
			"&size=" + mapWidth + "x" + mapHeight +
			"&scale=" + scale +
			"&maptype=" + mapSelected +
			"&markers=color:blue%7Clabel:B%7C" +
			lat1 + "," + lon1 +
			"&markers=color:green%7Clabel:A%7C" +
			lat2 + "," + lon2 +
			"&key=" + APIKEY;

		UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
		yield return www.SendWebRequest();
		img.texture = DownloadHandlerTexture.GetContent(www);
		img.SetNativeSize();
	}

	public uint DetermineZoom(uint distance)
	{
		uint zoom;
		if (distance >= 0 && distance < 1000)
		{
			zoom = 15;
		}
		else if(distance >= 1000 && distance < 2000)
		{
			zoom = 14;
		}
		else if (distance >= 2000 && distance < 5000)
		{
			zoom = 13;
		}
		else if (distance >= 5000 && distance < 10000)
		{
			zoom = 12;
		}
		else
		{
			zoom = 11;
		}
		return zoom;
	}
}
