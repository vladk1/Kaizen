using Microsoft.Phone.BackgroundAudio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modelOne
{
    class UpdatePlayerState
    {



        public string[] UpdateState(object sender, EventArgs e)
        {

            string[] updatePlayerArray;
            updatePlayerArray = new string[4];

            string trackTitle = ""; // trackTitle.Text

            double posIndicator;
            string positionIndicator = ""; // positionIndicator.Value

            string textPosition = ""; // textPosition.Text

            string textRemaining = ""; // textRemaining.Text


            // txtState.Text = string.Format("State: {0}", mediaElement.CurrentState);
            // ?  txtState.Text = string.Format("State: {0}", (App.Current as App).MainAudioPlayer.PlayerState);

            // txtTrack.Text = string.Format("Track: {0}", mediaElement.Name);
            //if ((App.Current as App).MainAudioPlayer.Track.Title!=null)
           // trackTitle = string.Format("Track: {0}", (App.Current as App).MainAudioPlayer.Track.Title);

            //trackTitle = string.Format("Track: {0}", BackgroundAudioPlayer.Instance.Track.Title);


            // Set the current possion on the ProgressBar
            //positionIndicator.Value = mediaElement.Position.TotalSeconds;
           // if ((App.Current as App).MainAudioPlayer.Position.TotalSeconds != null)
          //  {
            //    posIndicator = (App.Current as App).MainAudioPlayer.Position.TotalSeconds;
            posIndicator = BackgroundAudioPlayer.Instance.Position.TotalSeconds;
              
            positionIndicator = posIndicator.ToString("0.00");
            //}


            // Update the current playback position
            TimeSpan position = new TimeSpan();
            //position = mediaElement.Position;
           // position = (App.Current as App).MainAudioPlayer.Position;
            position = BackgroundAudioPlayer.Instance.Position;

            textPosition = String.Format("{0:d2}:{1:d2}:{2:d2}", position.Hours, position.Minutes, position.Seconds);


            // Update the time ramaining digits
            TimeSpan timeRemaining = new TimeSpan();

            // timeRemainging = mediaElement.NaturalDuration.TimeSpan - position;
            //timeRemaining = (App.Current as App).MainAudioPlayer.Position.Duration() - position;
            timeRemaining = BackgroundAudioPlayer.Instance.Position.Duration() - position;

            textRemaining = String.Format("-{0:d2}:{1:d2}:{2:d2}", timeRemaining.Hours, timeRemaining.Minutes, timeRemaining.Seconds);


            updatePlayerArray[0] = trackTitle;
            updatePlayerArray[1] = positionIndicator;
            updatePlayerArray[2] = textPosition;
            updatePlayerArray[3] = textRemaining;
            
            return updatePlayerArray;
        }
       




    }
}
