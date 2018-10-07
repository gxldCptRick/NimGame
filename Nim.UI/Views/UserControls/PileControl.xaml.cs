﻿using Nim.UI.Converters;
using Nim.UI.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Nim.UI.Views.UserControls
{
    /// <summary>
    /// Interaction logic for PileControl.xaml
    /// </summary>
    public partial class PileControl : UserControl
    {
        private static readonly IntToImagesConverter converter;

        static PileControl()
        {
            converter = new IntToImagesConverter();
        }

        public PileControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            ResetSpawnGrid();
            (DataContext as PileData).PropertyChanged += AmountLeftHandler;
            takeBtn.Click += (s, i) =>
            {
                (DataContext as PileData).AmountTaken++;
                (DataContext as PileData).AmountLeft--;
            };
        }

        private void ResetSpawnGrid()
        {
            spawnGrid.Children.Clear();
            var value = (DataContext as PileData).AmountLeft;
            var images = converter.Convert(value, null, null, null) as List<UIElement>;
            foreach (var image in images)
            {
                image.MouseDown += (s, e) =>
                {
                    (DataContext as PileData).AmountTaken++;
                    (DataContext as PileData).AmountLeft--;
                };
                spawnGrid.Children.Add(image);
            }
        }

        private void AmountLeftHandler(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AmountLeft") ResetSpawnGrid();
        }
    }
}
