using System;
using UnityEngine;

public class PlantSlot : MonoBehaviour
{
    public Seed CurrentSeed;
    public GameObject CurrentPlant;
    public bool SeedPlanted  { get; private set; } = false ;
    public bool PlantGrowed  { get; private set; } = false; 
    [SerializeField] private Transform PlantSpawnPoint;
    private string _currentPlantName;
    

    private void PlantSeed(string seedName)
    {
        Debug.Log("seed Plant");
        _currentPlantName = seedName;
    }

    private void GrownPlant()
    {
        PlantGrowed = true;
        Debug.Log("Water Plant");
        Instantiate(CurrentPlant,transform.position,Quaternion.identity, transform);
        PlantPuzzle.OnPlantGrown?.Invoke(this);
    }
    
    public string GetPlantLatinName()
    {
        return _currentPlantName;
    }

    private void ResetPlant()
    {
        PlantGrowed = false;
        _currentPlantName = null;
        Destroy(CurrentPlant);
        CurrentSeed = null;
    }


    private void OnParticleCollision(GameObject other)
    {
        if (!SeedPlanted) return;
        if (other.CompareTag("Seed"))
        {
           // PlantSeed(other.GetComponent<>());
        }
        
        if (PlantGrowed) return;
        if (other.CompareTag("Water"))
        {
            GrownPlant();
        }


    }

   
    
}
