using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Drawing;
using DiffMatchPatch;

namespace FileComparisonIgnou
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ChooseFiles : Window
    {
        public ChooseFiles()
        {
            InitializeComponent();
        }

        // this is the diff object;
        diff_match_patch DIFF = new diff_match_patch();

        // these are the diffs
        List<Diff> diffs;

        // chunks for formatting the two RTBs:
        List<Chunk> chunklist1;
        List<Chunk> chunklist2;

        // two color lists:
        Color[] colors1 = new Color[3] { Color.LightGreen, Color.LightSalmon, Color.White };
        Color[] colors2 = new Color[3] { Color.LightSalmon, Color.LightGreen, Color.White };

        FileComparisonForm fileComparisionForm = new FileComparisonForm();
        RichTextBox RTB1;
        RichTextBox RTB2;

        public struct Chunk
        {
            public int startpos;
            public int length;
            public Color BackColor;
        }
        
        List<Chunk> collectChunks(RichTextBox RTB)
        {
            RTB.Text = "";
            List<Chunk> chunkList = new List<Chunk>();
            foreach (Diff d in diffs)
            {
                if (RTB == RTB2 && d.operation == Operation.DELETE) continue;  // **
                if (RTB == RTB1 && d.operation == Operation.INSERT) continue;  // **

                Chunk ch = new Chunk();
                int length = RTB.TextLength;
                RTB.AppendText(d.text);
                ch.startpos = length;
                ch.length = d.text.Length;
                ch.BackColor = RTB == RTB1 ? colors1[(int)d.operation]
                                           : colors2[(int)d.operation];
                chunkList.Add(ch);
            }
            return chunkList;
        }

        void paintChunks(RichTextBox RTB, List<Chunk> theChunks)
        {
            foreach (Chunk ch in theChunks)
            {
                RTB.Select(ch.startpos, ch.length);
                RTB.SelectionBackColor = ch.BackColor;
            }
        }
        
        private void StartComparision_Click(object sender, RoutedEventArgs e)
        {
            RTB1 = fileComparisionForm.textboxAOutput;
            RTB2 = fileComparisionForm.textboxBOutput;
            MessageLabel.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(SelectFile1.Text) || string.IsNullOrEmpty(SelectFile2.Text))
            {
                MessageLabel.Content = "Files path should not be empty!!";
                MessageLabel.Visibility = Visibility.Visible;
                return;
            }
            
            try
            {
                string file1Text = File.ReadAllText(SelectFile1.Text, Encoding.UTF8);
                string file2Text = File.ReadAllText(SelectFile2.Text, Encoding.UTF8);

                diffs = DIFF.diff_main(file1Text, file2Text);
                DIFF.diff_cleanupSemanticLossless(diffs);      // <--- see note !

                chunklist1 = collectChunks(RTB1);
                chunklist2 = collectChunks(RTB2);

                paintChunks(RTB1, chunklist1);
                paintChunks(RTB2, chunklist2);

                RTB1.SelectionLength = 0;
                RTB2.SelectionLength = 0;
            }
            catch(Exception)
            {
                MessageLabel.Content = "Files are not valid!";
                MessageLabel.Visibility = Visibility.Visible;
                return;
            }
            
            fileComparisionForm.Show();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void ChooseFile1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectFile1.Text = fdlg.FileName;
            }
        }

        private void ChooseFile2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Open File Dialog";
            fdlg.InitialDirectory = @"c:\";
            fdlg.Filter = "All files (*.*)|*.*|All files (*.*)|*.*";
            fdlg.FilterIndex = 2;
            fdlg.RestoreDirectory = true;
            if (fdlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SelectFile2.Text = fdlg.FileName;
            }
        }
    }
}
