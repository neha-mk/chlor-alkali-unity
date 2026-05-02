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
    public ParticleSystem ps1, ps2, ps3, ps4, ps5, ps6;

    // Gas particle systems
    public ParticleSystem gasPS1, gasPS2;

    // Base values
    float[] baseSpeeds = new float[6];
    float[] baseEmissionRates = new float[6];
    float[] baseSizes = new float[6];

    float[] baseGasEmissionRates = new float[2];
    float[] baseGasSizes = new float[2];

    float baseElectronSpeed = 1f;
    float baseSpawnRate = 0.09f;

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
        // STORE BASE VALUES (IONS)
        //----------------------------------

        ParticleSystem[] ions = { ps1, ps2, ps3, ps4, ps5, ps6 };

        for (int i = 0; i < ions.Length; i++)
        {
            if (ions[i] == null) continue;

            var main = ions[i].main;
            var emission = ions[i].emission;

            baseSpeeds[i] = main.startSpeed.constant;
            baseEmissionRates[i] = emission.rateOverTime.constant;
            baseSizes[i] = main.startSize.constant;
        }

        //----------------------------------
        // STORE BASE VALUES (GASES)
        //----------------------------------

        ParticleSystem[] gases = { gasPS1, gasPS2 };

        for (int i = 0; i < gases.Length; i++)
        {
            if (gases[i] == null) continue;

            var main = gases[i].main;
            var emission = gases[i].emission;

            baseGasEmissionRates[i] = emission.rateOverTime.constant;
            baseGasSizes[i] = main.startSize.constant;
        }

        //----------------------------------

        UpdateSimulation(0);
    }

    //----------------------------------

    public void UpdateSimulation(float sliderValue)
    {
        int index = (int)sliderValue;
        float currentDensity = currentDensityValues[index];

        currentValueText.text = currentDensity + " A/m²";

        //----------------------------------
        // 🔥 TWO DIFFERENT FACTORS
        //----------------------------------

        float ionFactor = GetStepFactor(index); // strong jump
        float electronFactor = Mathf.Sqrt(currentDensity / 2500f); // smooth

        //----------------------------------
        // ELECTRONS (FIXED)
        //----------------------------------

        electronSpawner.speed = baseElectronSpeed * electronFactor;
        electronSpawner.spawnRate = baseSpawnRate / electronFactor;

        //----------------------------------
        // IONS
        //----------------------------------

        UpdateIon(ps1, 0, ionFactor);
        UpdateIon(ps2, 1, ionFactor);
        UpdateIon(ps3, 2, ionFactor);
        UpdateIon(ps4, 3, ionFactor);
        UpdateIon(ps5, 4, ionFactor);
        UpdateIon(ps6, 5, ionFactor);

        //----------------------------------
        // GASES
        //----------------------------------

        UpdateGas(gasPS1, 0, ionFactor);
        UpdateGas(gasPS2, 1, ionFactor);

        //----------------------------------
        // UI VALUES
        //----------------------------------

        secCL2Text.text = secCL2Values[index].ToString("F2");
        secH2Text.text = secH2Values[index].ToString("F2");
        secNaOHText.text = secNaOHValues[index].ToString("F2");

        mCL2Text.text = mCL2Values[index].ToString("F2");
        mH2Text.text = mH2Values[index].ToString("F2");
        mNaOHText.text = mNaOHValues[index].ToString("F2");

        //----------------------------------
        // SOUND
        //----------------------------------

        audioSource.pitch = Mathf.Clamp(soundPitchValues[index], 0.5f, 1.2f);
    }

    //----------------------------------
    // STEP FACTOR
    //----------------------------------

    float GetStepFactor(int index)
    {
        if (index == 0) return 1f;
        if (index == 1) return 2f;
        if (index == 2) return 4f;
        return 8f;
    }

    //----------------------------------
    // IONS
    //----------------------------------

    void UpdateIon(ParticleSystem ps, int i, float factor)
    {
        if (ps == null) return;

        var main = ps.main;
        var emission = ps.emission;

        main.startSize = baseSizes[i];

        main.startSpeed = baseSpeeds[i] * (1f + 0.2f * factor);

        emission.rateOverTime = baseEmissionRates[i] * factor;
    }

    //----------------------------------
    // GASES
    //----------------------------------

    void UpdateGas(ParticleSystem ps, int i, float factor)
    {
        if (ps == null) return;

        var main = ps.main;
        var emission = ps.emission;

        main.startSize = baseGasSizes[i];

        emission.rateOverTime = baseGasEmissionRates[i] * (factor * 1.5f);

        emission.SetBursts(new ParticleSystem.Burst[]
        {
            new ParticleSystem.Burst(0f, (short)(2 * factor))
        });
    }
}