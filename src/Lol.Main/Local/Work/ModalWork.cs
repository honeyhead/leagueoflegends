﻿using System;
using System.Collections.Generic;
using Lol.Friends.UI.Views;
using Lol.Settings.UI.Views;
using Lol.Main.Local.ViewModel;
using Lol.Friends.Local.ViewModel;
using Lol.Settings.Local.ViewModel;
using DevNcore.LayoutSupport.Leagueoflegends.Controls.Primitives;

namespace Lol.Main.Local.Work
{
    public class ModalWork
    {
        #region Variables 

        private readonly MainViewModel _vm;
        private readonly Dictionary<Type, IRiotUI> _modals;
        #endregion

        #region Constructor

        public ModalWork(MainViewModel vm)
        {
            _vm = vm;
            _modals = new();
        }
        #endregion

        #region SwitchModal

        internal void SwitchModal(Type type)
        {
            IRiotUI content = null;

            if (typeof(SettingView) == type) content = SwitchSettingView(type);
            if (typeof(AddFriendsView) == type) content = SwitchAddFriendsView(type);

            _vm.ModalContent = content;
        }
        #endregion

        #region SwitchSettingView

        private IRiotUI SwitchSettingView(Type type)
        {
            if (!_modals.ContainsKey(type))
            {
                _modals.Add(type, new SettingView().SetVM(new SettingViewModel(CloseModal)));
            }

            return _modals[type];
        }
        #endregion

        #region SwitchAddFriendsView

        private IRiotUI SwitchAddFriendsView(Type type)
        {
            if (!_modals.ContainsKey(type))
            {
                _modals.Add(type, new AddFriendsView().SetVM(new AddFriendsViewModel(CloseModal)));
            }

            return _modals[type];
        }
        #endregion

        #region CloseModal

        private void CloseModal(IRiotUI ui)
        {
            _vm.ModalContent = null;
        }
        #endregion
    }
}
