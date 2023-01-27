using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float spawnRate = 3f; //spawnrate 
    public int score;  //score (TMP)
    public GameObject targets;
    public GameObject targets1;
    public TextMeshProUGUI scoreText;
    private GameManager Gamemanager;
    public GameObject targets2;

    
    private void OnEnable() 
    {

       
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());

        score = 0;
        UpdateScore(0);
    }

    // Update is called once per frame
    void Update()
    {
        
     
    }
    IEnumerator SpawnTarget()
    {
        while (true) 
        {
            yield return new WaitForSeconds(spawnRate);

            spawnRate *= .97f;

            var position = new Vector3((345), 2, Random.Range(-2.5f, 2.5f));
            var position2 = new Vector3((208), 10, Random.Range(-5.5f, 5.5f));
            var position3 = new Vector3((-235), 2, Random.Range(-3.5f, 3.5f));
            Instantiate(targets, position, targets.transform.rotation);
            Instantiate(targets1, position2, targets1.transform.rotation);
            Instantiate(targets2, position3, targets2.transform.rotation);


        }
    }
    public void UpdateScore(int scoreToAdd)
    {

        score += scoreToAdd;
        scoreText.text = "Score: " + score;

        
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    } 
    public void StartGame()
    {
        SceneManager.LoadScene("project");
    }
    public void RestartGameM()
    {
        SceneManager.LoadScene("TitleScreen");
    }


}
