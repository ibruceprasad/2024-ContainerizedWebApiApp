namespace Garden.Management.Data.Entity
{
    public class Plant : EntityBase
    {
        public string Name { get; set; } = default!;
        public ICollection<Keeper> Keepers { get; set; } = default!;
    }
}