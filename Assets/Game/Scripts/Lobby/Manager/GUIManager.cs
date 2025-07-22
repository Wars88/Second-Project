using UnityEngine;

namespace Lobby
{
    public class GUIManager : Core.Manager
    {
        // ============================================================
        [ReadOnly] public LobbyViewer LobbyViewer;
        [ReadOnly] public GameStartButton GameStartButton;
        [ReadOnly] public InventoryButton InventoryButton;
        [ReadOnly] public EquipmentButton EquipmentButton;
        [ReadOnly] public MonsterButton MonsterButton;

        // ============================================================
        [ReadOnly] public InventoryViewer InventoryViewer;
        [ReadOnly] public ItemButton[] ItemButtons;

        // ============================================================
        [ReadOnly] public ItemViewer ItemViewer;

        // ============================================================
        [ReadOnly] public BackButton BackButton;
        [ReadOnly] public HomeButton HomeButton;

        public override void Preparing()
        {
            LobbyViewer = gameObject.GetComponentInChildren<LobbyViewer>(true);
            GameStartButton = gameObject.GetComponentInChildren<GameStartButton>(true);
            InventoryButton = gameObject.GetComponentInChildren<InventoryButton>(true);
            EquipmentButton = gameObject.GetComponentInChildren<EquipmentButton>(true);
            MonsterButton = gameObject.GetComponentInChildren<MonsterButton>(true);

            // ============================================================
            InventoryViewer = gameObject.GetComponentInChildren<InventoryViewer>(true);
            ItemButtons = gameObject.GetComponentsInChildren<ItemButton>(true);
            for (int i = 0; i < ItemButtons.Length; i++) { ItemButtons[i].Index = i; }

            // ============================================================
            ItemViewer = gameObject.GetComponentInChildren<ItemViewer>(true);

            // ============================================================
            BackButton = gameObject.GetComponentInChildren<BackButton>(true);
            HomeButton = gameObject.GetComponentInChildren<HomeButton>(true);
        }

        public T[] GetUIComponents<T>() => gameObject.GetComponentsInChildren<T>();

    }
}