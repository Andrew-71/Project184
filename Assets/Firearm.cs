using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firearm : MonoBehaviour
{
    // Damage-related fields
    [SerializeField] private float damage = 10f;
    [SerializeField] private float range = 100f;
    [SerializeField] private float fireRate = 10f;

    // Ammunition-related fields
    [SerializeField] private float reloadTime = 1f;
    [SerializeField] private int maxAmmo = 90;
    [SerializeField] private int clipSize = 10;
    [SerializeField] private int currentAmmo = 10;

    // shooting sound (full + empty)
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip emptySound;
    [SerializeField] private AudioClip reloadSound;

    [SerializeField] private TrailRenderer tracer;

    private float nextTimeToFire = 0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        // if left mouse/RT is pressed attempt to fire
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + fireRate * 1000;
            Shoot();
        }

        // if R is pressed attempt to reload (OR X on controller)
        if ((Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("Reload")) && currentAmmo < clipSize)
        {
            Reload();
        }
    }

    void Shoot() {
        // if there is ammo in the clip
        if (currentAmmo > 0) {
            // play shooting sound
            GetComponent<AudioSource>().PlayOneShot(shootSound);
            // reduce ammo by 1
            currentAmmo--;
            nextTimeToFire = Time.time + 1f / fireRate;
            // raycast from center of screen
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range)) {
                // draw a tracer line
                StartCoroutine(Tracer(hit.point));


                // if raycast hits something
                Debug.Log(hit.transform.name);
                // if raycast hits a target
                //Target target = hit.transform.GetComponent<Target>();
                //if (target != null) {
                //    // deal damage to target
                //    target.TakeDamage(damage);
                //}
            }
        } else {
            // play empty sound
            GetComponent<AudioSource>().PlayOneShot(emptySound);
            nextTimeToFire = Time.time + 1000;
        }
    }

    void Reload() {
        nextTimeToFire = Time.time + Mathf.Infinity;
        GetComponent<AudioSource>().PlayOneShot(reloadSound).OnComplete(() => {
            currentAmmo = Mathf.Min(maxAmmo, clipSize);
            nextTimeToFire = Time.time + 1f / fireRate;
        });
    }

    IEnumerator Tracer(Vector3 hitPoint) {
        tracer.enabled = true;
        tracer.SetPosition(0, tracer.transform.position);
        tracer.SetPosition(1, hitPoint);
        yield return new WaitForSeconds(0.01f);
        tracer.enabled = false;
    }
}
