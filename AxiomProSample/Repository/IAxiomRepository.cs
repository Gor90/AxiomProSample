using AxiomProSample.Domain;

namespace AxiomProSample.Repository
{
    public interface IAxiomRepository
    {
        Task<IReadOnlyCollection<AxiomItem>> GetAllAsync();
        Task<AxiomItem> AddAsync(string title);
        Task<AxiomItem?> UpdateAsync(int id);
    }
}
