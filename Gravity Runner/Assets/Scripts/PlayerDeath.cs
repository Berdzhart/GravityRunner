using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;

public class PlayerDeath : MonoBehaviour
{   
    AudioPlayer audioPlayer;

    public bool playerHasDied = false;
    [SerializeField] OxygenBar oxygenBar;
    [SerializeField] float oxygenTankValue = 5f;
    
    [Header("Player Position")]
    public Transform player;
    private float initialOffsets = 0f;

    [Header ("Score Status")]
    public float finalScore = 0f;
    public TextMeshProUGUI finalText;


    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    { 
        initialOffsets = player.transform.position.x;
    }

    void Update()
    {

    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Obstacle")
        {
            target.gameObject.SetActive(false);
            PlayerDied();
        }
        else if(target.tag == "OxygenTank")
        {
            target.gameObject.SetActive(false);
            oxygenBar.oxygenValue += oxygenTankValue;
            audioPlayer.PlayOxygenClip();
        }
    }

    public void PlayerDied()
    {
        finalScore = player.transform.position.x;
        finalScore -= initialOffsets;
        finalText.text = finalScore.ToString("0");
        // transform.position = new Vector3(0, 1000, 0);
        GameObject.Find("Player").SetActive(false);
        audioPlayer.PlayDeathClip();
        playerHasDied = true; 
        this.enabled = false;
        oxygenBar.enabled = false;     
    }
}
