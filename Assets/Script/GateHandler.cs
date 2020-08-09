using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateHandler : MonoBehaviour {
    public enum logicGate
    {
        And,
        Nand,
        Or,
        Nor,
        Not,
        Xor,
        Exor,
        Normal
    }
	public GameObject switchA;
	public GameObject switchB;
	public Sprite OnSprite;
	public Sprite OffSprite;
	public logicGate situation;
	//private Rigidbody2D rb2d;
	public float maxheight=5f;
	private bool AStatus=false, BStatus=false;
	// public Vector3 intloc=new Vector3(20.794f,5.14f,0);
    private Vector3 intiloca;
	// Use this for initialization
	void Start () {
        //	rb2d = gameObject.GetComponent<Rigidbody2D> ();
        intiloca=gameObject.transform.position;
		maxheight+=intiloca.y;
	}
	
	// Update is called once per frame
	void Update () {
      AStatus=  getStatusOfSwitch(switchA);
        if (switchB != null) {
            BStatus = getStatusOfSwitch(switchB);
        }
		if (gameObject.transform.position.y < maxheight||check(situation) ==false) {
			if (check(situation) ==true) {
				gameObject.transform.Translate (Vector2.up*Time.deltaTime, 0);

			} else {
				gameObject.transform.position = intiloca;
			}
		} 
	}
    private bool getStatusOfSwitch(GameObject switchGameObject)
    {
        if (switchGameObject.GetComponent<SpriteRenderer>().sprite == OnSprite)
           return true;
        else
            return  false;
    }
	private bool check(logicGate sit){
		switch (sit) {
		case logicGate.And://And
			if (AStatus && BStatus) {
				return true;
			}
			break;
		case logicGate.Or://or 
			if (AStatus || BStatus) {
				return true;
			} 
			break;
		case logicGate.Nor://nor 
			if (!(AStatus|| BStatus)) {
				return true;
			}
			break;
		case logicGate.Nand://nAnd
			if (!(AStatus && BStatus)) {
				return true;
			}
			break;
		case logicGate.Xor://XOR
			if (AStatus^BStatus) {
				return true;
			}
			break;
		case logicGate.Exor://eXOR
			if (!(AStatus^BStatus)) {
				return true;
			}
			break;
		case logicGate.Not://not
			if (!AStatus) {
				return true;
			}
			break;
		case logicGate.Normal://normal
			if (AStatus) {
				return true;
			}
			break;
		default:
			return true;
			
	}	
		return false;
	}
}
