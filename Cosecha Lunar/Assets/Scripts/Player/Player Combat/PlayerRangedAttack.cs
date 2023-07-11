using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerRangedAttack : MonoBehaviour
{
    [SerializeField]
    private SkinnedMeshRenderer gunModel;

    [SerializeField] private Material matGreen;
    [SerializeField] private Material matRed;
    private bool hasFuryMessageAppeared;
    int furyCount;
    [SerializeField]
    private GameObject furyMessage;

    [SerializeField] private PlayerAudio playerAudio;
    [SerializeField] private Animator blasterAnim;
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

    bool isUp;
    void Update()
    {/*
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            Destroy(bullet, 5f);
        }*/

        if(LevelChange.CURRENT_LEVEL >= 1)
        {
            PlayerCombat.FURY_CAN_BE_ON = true;
        }
        if (!PauseMenu.GAME_IS_PAUSED)
        {
            MyInput();
        }
        FuryOn();
        FuryMessage();
    }
    void FuryMessage()
    {
        if (furyCount == 1)
        {
            furyMessage.SetActive(true);
        }
        else
        {
            furyMessage.SetActive(false);
        }
    }
    private void Start()
    {
        readyToShoot = true;
        _currentBullet = bulletBasic;
        furyHasBeenActivated = false;

        allowButtonHold = false;

        PlayerCombat.FURY_CAN_BE_ON = false;

        furyMessage.SetActive(false);
    }
    private void OnEnable()
    {
        isUp = true;
    }
    private void MyInput()
    {
        //Input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shoot
        if (readyToShoot && shooting && isUp)
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

        blasterAnim.Play("Shoot");
        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(_currentBullet, attackPoint.position, Quaternion.identity);
        Destroy(currentBullet, 2f);
        ShootSFX();
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
    void ShootSFX()
    {
        
        if (furyHasBeenActivated)
        {
            playerAudio.PlayFurySHot();

        }
        else
        {
            playerAudio.PlaySHot();

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
        if (FurySystem.FURY_IS_ACTIVE && !furyHasBeenActivated && PlayerCombat.FURY_CAN_BE_ON)
        {
            shootForce += 45;
            timeBetweenShooting = 0.1f;
            Debug.Log("FURYYY FURY");
            _currentBullet = bulletFury;
            gunModel.material = matRed;
            furyCount++;

            furyHasBeenActivated = true;
        }
        else if(!FurySystem.FURY_IS_ACTIVE && furyHasBeenActivated)
        {
            shootForce = 125;
            timeBetweenShooting = 0.15f;
            _currentBullet = bulletBasic;
            gunModel.material = matGreen;

            furyHasBeenActivated = false;
        }
    }
    public void PlayDown()
    {
        blasterAnim.Play("Down");
        isUp = false;
    }
    public void PlayUp()
    {
        blasterAnim.Play("Up");
        isUp = true;
    }
}
