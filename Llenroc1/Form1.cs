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
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory + "\\command.txt");
            texts.Add(lines);
            Grammar listOfWords = new Grammar(new GrammarBuilder(texts));
            VoiceRecognition.LoadGrammar(listOfWords);
            

        }
        private void VoiceRecognition_VoiceRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
