using UnityEngine;
using System.Collections;
using Vuforia;

public class VirtualButtonHandler : MonoBehaviour, IVirtualButtonEventHandler
{
    public GameObject dice;
    public float forceAmount = 10.0f;
    public float torqueAmount = 10.0f;
    public ForceMode forceMode;
	public bool okdice=false, buttonPressed=false; //variavel que autoriza o player a andar

    // Use this for initialization
    void Start()
    {
		//Register with the virtual buttons TrackableBehaviour
		VirtualButtonBehaviour[] vbs = GetComponentsInChildren<VirtualButtonBehaviour>();
		for (int i = 0; i < vbs.Length; ++i)
		{
			vbs[i].RegisterEventHandler(this);
		}	
		dice = GameObject.Find("Dice (1)");
    }

	void Update()
	{
		if (buttonPressed) {
			Debug.Log("BOTAO PRESSED!!!");
			dice.GetComponent<Rigidbody> ().AddForce (Random.onUnitSphere * forceAmount, forceMode);
			dice.GetComponent<Rigidbody> ().AddTorque (Random.onUnitSphere * torqueAmount, forceMode);
		}
	}

    public void OnButtonPressed(VirtualButtonAbstractBehaviour vb)
    {
		Debug.Log ("Cliquei no botao");
		okdice = false;
		buttonPressed = true;
    }

    /// <summary>
    /// Called when the virtual button has just been released:
    /// </summary>
    public void OnButtonReleased(VirtualButtonAbstractBehaviour vb)
    {
		okdice = true;
		buttonPressed = false;
	}

}