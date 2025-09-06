using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldHouse : MonoBehaviour, SceneFunc
{

    private Vector2 startLocalPos;  //Spawn the Player.

    public ClickRaycastDetector crd;

    public Wall wall_L;
    public Wall wall_R;
    public bool canSetClock;
    public bool canMoveChair;
    public bool trueTime;
    public bool getEyeball;
    public bool getScript;
    public GameObject characterBack;
    public GameObject chair;
    public GameObject clock;
    public GameObject clock910;

    //The Limitation of the scene for the camera moving.
    public float leftPos;
    public float rightPos;


    public void Init()
    {
        wall_L.Init();
        wall_R.Init();

        characterBack.gameObject.SetActive(false);
        clock910.gameObject.SetActive(false);

        chair.transform.localPosition = new Vector3(-1.77f, -2.37f);

        Hide();
        startLocalPos = new Vector2(-7, Player.I.transform.position.y);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        Player.I.transform.localPosition = startLocalPos;
        Player.I.playerMove.PrintCanMove();
    }
    public void Hide() { gameObject.SetActive(false); }

    //public void CanSetClock(bool value)
    //{
    //    canSetClock = value;
    //}
    //public void CanMoveChair(bool value)
    //{
    //    canMoveChair = value;
    //}


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
