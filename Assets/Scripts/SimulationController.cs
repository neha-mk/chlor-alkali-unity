using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimulationController : MonoBehaviour
{
    public Slider currentSlider;

    public TextMeshProUGUI currentValueText;

    public TextMeshProUGUI secCL2Text;
    public TextMeshProUGUI secH2Text;
    public TextMeshProUGUI secNaOHText;

    public TextMeshProUGUI mCL2Text;
    public TextMeshProUGUI mH2Text;
    public TextMeshProUGUI mNaOHText;

    public ElectronSpawner electronSpawner;
    public AudioSource audioSource;

    // Ion particle systems
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    public ParticleSystem ps5;
    public ParticleSystem ps6;

    // Gas particle systems
    public ParticleSystem gasPS1;
    public ParticleSystem gasPS2;

    // 🔥 Base values (from Inspector)
    float[] baseSpeeds = new float[6];
    float[] baseEmissionRates = new float[6];
    float[] baseGasEmissionRates = new float[2];

    float baseElectronSpeed = 1f;
    float baseSpawnRate = 0.09f;

    //----------------------------------
    // MANUAL VALUES (EDIT THESE)
    //----------------------------------

    int[] currentDensityValues = { 2500, 4000, 5500, 7000 };

    public float[] secCL2Values = { 0, 0, 0, 0 };
    public float[] secH2Values = { 0, 0, 0, 0 };
    public float[] secNaOHValues = { 0, 0, 0, 0 };

    public float[] mCL2Values = { 0, 0, 0, 0 };
    public float[] mH2Values = { 0, 0, 0, 0 };
    public float[] mNaOHValues = { 0, 0, 0, 0 };

    public float[] soundPitchValues = { 0.2f, 0.45f, 0.65f, 0.85f };
    //----------------------------------

    void Start()
    {
        currentSlider.minValue = 0;
        currentSlider.maxValue = 3;
        currentSlider.wholeNumbers = true;

        currentSlider.value = 0;
        currentSlider.onValueChanged.AddListener(UpdateSimulation);

        //----------------------------------
        // 🔥 STORE ION BASE VALUES
        //----------------------------------

        ParticleSystem[] ionSystems = { ps1, ps2, ps3, ps4, ps5, ps6 };

        for (int i = 0; i < ionSystems.Length; i++)
        {
            if (ionSystems[i] == null) continue;

            var main = ionSystems[i].main;
            var emission = ionSystems[i].emission;

            baseSpeeds[i] = main.startSpeed.constant;
            baseEmissionRates[i] = emission.rateOverTime.constant;
        }

        //----------------------------------
        // 🔥 STORE GAS BASE VALUES
        //----------------------------------

        ParticleSystem[] gasSystems = { gasPS1, gasPS2 };

        for (int i = 0; i < gasSystems.Length; i++)
        {
            if (gasSystems[i] == null) continue;

            var emission = gasSystems[i].emission;
            baseGasEmissionRates[i] = emission.rateOverTime.constant;
        }

        //----------------------------------

        UpdateSimulation(currentSlider.value);
    }

    //----------------------------------

    public void UpdateSimulation(float sliderValue)
    {
        int index = (int)sliderValue;

        float currentDensity = currentDensityValues[index];

        currentValueText.text = currentDensity.ToString("0") + " A/m²";

        // ✅ Smooth scaling (prevents extreme jumps)
        float factor = Mathf.Sqrt(currentDensity / 2500f);

        //----------------------------------
        // ELECTRONS
        //----------------------------------

        electronSpawner.speed = baseElectronSpeed * factor;
        electronSpawner.spawnRate = baseSpawnRate / factor;

        //----------------------------------
        // ION PARTICLES
        //----------------------------------

        UpdateIonParticles(ps1, 0, factor);
        UpdateIonParticles(ps2, 1, factor);
        UpdateIonParticles(ps3, 2, factor);
        UpdateIonParticles(ps4, 3, factor);
        UpdateIonParticles(ps5, 4, factor);
        UpdateIonParticles(ps6, 5, factor);

        //----------------------------------
        // GAS PARTICLES
        //----------------------------------

        UpdateGasParticles(gasPS1, 0, factor);
        UpdateGasParticles(gasPS2, 1, factor);

        //----------------------------------
        // DISPLAY MANUAL VALUES
        //----------------------------------

        secCL2Text.text = secCL2Values[index].ToString("F2");
        secH2Text.text = secH2Values[index].ToString("F2");
        secNaOHText.text = secNaOHValues[index].ToString("F2");

        mCL2Text.text = mCL2Values[index].ToString("F2");
        mH2Text.text = mH2Values[index].ToString("F2");
        mNaOHText.text = mNaOHValues[index].ToString("F2");

        //----------------------------------
        // Sound pitch values
        //----------------------------------
        // audioSource.pitch = soundPitchValues[index];
        audioSource.pitch = Mathf.Clamp(soundPitchValues[index], 0.5f, 1.2f);
    }

    //----------------------------------
    // UPDATE IONS
    //----------------------------------

    void UpdateIonParticles(ParticleSystem ps, int index, float factor)
    {
        if (ps == null) return;

        var main = ps.main;
        var emission = ps.emission;

        // ✅ Always scale from ORIGINAL inspector values
        main.startSpeed = baseSpeeds[index] * factor;

        emission.rateOverTime = Mathf.Min(baseEmissionRates[index] * factor, 50f);

        // Optional: force reset to avoid leftover particles
        
    }

    //----------------------------------
    // UPDATE GAS
    //----------------------------------

    void UpdateGasParticles(ParticleSystem ps, int index, float factor)
    {
        if (ps == null) return;

        var emission = ps.emission;

        emission.rateOverTime = Mathf.Min(baseGasEmissionRates[index] * factor, 50f);

        // Optional reset
        
    }
}