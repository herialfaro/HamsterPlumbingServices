using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ServicesScript : MonoBehaviour
{
    public Toggle toggleService01;
    public Toggle toggleService02;
    public Toggle toggleService03;
    public Toggle toggleService04;
    public Toggle toggleService05;
    public Toggle toggleService06;

    public GameObject LoadingScreen;

    void Start()
    {
      Singleton.Instance.Service01Price = 0;
      Singleton.Instance.Service02Price = 0;
      Singleton.Instance.Service03Price = 0;
      Singleton.Instance.Service04Price = 0;
      Singleton.Instance.Service05Price = 0;
      Singleton.Instance.Service06Price = 0;
      Singleton.Instance.IsInOfficeRange = false;

      StartCoroutine(AppLoaded(5f));
    }

    public void Service01Selected()
    {
      if(toggleService01.isOn) {
        Singleton.Instance.Service01Price += 500;
      } else {
        Singleton.Instance.Service01Price -= 500;
      }
    }

    public void Service02Selected()
    {
      if(toggleService02.isOn) {
        Singleton.Instance.Service02Price += 400;
      } else {
        Singleton.Instance.Service02Price -= 400;
      }
    }

    public void Service03Selected()
    {
      if(toggleService03.isOn) {
        Singleton.Instance.Service03Price += 250;
      } else {
        Singleton.Instance.Service03Price -= 250;
      }
    }

    public void Service04Selected()
    {
      if(toggleService04.isOn) {
        Singleton.Instance.Service04Price += 100;
      } else {
        Singleton.Instance.Service04Price -= 100;
      }
    }

    public void Service05Selected()
    {
      if(toggleService05.isOn) {
        Singleton.Instance.Service05Price += 200;
      } else {
        Singleton.Instance.Service05Price -= 200;
      }
    }

    public void Service06Selected()
    {
      if(toggleService06.isOn) {
        Singleton.Instance.Service06Price += 550;
      } else {
        Singleton.Instance.Service06Price -= 550;
      }
    }

    public void GoToCheckUbication()
    {
      SceneManager.LoadScene("CheckUbicationScreen");
    }

    IEnumerator AppLoaded(float _timer)
    {
      yield return new WaitForSeconds(_timer);
      LoadingScreen.SetActive(false);
    }

}//class
