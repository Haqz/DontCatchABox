using UnityEngine;

namespace Polarith.AI.Examples
{
    /// <summary>
    /// This script can prefabs given by <see cref="SpawningObject"/>. It is possible to set <see cref="Parent"/> as the
    /// transforms parent of the spawned objects.
    /// <para/>
    /// The spawning area is defined by <see cref="Bounds"/> which is located in the xy-plane. By setting <see
    /// cref="XZSpawn"/><c>true</c> it is possible to flip the area onto the xz-plane.
    /// <para/>
    /// Per default, this component will spawn <see cref="Count"/> number of objects instantly. However, it is possible
    /// to spawn random objects over time by setting the <see cref="LoopedSpawn"/> value to <c>true</c>. Then the value
    /// <see cref="TimeBetweenSpawn"/> defines in which intervall a new object is instantiated.
    /// <para/>
    /// Note, this is just a script for our example scenes and therefore not part of the actual API. We do not guarantee
    /// that this script is working besides our examples.
    /// </summary>
    public sealed class RandomObjects : MonoBehaviour
    {
        #region Fields =================================================================================================

        /// <summary>
        /// The reference to the prefab which will be spawned.
        /// </summary>
        [Tooltip("The reference to the prefab which will be spawned.")]
        public GameObject SpawningObject;

        /// <summary>
        /// The object which will be parent for the spawned objects transforms. If null the objects wont have a parent.
        /// </summary>
        [Tooltip("The object which will be parent for the spawned objects transforms. If null the objects wont have " +
            "a parent.")]
        public GameObject Parent;

        /// <summary>
        /// The rectangle defining the spawning area.
        /// </summary>
        [Tooltip("The rectangle defining the spawning area.")]
        public Rect Bounds;

        /// <summary>
        /// If <c>true</c>, the spawning area will be flipped into the xz-plane. Otherwise, the spawning area is in the
        /// xy-plane.
        /// </summary>
        [Tooltip("If true, the spawning area will be flipped into the xz-plane. Otherwise, the spawning area is in " +
            "the xy-plane.")]
        public bool XZSpawn;

        /// <summary>
        /// If <c>true</c>, this component will constantly spawn new objects depending on <see
        /// cref="TimeBetweenSpawn"/>. Otherwise, only <see cref="Count"/> objects are spawned instantly.
        /// </summary>
        [Tooltip("If true, this component will constantly spawn new objects depending on TimeBetweenSpawn. Otherwise " +
            ", only Count objects are spawned instantly.")]
        public bool LoopedSpawn;

        /// <summary>
        /// The amount of instantly spawned instances of <see cref="SpawningObject"/>, if <see cref="LoopedSpawn"/> is
        /// <c>false</c>.
        /// </summary>
        [Tooltip("The amount of instantly spawned instances of SpawningObject, if LoopedSpawn is false")]
        public int Count;

        /// <summary>
        /// The time between 2 object spawns, if <see cref="LoopedSpawn"/> is <c>true</c>.
        /// </summary>
        [Tooltip("The time between 2 object spawns, if LoopedSpawn is true.")]
        public float TimeBetweenSpawn;

        //--------------------------------------------------------------------------------------------------------------

        private float currentTime;
        private float xz = 0.0f;
        private float xy = 1.0f;

        #endregion // Fields

        #region Methods ================================================================================================

        // Update is called once per frame
        private void Update()
        {
            // Initialize the used plane.
            xz = 0.0f;
            xy = 1.0f;
            if (XZSpawn)
            {
                xz = 1.0f;
                xy = 0.0f;
            }

            // If LoopedSpawn, repeat the process in every update.
            if (LoopedSpawn)
            {
                if (currentTime >= TimeBetweenSpawn)
                {
                    GameObject obj = Instantiate(SpawningObject);

                    if (Parent != null)
                        obj.transform.SetParent(Parent.transform);

                    obj.transform.localPosition
                        = new Vector3(
                            Random.Range(Bounds.x, Bounds.x + Bounds.width),
                            xy * Random.Range(Bounds.y, Bounds.y + Bounds.height),
                            xz * Random.Range(Bounds.y, Bounds.y + Bounds.height));

                    currentTime = 0.0f;
                }
            }
            // Else, just spawn count objects and disable this component.
            else
            {
                for (int i = 0; i < Count; i++)
                {
                    GameObject obj = Instantiate(SpawningObject);

                    if (Parent != null)
                        obj.transform.SetParent(Parent.transform);

                    obj.transform.localPosition
                        = new Vector3(
                            Random.Range(Bounds.x, Bounds.x + Bounds.width),
                            xy * Random.Range(Bounds.y, Bounds.y + Bounds.height) + xz * transform.position.y,
                            xz * Random.Range(Bounds.y, Bounds.y + Bounds.height) + xy * transform.position.z);

                    ;
                }
                enabled = false;
            }
            currentTime += Time.deltaTime;
        }

        //--------------------------------------------------------------------------------------------------------------

        private void OnDrawGizmosSelected()
        {
            xz = 0.0f;
            xy = 1.0f;
            if (XZSpawn)
            {
                xz = 1.0f;
                xy = 0.0f;
            }

            Gizmos.color = Color.green;

            Vector3 pos = gameObject.transform.position;

            // Top
            Gizmos.DrawLine(new Vector3(Bounds.x, xy * Bounds.y + xz * pos.y, xz * Bounds.y + xy * pos.z),
                new Vector3(Bounds.xMax, xy * Bounds.y + xz * pos.y, xz * Bounds.y + xy * pos.z));
            // Bot
            Gizmos.DrawLine(new Vector3(Bounds.x, xy * Bounds.yMax + xz * pos.y, xz * Bounds.yMax + xy * pos.z),
                new Vector3(Bounds.xMax, xy * Bounds.yMax + xz * pos.y, xz * Bounds.yMax + xy * pos.z));
            // Left
            Gizmos.DrawLine(new Vector3(Bounds.x, xy * Bounds.y + xz * pos.y, xz * Bounds.y + xy * pos.z),
                new Vector3(Bounds.x, xy * Bounds.yMax + xz * pos.y, xz * Bounds.yMax + xy * pos.z));
            // Right
            Gizmos.DrawLine(new Vector3(Bounds.xMax, xy * Bounds.y + xz * pos.y, xz * Bounds.y + xy * pos.z),
                new Vector3(Bounds.xMax, xy * Bounds.yMax + xz * pos.y, xz * Bounds.yMax + xy * pos.z));
        }

        #endregion // Methods
    } // class RandomObjects
} // namespace Polarith.AI.Examples
