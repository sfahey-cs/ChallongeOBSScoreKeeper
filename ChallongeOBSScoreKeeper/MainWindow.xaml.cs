using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;

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
            //label.Content = data[0].Participant.name;

            for (int i = 0; i < data.Count; i++)
            {
                playerListView.Items.Add(data[i].Participant.name);
            }
        }

        private void comboBox_DropDownOpened(object sender, System.EventArgs e)
        {
            comboBox.Items.Clear();

            string endPointParticipants = @"https://api.challonge.com/v1/tournaments/1143489/participants.json";
            var clientParticipants = new RestClient(endPointParticipants);
            var jsonParticipants = clientParticipants.MakeRequest("?api_key=dRmpIHLRpgfiepsGWcixpRrettoVeYmSqPw2RJcg");
            JsonSerializer serializerParticipants = new JsonSerializer();
            var dataParticipants = JsonConvert.DeserializeObject<List<Participants>>(jsonParticipants);

            string endPoint = @"https://api.challonge.com/v1/tournaments/1143489/matches.json";
            var client = new RestClient(endPoint);
            var json = client.MakeRequest("?api_key=dRmpIHLRpgfiepsGWcixpRrettoVeYmSqPw2RJcg");
            JsonSerializer serializer = new JsonSerializer();
            var dataMatches = JsonConvert.DeserializeObject<List<Matches>>(json);

            var openMatches = new List<SingleMatch>();
            string player1Name = "";
            string player2Name = "";
            string round = "Winner's";

            int finalRound = dataMatches[dataMatches.Count-1].match.round;

            for (int i=0;i<dataMatches.Count;i++)
            {
                if (dataMatches[i].match.state.Equals("open"))
                {
                    for(int j=0; j<dataParticipants.Count; j++)
                    {
                        if(dataMatches[i].match.player1_id.Equals(dataParticipants[j].Participant.id))
                        {
                            player1Name = dataParticipants[j].Participant.name;
                        }
                        else if (dataMatches[i].match.player2_id.Equals(dataParticipants[j].Participant.id))
                        {
                            player2Name = dataParticipants[j].Participant.name;
                        }
                    }
                    openMatches.Add(dataMatches[i].match);
                    
                    if (dataMatches[i].match.round == finalRound)
                    {
                        round = "Grand Finals";
                        comboBox.Items.Add(round + ": " + player1Name + " vs. " + player2Name);
                    }
                    else if (dataMatches[i].match.round == finalRound*-1)
                    {
                        round = "Losers Finals";
                        comboBox.Items.Add(round + ": " + player1Name + " vs. " + player2Name);
                    }
                    else if(dataMatches[i].match.round < 0)
                    {
                        round = "Losers";
                        comboBox.Items.Add(round + " Round " + Math.Abs(dataMatches[i].match.round) + ": " + player1Name + " vs. " + player2Name);
                    }
                    else
                    {
                        round = "Winners";
                        comboBox.Items.Add(round + " Round " + Math.Abs(dataMatches[i].match.round) + ": " + player1Name + " vs. " + player2Name);
                    }
                    
                }
            }
        }
    }

    public class Participants
    {
        public Participant Participant { get; set; }
    }

    public class Participant
    {
        public int? id { get; set; }
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
    public class Matches
    {
        public SingleMatch match { get; set; }
    }

    public class SingleMatch
    {
        public int id { get; set; }
        public int tournament_id { get; set; }
        public string state { get; set; }
        public int? player1_id { get; set; }
        public int? player2_id { get; set; }
        public int? player1_prereq_match_id { get; set; }
        public int? player2_prereq_match_id { get; set; }
        public bool player1_is_prereq_match_loser { get; set; }
        public bool player2_is_prereq_match_loser { get; set; }
        public object winner_id { get; set; }
        public object loser_id { get; set; }
        public string started_at { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string identifier { get; set; }
        public bool has_attachment { get; set; }
        public int round { get; set; }
        public object player1_votes { get; set; }
        public object player2_votes { get; set; }
        public object group_id { get; set; }
        public object attachment_count { get; set; }
        public object scheduled_time { get; set; }
        public object location { get; set; }
        public object underway_at { get; set; }
        public object optional { get; set; }
        public object rushb_id { get; set; }
        public object completed_at { get; set; }
        public string prerequisite_match_ids_csv { get; set; }
        public string scores_csv { get; set; }
    }
}

