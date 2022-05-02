using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystem : InteractManager
{
    [Header("Global Variables")]
    [SerializeField] private bool autoClose;
    [SerializeField] private float speed;
    private Transform player;
    private float timer = 0f;
    private bool isOpen;

    //Rotate
    [SerializeField] private Transform pivot;
    private float targetYRotation;
    private float defaultYRotation = 0f;
    public bool rotate;

    //Slide
    private Vector3 endTargetPosition;
    private Vector3 startTargetPosition;
    [SerializeField] private Transform endDoor;
    private bool isOpeningSlide;
    public bool slide;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        defaultYRotation = transform.eulerAngles.y;

        endTargetPosition = endDoor.position;
        startTargetPosition = transform.position;
    }

    void Update()
    {
        //Rotate
        if (rotate)
        {
            pivot.rotation = Quaternion.Lerp(pivot.rotation, Quaternion.Euler(0f, defaultYRotation + targetYRotation, 0f), speed * Time.deltaTime);

            timer -= Time.deltaTime;

            if (timer <= 0f && isOpen && autoClose)
            {
                ToggleDoorRotate(player.position);
            }
        }

        //Slide
        if (slide)
        {
            if (isOpeningSlide)
            {
                transform.position = Vector3.Lerp(transform.position, endTargetPosition, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.Lerp(transform.position, startTargetPosition, speed * Time.deltaTime);
            }
        }
    }

    public void ToggleDoorRotate(Vector3 pos)
    {
        isOpen = !isOpen;

        if (isOpen)
        {
            Vector3 dir = (pos - transform.position);
            targetYRotation = -Mathf.Sign(Vector3.Dot(transform.right, dir)) * 80f;
            timer = 5f;
            isOpeningSlide = true;
        }
        else
        {
            targetYRotation = 0f;
            isOpeningSlide = false;
        }
    }

    public void Open(Vector3 pos)
    {
        if (!isOpen)
        {
            ToggleDoorRotate(pos);
        }
    }
    public void Close(Vector3 pos)
    {
        if (isOpen)
        {
            ToggleDoorRotate(pos);
        }
    }

    public override void Interact()
    {
        ToggleDoorRotate(player.position);
    }

    public override string GetDescription()
    {
        if (isOpen) return " Press [E] to close the door";
        return "Press [E] to open the door";
    }
}
