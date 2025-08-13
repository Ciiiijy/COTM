using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Chair : MonoBehaviour
{
    public Button btn_MoveTheChair;
    public GameObject process;
    public GameObject chairHand;


    public void Init()
    {
        //GameMgr.I.oldHouse.canSetClock = false;
        btn_MoveTheChair.gameObject.SetActive(false);

        btn_MoveTheChair.onClick.AddListener(() =>
        {
            btn_MoveTheChair.gameObject.SetActive(false);
            GameMgr.I.oldHouse.canSetClock = true;

            AnimMoveChair();
           

        });
    }

    private void AnimMoveChair()
    {
        process.gameObject.SetActive(true);
        //chairHand.gameObject.SetActive(true);
        DOTween.Sequence()
            .Append(chairHand.transform.DOLocalMoveX(880f,2f));

    }
    private void StandingOnTheChair()
    {

    }

    public void TryMoveChair()
    {
        Show();
        if (GameMgr.I.oldHouse.canMoveChair)
        {
            //play a animation(moving a chair).
            //set the character(girl) on the chair. 

            btn_MoveTheChair.gameObject.SetActive(true);

            this.gameObject.SetActive(true);
            //UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
            //GameMgr.I.player.CanMove(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }
    void Show()
    {
        this.gameObject.SetActive(true);
    }
    void Hide()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}