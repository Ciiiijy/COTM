using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTheMountain : MonoBehaviour, SceneFunc
{
    private Vector2 startLocalPos;

    public Wall wall_L;
    public Wall wall_R;
    public bool isLeftKeyPressed;
    public bool putAllRight;
    public GameObject back;
    public GameObject gound;
    public GameObject middle;
    public GameObject front;

    public float leftPos;
    public float rightPos;

    private Vector3 lastPosition;

    public void Init()
    {
        wall_L.Init();
        wall_R.Init();

        Hide();
        startLocalPos = new Vector2(-7, Player.I.transform.position.y);

        RuleMgr.I.CanRule(true);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Player.I.transform.localPosition = startLocalPos;
        Player.I.playerMove.PrintCanMove();
        RuleMgr.I.CanRule(true);
    }

    public void Hide() { gameObject.SetActive(false); }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CameraCtrl.I.TryCameraFollowing(leftPos, rightPos);
    }
}
