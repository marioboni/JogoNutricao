using UnityEngine;
using System.Collections;
using System.IO;
using UnityEditor;

public class onClick : MonoBehaviour {

	private static string arquivo = "teste.txt";
	public static TextMesh textoPergunta;
	public GameObject texto;
	static int i = 0;
	
	void Start () {

		textoPergunta = GameObject.Find("Pergunta").GetComponent<TextMesh>(); //Pegando o GameObject (text3d) que eu quero mudar.
	}


	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			verificarArquivo(); //Verifico se o arquivo existe.
			lerArquivo();		//Carrego e leio o arquivo.
		}
	}


	public static void verificarArquivo(){

		if (!File.Exists(arquivo)){
			//File.Create(arquivo); //Podemos criar o arquivo caso ele nao exista. (Mas nao sei se eh valido)
			EditorUtility.DisplayDialog ("Erro ao encontrar arquivo", arquivo + " nao encontrado.", "ok");
		}
	}


	public static void lerArquivo(){

		string[] text; //Criamos um vetor que vai armazenar o resultado da nossa consulta no arquivo (= as nossas perguntas).
		StreamReader streamR = new StreamReader(arquivo); //Criamos um novo objeto que acessa os métods de leitura, passamos o arquivo que quremos ler.
			
		text = streamR.ReadToEnd().Split('#'); //Armazeno no vetor as perguntas (Que devem estar separadas por #. Podemos usar interrogacao como demarcador.
		streamR.Close(); // Finaliza o uso do nosso arquivo.

		textoPergunta.text = text[i]; ////Exibe na tela as perguntas conforme clicamos com o botao do mouse.

		i++;
		if (i == text.Length)
			i = 0; 			//Faz a lista de perguntas ser mostrada de forma circular: primeira -> segunda -> terceira -> primeira.
	}

}

