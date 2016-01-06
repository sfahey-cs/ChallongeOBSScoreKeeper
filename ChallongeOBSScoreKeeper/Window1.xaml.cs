using System;
using System.Collections.Generic;
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
using Newtonsoft.Json;

namespace ChallongeOBSScoreKeeper
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private static List<Tournaments> data;
        public static int? tournamentID;
        public static string apiKey;

        public Window1()
        {
            InitializeComponent();
        }

        private void comboBox_DropDownOpened(object sender, EventArgs e)
        {
            apiKey = textBox.Text;
            string endPoint = @"https://api.challonge.com/v1/tournaments.json";
            var client = new RestClient(endPoint);
            try
            {

                var json = client.MakeRequest("?api_key=" + apiKey);
                JsonSerializer serializer = new JsonSerializer();
                data = JsonConvert.DeserializeObject<List<Tournaments>>(json);

                for (int i = 0; i < data.Count; i++)
                {
                    comboBox.Items.Add(data[i].tournament.name);
                }
            } catch (Exception error)
            {
                MessageBox.Show(error.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(comboBox.SelectedIndex != -1)
                tournamentID = data[comboBox.SelectedIndex].tournament.id;
            this.Close();
        }
    }
    public class Tournaments
    {
        public Tournament tournament { get; set; }
    }

    public class Tournament
    {
        public int id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string description { get; set; }
        public string tournament_type { get; set; }
        public DateTime? started_at { get; set; }
        public object completed_at { get; set; }
        public bool require_score_agreement { get; set; }
        public bool notify_users_when_matches_open { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public string state { get; set; }
        public bool open_signup { get; set; }
        public bool notify_users_when_the_tournament_ends { get; set; }
        public int progress_meter { get; set; }
        public bool quick_advance { get; set; }
        public bool hold_third_place_match { get; set; }
        public string pts_for_game_win { get; set; }
        public string pts_for_game_tie { get; set; }
        public string pts_for_match_win { get; set; }
        public string pts_for_match_tie { get; set; }
        public string pts_for_bye { get; set; }
        public int swiss_rounds { get; set; }
        public bool _private { get; set; }
        public string ranked_by { get; set; }
        public bool show_rounds { get; set; }
        public bool hide_forum { get; set; }
        public bool sequential_pairings { get; set; }
        public bool accept_attachments { get; set; }
        public string rr_pts_for_game_win { get; set; }
        public string rr_pts_for_game_tie { get; set; }
        public string rr_pts_for_match_win { get; set; }
        public string rr_pts_for_match_tie { get; set; }
        public bool created_by_api { get; set; }
        public bool credit_capped { get; set; }
        public object category { get; set; }
        public bool hide_seeds { get; set; }
        public int prediction_method { get; set; }
        public object predictions_opened_at { get; set; }
        public bool anonymous_voting { get; set; }
        public int max_predictions_per_user { get; set; }
        public object signup_cap { get; set; }
        public int? game_id { get; set; }
        public int participants_count { get; set; }
        public bool group_stages_enabled { get; set; }
        public bool allow_participant_match_reporting { get; set; }
        public bool teams { get; set; }
        public object check_in_duration { get; set; }
        public object start_at { get; set; }
        public object started_checking_in_at { get; set; }
        public string[] tie_breaks { get; set; }
        public object locked_at { get; set; }
        public object event_id { get; set; }
        public object public_predictions_before_start_time { get; set; }
        public object ranked { get; set; }
        public string description_source { get; set; }
        public object subdomain { get; set; }
        public string full_challonge_url { get; set; }
        public string live_image_url { get; set; }
        public object sign_up_url { get; set; }
        public bool review_before_finalizing { get; set; }
        public bool accepting_predictions { get; set; }
        public bool participants_locked { get; set; }
        public string game_name { get; set; }
        public bool participants_swappable { get; set; }
        public bool team_convertable { get; set; }
        public bool group_stages_were_started { get; set; }
    }

}
