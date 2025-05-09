using UnityEngine;

public class SeedBag : MonoBehaviour
{
    public string PlantName => _plantName;
    [SerializeField] private string _plantName;
    public GameObject PlantPrefab => _plantPrefab;
    [SerializeField] private GameObject _plantPrefab;
    
}
