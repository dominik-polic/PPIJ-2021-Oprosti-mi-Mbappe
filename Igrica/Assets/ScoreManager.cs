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
    int score;
    float health = 100f;
    public int totalCoins = 10;
    public AudioSource skup;
    public AudioSource kaslj;
    public AudioSource crk;
    public bool isAlive = true;
    public Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) instance = this;
        textCoins.text = "0/" + totalCoins.ToString();
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        textCoins.text = score.ToString() + "/"+totalCoins.ToString();
        skup.Play();
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        animator.SetBool("isHurt",false);
    }

    IEnumerator ResetSceneAfterAnimation()
    {
        yield return new WaitForSeconds(2);
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
            textHealth.text = "CRK!";
            crk.Play();
            isAlive = false;
            StartCoroutine(ResetSceneAfterAnimation());
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
