using Global;
using TMPro;
using UnityEngine;

namespace Menu
{
    public class BestResultsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bestScoreText;
        [SerializeField] private TMP_Text _bestTimeText;
        
        private void OnEnable()
        {
            SaveData saveData = GameManager.Load();
            _bestScoreText.text = $"Best Score: {saveData.Score}";
            _bestTimeText.text = $"Best Time: {saveData.Time}";
        }
    }
}