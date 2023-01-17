using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float spawnRate;
    private int score;
    public GameObject targets;
    public TextMeshProUGUI scoreText;
    private GameManager Gamemanager;
    
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
            var position = new Vector3((345), 2, Random.Range(-2.5f, 2.5f));
            Instantiate(targets, position, targets.transform.rotation);
        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        
        score += scoreToAdd; 
        scoreText.text = "Score: " + score;
    }
    
}
