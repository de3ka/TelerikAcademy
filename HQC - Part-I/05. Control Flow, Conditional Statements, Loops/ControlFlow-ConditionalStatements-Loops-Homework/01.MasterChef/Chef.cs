using System;
using MasterChef.Models;

namespace MasterChef
{
    public class Chef
    {
        public void Cook()
        {
            var potato = this.GetPotato();
            var carrot = this.GetCarrot();

            var peeledPotato = this.Peel(potato);
            var peeledCarrot = this.Peel(carrot);

            var cuttedPotato = this.Cut(potato);
            var cuttedCarrot = this.Cut(carrot);

            Bowl bowl = this.GetBowl();

            var bowlwithVegetables = bowl.Add(cuttedPotato);
            bowlwithVegetables.Add(cuttedCarrot);

            var oven = new Oven();

            var coockedMeal = oven.Cook(bowlwithVegetables);
        }

        private Bowl GetBowl()
        {
            Bowl bowl = new Bowl();
            
            return bowl;
        }

        private Carrot GetCarrot()
        {
            Carrot carrot = new Carrot();
            
            return carrot;
        }

        private Potato GetPotato()
        {
            Potato potato = new Potato();
            
            return potato;
        }

        private Vegetable Peel(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }

        private Vegetable Cut(Vegetable vegetable)
        {
            throw new NotImplementedException();
        }
    }
}
