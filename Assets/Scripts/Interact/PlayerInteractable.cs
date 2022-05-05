using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerInteractable : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    [SerializeField] private float interactionDistance;
    [SerializeField] private TMPro.TextMeshProUGUI interactionText;
    [SerializeField] private GameObject interactionHoldGO;
    [SerializeField] private Image interactionHold;

    private bool interactKeypad;
    private bool interact;
    private void OnEnable()
    {
        GetComponent<InputSystemKeyboard>().OnInteract += SetInteract;
        GetComponent<InputSystemKeyboard>().OnKeyPad += SetKeyPad;

    }

    private void OnDisable()
    {
        GetComponent<InputSystemKeyboard>().OnInteract -= SetInteract;
        GetComponent<InputSystemKeyboard>().OnKeyPad -= SetKeyPad;

    }

    void Start()
    {
        interact = false;
        interactKeypad = false;
    }

    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        bool successfulHit = false;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            InteractManager interactable = hit.collider.GetComponent<InteractManager>();

            if (interactable != null)
            {
                HandleInteraction(interactable);
                interactionText.text = interactable.GetDescription();
                successfulHit = true;

                interactionHoldGO.SetActive(interactable.interactionType == InteractManager.InteractionType.Hold);
            }

            

        }
        
        float distance = Vector3.Distance(transform.position, hit.transform.position);
            if (distance <= 3f)
            {
                if (interactKeypad)
                {
                    if (hit.transform.GetComponent<KeypadKey>() != null)
                    {
                        hit.transform.GetComponent<KeypadKey>().SendKey();
                    }

                }
            }

        

        if (!successfulHit)
        {
            interactionText.text = "";
            interactionHoldGO.SetActive(false);
        }
    }

    void HandleInteraction(InteractManager interactable)
    {
        switch (interactable.interactionType)
        {
            case InteractManager.InteractionType.Click:

                if (interact)
                {
                    interactable.Interact();
                    interact = false;
                }
                break;
            case InteractManager.InteractionType.Hold:
                if (interact)
                {

                    interactable.IncreaseHoldTime();
                    if (interactable.GetHoldTime() > 1f) {
                        interactable.Interact();
                        interactable.ResetHoldTime();
                        interact = false;
                    }
                }
                else
                {
                    interactable.ResetHoldTime();
                }
                interactionHold.fillAmount = interactable.GetHoldTime();
                break;

            case InteractManager.InteractionType.Minigame:
                if (interact)
                {
                    interactable.Interact();
                    interact = false;

                }
                break;

            default:
                throw new System.Exception("No type of interact");
        }
    }

    void SetInteract(bool interacting)
    {
        if (interacting)
        {
            interact = true;
        }
        else
        {
            interact = false;
        }
    }

    void SetKeyPad(bool keyInteract)
    {
        if(keyInteract)
        {
            interactKeypad = true;
        }
        else
        {
            interactKeypad = false;
        }
    }
}
