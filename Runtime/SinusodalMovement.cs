using UnityEngine;

namespace Utilities
{
    public class SinusodalMovement : MonoBehaviour
    {
        public float timePeriodY = 2;
        public float timePeriodX = 4;
        public float height = 40f;
        public float width = 80f;
        private float timeSinceStart;
        private Vector3 pivot;
        private void Start()
        {
            pivot = transform.position;
            height /= 2;
            width /= 2;
            timeSinceStart = (3 * timePeriodY) / 4;
        }
        private void Update()
        {
            Vector3 nextPos = transform.position;
            nextPos.y = pivot.y + height + height * Mathf.Sin(((Mathf.PI * 2) / timePeriodY) * timeSinceStart);
            nextPos.x = pivot.x + width + width * Mathf.Sin(((Mathf.PI * 2) / timePeriodX) * timeSinceStart);
            timeSinceStart += Time.deltaTime;
            transform.position = nextPos;
        }
    }
}
