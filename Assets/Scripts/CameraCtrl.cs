using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    public static CameraCtrl I;

    private float leftPos;
    private float rightPos;
    public bool canMove;
    public void Init()
    {
        I = this;
        this.transform.position = new Vector3(0, 0, -10);
    }

    public void SetLimitation(float leftLimit, float rightLimit)
    {
        leftPos = leftLimit;
        rightPos = rightLimit;
    }
    public void SetMove(bool canMove)
    {
        this.canMove = canMove;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void TryCameraFollowing(float leftPos, float rightPos)
    {
        var playerPos_X = Player.I.transform.position.x;
        if (playerPos_X <= rightPos && playerPos_X >= leftPos)
        {
            this.canMove = true;
        }
        else
        {
            this.canMove = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;

        //var playerPos = Player.I.transform.position;


        var playerPos = Player.I.transform.position;
        Camera.main.transform.position = new Vector3(
            playerPos.x,
            playerPos.y, 
            Camera.main.transform.position.z);

    }
}
