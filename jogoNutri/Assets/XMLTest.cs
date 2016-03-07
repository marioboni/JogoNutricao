using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

public class XMLTest : MonoBehaviour {
	
	string Filelocation, FileName;
	public static TextMesh textoPergunta;
	public string[,] text;
	public int numPerguntas, numGrupos, idGrupo=0, u=0;	// u vai ser o index dos vetores das perguntas (text[]).
	public int[,] perguntaExibida;            // ehNulo eh o vetor que vai dizer se a pergunta ja foi exibida (valor 1) ou nao (valor 0). 
	public int[] grupo, maxGrupo;
	public GameObject script;

	// Os indexs desse vetor sao iguais aos do vetor de perguntas (text[]). 
	// Ex.: A pergunta em text[2] ja foi exibida se perguntaExibida[2] for =0. E o contrario se =1.
	
	void Start () {
		textoPergunta = GameObject.Find("TextoPergunta").GetComponent<TextMesh>(); //"TextoPergunta" eh o nome do objeto onde vamos colocar a pergunta (o objeto texto).
		Filelocation = "C:/Users/MarioBonicenha/Documents/jogoNutri/Banco de Dados/"; //Colocar o diretorio do arquivo xml (nao esquecer da contra-barra no final!)
		FileName = "arquivo.xml"; 			//Nome do arquivo
		LoadFromXML ();						//Funcao que vai ler do xml.
		idGrupo = 0;
		script = GameObject.Find ("Script");
	}
	
	void Update () {
		
		if (GameObject.Find("Script").GetComponent<Move>().okplayer) {     //A pergunta vai mudar ao clicarmos com o botao do mouse. (so um trigger para a exibicao)
			if(grupo[idGrupo]==0){                //Se todas as perguntas ja foram exibidas: Mensagem de Erro.
				EditorUtility.DisplayDialog ("Acabaram as perguntas do grupo " + idGrupo, "", "ok");
				if(idGrupo+1!=numGrupos)		//Faz as perguntas irem de grupo em grupo
					idGrupo=idGrupo+1;
			}
			else{
				u = Random.Range (0, maxGrupo[idGrupo]);
				while(perguntaExibida[idGrupo, u] == 1){			//Testo para ver se a pergunta ja foi exibida.
					u = Random.Range (0, maxGrupo[idGrupo]);		//Se ja: procuro outra.
				}
				grupo[idGrupo]--;              			    //Calculo o numero de perguntas restantes que podem ser exibidas.
				textoPergunta.text = text[idGrupo, u];		//Exibe na tela as perguntas conforme clicamos com o botao do mouse.
				perguntaExibida[idGrupo, u] = 1;            //Marcando que a pergunta nao pode ser mais exibida.
				script.GetComponent<Move>().okplayer = false;
			}
		}
	}
	
	public void LoadFromXML()
	{
		int i = 0;
		
		XmlDocument XmlDoc = new XmlDocument();
		
		if (File.Exists (Filelocation + FileName)) {
			XmlDoc.Load (Path.Combine (Filelocation, FileName));
			
			XmlNode Banco = XmlDoc.FirstChild;
			//XmlNodeList Perguntas = XmlDoc.GetElementsByTagName ("Banco");
			
			XmlNode nP = XmlDoc.SelectSingleNode ("/Banco/numeroPerguntas"); //Lendo o numero de perguntas contido no arquivo.
			numPerguntas = int.Parse(nP.InnerText);
			
			XmlNode nG = XmlDoc.SelectSingleNode ("/Banco/numeroGrupos"); //Lendo o numero de perguntas contido no arquivo.
			numGrupos = int.Parse(nG.InnerText);
			grupo = new int[numGrupos];
			maxGrupo = new int[numGrupos];
			
			foreach(XmlNode node in Banco){
				if(node.Name == ("Grupo"+idGrupo)){
					text = new string[numGrupos, node.ChildNodes.Count]; //Relacionando o numero de perguntas com o tamanho do vetor text.
					perguntaExibida = new int[numGrupos, node.ChildNodes.Count];
					idGrupo++;
				}
			}
			idGrupo=0;
			
			
			
			foreach (XmlNode node in Banco) { // Percorrendo as perguntas no arquivo xml e armazenando no vetor text.
				if (node.Name == ("Grupo"+idGrupo)) { 
					foreach(XmlNode pergunta in node){
						text [idGrupo, i] = pergunta.InnerText; // Guardando na matriz de strings de perguntas a pergunta lida.
						perguntaExibida [idGrupo, i] = 0;       //No inicio nenhuma pergunta foi exibida.
						i++;
						grupo[idGrupo] = grupo[idGrupo] + 1; // Guarda a quantidade de perguntas por grupo
					}
					maxGrupo[idGrupo]=grupo[idGrupo];
					idGrupo++;
					i=0;
				}
			}
		} 
		else
			EditorUtility.DisplayDialog ("Erro ao encontrar arquivo", Filelocation + FileName + " nao encontrado.", "ok");
	}
	
}
