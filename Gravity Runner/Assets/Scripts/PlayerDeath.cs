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
    public bool playerHasDied = false;
    [SerializeField] OxygenBar oxygenBar;
    [SerializeField] float oxygenTankValue = 5f;
    
    [Header("Player Position")]
    public Transform player;
    private float initialOffsets = 0f;

    [Header ("Score Status")]
    public float finalScore = 0f;
    public TextMeshProUGUI finalText;

    bool shieldActive = false;
    void Awake()
    {
        
    }

    void Start()
    { 
        initialOffsets = player.transform.position.x;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            shieldActive = true;
        }else
        {
            shieldActive = false;
        }
    }
    
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Obstacle" && !shieldActive)
        {
            target.gameObject.SetActive(false);
            Debug.Log("Player hit");
            PlayerDied();
        }
        else if(target.tag == "OxygenTank")
        {
            target.gameObject.SetActive(false);
            oxygenBar.oxygenValue += oxygenTankValue;
        }
    }

    public void PlayerDied()
    {
        finalScore = player.transform.position.x;
        finalScore -= initialOffsets;
        finalText.text = finalScore.ToString("0");
        // transform.position = new Vector3(0, 1000, 0);
        GameObject.Find("Player").SetActive(false);
        playerHasDied = true; 
        this.enabled = false;
        oxygenBar.enabled = false;     
    }
}
