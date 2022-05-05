using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageMove : MonoBehaviour
{
    public float movementQuantity;

    private InputSystemKeyboard _inputSystem;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystemKeyboard>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<RectTransform>().position = new Vector2((_inputSystem.mousePosX / Screen.width) * movementQuantity + (Screen.width / 2),
                                                             (_inputSystem.mousePosY / Screen.height) * movementQuantity + (Screen.height / 2));
    }
}
