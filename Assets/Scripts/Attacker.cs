using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    [Range(0f, 2f)]
    public float speed;

    public float damage;

    public Animator animator;

    GameObject defender;

	// Use this for initialization
	void Start () {
        animator.SetBool("isAttacking", false);
	}
	
	// Update is called once per frame
	void Update () {
        Walk();
	}

    void Walk(){
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void SetSpeed(float speed){
        this.speed = speed;
    }

    public void Attack(){
        Health health = defender.GetComponent<Health>();
        if(health){
            health.takeDamage(damage);
        }
        else{
            Debug.LogError("Object doesn't have a health componet.");
        }
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.GetComponent<Defender>())
		{
			animator.SetBool("isAttacking", true);
            defender = collision.gameObject;
        }
        else if(collision.GetComponent<Projectile>()){
            Health health = GetComponent<Health>();
			if (health)
			{
				health.takeDamage(collision.gameObject.GetComponent<Projectile>().damage);
			}
			else
			{
				Debug.LogError("Attacker missing health component.");
			}
        }
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.GetComponent<Defender>())
		{
            animator.SetBool("isAttacking", false);
		}
	}
}
