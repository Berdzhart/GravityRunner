using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;

public class ShieldCooldown : MonoBehaviour
{
    [SerializeField]
    private Image imageCD;
    public float fillAmount = 0.0f;
    [SerializeField] private TMP_Text textCD;

    // variabel untuk timer shield
    private bool isCD = false;
    private float CDtime = 4.0f;
    private float CDTimer = 0.0f;
    void Start()
    {
        textCD.gameObject.SetActive(false);
        fillAmount =  0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CDtime);
        Debug.Log(CDTimer);
        if(Input.GetKey(KeyCode.Mouse1) && !isCD)
        {
            isCD = true;
            textCD.gameObject.SetActive(true);
            CDTimer = CDtime;
        }
        cooldown();
    }
    void cooldown(){
        CDTimer -= Time.deltaTime;
        if (CDTimer < 0.0f){
            isCD =false;
            textCD.gameObject.SetActive(false);
            fillAmount = 0.0f;
        }else{
            textCD.text = Mathf.RoundToInt(CDTimer).ToString();
            fillAmount = CDTimer/CDtime;
        }
    }
    public bool useAbility(){
        if(isCD){
            return false;
        }else{
            isCD = true;
            textCD.gameObject.SetActive(true);
            CDTimer = CDtime;
            return true;
        }
    }
}
