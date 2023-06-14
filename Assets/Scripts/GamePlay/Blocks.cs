using UnityEngine;

namespace GamePlay
{
    public class Blocks : MonoBehaviour
    {
        public void Init(Transform parent)
        {
            transform.parent = parent;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
    }
}