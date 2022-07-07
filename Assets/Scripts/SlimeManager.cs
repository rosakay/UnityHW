using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlimeManager : MonoBehaviour
{
    static SlimeManager instance = null;

    public Object slimePrefab;
    public Object slimeLeafPrefab;
    public Object slimeKingPrefab;

    public int slimeCount = 25;
    public int slimeLeafCount = 10;
    public int slimeKingCount = 2;

    private List<GameObject> m_slimePool = new List<GameObject>();
    private List<GameObject> m_slimeLeafPool = new List<GameObject>();
    private List<GameObject> m_slimeKingPool = new List<GameObject>();

    [Range(0, 10), SerializeField] float spawnArea = 8.0f;

    private static SlimeManager m_Instance;
    public static SlimeManager Instance()
    {
        return m_Instance;
    }

    private void Awake()
    {
        m_Instance = this;
        SpawnSlime();
    }
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RespawnSlime", 2.0f, 2.0f);
        InvokeRepeating("RespawnLeafSlime", 5.0f, 4.0f);
        InvokeRepeating("RespawnKingSlime", 10.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(m_slimePool[5].activeSelf);
        }
    }


    public void SpawnSlime()
    {
        for (int i = 0; i < slimeCount; i++)
        {
            GameObject slime = Instantiate(slimePrefab) as GameObject;
            m_slimePool.Add(slime);
            m_slimePool[i].SetActive(false);
        }
        for (int i = 0; i < slimeLeafCount; i++)
        {
            GameObject slimeLeaf = Instantiate(slimeLeafPrefab) as GameObject;
            m_slimeLeafPool.Add(slimeLeaf);
            m_slimeLeafPool[i].SetActive(false);
        }
        for (int i = 0; i < slimeKingCount; i++)
        {
            GameObject slimeKing = Instantiate(slimeKingPrefab) as GameObject;
            m_slimeKingPool.Add(slimeKing);
            m_slimeKingPool[i].SetActive(false);
        }
    }
    public void RespawnSlime()
    {
        foreach (GameObject i in m_slimePool)
        {
            if (!i.activeSelf)
            {
                i.SetActive(true);
                return;
            }
        }
    }
    public void RespawnLeafSlime()
    {
        foreach (GameObject i in m_slimeLeafPool)
        {
            if (!i.activeSelf)
            {
                i.SetActive(true);
                return;
            }
        }
    }
    public void RespawnKingSlime()
    {
        foreach (GameObject i in m_slimeKingPool)
        {
            if (!i.activeSelf)
            {
                i.SetActive(true);
                return;
            }
        }
    }
}
