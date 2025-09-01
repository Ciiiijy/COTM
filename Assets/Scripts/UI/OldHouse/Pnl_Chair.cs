using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Pnl_Chair : MonoBehaviour
{
    public Button btn_MoveTheChair;
    public GameObject process;
    public GameObject standOnTheChair;
    public TextMeshProUGUI monologue_MovingChair;
    public Image chairHand;
    public Image bg_whiteArea;
    public Image stand1;
    public Image stand2;
    public Image stand3;


    public void Init()
    {
        this.gameObject.SetActive(true);

        //GameMgr.I.oldHouse.canSetClock = false;
        btn_MoveTheChair.gameObject.SetActive(false);
        process.gameObject.SetActive(false);
        standOnTheChair.gameObject.SetActive(false);
        //characterBack.gameObject.SetActive(false);

        btn_MoveTheChair.onClick.AddListener(() =>
        {
            btn_MoveTheChair.gameObject.SetActive(false);

            GameMgr.I.player.transform.localPosition = new Vector3(10.1f,-1.81f);
            Player.I.gameObject.SetActive(false);
            GameMgr.I.oldHouse.characterBack.gameObject.SetActive(true);
            //characterBack.gameObject.SetActive(true);
            //characterBack.transform.localPosition = new Vector3(1817, 570);

            AnimMoveChair();
        });
    }

    private void AnimMoveChair(System.Action onComplete = null)
    {
        process.gameObject.SetActive(true);
        standOnTheChair.gameObject.SetActive(true);
        GameMgr.I.oldHouse.characterBack.SetActive(true);
        
        print("Enter Anim Move Chair." );

        DOTween.Sequence()
            .Append(stand1.DOFade(0, 0.00001f))
            //.Append(stand2.DOFade(0, 0.00001f))
            //.Append(stand3.DOFade(0, 0.00001f))

            .Append(chairHand.transform.DOLocalMoveX(-200f, 1f))
            .AppendInterval(0.5f)
            .Append(chairHand.transform.DOLocalMoveX(150f, 1f))
            .AppendInterval(0.5f)
            .Append(chairHand.transform.DOLocalMoveX(500f, 1f))
            .AppendInterval(0.5f)

            .Append(chairHand.DOFade(0, 0.00001f))
            .Append(bg_whiteArea.DOFade(0,0.00001f))
            //change the colour of monologue_MovingChair to black.
            .Append(monologue_MovingChair.DOColor(Color.black, 0.00001f))

            .Append(stand1.DOFade(1, 1f))
            .AppendInterval(0.5f)
            .Append(stand1.DOFade(0, 0.001f))

            .Append(stand2.DOFade(1, 1f))
            .AppendInterval(0.5f)
            .Append(stand2.DOFade(0,0.001f))

            .Append(stand3.DOFade(1, 1f))
            .AppendInterval(0.5f)
            .Append(stand3.DOFade(0, 0.001f))

            .Append(GameMgr.I.oldHouse.chair.transform.DOMoveX(10.45f, 0f))
            .AppendCallback(()=>
            {
                process.gameObject.SetActive(false);
                standOnTheChair.gameObject.SetActive(false);
            });
        GameMgr.I.oldHouse.canSetClock = true;
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
            GameMgr.I.oldHouse.canSetClock = true;
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