using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gunScript : MonoBehaviour
{
    private float damage = 10f;
    private float range = 100f;
    private float impactForce = 30f;
    private float fireRate = 15f;
    public static int maxAmmo = 30;
    private int currentAmmo = -1;
    private float reloadTime = 2f;

    public GameObject impactEffect;
    public Animator animator;
    public TextMeshProUGUI ammoDisplay;
    public Camera fpsCam;

    private bool isReloading;
    private float nextTimeToFire = 0f;

    public AudioSource[] reloadSound;
    public AudioSource[] fireSound;

    private void Start()
    {
        if (currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }

        if (PointSystem.hasExtendedMag == 1)
        {
            maxAmmo += 10;
        }
    }

    private void OnEnable()
    {
        isReloading = false;
        animator.SetBool("isReloading", false);
    }
    void Update()
    {

        ammoDisplay.text = currentAmmo.ToString();

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    IEnumerator Reload ()
    {
        isReloading = true;

        reloadSound[0].Play();

        animator.SetBool("isReloading", true);
        yield return new WaitForSeconds(reloadTime - .25f);

        animator.SetBool("isReloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmo = maxAmmo;
        isReloading = false;

    }

    void Shoot ()
    {
        fireSound[0].Play();

        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
                GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGo, 2f);
            }

            if (hit.rigidbody != null)
            {   
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

        }

    }
}

