using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;


namespace Models
{
    public class ModuleLoader : MonoBehaviour
    {
        public static ModuleLoader Instance { get; private set; }

        [System.Serializable]
        public struct Connection {
            public string fromDoorID;        // ID de la porte déclencheur
            public AssetReference moduleReference; // Prefab Addressable du module cible
            public string targetDoorID;      // ID de la porte d'arrivée dans le module cible
        }

        [Header("Configuration des connexions")]
        public Connection[] connections;

        [Header("Réglages")]
        public float unloadDistance = 30f;
        public Transform playerRig;      // votre XR Rig ou caméra VR

        // Internes
        Dictionary<string, Connection> map;
        List<GameObject> loadedModules = new List<GameObject>();

        void Awake() {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
            BuildMap();
        }

        void BuildMap() {
            map = new Dictionary<string, Connection>();
            foreach (var c in connections) {
                if (!map.ContainsKey(c.fromDoorID))
                    map.Add(c.fromDoorID, c);
                else
                    Debug.LogWarning($"Duplicate connection fromDoorID: {c.fromDoorID}");
            }
        }

        public void OnDoorTrigger(string doorID) {
            if (!map.TryGetValue(doorID, out var conn)) return;
            StartCoroutine(LoadAndTeleport(conn));
        }

        IEnumerator LoadAndTeleport(Connection conn) {
            // 1. Charger le module cible
            var handle = conn.moduleReference.LoadAssetAsync<GameObject>();
            yield return handle;
            GameObject moduleGO = Instantiate(handle.Result);
            loadedModules.Add(moduleGO);

            // 2. Trouver la porte d'arrivée
            var anchors = moduleGO.GetComponentsInChildren<DoorAnchor>();
            DoorAnchor target = System.Array.Find(anchors, a => a.doorID == conn.targetDoorID);
            if (target != null) {
                // Téléportation imperceptible (à coupler avec fade)
                // playerRig.position = target.spawnPoint.position;
                // playerRig.rotation = target.spawnPoint.rotation;
            } else {
                Debug.LogError($"Target doorID '{conn.targetDoorID}' not found in module '{moduleGO.name}'");
            }

            // 3. Désinstancier modules trop éloignés
            for (int i = loadedModules.Count - 1; i >= 0; i--) {
                if (Vector3.Distance(loadedModules[i].transform.position, playerRig.position) > unloadDistance) {
                    Destroy(loadedModules[i]);
                    loadedModules.RemoveAt(i);
                }
            }
        }
    }
}