using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class heavyGun : MonoBehaviour
{
    private float damageHeavy = 300f;
    private float rangeHeavy = 200f;
    private float impactForceHeavy = 200f;
    private float fireRate = 15f;
    private int maxAmmoHeavy = 1;
    private int currentAmmoHeavy = -1;
    private float reloadTimeHeavy = 3f;

    public GameObject impactEffect;
    public Animator animator;
    private TextMeshProUGUI ammoDisplay;
    public Camera fpsCam;

    private bool isReloadingHeavy;
    private float nextTimeToFire = 0f;

    public AudioSource[] fireSound;

    private void Start()
    {
        ammoDisplay = FindObjectOfType<TextMeshProUGUI>();
        if (currentAmmoHeavy == -1)
        {
            currentAmmoHeavy = maxAmmoHeavy;
        }
    }

    private void OnEnable()
    {
        isReloadingHeavy = false;
        animator.SetBool("heavyReloading", false);
    }
    void Update()
    {

        ammoDisplay.text = currentAmmoHeavy.ToString();

        if (isReloadingHeavy)
        {
            return;
        }

        if (currentAmmoHeavy <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(ReloadHeavy());
            return;
        }

        if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }
    }
    IEnumerator ReloadHeavy()
    {
        isReloadingHeavy = true;

        animator.SetBool("heavyReloading", true);
        yield return new WaitForSeconds(reloadTimeHeavy - .25f);

        animator.SetBool("heavyReloading", false);
        yield return new WaitForSeconds(.25f);

        currentAmmoHeavy = maxAmmoHeavy;
        isReloadingHeavy = false;

    }

    void Shoot()
    {

        fireSound[0].Play();

        currentAmmoHeavy--;

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, rangeHeavy))
        {

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damageHeavy);
            }

            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForceHeavy);
            }

            GameObject impactGo = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(impactGo, 4f);

        }

    }
}

