using Moq;
using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services;
using OrderFoodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order_food_tests.Application.Services.CategoryServices {
    public class CategoryServiceTest 
    {
        private readonly Mock<ICategoryRepository> _categoryRepositoryMock;
        private readonly CategoryService _categoryService;

        public CategoryServiceTest() {
            _categoryRepositoryMock = new Mock<ICategoryRepository>();
            _categoryService = new CategoryService(_categoryRepositoryMock.Object);
        }

        [Fact]
        public async Task GetCategories_ShouldReturnCategories() {

            var categories = new List<Category> {

                new Category ("Bebidas"),
                new Category ( "Pizza" )
            };
            _categoryRepositoryMock.Setup(repo => repo.GetAllCategoriesAsync()).ReturnsAsync(categories);

            var result = await _categoryService.GetCategories();

            Assert.NotNull(result);
            Assert.Equal(2,result.Count());
            Assert.Equal("Bebidas", result.First().Name);
        }

        [Fact]
        public async Task GetCategoryById_ShouldReturnCategoryByID() {

            Category category = new Category("Bebidas");

            _categoryRepositoryMock.Setup(repo => repo.GetCategoryByIdAsync(1)).ReturnsAsync(category);

            var result = await _categoryService.GetCategoryById(1);

            Assert.NotNull(result);
            Assert.Equal("Bebidas", result.Name);
        }

        [Fact]
        public async Task AddCategory_ShouldCallRepository() {
            Category category = new Category("Pizza");

            await _categoryService.AddCategory(category);

            _categoryRepositoryMock.Verify(repo => repo.CreateCategory(category), Times.Once);

        }

        [Fact]
        public async Task UpdateCategory_ShouldCallRepository() {
            var category = new Category("Bebidas");

            await _categoryService.UpdateCategory(category.Id, category);

            _categoryRepositoryMock.Verify(repo => repo.UpdateCategory(category), Times.Once);
        }

        [Fact]
        public async Task DeleteCategory_ShouldCallRepository() {

            int categoryId = 1;

            await _categoryService.DeleteCategory(categoryId);

            _categoryRepositoryMock.Verify(repo => repo.DeleteCategory(categoryId), Times.Once);
        }

    }
}
