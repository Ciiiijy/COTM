using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public GameObject talkUI_Img;

    public void Init()
    {
        HideUI();
        HideNPC_Img();
    }

    public void ShowUI() 
    {
        talkUI_Img.SetActive(true);
    }
    public void HideUI() 
    {
        talkUI_Img.SetActive(false);
    }
    public void ShowNPC_Img() 
    {
        this.gameObject.SetActive(true);
    }
    public void HideNPC_Img() 
    {
        this.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
