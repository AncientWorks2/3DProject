using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterEngine : MonoBehaviour 
{
	[SerializeField]
	private float speed;
	[SerializeField]
	private float withoutStaminaSpeed;
	[SerializeField]
	private float crouchSpeed;
	[SerializeField]
	private float runSpeed;
	[SerializeField]
	private float gravity;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private float crouchJumpForce;
	[SerializeField]
	private float withoutStaminaJumpForce;
	[SerializeField]
	private float sensitivity;

	public GameObject cam;

	private float moveFB; //Move Front/Back
	private float moveLR; //Move Left/Right
	private float rotHor; //Rotattion Horizontal
	private float rotVer; //Rotation Vertical

	private float directionY;

	private bool crouched;
	private bool jump;
	private bool run;

	public float activeSpeed;
	public float activeJumpForce;

	private InputSystemKeyboard _inputSystem;
	private CharacterController _character;

	//Debug
	private MeshRenderer _renderer;
	public Material matGrounded;
	public Material matNotGround;

	private void Awake()
	{
		_character = GetComponent<CharacterController>();
		_inputSystem = GetComponent<InputSystemKeyboard>();

		_renderer = GetComponent<MeshRenderer>();
	}

    private void OnEnable()
    {
		_inputSystem.OnJump += SetJump;
		_inputSystem.OnCrouch += SetCrouch;
		_inputSystem.OnRun += SetRun;
    }

    private void OnDisable()
    {
		_inputSystem.OnJump -= SetJump;
		_inputSystem.OnCrouch -= SetCrouch;
		_inputSystem.OnRun -= SetRun;
	}

	private void Start()
    {
		jump = false;
		crouched = false;

		SetNormalSpeeds();
	}

    void FixedUpdate()
	{
		moveFB = _inputSystem.axHor * activeSpeed;
		moveLR = _inputSystem.axVer * activeSpeed;

		rotHor = _inputSystem.moHor * sensitivity;
		rotVer = _inputSystem.moVer * sensitivity;

		Vector3 movement = new Vector3(moveFB, 0, moveLR);		

		if (jump)
        {
			directionY = activeJumpForce;

			jump = false;
        }

		if (StaminaManager.currentStamina <= 0)
        {
			activeSpeed = withoutStaminaSpeed;
			activeJumpForce = withoutStaminaJumpForce;
        }

		directionY -= gravity * Time.fixedDeltaTime;

		movement.y = directionY;

		movement = transform.rotation * movement;
		_character.Move(movement * Time.fixedDeltaTime);


		CameraRotation(cam, rotHor, rotVer);

		//Debug
		GroundDetector();
	}

	void CameraRotation(GameObject cam, float rotHor, float rotVer)
	{
		transform.Rotate (0, rotHor * Time.fixedDeltaTime, 0);
		cam.transform.Rotate (-rotVer * Time.fixedDeltaTime, 0, 0);

		if (Mathf.Abs (cam.transform.localRotation.x) > 0.7) 
		{
			float clamped = 0.7f * Mathf.Sign(cam.transform.localRotation.x); 

			Quaternion adjustedRotation = new Quaternion(clamped, cam.transform.localRotation.y, cam.transform.localRotation.z, cam.transform.localRotation.w);
			cam.transform.localRotation = adjustedRotation;
		}
	}

	void SetCrouch()
    {
		if (_character.isGrounded)
		{
			if (!crouched)
			{
				cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y - 0.5f, cam.transform.position.z);

				activeSpeed = crouchSpeed;
				activeJumpForce = crouchJumpForce;

				crouched = true;
			}
			else
			{
				cam.transform.position = new Vector3(cam.transform.position.x, cam.transform.position.y + 0.5f, cam.transform.position.z);

				SetNormalSpeeds();

				crouched = false;
			}
		}
	}

	void SetJump()
	{
		if (_character.isGrounded)
		{
			jump = true;
		}
	}

	void SetRun(bool run)
    {
		if (!crouched && _character.isGrounded && StaminaManager.currentStamina >= 0)
		{
			if (run)
			{
				activeSpeed = runSpeed;
			}
			else
			{
				SetNormalSpeeds();
			}
		}
    }

	void SetNormalSpeeds()
    {
		activeSpeed = speed;
		activeJumpForce = jumpForce;
    }

	void GroundDetector()
    {
		if (_character.isGrounded)
		{
			_renderer.material = matGrounded;
		}
		else
		{
			_renderer.material = matNotGround;
		}
	}
}