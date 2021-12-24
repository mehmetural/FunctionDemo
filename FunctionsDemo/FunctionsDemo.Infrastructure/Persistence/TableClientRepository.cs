using Azure.Data.Tables;

namespace FunctionsDemo.Infrastructure
{
    public class TableClientRepository<T> : IRepository<T> where T : class, ITableEntity
    {
        readonly TableClient _tableClient;

        public TableClientRepository(TableServiceClient tableServiceClient)
        {
            _tableClient = tableServiceClient.GetTableClient(typeof(T).Name);
        }

        public async Task AddAsync(T item)
        {
            var entity = item.ValidateTableStorageEntity();

            await _tableClient.AddEntityAsync(entity);
        }

        public async Task UpdateAsync(T item)
        {
            var entity = item.ValidateTableStorageEntity();

            await _tableClient.UpdateEntityAsync(entity, Azure.ETag.All, TableUpdateMode.Merge);
        }

        public async Task Remove(T item)
        {
            await _tableClient.DeleteEntityAsync(item.PartitionKey, item.RowKey);
        }
    }
}