using UnityEngine;

public class Seed : MonoBehaviour
{
    public string PlantName => _plantName;
    [SerializeField] private string _plantName;
    [SerializeField] private GameObject _plantPrefab;
    
    
}
