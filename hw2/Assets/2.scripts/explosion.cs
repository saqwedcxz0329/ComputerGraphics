using UnityEngine;
using System.Collections;

public class explosion : MonoBehaviour {
	public GameObject effect;//特效
	public static int attacked_num = 0;
    private GameObject playerHealth;
    private GameObject enemyHealth;
	void Start () {
        playerHealth = GameObject.Find("HealthBar");
        enemyHealth = GameObject.Find("EnemyObject");
	}	
	void Update () {
	}

	void OnCollisionEnter (Collision collision) {//碰撞發生時呼叫
        float damage = 0f;
        if (gameObject.tag == "NormalAttack")
        {
            damage = 10f;
        }
        else if(gameObject.tag == "PowerfulAttack")
        {
            damage = 20f;
        }
		//碰撞後產生爆炸
		if(collision.gameObject.tag == "Enemy"){//當撞到的collider具有enemy tag時
			Instantiate (effect, transform.position, transform.rotation);
			Destroy(gameObject);//刪除砲彈
            enemyHealth.GetComponentInChildren<PlayerHealth>().decreseHealth(damage);
			attacked_num++;
		}
		if (collision.gameObject.tag == "Player")
		{//當撞到的collider具有enemy tag時
			Instantiate(effect, transform.position, transform.rotation);
			Destroy(gameObject);//刪除砲彈
            playerHealth.GetComponent<PlayerHealth>().decreseHealth(damage);
        }
        if (collision.gameObject.tag == "Terrain")
        {//當撞到的collider具有enemy tag時
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);//刪除砲彈
        }
    }
}
