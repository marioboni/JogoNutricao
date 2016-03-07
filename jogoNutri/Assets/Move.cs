using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {
	
	public GameObject player;
	public GameObject dice, button, perguntas;
	public int move;
	public int currentHouse;
	public int targetHouse;
	public int nextHouse;
	public List<GameObject> housesPositions = new List<GameObject>();
	public Vector3 target;
	public Vector3 next;
	public bool okplayer=false; //variavel que autoriza a pergunta a aparecer

	//public ArrayList housesPositions = new ArrayList();

	// Use this for initialization
	void Start () {

		Debug.Log ("Entrei!");
		player = GameObject.Find("player");
		player.transform.position = new Vector3(GameObject.Find("Casa0").transform.position.x, GameObject.Find("Casa0").transform.position.y + 0.2f, GameObject.Find("Casa0").transform.position.z);
		currentHouse = 0;
		
		//housesPositions.Add(GameObject.Find("Casa0").transform.position);
		//housesPositions.Add(GameObject.Find("Casa1").transform.position);
		//housesPositions.Add(GameObject.Find("Casa2").transform.position);
		//housesPositions.Add(GameObject.Find("Casa3").transform.position);
		//housesPositions.Add(GameObject.Find("Casa4").transform.position);
		//housesPositions.Add(GameObject.Find("Casa5").transform.position);
		//housesPositions.Add(GameObject.Find("Casa6").transform.position);
		//housesPositions.Add(GameObject.Find("Casa7").transform.position);
		//housesPositions.Add(GameObject.Find("Casa8").transform.position);
		//housesPositions.Add(GameObject.Find("Casa9").transform.position);
		//housesPositions.Add(GameObject.Find("Casa10").transform.position);
		//housesPositions.Add(GameObject.Find("Casa11").transform.position);
		//housesPositions.Add(GameObject.Find("Casa12").transform.position);
		//housesPositions.Add(GameObject.Find("Casa13").transform.position);
		//housesPositions.Add(GameObject.Find("Casa14").transform.position);
		//housesPositions.Add(GameObject.Find("Casa15").transform.position);
		//housesPositions.Add(GameObject.Find("Casa16").transform.position);
		//housesPositions.Add(GameObject.Find("Casa17").transform.position);
		
		housesPositions.Add(GameObject.Find("Casa0"));
		housesPositions.Add(GameObject.Find("Casa1"));
		housesPositions.Add(GameObject.Find("Casa2"));
		housesPositions.Add(GameObject.Find("Casa3"));
		housesPositions.Add(GameObject.Find("Casa4"));
		housesPositions.Add(GameObject.Find("Casa5"));
		housesPositions.Add(GameObject.Find("Casa6"));
		housesPositions.Add(GameObject.Find("Casa7"));
		housesPositions.Add(GameObject.Find("Casa8"));
		housesPositions.Add(GameObject.Find("Casa9"));
		housesPositions.Add(GameObject.Find("Casa10"));
		housesPositions.Add(GameObject.Find("Casa11"));
		housesPositions.Add(GameObject.Find("Casa12"));
		housesPositions.Add(GameObject.Find("Casa13"));
		housesPositions.Add(GameObject.Find("Casa14"));
		housesPositions.Add(GameObject.Find("Casa15"));
		housesPositions.Add(GameObject.Find("Casa16"));
		housesPositions.Add(GameObject.Find("Casa17"));
		

	}
	
	// Update is called once per frame
	void Update () {
		/*Debug.Log (move);
		Debug.Log (currentHouse);
		Debug.Log (targetHouse);
		Debug.Log ("---");*/
		dice = GameObject.Find ("Dice (1)");
		int current = dice.GetComponent<DisplayCurrentDieValue>().currentValue;

		button = GameObject.Find ("VirtualButton");

		if (move == 0 && button.GetComponent<VirtualButtonHandler>().okdice && dice.GetComponent<Rigidbody>().velocity == new Vector3(0,0,0))
			if (current==1){
				targetHouse = currentHouse + 1;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;
			}
			
			else if (current==2){
				targetHouse = currentHouse + 2;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==3){
				targetHouse = currentHouse + 3;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==4){
				targetHouse = currentHouse + 4;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==5){
				targetHouse = currentHouse + 5;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==6){
				targetHouse = currentHouse + 6;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			
		
		if (targetHouse > 17)
				targetHouse = targetHouse - 18;
		
		nextHouse = currentHouse + 1;
		
		if (nextHouse > 17)
				nextHouse = nextHouse - 18;
		
		target = housesPositions[targetHouse].transform.position;
		next = housesPositions[nextHouse].transform.position;
		target.y += 0.2f;
		next.y += 0.2f;
		
		
		if (move == 1){
			player.transform.position = Vector3.Lerp(player.transform.position, next, 15.0f * Time.deltaTime);
			/*Debug.Log ("Move 1: Player Position:" + player.transform.position);
			Debug.Log ("Move 1: Next:" + next);
			Debug.Log ("Target:" + target);*/
		}

		/*Debug.Log ("---");
		Debug.Log ("move:" + move);
		Debug.Log ("---");
		 */

		if (TesteVetores(player.transform.position, next)) {
			//Debug.Log ("Entrei onde atribuo a proxima casa");
			currentHouse = nextHouse;
		} 
		/*else
			Debug.Log ("(ELSE) Player:" + player.transform.position + " next:" + next);
			//Essa parte foi usada para constatar que mesmo quando os vetores sao iguais, a unity demora a reconhecer isso.
		*/

		if (TesteVetores(player.transform.position, target)){
			currentHouse = targetHouse;
			move = 0;

		}
	}

	public bool TesteVetores(Vector3 a, Vector3 b){
		//Essa funcao vai simplesmente comparar 2 vetores 3D. Qnd comparamos normalmente, a precisao eh maior que o colocado aqui.
		//Estava dando problemas com aproximacao, acredito, entao os valores (mesmo que iguais) demoravam a ser considerados = pela unity.
		return Vector3.SqrMagnitude(a - b) < 0.0001;
	}
}
