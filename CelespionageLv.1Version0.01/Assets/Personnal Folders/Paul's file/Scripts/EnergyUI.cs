using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour
{


    private EnergyLogic currentenergy;
    private Image barImage;

    // This class is the visual aspect of the UI, the Logic is in a sseperate class.
    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        currentenergy = new EnergyLogic();
    }

    private void Update()
    {
        currentenergy.Update();

        barImage.fillAmount = currentenergy.GetEnergyNormalized();
    }





}
public class EnergyLogic : MonoBehaviour
{
    public const int Energy_MAX = 100;

    private float currentEnergy;
    private float energyRegenAmount;

    public EnergyLogic()
    {
        currentEnergy = 0;
        energyRegenAmount = 5f;

    }
    public void Update()
    {
        currentEnergy += energyRegenAmount * Time.deltaTime;
        currentEnergy = Mathf.Clamp(currentEnergy, 0f, Energy_MAX);

        
    }
    public void TrySpendEnergy(int amount)
    {
        if (currentEnergy >= amount)
        {
            currentEnergy -= amount;
        }
    }
    public float GetEnergyNormalized()
    {
        return currentEnergy / Energy_MAX;
    }

    //public void DrainEnergy(float drain)
   // {
    //    currentEnergy -= drain;
   // }
}


