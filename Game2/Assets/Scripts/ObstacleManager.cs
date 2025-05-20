using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;

    [SerializeField] int createCount = 5;

    [SerializeField] List<GameObject> obstacles;

    [SerializeField] GameObject[] prefab;

    [SerializeField] Transform[] transforms;

    void Start()
    {
        Create();

        StartCoroutine(ActiveObstacle());
    }


    public void Create()
    {
        for (int i = 0; i < createCount; i++)
        {
            GameObject clone = Instantiate(prefab[Random.Range(0, prefab.Length)], transform);

            clone.SetActive(false);

            obstacles.Add(clone);
        }
    }

    public IEnumerator ActiveObstacle()
    {
        while(true)
        {
            random = Random.Range(0, obstacles.Count);

            // ���� ���� ������Ʈ�� Ȱ��ȭ �Ǿ� �ִ��� Ȯ���մϴ�.
            while (obstacles[random].activeSelf == true)
            {
                // ���� �ε����� �ִ� ���� ������Ʈ�� Ȱ��ȭ�Ǿ� ������
                // random ������ ���� +1�� �ؼ� �ٽ� �˻��մϴ�.
                random = (random + 1) % createCount;
            }

            obstacles[random].transform.position = transforms[Random.Range(0, transforms.Length)].position;

            obstacles[random].SetActive(true);

            yield return new WaitForSeconds(5);
        }
    }


}
