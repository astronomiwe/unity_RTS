using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Rain: MonoBehaviour
{
    public Light dirLight;
    private ParticleSystem _particleSystem;
    private bool _isRain = false;

    private void Start()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        StartCoroutine(Weather());
    }

    private void Update()
    {
        if (_isRain && dirLight.intensity > 0.25f)
            LightIntensity(-1);
        if (!_isRain && dirLight.intensity < 0.8f)
            LightIntensity(1);
    }

    private void LightIntensity(int multiplier)
    {
        dirLight.intensity += 0.1f * Time.deltaTime * multiplier;
    }

    IEnumerator Weather()
    {
        while (true)
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(5f, 5f));
            
            if (_isRain)
                _particleSystem.Stop();
            else
                _particleSystem.Play();
            
            _isRain = !_isRain;
        }
    }
}