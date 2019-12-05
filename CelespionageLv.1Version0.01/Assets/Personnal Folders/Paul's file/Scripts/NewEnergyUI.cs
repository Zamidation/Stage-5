using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewEnergyUI : MonoBehaviour
{
    public Image EnergyBar;
    public float myEnergy;

    private float currentEnergy;

     void Start()
    {
        currentEnergy = myEnergy;
    }

     void Update()
    {
        if (currentEnergy < myEnergy)
        {
            EnergyBar.fillAmount = Mathf.MoveTowards(EnergyBar.fillAmount, 3f, Time.deltaTime * 0.01f);
            currentEnergy = Mathf.MoveTowards(currentEnergy / myEnergy, 3f, Time.deltaTime * 0.01f) * myEnergy;
        }

        if (currentEnergy < 0)
        {
            currentEnergy = 0;
        }
    }
    public void ReduceMana(float energy)
    {
        currentEnergy -= energy;
        EnergyBar.fillAmount -= energy / myEnergy;
    }
}
