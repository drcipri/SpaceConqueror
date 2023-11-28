using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXBigLaser : MonoBehaviour
{
    
    ParticleSystem beam;
    ParticleSystem flash;
    ParticleSystem.MainModule theBeam;
    ParticleSystem.MainModule theFlash;
    float beamSize = 1f;


    private void Awake()
    {
        beam = gameObject.transform.GetChild(1).GetComponent<ParticleSystem>();
        flash = gameObject.transform.GetChild(2).GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        theBeam = beam.main;
        theFlash = flash.main;
        
    }
    private void Update()
    {
        StartBeamVfx();
    }


    private void StartBeamVfx()
    {
        theBeam.startSize = beamSize;
        if(beamSize < 5f)
        {
            beamSize += Time.deltaTime;
        }
        if(beamSize > 4.5f)
        {
            theFlash.loop = false;
        }

        
    }


    

}
