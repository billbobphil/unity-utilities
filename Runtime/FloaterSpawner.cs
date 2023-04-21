using System.Collections;
using TMPro;
using UnityEngine;

namespace Utilities
{
    public class FloaterSpawner : MonoBehaviour
    {
        public GameObject floaterPrefab;
        public int minimumDollarSigns = 1;
        public int maximumDollarSigns = 5;
        public int minFontSize = 24;
        public int maxFontSize = 48;
        public int minSpawnTime = 1;
        public int maxSpawnTime = 5;

        private void Start()
        {
            StartCoroutine(SpawnFloaterCoroutine());    
        }
        
        private IEnumerator SpawnFloaterCoroutine()
        {
            while (true)
            {
                int randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
                yield return new WaitForSeconds(randomSpawnTime);
                SpawnFloater();
            }
        }
        
        public void SpawnFloater()
        {
            GameObject createdFloater = Instantiate(floaterPrefab, transform.position, Quaternion.identity);

            string dollarSignsString = "";
            int randomDollarSigns = Random.Range(minimumDollarSigns, maximumDollarSigns);
            int randomFontSize = Random.Range(minFontSize, maxFontSize);
            
            for(int i = 0; i < randomDollarSigns; i++)
            {
                dollarSignsString += "$";
            }

            TextMeshPro text = createdFloater.GetComponent<TextMeshPro>();
            text.text = dollarSignsString;
            text.fontSize = randomFontSize;
        }
    }
}
