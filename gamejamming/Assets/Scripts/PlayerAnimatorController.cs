using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimatorController : MonoBehaviour
{

	[SerializeField] private Animator robotAnimatorController;
	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		if (Input.GetAxis("Vertical") != 0 || Input.GetAxis("Horizontal") != 0)
		{
			robotAnimatorController.SetBool("isWalking", true);


		}

		else if(Input.GetAxis("Horizontal") == 0 || Input.GetAxis("Vertical") == 0)
		{
			robotAnimatorController.SetBool("isWalking", false);

		}

	}
}
