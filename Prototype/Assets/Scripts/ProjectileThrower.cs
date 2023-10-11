using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileThrower : MonoBehaviour
{
    public GameObject projectilePrefab;
    [SerializeField] float speed = 5f;

    public void Throw(Vector3 targetPosition){
        Rigidbody2D newProjectileRB = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        targetPosition.z = 0;
        Vector3 normVector = (targetPosition - transform.position).normalized; 
        newProjectileRB.velocity = normVector * speed;
    }
}
