﻿using System.Windows;
using System.Windows.Controls;

namespace Lol.TeamFight.UI.Units
{
    public class QuickButton : Control
    {
        static QuickButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(QuickButton), new FrameworkPropertyMetadata(typeof(QuickButton)));
        }
    }
}
