using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using JetBrains.Annotations;
public class ShieldActivator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Shield;
    public float cooldowntime = 4.0f;
    public float nextcooldown = 0.0f;
    void Start()
    {
        Shield = GameObject.Find("Shield");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse1) && Time.time > nextcooldown)
        {
            Shield.SetActive(true);
            nextcooldown = Time.time + cooldowntime;
        }else
        {
            Shield.SetActive(false);

        }
         
    }
    void OnTriggerEnter2D(Collider2D ShieldHit)
    {
        if(ShieldHit.tag == "Obstacle")
        {
            ShieldHit.gameObject.SetActive(false);
        }
    }
}
