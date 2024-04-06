using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float maxX;
    public Transform spawnPoint;
    public GameObject Block;
    public float repeatRate;

    bool gameStarting = false;

    public GameObject tapText;
    public Text scoreText;
    private int score;

    private void Start()
    {
        scoreText.enabled = false;
    }
    void Update()
    {

        if (Input.GetMouseButton(0) && !gameStarting)
        {
            SpawnStarting();

            gameStarting = true;

            tapText.SetActive(false);
            scoreText.enabled = true;
        }
    }

    private void SpawnStarting()
    {
        InvokeRepeating("SpawnPoint", 0.5f, repeatRate);

    }

    private void SpawnPoint()
    {
        Vector3 spawnPos = spawnPoint.position;
        
        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(Block, spawnPos, Quaternion.identity);

        score++;

        scoreText.text = score.ToString();
    }
}
