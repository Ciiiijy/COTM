using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    private float leftPos;
    private float rightPos;
    private bool canMove;
    public void Init() 
    {
        this.transform.position = new Vector3(0, 0, -10);
    }

    public void SetLimitation(float leftLimit, float rightLimit)
    {
        leftPos = leftLimit;
        rightPos = rightLimit;
    }
    public void SetMove(bool canMove) 
    {
        this.canMove= canMove;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        
        //var playerPos = Player.I.transform.position;


        var cameraPosX = Camera.main.transform.position.x;
        Camera.main.transform.position = Player.I.transform.position;

    }
}
