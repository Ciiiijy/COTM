using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UI;

public class UI_OnTheMountain : MonoBehaviour, SceneFunc
{
    public Button btn_L;
    public Button btn_R;
    public Button btn_back;
    private GameObject currentObj;
    public Pnl_BillBoard pnl_billBoard;
    public Pnl_Death pnl_death;
    public Pnl_Temple pnl_temple;

    public void Init()
    {
        pnl_billBoard.Init();
        pnl_death.Init();
        pnl_temple.Init();

        Hide();

        btn_L?.gameObject.SetActive(false);
        btn_R?.gameObject.SetActive(false);
        

        btn_back.onClick.AddListener(() =>
        {
            btn_back.gameObject.SetActive(false);
            currentObj?.SetActive(false);
            GameMgr.I.player.CanMove(true);
        });
    }


    public void Show()
    {
        gameObject.SetActive(true);
        Player.I.playerMove.SetPlayerMove(true);
    }

    void LeftKey()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //Pnl_Death.AnimDeath();
        }
    }

    //private void StopCoroutine(Action animDeath)
    //{
    //    throw new NotImplementedException();
    //}

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LeftKey();
    }
}
