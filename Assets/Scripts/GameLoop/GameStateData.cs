using Gameplay.Controllers;

namespace GameLoop
{
    public class GameStateData
    {
        public FoodController FoodController { get; }

        public GameStateData(FoodController foodController)
        {
            FoodController = foodController;
        }
    }
}