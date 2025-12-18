using TMPro;
using UnityEngine;

public class ManageCPUParticleSystem : MonoBehaviour
{
    [SerializeField]
    private float emissionRateMultiplierEverySecond = 1.5f;

    [SerializeField]
    private TextMeshProUGUI particlesText;

    private ParticleSystem cpuParticleSystem;

    private float timeRemain;

    private void Awake()
    {
        cpuParticleSystem = GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        particlesText.text = $"CPU Particles: {cpuParticleSystem.particleCount}";
        timeRemain -= Time.deltaTime;
        if (timeRemain <= 0f)
        {
            var emission = cpuParticleSystem.emission;
            emission.rateOverTimeMultiplier *= emissionRateMultiplierEverySecond;
            timeRemain = 1f;
        }
    }
}
