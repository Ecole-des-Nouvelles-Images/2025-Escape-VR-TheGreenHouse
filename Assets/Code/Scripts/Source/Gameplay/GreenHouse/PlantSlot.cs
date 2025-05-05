using System;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    public Seed CurrentSeed;
    public GameObject CurrentPlant;
    public bool SeedPlanted = false;
    public bool PlantGrowned = false; 
    [SerializeField] private Transform PlantSpawnPoint;
    


    private void PlantSeed()
    {
        Debug.Log("seed Plant");
    }

    private void GrownPlant()
    {
        PlantGrowned = true;
        Debug.Log("Water Plant");
        Instantiate(CurrentPlant,transform.position,Quaternion.identity, transform);
        
    }

    private void ResetPlant()
    {
        Destroy(CurrentPlant);
        CurrentSeed = null;
    }


    private void OnParticleCollision(GameObject other)
    {
        if (!SeedPlanted) return;
        if (other.CompareTag("Seed"))
        {
            PlantSeed();
        }
        
        if (PlantGrowned) return;
        if (other.CompareTag("Water"))
        {
            GrownPlant();
        }


    }

   
    
}
