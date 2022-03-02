using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int life = 5;
    public Text scoreText;
    public Text finalScoreText;
    public Text submitScoreText;
    public GameObject gameOverMenu;
    public GameObject[] enemies;
    public Slider lifeSlider;

    private void Start()
    {
        scoreText.text = "SCORE: " + score;
        Time.timeScale = 0;
        enemies = new GameObject[4];
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = GetComponent<SpawnerEnemy>().enemies[i];
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        lifeSlider.transform.position = Camera.main.WorldToScreenPoint(this.transform.position);
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "SCORE: " + score;
        Debug.Log("<color=green>Score is: " + score + "</color> and <color=red> life is: " + life + "</color>");
    }

    public void TakeLife()
    {
        life--;
        lifeSlider.value = life;
        //lifeText.text = "LIFE: " + life + " / 5";
        Debug.Log("<color=green>Score is: " + score + "</color> and <color=red> life is: " + life + "</color>");
        if (life <= 0)
        {
            gameOverMenu.SetActive(true);
            finalScoreText.text = "FINAL SCORE: " + score;
            PlayerPrefs.SetInt("Highscore", score);
            submitScoreText.text = score.ToString();
            Time.timeScale = 0;
            
            Debug.Log("<color=red>Game over! Final score: " + score + "</color>");
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            for (int i = 0; i < enemies.Length; i++)
            {

                enemies[i].GetComponent<EnemyMovement>().enabled = false;
            }
            Application.Quit();
        }
    }
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Quitting game");
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        for (int i = 0; i < enemies.Length; i++)
        {
            
            enemies[i].GetComponent<EnemyMovement>().enabled = false;
        }
        
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<EnemyMovement>().enabled = true;
        }
       
    }
    public void StartGame()
    {
        Time.timeScale = 1;
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(0);
    }
}
