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
    /// Interaction logic for EditPlaylists.xaml
    /// </summary>
    public partial class EditPlaylists : Window
    {
        private MusicDbContext _context = new MusicDbContext();

        private Playlist? _playlist;

        public Collection<Track> SelectedTracks { get; } = new Collection<Track>();

        private Window _parentWindow;

        public EditPlaylists(Window parentWindow)
        {
            InitializeComponent();
            _parentWindow = parentWindow;
            _context.Tracks.Load();
            _context.Playlists.Load();
            AllAvailableTracks.ItemsSource = _context.Tracks.Local.ToObservableCollection();
            AllAvailablePlaylists.ItemsSource = _context.Playlists.Local.ToObservableCollection();
            EditSelectedTracksList.ItemsSource = SelectedTracks;
        }

        private void AllAvailablePlaylists_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _playlist = AllAvailablePlaylists.SelectedItem as Playlist;
            if (_playlist != null)
            {
                _context.Entry(_playlist).Collection(x => x.Tracks).Load();

                PlaylistEditName.Text = _playlist.Name;

                EditSelectedTracksList.ItemsSource = _playlist.Tracks;
            }
        }

        private Playlist? GetTrackedPlaylist()
        {
            if (_playlist is null)
            {
                MessageBox.Show("You must select a playlist");

                return null;
            }

            return _context.Playlists.Find(_playlist.PlaylistId);
        }

        private void DeleteSelectedTracks_Click(object sender, RoutedEventArgs e)
        {
            var entityPlaylist = GetTrackedPlaylist();

            if (entityPlaylist is null)
            {
                return;
            }

            var selectedTracksToRemove = new List<int>();

            foreach (var selectedItem in EditSelectedTracksList.SelectedItems)
            {
                if (selectedItem is Track track)
                {
                    selectedTracksToRemove.Add(track.TrackID);
                }
            }

            foreach (var track in selectedTracksToRemove)
            {
                var trackToRemove = entityPlaylist.Tracks.Where(x => x.TrackID == track).First();

                if (trackToRemove is not null)
                {
                    entityPlaylist.Tracks.Remove(trackToRemove);
                }
            }

            _context.SaveChanges();

            EditSelectedTracksList.ItemsSource = entityPlaylist.Tracks;
            EditSelectedTracksList.Items.Refresh();

            MessageBox.Show("The selected tracks have been deleted.");
        }

        private void SavePlaylist_Click(object sender, RoutedEventArgs e)
        {
            var entityPlaylist = GetTrackedPlaylist();

            if (entityPlaylist is null)
            {
                return;
            }

            string playlistName = PlaylistEditName.Text;

            var newPlaylist = new Playlist
            {
                Name = playlistName,
                Tracks = new Collection<Track>(SelectedTracks.ToList())
            };

            _context.Playlists.Add(newPlaylist);

            _context.SaveChanges();

            _playlist.Tracks = newPlaylist.Tracks;

            SelectedTracks.Clear();

            PlaylistEditName.Clear();

            EditSelectedTracksList.Items.Refresh();

            MessageBox.Show("Your playlist has been saved");
        }

        private void AddTracks_Click(object sender, RoutedEventArgs e)
        {
            Playlist? entityPlaylist = GetTrackedPlaylist();

            if (entityPlaylist is null)
            {
                entityPlaylist = new Playlist();
                _context.Add(entityPlaylist);
            }

            var selectedTracksToAdd = AllAvailableTracks.SelectedItems.OfType<Track>().ToList();

            foreach (var track in selectedTracksToAdd)
            {
                if(!entityPlaylist.Tracks.Contains(track))
                {
                    entityPlaylist.Tracks.Add(track);
                }
            }

            _context.SaveChanges();

            EditSelectedTracksList.Items.Refresh();

            MessageBox.Show("The selected tracks have been added to the playlist.");
        }

        private void DeletePlaylist_Click(object sender, RoutedEventArgs e)
        {
            var entity = GetTrackedPlaylist();

            if (entity is null)
            {
                MessageBox.Show("I could not find any playlist, try again.");

                return;
            }

            _context.Remove(entity);

            _context.SaveChanges();

            MessageBox.Show("The playlist has been deleted.");
        }

        private void MainMenu_Click(object sender, RoutedEventArgs e)
        {
            _parentWindow.Show();
            this.Close();
        }

    }
}
