using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour {

	public int currentValue = 4, i;
	public float[] y;
	public float alturaMaxima = -10000f;
	public GameObject[] faces; 
	public GameObject dice;

	void Start (){
		
		dice = GameObject.Find ("Dice (1)");
		faces = new GameObject[6];
		y = new float[6];

		for(i=0;i<6;i++){
			faces[i]=GameObject.Find((i+1).ToString());
		}
	}

	// Update is called once per frame
	void Update ()
	{
		alturaMaxima = -10000;
		if(dice.GetComponent<Rigidbody>().velocity == new Vector3(0,0,0)){ //Se o dado está parado
			for(i=0;i<6;i++){
				y[i]=faces[i].transform.position.y;
				if(y[i]>alturaMaxima){
					alturaMaxima = y[i];
					currentValue = i+1;
				}
			}
		}

	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
		
}
