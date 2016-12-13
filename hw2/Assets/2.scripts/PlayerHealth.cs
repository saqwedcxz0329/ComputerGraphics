using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
    private  float max_Health = 100f;
    private  float cur_Health = 0f;
    public  GameObject healthBar;

	// Use this for initialization
	 void Start () {
        cur_Health = max_Health;
        //InvokeRepeating("decreseHealth", 1f, 1f);
	}
	
	// Update is called once per frame
	 void Update () {
	
	}

    public  void decreseHealth(float damage)
    {
        cur_Health -= damage;
        float calc_Health = cur_Health / max_Health;
        setHealthBar(calc_Health);
    }

    private  void setHealthBar(float myHealth)
    {
        healthBar.transform.localScale = new Vector3(myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
    }

    public float getCurHealth()
    {
        return cur_Health;
    }
}
