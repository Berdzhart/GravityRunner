using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;
public class Shield : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnTriggerEnter2D(Collider2D ShieldHit)
    {
        if(ShieldHit.tag == "Obstacle")
        {
            ShieldHit.gameObject.SetActive(false);
            Debug.Log("Hit Obstacle");
        }
    }
}
