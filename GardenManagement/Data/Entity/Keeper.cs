namespace Garden.Management.Data.Entity
{
    public class Keeper : EntityBase
    {
        public string Name { get; set; } = default!;
        public ICollection<Plant>? Plants { get; set; }
    }
}
