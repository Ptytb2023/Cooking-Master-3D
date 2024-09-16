using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ProgressLine : MonoBehaviour, IProgressLine
    {
        [SerializeField] private Image _proggressLine;

        private void Awake() =>
            Close();

        public void Show() =>
            gameObject.SetActive(true);

        public void Close() =>
            gameObject.SetActive(false);

        public void SetProgress(float progress) =>
            _proggressLine.fillAmount = progress;


        private void OnValidate() =>
            _proggressLine.type = Image.Type.Filled;
    }
}