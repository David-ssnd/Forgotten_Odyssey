using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class Pulse : MonoBehaviour
{
    [SerializeField] private Volume volume;
    public Bloom bloom;
    public UnityEngine.Rendering.VolumeProfile volumeProfile;
    private float pulse = 4f;
    //private bool increasing = true;
    public bool visible = false;
    private void Start()
    {
        volume.profile.TryGet(out bloom);
    }
    void Update()
    {
        if (visible)
            pulse += Mathf.Log(10f + 1f) * Time.deltaTime;
        bloom.intensity.value = pulse;

        /*if (increasing)
        {
            
            pulse += Time.deltaTime * 5f;
            bloom.intensity.value = pulse;
            if (pulse >= 26f)
            {
                increasing = false;
                Debug.Log("Reached max intensity: " + pulse);
            }
        }
        else
        {
            pulse -= Time.deltaTime * 5f;
            bloom.intensity.value = pulse;

            if (pulse <= 3f)
            {
                increasing = true;
                Debug.Log("Reached min intensity: " + pulse);
            }
        }*/
    }
}