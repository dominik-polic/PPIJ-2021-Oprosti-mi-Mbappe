using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI textCoins;
    public TextMeshProUGUI textHealth;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI textLives;
    int score;
    int lives = 3;
    float health = 100f;
    public int totalCoins = 10;
    public AudioSource skup;
    public AudioSource kaslj;
    public AudioSource crk;
    public AudioSource deathMusic;
    public AudioSource backgroundMusic;
    public bool isAlive = true;
    public Animator animator;
    public string levelPrefsName;
    public Transform player;
    private Vector3 startingPos;

    int unlocked = 1;

    string HIGHSCORE = "HIGHSCORE_CURRENT";
    string SCORE = "SCORE_CURRENT";
    string CRK_ENABLED = "CRK_ENABLED";
    string REMAINING_LIVES = "REMAINING_LIVES";
    int DISABLED = 0;
    int ENABLED = 1;

    private bool isShielded = false;


    int totalScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        startingPos = player.position;
        if (!PlayerPrefs.HasKey(REMAINING_LIVES))
        {
            PlayerPrefs.SetInt(REMAINING_LIVES, 3);
        }
        lives = PlayerPrefs.GetInt(REMAINING_LIVES);
        totalScore = PlayerPrefs.GetInt(SCORE);
        textScore.text = totalScore.ToString();
        textLives.text = lives.ToString();
        PlayerPrefs.SetInt(levelPrefsName, unlocked);        
        textCoins.text = "0/" + totalCoins.ToString();
    }

    public void ChangeScore(int coinValue)
    {
        skup.Play();
        score += coinValue;
        textCoins.text = score.ToString() + "/"+totalCoins.ToString();
        totalScore += 10;
        PlayerPrefs.SetInt(SCORE, totalScore);
        textScore.text = totalScore.ToString();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        animator.SetBool("isHurt",false);
    }

    IEnumerator ResetSceneAfterAnimation(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        lives = 3;
        textLives.text = lives.ToString();
        PlayerPrefs.SetInt(REMAINING_LIVES, lives);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator ResetPlayerAfterAnimation(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        player.position = startingPos;
        animator.SetBool("isAlive", true);
        health = 100;
        isAlive = true;
        isShielded = true;
        yield return new WaitForSeconds(3);
        isShielded = false;
    }

    public void DoDamage(float damage)
    {
        if (!isAlive || isShielded) return;

        if (health > 0)
        {
            health -= damage;
            animator.SetBool("isHurt", true);
            StartCoroutine(ExecuteAfterTime(1));

            kaslj.Play();

        }

        if (health <= 0)
        {
            health = 0;
            //Crk            
            if (isAlive == true) {
                textHealth.text = "CRK!";
                isAlive = false;
                animator.SetBool("isAlive", false);
                crk.Play();

                if (lives > 1)
                {
                    lives--;
                    textLives.text = lives.ToString();
                    PlayerPrefs.SetInt(REMAINING_LIVES, lives);
                    StartCoroutine(ResetPlayerAfterAnimation(1));
                }
                else
                {

                    if (totalScore > PlayerPrefs.GetInt(HIGHSCORE))
                    {
                        PlayerPrefs.SetInt(HIGHSCORE, totalScore);                        
                    }
                    PlayerPrefs.SetInt(SCORE, 0);
                    score = 0;

                    if (PlayerPrefs.GetInt(CRK_ENABLED) != DISABLED)
                    {
                        backgroundMusic.Stop();
                        deathMusic.Play();
                        StartCoroutine(ResetSceneAfterAnimation(16));
                    }
                    else
                    {
                        StartCoroutine(ResetSceneAfterAnimation(1));
                    }
                }
                
            }
        }
        else
        {
            textHealth.text = "" + health.ToString();
        }
        
    }

    public void enterPortal(string level)
    {
        //TODO maybe not allow if not enough coins collected(?)
        SceneManager.LoadScene(level);

    }
}
