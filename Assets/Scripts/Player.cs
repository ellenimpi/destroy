using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float xmoveSpeed = 12f;
    [SerializeField] float ymoveSpeed = 12f;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.1f;
    // Start is called before the first frame update

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    void Start()
    {
        SetBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine("FireContinuously");
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine("FireContinuously");
        }
        
    }

    public void SetBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        

    }

    IEnumerator FireContinuously()
    {
        while(true)
        { 
            GameObject laser = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            yield return new WaitForSeconds(projectileFiringPeriod);
        }

    }

    public void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * xmoveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * ymoveSpeed;
        var xnewPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var ynewPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
		transform.position = new Vector2(xnewPos, ynewPos);

    }
}
