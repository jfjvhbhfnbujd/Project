using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour
{
    public TextMeshProUGUI highScoreText;
    public int _score;
    public int highscore;
    private GameManager Gamemanager;
    
    
    // Start is called before the first frame update
    void Start()
    {

        Gamemanager = GameObject.Find("GameManager").GetComponent<GameManager>();
        GetComponent("HighScore");
        
        highscore=PlayerPrefs.GetInt("HighScore");

        if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            highScoreText.text = "HighScore: " + highscore;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void SavePrefs()
    {
        PlayerPrefs.SetInt("HighScore", Gamemanager.score);
        Debug.Log("Saved! " + PlayerPrefs.GetInt("HighScore"));
    }
   
}
