using UnityEngine;
using System.Collections;

public class GunRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
                Vector3 pos = Camera.main.WorldToScreenPoint(transform.position); 
                Vector3 dir = Input.mousePosition - pos;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                gameObject.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
}
