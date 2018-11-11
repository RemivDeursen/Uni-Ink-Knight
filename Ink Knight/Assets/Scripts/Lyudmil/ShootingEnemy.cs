using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour {

    public GameObject arrow;
    public GameObject SpawningPoint;
    public bool waitingToShoot=false;
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (waitingToShoot== false)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
      GameObject shootedArrow = Instantiate(arrow, SpawningPoint.transform.position, SpawningPoint.transform.rotation);
        shootedArrow.transform.parent = gameObject.transform;
        waitingToShoot = true;
        StartCoroutine(prepareToShoot());
    }
    IEnumerator prepareToShoot()
    {
        yield return new WaitForSeconds(4f);
        waitingToShoot = false;
    }
    
}
