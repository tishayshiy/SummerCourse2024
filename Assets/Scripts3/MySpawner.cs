using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MySpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Массив объектов, которые нужно спавнить
    public Transform[] spawnPoints; // Массив точек спавна

    void Start()
    {
        // Создаем список с индексами точек спавна
        List<int> spawnPointIndices = Enumerable.Range(0, spawnPoints.Length).ToList();

        // Перемешиваем список индексов
        System.Random random = new System.Random();
        spawnPointIndices = spawnPointIndices.OrderBy(x => random.Next()).ToList();

        // Сравниваем количество объектов и точек спавна
        int spawnCount = Mathf.Min(objectsToSpawn.Length, spawnPoints.Length);

        // Спавним объекты в рандомной последовательности
        for (int i = 0; i < spawnCount; i++)
        {
            // Получаем индекс точки спавна из перемешанного списка
            int spawnPointIndex = spawnPointIndices[i];

            // Спавним объект
            Instantiate(objectsToSpawn[i], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        }
    }
}

//Создайте пустой объект в сцене Unity.
//Добавьте скрипт SpawnObjectsRandomly к этому объекту.
//В инспекторе скрипта выберите объекты, которые нужно спавнить, и точки спавна.
//Запустите игру.
