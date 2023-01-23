using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace OccaSoftware.Buto
{
    [ExecuteAlways]
    public sealed class FogDensityMask : ButoPlaceableObject
    {
        public enum BlendMode
		{
            Multiplicative,
            Exclusive
		}

        [SerializeField]
        private BlendMode mode = BlendMode.Multiplicative;
        public BlendMode Mode
		{
			get
			{
                return mode;
			}
		}
        

        [SerializeField, Min(0)]
        private float densityMultiplier = 1;
        public float DensityMultiplier
        {
            get
            {
                return densityMultiplier;
            }
        }


        [SerializeField, Min(0)]
        private float radius = 10;
        public float Radius
        {
            get
            {
                return radius;
            }
        }



        [SerializeField, Range(0, 1)]
        private float falloff = 0;
        public float Falloff
        {
            get
            {
                return falloff;
            }
        }

        public static void SortByDistance(Vector3 c)
        {
            fogVolumes = fogVolumes.OrderBy(x => x.GetSqrMagnitude(c)).ToList();
        }

        private static List<FogDensityMask> fogVolumes = new List<FogDensityMask>();
        public static List<FogDensityMask> FogVolumes
        {
            get { return fogVolumes; }
        }

        protected override void Reset()
        {
            ButoCommon.CheckMaxFogVolumeCount(FogVolumes.Count, this);
        }


        protected override void OnEnable()
        {
            fogVolumes.Add(this);
        }

        protected override void OnDisable()
        {
            fogVolumes.Remove(this);
        }

		private void OnDrawGizmosSelected()
		{
            if(mode == BlendMode.Exclusive)
			{
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(transform.position, Radius);
            }
            if(mode == BlendMode.Multiplicative)
			{
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(transform.position, Radius);
			}
		}
	}
}
