using UnityEngine;

namespace Polarith.AI.Examples
{
    /// <summary>
    /// Simple script which deactivates this <see cref="GameObject"/> when colliding with something else.
    /// <para/>
    /// Note, this is just a script for our example scenes and therefore not part of the actual API. We do not guarantee
    /// that this script is working besides our examples.
    /// </summary>
    public sealed class DeactivateOnHit : MonoBehaviour
    {
        #region Methods ================================================================================================

        private void OnTriggerEnter2D(Collider2D other)
        {
            gameObject.SetActive(false);
        }

        //--------------------------------------------------------------------------------------------------------------

        private void OnTriggerEnter(Collider other)
        {
            gameObject.SetActive(false);
        }

        #endregion // Methods
    } // class DestroyOnHit
} // namespace Polarith.AI.Examples
