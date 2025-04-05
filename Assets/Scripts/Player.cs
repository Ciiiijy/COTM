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

        //if��⣺�����Ի�����bool  && �㰴���˰���E 
        //|____�����������رնԻ���������ֹ���Ƶ����E��
    
        if (name == "Rui")
        {
            //��̨�ʾ籾��ʼ�Ի����ݡ�
        }
    }
}
