using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [Header("Energy Settings:")]
    [Range(1, 100)] public float maxEnergy = 100.0f;

    private float currentEnergy;
    private float energyRegenAmount = 20f;
    private Image barImage;


    [Header("Debug Settings:")]
    public bool debugComponent = false;

    private void Awake()
    {
        barImage = transform.Find("Bar").GetComponent<Image>();

        barImage.fillAmount = .3f;
    }

   

    void Start()
    {
        currentEnergy = maxEnergy;    // Initialize current health with max health.

        if (debugComponent)
            Debug.Log(gameObject.name + " Energy: " + currentEnergy + "/" + maxEnergy);
    }

    // Update is called once per frame
    public void Update()
    {
        // Check energy levels
        if (currentEnergy <= 0)
        {
            currentEnergy = 0;

            
        }
        else if (currentEnergy >= maxEnergy)
        {
            currentEnergy = maxEnergy;
        }

        currentEnergy += energyRegenAmount * Time.deltaTime; 
    }

   
    /// <param name="heal"></param>
    public void RestoreEnergy(float heal)
    {
        currentEnergy += heal;

        if (debugComponent)
            Debug.Log(gameObject.name + " Energy: " + currentEnergy + "/" + maxEnergy);
    }

    /// <summary>
    /// A method for draining Energy component.
    /// </summary>
    /// <param name="drain"></param>
    public void ConsumeEnergy(float drain)
    {
        currentEnergy -= drain;

        if (debugComponent)
            Debug.Log(gameObject.name + " Energy: " + currentEnergy + "/" + maxEnergy);
    }
}

