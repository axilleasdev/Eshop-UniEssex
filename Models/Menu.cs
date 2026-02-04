namespace EShop.Models
{
    // Model για Menu - Scaffolded από υπάρχοντα πίνακα
    // Δεν συμμετέχει στα migrations (ExcludeFromMigrations)
    public class Menu
    {
        public int Id { get; set; }
        public string MenuTitle { get; set; } = string.Empty;
        public string Link { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}
