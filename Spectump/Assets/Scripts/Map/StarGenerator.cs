using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    public List<GameObject> starList = new List<GameObject>(4);

    public float StarOneChance = 1f;
    public float StarTwoChance = 1f;
    public float StarThreeChance = 1f;
    public float StarFourChance = 1f;

    public float DistanceMinBetweenTwoStarMin = 1f;
    public float DistanceMinBetweenTwoStarMax = 10f;

    private float DistanceMinBetweenTwoStar;

    public int numberOfStarsMin = 50;
    public int numberOfStarsMax = 150;

    private int numberOfStars;

    public float generationRadius = 200f;

    public void Start()
    {
        // Generate random values for NumberOfStars and DistanceMinBetweenTwoStar
        numberOfStars = Random.Range(numberOfStarsMin, numberOfStarsMax + 1);
        DistanceMinBetweenTwoStar = Random.Range(DistanceMinBetweenTwoStarMin, DistanceMinBetweenTwoStarMax);

        GenerateStars();
    }

    private void GenerateStars()
    {
        for (int i = 0; i < numberOfStars; i++)
        {
            float randomX = Random.Range(-generationRadius, generationRadius);
            float randomY = Random.Range(-generationRadius, generationRadius);

            Vector3 randomPosition = new Vector3(randomX, randomY, 0f);

            if (IsFarEnoughFromOtherStars(randomPosition))
            {
                float randomValue = Random.value;

                GameObject selectedStar = null;

                if (randomValue < StarOneChance)
                    selectedStar = starList[0];
                else if (randomValue < StarTwoChance)
                    selectedStar = starList[1];
                else if (randomValue < StarThreeChance)
                    selectedStar = starList[2];
                else
                    selectedStar = starList[3];

                Instantiate(selectedStar, randomPosition, Quaternion.identity, transform);
            }
            else
            {
                i--;
            }
        }
    }

    private bool IsFarEnoughFromOtherStars(Vector3 position)
    {
        foreach (GameObject star in starList)
        {
            if (star != null)
            {
                float distance = Vector3.Distance(position, star.transform.position);

                if (distance < DistanceMinBetweenTwoStar)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
