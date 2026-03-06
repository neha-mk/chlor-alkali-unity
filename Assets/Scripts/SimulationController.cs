using UnityEngine;
using UnityEngine.UI;

public class SimulationController : MonoBehaviour
{
    public Slider currentSlider;

    public ElectronSpawner electronSpawner;

    // 6 particle system slots
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    public ParticleSystem ps5;
    public ParticleSystem ps6;

    float baseIonSpeed = 0.4f;

    float baseElectronSpeed = 1f;
    float baseSpawnRate = 0.09f;

    void Start()
    {
        currentSlider.onValueChanged.AddListener(UpdateSimulation);
        UpdateSimulation(currentSlider.value);
    }

    void UpdateSimulation(float current)
    {
        float factor = current / 2500f;

        //----------------------------------
        // ELECTRONS
        //----------------------------------

        electronSpawner.speed = baseElectronSpeed * factor;

        // decrease spawnRate so electrons remain dense
        electronSpawner.spawnRate = baseSpawnRate / factor;

        //----------------------------------
        // PARTICLE SYSTEMS
        //----------------------------------

        UpdateParticles(ps1, factor);
        UpdateParticles(ps2, factor);
        UpdateParticles(ps3, factor);
        UpdateParticles(ps4, factor);
        UpdateParticles(ps5, factor);
        UpdateParticles(ps6, factor);
    }

    void UpdateParticles(ParticleSystem ps, float factor)
    {
        if (ps == null) return;

        var main = ps.main;
        main.startSpeed = baseIonSpeed * factor;

        var emission = ps.emission;
        emission.rateOverTime = 40 * factor;
    }
}