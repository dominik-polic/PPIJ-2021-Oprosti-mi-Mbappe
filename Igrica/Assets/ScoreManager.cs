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
    int score;
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

    int unlocked = 1;

    string HIGHSCORE = "HIGHSCORE_CURRENT";
    string SCORE = "SCORE_CURRENT";

    int totalScore = 0;


    // Start is called before the first frame update
    void Start()
    {
        totalScore = PlayerPrefs.GetInt(SCORE);
        textScore.text = totalScore.ToString();            

        PlayerPrefs.SetInt(levelPrefsName, unlocked);
        if (instance == null) instance = this;
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

    IEnumerator ResetSceneAfterAnimation()
    {
        yield return new WaitForSeconds(16);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DoDamage(float damage)
    {
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
                backgroundMusic.Stop();
                crk.Play();
                deathMusic.Play();

                if(totalScore > PlayerPrefs.GetInt(HIGHSCORE))
                {
                    PlayerPrefs.SetInt(HIGHSCORE, totalScore);
                    PlayerPrefs.SetInt(SCORE, 0);
                }

                StartCoroutine(ResetSceneAfterAnimation());
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
