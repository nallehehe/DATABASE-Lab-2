using SQL_Lab_2.Data;
using SQL_Lab_2.Migrations;
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
    /// Interaction logic for CreatePlaylist.xaml
    /// </summary>
    public partial class CreatePlaylist : Window
    {
        private MusicDbContext _context = new MusicDbContext();
        public string CreatePlaylistName { get; set; }
        public Collection<Track> SelectedTracks { get; } = new Collection<Track>();
        private Collection<Track> _playlist;
        private Window _parentWindow;

        public CreatePlaylist(Window parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            AvailableTracks.ItemsSource = _context.Tracks.ToList();
            SelectedTracksList.ItemsSource = SelectedTracks;
        }

        private void CreatePlaylistButton_Click(object sender, RoutedEventArgs e)
        {
            string playlistName = PlaylistCreateName.Text;

            var newPlaylist = new Playlist
            {
                Name = playlistName,
                Tracks = new Collection<Track>(SelectedTracks.ToList())
            };

            _context.Playlists.Add(newPlaylist);

            _context.SaveChanges();

            _playlist = newPlaylist.Tracks;

            SelectedTracks.Clear();

            PlaylistCreateName.Clear();

            SelectedTracksList.Items.Refresh();

            MessageBox.Show("Your playlist has been saved");
        }

        private void AvailableTracks_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (Track selectedTrack in e.AddedItems)
            {
                if (!SelectedTracks.Contains(selectedTrack))
                {
                    SelectedTracks.Add(selectedTrack);
                }
            }

            foreach (Track unselectedTrack in e.RemovedItems)
            {
                SelectedTracks.Remove(unselectedTrack);
            }

            SelectedTracksList.ItemsSource = null;
            SelectedTracksList.ItemsSource = SelectedTracks;   
        }

        private void DeleteTracksButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedTrackRemove = new List<Track>();
            
            foreach (var selectedItem in SelectedTracksList.SelectedItems)
            {
                if (selectedItem is Track track)
                {
                    selectedTrackRemove.Add(track);
                }
            }

            foreach (var removeTrack in selectedTrackRemove)
            {
                SelectedTracks.Remove(removeTrack);
            }

            SelectedTracksList.ItemsSource = null;
            SelectedTracksList.ItemsSource = SelectedTracks;
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.Show();
            this.Close();
        }
    }
}
