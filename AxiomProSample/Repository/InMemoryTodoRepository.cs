using System.Collections.Concurrent;
using AxiomProSample.Domain;

namespace AxiomProSample.Repository
{
    public class InMemoryAxiomRepository : IAxiomRepository
    {
        private readonly ConcurrentDictionary<int, AxiomItem> _store = new();
        private int _counter = 1;

        public Task<IReadOnlyCollection<AxiomItem>> GetAllAsync() =>
            Task.FromResult((IReadOnlyCollection<AxiomItem>)_store.Values.ToList());

        public Task<AxiomItem> AddAsync(string title)
        {
            var id = _counter++;
            var item = new AxiomItem(id, title, false);
            _store[id] = item;

            return Task.FromResult(item);
        }

        public Task<AxiomItem?> UpdateAsync(int id)
        {
            if (!_store.TryGetValue(id, out var existing))
                return Task.FromResult<AxiomItem?>(null);

            var updated = existing with { IsCompleted = !existing.IsCompleted };
            _store[id] = updated;

            return Task.FromResult<AxiomItem?>(updated);
        }
    }
}
