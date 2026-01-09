using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheBus : MonoBehaviour,SceneFunc
{
    public Transform bus;
    public Transform character;
    public Transform bg;
    public Transform curtain_left1;
    public Transform curtain_left2;
    public Transform curtain_right1;
    public Transform curtain_right2;
    
    public void Init() 
    {
        Hide();

        GameMgr.I.player.gameObject.SetActive(false);
    }

    //private void AddCurtainsAndCharacterAsChildren()
    //{
    //    character.SetParent(bus);
    //    curtain_left1.SetParent(bus);
    //    curtain_left2.SetParent(bus);
    //    curtain_right1.SetParent(bus);
    //    curtain_right2.SetParent(bus);
    //}

    private void Anim_ShackBus()
    {

        DOTween.Sequence()
            .AppendInterval(1f)
            .Append(bus.DOLocalMoveY(0.05f, 0.15f))
            .Append(bus.DOLocalMoveY(0f, 0.2f))
            .Append(bus.DOLocalMoveY(0.05f, 0.15f))
            .Append(bus.DOLocalMoveY(0f, 0.2f))
            .AppendInterval(1f)
            .Append(bus.DOLocalMoveY(0.05f, 0.15f))
            .Append(bus.DOLocalMoveY(0f, 0.2f))
            .AppendInterval(1f)
            .SetLoops(-1, LoopType.Yoyo);

        AddCurtainAnimation(curtain_left1);
        AddCurtainAnimation(curtain_left2);
        AddCurtainAnimation(curtain_right1);

        AddCharacterAnimation(character);
    }

    private void AddCurtainAnimation(Transform curtain)
    {
        curtain_left1.DOLocalRotate(new Vector3(0f, 0f, 0.7f), 1f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo);
        curtain_left2.DOLocalRotate(new Vector3(0f, 0f, 1f), 0.8f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo);
        curtain_right1.DOLocalRotate(new Vector3(0f, 0f, -1f), 0.7f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo);
        curtain_right2.DOLocalRotate(new Vector3(0f, 0f, -0.7f), 0.8f, RotateMode.LocalAxisAdd)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void AddCharacterAnimation(Transform character)
    {
        DOTween.Sequence()
            .AppendInterval(1f)
            .Append(character.DOLocalMoveY(0.01f, 0.2f))
            .Append(character.DOLocalMoveY(0f, 0.15f))
            .Append(character.DOLocalMoveY(0.01f, 0.2f))
            .Append(character.DOLocalMoveY(0f, 0.15f))
            .AppendInterval(1f)
            .Append(character.DOLocalMoveY(0.01f, 0.2f))
            .Append(character.DOLocalMoveY(0f, 0.15f))
            .AppendInterval(1f)
            .SetLoops(-1, LoopType.Yoyo);
        //character.DOLocalMoveY(0.01f, 0.2f)
        //    .SetLoops(-1, LoopType.Yoyo);
    }

    public void Show() { gameObject.SetActive(true); }
    public void Hide() { gameObject.SetActive(false); }

    // Start is called before the first frame update
    void Start()
    {
        Anim_ShackBus();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
