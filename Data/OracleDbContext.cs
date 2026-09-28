using Microsoft.EntityFrameworkCore;
using TasteSphere.Models;

namespace TasteSphere.Data
{
    public class OracleDbContext : DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<RecipeStep> RecipeSteps { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Categories
            modelBuilder.Entity<Category>()
                .ToTable("CATEGORIES");

            modelBuilder.Entity<Category>()
                .HasKey(c => c.CategoryId);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryId)
                .HasColumnName("CATEGORY_ID");

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .HasColumnName("CATEGORY_NAME");

            modelBuilder.Entity<Category>()
                .Property(c => c.Description)
                .HasColumnName("DESCRIPTION");

            // Cuisines
            modelBuilder.Entity<Cuisine>()
                .ToTable("CUISINES");

            modelBuilder.Entity<Cuisine>()
                .HasKey(c => c.CuisineId);

            modelBuilder.Entity<Cuisine>()
                .Property(c => c.CuisineId)
                .HasColumnName("CUISINE_ID");

            modelBuilder.Entity<Cuisine>()
                .Property(c => c.CuisineName)
                .HasColumnName("CUISINE_NAME");

            modelBuilder.Entity<Cuisine>()
                .Property(c => c.CountryName)
                .HasColumnName("COUNTRY_NAME");

            modelBuilder.Entity<Cuisine>()
                .Property(c => c.Description)
                .HasColumnName("DESCRIPTION");

            // Users
            modelBuilder.Entity<User>()
                .ToTable("USERS");

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserId)
                .HasColumnName("USER_ID");

            modelBuilder.Entity<User>()
                .Property(u => u.FullName)
                .HasColumnName("FULL_NAME");

            modelBuilder.Entity<User>()
                .Property(u => u.Email)
                .HasColumnName("EMAIL");

            modelBuilder.Entity<User>()
                .Property(u => u.Password)
                .HasColumnName("PASSWORD");

            modelBuilder.Entity<User>()
                .Property(u => u.Role)
                .HasColumnName("ROLE");

            modelBuilder.Entity<User>()
                .Property(u => u.CreatedAt)
                .HasColumnName("CREATED_AT");

            // Recipes
            modelBuilder.Entity<Recipe>()
                .ToTable("RECIPES");

            modelBuilder.Entity<Recipe>()
                .HasKey(r => r.RecipeId);

            modelBuilder.Entity<Recipe>()
                .Property(r => r.RecipeId)
                .HasColumnName("RECIPE_ID");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.RecipeName)
                .HasColumnName("RECIPE_NAME");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Description)
                .HasColumnName("DESCRIPTION");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.CategoryId)
                .HasColumnName("CATEGORY_ID");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.CuisineId)
                .HasColumnName("CUISINE_ID");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.PrepTime)
                .HasColumnName("PREP_TIME");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.CookTime)
                .HasColumnName("COOK_TIME");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Difficulty)
                .HasColumnName("DIFFICULTY");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.Servings)
                .HasColumnName("SERVINGS");

            modelBuilder.Entity<Recipe>()
                .Property(r => r.ImageUrl)
                .HasColumnName("IMAGE_URL");

            // Ingredients
            modelBuilder.Entity<Ingredient>()
                .ToTable("INGREDIENTS");

            modelBuilder.Entity<Ingredient>()
                .HasKey(i => i.IngredientId);

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.IngredientId)
                .HasColumnName("INGREDIENT_ID");

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.IngredientName)
                .HasColumnName("INGREDIENT_NAME");

            modelBuilder.Entity<Ingredient>()
                .Property(i => i.Unit)
                .HasColumnName("UNIT");

            // Recipe Ingredients
            modelBuilder.Entity<RecipeIngredient>()
                .ToTable("RECIPE_INGREDIENTS");

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            modelBuilder.Entity<RecipeIngredient>()
                .Property(ri => ri.RecipeId)
                .HasColumnName("RECIPE_ID");

            modelBuilder.Entity<RecipeIngredient>()
                .Property(ri => ri.IngredientId)
                .HasColumnName("INGREDIENT_ID");

            modelBuilder.Entity<RecipeIngredient>()
                .Property(ri => ri.Quantity)
                .HasColumnName("QUANTITY");

            // Recipe Steps
            modelBuilder.Entity<RecipeStep>()
                .ToTable("RECIPE_STEPS");

            modelBuilder.Entity<RecipeStep>()
                .HasKey(rs => rs.StepId);

            modelBuilder.Entity<RecipeStep>()
                .Property(rs => rs.StepId)
                .HasColumnName("STEP_ID");

            modelBuilder.Entity<RecipeStep>()
                .Property(rs => rs.RecipeId)
                .HasColumnName("RECIPE_ID");

            modelBuilder.Entity<RecipeStep>()
                .Property(rs => rs.StepNumber)
                .HasColumnName("STEP_NUMBER");

            modelBuilder.Entity<RecipeStep>()
                .Property(rs => rs.Instruction)
                .HasColumnName("INSTRUCTION");

            // Reviews
            modelBuilder.Entity<Review>()
                .ToTable("REVIEWS");

            modelBuilder.Entity<Review>()
                .HasKey(r => r.ReviewId);

            modelBuilder.Entity<Review>()
                .Property(r => r.ReviewId)
                .HasColumnName("REVIEW_ID");

            modelBuilder.Entity<Review>()
                .Property(r => r.UserId)
                .HasColumnName("USER_ID");

            modelBuilder.Entity<Review>()
                .Property(r => r.RecipeId)
                .HasColumnName("RECIPE_ID");

            modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .HasColumnName("RATING");

            modelBuilder.Entity<Review>()
                .Property(r => r.CommentText)
                .HasColumnName("COMMENT_TEXT");

            modelBuilder.Entity<Review>()
                .Property(r => r.ReviewDate)
                .HasColumnName("REVIEW_DATE");

            // Favorites
            modelBuilder.Entity<Favorite>()
                .ToTable("FAVORITES");

            modelBuilder.Entity<Favorite>()
                .HasKey(f => f.FavoriteId);

            modelBuilder.Entity<Favorite>()
                .Property(f => f.FavoriteId)
                .HasColumnName("FAVORITE_ID");

            modelBuilder.Entity<Favorite>()
                .Property(f => f.UserId)
                .HasColumnName("USER_ID");

            modelBuilder.Entity<Favorite>()
                .Property(f => f.RecipeId)
                .HasColumnName("RECIPE_ID");

            modelBuilder.Entity<Favorite>()
                .Property(f => f.AddedDate)
                .HasColumnName("ADDED_DATE");

            // Relationships
            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId);

            modelBuilder.Entity<Recipe>()
                .HasOne(r => r.Cuisine)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CuisineId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany()
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(i => i.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<RecipeStep>()
                .HasOne(rs => rs.Recipe)
                .WithMany()
                .HasForeignKey(rs => rs.RecipeId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Recipe)
                .WithMany()
                .HasForeignKey(r => r.RecipeId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.Recipe)
                .WithMany()
                .HasForeignKey(f => f.RecipeId);
        }
    }
}