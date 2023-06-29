using UnityEngine;

namespace Scripts.Services
{
    public static class AdditionalServices
    {
        public static bool CheckLayer(this LayerMask original, int toCheck)
        {
            return (original.value & (1 << toCheck)) > 0;
        }
    }
}