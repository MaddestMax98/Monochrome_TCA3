using UnityEngine;
using ScripatbleObj;
using Manager;

namespace Item
{
    public class PickupMannequinItem : PickupItem
    {
        [SerializeField]
        private MannequinItemData item;

        public override void Start()
        {
            base.Start();
            if (item.isPickedUp)
            {
                Destroy(gameObject);
            }
        }


        public override void Pickup()
        {
            item.isPickedUp = true;
            Destroy(gameObject);
        }


    }

}
