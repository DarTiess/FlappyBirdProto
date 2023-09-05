using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamePlay
{
    public class PlayerEffects: MonoBehaviour
    {
        [SerializeField] private List<GameObject> _flyEffect;
        [SerializeField] private float _flyEffectTimer;

        public void FlyEffect()
        {
            StopCoroutine(PlayEffect());
            StartCoroutine(PlayEffect());
        }

        IEnumerator PlayEffect()
        {
            _flyEffect[1].SetActive(true);
            yield return new WaitForSeconds(_flyEffectTimer);
            _flyEffect[1].SetActive(false);
        }

        public void StopEffects()
        {
            foreach (GameObject effect in _flyEffect)
            {
                effect.SetActive(false);
            }
        }
    }
}