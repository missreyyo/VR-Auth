<<<<<<< HEAD
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

namespace UnityEditor.XR.Interaction.Toolkit.Inputs.Simulation
{
    /// <summary>
    /// Custom editor for an <see cref="XRDeviceSimulatorSettings"/>.
    /// </summary>
    [CustomEditor(typeof(XRDeviceSimulatorSettings))]
    class XRDeviceSimulatorSettingsEditor : Editor
    {
        const string k_PackageName = "com.unity.xr.interaction.toolkit";
        const string k_PackageDisplayName = "XR Interaction Toolkit";
        const string k_XRDeviceSimulatorName = "XR Device Simulator";
        const string k_ImportSampleTitle = "Importing " + k_XRDeviceSimulatorName + " sample.";
        const string k_ImportSampleMessage = "The " + k_XRDeviceSimulatorName + " sample is going to be imported from the " + k_PackageDisplayName + " package, press \"Ok\" to continue.";

        const float k_LabelsWidth = 270f;

        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="XRDeviceSimulatorSettings.automaticallyInstantiateSimulatorPrefab"/>.</summary>
        SerializedProperty m_AutomaticallyInstantiateSimulatorPrefab;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="XRDeviceSimulatorSettings.simulatorPrefab"/>.</summary>
        SerializedProperty m_SimulatorPrefab;

        /// <summary>
        /// Class that holds GUI content values used by this editor.
        /// </summary>
        static class Contents
        {
            /// <summary><see cref="GUIContent"/> for <see cref="XRDeviceSimulatorSettings.automaticallyInstantiateSimulatorPrefab"/>.</summary>
            public static readonly GUIContent automaticallyInstantiateSimulatorPrefab =
                EditorGUIUtility.TrTextContent("Use XR Device Simulator in scenes",
                    "When selected, the XR Device Simulator will be present on play mode in your scenes.");

            /// <summary><see cref="GUIContent"/> for <see cref="XRDeviceSimulatorSettings.simulatorPrefab"/>.</summary>
            public static readonly GUIContent simulatorPrefab =
                EditorGUIUtility.TrTextContent("XR Device Simulator prefab",
                    "Reference to the XR Device Simulator prefab that will be instantiated at runtime.");
        }

        void OnEnable()
        {
            m_AutomaticallyInstantiateSimulatorPrefab = serializedObject.FindProperty("m_AutomaticallyInstantiateSimulatorPrefab");
            m_SimulatorPrefab = serializedObject.FindProperty("m_SimulatorPrefab");
        }

        /// <inheritdoc />
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var labelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = k_LabelsWidth;
                EditorGUILayout.PropertyField(m_AutomaticallyInstantiateSimulatorPrefab, Contents.automaticallyInstantiateSimulatorPrefab);
                using (new EditorGUI.IndentLevelScope())
                using (new EditorGUI.DisabledScope(!m_AutomaticallyInstantiateSimulatorPrefab.boolValue))
                {
                    EditorGUILayout.PropertyField(m_SimulatorPrefab, Contents.simulatorPrefab);
                }

                EditorGUIUtility.labelWidth = labelWidth;

                if (check.changed)
                {
                    if (m_AutomaticallyInstantiateSimulatorPrefab.boolValue)
                        LoadXRDeviceSimulatorSampleAsset();
                    else
                        m_SimulatorPrefab.objectReferenceValue = null;

                    serializedObject.ApplyModifiedProperties();
                    Repaint();
                }
            }
        }

        void LoadXRDeviceSimulatorSampleAsset()
        {
            var packageSamples = Sample.FindByPackage(k_PackageName, string.Empty);
            if (packageSamples == null)
            {
                Debug.LogError($"Couldn't find samples of the {k_PackageName} package for importing the {k_XRDeviceSimulatorName} sample; aborting.", this);
                return;
            }

            var foundXRDeviceSimulatorSample = false;

            foreach (var packageSample in packageSamples)
            {
                if (packageSample.displayName != k_XRDeviceSimulatorName)
                    continue;

                if (!packageSample.isImported)
                {
                    if (EditorUtility.DisplayDialog(k_ImportSampleTitle, k_ImportSampleMessage, "Ok", "Cancel"))
                    {
                        packageSample.Import(Sample.ImportOptions.OverridePreviousImports);
                    }
                    else
                    {
                        m_AutomaticallyInstantiateSimulatorPrefab.boolValue = false;
                        return;
                    }
                }

                foundXRDeviceSimulatorSample = true;
                break;
            }

            if (!foundXRDeviceSimulatorSample)
            {
                Debug.LogError($"Couldn't find {k_XRDeviceSimulatorName} sample in the {k_PackageDisplayName} package; aborting.", this);
                return;
            }

            const string searchFilter = "\"" + k_XRDeviceSimulatorName +"\"";
            var foundXRDeviceSimulatorAsset = false;
            foreach (var guid in AssetDatabase.FindAssets(searchFilter))
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var simulatorPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                if (simulatorPrefab != null && simulatorPrefab.TryGetComponent<XRDeviceSimulator>(out _))
                {
                    m_SimulatorPrefab.objectReferenceValue = simulatorPrefab;
                    foundXRDeviceSimulatorAsset = true;
                }
            }

            if (!foundXRDeviceSimulatorAsset)
            {
                Debug.LogError($"Couldn't find the {k_XRDeviceSimulatorName} prefab; has the asset been renamed?", this);
            }
        }
    }
=======
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Inputs.Simulation;

