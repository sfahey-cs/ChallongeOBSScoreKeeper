using Newtonsoft.Json;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChallongeOBSScoreKeeper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            string endPoint = @"https://api.challonge.com/v1/tournaments/1143489/participants.json";
            var client = new RestClient(endPoint);
            var json = client.MakeRequest("?api_key=dRmpIHLRpgfiepsGWcixpRrettoVeYmSqPw2RJcg");
            JsonSerializer serializer = new JsonSerializer();
            var data = JsonConvert.DeserializeObject<List<Participants>>(json);
            label.Content = data[0].Participant.name;
        }
    }

    public class Participants
    {
        public Participant Participant { get; set; }
    }

    public class Participant
    {
        public string id { get; set; }
        public string tournament_id { get; set; }
        public string name { get; set; }
        public string seed { get; set; }
        public bool active { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string invite_email { get; set; }
        public string final_rank { get; set; }
        public string misc { get; set; }
        public string icon { get; set; }
        public bool on_waiting_list { get; set; }
        public string invitation_id { get; set; }
        public string group_id { get; set; }
        public string checked_in_at { get; set; }
        public string challonge_username { get; set; }
        public string challonge_email_address_verified { get; set; }
        public bool removable { get; set; }
        public bool participatable_or_invitation_attached { get; set; }
        public bool confirm_remove { get; set; }
        public bool invitation_pending { get; set; }
        public string display_name_with_invitation_email_address { get; set; }
        public string email_hash { get; set; }
        public string username { get; set; }
        public string display_name { get; set; }
        public string attached_participatable_portrait_url { get; set; }
        public bool can_check_in { get; set; }
        public bool checked_in { get; set; }
        public bool reactivatable { get; set; }
    }
}

