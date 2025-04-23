using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player I;
    PlayerMove playerMove;

    public bool canTalk;
    public string npc_Name;

    public void Init()
    {
        I = this;
        Hide();
        playerMove = GetComponent<PlayerMove>();
    }
    public void Show()
    {
        this.gameObject.SetActive(true);
    }
    public void Hide()
    {
        this.gameObject.SetActive(false);
    }

    public void SetPosition(Vector2 localPosition)
    {
        this.transform.position = localPosition;
    }


    public void CanTalk(bool canTalk)
    {
        this.canTalk = canTalk;
    }
    public void CanMove(bool canMove)
    {
        playerMove.CanMove(canMove);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        CanTalk(true);

        string name = collision.gameObject.name;

        GameMgr.I.npcs.dic_NPCs[name]?.ShowUI();
        npc_Name = name;

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        CanTalk(false);

        string name = collision.gameObject.name;
        GameMgr.I.npcs.dic_NPCs[name]?.HideUI();
        npc_Name = "";//string.Empty;

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall_L_BusStation") 
        {
            print("前面就是商业街，我应该先回家。");
        }
        if (collision.gameObject.name == "Wall_R_BusStation")
        {
            print("是否前往深山老家？Y/N");

        }

    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall_L_BusStation")
        {
            print("我不往前走了，转身回来。");
        }
        if (collision.gameObject.name == "Wall_R_BusStation")
        {
            print("暂时留在公交站，再观察一下吧。");
        }
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.canTalk && Input.GetKeyUp(KeyCode.E))
        {
            //|____进来后，立即关闭对话条件，防止玩家频繁按E。
            canTalk = false;
            playerMove.CanMove(false);

            //判断遇到的是谁
            if (npc_Name == "Rui")
            {
                //拿到台词剧本。
                UIMgr.I.ui_Chat.SetList(LineBooks.I.list_Rui_BusStation);
                UI_Chat.I.Show();
            }
        }
    }
}
