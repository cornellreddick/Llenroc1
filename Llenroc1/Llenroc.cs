using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.NetworkInformation;
using System.Diagnostics;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Speech.Recognition;
using System.Speech.Synthesis;

	

namespace Llenroc1
{
    public partial class Llenroc : Form
    {
         
        SpeechRecognitionEngine VoiceRecognition = new SpeechRecognitionEngine();
        SpeechSynthesizer llenroc = new SpeechSynthesizer();
        DateTime dateTime = DateTime.Now.Date;
        PromptBuilder pb = new PromptBuilder();
        //TO DO: add a prompt feature to the applicaton

        public Llenroc()
        {
            VoiceRecognition.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(VoiceRecognition_VoiceRecognized);
            LoadGrammar();
            VoiceRecognition.SetInputToDefaultAudioDevice();
            VoiceRecognition.RecognizeAsync(RecognizeMode.Multiple);
            InitializeComponent();
        }
        
        private void LoadGrammar()
        {
            Choices texts = new Choices();
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\voicecommand.txt");
            texts.Add(lines);
            Grammar listOfWords = new Grammar(new GrammarBuilder(texts));
            VoiceRecognition.LoadGrammar(listOfWords);
            

        }
        private void VoiceRecognition_VoiceRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            questionBox.Text = e.Result.Text;
            string voice = e.Result.Text;
            switch (voice)
            {
                case "Hello":
                    llenroc.Speak("Hello Cornell");
                    break;
                case "How are you doing today":
                    llenroc.Speak("I'm doing fine");
                    break;
                case "Llenroc":
                    llenroc.Speak("Hello Cornell");
                    break;
                case "What is your name":
                    llenroc.Speak("Llenroc");
                    break;
                case "What is my wife name":
                    llenroc.Speak("Davilla Reddick");
                    break;
                    case "What is my daugter name":
                    llenroc.Speak("Cornell Reddick Junior");
                    break;
                case "What is my son name":
                    llenroc.Speak("Cornell Reddick Junior");
                    break;
                case "what is the date":
                    llenroc.Speak("Today is" + DateTime.Now);
                    break;
                case "what is my niece name":
                    llenroc.Speak("Allona Anderson");
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
