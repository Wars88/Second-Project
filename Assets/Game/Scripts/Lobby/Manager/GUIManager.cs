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
            LobbyViewer = gameObject.GetComponentInChildren<LobbyViewer>();
            GameStartButton = gameObject.GetComponentInChildren<GameStartButton>();
            InventoryButton = gameObject.GetComponentInChildren<InventoryButton>();
            EquipmentButton = gameObject.GetComponentInChildren<EquipmentButton>();
            MonsterButton = gameObject.GetComponentInChildren<MonsterButton>();

            // ============================================================
            InventoryViewer = gameObject.GetComponentInChildren<InventoryViewer>();
            ItemButtons = gameObject.GetComponentsInChildren<ItemButton>();

            // ============================================================
            ItemViewer = gameObject.GetComponentInChildren<ItemViewer>();

            // ============================================================
            BackButton = gameObject.GetComponentInChildren<BackButton>();
            HomeButton = gameObject.GetComponentInChildren<HomeButton>();
        }

        public T[] GetUIComponents<T>() => gameObject.GetComponentsInChildren<T>();

    }
}