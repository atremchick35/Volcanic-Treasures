using TMPro;
using UnityEngine.UI;

namespace Interfaces
{
    public interface ILootable
    {
        void GivePlayer();

        void AnimateDrop(TMP_Text giveItemText, Image giveItemImage);
    }
}