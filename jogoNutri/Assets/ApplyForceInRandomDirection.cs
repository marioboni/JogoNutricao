using UnityEngine;
using System.Collections;

public class ApplyForceInRandomDirection : MonoBehaviour
{
    public string buttonName = "Fire1";
	public float forceAmount = 10.0f;
	public float torqueAmount = 10.0f;
	public ForceMode forceMode;


	// Update is called once per frame
	void Update ()
	{
		if(Input.GetButtonDown(buttonName)){
			this.GetComponent<Rigidbody>().AddForce(Random.onUnitSphere*forceAmount, forceMode);
			this.GetComponent<Rigidbody>().AddTorque(Random.onUnitSphere*torqueAmount, forceMode);
           
		}
	}
}
