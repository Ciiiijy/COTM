using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Death : MonoBehaviour
{
    public Image RedFrame;
    public Image San1;
    public Image San2;
    public Image San3;
    public Image San4;
    //public Image Faint;
    public Image RedBG;
    public TextMeshProUGUI Death;


    public void Init()
    {
        Hide();
        RedFrame?.gameObject.SetActive(false);
        San1?.gameObject.SetActive(false);
        San2?.gameObject.SetActive(false);
        San3?.gameObject.SetActive(false);
        San4?.gameObject.SetActive(false);
        //Faint?.gameObject.SetActive(false);
        RedBG?.gameObject.SetActive(false);
        Death?.gameObject.SetActive(false);

        //AnimDeath();
    }

    private void AnimDeath()
    {
        RedFrame?.gameObject.SetActive(true);
        San1?.gameObject.SetActive(true);
        San2?.gameObject.SetActive(true);
        San3?.gameObject.SetActive(true);
        San4?.gameObject.SetActive(true);
        //Faint?.gameObject.SetActive(true);
        RedBG?.gameObject.SetActive(true);
        Death?.gameObject.SetActive(true);

        print("Player died.");

        DOTween.Sequence()
            .Append(RedFrame.DOFade(0, 0.00001f))
            .Append(San1.DOFade(0, 0.00001f))
            .Append(San2.DOFade(0, 0.00001f))
            .Append(San3.DOFade(0, 0.00001f))
            .Append(San4.DOFade(0, 0.00001f))
            .Append(RedBG.DOFade(0, 0.00001f))
            .Append(Death.DOFade(0, 0.00001f))

            //RedFrameÉÁË¸
            .Append(RedFrame.DOFade(1,0.5f))
            .Append(RedFrame.DOFade(0, 0.5f))
            .SetLoops(-1,LoopType.Restart)
            
            .Append(San1.DOFade(1, 0.5f))
            .AppendInterval(0.5f)
            .Join(San1.DOFade(0, 0.00001f))

            .Append(San2.DOFade(1, 0.5f))
            .AppendInterval(0.5f)
            .Join(San2.DOFade(0, 0.00001f))

            .Append(San3.DOFade(1, 0.5f))
            .AppendInterval(0.5f)
            .Join(San3.DOFade(0, 0.00001f))

            .Append(San4.DOFade(1, 0.5f))
            .Join(San4.DOFade(0, 0.00001f))

            .Append(RedBG.DOFade(1, 0.5f))
            .Join(Death.DOFade(1, 0.5f))
            .AppendInterval(2f);

            //.AppendCallback(() =>
            //{
            //    process.gameObject.SetActive(false);
            //    standOnTheChair.gameObject.SetActive(false);
            //});
        //GameMgr.I.oldHouse.canSetClock = true;
    }
    //public void ShowDeath()
    //{
    //    if (GameMgr.I.onTheMountain.walkLeft)
    //    {
    //        Show();
    //    }
    //    this.gameObject.SetActive(true);
    //    UIMgr.I.ui_oldHouse.ShowBtnBack(this.gameObject);
    //    GameMgr.I.player.CanMove(false);
    //}

    // Start is called before the first frame update
    public void Show()
    {
        if (GameMgr.I.onTheMountain.isLeftKeyPressed)
        {
            Show();
        }
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

    //internal static void AnimDeath()
    //{
    //    throw new NotImplementedException();
    //}
}
