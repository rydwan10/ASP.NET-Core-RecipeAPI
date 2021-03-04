namespace RecipeAPI.Dtos
{
    public class RecipeReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Ingredient { get; set; }
        public string Description { get; set; }
        // Time will not displayed when retrieved from Database
        // public string Time { get; set; }
    }
}
