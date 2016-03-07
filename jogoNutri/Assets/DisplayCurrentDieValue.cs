using UnityEngine;
using System.Collections;

public class DisplayCurrentDieValue : MonoBehaviour {

	public LayerMask dieValueColliderLayer = -1;
	public int currentValue = 1;
	
	// Update is called once per frame
	void Update ()
	{
		RaycastHit hit;
	
		if(Physics.Raycast(this.transform.position,Vector3.up,out hit, Mathf.Infinity, dieValueColliderLayer))
		{
			currentValue = hit.collider.GetComponent<DieValue>().value;
		}

	}

	void OnGUI()
	{
		GUILayout.Label(currentValue.ToString());
	}
}
