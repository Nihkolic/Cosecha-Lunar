using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRangedAttack : MonoBehaviour
{/*
    public GameObject bulletPrefab; 
    public Transform bulletSpawnPoint; 
    public float bulletSpeed = 100f;
    */
    //bullet 
    public GameObject bulletBasic;
    public GameObject bulletFury;
    private GameObject _currentBullet;

    //bullet force
    public float shootForce;

    //Gun stats
    public float timeBetweenShooting, spread, timeBetweenShots;
    public bool allowButtonHold;
    public int bulletsPerTap;

    int bulletsLeft, bulletsShot;

    //Recoil
    public Rigidbody playerRb;
    public float recoilForce;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash;

    //bug fixing :D
    public bool allowInvoke = true;
    void Update()
    {/*
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            Destroy(bullet, 5f);
        }*/
        if (!PauseMenu.GAME_IS_PAUSED)
        {
            MyInput();
        }
        FuryOn();

    }
    private void Start()
    {
        readyToShoot = true;
        _currentBullet = bulletBasic;
        furyHasBeenActivated = false;

        allowButtonHold = false;

    }
    private void MyInput()
    {
        //Input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shoot
        if (readyToShoot && shooting)
        {
            Shoot(); //Function has to be after bulletsShot = bulletsPerTap
        }
    }
    private void Shoot()
    {
        readyToShoot = false;
        //
        //Find the exact hit position using a raycast
        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); //Just a ray through the middle of your current view
        RaycastHit hit;

        //check if ray hits something
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); //Just a point far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;
        //

        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //Calc Direction with Spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);

        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(_currentBullet, attackPoint.position, Quaternion.identity);
        Destroy(currentBullet, 2f);

        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up, ForceMode.Impulse);

        if (allowInvoke)
        {
            Invoke("ShotReset", timeBetweenShooting);
            allowInvoke = false;
        }
    }
    private void ShotReset()
    {
        readyToShoot = true;
        allowInvoke = true;
    }
    bool furyHasBeenActivated;
    void FuryOn()
    {
        if (FurySystem.FURY_IS_ACTIVE && !furyHasBeenActivated)
        {
            shootForce += 45;
            timeBetweenShooting = 0.25f;
            Debug.Log("FURYYY FURY");
            _currentBullet = bulletFury;

            furyHasBeenActivated = true;
        }
        else if(!FurySystem.FURY_IS_ACTIVE && furyHasBeenActivated)
        {
            shootForce = 105;
            timeBetweenShooting = 0.4f;
            _currentBullet = bulletBasic;

            furyHasBeenActivated = false;
        }
    }

}
