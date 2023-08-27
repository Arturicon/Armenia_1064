﻿using Assets.Game.Intro;
using Zenject;

namespace Loader
{
    class TaskStartIntro : IInitializable
    {
        private readonly IntroManager introManager;

        public TaskStartIntro(IntroManager introManager)
        {
            this.introManager = introManager;
        }
        void IInitializable.Initialize()
        {
            introManager.Begin();
        }
    }
}
