﻿using Microsoft.AspNetCore.Components;
using Net14Web.Models.Dnd;

namespace Net14Web.Services
{
    public class HeroBuilder
    {
        private RandomHelper _randomHelper;

        public HeroBuilder(RandomHelper randomHelper)
        {
            _randomHelper = randomHelper;
        }

        public HeroViewModel BuildRandomHero()
        {
            var hero = new HeroViewModel
            {
                Coin = DateTime.Now.Second * 5,
                Name = _randomHelper.GetRandomName(),
                Tools = new()
            };
            return hero;
        }
    }
}