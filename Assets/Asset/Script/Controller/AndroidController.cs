using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidController : MonoBehaviour
{

    public float targetValue = 1f;    
    public float speed = 0.5f;       
    private float currentValue = 0f;

    public PlayerController playerController;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveRight()
    {

            currentValue = 1f;

            playerController.MoveInput = currentValue;
    }

    public void MoveLeft()
    {

            currentValue = -1f;

            playerController.MoveInput = currentValue;

    }

    public void Jumping()
    {
        playerController.Jump();
    }

    public void Shooting()
    {
        playerController.Shoot();
    }

    public void Reseting()
    {
        currentValue = 0f;
        playerController.MoveInput = currentValue;
    }
}
