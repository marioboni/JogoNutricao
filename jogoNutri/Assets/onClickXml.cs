using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;
using System.Collections;

/*[XmlRoot("BancoPerguntas")]
public class onClickXml {

	[XmlArray("perguntas"),XmlArrayItem("pergunta")]
	public pergunta[] perguntas;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
*/
	/*public void Save(string path)
	{
		var serializer = new XmlSerializer(typeof(onClickXml));
		using(var stream = new FileStream(path, FileMode.Create))
		{
			serializer.Serialize(stream, this);
		}
	}
	*/
/*
	public static onClickXml Load(string path)
	{
		var serializer = new XmlSerializer(typeof(onClickXml));
		using(var stream = new FileStream(path, FileMode.Open))
		{
			return serializer.Deserialize(stream) as onClickXml;
		}
	}
	
	//Loads the xml directly from the given string. Useful in combination with www.text.
	public static onClickXml LoadFromText(string text) 
	{
		var serializer = new XmlSerializer(typeof(onClickXml));
		return serializer.Deserialize(new StringReader(text)) as onClickXml;
	}
	
}*/
