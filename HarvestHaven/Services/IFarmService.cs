﻿using HarvestHaven.Entities;

namespace HarvestHaven.Services
{
    public interface IFarmService
    {
        Task<Dictionary<FarmCell, Item>> GetAllFarmCellsForUser(Guid userId);

        Task InteractWithCell(int row, int column);

        Task DestroyCell(int row, int column);

        Task EnchanceCellForUser(Guid targetUserId, int row, int column);

        string GetPathByType(ItemType type);
    }
}
