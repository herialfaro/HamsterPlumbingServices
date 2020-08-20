using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScreenScript : MonoBehaviour
{
    public GameObject succesPanel;
    public GameObject failText;
    public Text price;
    // Start is called before the first frame update
    void Start()
    {
        CheckUbicationResult();
    }

    void CheckUbicationResult()
    {
      if(Singleton.Instance.IsInOfficeRange)
      {
        succesPanel.SetActive(true);
        failText.SetActive(false);
        ShowFinalPrice();
      } else
      {
        failText.SetActive(true);
        succesPanel.SetActive(false);
      }
    }

    void ShowFinalPrice()
    {
      int finalPrice = Singleton.Instance.Service01Price + Singleton.Instance.Service02Price + Singleton.Instance.Service03Price +
                       Singleton.Instance.Service04Price + Singleton.Instance.Service05Price + Singleton.Instance.Service06Price;
      price.text = "You are going to pay " + finalPrice.ToString() + "$" + " to the plumber.";
    }

    public void ReturnToMainScreen()
    {
      SceneManager.LoadScene("MainScreen");
    }
}//class
