using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DebugClass : MonoBehaviour
{
	[SerializeField] private UnityEvent ActivatePCGame;
	[SerializeField] private UnityEvent ActivatePhoneGame;
	private void Start()
	{
		
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			ActivatePCGame.Invoke();		
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{ 
			ActivatePhoneGame.Invoke();
		}
	}
}