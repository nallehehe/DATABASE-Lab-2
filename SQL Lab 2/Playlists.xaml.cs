using Microsoft.EntityFrameworkCore;
using SQL_Lab_2.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SQL_Lab_2
{
    /// <summary>
    /// Interaction logic for Playlists.xaml
    /// </summary>
    public partial class Playlists : Window
    {
        private MusicDbContext _context = new MusicDbContext();
        private Collection<Playlist> _playlists;
        private Window _parentWindow;

        public Playlists(Window parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;

            _playlists = new Collection<Playlist>();
            foreach (var playlist in _context.Playlists.Include(p => p.Tracks))
            {
                _playlists.Add(playlist);
            }

            PlaylistListbox.ItemsSource = _playlists;
        }

        private void PlaylistListbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPlaylist = PlaylistListbox.SelectedItem as Playlist;

            if (selectedPlaylist != null)
            {
                PlaylistContent.ItemsSource = selectedPlaylist.Tracks;
            }
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.Show();
            this.Close();
        }
    }
}
