<<<<<<< HEAD
using System;
using UnityEngine;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Prefab spawner with a key input
    /// </summary>
    public class SpawnPrefabOnKeyDown : MonoBehaviour
    {
        [SerializeField]
        GameObject prefab;
        
        [SerializeField]
        KeyCode keyCode;
        
        [SerializeField]
        Transform spawnedPrefabsHolder;

        Transform m_Transform;

        void Start()
        {
            m_Transform = transform;

            if (spawnedPrefabsHolder == null)
            {
                spawnedPrefabsHolder = m_Transform;
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(keyCode) && prefab != null)
                Instantiate(prefab, m_Transform.position, m_Transform.rotation, spawnedPrefabsHolder);
        }
    }
=======
using System;
using UnityEngine;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Prefab spawner with a key input
    /// </summary>
    public class SpawnPrefabOnKeyDown : MonoBehaviour
    {
        [SerializeField]
        GameObject prefab;
        
        [SerializeField]
        KeyCode keyCode;
        
        [SerializeField]
        Transform spawnedPrefabsHolder;

        Transform m_Transform;

        void Start()
        {
            m_Transform = transform;

            if (spawnedPrefabsHolder == null)
            {
                spawnedPrefabsHolder = m_Transform;
            }
        }

        void Update()
        {
            if (Input.GetKeyDown(keyCode) && prefab != null)
                Instantiate(prefab, m_Transform.position, m_Transform.rotation, spawnedPrefabsHolder);
        }
    }
>>>>>>> 5386830ea95ecb9f6ce72cd172faa6cc6f38de24
}