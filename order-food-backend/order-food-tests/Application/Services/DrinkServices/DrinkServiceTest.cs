using Moq;
using order_food_backend.Repositories.Interfaces;
using order_food_backend.Services;
using order_food_backend.Services.Interfaces;
using OrderFoodLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace order_food_tests.Application.Services.DrinkServices
{
    public class DrinkServiceTest
    {
        private readonly Mock<IDrinkRepository> _drinkRepositoryMock;
        private readonly DrinkService _drinkService;

        public DrinkServiceTest()
        {
            _drinkRepositoryMock = new Mock<IDrinkRepository>();
            _drinkService = new DrinkService(_drinkRepositoryMock.Object);
        }

        [Fact]
        public async Task GetDrinks_ShouldReturnDrinks()
        {

            var drinks = new List<Drink> {

               new Drink ( "Refrigerante",  false ),
               new Drink ( "Cerveja", true )
            };
            _drinkRepositoryMock.Setup(repo => repo.GetAllDrinksAsync()).ReturnsAsync(drinks);

            var result = await _drinkService.GetDrinks();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Refrigerante", result.First().Name);
            Assert.False(result.First().Alcoholic);
        }

        [Fact]
        public async Task GetDrinkById_ShouldReturnDrinkByID()
        {

            Drink drink = new Drink("Refrigerante", false);
            _drinkRepositoryMock.Setup(repo => repo.GetDrinkByIdAsync(1)).ReturnsAsync(drink);

            var result = await _drinkService.GetDrinkById(1);

            Assert.NotNull(result);
            Assert.Equal("Refrigerante", result.Name);
        }

        [Fact]
        public async Task AddDrink_ShouldCallRepository()
        {
            Drink drink = new Drink("Refrigerante", false);

            await _drinkService.AddDrink(drink);

            _drinkRepositoryMock.Verify(repo => repo.CreateDrink(drink), Times.Once);

        }

        [Fact]
        public async Task UpdateDrink_ShouldCallRepository()
        {
            Drink drink = new Drink("Refrigerante", false);

            await _drinkService.UpdateDrink(drink.Id, drink);

            _drinkRepositoryMock.Verify(repo => repo.UpdateDrink(drink), Times.Once);
        }

        [Fact]
        public async Task DeleteDrink_ShouldCallRepository()
        {

            int drinkId = 1;

            await _drinkService.DeleteDrink(drinkId);

            _drinkRepositoryMock.Verify(repo => repo.DeleteDrink(drinkId), Times.Once);
        }
    }
}
