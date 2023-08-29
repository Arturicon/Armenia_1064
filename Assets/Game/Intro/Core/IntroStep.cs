﻿using Assets.Game.Core;
using Assets.Game.Plot.Core;
using System;

namespace Assets.Game.Intro
{
    abstract class IntroStep : INarrativeStep<IntroStepType>
    {
        public IntroStepType StepType => stepType;
        protected IntroStepType stepType;

        public abstract event Action OnFinishStep;
        public abstract event Action<INarrativeStep<IntroStepType>> OnLaunchStep;

        public abstract void Begin();
        public abstract void Finish();
        public virtual void Break() { }

    }
}