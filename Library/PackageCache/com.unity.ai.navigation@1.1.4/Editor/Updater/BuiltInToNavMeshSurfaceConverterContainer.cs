<<<<<<< HEAD
#if UNITY_2022_2_OR_NEWER
using Unity.AI.Navigation.Editor.Converter;

namespace Unity.AI.Navigation.Updater
{
    internal sealed class BuiltInToNavMeshSurfaceConverterContainer : SystemConverterContainer
    {
        public override string name => "NavMesh Updater";
        public override string info => "The NavMesh updater performs the following tasks:\n* Converts scenes baked with the built-in NavMesh to the component-based version.\n* Replaces Navigation Static flags with NavMeshModifier components.";
    }
}
#endif
=======
#if UNITY_2022_2_OR_NEWER
using Unity.AI.Navigation.Editor.Converter;

namespace Unity.AI.Navigation.Updater
{
    internal sealed class BuiltInToNavMeshSurfaceConverterContainer : SystemConverterContainer
    {
        public override string name => "NavMesh Updater";
        public override string info => "The NavMesh updater performs the following tasks:\n* Converts scenes baked with the built-in NavMesh to the component-based version.\n* Replaces Navigation Static flags with NavMeshModifier components.";
    }
}
#endif
>>>>>>> 5386830ea95ecb9f6ce72cd172faa6cc6f38de24
