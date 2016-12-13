using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;
public class Enemy : MonoBehaviour
{
    public GameObject effect;//特效
    public Transform player, enemy, tower, barrel;
    public Rigidbody bullet;
    int refresh_num = 0;
    float alpha_z = 0f;

    void Update()
    {
        move();
        rotateBarrel();
        attack();
        destory();
    }

    private void move()
    {
        float tank_speed = 0.05f;
        Vector3 temp = transform.localPosition; // copy to an auxiliary variable...
        float value_z = Mathf.PingPong(alpha_z, 7); // modify the component you want in the variable...
        temp.z = value_z;
        transform.localPosition = temp; // and save the modified value 
        alpha_z += tank_speed;
    }

    private void rotateBarrel()
    {
        float rotate_speed = 2.0f;
        Vector2 vec_enemy = new Vector2((barrel.position.x - tower.position.x), (barrel.position.z - tower.position.z));
        Vector2 vec_target = new Vector2((player.position.x - tower.position.x), (player.position.z - tower.position.z));
        float angle = Vector2.Angle(vec_enemy, vec_target);
        float cross = (vec_enemy.x * vec_target.y) - (vec_enemy.y * vec_target.x);
        if (cross < 0)
        {
            tower.Rotate(Vector3.forward * rotate_speed);
        }else
        {
            tower.Rotate(Vector3.back * rotate_speed);
        }
    }

    private void attack()
    {
        if (refresh_num % 40 == 0)
        {
            int bullet_speed = 30;
            //產生砲彈在發射點
            Rigidbody shoot =
                (Rigidbody)Instantiate(bullet, barrel.position, barrel.rotation);
            //給砲彈方向力，將他從y軸推出去
            shoot.velocity = barrel.TransformDirection(new Vector3(0, bullet_speed, 0));
            //讓坦克的碰撞框忽略砲彈的碰撞"
            Physics.IgnoreCollision(enemy.GetComponent<Collider>(), shoot.GetComponent<Collider>());
        }
        refresh_num ++;
    }

    private void destory()
    {
        if (gameObject.GetComponentInChildren<PlayerHealth>().getCurHealth() <= 0)
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
