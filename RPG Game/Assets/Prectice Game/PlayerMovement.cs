using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Text text;
    public Text textDist;
    int move = 0;
    float timer = 50f;

    public Transform target;
    Vector3 posX;
    // Start is called before the first frame update
    void Start()
    {
        posX = target.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (timer <= 0.1f)
        {
            move = 0;
            SavePrefs();
            GetPrefs();
        }
        else
        {
            Timer();
            FindDistance();
            if (move == 1)
            {
                MoveFroward();
            }
            if (move == 2)
            {
                MoveBackward();
            }
            if (move == 3)
            {
                MoveLeft();
            }
            if (move == 4)
            {
                MoveRight();
            }if (move == 5)
            {
                JumpUp();
            }
        }
   
    }
    public void MoveFroward() {
        move = 1;
        transform.Translate(0f, 0f,2f);
    }
    public void MoveBackward() {
        move = 2;
        transform.Translate(0f, 0f,-2f);
    }
    public void MoveLeft() {
        move = 3;
        transform.Translate(2f, 0f,0f);
    }
    public void MoveRight() {
        move = 4;
        transform.Translate(-2f, 0f,0f);
    }
    public void JumpUp() {
        move = 5;
        transform.Translate(0f,2f,0f);
    }

    public void Timer()
    {
        timer -= Time.deltaTime;
        text.text = timer.ToString();
    }

    public void FindDistance() {
        textDist.text = Vector3.Distance(posX, transform.position).ToString("F1") + " /m";
    }

    public void SavePrefs() {
        PlayerPrefs.SetString("distance",textDist.text.ToString());
        PlayerPrefs.Save();
    }
    public void GetPrefs() {
        Debug.Log("Player Distance = "+ PlayerPrefs.GetString("distance"));
    }
    public void SceneMovement() {
        UnityEngine.SceneManagement.SceneManager.LoadScene("SecondScene");
    }




}
