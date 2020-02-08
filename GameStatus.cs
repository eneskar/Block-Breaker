using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int pointsPerBlockDestroyed = 83;

    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;


    private void Awake(){
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if(gameStatusCount > 1){
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start(){
        scoreText.text = currentScore.ToString();
    }

    void Update(){
        
    }

    public void AddToScore(){
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void Reset(){
        Destroy(gameObject);
    }
}
