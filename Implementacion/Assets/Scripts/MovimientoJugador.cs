using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour 
{
	private CharacterController controller;
	private float Velocidad = 7.0f;
	private float Vertical = 0.0f;
	private float gravedad = 12.0f;
	private Vector3 moveVector;
	private int carril = 0;

	// Use this for initialization
	void Start () {
		carril = 0;

		controller = GetComponent<CharacterController> ();   // componente del personaje

	}
	
	// Update is called once per frame
	void Update () {


		if (controller.isGrounded)  // si esta tocando el suelo su velocidad en y debe ser 0, sino debe actuar la gravedad
		{ 
			Vertical = 0.0f;
		}
		else 
		{
			Vertical -= gravedad * Time.deltaTime;
		}
		 
		if((Input.GetKeyDown(KeyCode.UpArrow)) & (controller.isGrounded)) // codigo para el salto
		{
			Vertical = 7.0f;
		}
			
	
		/// Y
	
		moveVector.y = Vertical; 

		/// Z
		moveVector.z = Velocidad; // moviemiento constante en el eje z para que simpre vaya hacia el frente
		controller.Move (moveVector * Time.deltaTime);

		/// x

		if( Input.GetKeyDown(KeyCode.LeftArrow))  // movimiento entre 3 carriles 
			{if (carril > -1)
				carril --;
			}
		if( Input.GetKeyDown(KeyCode.RightArrow))
		{if (carril < 1)
			carril ++;
		}
			
	
		Vector3 newposition = transform.position;  // posicionar el objeto segun el valor que tenga la variable "carril"
		newposition.x = carril * 2;
		transform.position = newposition;



	}


}
