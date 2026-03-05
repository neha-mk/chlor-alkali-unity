using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimulationController : MonoBehaviour
{
    public Slider currentSlider;
    public TextMeshProUGUI currentText;

    public ParticleSystem[] ionSystems;
    public ParticleSystem[] gasSystems;

    public ElectronSpawner electronSystem;

    void Start()
    {
        currentSlider.onValueChanged.AddListener(UpdateSimulation);
        UpdateSimulation(currentSlider.value);
    }

    void UpdateSimulation(float current)
    {
        currentText.text = current.ToString("0") + " A/m²";

        float factor = current / 2500f;

        // Ion behaviour
        float ionSpeed = 0.15f * factor * 2f;
        float emissionRate = 40f * factor * 3f;
        float turbulence = 0.05f * factor * 2f;

        // Gas bubbles
        float bubbleRate = 6f * factor * 4f;

        // Electron speed only (spawn rate stays constant)
        float electronSpeed = 1f * factor * 3f;

        foreach (ParticleSystem ps in ionSystems)
        {
            var main = ps.main;
            main.startSpeed = ionSpeed;

            var emission = ps.emission;
            emission.rateOverTime = emissionRate;

            var noise = ps.noise;
            noise.strength = turbulence;
        }

        foreach (ParticleSystem gas in gasSystems)
        {
            var emission = gas.emission;
            emission.rateOverTime = bubbleRate;
        }

        // Only electron speed changes
        electronSystem.speed = electronSpeed;
    }
}