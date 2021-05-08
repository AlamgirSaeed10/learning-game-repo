using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SavePrefs : MonoBehaviour
{
    public Text txt;

    void Start()
    {
        GetPrefs();
    }

    public void GetPrefs() {
        txt.text = PlayerPrefs.GetString("distance").ToString();

    }

    public void BackScene() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prectice Scene");
    }


}
