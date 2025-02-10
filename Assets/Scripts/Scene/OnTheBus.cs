using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheBus : MonoBehaviour
{
    public Transform bus;
    public Transform character;


    
    public void Init() 
    {
        Hide();
    }

    private void Anim_ShackBus() 
    {
        DOTween.Sequence()
            .Append(bus.DOLocalMoveY(0.37f,0.2f))
            .Append(bus.DOLocalMoveY(0f, 0.2f))
            .SetLoops(-1,LoopType.Yoyo);
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
