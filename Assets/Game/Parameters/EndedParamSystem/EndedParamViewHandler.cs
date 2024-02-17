﻿using Assets.Game.Configurations;
using Assets.Game.UI.FlyingParamPopup;
using ExtraInjection;
using Model.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using UniRx;
using UnityEngine;
using Zenject;

namespace Assets.Game.Parameters.EndedParamSystem
{
    class EndedParamViewHandler : IInitializable, ILateDisposable, IExtraInject
    {
        private readonly EndedParamMechanics endedParamMechanics;
        [ExtraInject] private PopupManager popupManager;
        private readonly PopupConfig popupConfig;

        public EndedParamViewHandler(EndedParamMechanics endedParamMechanics, PopupConfig popupConfig)
        {
            this.endedParamMechanics = endedParamMechanics;
            this.popupConfig = popupConfig;
        }

        void IInitializable.Initialize()
        {
            endedParamMechanics.OnRemovingPeople += TurnOnPopup;
        }
        void ILateDisposable.LateDispose()
        {
            endedParamMechanics.OnRemovingPeople -= TurnOnPopup;
        }

        private void TurnOnPopup(int value)
        {
            endedParamMechanics.IsPopupAvailable = false;
            var popup = popupManager.ShowPopup(PopupType.FlyingParamPopup, false) as FlyingParamPopup;
            popup.OnFinish += TurnOffPopup;
            popup.SetImage(ParameterType.People).SetParam(value).SetConfig(popupConfig.flyinngPopup).SetActive(true);
        }

        private void TurnOffPopup()
        {
            popupManager.ClosePopup(PopupType.FlyingParamPopup);
            endedParamMechanics.IsPopupAvailable = true;
        }
    }
}
