using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoretext;
    public TextMeshProUGUI gameoverext;
    public bool IsGameActive;
    public Button restartbutton;
    public List<GameObject> targets;
    private float spawnRate=1.0f;
    public GameObject titlescreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (IsGameActive)
        {  
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0,targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoretoadd)
    {
        score += scoretoadd;
        scoretext.text="Score:"+score;
    }

    public void Gameober()
    {
        gameoverext.gameObject.SetActive(true);
        IsGameActive=false;
        restartbutton.gameObject.SetActive(true);
    }

    public void restartgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void startgame(int difficullty)
    {
        IsGameActive=true;
        StartCoroutine(SpawnTarget());
        score=0;
        titlescreen.gameObject.SetActive(false);
        spawnRate/=difficullty;
    }
}
