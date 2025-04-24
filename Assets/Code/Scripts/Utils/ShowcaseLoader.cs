using UnityEngine;
using UnityEngine.UI;

using Code.Scripts.Source.Managers;

namespace Code.Scripts.Utils
{
    public class ShowcaseLoader : MonoBehaviour
    {
        [Header("Scenes")]
        [SerializeField] private string _hall;
        [SerializeField] private string _living;
        [SerializeField] private string _greenhouse;
        [SerializeField] private string _laboratory;

        [Header("Buttons")]
        [SerializeField] private Button _loadHall;
        [SerializeField] private Button _loadLiving;
        [SerializeField] private Button _loadGreenhouse;
        [SerializeField] private Button _loadLaboratory;

        private void OnEnable()
        {
            _loadHall.onClick.AddListener(LoadHall);
            _loadLiving.onClick.AddListener(LoadLiving);
            _loadGreenhouse.onClick.AddListener(LoadGreenhouse);
            _loadLaboratory.onClick.AddListener(LoadLaboratory);
        }

        private void OnDisable()
        {
            _loadHall.onClick.RemoveListener(LoadHall);
            _loadLiving.onClick.RemoveListener(LoadLiving);
            _loadGreenhouse.onClick.RemoveListener(LoadGreenhouse);
            _loadLaboratory.onClick.RemoveListener(LoadLaboratory);
        }

        private void LoadLaboratory()
        {
            SceneTransitionManager.Instance.LoadScene(_laboratory);
        }

        private void LoadGreenhouse()
        {
            SceneTransitionManager.Instance.LoadScene(_greenhouse);
        }

        private void LoadLiving()
        {
            SceneTransitionManager.Instance.LoadScene(_living);
        }

        private void LoadHall()
        {
            SceneTransitionManager.Instance.LoadScene(_hall);
        }
    }
}
