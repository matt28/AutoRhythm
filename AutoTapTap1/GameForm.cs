using System;//WRITE BYTES PER SAMPLE AS 2 BYTES MAXIMUM
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Media;
using System.Diagnostics;
using System.Collections;

namespace AutoTapTap1
{
    public partial class GameForm : Form
    {
        #region Var Init
        #region sp, fs and br
        public static string directory;
        public SoundPlayer sp = new SoundPlayer(directory);
        public FileStream fs = new FileStream(directory, FileMode.Open);
        public BinaryReader br;
        #endregion
        #region Wav file variables
        public bool IsStereo = true; //True for stereo, false for mono
        public double SamplesPerSecond;
        public double SamplesPer10Mil;
        public double BytesPerSample;
        public long bytes = 36;
        public double BytesPerSecond;
        #endregion
        #region Randomness
        public Random rndseed = new Random();
        public Random rnd;
        #endregion
        #region Temporary intergers
        public int ti;
        public int ti2;
        public int ti3;
        public int ti4;
        public int ti5;
        public int ti6;
        public int ti7;
        public int ti8;
        public int ti9;
        #endregion
        #region Song variables
        public bool SongIsReadyToPlay = false;//This is true after 10 seconds of ElapsedMilliseconds of the timer
        #endregion
        #region others
        public bool SecRun = false;
        public int bytediff = 0;
        public Frequency f = Frequency.same;
        public bool firstrun2 = true;
        public TapperRail tt;
        public bool firstrun3 = true;
        public int ClosestYTo580pxl = 0;
        public int ClosestYTo580pxc = 0;
        public int ClosestYTo580pxr = 0;
        public int ClosestYTo580pxf = 0;
        public bool HasDeleted = false;
        public bool Deletedvld = false;
        public int intensity = 0;
        public int fail = 0;
        public int feeling = 0;
        #endregion
        #region ArrayLists
        public ArrayList noteIDs = new ArrayList();
        public ArrayList notes = new ArrayList();
        public ArrayList VolLines = new ArrayList();
        #endregion
        #region Difficulty vars
        public static int avcval;// 2 = super hard 40 = super easy
        public static double notemakeConstant;// 0.01 = super hard 1 = super easy
        public static int MillSecWaitTime;//0 = impossible 200 = too easy
        public static int AvcNoteMakeLimit;//1 = madness 3 = somewhat easy
        public static int FmsTriggerValue;//0 = uberultramegasupremeextreme 100 = somewhat easy
        #endregion
        #region Timers
        public Stopwatch time = new Stopwatch();
        public Stopwatch timer = new Stopwatch();//Used for volume update loop...
        public Stopwatch RTS = new Stopwatch();
        public bool BREnded = false;
        public Stopwatch vldTimer = new Stopwatch();
        public Stopwatch TimeSinceReadingStarted = new Stopwatch();//Used for bytes=this*(hertz * channels * 8/16bit AKA 1 or 2)

        #region HitFX timers
        /// <summary>
        /// Will only appear for about 50 millisecs
        /// </summary>
        public Stopwatch leftfx = new Stopwatch();
        /// <summary>
        /// Will only appear for about 50 millisecs
        /// </summary>
        public Stopwatch centrefx = new Stopwatch();
        /// <summary>
        /// Will only appear for about 50 millisecs
        /// </summary>
        public Stopwatch rightfx = new Stopwatch();
        #endregion

        #endregion
        #region Note making variables
        public bool Waiting = false;
        public bool AllowNote = true;
        public Stopwatch WaitTime = new Stopwatch();
        public bool NeedToTimeWait = true;
        public int mi = 0;
        public int avc = 0;
        public bool NoteMadeAlready = false;
        public double VFirst = 0, VSec = 0;
        public double fms = 0;
        #endregion
        #region Key press variables
        public char CharPressed;
        public int SelectedCount;
        public bool AnyChosenAtAll = false;
        public bool havedeleted = false;
        #endregion
        #region Game variables
        public int score = 0;
        public int multiplier = 1;
        public int streak = 0;
        #endregion
        #endregion
        #region The form1 initialisation function
        public GameForm()
        {
            int it;
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.OptimizedDoubleBuffer, true);
            br = new BinaryReader(fs);
            #region Wav file stats reading
            //Read Samples per second
            br.BaseStream.Position = 24;
            it = br.Read();
            if (it == 68)
                SamplesPerSecond = 44100;
            else if (it == 34)
                SamplesPerSecond = 22050;
            else if (it == 17)
                SamplesPerSecond = 11025;
            else
                MessageBox.Show("Not supported SampleFrequency...");
            //MessageBox.Show("Samples/Second: " + SamplesPerSecond);

            //Samples per 10 milliseconds
            SamplesPer10Mil = SamplesPerSecond / 100.0;

