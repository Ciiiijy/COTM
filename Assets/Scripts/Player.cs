using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public void Init()
    {
        Hide();
    }
    public void Show() 
    {
        this.gameObject.SetActive(true);
    }
    public void Hide() 
    {
        this.gameObject.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string name =collision.gameObject.name;
        GameMgr.I.npcs.dic_NPCs[name].ShowUI();


    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        string name = collision.gameObject.name;
        GameMgr.I.npcs.dic_NPCs[name].HideUI();
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //if检测：开启对话条件bool  && 你按下了按键E 
        //|____进来后，立即关闭对话条件，防止玩家频繁按E。
    
        if (name == "Rui")
        {
            //拿台词剧本开始对话内容。
        }
    }
}
