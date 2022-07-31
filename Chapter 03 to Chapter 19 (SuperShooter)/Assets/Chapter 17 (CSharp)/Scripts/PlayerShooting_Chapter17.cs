using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting_Chapter17 : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public ParticleSystem muzzleEffect;
    public AudioSource shootSound;
    
    public int bulletsAmount;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed && bulletsAmount > 0 && Time.timeScale > 0)
        {
            animator.SetBool("Shooting", true);
            
            bulletsAmount--;
            
            GameObject clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
            
            muzzleEffect.Play();
            shootSound.Play();
        }
        else
        {
            animator.SetBool("Shooting", false);
        }
    }
}


