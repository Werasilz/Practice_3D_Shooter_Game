using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    private Animator animator;

    public GameObject bullet;
    public GameObject gunPoint;
    public GameObject muzzle;

    public float movementSpeed;
    public float rotationSpeed;
    public float bulletForce;

    private float Vertical => Input.GetAxis("Vertical");
    private float Horizontal => Input.GetAxis("Horizontal");

    private Vector3 Direction => new Vector3(Horizontal, 0, Vertical);

    private bool IsMoving => Direction != Vector3.zero;

    private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);

    private Vector3 RotationDirection => Vector3.RotateTowards(transform.forward, Direction, rotationSpeed * Time.deltaTime, 0);

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (!IsMoving)
        {
            animator.SetBool("isWalk", false);
            return;
        }
        else
        {
            animator.SetBool("isWalk", true);
        }

        transform.position += Direction * movementSpeed * Time.deltaTime;
        transform.rotation = Rotation;
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject cloneBullet = Instantiate(bullet, gunPoint.transform.position, bullet.transform.rotation);
            GameObject cloneMuzzle = Instantiate(muzzle, gunPoint.transform.position, muzzle.transform.rotation);
            cloneBullet.GetComponent<Rigidbody>().AddForce(gunPoint.transform.forward * bulletForce);
            Destroy(cloneBullet, 1f);
            Destroy(cloneMuzzle, 1f);
        }
    }
}
