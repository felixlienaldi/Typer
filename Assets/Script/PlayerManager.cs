using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;
    public Transform target;
    public GameObject laser;
    private Vector2 direction;
	// Use this for initialization
	
	void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeTarget()
    {
        direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 90f, Vector3.forward);
        GameObject laserPrefab = Instantiate(laser, transform.position, transform.rotation);
        laserPrefab.GetComponent<Bullet>().direction = this.direction.normalized;
        
    
    }
}
