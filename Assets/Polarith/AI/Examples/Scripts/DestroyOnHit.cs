using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Examples
{
    /// <summary>
    /// Simple script which destroys this gameObject when colliding with something else. It also removes the references
    /// from <see cref="AIMEnvironment"/> objects.
    /// <para/>
    /// Note, this is just a script for our example scenes and therefore not part of the actual API. We do not guarantee
    /// that this script is working besides our examples.
    /// </summary>
    public sealed class DestroyOnHit : MonoBehaviour
    {
        #region Methods ====================================================================================================

        private void OnTriggerEnter2D(Collider2D other)
        {
            GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));
            int idx = -1;

            // Search and remove all references of the object in every AIMEnvironment.
            foreach (var o in objects)
            {
                AIMEnvironment[] perecptor = o.GetComponents<AIMEnvironment>();
                if (perecptor != null)
                {
                    foreach (var p in perecptor)
                    {
                        idx = p.GameObjects.IndexOf(gameObject);
                        if (idx >= 0)
                            p.GameObjects[idx] = null;
                    }
                }
            }

            Destroy(gameObject);
        }

        //------------------------------------------------------------------------------------------------------------------

        private void OnTriggerEnter(Collider other)
        {
            GameObject[] objects = (GameObject[])FindObjectsOfType(typeof(GameObject));

            // Search and remove all references of the object in every AIMEnvironment.
            foreach (var o in objects)
            {
                AIMEnvironment[] perecptor = o.GetComponents<AIMEnvironment>();
                if (perecptor != null)
                {
                    foreach (var p in perecptor)
                    {
                        if (p.GameObjects.Contains(gameObject))
                            p.GameObjects.Remove(gameObject);
                    }
                }
            }

            Destroy(gameObject);
        }

        #endregion // Methods
    } // class DestroyOnHit
} // namespace Polarith.AI.Examples