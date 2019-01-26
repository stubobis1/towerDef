using UnityEngine;
using System.Collections;

// Very simple smooth mouselook modifier for the MainCamera in Unity
// by Francis R. Griffiths-Keam - www.runningdimensions.com

[AddComponentMenu("Camera/Simple Smooth Mouse Look ")]
public class playerLookScript : MonoBehaviour
{
	Vector2 _mouseAbsolute;
	Vector2 _smoothMouse;
	
	public Vector2 clampInDegrees = new Vector2(360, 180);
	public bool lockCursor;
	public Vector2 sensitivity = new Vector2(2, 2);
	public Vector2 smoothing = new Vector2(3, 3);
	public Vector2 targetDirection;
	public Vector2 targetCharacterDirection;
	
	
	public float cameraBackto0RotateTime = 1;
	public Transform rotatePoint;
	public bool inGrav = false;
	
	// Assign this if there's a parent object controlling motion, such as a Character Controller.
	// Yaw rotation will affect this object instead of the camera if set.
	public GameObject characterBody;
	
	void Start()
	{
	
		if( rotatePoint == null)
			rotatePoint = transform;
		// Set target direction to the camera's initial orientation.
		targetDirection = transform.localRotation.eulerAngles;
		
		// Set target direction for the character body to its inital state.
		if (characterBody) targetCharacterDirection = characterBody.transform.localRotation.eulerAngles;
	}
	
	void Update()
	{
	
	
		
		// Ensure the cursor is always locked wh en set
		Screen.lockCursor = lockCursor;
		
		// Allow the script to clamp based on a desired target value.
		//var targetOrientation = Quaternion.Euler(targetDirection);
		//var targetCharacterOrientation = Quaternion.Euler(targetCharacterDirection);
		
		// Get raw mouse input for a cleaner reading on more sensitive mice.
		var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		
		// Scale input against the sensitivity setting and multiply that against the smoothing value.
		mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity.x * smoothing.x, sensitivity.y * smoothing.y));
		
		// Interpolate mouse movement over time to apply smoothing delta.
		_smoothMouse.x = Mathf.Lerp(_smoothMouse.x, mouseDelta.x, 1f / smoothing.x);
		_smoothMouse.y = Mathf.Lerp(_smoothMouse.y, mouseDelta.y, 1f / smoothing.y);
		
		// Find the absolute mouse movement value from point zero.
		_mouseAbsolute += _smoothMouse;
		
		
		if(inGrav)
		{
		/*	// Clamp and apply the local x value first, so as not to be affected by world transforms.
			if (clampInDegrees.x < 360)
				_mouseAbsolute.x = Mathf.Clamp(_mouseAbsolute.x, -clampInDegrees.x * 0.5f, clampInDegrees.x * 0.5f);
			
			var xRotation = Quaternion.AngleAxis(-_mouseAbsolute.y, targetOrientation * Vector3.right);
			transform.localRotation = xRotation;
			
			// Then clamp and apply the global y value.
			if (clampInDegrees.y < 360)
				_mouseAbsolute.y = Mathf.Clamp(_mouseAbsolute.y, -clampInDegrees.y * 0.5f, clampInDegrees.y * 0.5f);
			
			transform.localRotation *= targetOrientation;*/
			
			float yAngle =0;
			
			
			float bottomLimit = clampInDegrees.y/2;
			float upperLimit =   360 - clampInDegrees.y/2;
			float curXRot = Mathf.Floor(transform.localEulerAngles.x);	
			
			if ( curXRot - _smoothMouse.y < bottomLimit)
				yAngle = _smoothMouse.y;
			
			
			if ( curXRot - _smoothMouse.y > upperLimit)
				yAngle = _smoothMouse.y;
			
			transform.RotateAround(transform.position, -characterBody.transform.right, yAngle);	
			
		}
		// If there's a character body that acts as a parent to the camera
		if (characterBody)
		{	
			//old direction movement
			//var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, characterBody.transform.up);
			//characterBody.transform.localRotation = yRotation;
			//characterBody.transform.localRotation *= targetCharacterOrientation;
			if (!inGrav)
			{	
				
				
				
				// rotate cam back to 0 0 0;
				
				/*
				print ("angle " + transform.rotation.eulerAngles.x);
				if (transform.rotation.eulerAngles.x > 0)
					transform.RotateAround(transform.position , transform.right, cameraBackto0RotateTime * Time.deltaTime);
				else if (transform.rotation.eulerAngles.x < 0)
					transform.RotateAround(transform.position , -transform.right, cameraBackto0RotateTime * Time.deltaTime);
					*/
					
				if(transform.localRotation.eulerAngles != Vector3.zero)
					transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(Vector3.zero), cameraBackto0RotateTime * Time.deltaTime);
				
				float yAngle = _smoothMouse.y;
				//Vector3 pos = characterBody.transform.position;
				//pos += (characterHieght/2 * transform.up);
			
				
				characterBody.transform.RotateAround(rotatePoint.position , -characterBody.transform.right, yAngle);	
			}

			
			float xAngle = _smoothMouse.x;
			characterBody.transform.RotateAround(characterBody.transform.position, characterBody.transform.up, xAngle);
			
		}
		else
		{	
		
			// ran if camera is body that we want to rotate ... need to change this..
			var yRotation = Quaternion.AngleAxis(_mouseAbsolute.x, transform.InverseTransformDirection(Vector3.up));
			transform.localRotation *= yRotation;
		}
	}
}
