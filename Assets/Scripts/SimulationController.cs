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

    float baseIonSpeed = 0.4f;
    float baseElectronSpeed = 1f;
    float baseSpawnRate = 0.09f;

    //----------------------------------
    // MANUAL VALUES (EDIT THESE)
    //----------------------------------

    int[] currentDensityValues = { 2500, 4000, 5500, 7000 };

    public float[] secCL2Values = { 0, 0, 0, 0 };
    public float[] secH2Values = { 0, 0, 0, 0 };
    public float[] secNaOHValues= { 0, 0, 0, 0 };

    public float[] mCL2Values = { 0, 0, 0, 0 };
    public float[] mH2Values = { 0, 0, 0, 0 };
    public float[] mNaOHValues = { 0, 0, 0, 0 };

    //----------------------------------

    void Start()
    {
        currentSlider.minValue = 0;
        currentSlider.maxValue = 3;
        currentSlider.wholeNumbers = true;

        currentSlider.value = 0;

        currentSlider.onValueChanged.AddListener(UpdateSimulation);

        UpdateSimulation(currentSlider.value);
    }

    //----------------------------------

    public void UpdateSimulation(float sliderValue)
    {
        Debug.Log("Slider moved: " + sliderValue);

        int index = (int)sliderValue;

        float currentDensity = currentDensityValues[index];

        currentValueText.text = currentDensity.ToString("0") + " A/m²";

        int particleCount = GetParticleCount(currentDensity);

        float factor = currentDensity / 2500f;

        //----------------------------------
        // ELECTRONS
        //----------------------------------

        electronSpawner.speed = baseElectronSpeed * factor;
        electronSpawner.spawnRate = baseSpawnRate / factor;

        //----------------------------------
        // ION PARTICLES
        //----------------------------------

        UpdateIonParticles(ps1, factor, particleCount);
        UpdateIonParticles(ps2, factor, particleCount);
        UpdateIonParticles(ps3, factor, particleCount);
        UpdateIonParticles(ps4, factor, particleCount);
        UpdateIonParticles(ps5, factor, particleCount);
        UpdateIonParticles(ps6, factor, particleCount);

        //----------------------------------
        // GAS PARTICLES
        //----------------------------------

        UpdateGasParticles(gasPS1, particleCount);
        UpdateGasParticles(gasPS2, particleCount);

        //----------------------------------
        // DISPLAY MANUAL VALUES
        //----------------------------------

        secCL2Text.text = secCL2Values[index].ToString("F2") ;
        secH2Text.text = secH2Values[index].ToString("F2") ;
        secNaOHText.text = secNaOHValues[index].ToString("F2") ;

        mCL2Text.text = mCL2Values[index].ToString("F2");
        mH2Text.text = mH2Values[index].ToString("F2");
        mNaOHText.text = mNaOHValues[index].ToString("F2");
    }

    //----------------------------------
    // PARTICLE COUNT
    //----------------------------------

    int GetParticleCount(float current)
    {
        float ratio = (current - 2500f) / (7000f - 2500f);
        return Mathf.RoundToInt(10 + ratio * 20);
    }

    //----------------------------------
    // UPDATE IONS
    //----------------------------------

    void UpdateIonParticles(ParticleSystem ps, float factor, int particleCount)
    {
        if (ps == null) return;

        var main = ps.main;
        main.startSpeed = baseIonSpeed * factor;

        var emission = ps.emission;
        emission.rateOverTime = particleCount;
    }

    //----------------------------------
    // UPDATE GAS
    //----------------------------------

    void UpdateGasParticles(ParticleSystem ps, int particleCount)
    {
        if (ps == null) return;

        var emission = ps.emission;
        emission.rateOverTime = particleCount;
    }
}