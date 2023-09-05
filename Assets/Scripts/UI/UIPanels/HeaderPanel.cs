using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.UIPanels
{
    public class HeaderPanel : MonoBehaviour
    {
        [SerializeField] private Text _textCoins;
        [SerializeField] private Animator _textAnimator;
        public void OnChangeCoinsValue(int coins)
        {
            _textCoins.text = coins.ToString();
            _textAnimator.enabled = true;
            StartCoroutine(DeactivateAnimator());
        }

        private IEnumerator DeactivateAnimator()
        {
            yield return new WaitForSeconds(1f);
            _textAnimator.enabled = false;
        }

        public void InitCoinsValue(int coinsValue)
        {
            _textCoins.text = coinsValue.ToString();
        }
    }
}