using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int lives;

    [SerializeField]
    private TMP_Text textLives;

    public static GameManager instance;

    private AudioSource audioSource;

    private GameObject spawnPlayer, player;

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

        audioSource = GetComponent<AudioSource>();
        spawnPlayer = GameObject.FindGameObjectWithTag("SpawnPlayer");
        player = GameObject.FindGameObjectWithTag("Player");

        player.transform.position = spawnPlayer.transform.position;

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

    public void PlaySound(AudioClip clip)
    {
        // Aquí puedes implementar la lógica para reproducir un sonido específico
        // Por ejemplo, podrías usar AudioSource para reproducir un clip de audio
        audioSource.clip = clip;
        audioSource.Play();
    }


}
