using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

namespace Utilities
{
    public class FloatAway : MonoBehaviour
    {
        public float xTravelDistance = 0.5f;
        public float yTravelDistance = 0.5f;
        public float floatTimeBeforeDestroy = 1f;
        public Directions floatDirection = Directions.UpRight;
        public bool shouldDestroySelf;
        
        public enum Directions {Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight}
        
        private void Start()
        {
            xTravelDistance = Math.Abs(xTravelDistance);
            yTravelDistance = Math.Abs(yTravelDistance);
            if (shouldDestroySelf)
            {
                StartCoroutine(DestroyAfterTime());
            }
        }

        private void FixedUpdate()
        {
            switch (floatDirection)
            {
                case Directions.Up:
                    transform.position += new Vector3(0, yTravelDistance, 0);
                    break;
                case Directions.Down:
                    transform.position += new Vector3(0, -yTravelDistance, 0);
                    break;
                case Directions.Left:
                    transform.position += new Vector3(-xTravelDistance, 0, 0);
                    break;
                case Directions.Right:
                    transform.position += new Vector3(xTravelDistance, 0, 0);
                    break;
                case Directions.UpLeft:
                    transform.position += new Vector3(-xTravelDistance, yTravelDistance, 0);
                    break;
                case Directions.UpRight:
                    transform.position += new Vector3(xTravelDistance, yTravelDistance, 0);
                    break;
                case Directions.DownLeft:
                    transform.position += new Vector3(-xTravelDistance, -yTravelDistance, 0);
                    break;
                case Directions.DownRight:
                    transform.position += new Vector3(xTravelDistance, -yTravelDistance, 0);
                    break;
            }
        }
        
        private IEnumerator DestroyAfterTime()
        {
            yield return new WaitForSecondsRealtime(floatTimeBeforeDestroy);
            Destroy(gameObject);
        }
    }
}
