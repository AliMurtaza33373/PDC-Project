using TMPro;
using UnityEngine;
using UnityEngine.VFX;

public class ManageGPUParticleSystem : MonoBehaviour
{
    [SerializeField]
    private float spawnRateMultiplierEverySecond = 1.5f;

    [SerializeField]
    private TextMeshProUGUI particlesText;

    [SerializeField]
    private string spawnRatePropertyName = "SpawnRate";

    private VisualEffect visualEffect;
    private float timeRemain = 1f;

    private void Awake()
    {
        visualEffect = GetComponent<VisualEffect>();
    }

    private void Update()
    {
        // Optional: shows alive particle count (GPU readback, may be delayed)
        if (particlesText != null)
        {
            particlesText.text = $"VFX Particles: {visualEffect.aliveParticleCount}";
        }

        timeRemain -= Time.deltaTime;
        if (timeRemain <= 0f)
        {
            float currentRate = visualEffect.GetFloat(spawnRatePropertyName);
            visualEffect.SetFloat(
                spawnRatePropertyName,
                currentRate * spawnRateMultiplierEverySecond
            );

            timeRemain = 1f;
        }
    }
}