            //Read stereoism
            br.BaseStream.Position = 22;
            it = br.Read();
            if (it == 1)
            {
                IsStereo = false; //MessageBox.Show("Using mono");
            }
            if (it == 2)
            {
                IsStereo = true; //MessageBox.Show("Using Stereo");
            }

            //Read Bytes per sample
            br.BaseStream.Position = 32;
            BytesPerSample = br.Read();
            //MessageBox.Show("Bytes per sample: " + BytesPerSample);
            #endregion
            br.BaseStream.Position = 36;
            rnd = new Random(rndseed.Next());
            System.Threading.Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
            #region randomness
            ti9 = rnd.Next(1, 3);
            if (ti9 == 1)
                tt = TapperRail.left;
            if (ti9 == 2)
                tt = TapperRail.right;
            if (ti9 == 3)
                tt = TapperRail.centre;
            #endregion
            BytesPerSecond = BytesPerSample * SamplesPerSecond;
            timer.Start();
        }
        #endregion
        #region The OnPaint function
        private void OnPaint(object sender, PaintEventArgs e)
        {
            #region TRY!
            try
            {

                ComboView.BackColor = Color.FromArgb(fail, Convert.ToInt32(feeling * 1.5), intensity);
                long elaspedtimestatic = time.ElapsedMilliseconds;
                time.Restart();
                VFirst = VSec;
                e.Graphics.Clear(Color.FromArgb(fail, Convert.ToInt32(feeling * 1.5), intensity));
                #region volbar
                if (BytesPerSample == 1)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue), 0, 10, 50, mi / 256f * 550f);
                    if (rnd.Next(4) == 1)
                        VolLines.Add(new VolLineDisplay(Convert.ToInt32(mi / 256.0 * 100.0)));
                }
                if (BytesPerSample == 2 && IsStereo == false)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue), 0, 10, 50, mi / 65536f * 550f);
                    if (rnd.Next(4) == 1)
                        VolLines.Add(new VolLineDisplay(Convert.ToInt32(mi / 65536.0 * 100.0)));
                }
                if (BytesPerSample == 2 && IsStereo)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue), 0, 10, 50, mi / 256f * 550f);
                    if (rnd.Next(4) == 1)
                        VolLines.Add(new VolLineDisplay(Convert.ToInt32(mi / 256.0 * 100.0)));
                }
                if (BytesPerSample == 4)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.AliceBlue), 0, 10, 50, mi / 65536f * 550f);
                    if (rnd.Next(4) == 1)
                        VolLines.Add(new VolLineDisplay(Convert.ToInt32(mi / 65536.0 * 100.0)));
                }
                #endregion
                #region HitFX
                if (leftfx.ElapsedMilliseconds >= 50)
                    leftfx.Stop();
                if (centrefx.ElapsedMilliseconds >= 50)
                    centrefx.Stop();
                if (rightfx.ElapsedMilliseconds > 50)
                    rightfx.Stop();

                if (leftfx.ElapsedMilliseconds != 0)
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb((int)((50 - leftfx.ElapsedMilliseconds) * 127 / 50.0), 255, 200, 200)), 100, 440, 50, 30);
                if (centrefx.ElapsedMilliseconds != 0)
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb((int)((50 - centrefx.ElapsedMilliseconds) * 127 / 50.0), 255, 255, 200)), 180, 440, 50, 30);
                if (rightfx.ElapsedMilliseconds != 0)
                    e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb((int)((50 - rightfx.ElapsedMilliseconds) * 127 / 50.0), 200, 255, 200)), 260, 440, 50, 30);
                #endregion
                #region for loop for notes
                for (int Count = 0; Count < notes.Count; Count++)
                {
                    note n = notes[Count] as note;
                    n.y += Convert.ToInt32(370.0 * elaspedtimestatic / 1000.0);
                    if (n.IsToDelete)
                    {
                        if (intensity + 30 < 256)
                            intensity += 30;
                        else
                            intensity = 255;
                        notes.RemoveAt(Count);
                        HasDeleted = true;
                    }
                    if (n.y > 600) { score -= 100; streak = 0; multiplier = 1; notes.RemoveAt(Count); HasDeleted = true; AccuracyDisplay.Text = "MISS!"; if (fail < 180) fail += 75; else fail = 255; }
                    #region tapper drawing
                    if (n.y < 600)
                    {
                        if (n.tr == TapperRail.left)
                            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 30, 20)), 100, n.y, 50, 20);
                        if (n.tr == TapperRail.centre)
                            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(255, 230, 30)), 180, n.y, 50, 20);
                        if (n.tr == TapperRail.right)
                            e.Graphics.FillEllipse(new SolidBrush(Color.FromArgb(20, 255, 20)), 260, n.y, 50, 20);
                    }
                    #endregion
                    if (!HasDeleted)
                        notes[Count] = n as note;
                    HasDeleted = false;
                }
                #endregion
                #region for loop for VolLineDisplay
                for (int count = 0; count < VolLines.Count; count++)
                {
                    VolLineDisplay vld = VolLines[count] as VolLineDisplay;
                    vld.y += Convert.ToInt32(370.0 * elaspedtimestatic / 1000.0);
                    if (vld.lengthpx > 94)
                        e.Graphics.DrawLine(new Pen(Color.FromArgb(170, 255, 30, 255), 5f), new Point(100, vld.y), new Point(100 + vld.lengthpx * 10, vld.y));
                    else
                        e.Graphics.DrawLine(new Pen(Color.FromArgb(0x30FFFFFF), 2f), new Point(100, vld.y), new Point(100 + vld.lengthpx * 10, vld.y));
                    if (vld.y > 500)
                    {
                        feeling = vld.lengthpx;
                        VolLines.RemoveAt(count);
                        Deletedvld = true;
                    }
                    if (!Deletedvld)
                    {
                        VolLines[count] = vld as VolLineDisplay;
                    }
                    Deletedvld = false;
                }
                #endregion
                #region avc settings
                if (avc == avcval)
                    avc = 0;
                #endregion
                #region BaseStream setting
                br.BaseStream.Position = bytes;
                #endregion
                #region SongIsReadyToPlay thing...
                if (timer.ElapsedMilliseconds > 3000)
                {
                    if (firstrun2)
                    {
                        firstrun2 = false;
                        SongIsReadyToPlay = true;
                        //sp.Play(); THIS IS ONLY FOR BEAT TESTING!!!!!!!
                        RTS.Restart();
                        time.Start();
                        vldTimer.Start();
                        TimeSinceReadingStarted.Start();
                    }
                }
                #endregion
                #region ToPlayTehSOOONG
                if (firstrun3 && timer.ElapsedMilliseconds > 4666)
                {
                    sp.Play();
                    firstrun3 = false;
                }
                #endregion
                #region timerthing...
                if (SongIsReadyToPlay)
                {
                    #region The real stuff
                    if (timer.ElapsedMilliseconds % 10 < 8 && timer.ElapsedMilliseconds % 10 > -8)
                    {
                        #region one
                        if (BytesPerSample == 1)
                        {
                            ti = br.ReadByte();
                            ti2 = br.ReadByte();
                            ti3 = br.ReadByte();
                            ti4 = br.ReadByte();
                            br.ReadBytes(Convert.ToInt32(SamplesPer10Mil * BytesPerSample - 4));
                            if (SecRun)
                            {
                                #region Frequency checking (and volume also....)
                                if (Math.Abs(ti - ti2) - bytediff > 40)
                                    f = Frequency.higher;
                                if (Math.Abs(ti - ti2) - bytediff > 80)
                                    f = Frequency.vhigh;
                                if (Math.Abs(ti - ti2) - bytediff < 40)
                                    f = Frequency.lower;
                                if (Math.Abs(ti - ti2) - bytediff < 80)
                                    f = Frequency.vlow;
                                if (Math.Abs(ti - ti2) - bytediff < 20 && Math.Abs(ti - ti2) - bytediff > -20)
                                    f = Frequency.same;
                                if (ti < 4 || ti2 < 4 || ti3 < 4 || ti4 < 4)
                                    f = Frequency.nulled;
                                if (Math.Abs(ti - ti3) < 20 && Math.Abs(ti2 - ti4) < 20)
                                    f = Frequency.doublenote;
                                if (ti > 240 || ti2 > 240 || ti3 > 240 || ti4 > 240)
                                    f = Frequency.BLAST;
                                #endregion
                            }
                            bytediff = Math.Abs(ti - ti2);
                            SecRun = true;
                        }
                        #endregion
                        #region two mono
                        else if (BytesPerSample == 2 && IsStereo == false)
                        {
                            #region INIT!!!
                            ti = br.ReadByte();//Chunk1 lb
                            ti2 = br.ReadByte();//Chunk1 hb
                            ti3 = br.ReadByte();//2lb
                            ti4 = br.ReadByte();//2hb
                            ti5 = br.ReadByte();//3lb
                            ti6 = br.ReadByte();//3hb
                            ti7 = br.ReadByte();//4lb
                            ti8 = br.ReadByte();//4hb
                            #endregion
                            #region Amplitude init (the real one). Values are upon 65536
                            ti = ti + ti2 * 0x100;
                            ti2 = ti3 + ti4 * 0x100;
                            ti3 = ti5 + ti6 * 0x100;
                            ti4 = ti7 + ti8 * 0x100;
                            #endregion
                            br.ReadBytes(Convert.ToInt32(SamplesPer10Mil * BytesPerSample - 8));
                            if (SecRun)
                            {
                                #region Frequency checking (and volume also....)
                                if (Math.Abs(ti - ti2) - bytediff > 10240)
                                    f = Frequency.higher;
                                if (Math.Abs(ti - ti2) - bytediff > 20480)
                                    f = Frequency.vhigh;
                                if (Math.Abs(ti - ti2) - bytediff < 10240)
                                    f = Frequency.lower;
                                if (Math.Abs(ti - ti2) - bytediff < 20480)
                                    f = Frequency.vlow;
                                if (Math.Abs(ti - ti2) - bytediff < 5120 && Math.Abs(ti - ti2) - bytediff > -5120)
                                    f = Frequency.same;
                                if (ti < 1024 || ti2 < 1024 || ti3 < 1024 || ti4 < 1024)
                                    f = Frequency.nulled;
                                if (Math.Abs(ti - ti3) < 5120 && Math.Abs(ti2 - ti4) < 5120)
                                    f = Frequency.doublenote;
                                if (ti > 61440 || ti2 > 61440 || ti3 > 61440 || ti4 > 61440)
                                    f = Frequency.BLAST;
                                #endregion
                            }
                            bytediff = Math.Abs(ti - ti2);
                            SecRun = true;
                        }
                        #endregion
                        #region two stereo
                        else if (BytesPerSample == 2 && IsStereo)
                        {
                            ti = br.ReadByte();
                            br.ReadByte();//Well, it's stereo and that's no reason to make tappers stereo...
                            ti2 = br.ReadByte();
                            br.ReadByte();
                            ti3 = br.ReadByte();
                            br.ReadByte();
                            ti4 = br.ReadByte();
                            br.ReadByte();
                            br.ReadBytes(Convert.ToInt32(SamplesPer10Mil * BytesPerSample - 8));
                            if (SecRun)
                            {
                                #region Frequency checking (and volume also....)
                                if (Math.Abs(ti - ti2) - bytediff > 40)
                                    f = Frequency.higher;
                                if (Math.Abs(ti - ti2) - bytediff > 80)
                                    f = Frequency.vhigh;
                                if (Math.Abs(ti - ti2) - bytediff < 40)
                                    f = Frequency.lower;
                                if (Math.Abs(ti - ti2) - bytediff < 80)
                                    f = Frequency.vlow;
                                if (Math.Abs(ti - ti2) - bytediff < 20 && Math.Abs(ti - ti2) - bytediff > -20)
                                    f = Frequency.same;
                                if (ti < 4 || ti2 < 4 || ti3 < 4 || ti4 < 4)
                                    f = Frequency.nulled;
                                if (Math.Abs(ti - ti3) < 20 && Math.Abs(ti2 - ti4) < 20)
                                    f = Frequency.doublenote;
                                if (ti > 240 || ti2 > 240 || ti3 > 240 || ti4 > 240)
                                    f = Frequency.BLAST;
                                #endregion
                            }
                            bytediff = Math.Abs(ti - ti2);
                            SecRun = true;
                        }
                        #endregion
                        #region four
                        else if (BytesPerSample == 4)
                        {
                            #region INIT!!!
                            ti = br.ReadByte();//Chunk1 lb
                            ti2 = br.ReadByte();//Chunk1 hb
                            br.ReadBytes(2);//THIS IS STEREO!!!!!!
                            ti3 = br.ReadByte();//2lb
                            ti4 = br.ReadByte();//2hb
                            br.ReadBytes(2);
                            ti5 = br.ReadByte();//3lb
                            ti6 = br.ReadByte();//3hb
                            br.ReadBytes(2);
                            ti7 = br.ReadByte();//4lb
                            ti8 = br.ReadByte();//4hb
                            br.ReadBytes(2);
                            #endregion
                            #region Amplitude init (the real one). Values are upon 65536
                            ti = ti + ti2 * 0x100;
                            ti2 = ti3 + ti4 * 0x100;
                            ti3 = ti5 + ti6 * 0x100;
                            ti4 = ti7 + ti8 * 0x100;
                            #endregion
                            if (SecRun)
                            {
                                #region Frequency checking (and volume also....)
                                if (Math.Abs(ti - ti3) < 5120 && Math.Abs(ti2 - ti4) < 5120)
                                    f = Frequency.doublenote;
                                else if (ti > 61440 || ti2 > 61440 || ti3 > 61440 || ti4 > 61440)
                                    f = Frequency.BLAST;
                                else if (ti < 1024 || ti2 < 1024 || ti3 < 1024 || ti4 < 1024)
                                    f = Frequency.nulled;
                                else
                                {
                                    if (Math.Abs(ti - ti2) - bytediff > 10240)
                                        f = Frequency.higher;
                                    else if (Math.Abs(ti - ti2) - bytediff > 20480)
                                        f = Frequency.vhigh;
                                    else if (Math.Abs(ti - ti2) - bytediff < 10240)
                                        f = Frequency.lower;
                                    else if (Math.Abs(ti - ti2) - bytediff < 20480)
                                        f = Frequency.vlow;
                                    else if (Math.Abs(ti - ti3) - bytediff < 5120 && Math.Abs(ti - ti3) - bytediff > -5120)
                                        f = Frequency.same;
                                }

                                #endregion
                            }
                            bytediff = Math.Abs(ti - ti2);
                            SecRun = true;
                        }
                        #endregion
                        else
                        {
                            MessageBox.Show("You're not using a wav file!!!");
                        }
                        avc++;
                        if (avc == 1)
                            mi = (ti + mi * (avcval - 3)) / avcval;
                        else
                            mi += (ti - mi) / avc;
                    }
                    #endregion
                }
                #endregion
                #region VSec manipulation
                if ((BytesPerSample == 1 || (BytesPerSample == 2 && IsStereo)) && avc > 3)
                    VSec = mi / 256.0 * 100.0;
                if (BytesPerSample == 4 || (BytesPerSample == 2 && !IsStereo) && avc > 3)
                    VSec = mi / 65536.0 * 100.0;
                #endregion
                fms = ((VFirst - VSec) * 100 + fms) / 2;
                #region Controls
                #region milab
                milab.Text = mi.ToString();
                #endregion
                #region RTime
                RTime.Text = RTS.ElapsedMilliseconds.ToString();
                #endregion
                #region VF
                VF.Text = VFirst.ToString();
                #endregion
                #region VS
                VS.Text = VSec.ToString();
                #endregion
                #region FminS
                FminS.Text = fms.ToString();
                #endregion
                #region avt
                avt.Text = notes.Count.ToString();
                #endregion
                #region nw
                nw.Text = AllowNote.ToString();
                #endregion
                #region NoteFreq
                NoteFreq.Text = f.ToString();
                #endregion
                #region ScoreDisplay
                ScoreDisplay.Text = score.ToString();
                #endregion
                #region MultiplierDisplay
                MultiplierDisplay.Text = multiplier.ToString();
                #endregion
                #region streakdisplay
                streakdisplay.Text = streak.ToString();
                #endregion
                #region ComboView
                if (streak < 100)
                {
                    ComboView.Text = streak + " Hit";
                    ComboView.ForeColor = Color.FromArgb(intensity, 190, 122, 60);
                }
                else
                {
                    ComboView.Text = streak + " HIT!!";
                    ComboView.ForeColor = Color.FromArgb(intensity, 230, 90, 120);
                }
                if (intensity > 50 && streak > 30)
                    ComboView.Visible = true;
                else
                    ComboView.Visible = false;
                #endregion
                #region BytesVis
                BytesVis.Text = TimeSinceReadingStarted.ElapsedMilliseconds.ToString() + ", " + bytes + ", " + ((bytes - 36) / BytesPerSecond) + ", " + BytesPerSecond + ", " + br.BaseStream.Length;
                #endregion
                #endregion
                #region notemaking
                if (avc >= AvcNoteMakeLimit & AllowNote)
                {
                    #region note not made already
                    if (!NoteMadeAlready)
                    {
                        #region 256
                        if (BytesPerSample == 1 || (BytesPerSample == 2 && IsStereo == true))
                        {
                            if (ti / 256.0 > 0.4)
                            {
                                notes.Add(new note(TapperRail.centre));
                                Waiting = true;
                                NoteMadeAlready = true;
                            }
                        }
                        #endregion
                        #region 65536
                        if (BytesPerSample == 4 || (BytesPerSample == 2 && IsStereo == false))
                        {
                            if (ti / 256.0 > 0.4)
                            {
                                notes.Add(new note(TapperRail.centre));
                                Waiting = true;
                                NoteMadeAlready = true;
                            }
                        }
                        #endregion
                    }
                    #endregion
                    #region note made already
                    if (NoteMadeAlready)
                    {
                        #region 256
                        if (BytesPerSample == 1 || (BytesPerSample == 2 && IsStereo))
                        {
                            if ((VSec - VFirst) / 256.0 * 10000.0 > notemakeConstant && AllowNote)
                            {
                                #region Frequencies
                                if (f == Frequency.higher)
                                    notes.Add(new note(TapperRail.right));
                                if (f == Frequency.same)
                                    notes.Add(new note(TapperRail.centre));
                                if (f == Frequency.lower)
                                    notes.Add(new note(TapperRail.left));
                                if (f == Frequency.vhigh)
                                    notes.Add(new note(TapperRail.left));
                                if (f == Frequency.vlow)
                                    notes.Add(new note(TapperRail.right));
                                if (f == Frequency.BLAST)
                                    notes.Add(new note(TapperRail.centre));
                                if (f == Frequency.nulled)
                                    notes.Add(new note(TapperRail.centre));
                                #endregion
                                #region Double note
                                if (f == Frequency.doublenote)
                                {
                                    ti9 = rnd.Next(1, 4);
                                    if (ti9 == 1)
                                    {
                                        notes.Add(new note(TapperRail.left));
                                        notes.Add(new note(TapperRail.centre));
                                    }
                                    if (ti9 == 2)
                                    {
                                        notes.Add(new note(TapperRail.centre));
                                        notes.Add(new note(TapperRail.right));
                                    }
                                    if (ti9 == 3)
                                    {
                                        notes.Add(new note(TapperRail.left));
                                        notes.Add(new note(TapperRail.right));
                                    }
                                }
                                #endregion
                                NF2.Text = f.ToString();
                                Waiting = true;
                                NeedToTimeWait = true;
                            }
                        }
                        #endregion
                        #region 65536
                        if (BytesPerSample == 4 || (BytesPerSample == 2 && !IsStereo))
                        {
                            if ((VSec - VFirst) / 65536.0 * 10000.0 > notemakeConstant & AllowNote)
                            {
                                #region Frequencies
                                if (f == Frequency.higher)
                                    notes.Add(new note(TapperRail.right));
                                if (f == Frequency.same)
                                    notes.Add(new note(TapperRail.centre));
                                if (f == Frequency.lower)
                                    notes.Add(new note(TapperRail.left));
                                if (f == Frequency.vhigh)
                                    notes.Add(new note(TapperRail.left));
                                if (f == Frequency.vlow)
                                    notes.Add(new note(TapperRail.right));
                                if (f == Frequency.BLAST)
                                    notes.Add(new note(TapperRail.centre));
                                if (f == Frequency.nulled)
                                    notes.Add(new note(TapperRail.centre));
                                #endregion
                                #region Double note
                                if (f == Frequency.doublenote)
                                {
                                    ti9 = rnd.Next(1, 4);
                                    if (ti9 == 1)
                                    {
                                        notes.Add(new note(TapperRail.left));
                                        notes.Add(new note(TapperRail.centre));
                                    }
                                    if (ti9 == 2)
                                    {
                                        notes.Add(new note(TapperRail.centre));
                                        notes.Add(new note(TapperRail.right));
                                    }
                                    if (ti9 == 3)
                                    {
                                        notes.Add(new note(TapperRail.left));
                                        notes.Add(new note(TapperRail.right));
                                    }
                                }
                                #endregion
                                NF2.Text = f.ToString();
                                Waiting = true;
                                NeedToTimeWait = true;
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
                if (notes.Count > 1)
                {
                    #region note deleting if too close to each other
                    for (int i = 0; i < notes.Count; i++)
                    {
                        note n1 = notes[i] as note;
                        note n2 = null;
                        int j;
                        for (j = 0; j < notes.Count - i - 1; j++)
                        {
                            if ((notes[i + j + 1] as note).tr == n1.tr)
                            {
                                n2 = notes[i + j + 1] as note;
                                break;
                            }
                        }
                        if (n2 == null) break;
                        if (Math.Abs(n2.y - n1.y) < 15)
                        {
                            notes.RemoveAt(i + j + 1);
                        }
                    }
                    #endregion
                }
                #region if waiting is true
                if (Waiting)
                {
                    AllowNote = false;
                    #region Need to time wait section
                    if (NeedToTimeWait)
                    {
                        WaitTime.Start();
                        NeedToTimeWait = false;
                    }
                    #endregion
                    #region To wait for another note to be made
                    if (WaitTime.ElapsedMilliseconds > MillSecWaitTime)
                    {
                        #region 256
                        if (BytesPerSample == 1 || (BytesPerSample == 2 && IsStereo == true))
                        {
                            if (fms > FmsTriggerValue)
                            {
                                WaitTime.Reset();
                                AllowNote = true; NeedToTimeWait = true;
                            }
                        }
                        #endregion
                        #region 65536
                        if ((BytesPerSample == 2 && IsStereo == true) || BytesPerSample == 4)
                        {
                            if (fms > FmsTriggerValue)
                            {
                                WaitTime.Reset();
                                AllowNote = true; NeedToTimeWait = true;
                            }
                        }
                        #endregion
                    }
                    #endregion
                }
                #endregion
                #region MU171|=1I3|-!!! (multiplier)
                if (streak < 20) multiplier = 1;
                else if (streak > 19 && streak < 30) multiplier = 2;
                else if (streak > 29 && streak < 40) multiplier = 3;
                else if (streak > 39 && streak < 50) multiplier = 4;
                else if (streak > 49 && streak < 100) multiplier = 8;
                else if (streak > 99) multiplier = 16;
                #endregion
                #region intensity manip
                if (intensity > 0)
                    intensity--;
                if (fail > 0)
                    fail--;
                #endregion
                #region Byte reading position update
                bytes = Convert.ToInt64(TimeSinceReadingStarted.ElapsedMilliseconds / 1000.0 * BytesPerSecond) + 36;
                #endregion
                #region Green Separator Graphics Manipulation
                try
                {
                    if (multiplier < 4)
                    {
                        label4.BackColor = Color.FromArgb(intensity, 225, feeling * 2); label5.BackColor = Color.FromArgb(intensity, 225, feeling);
                    }
                    if (multiplier == 4)
                    {
                        label4.BackColor = Color.FromArgb((255 - intensity) / 2, 100, feeling * 2); label5.BackColor = Color.FromArgb((255 - intensity) / 2, 100, 100 + feeling * 2);
                    }
                    if (multiplier == 8)
                    {
                        label4.BackColor = Color.FromArgb(intensity, 100, Convert.ToInt32(feeling * 2.4)); label5.BackColor = Color.FromArgb(intensity, 100, 100 + Convert.ToInt32(feeling * 2.4));
                    }
                    if (multiplier == 16)
                    {
                        label4.BackColor = Color.FromArgb(feeling * 2, 100, feeling * 2); label5.BackColor = Color.FromArgb(feeling * 2, 100, feeling * 2);
                    }
                    label4.Location = new Point(165, 50 - (2 ^ (Convert.ToInt32(feeling * 2))));
                    label5.Location = new Point(235, 50 - (2 ^ (Convert.ToInt32(intensity))));
                }
                catch { }
                #endregion
            }
            #endregion
            #region CATCH!
            catch (System.IO.EndOfStreamException)
            {

                RTS.Stop();
                time.Stop();
                vldTimer.Stop();
                TimeSinceReadingStarted.Stop();
            }
            #endregion
            #region end stuff...
            System.Threading.Thread.Sleep(0);
            System.Threading.Thread.Sleep(0);
            System.Threading.Thread.Sleep(0);
            pictureBox1.Invalidate();
            #endregion
        }
        #endregion
        #region KeyPress
        private void KP(object sender, KeyPressEventArgs e)
        {
            note TNForCounterLoop;
            note n;
            for (int count = 0; count < notes.Count; count++)//This is the "is closest" loop
            {
                n = notes[count] as note;
                #region left
                if (n.tr == TapperRail.left)
                {
                    if (n.y > ClosestYTo580pxl && n.y > 420 && n.y < 585)
                    {
                        for (int counter = 0; counter < notes.Count; counter++)
                        {
                            TNForCounterLoop = notes[counter] as note;
                            if (TNForCounterLoop.tr == TapperRail.left)
                                TNForCounterLoop.Tappable = false;
                            notes[counter] = TNForCounterLoop as note;
                        }
                        n.Tappable = true;
                        ClosestYTo580pxl = n.y;
                    }
                }
                #endregion
                #region centre
                if (n.tr == TapperRail.centre)
                {
                    if (n.y > ClosestYTo580pxc && n.y > 420 && n.y < 585)
                    {
                        for (int counter = 0; counter < notes.Count; counter++)
                        {
                            TNForCounterLoop = notes[counter] as note;
                            if (TNForCounterLoop.tr == TapperRail.centre)
                                TNForCounterLoop.Tappable = false;
                            notes[counter] = TNForCounterLoop as note;
                        }
                        n.Tappable = true;
                        ClosestYTo580pxc = n.y;
                    }
                }
                #endregion
                #region right
                if (n.tr == TapperRail.right)
                {
                    if (n.y > ClosestYTo580pxr && n.y > 420 && n.y < 585)
                    {
                        for (int counter = 0; counter < notes.Count; counter++)
                        {
                            TNForCounterLoop = notes[counter] as note;
                            if (TNForCounterLoop.tr == TapperRail.right)
                                TNForCounterLoop.Tappable = false;
                            notes[counter] = TNForCounterLoop as note;
                        }
                        n.Tappable = true;
                        ClosestYTo580pxr = n.y;
                    }
                }
                #endregion
                #region Note hit check
                if (n.Tappable)
                {
                    if (e.KeyChar == Convert.ToChar("i") && n.tr == TapperRail.left)
                    {
                        #region POINTS!!!!
                        if (n.IsBetween(490, 510)) { score += 600 * multiplier; streak++; AccuracyDisplay.Text = "PERFECT!"; }
                        else if (n.IsBetween(470, 530)) { score += 300 * multiplier; streak++; AccuracyDisplay.Text = "GREAT!"; }
                        else if (n.IsBetween(460, 540)) { score += 150 * multiplier; streak++; AccuracyDisplay.Text = "GOOD!"; }
                        else if (n.IsBetween(450, 550)) { score += 100 * multiplier; streak++; AccuracyDisplay.Text = "NORMAL!"; }
                        else if (n.IsBetween(420, 585)) { score += 50 * multiplier; streak++; AccuracyDisplay.Text = "BAD"; }
                        #endregion
                        leftfx.Start();
                        AnyChosenAtAll = true;
                        n.IsToDelete = true;
                        break;
                    }
                    if (e.KeyChar == Convert.ToChar("o") && n.tr == TapperRail.centre)
                    {
                        #region POINTS!!!!
                        if (n.IsBetween(490, 510)) { score += 600 * multiplier; streak++; AccuracyDisplay.Text = "PERFECT!"; }
                        else if (n.IsBetween(470, 530)) { score += 300 * multiplier; streak++; AccuracyDisplay.Text = "GREAT!"; }
                        else if (n.IsBetween(460, 540)) { score += 150 * multiplier; streak++; AccuracyDisplay.Text = "GOOD!"; }
                        else if (n.IsBetween(450, 550)) { score += 100 * multiplier; streak++; AccuracyDisplay.Text = "NORMAL!"; }
                        else if (n.IsBetween(420, 585)) { score += 50 * multiplier; streak++; AccuracyDisplay.Text = "BAD"; }
                        #endregion
                        centrefx.Start();
                        AnyChosenAtAll = true;
                        n.IsToDelete = true;
                        break;
                    }
                    if (e.KeyChar == Convert.ToChar("p") && n.tr == TapperRail.right)
                    {
                        #region POINTS!!!!
                        if (n.IsBetween(490, 510)) { score += 600 * multiplier; streak++; AccuracyDisplay.Text = "PERFECT!"; }
                        else if (n.IsBetween(470, 530)) { score += 300 * multiplier; streak++; AccuracyDisplay.Text = "GREAT!"; }
                        else if (n.IsBetween(460, 540)) { score += 150 * multiplier; streak++; AccuracyDisplay.Text = "GOOD!"; }
                        else if (n.IsBetween(450, 550)) { score += 100 * multiplier; streak++; AccuracyDisplay.Text = "NORMAL!"; }
                        else if (n.IsBetween(420, 585)) { score += 50 * multiplier; streak++; AccuracyDisplay.Text = "BAD"; }
                        #endregion
                        rightfx.Start();
                        AnyChosenAtAll = true;
                        n.IsToDelete = true;
                        break;
                    }
                }
                #endregion
            }
            ClosestYTo580pxl = 0;
            ClosestYTo580pxc = 0;
            ClosestYTo580pxr = 0;
            ClosestYTo580pxf = 0;
            #region if not AnyChosenAtAll
            if (!AnyChosenAtAll)
            {
                score -= 100; multiplier = 1; streak = 0; AccuracyDisplay.Text = "OVER-TAP!"; if (fail < 180) fail += 75; else fail = 255;
            }
            AnyChosenAtAll = false;
            #endregion
        }
        #endregion
        #region GameFormClosed
        private void GameFormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Dispose();
            br.Dispose();
            fs.Dispose();
            Form tf = new MainMenu();
            tf.Show();
        }
        #endregion
    }
    #region enums
    #region Frequency enum
    public enum Frequency
    {
        higher,
        lower,
        same,// About there (+- 20 amplitude for 8-bit, +- 5120)
        vhigh,
        vlow,
        nulled,//Almost zero amplitude (less than 4/256; less than 1024/65536)
        BLAST,//Very high amplitude (more than 240/256; more than 61440/65536)
        doublenote//Scans a continuing pattern AKA: 141 25 158 32 175 39 (Separate notes: 141 158 175, 25 32 39)
    }
    #endregion
    #region TapperRail enum
    public enum TapperRail
    {
        left,
        centre,
        right
    }
    #endregion
    #endregion
    #region Other functions
    #endregion
    #region note class
    public class note
    {
        public int y = 0;
        public TapperRail tr;
        public bool Tappable = false;
        public bool IsToDelete = false;
        public note(TapperRail tr)
        {
            this.tr = tr;
        }
        public bool IsBetween(int smallerYValue, int biggerYValue)
        {
            if (y > smallerYValue && y < biggerYValue) return true;
            return false;
        }
    }
    #endregion
    #region VolLineDisplayClass
    public class VolLineDisplay
    {
        public int lengthpx;
        public int y;
        public VolLineDisplay(int lengthpx)
        {
            y = 0;
            this.lengthpx = lengthpx;
        }
    }
    #endregion
    #region noteID class
    //public class noteID
    //{
    //    public int y;//Get
    //    public TapperRail TR;//Get
    //    public int count;//Set
    //    public bool IsChosen = false;
    //    public noteID(int y, TapperRail TR)
    //    {
    //        this.y = y;
    //        this.TR = TR;
    //    }
    //}
    #endregion
}