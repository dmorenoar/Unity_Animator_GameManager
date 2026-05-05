using System;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lives;

    [SerializeField]
    private TMP_Text textLives;

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = 3;
        textLives.text = "x " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddLive()
    {
        lives++;
        textLives.text = "x " + lives;
    }


}
