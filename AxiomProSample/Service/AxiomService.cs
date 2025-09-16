using AxiomProSample.Repository;
using AxiomProSample.Domain;

namespace AxiomProSample.Service
{
    public class AxiomService
    {
        private readonly IAxiomRepository _repo;

        public AxiomService(IAxiomRepository repo) => _repo = repo;

        public async Task RunDemoAsync()
        {
            Console.WriteLine("Adding sample Axioms...");
            await _repo.AddAsync("Sample 1");
            await _repo.AddAsync("Sample 2");
            await _repo.AddAsync("Sample 3");

            Console.WriteLine("\nAll Axioms:");
            var allAxioms = await _repo.GetAllAsync();
            foreach (var axiom in allAxioms)
            {
                Console.WriteLine($"[{(axiom.IsCompleted ? "x" : " ")}] {axiom.Title}");
            }

            Console.WriteLine("\nUpdating 2nd Axiom...");
            await _repo.UpdateAsync(2);

            Console.WriteLine("\nAxioms after update:");
            var updatedAxioms = (await _repo.GetAllAsync()).OrderBy(t => t.Id);
            foreach (var axiom in updatedAxioms)
            {
                Console.WriteLine($"[{(axiom.IsCompleted ? "x" : " ")}] {axiom.Title}");
            }
        }
    }
}
