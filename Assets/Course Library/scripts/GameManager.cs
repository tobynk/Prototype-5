using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoretext;
    public List<GameObject> targets;
    private float spawnRate=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        score=0;
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore(0);
    }

    IEnumerator SpawnTarget()
    {
        while (true)
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
}
