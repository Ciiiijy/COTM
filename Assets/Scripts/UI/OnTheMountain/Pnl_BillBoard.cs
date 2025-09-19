using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_BillBoard : MonoBehaviour
{
    public GameObject Billboard;
    public TextMeshProUGUI context;
    public GameObject monologue_warning;
    public Button Shutdown_warning;

    public void Init()
    {
        Hide();
        //monologue_warning?.gameObject.SetActive(false);

        Shutdown_warning.onClick.AddListener(() =>
        {
            this.gameObject.SetActive(false);
            //monologue_warning.SetActive(false);
        });
    }

    public void ShowBillBoard()
    {
        Show();
        
        this.gameObject.SetActive(true);
        UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
        //GameMgr.I.player.CanMove(false);
    }

    // Start is called before the first frame update
    void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
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
