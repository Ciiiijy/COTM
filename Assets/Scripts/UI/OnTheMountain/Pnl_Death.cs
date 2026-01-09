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
    public Image img_faint;
    public Image img_back;
    public Image black;
    public Image RedBG;
    public GameObject Faint;
    public TextMeshProUGUI Death;


    public void Init()
    {
        Hide();
        RedFrame?.gameObject.SetActive(false);
        Faint?.SetActive(false);
        RedBG?.gameObject.SetActive(false);
        Death?.gameObject.SetActive(false);

        //AnimDeath();
    }

    public void AnimWarning()
    {
        RedFrame?.gameObject.SetActive(true);

        print("Sanity warning.");

        DOTween.Sequence()
            .Append(RedFrame.DOFade(0, 0.00001f))

            //RedFrameÉÁË¸
            .Append(RedFrame.DOFade(1, 0.5f))
            .Append(RedFrame.DOFade(0, 0.5f))
            .SetLoops(-1, LoopType.Restart);
    }
    
    public void AnimDeath()
    {
        RedFrame?.gameObject.SetActive(false);

        Faint?.gameObject.SetActive(true);

        print("Player died.");

        DOTween.Sequence()
            .Append(img_faint.DOFade(0, 0.00001f))
            .Append(img_back.DOFade(0, 0.00001f))
            .Append(black.DOFade(0, 0.00001f))

            .Append(img_faint.DOFade(1, 0.5f))
            .Join(img_back.DOFade(1, 0.5f))
            .Join(black.DOFade(1, 0.5f))

            .AppendInterval(0.5f)
            //img_backÂýÂý·Å´ó
            .Append(img_back.rectTransform.DOScale(new Vector3(1.25f, 1.25f, 1.25f), 5f))

            .AppendCallback(() =>
            {
                UIMgr.I.ui_onTheMountain.pnl_death.Faint.gameObject.SetActive(false);
                print("Player is laying on the ground.");


                GameMgr.I.player.CharacterImg.gameObject.SetActive(false);
                GameMgr.I.player.CharacterDun.gameObject.SetActive(true);

                GameMgr.I.player.CanMove(false);
            });
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
