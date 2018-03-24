using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{
	// Joystick
	private Image _bgImage;
	private Image _joystickImage;
	private Vector3 _inputVector;

	private void Start()
	{
		_bgImage = GetComponent<Image>();
		_joystickImage = transform.GetChild(0).GetComponent<Image>();
	}
	
	public virtual void OnDrag(PointerEventData ped)
	{
		Vector2 pos;
		if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(_bgImage.rectTransform, ped.position,
																	ped.pressEventCamera, out pos)) return;
		pos.x = (pos.x / _bgImage.rectTransform.sizeDelta.x);
		pos.y = (pos.y / _bgImage.rectTransform.sizeDelta.y);
			
		_inputVector = new Vector3(pos.x * 2f, 0, pos.y * 2f);
		_inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;
	}
	
	public virtual void OnPointerDown(PointerEventData ped)
	{
		OnDrag(ped);
	}
	
	public virtual void OnPointerUp(PointerEventData ped)
	{
		_inputVector = Vector3.zero;
		_joystickImage.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float Horizontal()
	{
		return _inputVector.x != 0 ? _inputVector.x : Input.GetAxis("Horizontal");
	}
	
	public float Vertical()
	{
		return _inputVector.z != 0 ? _inputVector.z : Input.GetAxis("Vertical");
	}
	
	//PC WASD
	
	/*
	public float MoveSpeed = 3f;
	public Vector3 Position;
	public Touch Touch;

	private void FixedUpdate ()
	{
		PlayerInput();
	}

	private void PlayerInput()
	{
		//TODO: Add Controller and Touch input
		if (Input.anyKey) //Anykey from Keyboard
		{
			if (Input.GetKey(KeyCode.W)) //Forward
			{
				Position.x += MoveSpeed;
			}

			if (Input.GetKey(KeyCode.S)) //Backward
			{
				Position.x -= MoveSpeed;
			}

			if (Input.GetKey(KeyCode.A)) //Go Left
			{
				Position.z += MoveSpeed;
			}

			if (Input.GetKey(KeyCode.D)) //Go Right
			{
				Position.z -= MoveSpeed;
			}

			if (Input.GetKeyDown(KeyCode.Escape))
			{
				//quit / exit? or pause menu
			}
		}
		//Mouse buttons
		if (Input.GetMouseButton(1))
		{
			
		}
		//Todo: TOUCH!!!!!
		//Todo: Controller
		//Position = Vector3.SmoothDamp()  Todo: Smotthign!!!!!
		transform.position = Position;
	}
	*/
}
