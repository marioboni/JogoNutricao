using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Move : MonoBehaviour {
	
	public GameObject[] player;
	public int[] currentHouse;
	public GameObject dice, button, perguntas, esferaPlayer;
	public int move, targetHouse, nextHouse, i=0, j=0, posicaoPlayer=1; //posicaoPlayer eh uma auxiliar para identificar caso os players estejam na mesma casa qual sera a posicao individual de cada um
	public List<GameObject> housesPositions = new List<GameObject>();
	public Vector3 target, next;

	public Material PlayerPreto, PlayerVermelho, PlayerAzul;

	public bool okplayer=false, targetAlcancado=true; // okPlayer: variavel que autoriza a pergunta a aparecer
													  // targetAlcancado: Auxiliar para a posicao de players na mesma casa (eh a vez de quem?)

	//public ArrayList housesPositions = new ArrayList();

	// Use this for initialization
	void Start () {

		//player = new GameObject[3];
		
		esferaPlayer = GameObject.Find("corJogador");
		player = new GameObject[] {GameObject.Find("player 0"), GameObject.Find("player 1"), GameObject.Find("player 2")};
		currentHouse = new int[] {0, 0, 0};

		player[0].transform.position = new Vector3(GameObject.Find("Casa0").transform.position.x, GameObject.Find("Casa0").transform.position.y + 0.2f, GameObject.Find("Casa0").transform.position.z + 17f);
		player[1].transform.position = new Vector3(GameObject.Find("Casa0").transform.position.x, GameObject.Find("Casa0").transform.position.y + 0.2f, GameObject.Find("Casa0").transform.position.z);
		player[2].transform.position = new Vector3(GameObject.Find("Casa0").transform.position.x, GameObject.Find("Casa0").transform.position.y + 0.2f, GameObject.Find("Casa0").transform.position.z - 17f);
		
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

		int current;
		dice = GameObject.Find ("Dice (1)");
		current = dice.GetComponent<DisplayCurrentDieValue>().currentValue;

//		Debug.Log("Current: " + current);

		if(i==3 || i==0){
			i=0;
			esferaPlayer.GetComponent<Renderer>().material = PlayerAzul;
		}
		if(i==2){
			esferaPlayer.GetComponent<Renderer>().material = PlayerPreto;
		}
		if(i==1){
			esferaPlayer.GetComponent<Renderer>().material = PlayerVermelho;
		}

		button = GameObject.Find ("VirtualButton");

		if (move == 0 && button.GetComponent<VirtualButtonHandler>().okdice && dice.GetComponent<Rigidbody>().velocity == new Vector3(0,0,0)){ //Esta na hora do player andar?
			if (current==1){ //Os ifs vao decidir quantas casas (de acordo com o dado) o player tem que andar.
				targetHouse = currentHouse[i] + 1;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;
			}
			
			else if (current==2){
				targetHouse = currentHouse[i] + 2;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==3){
				targetHouse = currentHouse[i] + 3;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==4){
				targetHouse = currentHouse[i] + 4;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==5){
				targetHouse = currentHouse[i] + 5;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
			else if (current==6){
				targetHouse = currentHouse[i] + 6;
				move = 1;
				button.GetComponent<VirtualButtonHandler>().okdice = false;
				okplayer = true;

			}
		}
		else{
			//Debug.Log(move + " " + button.GetComponent<VirtualButtonHandler>().okdice + " " + dice.GetComponent<Rigidbody>().velocity);
		}
		
		if (targetHouse > 17)
				targetHouse = targetHouse - 18;
		
		nextHouse = currentHouse[i] + 1;
		
		if (nextHouse > 17)
				nextHouse = nextHouse - 18;
		
		target = housesPositions[targetHouse].transform.position;
		next = housesPositions[nextHouse].transform.position;
		target.y += 0.2f;
		next.y += 0.2f;
		

		if (move == 1){
			player[i].transform.position = Vector3.Lerp(player[i].transform.position, next, 15.0f * Time.deltaTime);
			targetAlcancado=true;
		}

		if (TesteVetores(player[i].transform.position, next)) {
			currentHouse[i] = nextHouse;
		} 

		if (TesteVetores(player[i].transform.position, target) && targetAlcancado){
			currentHouse[i] = targetHouse;
			/*for(j=0;j<3;j++){
				if(i==j) {}
				else{
					if(currentHouse[i]==currentHouse[j]){
							Debug.Log("Player " + i + ", PosicaoPlayer:" + posicaoPlayer + ", no mesmo lugar que Player " + j);
							player[i].transform.position = new Vector3(player[i].transform.position.x, player[i].transform.position.y, player[i].transform.position.z + 17f*posicaoPlayer); 
							posicaoPlayer = posicaoPlayer*-1;
					}
					break;
				}
			}*/
			move = 0;
			i++;
			targetAlcancado=false;
		}

		for(j=0;j<3;j++){
			if(j==2){
				if(move==0 && TesteVetores(player[j].transform.position, player[0].transform.position )){
					player[j].transform.position = new Vector3(player[j].transform.position.x, player[j].transform.position.y, player[j].transform.position.z + 17f*posicaoPlayer); 
					posicaoPlayer = posicaoPlayer*-1;
				}
			}
			else{
				if(move == 0 && TesteVetores(player[j].transform.position, player[j+1].transform.position)){
					player[j].transform.position = new Vector3(player[j].transform.position.x, player[j].transform.position.y, player[j].transform.position.z + 17f*posicaoPlayer); 
					posicaoPlayer = posicaoPlayer*-1;
				}
			}
		}

	}



	public bool TesteVetores(Vector3 a, Vector3 b){
		//Essa funcao vai simplesmente comparar 2 vetores 3D. Qnd comparamos normalmente, a precisao eh maior que o colocado aqui.
		//Estava dando problemas com aproximacao, acredito, entao os valores (mesmo que iguais) demoravam a ser considerados = pela unity.
		return Vector3.SqrMagnitude(a - b) < 0.0001;
	}
	
}
