using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeaderPanel : MonoBehaviour
    {
        [SerializeField] private Text textCoins;
        [SerializeField] private Animator textAnimator;
        
        public void OnChangeCoinsValue(int coins)
        {
            textCoins.text = coins.ToString();
            textAnimator.enabled = true;
            StartCoroutine(DeactivateAnimator());
        }

        private IEnumerator DeactivateAnimator()
        {
            yield return new WaitForSeconds(1f);
            textAnimator.enabled = false;
        }

        public void InitCoinsValue(int coinsValue)
        {
            textCoins.text = coinsValue.ToString();
        }
    }
}