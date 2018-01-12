using UnityEngine;
using UnityEngine.UI;

namespace Polarith.AI.Examples
{
    /// <summary>
    /// Count the <see cref="GameObject"/> instances which are attached to <see cref="AgentObjects"/>, <see
    /// cref="InterestObjects"/> and <see cref="DangerObjects"/>. The result is written to the <see cref="TextField"/>
    /// object.
    /// <para/>
    /// Note, this is just a script for our example scenes and therefore not part of the actual API. We do not guarantee
    /// that this script is working besides our examples.
    /// </summary>
    public sealed class CountObjects : MonoBehaviour
    {
        #region Fields =================================================================================================

        /// <summary>
        /// The target UI Text were the object count will be represented.
        /// </summary>
        [Tooltip("The target UI Text were the object count will be represented.")]
        public Text TextField;

        /// <summary>
        /// The parent object of the agents.
        /// </summary>
        [Tooltip("The parent object of the agents.")]
        public GameObject AgentObjects;

        /// <summary>
        /// The parent object of the interest objects.
        /// </summary>
        [Tooltip("The parent object of the interest objects.")]
        public GameObject InterestObjects;

        /// <summary>
        /// The parent object of the danger objects.
        /// </summary>
        [Tooltip("The parent object of the danger objects.")]
        public GameObject DangerObjects;

        #endregion // Fields

        #region Methods ================================================================================================

        private void Start()
        {
            // Check for valid input.
            if (TextField == null || AgentObjects == null || InterestObjects == null || DangerObjects == null)
                enabled = false;
        }

        //--------------------------------------------------------------------------------------------------------------

        private void Update()
        {
            // Get the object count.
            int all = AgentObjects.transform.childCount
                + InterestObjects.transform.childCount
                + DangerObjects.transform.childCount;
            int objects = InterestObjects.transform.childCount + DangerObjects.transform.childCount;

            // Update the text field.
            TextField.text = "GameObject count: " + all
                + " \n\n Agents: " + AgentObjects.transform.childCount + " \n\n Other objects: " +
                +objects + " \n\n " +
                "Worst case: " + (AgentObjects.transform.childCount * (all - 1)) + " interactions per update";
        }

        #endregion // Methods
    } // class CountObjects
} // namespace Polarith.AI.Examples
