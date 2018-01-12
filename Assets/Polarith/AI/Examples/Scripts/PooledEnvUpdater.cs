using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Examples
{
    /// <summary>
    /// Iterates over all children of <see cref="TargetObject"/> and attaches them to the <see
    /// cref="AIMEnvironment.GameObjects"/> list. <see cref="EnvLabel"/> is used to identify the correct <see
    /// cref="AIMEnvironment"/> instance attached to this gameobject.
    /// <para/>
    /// This component does not change the <see cref="AIMEnvironment.GameObjects"/> lists length. It just attaches the
    /// gameobjects as long as empty entries are available. This is done to avoid memory allocations during runtime.
    /// Therefore, the <see cref="AIMEnvironment.GameObjects"/> list must be set to an appropriate size before this
    /// component is activated.
    /// <para/>
    /// Note, this is just a script for our example scenes and therefore not part of the actual API. We do not guarantee
    /// that this script is working besides our examples.
    /// </summary>
    public sealed class PooledEnvUpdater : MonoBehaviour
    {
        #region Fields =================================================================================================

        /// <summary>
        /// All children of this object will be added to the environment given by <see cref="EnvLabel"/>.
        /// </summary>
        [Tooltip("All children of this object will be added to the environment given by EnvLabel.")]
        public GameObject TargetObject;

        /// <summary>
        /// This label is used to identify the correct environment on this gameobject.
        /// </summary>
        [Tooltip("This label is used to identify the correct environment on this gameobject.")]
        public string EnvLabel = "Interest";

        /// <summary>
        /// If this is <c>true</c>, the objects will only be added in Start assuming that objects wont change over
        /// runtime.
        /// </summary>
        [Tooltip("If this is true, the objects will only be added in Start assuming that objects wont change over " +
            "runtime.")]
        public bool StaticEnv = false;

        //--------------------------------------------------------------------------------------------------------------

        private AIMEnvironment env;

        #endregion // Fields

        #region Methods ================================================================================================

        private void Start()
        {
            // Search for the correct environment.
            AIMEnvironment[] envs = gameObject.GetComponents<AIMEnvironment>();
            for (int i = 0; i < envs.Length; i++)
            {
                if (envs[i].Label == EnvLabel)
                    env = envs[i];
            }

            // If no environment was found disable this component.
            if (env == null)
                enabled = false;

            // If StaticEnv is true, fill the given gameobjects into the list and disable this component.
            if (StaticEnv)
            {
                for (int i = 0; i < env.GameObjects.Count; i++)
                {
                    if (i >= TargetObject.transform.childCount)
                        break;

                    env.GameObjects[i] = TargetObject.transform.GetChild(i).gameObject;
                }
                env.Static = true;
                enabled = false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------

        private void Update()
        {
            // Write the object references to the environment.
            for (int i = 0; i < env.GameObjects.Count; i++)
            {
                if (i >= TargetObject.transform.childCount)
                    break;

                env.GameObjects[i] = TargetObject.transform.GetChild(i).gameObject;
            }
        }

        #endregion // Methods
    } // class PooledEnvUpdater
} // namespace Polarith.AI.Examples
