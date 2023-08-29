﻿using Assets.Game.Configurations;
using Assets.Game.Core;
using Assets.Game.Plot.Core;
using Assets.Game.Plot.UI;
using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Game.Plot.Steps
{
    //6
    class PStep6ShowPreSiege : PlotStep
    {
        public override event Action OnFinishStep;
        public override event Action<INarrativeStep<PlotStepType>> OnLaunchStep;

        private PlotWordPresentor presentor;
        private readonly PopupManager popupManager;
        private readonly MySceneManager sceneManager;
        private readonly PlotConfig plotConfig;
        private readonly string text = "А на рассвете к стенам Аревберда подошло войско турок-сельджуков.";
        public PStep6ShowPreSiege(PopupManager popupManager, ConfigurationRuntime config, MySceneManager sceneManager)
        {
            this.stepType = PlotStepType.PreSiege;
            this.popupManager = popupManager;
            this.sceneManager = sceneManager;
            this.plotConfig = config.PlotConfig;
        }
        public override void Begin()
        {
            sceneManager.OnChangeScene_Post += DoBegin;
            sceneManager.LoadPlotScene();     
        }

        private void DoBegin(Scene _)
        {
            sceneManager.OnChangeScene_Post -= DoBegin;
            var popup = popupManager.ShowPopup(PopupType.PlotDarkWords) as PlotWordsPopup;
            presentor = new PlotWordPresentor(popup, plotConfig.darkWordTime, text);
            presentor.OnFinish += Finish;
            presentor.Begin();
            OnLaunchStep?.Invoke(this);
        }

        public override void Finish()
        {
            presentor.OnFinish -= Finish;
            popupManager.ClosePopup(PopupType.PlotDarkWords);
            OnFinishStep?.Invoke();
        }
    }
}