namespace UnityEditor.XR.Interaction.Toolkit.Inputs.Simulation
{
    /// <summary>
    /// Custom editor for an <see cref="XRDeviceSimulatorSettings"/>.
    /// </summary>
    [CustomEditor(typeof(XRDeviceSimulatorSettings))]
    class XRDeviceSimulatorSettingsEditor : Editor
    {
        const string k_PackageName = "com.unity.xr.interaction.toolkit";
        const string k_PackageDisplayName = "XR Interaction Toolkit";
        const string k_XRDeviceSimulatorName = "XR Device Simulator";
        const string k_ImportSampleTitle = "Importing " + k_XRDeviceSimulatorName + " sample.";
        const string k_ImportSampleMessage = "The " + k_XRDeviceSimulatorName + " sample is going to be imported from the " + k_PackageDisplayName + " package, press \"Ok\" to continue.";

        const float k_LabelsWidth = 270f;

        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="XRDeviceSimulatorSettings.automaticallyInstantiateSimulatorPrefab"/>.</summary>
        SerializedProperty m_AutomaticallyInstantiateSimulatorPrefab;
        /// <summary><see cref="SerializedProperty"/> of the <see cref="SerializeField"/> backing <see cref="XRDeviceSimulatorSettings.simulatorPrefab"/>.</summary>
        SerializedProperty m_SimulatorPrefab;

        /// <summary>
        /// Class that holds GUI content values used by this editor.
        /// </summary>
        static class Contents
        {
            /// <summary><see cref="GUIContent"/> for <see cref="XRDeviceSimulatorSettings.automaticallyInstantiateSimulatorPrefab"/>.</summary>
            public static readonly GUIContent automaticallyInstantiateSimulatorPrefab =
                EditorGUIUtility.TrTextContent("Use XR Device Simulator in scenes",
                    "When selected, the XR Device Simulator will be present on play mode in your scenes.");

            /// <summary><see cref="GUIContent"/> for <see cref="XRDeviceSimulatorSettings.simulatorPrefab"/>.</summary>
            public static readonly GUIContent simulatorPrefab =
                EditorGUIUtility.TrTextContent("XR Device Simulator prefab",
                    "Reference to the XR Device Simulator prefab that will be instantiated at runtime.");
        }

        void OnEnable()
        {
            m_AutomaticallyInstantiateSimulatorPrefab = serializedObject.FindProperty("m_AutomaticallyInstantiateSimulatorPrefab");
            m_SimulatorPrefab = serializedObject.FindProperty("m_SimulatorPrefab");
        }

        /// <inheritdoc />
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            using (var check = new EditorGUI.ChangeCheckScope())
            {
                var labelWidth = EditorGUIUtility.labelWidth;
                EditorGUIUtility.labelWidth = k_LabelsWidth;
                EditorGUILayout.PropertyField(m_AutomaticallyInstantiateSimulatorPrefab, Contents.automaticallyInstantiateSimulatorPrefab);
                using (new EditorGUI.IndentLevelScope())
                using (new EditorGUI.DisabledScope(!m_AutomaticallyInstantiateSimulatorPrefab.boolValue))
                {
                    EditorGUILayout.PropertyField(m_SimulatorPrefab, Contents.simulatorPrefab);
                }

                EditorGUIUtility.labelWidth = labelWidth;

                if (check.changed)
                {
                    if (m_AutomaticallyInstantiateSimulatorPrefab.boolValue)
                        LoadXRDeviceSimulatorSampleAsset();
                    else
                        m_SimulatorPrefab.objectReferenceValue = null;

                    serializedObject.ApplyModifiedProperties();
                    Repaint();
                }
            }
        }

        void LoadXRDeviceSimulatorSampleAsset()
        {
            var packageSamples = Sample.FindByPackage(k_PackageName, string.Empty);
            if (packageSamples == null)
            {
                Debug.LogError($"Couldn't find samples of the {k_PackageName} package for importing the {k_XRDeviceSimulatorName} sample; aborting.", this);
                return;
            }

            var foundXRDeviceSimulatorSample = false;

            foreach (var packageSample in packageSamples)
            {
                if (packageSample.displayName != k_XRDeviceSimulatorName)
                    continue;

                if (!packageSample.isImported)
                {
                    if (EditorUtility.DisplayDialog(k_ImportSampleTitle, k_ImportSampleMessage, "Ok", "Cancel"))
                    {
                        packageSample.Import(Sample.ImportOptions.OverridePreviousImports);
                    }
                    else
                    {
                        m_AutomaticallyInstantiateSimulatorPrefab.boolValue = false;
                        return;
                    }
                }

                foundXRDeviceSimulatorSample = true;
                break;
            }

            if (!foundXRDeviceSimulatorSample)
            {
                Debug.LogError($"Couldn't find {k_XRDeviceSimulatorName} sample in the {k_PackageDisplayName} package; aborting.", this);
                return;
            }

            const string searchFilter = "\"" + k_XRDeviceSimulatorName +"\"";
            var foundXRDeviceSimulatorAsset = false;
            foreach (var guid in AssetDatabase.FindAssets(searchFilter))
            {
                var assetPath = AssetDatabase.GUIDToAssetPath(guid);
                var simulatorPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(assetPath);
                if (simulatorPrefab != null && simulatorPrefab.TryGetComponent<XRDeviceSimulator>(out _))
                {
                    m_SimulatorPrefab.objectReferenceValue = simulatorPrefab;
                    foundXRDeviceSimulatorAsset = true;
                }
            }

            if (!foundXRDeviceSimulatorAsset)
            {
                Debug.LogError($"Couldn't find the {k_XRDeviceSimulatorName} prefab; has the asset been renamed?", this);
            }
        }
    }
>>>>>>> 5386830ea95ecb9f6ce72cd172faa6cc6f38de24
}