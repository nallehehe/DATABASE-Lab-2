using Microsoft.EntityFrameworkCore;
using SQL_Lab_2.Data;
using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Windows;

namespace SQL_Lab_2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
 
    }

    private void Playlists_Click(object sender, RoutedEventArgs e)
    {
        Playlists win2 = new Playlists(this);
        win2.Show();
        this.Hide();
    }

    private void CreatePlaylist_Click(object sender, RoutedEventArgs e)
    {
        CreatePlaylist win2 = new CreatePlaylist(this);
        win2.Show();
        this.Hide();
    }

    private void Editplaylists_Click(object sender, RoutedEventArgs e)
    {
        EditPlaylists win2 = new EditPlaylists(this);
        win2.Show();
        this.Hide();
    }
}
