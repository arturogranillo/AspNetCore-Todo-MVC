using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public class FakeTodoItemService : ITodoItemService
    {
        private readonly List<TodoItem> items = new List<TodoItem>();

        public FakeTodoItemService()
        {
            var item1 = new TodoItem
            {
                Title = "Learn ASP.NET Core",
                DueAt = DateTimeOffset.Now.AddDays(1)
            };
            items.Add(item1);

            var item2 = new TodoItem
            {
                Title = "Build awesome apps",
                DueAt = DateTimeOffset.Now.AddDays(2)
            };
            items.Add(item2);
        }

        public Task<TodoItem[]> GetIncompleteItemsAsync()
        {
            return Task.FromResult(items.ToArray());
        }

        public async Task<bool> AddItemAsync(TodoItem newItem)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);

            items.Add(newItem);

            return true;
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var item = items
                .Where(x => x.Id == id)
                .SingleOrDefault();

            if (item == null) return false;

            item.IsDone = true;

            return true; // One entity should have been updated
        }

    }
}
