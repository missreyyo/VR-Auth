<<<<<<< HEAD
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit.Samples
{
    public class ToggleGameObject : MonoBehaviour
    {
        [SerializeField]
        GameObject m_ActivationGameObject;

        public GameObject activationGameObject
        {
            get => m_ActivationGameObject;
            set => m_ActivationGameObject = value;
        }

        [SerializeField]
        bool m_CurrentlyActive = false;
        
        public bool currentlyActive
        {
            get => m_CurrentlyActive;
            set
            {
                m_CurrentlyActive = value;
                activationGameObject.SetActive(m_CurrentlyActive);
            } 
        }

        public void ToggleActiveState()
        {
            m_CurrentlyActive = !m_CurrentlyActive;
            activationGameObject.SetActive(m_CurrentlyActive);
        }
    }
}
=======
using UnityEngine;

namespace UnityEngine.XR.Interaction.Toolkit.Samples
{
    public class ToggleGameObject : MonoBehaviour
    {
        [SerializeField]
        GameObject m_ActivationGameObject;

        public GameObject activationGameObject
        {
            get => m_ActivationGameObject;
            set => m_ActivationGameObject = value;
        }

        [SerializeField]
        bool m_CurrentlyActive = false;
        
        public bool currentlyActive
        {
            get => m_CurrentlyActive;
            set
            {
                m_CurrentlyActive = value;
                activationGameObject.SetActive(m_CurrentlyActive);
            } 
        }

        public void ToggleActiveState()
        {
            m_CurrentlyActive = !m_CurrentlyActive;
            activationGameObject.SetActive(m_CurrentlyActive);
        }
    }
}
>>>>>>> 5386830ea95ecb9f6ce72cd172faa6cc6f38de24
