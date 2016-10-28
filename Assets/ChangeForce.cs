using UnityEngine;
using System.Collections;

public class ChangeForce : MonoBehaviour {
    public GameObject target;
    public GameObject cursor;
    private ConstantForceEffect cfe;
    // Use this for initialization
    void Start () {
        cfe = GetComponent<ConstantForceEffect>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 direction = cursor.transform.position - target.transform.position;
        
        cfe.directionEffect = new float[3] {0,-1,0};
        //cfe.magnitude = Mathf.Pow(direction.magnitude / 20, 2);
        //cfe.gain = Random.Range(0, 10.0f);
        //cfe.directionEffect[0] = Random.Range(0, 2.0f);
        //cfe.directionEffect[2] = Random.Range(0, 1.0f);
    }
}
