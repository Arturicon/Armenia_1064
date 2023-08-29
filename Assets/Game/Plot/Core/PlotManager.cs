﻿using Assets.Game.Configurations;
using Assets.Game.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zenject;

namespace Assets.Game.Plot.Core
{
    public class PlotManager : NarrativeManager<PlotStepType>, IInitializable, ILateDisposable
    {
        public PlotManager(List<INarrativeStep<PlotStepType>> steps, ConfigurationRuntime config) : base(steps)
        {
            this.config = config.PlotConfig;
        }

        void IInitializable.Initialize()
        {
            Init();
        }

        void ILateDisposable.LateDispose()
        {
            Finish();
        }
    }
}